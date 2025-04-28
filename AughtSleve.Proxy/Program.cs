
namespace AughtSleve.Proxy
{
    public class Program
    {
        static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.UseYafpForwardProxy(options =>
            {
                options.UseTransformer(_ => new FilteringTransformer());
            });

            var app = builder.Build();

            app.MapForwardProxy();

            app.MapGet("/", () => "Hello World!");
            app.Run();

        }
    }
}
