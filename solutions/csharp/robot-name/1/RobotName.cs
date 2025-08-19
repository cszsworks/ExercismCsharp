public class Robot
{
    private static HashSet<string> usedNames = new HashSet<string>();
    private string name;
    
    public Robot() 
    {
        this.name = GenerateRandomName();
    }
    
    public string Name
    {
        get => name;
        
    }
    private static Random rng = new Random();
    
    private string GenerateRandomName() 
    {
        char[] chars = new char[5];
        string s;
        do
        {
        for(int i = 0; i < 5; i++)
        {
            if(i<2)
            {
                chars[i] = (char)rng.Next('A', 'Z' + 1);
            }
            else 
            {
                chars[i] = (char)rng.Next('0','9'+1);
            }

        }
            s = new string(chars);
        }
    while (!usedNames.Add(s));     
    return s;    
    }

    public void Reset()
    {
        this.name = GenerateRandomName();
    }
}