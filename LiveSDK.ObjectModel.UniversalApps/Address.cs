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

    /// <summary>
    /// The user's postal address.
    /// </summary>
    [DataContract(Namespace = LiveSDKOMConsts.DataContractsDefaltNamespace)]
    [KnownType(typeof(Personal))]
    [KnownType(typeof(Business))]
    public class Address : LiveSDKOM
    {
        /// <summary>
        /// The user's street address, or null if one is not specified.
        /// </summary>
        [DataMember(Name = "street")]
        public string Street { get; set; }

        /// <summary>
        /// The second line of the user's street address, or null if one is not specified.
        /// </summary>
        [DataMember(Name = "street_2")]
        public string Street2 { get; set; }

        /// <summary>
        /// The city of the user's address, or null if one is not specified.
        /// </summary>
        [DataMember(Name = "city")]
        public string City { get; set; }

        /// <summary>
        /// The state of the user's address, or null if one is not specified.
        /// </summary>
        [DataMember(Name = "state")]
        public string State { get; set; }

        /// <summary>
        /// The postal code of the user's address, or null if one is not specified.
        /// </summary>
        [DataMember(Name = "postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The region of the user's address, or null if one is not specified.
        /// </summary>
        [DataMember(Name = "region")]
        public string Region { get; set; }
    }
}
