using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace MC.SimpleLambda
{
    public class Functions
    {
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Functions()
        {
        }


        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The list of blogs</returns>
        public APIGatewayProxyResponse GetAll(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");
            List<string> retorno = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                retorno.Add(Guid.NewGuid().ToString());
            }
            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(retorno),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/json" } }
            };

            return response;
        }

        public APIGatewayProxyResponse GetOne(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(Guid.NewGuid().ToString()),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/json" } }
            };

            return response;
        }


        public APIGatewayProxyResponse GetCoupon(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");
            int size;
            var response = new APIGatewayProxyResponse();
            if (!int.TryParse(request.QueryStringParameters["size"], out size) || size <= 4)
            {
                response = new APIGatewayProxyResponse

                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Body = JsonConvert.SerializeObject("Invalid size, must be >=4"),
                    Headers = new Dictionary<string, string> { { "Content-Type", "text/json" } }
                };
                return response;

            }

            response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(MC.SimpleLambda.Utils.GetUniqueKey(size)),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/json" } }
            };

            return response;
        }
    }
}
