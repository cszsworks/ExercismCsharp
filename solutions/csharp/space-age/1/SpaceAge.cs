public class SpaceAge
{
    int secondsAge;
    public SpaceAge(int seconds)
    {
        secondsAge = seconds;
    }

    public double OnEarth()
    {
        return secondsAge / 31_557_600.0;
    }

    public double OnMercury()
    {
        return OnEarth() * (1 / 0.2408467);
    }

    public double OnVenus()
    {
        return OnEarth() * (1 / 0.61519726);
    }

    public double OnMars()
    {
        return OnEarth() * (1 / 1.8808158);
    }

    public double OnJupiter()
    {
        return OnEarth() * (1 / 11.862615);
    }

    public double OnSaturn()
    {
        return OnEarth() * (1 / 29.447498);
    }

    public double OnUranus()
    {
        return OnEarth() * (1 / 84.016846);
    }

    public double OnNeptune()
    {
        return OnEarth() * (1 / 164.79132);
    }
}