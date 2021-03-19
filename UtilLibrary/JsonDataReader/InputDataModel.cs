using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class InputDataModel
{
    [JsonProperty("TestDataID")]
    public long TestDataId { get; set; }

    [JsonProperty("ExpectedPageTitle", NullValueHandling = NullValueHandling.Ignore)]
    public string ExpectedPageTitle { get; set; }

    [JsonProperty("ExpectedPageUrl", NullValueHandling = NullValueHandling.Ignore)]
    public string ExpectedPageUrl { get; set; }
}