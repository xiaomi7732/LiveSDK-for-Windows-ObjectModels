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
    /// Service to provide contacts related operations.
    /// </summary>
    public interface ILiveContactService
    {
        /// <summary>
        /// Download the picture of the contact.
        /// </summary>
        /// <param name="contactUserId">Contact.UserId</param>
        /// <param name="resultFile">Download dest.</param>
        /// <param name="cancel">Cancellation token for the operation.</param>
        Task DownloadPictureAsync(string contactUserId, IStorageFile resultFile, CancellationToken? cancel = null);

        /// <summary>
        /// Download the picture of the contact.
        /// </summary>
        /// <param name="contact">Contact object for the picture.</param>
        /// <param name="resultFile">Download dest.</param>
        /// <param name="cancel">Cancellation token for the operation.</param>
        Task DownloadPictureAsync(Contact contact, IStorageFile resultFile, CancellationToken? cancel = null);

        /// <summary>
        /// Get all contacts of current user.
        /// </summary>
        /// <returns>Contacts object. Fetch Contacts.Items for contact objects.</returns>
        Task<Contacts> GetContactsAsync();

        /// <summary>
        /// Get a page of contacts.
        /// </summary>
        /// <param name="skip">Number of records to skip for the results.</param>
        /// <param name="take">Number of records to take for the results.</param>
        /// <param name="cancel">Cancellation token for the operation.</param>
        /// <returns>Contacts object. Fetch Contacts.Items for contact objects.</returns>
        Task<Contacts> GetContactsAsync(int skip = 0, int take = 50, System.Threading.CancellationToken? cancel = null);

        /// <summary>
        /// Get a picture object for a contact.
        /// </summary>
        /// <param name="contactUserId">Contact's user id.</param>
        /// <param name="cancel">Cancellation token for the operation.</param>
        /// <returns>Picture object for the contact</returns>
        Task<Picture> GetPictureAsync(string contactUserId, CancellationToken? cancel = null);

        /// <summary>
        /// Get a picture object for a contact.
        /// </summary>
        /// <param name="contact">Contact object for the picture.</param>
        /// <param name="cancel">Cancellation token for the operation.</param>
        /// <returns>Picture object for the contact</returns>
        Task<Picture> GetPictureAsync(Contact contact, CancellationToken? cancel = null);
    }
}
