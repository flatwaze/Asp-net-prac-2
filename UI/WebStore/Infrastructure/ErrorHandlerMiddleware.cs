﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Infrastructure
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _Next;
        private readonly ILogger<ErrorHandlerMiddleware> _Logger;

        public ErrorHandlerMiddleware(RequestDelegate Next, ILogger<ErrorHandlerMiddleware> Logger)
        {
            _Next = Next;
            _Logger = Logger;
        }

        public async Task Invoke(HttpContext Context)
        {
            try
            {
                await _Next(Context);
            }
            catch(Exception e)
            {
                HandleException(Context, e);
                throw;
            }
        }

        private void HandleException(HttpContext Context, Exception Error)
        {
            _Logger.LogError(Error, "Error {0}", Context.Request.Path);
        }

    }
}
    