namespace CarDealershipBackend.DTOs.Manager
{
    /// <summary>
    /// DTO для отправки запроса на логин
    /// </summary>
    /// <param name="Login"></param>
    /// <param name="Password"></param>
    public record LoginRequestDTO(
        string? Login,
        string? Password
    );
}
