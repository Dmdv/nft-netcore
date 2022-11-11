// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Nft.ArgumentsBinding;

public record SearchArgs
{
    public string? Address { get; set; }
    public SymbolFilter? Symbol { get; set; }
    public NameFilter? Name { get; set; }
    public int? First { get; set; }
    public string? After { get; set; }
}

public record SymbolFilter(string Value, StringEqualityInput Op);

public record NameFilter(string Value, StringEqualityInput Op);