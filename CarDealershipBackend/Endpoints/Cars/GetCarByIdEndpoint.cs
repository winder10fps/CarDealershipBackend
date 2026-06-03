using CarDealershipBackend.Data;
using CarDealershipBackend.DTOs.Car;
using CarDealershipBackend.Endpoints.Types;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipBackend.Endpoints.Cars
{
    public class GetCarByIdEndpoint : EndpointWithId
    {
        protected override async Task<IResult> ExecuteAsync(int id, AppDbContext db)
        {
            var searchedCar = await db.Cars.FindAsync(id);

            if (searchedCar is null)
            {
                return Results.NotFound();
            }

            var response = new CarResponseDTO(
                searchedCar.Id, 
                searchedCar.Brand, 
                searchedCar.Model, 
                searchedCar.ReleaseYear, 
                searchedCar.Color, 
                searchedCar.Price, 
                searchedCar.Condition
            );


            return Results.Ok(response);
        }
    }
}
