using CarDealershipBackend.Data;
using CarDealershipBackend.Endpoints.Types;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipBackend.Endpoints.Cars
{
    public class DeleteCarEndpoint : EndpointWithId
    {
        protected override async Task<IResult> ExecuteAsync(int id, AppDbContext db)
        {
            var searchedCar = await db.Cars.FindAsync(id);

            if (searchedCar is null)
            {
                return Results.NotFound();
            }

            db.Cars.Remove(searchedCar);
            await db.SaveChangesAsync();

            return Results.Ok();
        }
    }
}
