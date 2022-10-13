// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global

using System.Text;

namespace Nft.ArgumentsBinding;

public record TrendingArgs
{
    // [BindProperty(Name = "orderby")]
    // [EnumDataType(typeof(OrderBy))]
    // [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrderBy? OrderBy { get; set; }
    public OrderDirection? OrderDirection { get; set; }
    public TimePeriod? TimePeriod { get; set; }
    public string? After { get; set; }
    public int? First { get; set; }
    public bool Refresh { get; set; }
    // ?markets=[[in|1,2,3][eq|2]] = if array
    // ?Markets.Op=Eq&Markets.Market=1&Markets.Market=2 = if one item
    public MarketPlaceFilter? Markets { get; set; }
}

public enum TimePeriod
{
    ONE_HOUR,
    TWELVE_HOURS,
    ONE_DAY,
    SEVEN_DAYS
}

public record MarketPlaceFilter(OrderMarketplaceInput Op, Marketplace[] Market)
{
    public override string ToString()
    {
        var sb = new StringBuilder().AppendJoin('+', Market.Select(x => x.String()));
        return $"{Op.String()}:{sb}";
    }
}

public enum Marketplace
{
    Cryptopunks,
    Gem,
    Genie,
    Looksrare,
    Niftygateway,
    Opensea,
    X2Y2,
    Zerox
}

public enum OrderMarketplaceInput
{
    Eq,
    In,
    NotIn,
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

public enum OrderDirection
{
    Asc,
    Desc
}

// Extensions for enums
public static class EnumsZeroAllocations
{
    public static string String(this Marketplace en)
    {
        return en switch
        {
            Marketplace.Cryptopunks => nameof(Marketplace.Cryptopunks),
            Marketplace.Gem => nameof(Marketplace.Gem),
            Marketplace.Genie => nameof(Marketplace.Genie),
            Marketplace.Looksrare => nameof(Marketplace.Looksrare),
            Marketplace.Niftygateway => nameof(Marketplace.Niftygateway),
            Marketplace.Opensea => nameof(Marketplace.Opensea),
            Marketplace.Zerox => nameof(Marketplace.Zerox),
            Marketplace.X2Y2 => nameof(Marketplace.X2Y2),
            _ => throw new ArgumentOutOfRangeException(nameof(en), en, null)
        };
    }
    
    public static string String(this TimePeriod? en)
    {
        return en switch
        {
            TimePeriod.ONE_DAY => nameof(TimePeriod.ONE_DAY),
            TimePeriod.ONE_HOUR => nameof(TimePeriod.ONE_HOUR),
            TimePeriod.SEVEN_DAYS => nameof(TimePeriod.SEVEN_DAYS),
            TimePeriod.TWELVE_HOURS => nameof(TimePeriod.TWELVE_HOURS),
            _ => throw new ArgumentOutOfRangeException(nameof(en), en, null)
        };
    }
    
    public static string String(this TimePeriod en)
    {
        return en switch
        {
            TimePeriod.ONE_DAY => nameof(TimePeriod.ONE_DAY),
            TimePeriod.ONE_HOUR => nameof(TimePeriod.ONE_HOUR),
            TimePeriod.SEVEN_DAYS => nameof(TimePeriod.SEVEN_DAYS),
            TimePeriod.TWELVE_HOURS => nameof(TimePeriod.TWELVE_HOURS),
            _ => throw new ArgumentOutOfRangeException(nameof(en), en, null)
        };
    }
    
    public static string String(this OrderMarketplaceInput en)
    {
        return en switch
        {
            OrderMarketplaceInput.Eq => nameof(OrderMarketplaceInput.Eq),
            OrderMarketplaceInput.In => nameof(OrderMarketplaceInput.In),
            OrderMarketplaceInput.NotIn => nameof(OrderMarketplaceInput.NotIn),
            _ => throw new ArgumentOutOfRangeException(nameof(en), en, null)
        };
    }
    
    public static string String(this OrderMarketplaceInput? en)
    {
        return en switch
        {
            OrderMarketplaceInput.Eq => nameof(OrderMarketplaceInput.Eq),
            OrderMarketplaceInput.In => nameof(OrderMarketplaceInput.In),
            OrderMarketplaceInput.NotIn => nameof(OrderMarketplaceInput.NotIn),
            _ => throw new ArgumentOutOfRangeException(nameof(en), en, null)
        };
    }
    
    public static string String(this OrderBy? en)
    {
        return en switch
        {
            OrderBy.Average => nameof(OrderBy.Average),
            OrderBy.Sales => nameof(OrderBy.Sales),
            OrderBy.Volume => nameof(OrderBy.Volume),
            _ => throw new ArgumentOutOfRangeException(nameof(en), en, null)
        };
    }
    
    public static string String(this OrderBy en)
    {
        return en switch
        {
            OrderBy.Average => nameof(OrderBy.Average),
            OrderBy.Sales => nameof(OrderBy.Sales),
            OrderBy.Volume => nameof(OrderBy.Volume),
            _ => throw new ArgumentOutOfRangeException(nameof(en), en, null)
        };
    }
    
    public static string String(this OrderDirection? en)
    {
        return en switch
        {
            OrderDirection.Asc => nameof(OrderDirection.Asc),
            OrderDirection.Desc => nameof(OrderDirection.Desc),
            _ => throw new ArgumentOutOfRangeException(nameof(en), en, null)
        };
    }
    
    public static string String(this OrderDirection en)
    {
        return en switch
        {
            OrderDirection.Asc => nameof(OrderDirection.Asc),
            OrderDirection.Desc => nameof(OrderDirection.Desc),
            _ => throw new ArgumentOutOfRangeException(nameof(en), en, null)
        };
    }
}