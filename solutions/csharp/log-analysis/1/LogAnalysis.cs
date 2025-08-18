using System.Text.RegularExpressions;

public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter (this string str, string delimiter)
    {
        int index = str.IndexOf(delimiter);
        if (index == -1 || index + delimiter.Length >= str.Length)
        return str;

        return str.Substring(index + delimiter.Length);
    }
    public static string SubstringBetween(this string str, string limit1, string limit2)
    {
        int startIndex = str.IndexOf(limit1)+limit1.Length;
        int endIndex = str.IndexOf(limit2);
        return str.Substring(startIndex, endIndex-startIndex);
    }

    public static string Message(this string str)
    {
        return SubstringAfter(str, "]: ");
    }

    public static string LogLevel(this string str) 
    {
        return SubstringBetween(str, "[", "]");
    }
}