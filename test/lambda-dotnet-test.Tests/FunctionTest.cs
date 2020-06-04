using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

using lambda_dotnet_test;

namespace lambda_dotnet_test.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestGetMethod()
        {
            TestLambdaContext context;
            APIGatewayProxyRequest request;
            APIGatewayProxyResponse response;

            Functions functions = new Functions();


            request = new APIGatewayProxyRequest();
            context = new TestLambdaContext();
            response = functions.Hello(request, context);
            Assert.Equal(200, response.StatusCode);
            Assert.Equal("Hello World!", response.Body);
        }
    }
}
