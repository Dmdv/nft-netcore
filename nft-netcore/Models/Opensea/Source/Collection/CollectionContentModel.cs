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
// ReSharper disable UnusedAutoPropertyAccessor.Global
#pragma warning disable CS8618

using System.Text.Json.Serialization;
using Nft.Models.Opensea.Source.Token;

namespace Nft.Models.Opensea.Source.Collection;

public class CollectionContentModel
{
    [JsonPropertyName("next")]
    public string Next { get; set; }

    [JsonPropertyName("previous")]
    public string Previous  { get; set; }

    [JsonPropertyName("assets")]
    public List<Asset> Assets  { get; set; }
}

public class Asset
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
    public string ImageOriginalUrl { get; set; }

    [JsonPropertyName("animation_url")]
    public object AnimationUrl { get; set; }

    [JsonPropertyName("animation_original_url")]
    public object AnimationOriginalUrl { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public object Description { get; set; }

    [JsonPropertyName("external_link")]
    public object ExternalLink { get; set; }
    
    [JsonPropertyName("asset_contract")]
    public AssetContract AssetContract { get; set; }

    [JsonPropertyName("permalink")]
    public string Permalink { get; set; }

    [JsonPropertyName("collection")]
    public ParentCollection Collection { get; set; }

    [JsonPropertyName("decimals")]
    public object Decimals { get; set; }

    [JsonPropertyName("token_metadata")]
    public string TokenMetadata { get; set; }

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

    [JsonPropertyName("supports_wyvern")]
    public bool SupportsWyvern { get; set; }

    [JsonPropertyName("rarity_data")]
    public object RarityData { get; set; }

    [JsonPropertyName("transfer_fee")]
    public object TransferFee { get; set; }

    [JsonPropertyName("transfer_fee_payment_token")]
    public object TransferFeePaymentToken { get; set; }

    [JsonPropertyName("token_id")]
    public string TokenId { get; set; }
}

public class ParentCollection
{
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

    [JsonPropertyName("display_data")]
    public DisplayData DisplayData { get; set; }

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