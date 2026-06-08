using CarDealershipBackend.Data;
using CarDealershipBackend.DTOs.Client;
using CarDealershipBackend.Endpoints.Types;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipBackend.Endpoints.Clients
{
    /// <summary>
    /// Эндпоинт для получения списка всех клиентов
    /// </summary>
    public class GetAllClientsEndpoint:EndpointWithoutParams
    {
        protected override async Task<IResult> ExecuteAsync(AppDbContext db)
        {
            var allClients = await db.Clients.Select(c => new ClientResponseDTO(
                c.Id,
                c.FCs,
                c.PhoneNumber,
                c.Address,
                c.PurchaseDate
            )).ToListAsync();

            return Results.Ok(allClients);
        }
    }
}
