using CarDealershipBackend.Data;
using CarDealershipBackend.Endpoints.Cars;
using CarDealershipBackend.Endpoints.Managers;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Поддержка OpenAPI и Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=Dealeship.db"));

            var app = builder.Build();

            // Swagger в разработке
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Регистрация эндпоинтов
            new LoginEndpoint().Register(app, "/managers", "POST");

            new AddCarEndpoint().Register(app, "/cars", "POST");
            new GetAllCarsEndpoint().Register(app, "/cars");
            new GetCarByIdEndpoint().Register(app, "/cars/{id}", "GET");
            new DeleteCarEndpoint().Register(app, "/cars/{id}", "DELETE");
            new UpdeteCarEndpoint().Register(app, "/cars/{id}");

            app.Run();
        }
    }
}
