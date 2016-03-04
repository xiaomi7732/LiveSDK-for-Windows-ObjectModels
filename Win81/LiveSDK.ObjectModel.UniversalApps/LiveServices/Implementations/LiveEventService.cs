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

using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using LiveSDK.ObjectModel.Extensions;
using LiveSDK.ObjectModel.LiveServices.Interfaces;
using Microsoft.Live;

namespace LiveSDK.ObjectModel.LiveServices.Implementations
{
    /// <summary>
    /// Serivce for Events.
    /// The Event object contains info about events on a user's Outlook.com calendars.
    /// The Live Connect REST API supports creating Event objects. Use the wl.events_create scope
    /// to create Event objects on the user's default calendar only. Use the wl.calendars scope to
    /// read Event objects on the user's calendars. Use wl.calendars_update to create Event objects
    /// on any of the user's calendars. Use the wl.contacts_calendars scope to read Event objects
    /// from the user's friend's calendars.
    /// </summary>
    public class LiveEventService : LiveService, ILiveEventService
    {
        /// <summary>
        /// To create an Event object on the user's default calendar by using the Live Connect REST API, make a POST request to /me/events. Pass the properties for the event in the request body, as shown here.
        ///         Content-Type: application/json
        /// 
        /// {
        ///     "name": "Global Project Risk Management Meeting",
        ///     "description": "Generate and assess risks for the project",
        ///     "start_time": "2011-04-20T01:00:00-07:00",
        ///     "end_time": "2011-04-20T02:00:00-07:00",
        ///     "location": "Building 81, Room 9981, 123 Anywhere St., Redmond WA 19599",
        ///     "is_all_day_event": false,
        ///     "availability": "busy",
        ///     "visibility": "public"
        /// }
        /// </summary>
        /// <param name="newEvent"></param>
        /// <returns></returns>
        public async Task<Event> CreateEvent(Event newEvent, string calendarId, string[] scopes = null)
        {
            var client = await GetConnectClientAsync(scopes);
            var eventDictionary = new Dictionary<string, object>() {
                { "name", newEvent.Name },
                { "description", newEvent.Description},
                { "start_time", newEvent.StartTime.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)},
                { "end_time", newEvent.EndTime.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)},
                { "location", newEvent.Location},
                { "is_all_day_event", newEvent.IsAllDayEvent },
                { "availability", newEvent.Availability.ToLowerInvariant()},
                { "visibility", newEvent.Visibility ?? "public"}
            };

            string path = "{0}/events";
            path = string.Format(CultureInfo.InvariantCulture, path, calendarId ?? "me");
            LiveOperationResult operationResult = await client.PostAsync(path, eventDictionary);
            string result = operationResult.RawResult;
            return result.TryJsonParse<Event>();
        }

        /// <summary>
        /// Delete an event by its id. To delete an Event, make a DELETE request to /EVENT_ID.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task DeleteEvent(string eventId, string[] scopes = null)
        {
            var client = await GetConnectClientAsync(scopes);
            string path = $"/{eventId}";
            LiveOperationResult operationResult = await client.DeleteAsync(path);
        }

        /// <summary>
        /// To return a list of events for a calendar by using the Live Connect REST API, 
        /// make a GET request to /CALENDAR_ID/events. This will return all events between now and the next 30 days by default.
        /// </summary>
        /// <param name="calendarId"></param>
        /// <returns></returns>
        public async Task<Events> GetCalendarEvents(string calendarId, string[] scopes = null)
        {
            var client = await GetConnectClientAsync(scopes);
            return await client.GetAsync<Events>($"/{calendarId}/events");
        }

        /// <summary>
        /// To return a list of events for a user, make a GET request to 
        /// either /me/events, or /USER_ID/events.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Events> GetUserEvents(string userId, string[] scopes = null)
        {
            userId = userId ?? "me";
            var client = await GetConnectClientAsync(scopes);
            return await client.GetAsync<Events>($"/{userId}/events");
        }
    }
}
