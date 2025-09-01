using System.IO.Pipes;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
{
    string availableChars = "{}()[]";
    string signsOnly = new string(input.Where(c => availableChars.Contains(c)).ToArray());
    List<char> tempList = new List<char>();

    foreach (char c in signsOnly)
    {
        if ("{([".Contains(c))
        {
            // opening bracket → add to tempList
            tempList.Add(c);
        }
        else
        {
            // closing bracket → must match last opening
            if (tempList.Count == 0) return false;
            char last = tempList[tempList.Count - 1];
            if ((c == '}' && last != '{') ||
                (c == ')' && last != '(') ||
                (c == ']' && last != '['))
            {
                return false;
            }
            tempList.RemoveAt(tempList.Count - 1); // pop last
        }
    }

    return tempList.Count == 0; // true if all matched
}

}
