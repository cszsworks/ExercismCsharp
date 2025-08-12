using System.Runtime.InteropServices;
using System.Globalization;
public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        string locationText = "";
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            locationText = location switch
            {
                Location.NewYork => "Eastern Standard Time",
                Location.London => "GMT Standard Time",
                Location.Paris => "Paris - W. Europe Standard Time",
                _ => "Unknown Timezone"   
            };
        }
        else
        {
            locationText = location switch
            {
                Location.NewYork => "America/New_York",
                Location.London => "Europe/London",
                Location.Paris => "Europe/Paris",
                _ => "Unknown Timezone"   
            };
        }
        
        DateTime inputDate = DateTime.Parse(appointmentDateDescription);
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(locationText);
        Console.WriteLine(tz);
        DateTime UTCSchedule = TimeZoneInfo.ConvertTimeToUtc(inputDate, tz);

        return UTCSchedule;


            
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        DateTime difference;
        difference =  alertLevel switch 
        {
                AlertLevel.Early => appointment-(new TimeSpan(1, 0, 0, 0)),
                AlertLevel.Standard => appointment-(new TimeSpan(0, 1, 45, 0)),
                AlertLevel.Late => appointment-(new TimeSpan(0, 0, 30, 0)),
                _ => appointment
        };
        return difference;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        int year = dt.Year;
        string locationText;
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            locationText = location switch
            {
                Location.NewYork => "Eastern Standard Time",
                Location.London => "GMT Standard Time",
                Location.Paris => "Paris - W. Europe Standard Time",
                _ => "Unknown Timezone"   
            };
        }
        else
        {
            locationText = location switch
            {
                Location.NewYork => "America/New_York",
                Location.London => "Europe/London",
                Location.Paris => "Europe/Paris",
                _ => "Unknown Timezone"   
            };
        }
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(locationText);

        bool isDst = tz.IsDaylightSavingTime(dt);
        bool dstChange = isDst;
        for(int i = 0; i < 7; i++)
        {
            DateTime upwards = dt.AddDays(i);
            DateTime downwards = dt.AddDays(i*-1);
            if(tz.IsDaylightSavingTime(upwards) != isDst || tz.IsDaylightSavingTime(downwards) != isDst) 
            {
                dstChange = !dstChange;
                break;
            }
        }
        return !(isDst == dstChange);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        CultureInfo myCulture = location switch
        {
            Location.NewYork => new CultureInfo("en-US"), // United States
            Location.London  => new CultureInfo("en-GB"), // United Kingdom
            Location.Paris   => new CultureInfo("fr-FR"), // France
            _ => CultureInfo.InvariantCulture
        };
        DateTime localDate = new DateTime();
        try 
        {
            localDate = DateTime.Parse(dtStr, myCulture);
        }
        catch (Exception e)
        {
            localDate = new DateTime(1, 1, 1, 0, 0, 0);
        }

        return localDate;
    }
}
