using AgileMaintenceAPI.Context;
using AgileMaintenceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgileMaintenceAPI.Controllers
{
    [Route("api/adress")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly AgileMaintenceAPIContext _context;

        public AdressesController(AgileMaintenceAPIContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Post(Adresses adress)
        {
            if (adress == null)
            {
                return BadRequest();
            }

            _context.Adresses.Add(adress);
            _context.SaveChanges();

            return Ok(adress);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Adresses>> Get()
        {
            var adresses = _context.Adresses.ToList();
            if (adresses == null)
            {
                return NotFound("Endereços cadastrados");
            }

            return adresses;
        }

        [HttpGet("address-by-client/{Clientid:guid}/")]
        public ActionResult<IEnumerable<object>> GetAddressClient(Guid id)
        {
           
            var adresses = _context.Adresses
                .Include(a => a.Client)
                .Select(a => new
                {
                    a.Id,
                    a.ClientId,
                    a.Name,
                    a.Number,
                    a.Logradouro,
                    a.City,
                    a.State,

                    Client = new
                    {
                        a.Client.Id,
                        a.Client.Name,
                        a.Client.Cpf,
                        a.Client.Phone,
                        a.Client.IsActive,
                    }
                })
                .ToList();

            if (adresses == null || !adresses.Any())
            {
                return NotFound("Nenhum endereço cadastrado.");
            }

            return Ok(adresses);
        }
    }
}


//d0491ba5-542c-4b60-993c-959f4200be51