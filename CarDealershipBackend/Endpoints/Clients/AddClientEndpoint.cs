using CarDealershipBackend.Data;
using CarDealershipBackend.DTOs.Client;
using CarDealershipBackend.Endpoints.Types;
using CarDealershipBackend.Models;
using static CarDealershipBackend.Validation.Validation;

namespace CarDealershipBackend.Endpoints.Clients
{
    public class AddClientEndpoint : EndpointWithBody<ClientRequestDTO>
    {
        protected override async Task<IResult> ExecuteAsync(ClientRequestDTO request, AppDbContext db)
        {
            var validateClient = ValidateClient(request);

            if (validateClient is not null)
            {
                return Results.BadRequest(new
                {
                    error = validateClient.ErrorCode,
                    message = validateClient.ErrorMessage
                });
            }

            var newClient = new Client
            {
                FCs = request.FCs,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                PurchaseDate = request.PurchaseDate
            };

            db.Clients.Add(newClient);
            await db.SaveChangesAsync();

            var response = new ClientResponseDTO(
                newClient.Id,
                newClient.FCs,
                newClient.PhoneNumber,
                newClient.Address,
                newClient.PurchaseDate
            );

            return Results.Created($"/clients/{response.Id}", response);
        }
    }
}
