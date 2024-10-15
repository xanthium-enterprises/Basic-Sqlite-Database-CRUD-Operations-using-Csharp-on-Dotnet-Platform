

// Basic Sqlite Database Access using C# on .NET Platform  
// Read the data from a sqlite 3 database and then prints them onto the console
// Make sure that Database is populated with some data before running this code
// (c) www.xanthium.in 2024


using System.Data.SQLite;

namespace SqliteDatabaseAccess
{
    class ReadSqliteDB
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
                            /*
                            int Id      = MyDataReader.GetInt32(0);  // Index 0 for the first column ,Id
                            string Name = MyDataReader.GetString(1); // Index 1 for the second column, Name
                            int Age     = MyDataReader.GetInt32(2);
                            string DOB  = MyDataReader.GetString(3);
                            string Email= MyDataReader.GetString(4);
                            float Price = MyDataReader.GetFloat(5);
                            */

                            int Id       = Convert.ToInt32(MyDataReader["Id"]);   // Database cell access by using column name
                            string Name  = MyDataReader["name"].ToString();
                            int Age      = Convert.ToInt32(MyDataReader["Age"]);
                            string DOB   = MyDataReader["DateofBirth"].ToString();
                            string Email = MyDataReader["email"].ToString();
                            Double Price = Convert.ToDouble(MyDataReader["price"]);

                            Console.WriteLine($"{Id} {Name} {Age} {DOB} {Email} {Price}");
                        }
                    }
                }

                    
            }



            

           

            



        }//End of Main()
    }//End of Class
}//End of namespace