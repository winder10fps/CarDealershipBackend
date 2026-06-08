namespace CarDealershipBackend.DTOs.Manager
{
    /// <summary>
    /// DTO для отправки менеджера
    /// </summary>
    public record ManagerResponseDTO(
        int Id,
        string? Login
    );
}
