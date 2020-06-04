using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace lambda_dotnet_test
{
    public class Functions
    {
        ITimeProcessor processor = new TimeProcessor();

        public APIGatewayProxyResponse Get(
APIGatewayProxyRequest request, ILambdaContext context)
        {
            var result = processor.CurrentTimeUTC();

            return CreateResponse(result);
        }
        public APIGatewayProxyResponse Hello(
APIGatewayProxyRequest request, ILambdaContext context)
        {
            return new APIGatewayProxyResponse
            {
                Body = "Hello World!",
                StatusCode = 200,
                Headers = new Dictionary<string, string>{
                    { "Content-Type", "text/plain" },
                    { "Access-Control-Allow-Origin", "*" }}
            };
        }
        APIGatewayProxyResponse CreateResponse(DateTime? result)
        {
            int statusCode = (result != null) ?
                (int)HttpStatusCode.OK :
                (int)HttpStatusCode.InternalServerError;

            string body = (result != null) ?
                JsonConvert.SerializeObject(result) : string.Empty;

            var response = new APIGatewayProxyResponse
            {
                StatusCode = statusCode,
                Body = body,
                Headers = new Dictionary<string, string>{
                    { "Content-Type", "application/json" },
                    { "Access-Control-Allow-Origin", "*" }
                }
            };

            return response;
        }
    }
}
