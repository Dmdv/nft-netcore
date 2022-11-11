// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable CollectionNeverUpdated.Global
#pragma warning disable CS8618

namespace Nft.Models.Opensea.Target.Token;

public class SaleAsset
{
    public object Decimals { get; set; }
    public string TokenId { get; set; }
}

public class AssetContract
{
    public string Address { get; set; }
    public string AssetContractType { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public object NftVersion { get; set; }
    public string OpenseaVersion { get; set; }
    public int Owner { get; set; }
    public string SchemaName { get; set; }
    public string Symbol { get; set; }
    public object TotalSupply { get; set; }
    public string Description { get; set; }
    public object ExternalLink { get; set; }
    public string ImageUrl { get; set; }
    public bool DefaultToFiat { get; set; }
    public int DevBuyerFeeBasisPoints { get; set; }
    public int DevSellerFeeBasisPoints { get; set; }
    public bool OnlyProxiedTransfers { get; set; }
    public int OpenseaBuyerFeeBasisPoints { get; set; }
    public int OpenseaSellerFeeBasisPoints { get; set; }
    public int BuyerFeeBasisPoints { get; set; }
    public int SellerFeeBasisPoints { get; set; }
    public object PayoutAddress { get; set; }
}

public class Collection
{
    public List<PaymentToken> PaymentTokens { get; set; }
    public List<object> PrimaryAssetContracts { get; set; }
    // public Traits Traits { get; set; }
    public Stats Stats { get; set; }
    public string BannerImageUrl { get; set; }
    public object ChatUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool DefaultToFiat { get; set; }
    public string Description { get; set; }
    public string DevBuyerFeeBasisPoints { get; set; }
    public string DevSellerFeeBasisPoints { get; set; }
    public string DiscordUrl { get; set; }
    public DisplayData DisplayData { get; set; }
    public string ExternalUrl { get; set; }
    public bool Featured { get; set; }
    public string FeaturedImageUrl { get; set; }
    public bool Hidden { get; set; }
    public string SafelistRequestStatus { get; set; }
    public string ImageUrl { get; set; }
    public bool IsSubjectToWhitelist { get; set; }
    public string LargeImageUrl { get; set; }
    public object MediumUsername { get; set; }
    public string Name { get; set; }
    public bool OnlyProxiedTransfers { get; set; }
    public string OpenseaBuyerFeeBasisPoints { get; set; }
    public string OpenseaSellerFeeBasisPoints { get; set; }
    public string PayoutAddress { get; set; }
    public bool RequireEmail { get; set; }
    public object ShortDescription { get; set; }
    public string Slug { get; set; }
    public object TelegramUrl { get; set; }
    public string TwitterUsername { get; set; }
    public object InstagramUsername { get; set; }
    public object WikiUrl { get; set; }
    public bool IsNsfw { get; set; }
    public bool IsRarityEnabled { get; set; }
}

public class Creator
{
    public User User { get; set; }
    public string ProfileImgUrl { get; set; }
    public string Address { get; set; }
    public string Config { get; set; }
}

public class DisplayData
{
    public string CardDisplayStyle { get; set; }
}

public class LastSale
{
    public SaleAsset Asset { get; set; }
    public object AssetBundle { get; set; }
    public string EventType { get; set; }
    public DateTime EventTimestamp { get; set; }
    public object AuctionType { get; set; }
    public string TotalPrice { get; set; }
    public PaymentToken PaymentToken { get; set; }
    public object Transaction { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Quantity { get; set; }
}

public class Owner
{
    public User User { get; set; }
    public string ProfileImgUrl { get; set; }
    public string Address { get; set; }
    public string Config { get; set; }
}

public class PaymentToken
{
    public int Id { get; set; }
    public string Symbol { get; set; }
    public string Address { get; set; }
    public string ImageUrl { get; set; }
    public string Name { get; set; }
    public int Decimals { get; set; }
    // public double EthPrice { get; set; }
    // public double UsdPrice { get; set; }
}

public class TokenViewModel
{
    public int Id { get; set; }
    public int NumSales { get; set; }
    public object BackgroundColor { get; set; }
    public string ImageUrl { get; set; }
    public string ImagePreviewUrl { get; set; }
    public string ImageThumbnailUrl { get; set; }
    public object ImageOriginalUrl { get; set; }
    public object AnimationUrl { get; set; }
    public object AnimationOriginalUrl { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ExternalLink { get; set; }
    public AssetContract AssetContract { get; set; }
    public string Permalink { get; set; }
    public Collection Collection { get; set; }
    public object Decimals { get; set; }
    public object TokenMetadata { get; set; }
    public bool IsNsfw { get; set; }
    public Owner Owner { get; set; }
    public object SeaportSellOrders { get; set; }
    public Creator Creator { get; set; }
    public List<Trait> Traits { get; set; }
    public LastSale LastSale { get; set; }
    public object TopBid { get; set; }
    public object ListingDate { get; set; }
    public bool IsPresale { get; set; }
    public object TransferFee { get; set; }
    public object TransferFeePaymentToken { get; set; }
    public bool SupportsWyvern { get; set; }
    public object RarityData { get; set; }
    public List<object> RelatedAssets { get; set; }
    public object Orders { get; set; }
    public List<object> Auctions { get; set; }
    public List<TopOwnership> TopOwnerships { get; set; }
    public object Ownership { get; set; }
    public object HighestBuyerCommitment { get; set; }
    public string TokenId { get; set; }
}

public class Stats
{
    public double OneHourVolume { get; set; }
    public double OneHourChange { get; set; }
    public double OneHourSales { get; set; }
    public double OneHourSalesChange { get; set; }
    public double OneHourAveragePrice { get; set; }
    public double OneHourDifference { get; set; }
    public double SixHourVolume { get; set; }
    public double SixHourChange { get; set; }
    public double SixHourSales { get; set; }
    public double SixHourSalesChange { get; set; }
    public double SixHourAveragePrice { get; set; }
    public double SixHourDifference { get; set; }
    public double OneDayVolume { get; set; }
    public double OneDayChange { get; set; }
    public double OneDaySales { get; set; }
    public double OneDaySalesChange { get; set; }
    public double OneDayAveragePrice { get; set; }
    public double OneDayDifference { get; set; }
    public double SevenDayVolume { get; set; }
    public double SevenDayChange { get; set; }
    public double SevenDaySales { get; set; }
    public double SevenDayAveragePrice { get; set; }
    public double SevenDayDifference { get; set; }
    public double ThirtyDayVolume { get; set; }
    public double ThirtyDayChange { get; set; }
    public double ThirtyDaySales { get; set; }
    public double ThirtyDayAveragePrice { get; set; }
    public double ThirtyDayDifference { get; set; }
    public double TotalVolume { get; set; }
    public double TotalSales { get; set; }
    public double TotalSupply { get; set; }
    public double Count { get; set; }
    public int NumOwners { get; set; }
    public double AveragePrice { get; set; }
    public int NumReports { get; set; }
    public double MarketCap { get; set; }
    public int FloorPrice { get; set; }
}

public class TopOwnership
{
    public Owner Owner { get; set; }
    public string Quantity { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class Trait
{
    public string TraitType { get; set; }
    public string Value { get; set; }
    public object DisplayType { get; set; }
    public object MaxValue { get; set; }
    public int TraitCount { get; set; }
    public object Order { get; set; }
}

public class User
{
    public string Username { get; set; }
}

