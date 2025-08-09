public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }

    private Speed currentSpeed;
    
    private TelemetrySystem telemetry;
    
    public RemoteControlCar()
    {
        this.telemetry = new TelemetrySystem(this);
        CurrentSponsor = "";
    }

    public TelemetrySystem Telemetry => telemetry;
    
    public class TelemetrySystem
    {
        
    private RemoteControlCar parent;
        
    public TelemetrySystem(RemoteControlCar parent) {
        this.parent = parent;
    }
    public void Calibrate()
    {

    }

    public bool SelfTest()
    {
        return true;
    }

    public void ShowSponsor(string sponsorName)
    {
        parent.SetSponsor(sponsorName);
    }

    public void SetSpeed(decimal amount, string unitsString)
    {
        SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
        if (unitsString == "cps")
        {
            speedUnits = SpeedUnits.CentimetersPerSecond;
        }

        parent.SetSpeed(new Speed(amount, speedUnits));
    }
        
    }


    public string GetSpeed()
    {
        return currentSpeed.ToString();
    }

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;

    }

    private void SetSpeed(Speed speed)
    {
        currentSpeed = speed;
    }
}

public enum SpeedUnits
{
    MetersPerSecond,
    CentimetersPerSecond
}

public struct Speed
{
    public decimal Amount { get; }
    public SpeedUnits SpeedUnits { get; }

    public Speed(decimal amount, SpeedUnits speedUnits)
    {
        Amount = amount;
        SpeedUnits = speedUnits;
    }

    public override string ToString()
    {
        string unitsString = "meters per second";
        if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
        {
            unitsString = "centimeters per second";
        }

        return Amount + " " + unitsString;
    }
}
