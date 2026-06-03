using CarDealershipBackend.Data;

namespace CarDealershipBackend.Endpoints.Types
{
    // get по id или delete
    public abstract class EndpointWithId
    {
        protected abstract Task<IResult> ExecuteAsync(int id, AppDbContext db);

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
