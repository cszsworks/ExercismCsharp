using System.Text.RegularExpressions;

public class LogParser
{
    #region helper
    public static (int startIndex, int length)? FindMatchIndexLength(string input, string pattern)
    {
        Match match = Regex.Match(input, pattern);
        if (match.Success)
        {
            return (match.Index, match.Length);
        }
        else return null;
    }

    public static string? CutToMatchIndex(string? input, string pattern)
    {
        if (FindMatchIndexLength(input, pattern) != null)
        {
            int startIndex = FindMatchIndexLength(input, pattern).Value.startIndex;
            int length = FindMatchIndexLength(input, pattern).Value.length;
            return input.Substring(0, startIndex).Trim();

        }
        return null;

    }

    public static string? RemoveToMatchIndex(string input, string pattern)
    {
        if (FindMatchIndexLength(input, pattern) != null)
        {
            int startIndex = FindMatchIndexLength(input, pattern).Value.startIndex;
            int length = FindMatchIndexLength(input, pattern).Value.length;
            return input.Substring(startIndex+length).Trim();

        }
        return null;

    }
        
    #endregion helper
    
    public bool IsValidLine(string text)
    {
        string patternRegex = @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
        return Regex.IsMatch(text,patternRegex);
    }

    public string[] SplitLogLine(string text)
    {
        List<string> wordList = new List<string>();
        string szoveg = text;
        string pattern = @"<[*^=-]+>";
        while (CutToMatchIndex(szoveg, pattern) != null)
        {
            wordList.Add(CutToMatchIndex(szoveg, pattern));
            szoveg = RemoveToMatchIndex(szoveg, pattern);
        }
        wordList.Add(szoveg);  //adding what's left over
        return wordList.ToArray();
    }

    public int CountQuotedPasswords(string lines)
    {
         int pwCount = 0;
        
        using (StringReader reader = new StringReader(lines))
        {
            string pattern = "\".*(?i)password.*\"";
            string? line;
            while ((line = reader.ReadLine()) != null)
            {

                if (Regex.IsMatch(line, pattern))
                {
                    Console.WriteLine($"Ebben van pass: {line}");
                    pwCount++;
                }

            }
        }
        return pwCount;
    }

   public string RemoveEndOfLineText(string line)
    {
        return Regex.Replace(line, @"end-of-line\d+", "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
   {
    List<string> result = new List<string>();
    foreach (var line in lines)
    {
        // Only match "password" followed by at least one word character
        Match match = Regex.Match(line, @"\b(password\w+)", RegexOptions.IgnoreCase);
        if (match.Success)
        {
            result.Add($"{match.Value}: {line}");
        }
        else
        {
            result.Add($"--------: {line}");
        }
    }
    return result.ToArray();
}
}
