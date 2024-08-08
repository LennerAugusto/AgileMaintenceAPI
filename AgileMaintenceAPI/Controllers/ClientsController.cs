using AgileMaintenceAPI.Context;
using AgileMaintenceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgileMaintenceAPI.Controllers
{
    [Route("clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AgileMaintenceAPIContext _context;

        public ClientsController(AgileMaintenceAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            var clients = _context.Clients.ToList();
            if (clients == null)
            {
                return NotFound("Não existe clientes cadastrados");
            }

            return clients;
        }

        [HttpGet("{id:guid}", Name = "ObterCliente")]
        public ActionResult<Client> GetClient(Guid clientId)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id != clientId);
            if (client == null)
            {
                return NotFound("Cliente Não Encontrado");
            }
            return client;
        }

        [HttpPost]
        public ActionResult Post(Client client)
        {
            if (client is null)
            {
                return BadRequest();
            }
            _context.Clients.Add(client);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCliente", new { id = client.Id }, client);
        }

        [HttpPut("{id:guid}")] //Altera TODOS os dados do cliente
        public ActionResult Put(Guid id, Client client)
        {
            if(id != client.Id)
            {
                return BadRequest("Cliente solicitado não existe");
            }
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(client);
;       }
        
        [HttpDelete("{id:guid}")]
        public ActionResult Delete(Guid id) 
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null) 
            {
                return NotFound("Cliente não encontrado");
            }
            _context.Clients.Remove(client);
            _context.SaveChanges();
            return Ok(client);
        }
    }
}
