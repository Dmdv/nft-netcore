using System.Text;
using System.Text.Json;

namespace Opensea.Helpers;

public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
{
    private const char Separator = '_';

    public override string ConvertName(string name)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) return string.Empty;

        ReadOnlySpan<char> spanName = name.Trim();

        var stringBuilder = new StringBuilder();
        var addCharacter = true;

        var isPreviousSpace = false;
        var isPreviousSeparator = false;
        var isCurrentSpace = false;
        var isNextLower = false;
        var isNextUpper = false;
        var isNextSpace = false;

        for (var position = 0; position < spanName.Length; position++)
        {
            if (position != 0)
            {
                isCurrentSpace = spanName[position] == 32;
                isPreviousSpace = spanName[position - 1] == 32;
                isPreviousSeparator = spanName[position - 1] == 95;

                if (position + 1 != spanName.Length)
                {
                    isNextLower = spanName[position + 1] > 96 && spanName[position + 1] < 123;
                    isNextUpper = spanName[position + 1] > 64 && spanName[position + 1] < 91;
                    isNextSpace = spanName[position + 1] == 32;
                }

                if (isCurrentSpace &&
                    (isPreviousSpace || 
                     isPreviousSeparator || 
                     isNextUpper || 
                     isNextSpace))
                {
                    addCharacter = false;
                }
                else
                {
                    var isCurrentUpper = spanName[position] > 64 && spanName[position] < 91;
                    var isPreviousLower = spanName[position - 1] > 96 && spanName[position - 1] < 123;
                    var isPreviousNumber = spanName[position - 1] > 47 && spanName[position - 1] < 58;

                    if (isCurrentUpper &&
                        (isPreviousLower || 
                         isPreviousNumber || 
                         isNextLower || 
                         isNextSpace || 
                         (isNextLower && !isPreviousSpace)))
                        stringBuilder.Append(Separator);
                    else
                    {
                        if (isCurrentSpace && 
                            !isPreviousSpace && 
                            !isNextSpace)
                        {
                            stringBuilder.Append(value: Separator);
                            addCharacter = false;
                        }
                    }
                }
            }

            switch (addCharacter)
            {
                case true:
                    stringBuilder.Append(spanName[position]);
                    break;
                default:
                    addCharacter = true;
                    break;
            }
        }

        return stringBuilder.ToString().ToLower();
    }
}