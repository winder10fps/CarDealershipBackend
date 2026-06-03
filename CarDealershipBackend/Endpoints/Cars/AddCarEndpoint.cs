using CarDealershipBackend.Data;
using CarDealershipBackend.DTOs.Car;
using CarDealershipBackend.Endpoints.Types;
using CarDealershipBackend.Models;
using static CarDealershipBackend.Validation.Validation;

namespace CarDealershipBackend.Endpoints.Cars
{
    public class AddCarEndpoint : EndpointWithBody<CarRequestDTO>
    {
        protected override async Task<IResult> ExecuteAsync(CarRequestDTO request, AppDbContext db)
        {
            var validateCar = ValidateCar(request);

            if (validateCar is not null)
            {
                return Results.BadRequest(new
                {
                    error = validateCar.ErrorCode,
                    message = validateCar.ErrorMessage
                });
            }

            var newCar = new Car 
            { 
                Brand = request.Brand,
                Model = request.Model,
                ReleaseYear = request.ReleaseYear,
                Color = request.Color,
                Price = request.Price,
                Condition = request.Condition,
            };

            db.Cars.Add(newCar);
            await db.SaveChangesAsync();

            var response = new CarResponseDTO(
                newCar.Id,
                newCar.Brand,
                newCar.Model,
                newCar.ReleaseYear,
                newCar.Color,
                newCar.Price,
                newCar.Condition
            );

            return Results.Created($"/cars/{response.Id}", response);
        }
    }
}
