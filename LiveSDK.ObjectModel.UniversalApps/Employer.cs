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
    /// <summary>
    /// Info about the user's employer.
    /// </summary>
    [JsonObject]
    public class Employer
    {
        /// <summary>
        /// The name of the user's employer, or null if the employer's name is not specified.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
