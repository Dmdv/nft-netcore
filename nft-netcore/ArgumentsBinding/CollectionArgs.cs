// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

using System.ComponentModel.DataAnnotations;

namespace Nft.ArgumentsBinding;

public record CollectionArgs
{
    [Required]
    public string Address { get; set; } = null!;
    public OrderDirection? OrderDirection { get; set; }
    public int? Limit { get; set; } = 10;
    public string? Cursor { get; set; }
}