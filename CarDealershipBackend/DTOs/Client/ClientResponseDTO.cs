namespace CarDealershipBackend.DTOs.Client
{
    public record ClientResponseDTO(
        int Id,
        string? FCs,
        string? PhoneNumber,
        string? Address,
        DateOnly PurchaseDate
    );
}
