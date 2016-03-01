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
using System.Threading.Tasks;

namespace LiveSDK.ObjectModel.LiveServices.Interfaces
{
    /// <summary>
    /// Live Event operations
    /// </summary>
    public interface ILiveEventService
    {
        /// <summary>
        /// Return all events between now and the next 30 days by default.
        /// </summary>
        /// <param name="calendarId"></param>
        /// <returns></returns>
        Task<Events> GetCalendarEvents(string calendarId);

        /// <summary>
        /// Return a list of events for a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Events> GetUserEvents(string userId);

        /// <summary>
        /// To create an Event object on a calendar.
        /// </summary>
        /// <param name="newEvent"></param>
        /// <param name="calendarId">Calendar id. To default calendar if not specified.</param>
        /// <returns></returns>
        Task<Event> CreateEvent(Event newEvent, string calendarId);

        /// <summary>
        /// Delete an Event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        Task DeleteEvent(string eventId);
    }
}
