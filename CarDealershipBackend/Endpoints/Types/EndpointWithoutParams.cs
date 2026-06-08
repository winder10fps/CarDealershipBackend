using CarDealershipBackend.Data;

namespace CarDealershipBackend.Endpoints.Types
{
    /// <summary>
    /// Шаблонный класс для эндпоинтов без параметров
    /// </summary>
    public abstract class EndpointWithoutParams
    {
        protected abstract Task<IResult> ExecuteAsync(AppDbContext db);

        /// <summary>
        /// Регистрирует эндпоинт
        /// </summary>
        /// <param name="app">Приложение</param>
        /// <param name="path">Путь</param>
        public void Register(WebApplication app, string path)
        {
            app.MapGet(path, async (AppDbContext db) => await ExecuteAsync(db));
        }

    }
}
