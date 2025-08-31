public class Clock : IEquatable<Clock>
{
    private int _hours;
    private int _minutes;

    public bool Equals(Clock other)
    {
        if (other is null)
        {
            return false;
        }
        return _hours == other._hours && _minutes == other._minutes;
    }

    public bool Equals(object obj)
    {
        return Equals(obj as Clock);
    }
    // override object.GetHashCode
    public override int GetHashCode()
    {

        return HashCode.Combine(_hours, _minutes);
    }

    public Clock(int hours, int minutes)
    {
        int totalMinutes = hours * 60 + minutes;
        totalMinutes = ((totalMinutes % 1440) + 1440) % 1440;
        this._hours = totalMinutes / 60;
        this._minutes = totalMinutes - (this._hours * 60);
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(this._hours, this._minutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(this._hours, this._minutes - minutesToSubtract);
    }
    
     public override string ToString()
    {
        string hoursText = this._hours.ToString("D2");
        string minutesText = this._minutes.ToString("D2");
        return $"{hoursText}:{minutesText}";
    }
}
