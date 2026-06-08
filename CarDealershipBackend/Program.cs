using CarDealershipBackend.Data;
using CarDealershipBackend.Endpoints.Cars;
using CarDealershipBackend.Endpoints.Clients;
using CarDealershipBackend.Endpoints.Managers;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=Dealeship.db"));

            var app = builder.Build();

            if (app.Environment.IsDevelopment()) 
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Регистрация эндпоинтов
            new LoginEndpoint().Register(app, "/managers");

            new AddCarEndpoint().Register(app, "/cars");
            new GetAllCarsEndpoint().Register(app, "/cars");
            new GetCarByIdEndpoint().Register(app, "/cars/{id}", "GET");
            new DeleteCarEndpoint().Register(app, "/cars/{id}", "DELETE");
            new UpdeteCarEndpoint().Register(app, "/cars/{id}");

            new AddClientEndpoint().Register(app, "/clients");
            new DeleteClientEndpoint().Register(app, "/clients/{id}", "DELETE");
            new GetAllClientsEndpoint().Register(app, "/clients");
            new GetClientByIdEndpoint().Register(app, "/clients/{id}", "GET");
            new UpdateClientEndpoint().Register(app, "/clients/{id}");

            app.Run();
        }
    }
}
