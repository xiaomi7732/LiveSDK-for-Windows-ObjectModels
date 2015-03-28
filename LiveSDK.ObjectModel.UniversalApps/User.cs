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
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The User object contains info about a user. The Live Connect REST API supports reading User objects.
    /// </summary>
    [DataContract(Namespace = LiveSDKOMConsts.DataContractsDefaltNamespace)]
    public class User : LiveSDKOM
    {
        /// <summary>
        /// The user's ID.
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The user's full name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The user's first name.
        /// </summary>
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// The URL of the user's profile page.
        /// </summary>
        [DataMember(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// The day of the user's birth date, or null if no birth date is specified.
        /// </summary>
        [DataMember(Name = "birth_day")]
        public int? BirthDay { get; set; }

        /// <summary>
        /// The month of the user's birth date, or null if no birth date is specified.
        /// </summary>
        [DataMember(Name = "birth_month")]
        public int? BirthMonth { get; set; }

        /// <summary>
        /// The year of the user's birth date, or null if no birth date is specified.
        /// </summary>
        [DataMember(Name = "birth_year")]
        public int? BirthYear { get; set; }

        /// <summary>
        /// An array that contains the user's work info.
        /// </summary>
        [DataMember(Name = "work")]
        public List<Work> Work { get; set; }

        /// <summary>
        /// The user's email addresses.
        /// </summary>
        [DataMember(Name = "emails")]
        public Emails Emails { get; set; }

        /// <summary>
        /// The user's postal addresses.
        /// </summary>
        [DataMember(Name = "addresses")]
        public Addresses Addresses { get; set; }

        /// <summary>
        /// The user's phone numbers.
        /// </summary>
        [DataMember(Name = "phones")]
        public Phones Phones { get; set; }

        /// <summary>
        /// The user's locale code.
        /// </summary>
        [DataMember(Name = "locale")]
        public string Locale { get; set; }

        /// <summary>
        /// The time, in ISO 8601 format, at which the user last updated the object.
        /// </summary>
        [DataMember(Name = "updated_time")]
        public string UpdatedTime { get; set; }
    }
}
