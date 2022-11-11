// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
#pragma warning disable CS8618

using System.Text.Json.Serialization;

namespace Nft.Models.Blockdaemon.Source.Assets;

public class Datum
{
    [JsonPropertyName("id")]
    public string BlockdaemonId { get; set; }

    [JsonPropertyName("token_id")]
    public string TokenId { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("contract_address")]
    public string ContractAddress { get; set; }

    [JsonPropertyName("wallets")]
    public List<string> Wallets { get; set; }

    [JsonPropertyName("burned")]
    public bool Burned { get; set; }
}

public class Meta
{
    [JsonPropertyName("paging")]
    public Paging Paging { get; set; }
}

public class Paging
{
    [JsonPropertyName("next_page_token")]
    public string NextPageToken { get; set; }
}

public class AssetRoot
{
    [JsonPropertyName("data")]
    public List<Datum> Data { get; set; }

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }
}

