using LiveSDK.ObjectModel.Extensions;
using Microsoft.Live;
using System;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
namespace LiveSDK.ObjectModel.LiveServices.Implementations
{
    public class UserService : LiveService, LiveSDK.ObjectModel.LiveServices.Implementations.IUserService
    {
        public UserService()
        {

        }

        public UserService(params string[] scopes)
            : base(scopes)
        {

        }

        public async Task<User> GetCurrentUserAsync()
        {
            LiveConnectClient client = await GetConnectClientAsync();
            User user = await client.GetAsync<User>("/me");
            return user;
        }

        public async Task<Picture> GetCurrentUserPictureAsync()
        {
            LiveConnectClient client = await GetConnectClientAsync();
            Picture picture = await client.GetAsync<Picture>("/me/picture");
            return picture;
        }

        public async Task DownloadCurrentUserPicture(IStorageFile resultFile)
        {
            Picture picture = await GetCurrentUserPictureAsync();
            Uri source = new Uri(picture.Location);
            BackgroundDownloader downloader = new BackgroundDownloader();
            DownloadOperation operation = downloader.CreateDownload(source, resultFile);
            await operation.StartAsync();
        }
    }
}
