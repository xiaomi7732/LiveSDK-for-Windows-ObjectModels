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
    using System.IO;
    using System.Runtime.Serialization.Json;
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
        /// Get object by invoking LiveSDK on the path.
        /// </summary>
        /// <typeparam name="T">Return type.</typeparam>
        /// <param name="client">Live Connect Client object.</param>
        /// <param name="path">Query path.</param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(this LiveConnectClient client, string path)
            where T : LiveSDKOM, new()
        {
            LiveOperationResult operationResult = await client.GetAsync(path);
            string json = operationResult.RawResult;
            return json.TryJsonParse<T>();
        }

        /// <summary>
        /// Get object by invoking LiveSDK on the path, with a cancellation token.
        /// </summary>
        /// <typeparam name="T">Return type.</typeparam>
        /// <param name="client">Live Connect Client object.</param>
        /// <param name="path">Query path.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(this LiveConnectClient client, string path, CancellationToken ct)
            where T : LiveSDKOM, new()
        {
            LiveOperationResult operationResult = await client.GetAsync(path, ct);
            string json = operationResult.RawResult;
            return json.TryJsonParse<T>();
        }
        #endregion
    }
}
