public static class Bob
{
    public static string Response(string statement)
    {
        string trimmed = statement.TrimEnd();

        bool isShouting = statement.Any(char.IsLetter) && statement.All(c => !char.IsLetter(c) || char.IsUpper(c));
        bool isQuestion = trimmed.EndsWith("?");
        bool isSilence = string.IsNullOrWhiteSpace(statement);

        if (isQuestion && isShouting) return "Calm down, I know what I'm doing!";
        if (isShouting) return "Whoa, chill out!";
        if (isQuestion) return "Sure.";
        if (isSilence) return "Fine. Be that way!";

        return "Whatever.";
    }
}
