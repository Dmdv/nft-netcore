// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Nft.ArgumentsBinding;

public class TrendingArgs
{
    // [BindProperty(Name = "orderby")]
    // [EnumDataType(typeof(OrderBy))]
    // [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrderBy OrderBy { get; set; }

    public SortDirection SortDirection { get; set; }
}

public enum OrderBy
{
    // [EnumMember(Value = "AVERAGE")]
    Average,
    // [EnumMember(Value = "SALES")]
    Sales,
    // [EnumMember(Value = "VOLUME")]
    Volume,
}

public enum SortDirection
{
    Ascending,
    Descending
}