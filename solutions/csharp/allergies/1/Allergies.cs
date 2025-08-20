public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}



public class Allergies
{
    int mask;
    public List<Allergen> allergyList;
    public Allergies(int mask)
    {
        this.mask = mask;
        allergyList = AllergyReader(mask);
    }

    public List<Allergen> AllergyReader(int allergyNum)
    {
        while (allergyNum >= Math.Pow(2, 8))
        {
            Console.WriteLine($"{allergyNum} too large, cut");
            for (int i = 15; i > 6; i--)
            {
                if (allergyNum / Math.Pow(2, i) >= 1)
                {
                    Console.WriteLine($"{allergyNum} cut by {(int)Math.Pow(2, i)} -vel");
                    allergyNum = allergyNum - (int)Math.Pow(2, i);
                    break;
                }
            }
        }
        List<Allergen> allergyList = new List<Allergen>();
        for (int i = 7; i >= 0; i--)
        {
            if (allergyNum / Math.Pow(2, i) >= 1)
            {
                allergyList.Add((Allergen)i);
                allergyNum = allergyNum - (int)Math.Pow(2, i);
            }
        }
        return allergyList;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        foreach (Allergen al in allergyList)
        {
            if (al == allergen)
            {
                return true;
            }
        }
        return false;
    }

    public Allergen[] List()
    {
        return allergyList.ToArray().Reverse().ToArray();
    }
}