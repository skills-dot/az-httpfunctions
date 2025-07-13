using az_functions.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace az_functions;

public class InsertRecords
{
    private readonly ILogger<InsertRecords> _logger;

    public InsertRecords(ILogger<InsertRecords> logger)
    {
        _logger = logger;
    }

    [Function("InsertRecords")]
  
    public async Task<OutputReposne> InsertRecord([HttpTrigger(AuthorizationLevel.Function,  "post", Route = "Inseruser")] HttpRequestData req)
    {
        UserRequest user = new UserRequest();
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data = JsonConvert.DeserializeObject<UserRequest>(requestBody);
        if(string.IsNullOrEmpty(data?.UserName) || string.IsNullOrEmpty(data?.Password)) {
            var resposne = req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
          
            await  resposne.WriteStringAsync("UserName or password should not be empty");   
            return new OutputReposne()
            {
                UserRequest =  new UserRequest(),
                httpResponseData = resposne
            };
        }
           
        return  new OutputReposne() { UserRequest= data ?? new UserRequest(),
            httpResponseData= req.CreateResponse(System.Net.HttpStatusCode.OK)};
    }
}