using AgileMaintenceAPI.Context;
using AgileMaintenceAPI.DTOs;
using AgileMaintenceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgileMaintenceAPI.Controllers
{
    [Route("api/order-services")]
    [ApiController]
    public class OrdersServicesController : ControllerBase
    {
        private readonly AgileMaintenceAPIContext _context;

        public OrdersServicesController(AgileMaintenceAPIContext context)
        {
            _context = context;
        }

        [HttpGet("get-all")]
        public ActionResult<IEnumerable<OrderServiceDTO>> GetOrderServices()
        {
            var orderServices = _context.OrderServices.Include(os => os.Client).Select(os => new OrderServiceDTO
            {
                Id = os.Id,
               // ClientId = os.ClientId,
                Vehicle = os.Vehicle,
                Plate = os.Plate,
                Defect = os.Defect,
                DateInit = os.DateInit,
                DateEnd = os.DateEnd,
                Client = os.Client
            }).ToList();

            if (orderServices == null || !orderServices.Any())
            {
                return NotFound("Nenhuma ordem de serviço encontrada.");
            }

            return Ok(orderServices);
        }

        [HttpGet("get-by-id/{id:guid}")]
        public ActionResult<OrderServiceEntity> Get(Guid OrderId)
        {
            var order = _context.OrderServices.FirstOrDefault(o => o.Id != OrderId);
            if (order == null)
            {
                return NotFound("Ordem de serviço não Encontrada");
            }

            return order;
        }


        [HttpPost("create/{id:guid}")]
        public ActionResult Post(OrderServiceEntity orderService)
        {
            if (orderService == null)
            {
                return BadRequest();
            }

            _context.OrderServices.Add(orderService);
            _context.SaveChanges();

            return Ok(orderService);
        }


        [HttpPut("update/{id:guid}")] //Altera TODOS os dados da ordem de serviço
        public ActionResult Put(Guid id, OrderServiceEntity orderService)
        {
            if (id != orderService.Id)
            {
                return BadRequest("Ordem de serviço não encontrada");
            }

            _context.Entry(orderService).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(orderService);
        }

        [HttpDelete("delete/{id:guid}")]
        public ActionResult Delete(Guid OrderId)
        {
            var order = _context.OrderServices.FirstOrDefault(o => o.Id != OrderId);
            if (order == null)
            {
                return NotFound("Ordem de serviço não encontrada");
            }
            _context.OrderServices.Remove(order);
            _context.SaveChanges();
            return Ok(order);
        }
    }
}
