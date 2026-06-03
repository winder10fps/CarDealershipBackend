using CarDealershipBackend.Data;
using CarDealershipBackend.DTOs.Car;
using CarDealershipBackend.Endpoints.Types;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipBackend.Endpoints.Cars
{
    public class GetAllCarsEndpoint : EndpointWithoutParams
    {
        protected override async Task<IResult> ExecuteAsync(AppDbContext db)
        {
            var allCars = await db.Cars.Select(c => new CarResponseDTO(
                c.Id,
                c.Brand,
                c.Model,
                c.ReleaseYear,
                c.Color,
                c.Price,
                c.Condition
            )).ToListAsync();

            return Results.Ok(allCars);
        }
    }
}
