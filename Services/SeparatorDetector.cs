using PeopleLibraryApp.Interfaces;
using System.Text.RegularExpressions;

namespace PeopleLibraryApp.Services;

public class SeparatorDetector : ISeparatorDetector
{
    public string DetectSeparator(string fileContent)
    {
        var matches = Regex.Matches(fileContent, @"(\n[*%\-+=#]{3,}\n)+");

        if (matches.Count > 0)
        {
            return matches[0].Value;
        }

        return "\n------------------------------\n"; 
    }
}
