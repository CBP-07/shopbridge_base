using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shopbridge_base.Helpers
{
    public static class Factory
    {
        public static Responses.Response ErrorResponse()
        => Factory.GetResponse<Responses.ServerErrorResponse>(null,
                    500,
                    "Various internal unexpected errors happened",
                    false);
        public static byte[] GetBytes(this Responses.Response response) => Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
        public static byte[] GetBytes(this Responses.ServerErrorResponse response) => Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
        public static Responses.Response GetResponse<T>(object response, int statusCode = 200, string message = "Ok", bool success = true, IEnumerable<string> validation = null)

        {
            var tipo = typeof(T);
            if (tipo == typeof(Responses.Response))
            {
                return new Responses.Response { Data = response, Message = message, StatusCode = statusCode, Success = success };
            }
            else if (tipo == typeof(Responses.ServerErrorResponse))
            {
                if (response is not null)
                    return new Responses.ServerErrorResponse { Data = response, StatusCode = statusCode, Message = message, Success = false, Validation = validation };

                return new Responses.ServerErrorResponse { Data = null, StatusCode = statusCode, Message = message, Success = false, Validation = validation };
            }
            return null!;
        }
    }
}
