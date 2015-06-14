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
    /// The user's work info.
    /// </summary>
    [JsonObject]
    public class Work
    {
        /// <summary>
        /// Info about the user's employer.
        /// </summary>
        [JsonProperty("employer")]
        public Employer Employer { get; set; }

        /// <summary>
        /// Info about the user's work position.
        /// </summary>
        [JsonProperty("position")]
        public Position Position { get; set; }
    }
}
