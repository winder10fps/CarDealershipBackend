namespace CarDealershipBackend.DTOs.Client
{
    /// <summary>
    /// DTO для возвращения клиента
    /// </summary>
    public record ClientResponseDTO(
        int Id,
        string? FCs,
        string? PhoneNumber,
        string? Address,
        DateOnly PurchaseDate
    );
}
