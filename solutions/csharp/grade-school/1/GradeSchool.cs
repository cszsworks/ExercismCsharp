public class GradeSchool
{
    Dictionary<string, int> studentDictionary;
    public GradeSchool() 
    {
        studentDictionary = new Dictionary<string, int>();
    }

    public bool Add(string student, int grade)
    {
        try 
        {
            studentDictionary.Add(student,grade);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public IEnumerable<string> Roster()
    {
         var sortedDict = from entry in studentDictionary orderby entry.Value,entry.Key ascending select entry.Key;
        return sortedDict;
    }

    public IEnumerable<string> Grade(int grade)
    {
        List<string> namesInGrade = new List<string>();
        foreach(var learner in studentDictionary)
        {
            if(learner.Value == grade)
            {
                namesInGrade.Add(learner.Key);   
            }
        }
        namesInGrade.Sort();
        return namesInGrade;
    }

}