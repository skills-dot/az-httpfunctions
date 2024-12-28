using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using az_functions.Models;
using System.Net;
using Azure.Core;
using Microsoft.Extensions.Primitives;

namespace az_functions
{
    public class Login
    {
        [FunctionName("LoginFunction")]
        public  async Task<IActionResult> GetLoginDetails(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetLoginDetails")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
           
            
            //if (dataModel != null)
            {
                StringValues username;
                StringValues password;
                req.Headers.TryGetValue("username", out  username);
                 req.Headers.TryGetValue("password", out  password);
             
                if (username == "ram" && password == "ram")
                {
                    var result = new LoginDetails()
                    {
                        UserName = username,
                        Password = password
                    };
                    return new OkObjectResult(result);
                }
            }
            return new OkObjectResult(new LoginDetails());
        }
    }
}
