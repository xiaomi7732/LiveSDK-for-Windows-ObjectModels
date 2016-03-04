using System.Threading.Tasks;
namespace LiveSDK.ObjectModel.LiveServices.Interfaces
{
    /// <summary>
    /// Provide calendar related services. Refer https://msdn.microsoft.com/en-us/library/hh826523.aspx#cal_cs.
    /// </summary>
    public interface ILiveCalendarService
    {
        /// <summary>
        /// Create a new calendar for current user.
        /// </summary>
        /// <param name="name">Calendar name.</param>
        /// <param name="description">Calendar description</param>
        /// <returns>New calendar id</returns>
        Task<string> CreateCalendar(string name, string description, string[] scopes=null);

        /// <summary>
        /// Delete a calendar by Id.
        /// </summary>
        /// <param name="calendarId">Calendar id.</param>
        /// <returns></returns>
        Task DeleteCalendar(string calendarId, string[] scopes = null);

        /// <summary>
        /// Get a calendar object by id.
        /// </summary>
        /// <param name="calendarId">Calendar Id.</param>
        /// <param name="cancel">Cancellation token.</param>
        /// <returns></returns>
        Task<Calendar> GetCalendar(string calendarId, System.Threading.CancellationToken? cancel, string[] scopes = null);

        /// <summary>
        /// Get all calendars for current user.
        /// </summary>
        /// <param name="cancel">Cancellation token.</param>
        /// <returns>Calendars object. Retrieve Items on the object to get the calendars.</returns>
        Task<Calendars> GetMyCalendars(System.Threading.CancellationToken? cancel, string[] scopes = null);

        /// <summary>
        /// Subscribe to a public calendar.
        /// </summary>
        /// <param name="name">Calendar Name.</param>
        /// <param name="description">Calendar description</param>
        /// <param name="subscribeUrl">Public calendar url.</param>
        /// <returns></returns>
        Task Subscribe(string name, string description, string subscribeUrl, string[] scopes = null);

        /// <summary>
        /// Update a calendar
        /// </summary>
        /// <param name="updateSpec"></param>
        /// <param name="scopes"></param>
        /// <returns></returns>
        Task UpdateCanedlar(Calendar updateSpec, string[] scopes = null);
    }
}
