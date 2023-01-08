using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class getCV
    {
        private readonly ILogger _logger;

        public getCV(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<getCV>();
        }

        [Function("getCV")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethod.Get))] HttpRequestData req,
        [BlobInput("resume/cv.json")] string cv)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString(cv);

            return response;
        }
    }
}
