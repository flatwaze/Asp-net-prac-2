using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebStore.Clients.Base
{
    public abstract class BaseClient:IDisposable
    {
        protected readonly HttpClient _Client;
        protected readonly string _ServiceAddress;
        protected BaseClient(IConfiguration config, string ServiceAddress)
        {
            _ServiceAddress = ServiceAddress;
            _Client = new HttpClient
            {
                BaseAddress = new Uri(config["WebApiUrl"])
            };
            var headers = _Client.DefaultRequestHeaders.Accept;
            headers.Clear();
            headers.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }


        #region Dispose
        private bool _Disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed || !disposing)
                return;
            _Disposed = true;
            _Client.Dispose();
        }
        #endregion
    }
}
