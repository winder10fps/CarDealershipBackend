using CarDealershipBackend.DTOs.Car;
using CarDealershipBackend.DTOs.Client;
using System.Text.RegularExpressions;

namespace CarDealershipBackend.Validation
{
    public record ValidationError(string ErrorCode, string ErrorMessage);

    public static partial class Validation
    {
        const int MIN_YEAR = 1990;
        const decimal MIN_PRICE = 10000;
        const decimal MAX_PRICE = 50000000;
        const string PHONE_PATTERN = @"^\+?\d{10,15}$";

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


        public static ValidationError? ValidateClient(ClientRequestDTO request)
        {
            if (request is null ||
                string.IsNullOrEmpty(request.FCs) ||
                string.IsNullOrEmpty(request.PhoneNumber) ||
                string.IsNullOrEmpty(request.Address))
            {
                return new("INVALID_DATA", "Все поля обязательны для заполнения");
            }

            if (!PhoneNumberRegex().IsMatch(request.PhoneNumber))
            {
                return new("INVALID_PHONE", "Некорректный номер телефона");
            }

            if (request.PurchaseDate > DateOnly.FromDateTime(DateTime.Now))
            {
                return new("INVALID_PURCHASE_DATE", "Дата покупки не может быть больше текущей");
            }

            return null;
        }


        [GeneratedRegex(PHONE_PATTERN)]
        private static partial Regex PhoneNumberRegex();
    }
}
