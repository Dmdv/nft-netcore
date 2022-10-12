using System.ComponentModel;

namespace Nft.Arguments;

public enum OrderBy
{
    [Description("AVERAGE")]
    Average,
    [Description("SALES")]
    Sales,
    [Description("VOLUME")]
    Volume,
}