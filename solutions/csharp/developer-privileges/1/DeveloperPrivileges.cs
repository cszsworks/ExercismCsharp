public class Authenticator
{
    public Identity Admin { get; }
    public IDictionary<string, Identity> Developers { get; }
    public Authenticator()
    {
        FacialFeatures adminFace = new FacialFeatures{EyeColor = "green",PhiltrumWidth = 0.9m};
        List<string> nameAndAddress = new List<string>{"Chanakya","Mumbai","India"};
        Identity adminID = new Identity {Email = "admin@ex.ism",FacialFeatures = adminFace, NameAndAddress = nameAndAddress};
        
        FacialFeatures bertFace = new FacialFeatures{EyeColor = "blue",PhiltrumWidth = 0.8m};
        List<string> bertNameAndAddress = new List<string>{"Bertrand","Paris","France"};
        Identity bertID = new Identity {Email = "bert@ex.ism",FacialFeatures = bertFace, NameAndAddress = bertNameAndAddress};

        FacialFeatures andersFace = new FacialFeatures{EyeColor = "brown",PhiltrumWidth = 0.85m};
        List<string> andersNameAndAddress = new List<string>{"Anders","Redmond","USA"};
        Identity andersID = new Identity {Email = "anders@ex.ism",FacialFeatures = andersFace, NameAndAddress =         andersNameAndAddress};

        IDictionary<string,Identity> devDict = new Dictionary<string,Identity>{{"Bertrand",bertID},{"Anders",andersID}};
        Admin = adminID;
        Developers = devDict;
    }
    
    // TODO: Implement the Authenticator.Developers property

}

//**** please do not modify the FacialFeatures class ****
public class FacialFeatures
{
    public required string EyeColor { get; set; }
    public required decimal PhiltrumWidth { get; set; }
}

//**** please do not modify the Identity class ****
public class Identity
{
    public required string Email { get; set; }
    public required FacialFeatures FacialFeatures { get; set; }
    public required IList<string> NameAndAddress { get; set; }
}
