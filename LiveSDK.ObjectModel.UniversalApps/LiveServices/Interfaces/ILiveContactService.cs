using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
namespace LiveSDK.ObjectModel.LiveServices.Interfaces
{
    public interface ILiveContactService
    {
        Task DownloadPictureAsync(string contactUserId, IStorageFile resultFile, CancellationToken? cancel = null);
        Task DownloadPictureAsync(Contact contact, IStorageFile resultFile, CancellationToken? cancel = null);
        Task<Contacts> GetContactsAsync();
        Task<Contacts> GetContactsAsync(int skip = 0, int take = 50, System.Threading.CancellationToken? cancel = null);
        Task<Picture> GetPictureAsync(string contactUserId, CancellationToken? cancel = null);
        Task<Picture> GetPictureAsync(Contact contact, CancellationToken? cancel = null);
    }
}
