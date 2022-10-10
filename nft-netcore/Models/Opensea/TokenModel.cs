// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo

public record Asset(
        [property: JsonPropertyName("decimals")] object Decimals,
        [property: JsonPropertyName("token_id")] string TokenId
    );

public record AssetContract(
    [property: JsonPropertyName("address")] string Address,
    [property: JsonPropertyName("asset_contract_type")] string AssetContractType,
    [property: JsonPropertyName("created_date")] DateTime CreatedDate,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("nft_version")] object NftVersion,
    [property: JsonPropertyName("opensea_version")] string OpenseaVersion,
    [property: JsonPropertyName("owner")] int Owner,
    [property: JsonPropertyName("schema_name")] string SchemaName,
    [property: JsonPropertyName("symbol")] string Symbol,
    [property: JsonPropertyName("total_supply")] object TotalSupply,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("external_link")] object ExternalLink,
    [property: JsonPropertyName("image_url")] string ImageUrl,
    [property: JsonPropertyName("default_to_fiat")] bool DefaultToFiat,
    [property: JsonPropertyName("dev_buyer_fee_basis_points")] int DevBuyerFeeBasisPoints,
    [property: JsonPropertyName("dev_seller_fee_basis_points")] int DevSellerFeeBasisPoints,
    [property: JsonPropertyName("only_proxied_transfers")] bool OnlyProxiedTransfers,
    [property: JsonPropertyName("opensea_buyer_fee_basis_points")] int OpenseaBuyerFeeBasisPoints,
    [property: JsonPropertyName("opensea_seller_fee_basis_points")] int OpenseaSellerFeeBasisPoints,
    [property: JsonPropertyName("buyer_fee_basis_points")] int BuyerFeeBasisPoints,
    [property: JsonPropertyName("seller_fee_basis_points")] int SellerFeeBasisPoints,
    [property: JsonPropertyName("payout_address")] object PayoutAddress
);

public record Collection(
    [property: JsonPropertyName("payment_tokens")] IReadOnlyList<PaymentToken> PaymentTokens,
    [property: JsonPropertyName("primary_asset_contracts")] IReadOnlyList<object> PrimaryAssetContracts,
    // [property: JsonPropertyName("traits")] Traits Traits,
    [property: JsonPropertyName("stats")] Stats Stats,
    [property: JsonPropertyName("banner_image_url")] string BannerImageUrl,
    [property: JsonPropertyName("chat_url")] object ChatUrl,
    [property: JsonPropertyName("created_date")] DateTime CreatedDate,
    [property: JsonPropertyName("default_to_fiat")] bool DefaultToFiat,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("dev_buyer_fee_basis_points")] string DevBuyerFeeBasisPoints,
    [property: JsonPropertyName("dev_seller_fee_basis_points")] string DevSellerFeeBasisPoints,
    [property: JsonPropertyName("discord_url")] string DiscordUrl,
    [property: JsonPropertyName("display_data")] DisplayData DisplayData,
    [property: JsonPropertyName("external_url")] string ExternalUrl,
    [property: JsonPropertyName("featured")] bool Featured,
    [property: JsonPropertyName("featured_image_url")] string FeaturedImageUrl,
    [property: JsonPropertyName("hidden")] bool Hidden,
    [property: JsonPropertyName("safelist_request_status")] string SafelistRequestStatus,
    [property: JsonPropertyName("image_url")] string ImageUrl,
    [property: JsonPropertyName("is_subject_to_whitelist")] bool IsSubjectToWhitelist,
    [property: JsonPropertyName("large_image_url")] string LargeImageUrl,
    [property: JsonPropertyName("medium_username")] object MediumUsername,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("only_proxied_transfers")] bool OnlyProxiedTransfers,
    [property: JsonPropertyName("opensea_buyer_fee_basis_points")] string OpenseaBuyerFeeBasisPoints,
    [property: JsonPropertyName("opensea_seller_fee_basis_points")] string OpenseaSellerFeeBasisPoints,
    [property: JsonPropertyName("payout_address")] string PayoutAddress,
    [property: JsonPropertyName("require_email")] bool RequireEmail,
    [property: JsonPropertyName("short_description")] object ShortDescription,
    [property: JsonPropertyName("slug")] string Slug,
    [property: JsonPropertyName("telegram_url")] object TelegramUrl,
    [property: JsonPropertyName("twitter_username")] string TwitterUsername,
    [property: JsonPropertyName("instagram_username")] object InstagramUsername,
    [property: JsonPropertyName("wiki_url")] object WikiUrl,
    [property: JsonPropertyName("is_nsfw")] bool IsNsfw,
    [property: JsonPropertyName("fees")] Fees Fees,
    [property: JsonPropertyName("is_rarity_enabled")] bool IsRarityEnabled
);

public record Creator(
    [property: JsonPropertyName("user")] User User,
    [property: JsonPropertyName("profile_img_url")] string ProfileImgUrl,
    [property: JsonPropertyName("address")] string Address,
    [property: JsonPropertyName("config")] string Config
);

public record DisplayData(
    [property: JsonPropertyName("card_display_style")] string CardDisplayStyle
);

public record Fees;
    // [property: JsonPropertyName("seller_fees")] SellerFees SellerFees,
    // [property: JsonPropertyName("opensea_fees")] OpenseaFees OpenseaFees
// );

public record LastSale(
    [property: JsonPropertyName("asset")] Asset Asset,
    [property: JsonPropertyName("asset_bundle")] object AssetBundle,
    [property: JsonPropertyName("event_type")] string EventType,
    [property: JsonPropertyName("event_timestamp")] DateTime EventTimestamp,
    [property: JsonPropertyName("auction_type")] object AuctionType,
    [property: JsonPropertyName("total_price")] string TotalPrice,
    [property: JsonPropertyName("payment_token")] PaymentToken PaymentToken,
    [property: JsonPropertyName("transaction")] object Transaction,
    [property: JsonPropertyName("created_date")] DateTime CreatedDate,
    [property: JsonPropertyName("quantity")] string Quantity
);

// public record OpenseaFees(
//     [property: JsonPropertyName("0x0000a26b00c1f0df003000390027140000faa719")] int _0x0000a26b00c1f0df003000390027140000faa719
// );

public record Owner(
    [property: JsonPropertyName("user")] User User,
    [property: JsonPropertyName("profile_img_url")] string ProfileImgUrl,
    [property: JsonPropertyName("address")] string Address,
    [property: JsonPropertyName("config")] string Config
);

public record PaymentToken(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("symbol")] string Symbol,
    [property: JsonPropertyName("address")] string Address,
    [property: JsonPropertyName("image_url")] string ImageUrl,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("decimals")] int Decimals
    // [property: JsonPropertyName("eth_price")] decimal EthPrice,
    // [property: JsonPropertyName("usd_price")] decimal UsdPrice
);

public record Root(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("num_sales")] int NumSales,
        [property: JsonPropertyName("background_color")] object BackgroundColor,
        [property: JsonPropertyName("image_url")] string ImageUrl,
        [property: JsonPropertyName("image_preview_url")] string ImagePreviewUrl,
        [property: JsonPropertyName("image_thumbnail_url")] string ImageThumbnailUrl,
        [property: JsonPropertyName("image_original_url")] object ImageOriginalUrl,
        [property: JsonPropertyName("animation_url")] object AnimationUrl,
        [property: JsonPropertyName("animation_original_url")] object AnimationOriginalUrl,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("external_link")] string ExternalLink,
        [property: JsonPropertyName("asset_contract")] AssetContract AssetContract,
        [property: JsonPropertyName("permalink")] string Permalink,
        [property: JsonPropertyName("collection")] Collection Collection,
        [property: JsonPropertyName("decimals")] object Decimals,
        [property: JsonPropertyName("token_metadata")] object TokenMetadata,
        [property: JsonPropertyName("is_nsfw")] bool IsNsfw,
        [property: JsonPropertyName("owner")] Owner Owner,
        [property: JsonPropertyName("seaport_sell_orders")] object SeaportSellOrders,
        [property: JsonPropertyName("creator")] Creator Creator,
        [property: JsonPropertyName("traits")] IReadOnlyList<Trait> Traits,
        [property: JsonPropertyName("last_sale")] LastSale LastSale,
        [property: JsonPropertyName("top_bid")] object TopBid,
        [property: JsonPropertyName("listing_date")] object ListingDate,
        [property: JsonPropertyName("is_presale")] bool IsPresale,
        [property: JsonPropertyName("transfer_fee")] object TransferFee,
        [property: JsonPropertyName("transfer_fee_payment_token")] object TransferFeePaymentToken,
        [property: JsonPropertyName("supports_wyvern")] bool SupportsWyvern,
        [property: JsonPropertyName("rarity_data")] object RarityData,
        [property: JsonPropertyName("related_assets")] IReadOnlyList<object> RelatedAssets,
        [property: JsonPropertyName("orders")] object Orders,
        [property: JsonPropertyName("auctions")] IReadOnlyList<object> Auctions,
        [property: JsonPropertyName("top_ownerships")] IReadOnlyList<TopOwnership> TopOwnerships,
        [property: JsonPropertyName("ownership")] object Ownership,
        [property: JsonPropertyName("highest_buyer_commitment")] object HighestBuyerCommitment,
        [property: JsonPropertyName("token_id")] string TokenId
    );

public record Stats(
    [property: JsonPropertyName("one_hour_volume")] double OneHourVolume,
    [property: JsonPropertyName("one_hour_change")] double OneHourChange,
    [property: JsonPropertyName("one_hour_sales")] double OneHourSales,
    [property: JsonPropertyName("one_hour_sales_change")] double OneHourSalesChange,
    [property: JsonPropertyName("one_hour_average_price")] double OneHourAveragePrice,
    [property: JsonPropertyName("one_hour_difference")] double OneHourDifference,
    [property: JsonPropertyName("six_hour_volume")] double SixHourVolume,
    [property: JsonPropertyName("six_hour_change")] double SixHourChange,
    [property: JsonPropertyName("six_hour_sales")] double SixHourSales,
    [property: JsonPropertyName("six_hour_sales_change")] double SixHourSalesChange,
    [property: JsonPropertyName("six_hour_average_price")] double SixHourAveragePrice,
    [property: JsonPropertyName("six_hour_difference")] double SixHourDifference,
    [property: JsonPropertyName("one_day_volume")] double OneDayVolume,
    [property: JsonPropertyName("one_day_change")] double OneDayChange,
    [property: JsonPropertyName("one_day_sales")] double OneDaySales,
    [property: JsonPropertyName("one_day_sales_change")] double OneDaySalesChange,
    [property: JsonPropertyName("one_day_average_price")] double OneDayAveragePrice,
    [property: JsonPropertyName("one_day_difference")] double OneDayDifference,
    [property: JsonPropertyName("seven_day_volume")] double SevenDayVolume,
    [property: JsonPropertyName("seven_day_change")] double SevenDayChange,
    [property: JsonPropertyName("seven_day_sales")] double SevenDaySales,
    [property: JsonPropertyName("seven_day_average_price")] double SevenDayAveragePrice,
    [property: JsonPropertyName("seven_day_difference")] double SevenDayDifference,
    [property: JsonPropertyName("thirty_day_volume")] double ThirtyDayVolume,
    [property: JsonPropertyName("thirty_day_change")] double ThirtyDayChange,
    [property: JsonPropertyName("thirty_day_sales")] double ThirtyDaySales,
    [property: JsonPropertyName("thirty_day_average_price")] double ThirtyDayAveragePrice,
    [property: JsonPropertyName("thirty_day_difference")] double ThirtyDayDifference,
    [property: JsonPropertyName("total_volume")] double TotalVolume,
    [property: JsonPropertyName("total_sales")] double TotalSales,
    [property: JsonPropertyName("total_supply")] double TotalSupply,
    [property: JsonPropertyName("count")] double Count,
    [property: JsonPropertyName("num_owners")] int NumOwners,
    [property: JsonPropertyName("average_price")] double AveragePrice,
    [property: JsonPropertyName("num_reports")] int NumReports,
    [property: JsonPropertyName("market_cap")] double MarketCap,
    [property: JsonPropertyName("floor_price")] int FloorPrice
);

public record TopOwnership(
    [property: JsonPropertyName("owner")] Owner Owner,
    [property: JsonPropertyName("quantity")] string Quantity,
    [property: JsonPropertyName("created_date")] DateTime CreatedDate
);

public record Trait(
    [property: JsonPropertyName("trait_type")] string TraitType,
    [property: JsonPropertyName("value")] string Value,
    [property: JsonPropertyName("display_type")] object DisplayType,
    [property: JsonPropertyName("max_value")] object MaxValue,
    [property: JsonPropertyName("trait_count")] int TraitCount,
    [property: JsonPropertyName("order")] object Order
);

public record User(
    [property: JsonPropertyName("username")] string Username
);