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
using Newtonsoft.Json;

namespace LiveSDK.ObjectModel
{

    /// <summary>
    /// The user's postal address.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Address
    {
        /// <summary>
        /// The user's street address, or null if one is not specified.
        /// </summary>
        [JsonProperty("street")]
        public string Street { get; set; }

        /// <summary>
        /// The second line of the user's street address, or null if one is not specified.
        /// </summary>
        [JsonProperty("street_2")]
        public string Street2 { get; set; }

        /// <summary>
        /// The city of the user's address, or null if one is not specified.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// The state of the user's address, or null if one is not specified.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// The postal code of the user's address, or null if one is not specified.
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The region of the user's address, or null if one is not specified.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }
    }
}
