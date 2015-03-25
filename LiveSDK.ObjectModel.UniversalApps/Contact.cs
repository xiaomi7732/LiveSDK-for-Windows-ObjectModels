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
    using LiveSDK.ObjectModel.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Contact wrapper for LiveSDK contact object. Refer https://msdn.microsoft.com/en-us/library/hh243648.aspx#contact for details.
    /// </summary>
    [DataContract(Namespace = LiveSDKOMConsts.DataContractsDefaltNamespace)]
    public class Contact : LiveSDKOM
    {
        public Contact() { }

        [DataMember(Name = "id")]
        public string Id { get; internal set; }

        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "gender")]
        public object Gender { get; set; }

        [DataMember(Name = "is_friend")]
        public bool IsFriend { get; set; }

        [DataMember(Name = "is_favorite")]
        public bool IsFavorite { get; set; }

        [DataMember(Name = "user_id")]
        public string UserId { get; internal set; }

        [DataMember(Name = "email_hashes")]
        public List<string> EmailHashes { get; set; }

        [DataMember(Name = "udpated_time")]
        public DateTimeOffset UpdatedTime { get; set; }

        [DataMember(Name = "birth_day")]
        public int? BirthDay { get; set; }

        [DataMember(Name = "birth_month")]
        public int? BirthMonth { get; set; }

        [DataMember(Name = "emails")]
        public Emails Emails { get; set; }
    }
}
