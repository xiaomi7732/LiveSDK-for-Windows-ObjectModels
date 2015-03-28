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
    using System.Runtime.Serialization;

    [DataContract(Namespace = LiveSDKOMConsts.DataContractsDefaltNamespace)]
    public class Emails
    {
        public Emails()
        {
        }

        [DataMember(Name = "preferred")]
        public string Preferred { get; set; }

        [DataMember(Name = "account")]
        public string Account { get; set; }

        [DataMember(Name = "personal")]
        public string Personal { get; set; }

        [DataMember(Name = "business")]
        public string Business { get; set; }

        [DataMember(Name = "other")]
        public string Other { get; set; }
    }
}
