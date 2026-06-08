using CarDealershipBackend.Data;

namespace CarDealershipBackend.Endpoints.Types
{
    /// <summary>
    /// Шаблонный класс эндпоинта, у которого есть только тело запроса (здесь для post запросов)
    /// </summary>
    /// <typeparam name="TRequest">DTO запроса</typeparam>
    public abstract class EndpointWithBody<TRequest>
    {
        protected abstract Task<IResult> ExecuteAsync(TRequest request, AppDbContext db);

        /// <summary>
        /// Регистрирует эндпоинт
        /// </summary>
        /// <param name="app">Приложение</param>
        /// <param name="path">Путь</param>
        public void Register(IEndpointRouteBuilder app, string path)
        {
            app.MapPost(path, async(TRequest request, AppDbContext db) => await ExecuteAsync(request, db));
        }
    }
}
