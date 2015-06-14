using System.Threading.Tasks;
using Windows.Storage;
namespace LiveSDK.ObjectModel.LiveServices.Implementations
{
    public interface IUserService
    {
        /// <summary>
        /// Get user Info
        /// </summary>
        /// <returns></returns>
        Task<User> GetCurrentUserAsync();

        /// <summary>
        /// Get user picture info
        /// </summary>
        /// <returns></returns>
        Task<Picture> GetCurrentUserPictureAsync();

        /// <summary>
        /// Download user picture to a storage.
        /// </summary>
        /// <param name="downloadTo"></param>
        /// <returns></returns>
        Task DownloadCurrentUserPicture(IStorageFile downloadTo);
    }
}
