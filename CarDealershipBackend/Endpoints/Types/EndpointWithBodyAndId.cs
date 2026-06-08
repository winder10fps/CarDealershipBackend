using CarDealershipBackend.Data;

namespace CarDealershipBackend.Endpoints.Types
{
    /// <summary>
    /// Шаблонный класс эндпоинта с телом запроса и ID (put запросы к этом приложении)
    /// </summary>
    /// <typeparam name="TBody">DTO запроса</typeparam>
    public abstract class EndpointWithBodyAndId<TBody>
    {
        protected abstract Task<IResult> ExecuteAsync(int id, TBody request, AppDbContext db);

        /// <summary>
        /// Регистрирует эндпоинт
        /// </summary>
        /// <param name="app">Приложение</param>
        /// <param name="path">Путь</param>
        public void Register(WebApplication app, string path)
        {
            app.MapPut(path, async (int id, TBody request, AppDbContext db) =>
            await ExecuteAsync(id, request, db));
        }
    }
}
