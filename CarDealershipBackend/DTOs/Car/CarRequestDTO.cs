namespace CarDealershipBackend.DTOs.Car
{
    public record CarRequestDTO(
        string? Brand, 
        string? Model, 
        int ReleaseYear, 
        string? Color, 
        decimal Price, 
        string? Condition
    );
}
