public class SpaceAge
{
    int secondsAge;
    public SpaceAge(int seconds)
    {
        secondsAge = seconds;
    }

    public double OnEarth() => secondsAge / 31_557_600.0;
  
    public double OnMercury() => OnEarth() * (1 / 0.2408467);

    public double OnVenus() => OnEarth() * (1 / 0.61519726);

    public double OnMars() => OnEarth() * (1 / 1.8808158);

    public double OnJupiter() => OnEarth() * (1 / 11.862615);

    public double OnSaturn() => OnEarth() * (1 / 29.447498);

    public double OnUranus() => OnEarth() * (1 / 84.016846);

    public double OnNeptune() => OnEarth() * (1 / 164.79132);
}