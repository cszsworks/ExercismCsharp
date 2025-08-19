public static class Gigasecond
{
    public static DateTime Add(DateTime moment)
    {
        TimeSpan gigaSecond = new TimeSpan();
        gigaSecond = TimeSpan.FromSeconds(1000000000);
        return moment + gigaSecond;
    }
}