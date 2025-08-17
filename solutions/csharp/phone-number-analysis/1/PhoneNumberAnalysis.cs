public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        bool isNewYork = ("212" == phoneNumber.Substring(0,3));
        bool isFake = ("555" == phoneNumber.Substring(4,3));
        string localNum = phoneNumber.Substring(phoneNumber.Length-4);
        return (isNewYork,isFake,localNum);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.Item2;
    }
}
