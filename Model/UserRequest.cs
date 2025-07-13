
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Azure.Functions.Worker.Http;

namespace az_functions.Model
{
    public class UserRequest
    {
        public string  UserName { set; get; } = string.Empty; 
        public string  Password { set; get; } = string.Empty;
    }

    public class OutputReposne
    {
        [SqlOutput("dbo.LOGIN", "SqlConnectionString")]
        public UserRequest UserRequest { set; get; } = new UserRequest();

        [HttpResult]
        public  HttpResponseData? httpResponseData { set; get; }
    }
}
