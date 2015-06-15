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

        public async Task<Picture> GetPictureAsync(string contactId, CancellationToken? cancel = null)
        {
            LiveConnectClient connectClient = await GetConnectClientAsync();
            Picture picture = await connectClient.GetAsync<Picture>(string.Format("{0}/picture", contactId), cancel);
            return picture;
        }

        public async Task<Picture> GetPictureAsync(Contact contact, CancellationToken? cancel = null)
        {
            return await GetPictureAsync(contact.Id, cancel);
        }

        public async Task DownloadPictureAsync(string contactId, IStorageFile resultFile, CancellationToken? cancel = null)
        {
            Picture picture = await GetPictureAsync(contactId, cancel);
            Uri source = new Uri(picture.Location);
            await DownloadFileAsync(source, resultFile, cancel);
        }

        public async Task DownloadPictureAsync(Contact contact, IStorageFile resultFile, CancellationToken? cancel = null)
        {
            await DownloadPictureAsync(contact.Id, resultFile, cancel);
        }
    }
}
