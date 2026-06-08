namespace CarDealershipBackend.DTOs.Client
{
    /// <summary>
    /// DTO для запросов, связанных с клиентом
    /// </summary>
    public record ClientRequestDTO(
        string? FCs,
        string? PhoneNumber,
        string? Address,
        DateOnly PurchaseDate
    );
}
