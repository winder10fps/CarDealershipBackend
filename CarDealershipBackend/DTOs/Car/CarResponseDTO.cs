namespace CarDealershipBackend.DTOs.Car
{
    public record CarResponseDTO(
        int Id,
        string? Brand,
        string? Model,
        int ReleaseYear,
        string? Color,
        decimal Price,
        string? Condition
    );
}
