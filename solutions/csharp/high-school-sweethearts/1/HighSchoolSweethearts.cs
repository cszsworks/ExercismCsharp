public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        return $"{studentA,29} ♡ {studentB,-29}";
    }

public static string DisplayBanner(string studentA, string studentB)
{
    studentA = studentA.TrimEnd();
    studentB = studentB.TrimEnd();

    return $@"     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {studentA.PadRight(5)}  +  {studentB.PadRight(5)}     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";
}




public static string DisplayGermanExchangeStudents(string studentA, string studentB, DateTime start, float hours)
{
    string formattedDate = start.ToString("dd.MM.yyyy");
    string formattedHours = hours.ToString("N2", new System.Globalization.CultureInfo("de-DE"));
    return $"{studentA} and {studentB} have been dating since {formattedDate} - that's {formattedHours} hours";
}

}
