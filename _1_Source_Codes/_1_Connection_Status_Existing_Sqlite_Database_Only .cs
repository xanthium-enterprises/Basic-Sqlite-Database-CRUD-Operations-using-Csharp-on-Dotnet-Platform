
//Basic Sqlite Database Access using C# on .NET Platform  
// Open a connection with a non existing Sqlite DB without creating a new database

// if database do not exists on disk,the program will create an exception instead of creating a new database
// use the connection string = "Data Source = SqliteDatabase.db;Version = 3;FailIfMissing = True"

// default sqlite behaviour is changed by using the key value pair "FailIfMissing = True"

// (c) www.xanthium.in 2024


using System.Data.SQLite;

namespace SqliteDatabaseAccess
{
    class MySqliteDBConnect
    {
        public static void Main()
        {
            //"FailIfMissing = True",
            //if SqliteDatabase.db do not exists on disk,Generate an exception instead of creating a new database file

            String ConnectionString = "Data Source = SqliteDatabase.db;Version = 3;FailIfMissing = True"; //"FailIfMissing = True",

            try
            {
                using (SQLiteConnection MyConnection = new SQLiteConnection(ConnectionString)) //Create a SqliteConnection object called Connection
                {
                    MyConnection.Open(); //open a connection to the database 
                   
                    Console.WriteLine(MyConnection.State);

                }
            }

            catch(Exception Ex )
            {
               // Console.WriteLine(Ex.ToString());
                Console.WriteLine(Ex.Message);
            }
           




        }//End of Main()
    }//End of Class
}//End of namespace