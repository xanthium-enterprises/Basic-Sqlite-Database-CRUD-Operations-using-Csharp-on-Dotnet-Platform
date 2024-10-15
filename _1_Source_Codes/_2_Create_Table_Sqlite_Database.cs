
// Basic Sqlite Database Access using C# on .NET Platform  
// Create a table in SQLite Database

// (c) www.xanthium.in 2024


using System.Data.SQLite;

namespace SqliteDatabaseAccess
{
    class MySqliteDBCreateTable
    {
        public static void Main()
        {
            String ConnectionString = @"Data Source=MySqliteDatabase.db"; // MySqliteDatabase.db will be in "\bin\Debug\net8.0\MySqliteDatabase.db"

            //Create a Table to Store data 
            String SQLQueryCreateTable = @"CREATE TABLE IF NOT EXISTS Customers(Id    INTEGER PRIMARY KEY, 
                                                                                Name  VARCHAR, 
                                                                                Age   INTEGER,
                                                                                DateOfBirth TEXT,
                                                                                Email VARCHAR,
                                                                                Price REAL)";

            SQLiteConnection MyConnection = new SQLiteConnection(ConnectionString); //Create a SqliteConnection object called Connection
            
            SQLiteCommand MyCommand = new SQLiteCommand(SQLQueryCreateTable, MyConnection);

            MyConnection.Open(); //open a connection to the database 

            var RowsChanged = MyCommand.ExecuteNonQuery();           // Execute Create the Table SQL query
            
            Console.WriteLine($"No of Rows Changed = {RowsChanged}");//rows changed =0,since we are creating a table

            
            
            MyConnection.Close();//Close the connection with database 


        }//End of Main()
    }//End of Class
}//End of namespace