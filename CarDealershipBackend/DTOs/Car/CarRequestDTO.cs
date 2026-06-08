namespace CarDealershipBackend.DTOs.Car
{
    /// <summary>
    /// DTO для запросов, связанных с автомобилем
    /// </summary>
    public record CarRequestDTO(
        string? Brand, 
        string? Model, 
        int ReleaseYear, 
        string? Color, 
        decimal Price, 
        string? Condition
    );
}
