

// Basic Sqlite Database Access using C# on .NET Platform  
// Able to read null values inside the sqlite 3 databases
// Read the data from a sqlite 3 database and then prints them onto the console
// Make sure that Database is populated with some data before running this code
// (c) www.xanthium.in 2024


using System.Data.SQLite;

namespace SqliteDatabaseAccess
{
    class ReadSqliteDB_NullValue
    {
        public static void Main()
        {
            String ConnectionString = @"Data Source=MySqliteDatabase.db";           // MySqliteDatabase.db will be in "\bin\Debug\net8.0\MySqliteDatabase.db"
            
            String SQLQuerySelectAll = "SELECT * FROM Customers";
            
            using (SQLiteConnection MyConnection = new SQLiteConnection(ConnectionString)) // Create a SqliteConnection object called Connection
            {
                MyConnection.Open();              //open a connection to sqlite 3 database

                // Make sure that Database is populated with some data before running this code

                using (SQLiteCommand MyCommand = new SQLiteCommand(SQLQuerySelectAll, MyConnection)) //Create a new command object using sql query and connection object
                {
                    using (SQLiteDataReader MyDataReader = MyCommand.ExecuteReader())
                    {
                        while(MyDataReader.Read())
                        {
                            //using ternary operator to check for null
                            //condition ? value_if_true : value_if_false;

                            int Id       = Convert.ToInt32(MyDataReader["Id"]);   // Database cell access by using column name

                            string Name  = MyDataReader["name"] == DBNull.Value ? "NULL" : MyDataReader["name"].ToString();

                            int Age      = MyDataReader["Age"] == DBNull.Value ? -1 : Convert.ToInt32(MyDataReader["Age"]);
                            
                            string DOB   = MyDataReader["DateofBirth"] == DBNull.Value ? "NULL" : MyDataReader["DateofBirth"].ToString();

                            string Email = MyDataReader["Email"] == DBNull.Value ? "NULL" : MyDataReader["Email"].ToString();

                            double Price = MyDataReader["Price"] == DBNull.Value ? -1 : Convert.ToInt32(MyDataReader["Price"]);

                            Console.WriteLine($"{Id} {Name} {Age} {DOB} {Email} {Price}");
                        }
                    }
                }

                    
            }



            

           

            



        }//End of Main()
    }//End of Class
}//End of namespace