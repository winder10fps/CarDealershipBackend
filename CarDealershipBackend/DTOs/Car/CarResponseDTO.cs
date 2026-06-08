namespace CarDealershipBackend.DTOs.Car
{
    /// <summary>
    /// DTO для возвращения автомобиля на клиент
    /// </summary>
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
