using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Yarp.ReverseProxy.Forwarder;

namespace AughtSleve.Proxy
{
    public class FilteringTransformer : HttpTransformer
    {


        public override async ValueTask<bool> TransformResponseAsync(HttpContext httpContext, HttpResponseMessage? proxyResponse, CancellationToken cancellationToken)
        {
            var uri = httpContext.Request.GetEncodedUrl();
            var contentType = proxyResponse?.Content.Headers.ContentType?.ToString();
            Console.WriteLine(uri);
            return await base.TransformResponseAsync(httpContext, proxyResponse, cancellationToken);
        }
    }
}