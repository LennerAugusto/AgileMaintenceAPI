using AgileMaintenceAPI.Context;
using AgileMaintenceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgileMaintenceAPI.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly AgileMaintenceAPIContext _context;

        public AdressesController(AgileMaintenceAPIContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public ActionResult Post(AdressesEntity adress)
        {
            if (adress == null)
            {
                return BadRequest();
            }

            _context.Adresses.Add(adress);
            _context.SaveChanges();

            return Ok(adress);
        }

        [HttpGet("address-get-all")]
        public ActionResult<IEnumerable<AdressesEntity>> Get()
        {
            var adresses = _context.Adresses.ToList();
            if (adresses == null)
            {
                return NotFound("Endereços cadastrados");
            }

            return adresses;
        }

        [HttpGet("address-by-client-id/{Clientid:guid}/")]
        public ActionResult<IEnumerable<object>> GetAddressClient(Guid ClientId)
        {
           
            var adresses = _context.Adresses
                .Include(a => a.ClientId == ClientId)
                .Select(a => new
                {
                    a.Id,
                    a.ClientId,
                    a.Name,
                    a.Number,
                    a.Logradouro,
                    a.City,
                    a.State
                })
                .ToList();

            if (adresses == null || !adresses.Any())
            {
                return NotFound("Nenhum endereço cadastrado.");
            }

            return Ok(adresses);
        }

        [HttpPut("update/{id:guid}")]
        public ActionResult Put(Guid id, AdressesEntity adresses)
        {
            if (id != adresses.Id)
            {
                return BadRequest("Endereço solicitado não existe");
            }
            _context.Entry(adresses).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(adresses);
            ;
        }

        [HttpDelete("delete/{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            var adress = _context.Clients.FirstOrDefault(a => a.Id == id);
            if (adress == null)
            {
                return NotFound("Endereço não encontrado");
            }
            _context.Clients.Remove(adress);
            _context.SaveChanges();
            return Ok(adress);
        }
    }

}


