using CarDealershipBackend.Data;
using CarDealershipBackend.DTOs.Car;
using CarDealershipBackend.Endpoints.Types;
using static CarDealershipBackend.Validation.Validation;

namespace CarDealershipBackend.Endpoints.Cars
{
    public class UpdeteCarEndpoint : EndpointWithBodyAndId<CarRequestDTO>
    {
        protected override async Task<IResult> ExecuteAsync(int id, CarRequestDTO request, AppDbContext db)
        {
            var searchedCar = await db.Cars.FindAsync(id);

            if (searchedCar is null)
            {
                return Results.NotFound();
            }

            var validateCar = ValidateCar(request);

            if (validateCar is not null)
            {
                return Results.BadRequest(new
                {
                    error = validateCar.ErrorCode,
                    message = validateCar.ErrorMessage
                });
            }

            searchedCar.Brand = request.Brand;
            searchedCar.Brand = request.Brand;
            searchedCar.Model = request.Model;
            searchedCar.ReleaseYear = request.ReleaseYear;
            searchedCar.Color = request.Color;
            searchedCar.Price = request.Price;
            searchedCar.Condition = request.Condition;

            await db.SaveChangesAsync();

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
