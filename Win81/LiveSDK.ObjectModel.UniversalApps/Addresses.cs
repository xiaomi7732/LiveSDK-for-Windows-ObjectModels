﻿/// =======================================================================================
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
    /// The user's postal addresses.
    /// </summary>
    [JsonObject]
    public class Addresses
    {
        /// <summary>
        /// The user's personal postal address.
        /// </summary>
        [JsonProperty("personal")]
        public Personal Personal { get; set; }

        /// <summary>
        /// The user's business postal address.
        /// </summary>
        [JsonProperty("business")]
        public Business Business { get; set; }
    }
}
