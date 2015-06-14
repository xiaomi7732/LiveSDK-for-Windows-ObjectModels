using LiveSDK.ObjectModel.Extensions;
using LiveSDK.ObjectModel.LiveServices.Interfaces;
using Microsoft.Live;
using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
namespace LiveSDK.ObjectModel.LiveServices.Implementations
{
    public class UserService : LiveService, IUserService
    {
        public UserService()
        {

        }

        public UserService(params string[] scopes)
            : base(scopes)
        {

        }

        public async Task<User> GetCurrentUserAsync(CancellationToken? cancel = null)
        {
            LiveConnectClient client = await GetConnectClientAsync();
            User user = await client.GetAsync<User>("/me", cancel);
            return user;
        }

        public async Task<Picture> GetCurrentUserPictureAsync(CancellationToken? cancel = null)
        {
            LiveConnectClient client = await GetConnectClientAsync();
            Picture picture = await client.GetAsync<Picture>("/me/picture", cancel);
            return picture;
        }

        public async Task DownloadCurrentUserPictureAsync(IStorageFile resultFile, CancellationToken? cancel = null)
        {
            Picture picture = await GetCurrentUserPictureAsync(cancel);
            Uri source = new Uri(picture.Location);
            await DownloadFileAsync(source, resultFile, cancel);
        }
    }
}
