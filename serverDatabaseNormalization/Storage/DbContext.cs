using System.Data.SqlClient;

namespace serverDatabaseNormalization.Storage;

public class DbContext 
{
    public readonly SqlConnection connection =
        new SqlConnection("server=localhost; database=DbNormalization; user id=sa; password=SqlSql123");
    
    public DbContext()
    {
        try
        {
            connection.Open();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            connection.Close();
        }
    }
}
