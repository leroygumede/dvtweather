using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using DVTWeather.Models;

namespace DVTWeather.Services.Service
{
    public interface IService
    {
        #region Async

        /// <summary>
        /// gets an <see cref="ObservableCollection{T}"/> object for the given type definition
        /// </summary>
        /// <param name="url">the URI to query</param>
        /// <returns>an observable collection of <seealso cref="TResult"/></returns>
        Task<ServiceResult> GetAsync(string url);

        /// <summary>
        /// posts an entity to the data store
        /// </summary>
        /// <param name="url">the URI to post to</param>
        /// <param name="record">the entity which needs to be stored</param>
        /// <returns>the record id which was stored</returns>
        Task<TResult> PostAsync<TResult>(TResult record, string url);

        /// <summary>
        /// deletes a given entity
        /// </summary>
        /// <param name="record">the entity which should be deleted</param>
        /// <param name="cancellationToken">the cancellation token incase the call should be cancelled</param>
        /// <returns>the record id which was deleted</returns>
        Task<bool> DeleteAsync<T>(T record, CancellationToken? cancellationToken = null);

        /// <summary>
        /// updates a given entity
        /// </summary>
        /// <param name="record">the entity which should be updated</param>
        /// <param name="cancellationToken">the cancellation token incase the call should be cancelled</param>
        /// <returns>the record id which was updated</returns>
        Task<bool> UpdateAsync<T>(T record, CancellationToken? cancellationToken = null);
        #endregion

        #region Synchronous
        /// <summary>
        /// gets an <see cref="ObservableCollection{T}"/> object for the given type definition
        /// </summary>
        /// <returns>an observable collection of <seealso cref="T"/></returns>
        ObservableCollection<T> Get<T>();

        /// <summary>
        /// posts an entity to the data store
        /// </summary>
        /// <param name="record">the entity which needs to be stored</param>
        /// /// <returns>the record id which was stored</returns>
        bool Post<T>(T record);

        /// <summary>
        /// deletes a given entity
        /// </summary>
        /// <param name="record">the entity which should be deleted</param>
        /// <returns>the record id which was deleted</returns>
        bool Delete<T>(T record);

        /// <summary>
        /// updates a given entity
        /// </summary>
        /// <param name="record">the entity which should be updated</param>
        /// <returns>the record id which was updated</returns>
        bool Update<T>(T record);

        #endregion
    }
}