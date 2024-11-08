using AgileMaintenceAPI.Context;
using AgileMaintenceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgileMaintenceAPI.Controllers
{
    [Route("api/auto-repair")]
    [ApiController]
    public class AutoRepairController : ControllerBase
    {
        private readonly AgileMaintenceAPIContext _context;

        public AutoRepairController(AgileMaintenceAPIContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public ActionResult Post(AutoRepairEntity autoRepair)
        {
            if (autoRepair == null)
            {
                return BadRequest();
            }

            _context.AutoRepairs.Add(autoRepair);
            _context.SaveChanges();

            return Ok(autoRepair);
        }

        [HttpGet("get-all")]
        public ActionResult<IEnumerable<AutoRepairEntity>> Get()
        {
            var autoRepair = _context.AutoRepairs.ToList();
            if (autoRepair == null)
            {
                return NotFound("Nenhuma oficina cadastrada");
            }

            return autoRepair;
        }

        [HttpGet("get-by-id/{AutoRepairId:guid}/")]
        public ActionResult<IEnumerable<object>> GetAddressClient(Guid AutoRepairId)
        {

            var autoRepairResult = _context.AutoRepairs
                .Where(a => a.Id == AutoRepairId);
                


            if (autoRepairResult == null || !autoRepairResult.Any())
            {
                return NotFound("Nenhuma oficina encontrada");
            }

            return Ok(autoRepairResult);
        }

        [HttpPut("update/{id:guid}")]
        public ActionResult Put(Guid id, AutoRepairEntity autoRepair)
        {
            if (id != autoRepair.Id)
            {
                return BadRequest("Oficina solicitada não existe");
            }
            _context.Entry(autoRepair).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(autoRepair);
            ;
        }

        [HttpDelete("delete/{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            var autoRepair = _context.AutoRepairs.FirstOrDefault(a => a.Id == id);
            if (autoRepair == null)
            {
                return NotFound("Oficina não encontrada");
            }
            _context.AutoRepairs.Remove(autoRepair);
            _context.SaveChanges();
            return Ok(autoRepair);
        }


    }
}
