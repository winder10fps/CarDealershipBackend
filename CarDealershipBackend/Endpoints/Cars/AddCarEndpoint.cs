using CarDealershipBackend.Data;
using CarDealershipBackend.DTOs.Car;
using CarDealershipBackend.Models;

namespace CarDealershipBackend.Endpoints.Cars
{
    public class AddCarEndpoint : EndpointWithBody<CreateCarRequestDTO>
    {
        const int MIN_YEAR = 1990;
        const decimal MIN_PRICE = 10000;
        const decimal MAX_PRICE = 50000000;


        protected override async Task<IResult> ExecuteAsync(CreateCarRequestDTO request, AppDbContext db)
        {
            if (request is null || 
                string.IsNullOrEmpty(request.Brand) ||
                string.IsNullOrEmpty(request.Model) ||
                string.IsNullOrEmpty(request.Color) ||
                string.IsNullOrEmpty(request.Condition))
            {
                return Results.BadRequest(new
                {
                    error = "INVALID_DATA",
                    message = "Все поля обязательны для заполнения"
                });
            }

            if (request.ReleaseYear < MIN_YEAR || request.ReleaseYear > DateTime.Now.Year)
            {
                return Results.BadRequest(new
                {
                    error = "INVALID_YEAR",
                    message = "Год должен быть не меньше 1990 и не больше текущего"
                });
            }

            if (request.Price < MIN_PRICE || request.Price > MAX_PRICE)
            {
                return Results.BadRequest(new
                {
                    error = "INVALID_PRICE",
                    message = "Цена должна быть в диапазоне от 10000 до 50000000"
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

            var response = new CarResponseDTO
            {
                Id = newCar.Id,
                Brand = newCar.Brand,
                Model = newCar.Model,
                ReleaseYear = newCar.ReleaseYear,
                Color = newCar.Color,
                Price = newCar.Price,
                Condition = newCar.Condition
            };

            return Results.Created($"/cars/{response.Id}", response);
        }
    }
}
