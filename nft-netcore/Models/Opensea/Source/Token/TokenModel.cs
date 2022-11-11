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
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
// ReSharper disable UnusedAutoPropertyAccessor.Global
#pragma warning disable CS8618
using System.Text.Json.Serialization;

namespace Nft.Models.Opensea.Source.Token;

public class SaleAsset
{
    [JsonPropertyName("decimals")]
    public object Decimals { get; set; }

    [JsonPropertyName("token_id")]
    public string TokenId { get; set; }
}

public class AssetContract
{
    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("asset_contract_type")]
    public string AssetContractType { get; set; }

    [JsonPropertyName("created_date")]
    public DateTime CreatedDate { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("nft_version")]
    public object NftVersion { get; set; }

    [JsonPropertyName("opensea_version")]
    public string OpenseaVersion { get; set; }

    [JsonPropertyName("owner")]
    public int Owner { get; set; }

    [JsonPropertyName("schema_name")]
    public string SchemaName { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("total_supply")]
    public object TotalSupply { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("external_link")]
    public object ExternalLink { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("default_to_fiat")]
    public bool DefaultToFiat { get; set; }

    [JsonPropertyName("dev_buyer_fee_basis_points")]
    public int DevBuyerFeeBasisPoints { get; set; }

    [JsonPropertyName("dev_seller_fee_basis_points")]
    public int DevSellerFeeBasisPoints { get; set; }

    [JsonPropertyName("only_proxied_transfers")]
    public bool OnlyProxiedTransfers { get; set; }

    [JsonPropertyName("opensea_buyer_fee_basis_points")]
    public int OpenseaBuyerFeeBasisPoints { get; set; }

    [JsonPropertyName("opensea_seller_fee_basis_points")]
    public int OpenseaSellerFeeBasisPoints { get; set; }

    [JsonPropertyName("buyer_fee_basis_points")]
    public int BuyerFeeBasisPoints { get; set; }

    [JsonPropertyName("seller_fee_basis_points")]
    public int SellerFeeBasisPoints { get; set; }

    [JsonPropertyName("payout_address")]
    public object PayoutAddress { get; set; }
}

public class Collection
{
    [JsonPropertyName("payment_tokens")]
    public List<PaymentToken> PaymentTokens { get; set; }

    [JsonPropertyName("primary_asset_contracts")]
    public List<object> PrimaryAssetContracts { get; set; }

    // [JsonPropertyName("traits")]
    // public Traits Traits { get; set; }

    [JsonPropertyName("stats")]
    public TokenStat Stats { get; set; }

    [JsonPropertyName("banner_image_url")]
    public string BannerImageUrl { get; set; }

    [JsonPropertyName("chat_url")]
    public object ChatUrl { get; set; }

    [JsonPropertyName("created_date")]
    public DateTime CreatedDate { get; set; }

    [JsonPropertyName("default_to_fiat")]
    public bool DefaultToFiat { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("dev_buyer_fee_basis_points")]
    public string DevBuyerFeeBasisPoints { get; set; }

    [JsonPropertyName("dev_seller_fee_basis_points")]
    public string DevSellerFeeBasisPoints { get; set; }

    [JsonPropertyName("discord_url")]
    public string DiscordUrl { get; set; }

    [JsonPropertyName("external_url")]
    public string ExternalUrl { get; set; }

    [JsonPropertyName("featured")]
    public bool Featured { get; set; }

    [JsonPropertyName("featured_image_url")]
    public string FeaturedImageUrl { get; set; }

    [JsonPropertyName("hidden")]
    public bool Hidden { get; set; }

    [JsonPropertyName("safelist_request_status")]
    public string SafelistRequestStatus { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("is_subject_to_whitelist")]
    public bool IsSubjectToWhitelist { get; set; }

    [JsonPropertyName("large_image_url")]
    public string LargeImageUrl { get; set; }

    [JsonPropertyName("medium_username")]
    public object MediumUsername { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("only_proxied_transfers")]
    public bool OnlyProxiedTransfers { get; set; }

    [JsonPropertyName("opensea_buyer_fee_basis_points")]
    public string OpenseaBuyerFeeBasisPoints { get; set; }

    [JsonPropertyName("opensea_seller_fee_basis_points")]
    public string OpenseaSellerFeeBasisPoints { get; set; }

    [JsonPropertyName("payout_address")]
    public string PayoutAddress { get; set; }

    [JsonPropertyName("require_email")]
    public bool RequireEmail { get; set; }

    [JsonPropertyName("short_description")]
    public object ShortDescription { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("telegram_url")]
    public object TelegramUrl { get; set; }

    [JsonPropertyName("twitter_username")]
    public string TwitterUsername { get; set; }

    [JsonPropertyName("instagram_username")]
    public object InstagramUsername { get; set; }

    [JsonPropertyName("wiki_url")]
    public object WikiUrl { get; set; }

    [JsonPropertyName("is_nsfw")]
    public bool IsNsfw { get; set; }

    [JsonPropertyName("is_rarity_enabled")]
    public bool IsRarityEnabled { get; set; }
}

public class Creator
{
    [JsonPropertyName("user")]
    public User User { get; set; }

    [JsonPropertyName("profile_img_url")]
    public string ProfileImgUrl { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("config")]
    public string Config { get; set; }
}

public class LastSale
{
    [JsonPropertyName("asset")]
    public SaleAsset Asset { get; set; }

    [JsonPropertyName("asset_bundle")]
    public object AssetBundle { get; set; }

    [JsonPropertyName("event_type")]
    public string EventType { get; set; }

    [JsonPropertyName("event_timestamp")]
    public DateTime EventTimestamp { get; set; }

    [JsonPropertyName("auction_type")]
    public object AuctionType { get; set; }

    [JsonPropertyName("total_price")]
    public string TotalPrice { get; set; }

    [JsonPropertyName("payment_token")]
    public PaymentToken PaymentToken { get; set; }

    [JsonPropertyName("transaction")]
    public object Transaction { get; set; }

    [JsonPropertyName("created_date")]
    public DateTime CreatedDate { get; set; }

    [JsonPropertyName("quantity")]
    public string Quantity { get; set; }
}

public class Owner
{
    [JsonPropertyName("user")]
    public User User { get; set; }

    [JsonPropertyName("profile_img_url")]
    public string ProfileImgUrl { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("config")]
    public string Config { get; set; }
}

public class PaymentToken
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("decimals")]
    public int Decimals { get; set; }

    // [JsonPropertyName("eth_price")]
    // public double EthPrice { get; set; }
    //
    // [JsonPropertyName("usd_price")]
    // public double UsdPrice { get; set; }
}

public class TokenModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("num_sales")]
    public int NumSales { get; set; }

    [JsonPropertyName("background_color")]
    public object BackgroundColor { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("image_preview_url")]
    public string ImagePreviewUrl { get; set; }

    [JsonPropertyName("image_thumbnail_url")]
    public string ImageThumbnailUrl { get; set; }

    [JsonPropertyName("image_original_url")]
    public object ImageOriginalUrl { get; set; }

    [JsonPropertyName("animation_url")]
    public object AnimationUrl { get; set; }

    [JsonPropertyName("animation_original_url")]
    public object AnimationOriginalUrl { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("external_link")]
    public string ExternalLink { get; set; }

    [JsonPropertyName("asset_contract")]
    public AssetContract AssetContract { get; set; }

    [JsonPropertyName("permalink")]
    public string Permalink { get; set; }

    [JsonPropertyName("collection")]
    public Collection Collection { get; set; }

    [JsonPropertyName("decimals")]
    public object Decimals { get; set; }

    [JsonPropertyName("token_metadata")]
    public object TokenMetadata { get; set; }

    [JsonPropertyName("is_nsfw")]
    public bool IsNsfw { get; set; }

    [JsonPropertyName("owner")]
    public Owner Owner { get; set; }

    [JsonPropertyName("seaport_sell_orders")]
    public object SeaportSellOrders { get; set; }

    [JsonPropertyName("creator")]
    public Creator Creator { get; set; }

    [JsonPropertyName("traits")]
    public List<Trait> Traits { get; set; }

    [JsonPropertyName("last_sale")]
    public LastSale LastSale { get; set; }

    [JsonPropertyName("top_bid")]
    public object TopBid { get; set; }

    [JsonPropertyName("listing_date")]
    public object ListingDate { get; set; }

    [JsonPropertyName("is_presale")]
    public bool IsPresale { get; set; }

    [JsonPropertyName("transfer_fee")]
    public object TransferFee { get; set; }

    [JsonPropertyName("transfer_fee_payment_token")]
    public object TransferFeePaymentToken { get; set; }

    [JsonPropertyName("supports_wyvern")]
    public bool SupportsWyvern { get; set; }

    [JsonPropertyName("rarity_data")]
    public object RarityData { get; set; }

    [JsonPropertyName("related_assets")]
    public List<object> RelatedAssets { get; set; }

    [JsonPropertyName("orders")]
    public object Orders { get; set; }

    [JsonPropertyName("auctions")]
    public List<object> Auctions { get; set; }

    [JsonPropertyName("top_ownerships")]
    public List<TopOwnership> TopOwnerships { get; set; }

    [JsonPropertyName("ownership")]
    public object Ownership { get; set; }

    [JsonPropertyName("highest_buyer_commitment")]
    public object HighestBuyerCommitment { get; set; }

    [JsonPropertyName("token_id")]
    public string TokenId { get; set; }
}

public class TokenStat
{
    [JsonPropertyName("one_hour_volume")]
    public double OneHourVolume { get; set; }

    [JsonPropertyName("one_hour_change")]
    public double OneHourChange { get; set; }

    [JsonPropertyName("one_hour_sales")]
    public double OneHourSales { get; set; }

    [JsonPropertyName("one_hour_sales_change")]
    public double OneHourSalesChange { get; set; }

    [JsonPropertyName("one_hour_average_price")]
    public double OneHourAveragePrice { get; set; }

    [JsonPropertyName("one_hour_difference")]
    public double OneHourDifference { get; set; }

    [JsonPropertyName("six_hour_volume")]
    public double SixHourVolume { get; set; }

    [JsonPropertyName("six_hour_change")]
    public double SixHourChange { get; set; }

    [JsonPropertyName("six_hour_sales")]
    public double SixHourSales { get; set; }

    [JsonPropertyName("six_hour_sales_change")]
    public double SixHourSalesChange { get; set; }

    [JsonPropertyName("six_hour_average_price")]
    public double SixHourAveragePrice { get; set; }

    [JsonPropertyName("six_hour_difference")]
    public double SixHourDifference { get; set; }

    [JsonPropertyName("one_day_volume")]
    public double OneDayVolume { get; set; }

    [JsonPropertyName("one_day_change")]
    public double OneDayChange { get; set; }

    [JsonPropertyName("one_day_sales")]
    public double OneDaySales { get; set; }

    [JsonPropertyName("one_day_sales_change")]
    public double OneDaySalesChange { get; set; }

    [JsonPropertyName("one_day_average_price")]
    public double OneDayAveragePrice { get; set; }

    [JsonPropertyName("one_day_difference")]
    public double OneDayDifference { get; set; }

    [JsonPropertyName("seven_day_volume")]
    public double SevenDayVolume { get; set; }

    [JsonPropertyName("seven_day_change")]
    public double SevenDayChange { get; set; }

    [JsonPropertyName("seven_day_sales")]
    public double SevenDaySales { get; set; }

    [JsonPropertyName("seven_day_average_price")]
    public double SevenDayAveragePrice { get; set; }

    [JsonPropertyName("seven_day_difference")]
    public double SevenDayDifference { get; set; }

    [JsonPropertyName("thirty_day_volume")]
    public double ThirtyDayVolume { get; set; }

    [JsonPropertyName("thirty_day_change")]
    public double ThirtyDayChange { get; set; }

    [JsonPropertyName("thirty_day_sales")]
    public double ThirtyDaySales { get; set; }

    [JsonPropertyName("thirty_day_average_price")]
    public double ThirtyDayAveragePrice { get; set; }

    [JsonPropertyName("thirty_day_difference")]
    public double ThirtyDayDifference { get; set; }

    [JsonPropertyName("total_volume")]
    public double TotalVolume { get; set; }

    [JsonPropertyName("total_sales")]
    public double TotalSales { get; set; }

    [JsonPropertyName("total_supply")]
    public double TotalSupply { get; set; }

    [JsonPropertyName("count")]
    public double Count { get; set; }

    [JsonPropertyName("num_owners")]
    public int NumOwners { get; set; }

    [JsonPropertyName("average_price")]
    public double AveragePrice { get; set; }

    [JsonPropertyName("num_reports")]
    public int NumReports { get; set; }

    [JsonPropertyName("market_cap")]
    public double MarketCap { get; set; }

    [JsonPropertyName("floor_price")]
    public int FloorPrice { get; set; }
}

public class TopOwnership
{
    [JsonPropertyName("owner")]
    public Owner Owner { get; set; }

    [JsonPropertyName("quantity")]
    public string Quantity { get; set; }

    [JsonPropertyName("created_date")]
    public DateTime CreatedDate { get; set; }
}

public class Trait
{
    [JsonPropertyName("trait_type")]
    public string TraitType { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("display_type")]
    public object DisplayType { get; set; }

    [JsonPropertyName("max_value")]
    public object MaxValue { get; set; }

    [JsonPropertyName("trait_count")]
    public int TraitCount { get; set; }

    [JsonPropertyName("order")]
    public object Order { get; set; }
}

public class User
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
}

public class DisplayData
{
    [JsonPropertyName("card_display_style")]
    public string CardDisplayStyle;
}