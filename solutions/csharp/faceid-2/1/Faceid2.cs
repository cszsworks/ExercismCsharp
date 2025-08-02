public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public FacialFeatures(FacialFeatures copyFacial) 
    {
        EyeColor = copyFacial.EyeColor;
        PhiltrumWidth = copyFacial.PhiltrumWidth;
    }

    
    public override bool Equals(Object obj) {
        if (ReferenceEquals(this, obj)) return true;
        
        if (obj is null) return false;
        
        if (obj is FacialFeatures otherFace)
        {
            return (otherFace.EyeColor == this.EyeColor && otherFace.PhiltrumWidth == this.PhiltrumWidth);
        }
        return false; 
    }

        public override int GetHashCode()
        {
        return HashCode.Combine(EyeColor,PhiltrumWidth);
        }       
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public Identity(Identity copyID)
    {
        Email = copyID.Email;
        FacialFeatures = new FacialFeatures(copyID.FacialFeatures);
    }
    public override bool Equals(Object obj) {
        if(ReferenceEquals(this,obj)) return true;
        if(obj is null) return false;

        if(obj is Identity otherID) 
        {
            return (Email == otherID.Email && FacialFeatures.Equals(otherID.FacialFeatures));
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email,FacialFeatures);
    }
}

public class Authenticator
{
    List<Identity> identityContainer = new List<Identity>();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return (faceA.Equals(faceB) && faceA.GetHashCode() == faceB.GetHashCode());
    }

    public bool IsAdmin(Identity identity)
    {
        FacialFeatures adminFace = new FacialFeatures("green",0.9m);
        Identity adminID = new Identity("admin@exerc.ism",adminFace);
        return identity.Equals(adminID);
    }

    public bool Register(Identity identity)
    {
        if(identityContainer.Contains(identity))return false;
        Identity newID = new Identity(identity);
        this.identityContainer.Add(newID);
        return true;
    }

    public bool IsRegistered(Identity identity)
    {
        foreach (Identity checkID in this.identityContainer)
        {
            if(checkID.Equals(identity))return true;
        }
        return false;
    }

    public static bool AreSameObject(Identity identityA, Identity identityB) => ReferenceEquals(identityA,identityB);

}
