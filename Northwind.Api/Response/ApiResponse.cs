using System.Collections.Generic;

namespace Northwind.Api.Response
{
    public class ApiResponse<T> where T: class
    {
        public T Data { get; set; }

        public Dictionary<string, string> Errors;

        public string ResponseType { get; set; } 
    }
}


