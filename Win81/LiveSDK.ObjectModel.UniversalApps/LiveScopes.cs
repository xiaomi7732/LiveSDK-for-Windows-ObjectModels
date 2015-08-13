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

namespace LiveSDK.ObjectModel
{
    public static class LiveScopes
    {
        #region Core Scopes
        /// <summary>
        /// Enables read access to a user's basic profile info. Also enables read access to a user's list of contacts.
        /// </summary>
        public const string Basic = "wl.basic";

        /// <summary>
        /// Enables the ability of an app to read and update a user's info at any time. Without this scope, an app can access the user's info only while the user is signed in to Live Connect and is using your app. 
        /// </summary>
        public const string OfflineAccess = "wl.offline_access";

        /// <summary>
        /// Enables single sign-in behavior. With single sign-in, users who are already signed in to Live Connect are also signed in to your website.
        /// </summary>
        public const string Signin = "wl.signin";
        #endregion

        #region Extended Scopes
        /// <summary>
        /// Enables read access to a user's birthday info including birth day, month, and year.
        /// </summary>
        public const string Birthday = "wl.birthday";

        /// <summary>
        /// Enables read access to a user's calendars and events.
        /// </summary>
        public const string Calendars = "wl.calendars";

        /// <summary>
        /// Enables read and write access to a user's calendars and events.
        /// </summary>
        public const string CalendarsUpdate = "wl.calendars_update";

        /// <summary>
        /// Enables read access to the birth day and birth month of a user's contacts. Note that this also gives read access to the user's birth day, birth month, and birth year.
        /// </summary>
        public const string ContactsBirthday = "wl.contacts_birthday";

        /// <summary>
        /// Enables creation of new contacts in the user's address book.
        /// </summary>
        public const string ContactsCreate = "wl.contacts_create";

        /// <summary>
        /// Enables read access to a user's calendars and events. Also enables read access to any calendars and events that other users have shared with the user.
        /// </summary>
        public const string ContactsCalendars = "wl.contacts_calendars";

        /// <summary>
        /// Enables read access to a user's personal, preferred and business email addresses. Also enables read access to any personal, preferred and business email addresses that other users have shared with the user.
        /// </summary>
        public const string ContactsEmails = "wl.contacts_emails";

        /// <summary>
        /// Enables read access to a user's albums, photos, videos, and audio, and their associated comments and tags. Also enables read access to any albums, photos, videos, and audio that other users have shared with the user. 
        /// </summary>
        public const string ContactsPhotos = "wl.contacts_photos";

        /// <summary>
        /// Enables read access to Microsoft OneDrive files that other users have shared with the user. Note that this also gives read access to the user's files stored in OneDrive.
        /// </summary>
        public const string ContactsSkydrive = "wl.contacts_skydrive";

        /// <summary>
        /// Enables read access to a user's personal, preferred, and business email addresses.
        /// </summary>
        public const string Emails = "wl.emails";

        /// <summary>
        /// Enables creation of events on the user's default calendar.
        /// </summary>
        public const string EventsCreate = "wl.events_create";

        /// <summary>
        /// Enables read and write access to a user's email using IMAP, and send access using SMTP. 
        /// </summary>
        public const string IMAP = "wl.imap";

        /// <summary>
        /// Enables read access to a user's personal, business, and mobile phone numbers.
        /// </summary>
        public const string PhoneNumbers = "wl.phone_numbers";

        /// <summary>
        /// Enables read access to a user's photos, videos, audio, and albums.
        /// </summary>
        public const string Photos = "wl.photos";

        /// <summary>
        /// Enables read access to a user's postal addresses.
        /// </summary>
        public const string PostalAddresses = "wl.postal_addresses";

        /// <summary>
        /// Enables read access to a user's files stored in OneDrive.
        /// </summary>
        public const string Skydrive = "wl.skydrive";

        /// <summary>
        /// Enables read and write access to a user's files stored in OneDrive.
        /// </summary>
        public const string SkydriveUpdate = "wl.skydrive_update";

        /// <summary>
        /// Enables read access to a user's employer and work position information.
        /// </summary>
        public const string WorkProfile = "wl.work_profile";

        /// <summary>
        /// Enables read and write access to a user's OneNote notebooks stored in OneDrive.
        /// </summary>
        public const string OnenoteCreate = "office.onenote_create";
        #endregion
    }
}
