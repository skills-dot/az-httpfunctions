using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Azure.Functions.Worker.Http;
using az_functions.Model;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace az_functions
{

    public class Login
    {
        private readonly ILogger _logger;

        public Login(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Login>();
        }

        [Function("GetLoginDetails")]
        public async Task<HttpResponseData> GetLoginDetails([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestData req, ILogger log
            ,[SqlInput("select [userName],[password] from [LOGIN]",
            "SqlConnectionString")]
            IEnumerable<LoginReponse> loginReponse
            )
        {
            string requestBody= await  new StreamReader(req.Body).ReadToEndAsync();
             var data = JsonConvert.DeserializeObject(requestBody);
          //  HttpResponseData httpResponseData ;
            //ring username = data?.UserName
            //string password = data?.Password;
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            // HttpResponseData response = req.CreateResponse(loginReponse);
            // await response.WriteStringAsync($"Orchestration started with ID: {instanceId}");
            
              var  httpResponseData = req.CreateResponse(HttpStatusCode.OK);
               await httpResponseData.WriteAsJsonAsync(loginReponse);

            return httpResponseData;
           
        }
    }
}
