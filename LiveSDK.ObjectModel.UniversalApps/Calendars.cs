using Newtonsoft.Json;
using System.Collections.Generic;

namespace LiveSDK.ObjectModel
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Calendars : LiveSDKOM
    {
        [JsonProperty(PropertyName = "data")]
        public List<Calendar> Items { get; set; }
    }
}
