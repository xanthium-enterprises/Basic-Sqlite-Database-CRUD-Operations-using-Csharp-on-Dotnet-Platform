
// Basic Sqlite Database Access using C# on .NET Platform  

// Create a table in SQLite Database
// Populate the table with some data
// display the parameters passed on to the SQL query 

// (c) www.xanthium.in 2024


using System.Data.SQLite;

namespace SqliteDatabaseAccess
{
    class MySqliteDBOps
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
            
            SQLiteCommand CreateTableCommand = new SQLiteCommand(SQLQueryCreateTable, MyConnection); //create a command object to create a table

            MyConnection.Open(); //open a connection to the database 

            //Create a table if it does not exist
            var RowsChanged = CreateTableCommand.ExecuteNonQuery();           // Execute Create the Table SQL query
            Console.WriteLine($"No of Rows Changed = {RowsChanged}");

           
            // Insert some data into the table
            string  SQLQueryInsertData = "INSERT INTO Customers (Name,Age,DateOfBirth,Email,Price) VALUES (@NameParam,@AgeParam,@DateOfBirth,@Email,@Price)";

            SQLiteCommand InsertDataCommand = new SQLiteCommand( SQLQueryInsertData, MyConnection); //create a SQLite Command object to insert data 
            InsertDataCommand.Parameters.AddWithValue("@NameParam", "Johnny Dave");
            InsertDataCommand.Parameters.AddWithValue("@AgeParam", 60);
            InsertDataCommand.Parameters.AddWithValue("@DateOfBirth", "1984-04-01"); //Sqlite Supports ISO 8601 date format YYYY-MM-DD
            InsertDataCommand.Parameters.AddWithValue("@Email", "johnnydoe@email.com");
            InsertDataCommand.Parameters.AddWithValue("@Price", 25324.68);

            //Debugging Purpose only

            //Console.WriteLine(InsertDataCommand.CommandText);//Shows the SQL query inside MyCommand
            Console.WriteLine(InsertDataCommand.Parameters["@NameParam"].Value);//Shows the value inside the parameter
            Console.WriteLine(InsertDataCommand.Parameters["@AgeParam"].Value);//Shows the value inside the parameter
            Console.WriteLine(InsertDataCommand.Parameters["@DateOfBirth"].Value);//Shows the value inside the parameter
            Console.WriteLine(InsertDataCommand.Parameters["@Email"].Value);//Shows the value inside the parameter
            Console.WriteLine(InsertDataCommand.Parameters["@Price"].Value);//Shows the value inside the parameter

            //using a foreach loop
            
            foreach (SQLiteParameter parameter in InsertDataCommand.Parameters)
            {
                Console.WriteLine($"{parameter.ParameterName}: {parameter.Value}");
            }
            
            RowsChanged = InsertDataCommand.ExecuteNonQuery();
            //Console.WriteLine($"No of Rows Changed = {RowsChanged}");
           

            MyConnection.Close();//Close the connection with database 


        }//End of Main()
    }//End of Class
}//End of namespace