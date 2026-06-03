using CarDealershipBackend.DTOs.Car;

namespace CarDealershipBackend.Validation
{
    public record ValidationError(string ErrorCode, string ErrorMessage);

    public static class Validation
    {
        const int MIN_YEAR = 1990;
        const decimal MIN_PRICE = 10000;
        const decimal MAX_PRICE = 50000000;

        public static ValidationError? ValidateCar(CarRequestDTO request)
        {
            if (request is null ||
                string.IsNullOrEmpty(request.Brand) ||
                string.IsNullOrEmpty(request.Model) ||
                string.IsNullOrEmpty(request.Color) ||
                string.IsNullOrEmpty(request.Condition))
            {
                return new("INVALID_DATA", "Все поля обязательны для заполнения");
            }

            if (request.ReleaseYear < MIN_YEAR || request.ReleaseYear > DateTime.Now.Year)
            {
                return new("INVALID_YEAR", "Год должен быть не меньше 1990 и не больше текущего");
            }

            if (request.Price < MIN_PRICE || request.Price > MAX_PRICE)
            {
                return new("INVALID_PRICE", "Цена должна быть в диапазоне от 10000 до 50000000");
            }

            return null;
        }
    }
}
