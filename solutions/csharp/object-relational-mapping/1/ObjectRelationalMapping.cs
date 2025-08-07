public class Orm : IDisposable
{
    private Database database;


    public void Dispose() 
    {
        this.database.Dispose();
    }
    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        try 
        {
            database.BeginTransaction();         
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
            database.Dispose();
            
        }
    }

    public void Write(string data)
    {
        try
        {
            database.Write(data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            database.Dispose();
        }
    }

    public void Commit()
    {
        try 
        {
            database.EndTransaction();
        }
        catch (Exception e)
        {
            database.Dispose();
        }
    }

    
}
