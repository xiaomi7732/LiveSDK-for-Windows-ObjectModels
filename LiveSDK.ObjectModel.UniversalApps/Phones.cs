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
    /// The user's phone numbers.
    /// </summary>
    [DataContract(Namespace = LiveSDKOMConsts.DataContractsDefaltNamespace)]
    public class Phones : LiveSDKOM
    {
        /// <summary>
        /// The user's personal phone number, or null if one is not specified.
        /// </summary>
        [DataMember(Name = "personal")]
        public string Personal { get; set; }

        /// <summary>
        /// The user's business phone number, or null if one is not specified.
        /// </summary>
        [DataMember(Name="business")]
        public string Business { get; set; }

        /// <summary>
        /// The user's mobile phone number, or null if one is not specified.
        /// </summary>
        [DataMember(Name="mobile")]
        public string Mobile { get; set; }
    }
}
