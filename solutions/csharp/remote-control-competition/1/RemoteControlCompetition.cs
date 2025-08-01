public interface IRemoteControlCar 
{
    int DistanceTravelled {get;}
    void Drive();
}
public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }
    public int CompareTo(ProductionRemoteControlCar otherCar)
    {
        if (this.NumberOfVictories == otherCar.NumberOfVictories) return 0;
        else return this.NumberOfVictories > otherCar.NumberOfVictories ? 1 : -1; 
    }
    public void Drive()
    {
        DistanceTravelled += 10;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }
    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        List <ProductionRemoteControlCar> carList = new List<ProductionRemoteControlCar>();
        if(prc1.CompareTo(prc2)==1){
            carList.Add(prc2);
            carList.Add(prc1);
        }
        else {
            carList.Add(prc1);
            carList.Add(prc2);
        }
        return carList;
    }
}
