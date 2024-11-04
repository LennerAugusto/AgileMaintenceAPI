using AgileMaintenceAPI.Context;
using AgileMaintenceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgileMaintenceAPI.Service
{
    public class ClientService
    {
        private readonly AgileMaintenceAPIContext _context;

        public ClientService(AgileMaintenceAPIContext context)
        {
            _context = context;
        }

        public async Task<ClientEntity> GetClienteWithEnderecosAsync(Guid clientId)
        {
            return await _context.Clients.Include(c => c.Adresses).FirstOrDefaultAsync(c => c.Id == clientId);
        }
    }
}
