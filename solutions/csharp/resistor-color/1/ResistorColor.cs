public static class ResistorColor
{
    public static int ColorCode(string color)
    {
        int index = Array.IndexOf(Colors(),color);
        return index;
    }

    public static string[] Colors()
    {
        string [] colors = {"black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"};
        return colors;
    }
}