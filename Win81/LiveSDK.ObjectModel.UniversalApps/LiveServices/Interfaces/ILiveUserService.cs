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

using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;

namespace LiveSDK.ObjectModel.LiveServices.Interfaces
{
    /// <summary>
    /// Service to provide user related operations.
    /// </summary>
    public interface ILiveUserService
    {
        /// <summary>
        /// Get user Info
        /// </summary>
        /// <returns></returns>
        Task<User> GetCurrentUserAsync(CancellationToken? cancel = null, string[] scopes = null);

        /// <summary>
        /// Get user picture info
        /// </summary>
        /// <returns></returns>
        Task<Picture> GetCurrentUserPictureAsync(CancellationToken? cancel = null, string[] scopes = null);

        /// <summary>
        /// Download user picture to a storage.
        /// </summary>
        /// <param name="downloadTo"></param>
        /// <returns></returns>
        Task DownloadCurrentUserPictureAsync(IStorageFile resultFile, CancellationToken? cancel = null, string[] scopes = null);
    }
}
