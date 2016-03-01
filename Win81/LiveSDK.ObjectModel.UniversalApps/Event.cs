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
using System;
using Newtonsoft.Json;

namespace LiveSDK.ObjectModel
{
    /// <summary>
    /// Refer https://msdn.microsoft.com/en-us/library/hh243648.aspx#event for details.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Event: LiveSDKOM
    {
        /// <summary>
        /// The ID of the event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the event, with a maximum length of 255 characters. This structure is required.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The UTC time, in ISO 8601 format, at which the event was created.
        /// </summary>
        [JsonProperty("created_time")]
        public DateTimeOffset CreatedTime { get; set; }

        /// <summary>
        /// The UTC time, in ISO 8601 format, at which the event was updated. This structure is visible only in the Event object that is returned if the event was successfully created.
        /// </summary>
        [JsonProperty("updated_time")]
        public DateTimeOffset UpdatedTime { get; set; }

        /// <summary>
        /// A description of the event, with a maximum length of 32,768 characters. This structure is required.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The ID of the calendar that contains the event. For example: calendar.611afb17fa9448f28cdb8277e8ffeb77
        /// </summary>
        [JsonProperty("calendar_id")]
        public string CalendarId { get; set; }

        /// <summary>
        /// The object that contains the name and ID of the organizer.
        /// </summary>
        [JsonProperty("from")]
        public User From { get; set; }

        /// <summary>
        /// The start time, in ISO 8601 format, of the event. When the event is being read, the time will be the user's local time, in ISO 8601 format.
        /// </summary>
        [JsonProperty("start_time")]
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// The end time, in ISO 8601 format, of the event. If no end time is specified, the default value is 30 minutes after start_time. This structure is optional when creating an event. When the event is being read, the time will be the user's local time, in ISO 8601 format.
        /// </summary>
        [JsonProperty("end_time")]
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        /// The name of the location at which the event will take place. The maximum length is 1,000 characters.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// A value that specifies whether the event is an all-day event. If the event is an all-day event, this value is true; otherwise, it is false. If this structure is missing, the default value is false.
        /// </summary>
        [JsonProperty("is_all_day_event")]
        public bool IsAllDayEvent { get; set; }

        /// <summary>
        /// A value that specifies whether the event is recurring. If the event is recurring, this value is true; otherwise, it is false.
        /// </summary>
        [JsonProperty("is_recurrent")]
        public bool IsRecurrent { get; set; }

        /// <summary>
        /// The text description of the recurrence pattern, for example, "Occurs every week on Tuesday". The value is Null if this is not a recurrent event.
        /// </summary>
        [JsonProperty("recurrence")]
        public string Recurrence { get; set; }

        /// <summary>
        /// The time, in minutes, before the event for the reminder alarm.
        /// </summary>
        [JsonProperty("reminder_time")]
        public double? ReminderTime { get; set; }

        /// <summary>
        /// The user's availability status for the event. Valid values are: 
        /// • free
        /// • busy
        /// • tentative
        /// • out_of_office
        /// The default value is free.
        /// </summary>
        [JsonProperty("availability")]
        public string Availability { get; set; }

        /// <summary>
        /// A value that specifies whether the event is publicly visible. Valid values are: 
        /// • public: the event is visible to anyone who can view the calendar.
        /// • private: the event is visible only to the event owner.
        /// The default value is public. 
        /// </summary>
        [JsonProperty("visibility")]
        public string Visibility { get; set; }
    }
}
