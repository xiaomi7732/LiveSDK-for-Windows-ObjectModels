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

using LiveSDK.ObjectModel.Extensions;
using LiveSDK.ObjectModel.LiveServices.Interfaces;
using Microsoft.Live;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LiveSDK.ObjectModel.LiveServices.Implementations
{
    /// <summary>
    /// Refer https://msdn.microsoft.com/en-us/library/hh243648.aspx#calendar for scope description
    /// </summary>
    public class LiveCalendarService : LiveService, ILiveCalendarService
    {
        public LiveCalendarService()
        {

        }

        public LiveCalendarService(params string[] scopes)
            : base(scopes)
        {

        }

        public async Task<Calendars> GetMyCalendars(CancellationToken? cancel, string[] scopes = null)
        {
            var client = await GetConnectClientAsync(scopes);
            return await client.GetAsync<Calendars>("me/calendars");
        }

        public async Task<Calendar> GetCalendar(string calendarId, CancellationToken? cancel, string[] scopes = null)
        {
            var client = await GetConnectClientAsync(scopes);
            return await client.GetAsync<Calendar>(calendarId, cancel);
        }

        public async Task DeleteCalendar(string calendarId, string[] scopes = null)
        {
            var client = await GetConnectClientAsync(scopes);
            await client.DeleteAsync(calendarId);
        }

        public async Task<string> CreateCalendar(string name, string description, string[] scopes = null)
        {
            var client = await GetConnectClientAsync(scopes);
            var calendar = new Dictionary<string, object>();
            calendar.Add("name", name);
            calendar.Add("description", description);
            LiveOperationResult operationResult = await client.PostAsync("me/calendars", calendar);
            dynamic result = operationResult.Result;
            return result.id;
        }

        public async Task UpdateCanedlar(Calendar updateSpec, string[] scopes = null)
        {
            var client = await GetConnectClientAsync(scopes);
            var calendar = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(updateSpec.Name))
            {
                calendar.Add("name", updateSpec.Name);
            }
            if (!string.IsNullOrEmpty(updateSpec.Description))
            {
                calendar.Add("description", updateSpec.Description);
            }

            await client.PutAsync(updateSpec.Id, calendar);
        }

        /// <summary>
        /// Subscribe to a public calendar.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="subscribeUrl">For example: webcal://ical.mac.com/fredduck/Anime47Game32Birthdays.ics</param>
        /// <returns></returns>
        public async Task Subscribe(string name, string description, string subscribeUrl, string[] scopes = null)
        {
            LiveConnectClient liveClient = await GetConnectClientAsync(scopes);
            var calendar = new Dictionary<string, object>();
            calendar.Add("name", name);
            calendar.Add("description", description);
            calendar.Add("subscription_url", "");
            LiveOperationResult operationResult = await liveClient.PostAsync("me/calendars", calendar);
        }
    }
}
