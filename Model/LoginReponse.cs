using Microsoft.Azure.Functions.Worker.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace az_functions.Model
{
    public class LoginReponse 
    {
        public string UserName { set; get; }=string.Empty;
        public string password { set; get; } = string.Empty;
        public static HttpResponseData? ResponseData { set; get; }
    }
}
