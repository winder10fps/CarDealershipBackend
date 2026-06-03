using CarDealershipBackend.Data;

namespace CarDealershipBackend.Endpoints.Types
{
    // с телом
    public abstract class EndpointWithBody<TRequest>
    {
        protected abstract Task<IResult> ExecuteAsync(TRequest request, AppDbContext db);

        public void Register(IEndpointRouteBuilder app, string path, string httpMethod)
        {
            switch (httpMethod.ToUpper())
            {
                case "GET":
                    app.MapGet(path, Handle);
                    break;
                case "POST":
                    app.MapPost(path, Handle);
                    break;
                case "PUT":
                    app.MapPut(path, Handle);
                    break;
                case "DELETE":
                    app.MapDelete(path, Handle);
                    break;
                default:
                    throw new ArgumentException($"Необрабатываемый HTTP метод: {httpMethod}");
            }
        }

        private async Task<IResult> Handle(TRequest request, AppDbContext db) => await ExecuteAsync(request, db);
    }
}
