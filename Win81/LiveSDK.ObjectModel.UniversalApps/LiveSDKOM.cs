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
using System;

namespace LiveSDK.ObjectModel
{
    /// <summary>
    /// Base class of LiveSDK Object Models.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class LiveSDKOM
    {
        /// <summary>
        /// The time, at which the user last updated the object.
        /// </summary>
        public DateTimeOffset? UpdatedTimeOffset
        {
            get
            {
                if (!string.IsNullOrEmpty(UpdatedTimeString))
                {
                    DateTimeOffset updateTime;
                    if (DateTimeOffset.TryParse(UpdatedTimeString, out updateTime))
                    {
                        return updateTime;
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
        }

        [JsonProperty("updated_time")]
        private string UpdatedTimeString { get; set; }
    }
}
