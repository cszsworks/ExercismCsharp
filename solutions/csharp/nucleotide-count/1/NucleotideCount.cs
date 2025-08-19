public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> dnaCount = new Dictionary<char, int>
        {
            { 'A', 0 },
            { 'C', 0 },
            { 'G', 0 },
            { 'T', 0 }
        };
        foreach(char c in sequence)
        {
            if(dnaCount.ContainsKey(c))
            {
                dnaCount[c]++;
            }
            else 
            {
                throw new ArgumentException();
            }
        }
        return dnaCount;
    }
}