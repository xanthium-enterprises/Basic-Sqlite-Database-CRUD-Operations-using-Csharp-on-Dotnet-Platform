

// Basic Sqlite Database Access using C# on .NET Platform  
// Delete a Record from the Sqlite Databse at id =3
// Make sure that Database is populated with some data before running this code
// (c) www.xanthium.in 2024


using System.Data.SQLite;

namespace SqliteDatabaseAccess
{
    class UpdateSQLiteDatabase
    {
        public static void Main()
        {
            String ConnectionString = @"Data Source=MySqliteDatabase.db";           // MySqliteDatabase.db will be in "\bin\Debug\net8.0\MySqliteDatabase.db"
            
           
            using (SQLiteConnection MyConnection = new SQLiteConnection(ConnectionString)) // Create a SqliteConnection object called Connection
            {
                MyConnection.Open();              //open a connection to sqlite 3 database

               
                String SQLQueryUpdate = "DELETE FROM Customers WHERE Id = @id";

                using (SQLiteCommand UpdateCommand = new SQLiteCommand(SQLQueryUpdate, MyConnection)) //Create a new command object using sql query and connection object
                {
                    UpdateCommand.Parameters.AddWithValue("@id", 33);
                    
                    UpdateCommand.ExecuteNonQuery();

                }

              
            }











        }//End of Main()
    }//End of Class
}//End of namespace