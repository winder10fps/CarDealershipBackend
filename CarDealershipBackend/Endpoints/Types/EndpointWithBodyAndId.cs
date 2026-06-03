using CarDealershipBackend.Data;

namespace CarDealershipBackend.Endpoints.Types
{
    // put с телом и id
    public abstract class EndpointWithBodyAndId<TBody>
    {
        protected abstract Task<IResult> ExecuteAsync(int id, TBody request, AppDbContext db);

        public void Register(WebApplication app, string path)
        {
            app.MapPut(path, async (int id, TBody request, AppDbContext db) =>
            await ExecuteAsync(id, request, db));
        }
    }
}
