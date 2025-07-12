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
    [SqlOutput("dbo.LOGIN", "SqlConnectionString")]
    public async Task<UserRequest> InsertRecord([HttpTrigger(AuthorizationLevel.Anonymous,  "post", Route = "Inseruser")] HttpRequestData req)
    {
        UserRequest user= new UserRequest();
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data = JsonConvert.DeserializeObject<UserRequest>(requestBody);
        
        return data ?? new UserRequest();
    }
}