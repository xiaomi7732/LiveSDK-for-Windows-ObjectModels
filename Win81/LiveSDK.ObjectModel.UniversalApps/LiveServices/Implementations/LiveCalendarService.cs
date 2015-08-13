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

        public async Task<Calendars> GetMyCalendars(CancellationToken? cancel)
        {
            var client = await GetConnectClientAsync();
            return await client.GetAsync<Calendars>("me/calendars");
        }

        public async Task<Calendar> GetCalendar(string calendarId, CancellationToken? cancel)
        {
            var client = await GetConnectClientAsync();
            return await client.GetAsync<Calendar>(calendarId, cancel);
        }

        public async Task DeleteCalendar(string calendarId)
        {
            var client = await GetConnectClientAsync();
            await client.DeleteAsync(calendarId);
        }

        public async Task<string> CreateCalendar(string name, string description)
        {
            var client = await GetConnectClientAsync();
            var calendar = new Dictionary<string, object>();
            calendar.Add("name", name);
            calendar.Add("description", description);
            LiveOperationResult operationResult = await client.PostAsync("me/calendars", calendar);
            dynamic result = operationResult.Result;
            return result.id;
        }

        public async Task UpdateCanedlar(Calendar updateSpec)
        {
            var client = await GetConnectClientAsync();
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
        public async Task Subscribe(string name, string description, string subscribeUrl)
        {
            LiveConnectClient liveClient = await GetConnectClientAsync();
            var calendar = new Dictionary<string, object>();
            calendar.Add("name", name);
            calendar.Add("description", description);
            calendar.Add("subscription_url", "");
            LiveOperationResult operationResult = await liveClient.PostAsync("me/calendars", calendar);
        }
    }
}
