﻿/// =======================================================================================
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
    public class LiveContactService : LiveService, ILiveContactService
    {
        public LiveContactService()
        {
        }

        public LiveContactService(params string[] scopes)
            : base(scopes)
        {

        }

        public async Task<Contacts> GetContactsAsync()
        {
            LiveConnectClient connectClient = await GetConnectClientAsync();
            Contacts contacts = await connectClient.GetAsync<Contacts>("me/contacts");
            return contacts;
        }

        public async Task<Contacts> GetContactsAsync(int skip = 0, int take = 50, CancellationToken? cancel = null)
        {
            if (skip < 0 || take <= 0)
            {
                return await GetContactsAsync();
            }
            else
            {
                LiveConnectClient connectClient = await GetConnectClientAsync();
                Contacts contacts = await connectClient.GetAsync<Contacts>("me/contacts", cancel, skip, take);
                return contacts;
            }
        }

        public async Task<Picture> GetPictureAsync(string contactUserId, CancellationToken? cancel = null)
        {
            LiveConnectClient connectClient = await GetConnectClientAsync();
            Picture picture = await connectClient.GetAsync<Picture>(string.Format("{0}/picture", contactUserId), cancel);
            return picture;
        }

        public async Task<Picture> GetPictureAsync(Contact contact, CancellationToken? cancel = null)
        {
            return await GetPictureAsync(contact.UserId, cancel);
        }

        public async Task DownloadPictureAsync(string contactUserId, IStorageFile resultFile, CancellationToken? cancel = null)
        {
            Picture picture = await GetPictureAsync(contactUserId, cancel);
            Uri source = new Uri(picture.Location);
            await DownloadFileAsync(source, resultFile, cancel);
        }

        public async Task DownloadPictureAsync(Contact contact, IStorageFile resultFile, CancellationToken? cancel = null)
        {
            await DownloadPictureAsync(contact.UserId, resultFile, cancel);
        }
    }
}
