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
        public ActionResult<IEnumerable<ClientResponseDTO>> GetAllClient()
        {
            var clients = _context.Clients
                .Include(c => c.Adresses) 
                .Select(c => new ClientResponseDTO
                {
                    Id = c.Id,  
                    Name = c.Name,
                    Cpf = c.Cpf,
                    Phone = c.Phone,
                    IsActive = c.IsAcive,
                    Adresses = c.Adresses.Select(a => new AdressesEntity
                    { 
                        ClientId = a.ClientId,
                        Name = a.Name,
                        Number = a.Number,
                        Logradouro = a.Logradouro,
                        City = a.City,
                        State = a.State
                    }).ToList()
                })
                .ToList();

            if (!clients.Any())
            {
                return NotFound("Não existem clientes cadastrados");
            }

            return Ok(clients);
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
        public async Task<ActionResult<ClientCreateDTO>> CreateClient(ClientCreateDTO createClientDto)
        {
            if (createClientDto.Adresses == null)
            {
                return BadRequest("Nenhum Endereço criado para o cliente");
            }

            createClientDto.Id = Guid.NewGuid();

            var addressDto = createClientDto.Adresses; 
            addressDto.Id = Guid.NewGuid();
            addressDto.ClientId = createClientDto.Id;
            addressDto.IsAcive = true; 

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Clients.AddAsync(new ClientEntity
                    {
                        Id = createClientDto.Id,
                        Name = createClientDto.Name,
                        Cpf = createClientDto.Cpf,
                        Phone = createClientDto.Phone,
                        IsAcive = true,
                        Adresses = new List<AdressesEntity>
                {
                    new AdressesEntity
                    {
                        Id = addressDto.Id,
                        ClientId = addressDto.ClientId,
                        Name = addressDto.Name,
                        Number = addressDto.Number,
                        Logradouro = addressDto.Logradouro,
                        City = addressDto.City,
                        State = addressDto.State,
                        ZipCode = addressDto.ZipCode,
                        IsAcive = addressDto.IsAcive,
                    }
                }
                    });

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            return CreatedAtAction(nameof(GetClientById), new { id = createClientDto.Id }, createClientDto);
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
