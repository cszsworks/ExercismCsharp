public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    double[] lengths;
    public Plot(Coord a, Coord b, Coord c, Coord d) 
    {
        lengths = new double[4]; 
        A = a;
        B = b;
        C = c;
        D = d;
        lengths[0] = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        lengths[1] = Math.Sqrt(Math.Pow(b.X - c.X, 2) + Math.Pow(b.Y - c.Y, 2));
        lengths[2] = Math.Sqrt(Math.Pow(c.X - d.X, 2) + Math.Pow(c.Y - d.Y, 2));
        lengths[3] = Math.Sqrt(Math.Pow(d.X - a.X, 2) + Math.Pow(d.Y - a.Y, 2));
        
    }
    Coord A;
    Coord B;
    Coord C;
    Coord D;
    
    public double LongestSide()
    {
        double longest = 0;
        for(int i = 0; i < 4; i++) 
        {
            if(lengths[i]>longest)
            {
                longest = lengths[i];
            }
        }
        return longest;
    }
    
    public override bool Equals(object obj)
    {
        if(obj is Plot p) 
        {
           if( p.A.X == this.A.X && p.A.Y == this.A.Y &&
            p.B.X == this.B.X && p.B.Y == this.B.Y &&
            p.C.X == this.C.X && p.C.Y == this.C.Y &&
            p.D.X == this.D.X && p.D.Y == this.D.Y ) return true;
        }
        return false;
    }
}


public class ClaimsHandler
{
    List<Plot> plotList;

    public ClaimsHandler()
    {
        this.plotList = new List<Plot>();
    }
    
    public void StakeClaim(Plot plot)
    {
        this.plotList.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        foreach(Plot p in this.plotList)
        {
            if(p.Equals(plot)) {
                return true;
            }
        }
        return false;
    }

    public bool IsLastClaim(Plot plot) =>  this.plotList[this.plotList.Count-1].Equals(plot);

    public Plot GetClaimWithLongestSide()
    {
        double longestSide = 0;
        int longestIndex = 0;
        for(int i = 0; i < plotList.Count; i++)
        {
            if(this.plotList[i].LongestSide()>longestSide)
            {
                longestSide = plotList[i].LongestSide();
                longestIndex = i;
            }
        }
        return this.plotList[longestIndex];
    }
}
