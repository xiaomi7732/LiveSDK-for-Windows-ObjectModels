# LiveSDK-for-Windows-ObjectModels
This is object models for Live-SDK-for-Windows to make it easier to use, cause less error.

# Code samples
1. Add NuGet package of LiveSDK.
2. Add Reference to this LiveSDK.ObjectModel.UniversalApps.dll.

Sample Code:
```
using LiveSDK.ObjectModel;
using LiveSDK.ObjectModel.Extensions;
using Microsoft.Live;
namespace SampleCode
{
	public class Sample
	{
		public void ContactsExample()
		{
			LiveAuthClient auth = null;
            LiveLoginResult initResult = null;
            LiveLoginResult loginResult = null;

            auth = new LiveAuthClient();
            initResult = await auth.InitializeAsync();
            // =============================================================================================
			// More strong typed LiveScopes are provided in this Library.
			// =============================================================================================
            loginResult = await auth.LoginAsync(new string[]{
                LiveScopes.Basic,
                LiveScopes.ContactsEmails,
                LiveScopes.ContactsPhotos
            });

			if (loginResult.Session != null)
            {
                LiveConnectClient connect = new LiveConnectClient(auth.Session);
                // =============================================================================================
				// GetAsync<T> extenion method provides convenient way to get strong typed result out of LiveSDK calls.
				// =============================================================================================
                Contacts contacts = await connect.GetAsync<Contacts>("me/contacts");
                // =============================================================================================
                // Get a list of the contacts.
                // =============================================================================================
				var contactList = contacts.Items.ToList();
				...
            }   
		}

		// Get Profile Picutre by given contact.
		public async Task<stirng> GetLocationByContact(Contact contact)
		{
			// ... get LiveConnectClient to connect
			            
			if (contact!=null && !string.IsNullOrEmpty(contact.UserId))
			{
				tokenSource = new CancellationTokenSource();
				tokenSource.CancelAfter(3000);
				CancellationToken ct = tokenSource.Token;
				
				// Call override of GetAsync<T>(), use cancellation token to timeout the operation.
				Picture pic = await connect.GetAsync<Picture>(string.Format("{0}/picture", contact.UserId, ct));
				return pic.Location;
			}
		}
	}
}
```
# Project progress
3/27: Wrap up the User object.
3/23: Just started this project. Only Contacts and Pictures are supported.
