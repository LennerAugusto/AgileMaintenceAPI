using AgileMaintenceAPI.Context;
using AgileMaintenceAPI.DTOs.AddressesDTO;
using AgileMaintenceAPI.DTOs.ClientDTO;
using AgileMaintenceAPI.Models;
using AgileMaintenceAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AgileMaintenceAPI.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AgileMaintenceAPIContext _context;

        public ClientsController(AgileMaintenceAPIContext context)
        {
            _context = context;
        }

        [HttpGet("get-all")]
        public ActionResult<IEnumerable<ClientEntity>> GetAllClient()
        {
            var clients = _context.Clients.ToList();
            if (clients == null)
            {
                return NotFound("Não existe clientes cadastrados");
            }

            return clients;
        }
        
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetClientById(Guid ClientId)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id != ClientId);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost("create")]
        public async Task<ActionResult<ClientDTO>> CreateClient(ClientDTO createClientDto)
        {
            if (createClientDto.Adresses == null || !createClientDto.Adresses.Any())
            {
                return BadRequest("At least one address must be provided.");
            }
            var client = new ClientEntity
            {
                Name = createClientDto.Name,
                Cpf = createClientDto.Cpf,
                Phone = createClientDto.Phone,
                IsAcive = true,
                Adresses = new List<AdressesEntity>()

            };

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Clients.AddAsync(client);
                    await _context.SaveChangesAsync(); 

                    foreach (var addrDto in createClientDto.Adresses)
                    {
                        var address = new AdressesEntity
                        {
                            ClientId = client.Id, 
                            Name = addrDto.Name,
                            Number = addrDto.Number,
                            Logradouro = addrDto.Logradouro,
                            City = addrDto.City,
                            State = addrDto.State,
                            ZipCode = addrDto.ZipCode,
                            IsAcive = true,
                        };

                        client.Adresses.Add(address); 
                        await _context.Adresses.AddAsync(address); 
                    }

                    await _context.SaveChangesAsync(); 
                    await transaction.CommitAsync(); 
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
        }

        [HttpPut("update/{id:guid}")] 
        public ActionResult Put(Guid id, ClientEntity client)
        {
            if(id != client.Id)
            {
                return BadRequest("Cliente solicitado não existe");
            }
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(client);
;       }
        
        [HttpDelete("delete/{id:guid}")]
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
