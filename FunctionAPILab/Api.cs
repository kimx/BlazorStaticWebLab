using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace FunctionAPILab
{
    public class Api
    {
        private readonly ILogger _logger;

        public Api(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Api>();
        }

        [Function("GetMessage")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");

            response.WriteString("Welcome to Azure Functions!:" + DateTime.Now.ToString());

            return response;
        }
    }
}
