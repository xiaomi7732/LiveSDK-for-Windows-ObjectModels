﻿using Microsoft.Live;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveSDK.ObjectModel.LiveServices.Implementations
{
    public abstract class LiveService
    {
        public LiveService()
        {

        }

        public LiveService(params string[] scopes)
        {
            Scopes = new List<string>();
            if (scopes != null && scopes.Length > 0)
            {
                foreach (string scope in scopes)
                {
                    Scopes.Add(scope);
                }
            }
        }

        public List<string> Scopes { get; set; }

        protected async Task<LiveConnectClient> GetConnectClientAsync()
        {
            if (Scopes == null)
            {
                throw new System.ArgumentNullException("Scopes");
            }

            LiveAuthClient auth = null;
            LiveLoginResult initResult = null;
            LiveLoginResult loginResult = null;

            auth = new LiveAuthClient();
            initResult = await auth.InitializeAsync();

            loginResult = await auth.LoginAsync(Scopes);
            if (loginResult.Session != null)
            {
                LiveConnectClient connect = new LiveConnectClient(auth.Session);
                return connect;
            }
            throw new InvalidOperationException("Fail to fetch the Live Connect Client");
        }
    }
}
