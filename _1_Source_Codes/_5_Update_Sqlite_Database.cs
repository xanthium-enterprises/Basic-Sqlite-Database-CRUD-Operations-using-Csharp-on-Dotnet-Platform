

// Basic Sqlite Database Access using C# on .NET Platform  

// Update Name and Age Fields for Id =3

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
            
            String SQLQuery = "SELECT id,Name,Age FROM Customers WHERE id = 3";
            
            

            String NameToBeUpdated = "";
            int AgeToBeUpdated = 0;


            using (SQLiteConnection MyConnection = new SQLiteConnection(ConnectionString)) // Create a SqliteConnection object called Connection
            {
                MyConnection.Open();              //open a connection to sqlite 3 database

                // Make sure that Database is populated with some data before running this code

                using (SQLiteCommand QueryCommand = new SQLiteCommand(SQLQuery, MyConnection)) //Create a new command object using sql query and connection object
                {
                    using (SQLiteDataReader MyDataReader = QueryCommand.ExecuteReader())
                    {
                        while (MyDataReader.Read())
                        {
                            int id = MyDataReader.GetInt32(0);
                            string name = MyDataReader.GetString(1);
                            int age = MyDataReader.GetInt32(2);

                            Console.WriteLine($"Before Update - > {id} {name} {age}");

                        }
                    }
                }
                Console.WriteLine("\nEnter the name to be updated - ");
                NameToBeUpdated = Console.ReadLine();

                Console.WriteLine("Enter the Age  to be updated - ");
                AgeToBeUpdated  = Convert.ToInt32(Console.ReadLine()) ;

                String SQLQueryUpdate = "UPDATE Customers SET Name = @name, Age = @age WHERE Id = @id";

                using (SQLiteCommand UpdateCommand = new SQLiteCommand(SQLQueryUpdate, MyConnection)) //Create a new command object using sql query and connection object
                {
                    UpdateCommand.Parameters.AddWithValue("@name", NameToBeUpdated);
                    UpdateCommand.Parameters.AddWithValue("@age", AgeToBeUpdated);
                    UpdateCommand.Parameters.AddWithValue("@id", 3);
                    UpdateCommand.ExecuteNonQuery();

                }

                using (SQLiteCommand QueryCommand = new SQLiteCommand(SQLQuery, MyConnection)) //Create a new command object using sql query and connection object
                {
                    using (SQLiteDataReader MyDataReader = QueryCommand.ExecuteReader())
                    {
                        while (MyDataReader.Read())
                        {
                            int id = MyDataReader.GetInt32(0);
                            string name = MyDataReader.GetString(1);
                            int age = MyDataReader.GetInt32(2);

                            Console.WriteLine($"After Update - > {id} {name} {age}");

                        }
                    }
                }



            }











        }//End of Main()
    }//End of Class
}//End of namespace