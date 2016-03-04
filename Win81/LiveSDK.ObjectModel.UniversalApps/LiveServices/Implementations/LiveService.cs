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

using Microsoft.Live;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;

namespace LiveSDK.ObjectModel.LiveServices.Implementations
{
    public abstract class LiveService
    {
        public LiveService(params string[] scopes)
        {
            Debug.Assert(Scopes != null);
            if (scopes != null && scopes.Length > 0)
            {
                foreach (string scope in scopes)
                {
                    Scopes.Add(scope);
                }
            }
        }

        public List<string> Scopes { get; private set; } = new List<string>();

        public void AppendScope(params string[] scopes)
        {
            Debug.Assert(Scopes != null);
            if (scopes == null || scopes.Length == 0)
            {
                return;
            }
            IEnumerable<string> newItems = scopes.Except(Scopes);
            Scopes.AddRange(newItems);
        }

        protected async Task<LiveConnectClient> GetConnectClientAsync(params string[] scopes)
        {
            if (scopes != null && scopes.Length > 0)
            {
                AppendScope(scopes);
            }

            if (Scopes == null)
            {
                throw new ArgumentNullException("Scopes");
            }

            LiveAuthClient auth = null;
            LiveLoginResult initResult = null;
            LiveLoginResult loginResult = null;

            auth = new LiveAuthClient();
            initResult = await auth.InitializeAsync();

            loginResult = await auth.LoginAsync(Scopes);
            if (loginResult.Session != null)
            {
                LiveConnectClient connect = new LiveConnectClient(auth.Session);
                return connect;
            }
            throw new InvalidOperationException("Fail to fetch the Live Connect Client");
        }

        public async Task DownloadFileAsync(Uri source, IStorageFile resultFile, CancellationToken? cancel = null)
        {
            BackgroundDownloader downloader = new BackgroundDownloader();
            DownloadOperation operation = downloader.CreateDownload(source, resultFile);
            await operation.StartAsync();
        }
    }
}
