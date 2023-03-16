using Shopbridge_base.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Exceptions
{
    public class ServerResponseException : Exception
    {
        ServerErrorResponse _response { get; }
        public int StatusCode {get; }
        public ServerResponseException(int statusCode ,ServerErrorResponse response):base()
        {
            StatusCode = statusCode;
            _response = response;

        }
        public ServerErrorResponse GetResponseError => _response;
    }
}
