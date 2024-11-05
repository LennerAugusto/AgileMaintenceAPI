using AgileMaintenceAPI.Context;
using AgileMaintenceAPI.DTOs.OrderServices;
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

        [HttpGet("get-by-clientid{ClientId:guid}")]
        public ActionResult<IEnumerable<OrderServiceDTO>> GetOrderServicesByClientId(Guid ClientId)
        {
            var orderServices = _context.OrderServices.Include(os => os.Client)
                .Where(os => os.Id == ClientId)
                .Select(os => new OrderServiceCreateDTO
            {
                Id = os.Id,
                ClientId = os.ClientId,
                Vehicle = os.Vehicle,
                Plate = os.Plate,
                Defect = os.Defect,
                DateInit = os.DateInit,
                DateEnd = os.DateEnd,
            }).ToList();

            if (orderServices == null || !orderServices.Any())
            {
                return NotFound("Nenhuma ordem de serviço encontrada.");
            }

            return Ok(orderServices);
        }

        [HttpGet("get-by-id/{id:guid}")]
        public ActionResult<OrderServiceEntity> GetById(Guid OrderId)
        {
            var order = _context.OrderServices.FirstOrDefault(o => o.Id != OrderId);
            if (order == null)
            {
                return NotFound("Ordem de serviço não Encontrada");
            }

            return order;
        }

        [HttpGet("get-all")]
        public ActionResult<List<OrderServiceEntity>> GetAll()
        {
            var order = _context.OrderServices.ToList();
            if (order == null)
            {
                return NotFound("Nenhuma ordem de serviço encontrada");
            }

            return order;
        }


        [HttpPost("create")]
        public ActionResult Post(OrderServiceCreateDTO orderServiceDto)
        {
            if (orderServiceDto == null)
            {
                return BadRequest();
            }

            var orderServiceEntity = new OrderServiceEntity
            {
                Id = Guid.NewGuid(),
                ClientId = orderServiceDto.ClientId,
                Vehicle = orderServiceDto.Vehicle,
                Plate = orderServiceDto.Plate,
                Defect = orderServiceDto.Defect,
                DateInit = orderServiceDto.DateInit,
                DateEnd = orderServiceDto.DateEnd,
            };

            _context.OrderServices.Add(orderServiceEntity);
            _context.SaveChanges();

            return Ok(orderServiceEntity);
        }

        [HttpPut("update/{id:guid}")] 
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
