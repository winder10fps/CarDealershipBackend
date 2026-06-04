namespace CarDealershipBackend.DTOs.Client
{
    public record ClientRequestDTO(
        string? FCs,
        string? PhoneNumber,
        string? Address,
        DateOnly PurchaseDate
    );
}
