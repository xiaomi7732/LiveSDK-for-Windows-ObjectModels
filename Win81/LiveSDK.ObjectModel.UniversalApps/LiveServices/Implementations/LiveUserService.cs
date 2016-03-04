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

using LiveSDK.ObjectModel.Extensions;
using LiveSDK.ObjectModel.LiveServices.Interfaces;
using Microsoft.Live;
using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
namespace LiveSDK.ObjectModel.LiveServices.Implementations
{
    public class LiveUserService : LiveService, ILiveUserService
    {
        public LiveUserService()
        {

        }

        public LiveUserService(params string[] scopes)
            : base(scopes)
        {

        }

        public async Task<User> GetCurrentUserAsync(CancellationToken? cancel = null, string[] scopes = null)
        {
            LiveConnectClient client = await GetConnectClientAsync(scopes);
            User user = await client.GetAsync<User>("me", cancel);
            return user;
        }

        public async Task<Picture> GetCurrentUserPictureAsync(CancellationToken? cancel = null, string[] scopes = null)
        {
            LiveConnectClient client = await GetConnectClientAsync(scopes);
            Picture picture = await client.GetAsync<Picture>("me/picture", cancel);
            return picture;
        }

        public async Task DownloadCurrentUserPictureAsync(IStorageFile resultFile, CancellationToken? cancel = null, string[] scopes = null)
        {
            Picture picture = await GetCurrentUserPictureAsync(cancel, scopes);
            Uri source = new Uri(picture.Location);
            await DownloadFileAsync(source, resultFile, cancel);
        }
    }
}
