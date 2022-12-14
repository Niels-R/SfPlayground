using System.Text.Json.Serialization;
using SfPlayground.Common.Helpers;

namespace SfPlayground.Common.Models;

public class Property
{
    public long PropertyAutoId { get; set; }
    public int CompanyId { get; set; }
    public string? CompanyLanguage { get; set; }
    public string? Reference { get; set; }
    public string? Transaction { get; set; }
    public int TypeId { get; set; }
    public string? Type { get; set; }
    public string? Availability { get; set; }
    public string? ConstructionYear { get; set; }
    public string? BuildingType { get; set; }
    public string? Street { get; set; }
    public string? Number { get; set; }
    public string? Box { get; set; }
    public string? FileAdministrator { get; set; }
    public string? Office { get; set; }
    public string? Owner { get; set; }
    public string? Renter { get; set; }
    public string? Buyer { get; set; }

    [JsonConverter(typeof(BitBoolJsonConverter))]
    public bool Development { get; set; }

    [JsonConverter(typeof(BitBoolJsonConverter))]
    public bool Investment { get; set; }

    [JsonConverter(typeof(BitBoolJsonConverter))]
    public bool Poster { get; set; }

    public int? Bedrooms { get; set; }
    public string? Key { get; set; }
    public string? Status { get; set; }
    public string? ResponsibleSalesRep { get; set; }

    [JsonConverter(typeof(BitBoolJsonConverter))]
    public bool Archived { get; set; }

    [JsonConverter(typeof(BitBoolJsonConverter))]
    public bool Show { get; set; }

    public int Flag { get; set; }
    public long? ProjectPropertyAutoId { get; set; }
    public string? ProjectReference { get; set; }

    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? Creation { get; set; }

    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime? Modified { get; set; }
}
