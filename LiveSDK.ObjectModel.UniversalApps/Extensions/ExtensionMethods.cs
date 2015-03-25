/// =======================================================================================
/// This file is part of LiveSDK.ObjectModel.

/// LiveSDK.ObjectModel is free software: you can redistribute it and/or modify
/// it under the terms of the GNU General Public License as published by
/// the Free Software Foundation, either version 3 of the License, or
/// (at your option) any later version.

/// LiveSDK.ObjectModel is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU General Public License for more details.
/// =======================================================================================

namespace LiveSDK.ObjectModel.Extensions
{
    using Microsoft.Live;
    using System;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public static class ExtensionMethods
    {
        #region Json Parse
        /// <summary>
        /// Parse json string to a type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T TryJsonParse<T>(this string json)
            where T : LiveSDKOM, new()
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                using (var memoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
                {
                    return (T)serializer.ReadObject(memoryStream);
                }
            }
            catch
            {
#if DEBUG
                throw;
#else
                return default(T);
#endif
            }
        }
        #endregion

        #region Extend Connect Client
        /// <summary>
        /// Get object by invoking LiveSDK on the path, with a cancellation token.
        /// </summary>
        /// <typeparam name="T">Return object type.</typeparam>
        /// <param name="client">LiveConnectClient for sending the request.</param>
        /// <param name="path">Query Path without parameters</param>
        /// <param name="ct">Cancellation token if any.</param>
        /// <param name="skip">Skip the first n records.</param>
        /// <param name="take">Take only m records after the skip.</param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(this LiveConnectClient client, string path, CancellationToken? ct = null, int? skip = null, int? take = null)
            where T : LiveSDKOM, new()
        {
            return await GetObjectAsync<T>(client, path, ct, skip, take);
        }

        private static async Task<T> GetObjectAsync<T>(LiveConnectClient client, string path, CancellationToken? ct, int? skip, int? take)
            where T : LiveSDKOM, new()
        {
            UriBuilder builder = new UriBuilder(path);
            builder.Query = GetQueryString(skip, take);
            path = string.Format("{0}{1}", path, builder.Query);

            LiveOperationResult operationResult = null;
            if (ct != null && ct.HasValue)
            {
                operationResult = await client.GetAsync(path, ct.Value);
            }
            else
            {
                operationResult = await client.GetAsync(path);
            }
            if (operationResult != null && !string.IsNullOrEmpty(operationResult.RawResult))
            {
                string json = operationResult.RawResult;
                return json.TryJsonParse<T>();
            }
            return null;
        }

        private static string GetQueryString(int? skip, int? take)
        {
            StringBuilder queryBuilder = new StringBuilder();
            if (skip != null && skip.HasValue)
            {
                queryBuilder.AppendFormat("offset={0}&", skip.Value);
            }
            if (take != null && take.HasValue)
            {
                queryBuilder.AppendFormat("limit={0}&", take.Value);
            }

            string result = queryBuilder.ToString();
            if (result.Length > 0 && result.EndsWith("&"))
            {
                return result.Substring(0, result.Length - 1);
            }
            return null;
        }
        #endregion
    }
}
