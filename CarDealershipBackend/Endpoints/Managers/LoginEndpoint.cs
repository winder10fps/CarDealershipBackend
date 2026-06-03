using CarDealershipBackend.Data;
using CarDealershipBackend.DTOs.Manager;
using CarDealershipBackend.Endpoints.Types;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace CarDealershipBackend.Endpoints.Managers
{
    public class LoginEndpoint: EndpointWithBody<LoginRequestDTO>
    {
        protected override async Task<IResult> ExecuteAsync(LoginRequestDTO request, AppDbContext db)
        {
            if (request is null || string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Password))
            {
                return Results.BadRequest(new
                {
                    error = "INVALID_DATA",
                    message = "Логин и пароль обязательный для ввода"
                });
            }

            var manager = await db.Managers.FirstOrDefaultAsync(m => m.Login == request.Login);

            if (manager is null || !BC.Verify(request.Password, manager.Password))
            {
                return Results.Unauthorized();
            }

            var response = new ManagerResponseDTO(manager.Id, manager.Login);

            return Results.Ok(response);
        }
    }
}
