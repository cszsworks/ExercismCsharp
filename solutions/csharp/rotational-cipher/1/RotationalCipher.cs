public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        char[] newText = new char[text.Length];
        for(int i = 0; i < text.Length; i++) 
        {
            char currentChar = text[i];
            int charValue;
            if(currentChar >= 'a' && currentChar <= 'z')
            {
                charValue = currentChar-'a';
                Console.WriteLine($"asci value : {charValue}");
                currentChar = (char)((charValue+shiftKey)%26);
                Console.WriteLine($"shifted asci value : {(int)currentChar}");
                newText[i] = (char)((int)currentChar+(int)'a');
                continue;
            }
            if(currentChar >= 'A' && currentChar <= 'Z')
            {
                charValue = currentChar-'A';
                Console.WriteLine($"asci value : {charValue}");
                currentChar = (char)((charValue+shiftKey)%26);
                Console.WriteLine($"shifted asci value : {(int)currentChar}");
                newText[i] = (char)((int)currentChar+(int)'A');
                continue;
            }
        else
        {
            newText[i] = currentChar;
        }
        }
        return new string(newText);
    }
}