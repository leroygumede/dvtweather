using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using DVTWeather.Models;
using Flurl;
using Flurl.Http;
using DVTWeather.Helpers;
using System.Collections.Generic;

namespace DVTWeather.Services.Service
{
    public class Services : IService
    {

        //private readonly IAppSettings _appSettings;

        private string BaseUrl => AppConstants.BaseUrl;

        public bool Delete<T>(T record)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync<T>(T record, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<T> Get<T>()
        {
            throw new NotImplementedException();
        }

        public async Task<TResult> GetAsync<TResult>(string url, object payload)
        {
            try
            {
                var token = AppConstants.AppId;


                return await Task.Run(() => BaseUrl
                  .AppendPathSegment(url)
                  .SetQueryParams(new
                  {
                      APPID = token,
                      id = AppConstants.CountryId,
                  })
                  .SetQueryParams(payload)
                  .GetAsync()
                  .ReceiveJson<TResult>());
            }
            catch (FlurlHttpException httpex)
            {
                throw new ServicesException(httpex.Message);
            }
        }

        public bool Post<T>(T record)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> PostAsync<TResult>(TResult record, string url)
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(T record)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync<T>(T record, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }
    }

    public class ServicesException : Exception
    {
        public ServicesException(string Message) : base(Message) { }
        public ServicesException(string Message, Exception innerException) : base(Message, innerException) { }
    }
}
