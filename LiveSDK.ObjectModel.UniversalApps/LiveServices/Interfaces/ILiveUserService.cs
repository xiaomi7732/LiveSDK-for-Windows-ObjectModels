using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
namespace LiveSDK.ObjectModel.LiveServices.Interfaces
{
    public interface ILiveUserService
    {
        /// <summary>
        /// Get user Info
        /// </summary>
        /// <returns></returns>
        Task<User> GetCurrentUserAsync(CancellationToken? cancel = null);

        /// <summary>
        /// Get user picture info
        /// </summary>
        /// <returns></returns>
        Task<Picture> GetCurrentUserPictureAsync(CancellationToken? cancel = null);

        /// <summary>
        /// Download user picture to a storage.
        /// </summary>
        /// <param name="downloadTo"></param>
        /// <returns></returns>
        Task DownloadCurrentUserPictureAsync(IStorageFile resultFile, CancellationToken? cancel = null);
    }
}
