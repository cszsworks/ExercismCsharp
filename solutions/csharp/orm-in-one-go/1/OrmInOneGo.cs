public class Orm
{
    private Database database;

    
    public Orm(Database database)
    {
        this.database = database;
    }


    public void Write(string data)
    {
            using(database) 
    {
        try 
        {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
        }
        catch (Exception e)
        {
            throw;
        }
    }
    }

    public bool WriteSafely(string data)
    {
        bool success = false;
        try 
        {
            Write(data);
            success = true;
            return success;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    return success;
            
    }
}
