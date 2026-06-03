using CarDealershipBackend.Data;

namespace CarDealershipBackend.Endpoints.Types
{
    // get без параметров
    public abstract class EndpointWithoutParams
    {
        protected abstract Task<IResult> ExecuteAsync(AppDbContext db);

        public void Register(WebApplication app, string path)
        {
            app.MapGet(path, async (AppDbContext db) => await ExecuteAsync(db));
        }

    }
}
