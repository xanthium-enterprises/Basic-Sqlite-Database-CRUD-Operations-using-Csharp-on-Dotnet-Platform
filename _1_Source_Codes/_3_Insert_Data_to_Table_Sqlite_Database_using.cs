
// Basic Sqlite Database Access using C# on .NET Platform  

// Create a table in SQLite Database
// Populate the table with some data

// (c) www.xanthium.in 2024


using System.Data.SQLite;

namespace SqliteDatabaseAccess
{
    class MySqliteDBInsertDataUsing
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

            using (SQLiteConnection MyConnection = new SQLiteConnection(ConnectionString)) //Create a SqliteConnection object called Connection
            {
                MyConnection.Open(); //open a connection to the database 

                using (SQLiteCommand CreateTableCommand = new SQLiteCommand(SQLQueryCreateTable, MyConnection))
                {
                   CreateTableCommand.ExecuteNonQuery();           // Execute,Create the Table SQL query
                    
                }

                // Insert some data into the table
                string SQLQueryInsertData = "INSERT INTO Customers (Name,Age,DateOfBirth,Email,Price) VALUES (@NameParam,@AgeParam,@DateOfBirth,@Email,@Price)";

                using (SQLiteCommand InsertDataCommand = new SQLiteCommand(SQLQueryInsertData, MyConnection))
                {
                    InsertDataCommand.Parameters.AddWithValue("@NameParam", "Johnny Austin Dave");
                    InsertDataCommand.Parameters.AddWithValue("@AgeParam", 68);
                    InsertDataCommand.Parameters.AddWithValue("@DateOfBirth", "1989-04-01"); //Sqlite Supports ISO 8601 date format YYYY-MM-DD
                    InsertDataCommand.Parameters.AddWithValue("@Email", "johastinnydoe@email.com");
                    InsertDataCommand.Parameters.AddWithValue("@Price", 324.68);

                    
                    var RowsChanged = InsertDataCommand.ExecuteNonQuery();
                    Console.WriteLine($"No of Rows Changed = {RowsChanged}");


                }

            }

        }//End of Main()
    }//End of Class
}//End of namespace