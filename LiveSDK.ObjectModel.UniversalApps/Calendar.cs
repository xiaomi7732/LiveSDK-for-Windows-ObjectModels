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
    using System;

    /// <summary>
    /// Refer https://msdn.microsoft.com/en-us/library/hh243648.aspx#calendar for details.
    /// </summary>
    [JsonObject]
    public class Calendar : LiveSDKOM
    {
        /// <summary>
        /// The Calendar object's ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the calendar.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the calendar.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The time, in ISO 8601 format, at which the calendar was created.
        /// </summary>
        [JsonProperty("created_time")]
        public DateTimeOffset CreatedTime { get; set; }

        /// <summary>
        /// The time, in ISO 8601 format, that the calendar was last updated.
        /// </summary>
        [JsonProperty("updated_time")]
        public DateTimeOffset UpdatedTime { get; set; }

        /// <summary>
        /// Info about the user who owns the calendar.
        /// </summary>
        [JsonProperty("from")]
        public CalendarOwner From { get; set; }

        /// <summary>
        /// A value that indicates whether this calendar is the default calendar. If this calendar is the default calendar, this value is true; otherwise, it is false.
        /// </summary>
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        /// <summary>
        /// A public subscription URL with which Live Connect will synchronize properties and events periodically for this calendar. A NULL value indicates that this is not a subscribed calendar.
        /// </summary>
        [JsonProperty("subscription_location")]
        public string SubscriptionLocation { get; set; }

        /// <summary>
        /// Role and permissions that are granted to the user for the calendar. The possible values are:
        ///    free_busy: The user can see only free/busy info.
        ///    limited_details: The user can see a subset of all details.
        ///    read: The user can only read the content of the calendar events. 
        ///    read_write: The user can read and write calendar and events. 
        ///    co_owner: The user is co-owner of this calendar.
        ///    owner: The user is the owner of this calendar.
        /// </summary>
        [JsonProperty("permissions")]
        public string Permissions { get; set; }
    }

    /// <summary>
    /// Refer https://msdn.microsoft.com/en-us/library/hh243648.aspx#calendar for details.
    /// </summary>
    [JsonObject]
    public class CalendarOwner
    {
        /// <summary>
        /// The name of the user who uploaded the file.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the user who owns the calendar.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
