using CarDealershipBackend.Data;
using CarDealershipBackend.DTOs.Client;
using CarDealershipBackend.Endpoints.Types;

namespace CarDealershipBackend.Endpoints.Clients
{
    public class GetClientByIdEndpoint : EndpointWithId
    {
        protected override async Task<IResult> ExecuteAsync(int id, AppDbContext db)
        {
            var searchedClient = await db.Clients.FindAsync(id);

            if (searchedClient is null)
            {
                return Results.NotFound();
            }

            var response = new ClientResponseDTO(
                searchedClient.Id,
                searchedClient.FCs,
                searchedClient.PhoneNumber,
                searchedClient.Address,
                searchedClient.PurchaseDate
            );

            return Results.Ok(response);
        }
    }
}
