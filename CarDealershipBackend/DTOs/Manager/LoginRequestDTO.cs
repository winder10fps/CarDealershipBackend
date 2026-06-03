namespace CarDealershipBackend.DTOs.Manager
{
    public record LoginRequestDTO(
        string? Login,
        string? Password
    );
}
