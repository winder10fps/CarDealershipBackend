using CarDealershipBackend.Data;
using CarDealershipBackend.Endpoints.Types;

namespace CarDealershipBackend.Endpoints.Clients
{
    /// <summary>
    /// Эндпоинт для удаления клиента
    /// </summary>
    public class DeleteClientEndpoint : EndpointWithId
    {
        protected override async Task<IResult> ExecuteAsync(int id, AppDbContext db)
        {
            var searchedClient = await db.Clients.FindAsync(id);

            if (searchedClient is null)
            {
                return Results.NotFound();
            }

            db.Clients.Remove(searchedClient);
            await db.SaveChangesAsync();

            return Results.Ok();
        }
    }
}
