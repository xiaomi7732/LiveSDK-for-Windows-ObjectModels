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
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [JsonObject]
    public class Contact 
    {
        public Contact() { }

        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public object Gender { get; set; }

        [JsonProperty("is_friend")]
        public bool IsFriend { get; set; }

        [JsonProperty("is_favorite")]
        public bool IsFavorite { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; internal set; }

        [JsonProperty("email_hashes")]
        public List<string> EmailHashes { get; set; }

        [JsonProperty("emails")]
        public Emails Emails { get; set; }
    }
}
