using CarDealershipBackend.Data;

namespace CarDealershipBackend.Endpoints.Types
{
    /// <summary>
    /// Шаблонный класс эндпоинта, в который передается ID объекта из бд
    /// </summary>
    public abstract class EndpointWithId
    {
        protected abstract Task<IResult> ExecuteAsync(int id, AppDbContext db);

        /// <summary>
        /// Регистрирует эндпоинт в зависимоти от HTTP метода запроса
        /// </summary>
        /// <param name="app">Приложение</param>
        /// <param name="path">Путь</param>
        /// <param name="httpMethod">HTTP метод для запроса</param>
        /// <exception cref="ArgumentException">Если метод не соответствует обрабатываемым</exception>
        public void Register(WebApplication app, string path, string httpMethod)
        {
            switch (httpMethod.ToUpper())
            {
                case "GET":
                    app.MapGet(path, async (int id, AppDbContext db) => await ExecuteAsync(id, db));
                    break;
                case "DELETE":
                    app.MapDelete(path, async (int id, AppDbContext db) => await ExecuteAsync(id, db));
                    break;
                default:
                    throw new ArgumentException($"Необрабатываемый HTTP метод: {httpMethod}");
            }
        }
    }
}
