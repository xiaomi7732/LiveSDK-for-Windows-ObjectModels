# LiveSDK-for-Windows-ObjectModels
This is object models for Live-SDK-for-Windows to make it easier to use, cause less error.

Starting from 0.1.3-alpha, the nuget package could be reference by Windows 8.1 App or Windows 10 Universal Application Platform Apps.

# Code samples
## Setup
1. Add NuGet package of LiveSDK.
2. Add NuGet package of LiveSDK for Windows Object Models [here](https://www.nuget.org/packages/LiveSDK.ObjectModel/).

    - Run the following command in the Package Manager Console 
```
    Install-Package LiveSDK.ObjectModel -Pre
```

## Usage

```
// Strong typed LiveScopes are provided in this Library.
loginResult = await auth.LoginAsync(new string[]{
    LiveScopes.Basic,
    LiveScopes.ContactsEmails,
    LiveScopes.ContactsPhotos
});
```

```
// GetAsync<T> extenion method provides convenient way to get strong typed result out of LiveSDK calls.
Contacts contacts = await connect.GetAsync<Contacts>("me/contacts");
```

#Contritbute
## Branches
### Dev Branches
Please prefix dev branch with dev/. 

For exmaple: **dev/**feature1.

### Release Branches
When release the nuget package, a release branch will be created like the one below:

**rel/**0.1.3-alpha

All pull request are welcome! Please send them against master branch and the change will show up in the next release.

## Build
Projects can be opened in Visual Studio 2015 and being built there. There are some commands to make build easier.

* Build.cmd - Build the solutions in configuration of release.
* Pack.cmd - Create a nuget package out of the build result.

Note: The package by default will be packed into bin folder. The released package can be found in redist folder.