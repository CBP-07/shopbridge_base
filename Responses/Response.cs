﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Responses
{
    public class Response
    {
        public Response()
        {

        }
        public Response(object data)
        {
            Data = data;
        }
        public object Data { get; set; }
        public virtual int StatusCode { get; set; } = 200;
        public virtual string Message { get; set; } = "Ok";
        public bool Success { get; set; } = true;
    }
}
