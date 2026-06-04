using CarDealershipBackend.Data;
using CarDealershipBackend.DTOs.Client;
using CarDealershipBackend.Endpoints.Types;
using static CarDealershipBackend.Validation.Validation;

namespace CarDealershipBackend.Endpoints.Clients
{
    public class UpdateClientEndpoint : EndpointWithBodyAndId<ClientRequestDTO>
    {
        protected override async Task<IResult> ExecuteAsync(int id, ClientRequestDTO request, AppDbContext db)
        {
            var searchedClient = await db.Clients.FindAsync(id);

            if (searchedClient is null)
            {
                return Results.NotFound();
            }

            var validateClient = ValidateClient(request);

            if (validateClient is not null)
            {
                return Results.BadRequest(new
                {
                    error = validateClient.ErrorCode,
                    message = validateClient.ErrorMessage
                });
            }

            searchedClient.FCs = request.FCs;
            searchedClient.PhoneNumber = request.PhoneNumber;
            searchedClient.Address = request.Address;
            searchedClient.PurchaseDate = request.PurchaseDate;

            await db.SaveChangesAsync();

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
