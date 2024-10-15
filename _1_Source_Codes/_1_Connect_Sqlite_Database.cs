
//Basic Sqlite Database Access using C# on .NET Platform  
//Open a  connection with Sqlite DB
//
// (c) www.xanthium.in 2024


using System.Data.SQLite;

namespace SqliteDatabaseAccess
{
    class MySqliteDBConnect
    {
        public static void Main()
        {
            String ConnectionString = @"Data Source=./MySqliteDatabase.db"; // MySqliteDatabase.db will be in "\bin\Debug\net8.0\MySqliteDatabase.db"

            SQLiteConnection MyConnection = new SQLiteConnection(ConnectionString); //Create a SqliteConnection object called Connection

            MyConnection.Open(); //open a connection to the database 

            MyConnection.Close();//Close the connection with database 


        }//End of Main()
    }//End of Class
}//End of namespace