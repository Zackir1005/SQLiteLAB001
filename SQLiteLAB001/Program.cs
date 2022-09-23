using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SQLiteLAB
{
    internal class Program
    {
        //static void SQL_init(string ConnectParametr, string SQLCommand)
        //{
        //    SQLiteConnection _sqlite = new SQLiteConnection(ConnectParametr);
        //    Console.WriteLine("new connection sets setup");
        //    _sqlite.Open();
        //    Console.WriteLine("new connection open");
        //    SQLiteCommand cmd = _sqlite.CreateCommand();
        //    Console.WriteLine("CreateCommand");
        //    cmd.CommandText = (SQLCommand);
        //    cmd.ExecuteReader();
        //    _sqlite.Close();
        //    Console.WriteLine("new connection close");
        //}
        //static void SQL_insert(string ConnectParametr, string SQLCommand)
        //{
        //    SQLiteConnection _sqlite = new SQLiteConnection(ConnectParametr);
        //    Console.WriteLine("new connection sets setup");
        //    _sqlite.Open();
        //    Console.WriteLine("new connection open");
        //    SQLiteCommand cmd = _sqlite.CreateCommand();
        //    Console.WriteLine("CreateCommand");
        //    cmd.CommandText = (SQLCommand);
        //    SQLiteDataReader _sql = cmd.ExecuteReader();
        //    _sqlite.Close();
        //    Console.WriteLine("new connection close");
        //}
        static void SQL_Print(string ConnectParametr, string SQLCommand)
        {
            SQLiteConnection _sqlite = new SQLiteConnection(ConnectParametr);
            Console.WriteLine("new connection sets setup");
            _sqlite.Open();
            Console.WriteLine("new connection open");
            SQLiteCommand cmd = _sqlite.CreateCommand();
            Console.WriteLine("CreateCommand");
            cmd.CommandText = (SQLCommand);
            SQLiteDataReader _sql = cmd.ExecuteReader();
            if (_sql.HasRows)
            {
                string _text = "";
                while (_sql.Read())
                {
                    _text += "id: " + _sql["id"]
                        + "\tname: " + _sql["name"]
                        + "\tdisplay: " + _sql["display"]
                        + "\tkeyboard: " + _sql["keyboard"]
                        + "\tmouse: " + _sql["mouse"]
                        + "\n";
                }
                Console.WriteLine(_text);
            }
            else
            {
                Console.WriteLine("Ничего не найдено...");
            }
            _sqlite.Close();
            Console.WriteLine("new connection close");
        }


        static void Main(string[] args)
        {

            string ConnectParametr = @"Data source = inventory.db; Version = 3;Mode=ReadWriteCreate;";
            string SQLCommand_create = "CREATE TABLE IF NOT EXISTS workplace " +
                "(id INTEGER PRIMARY KEY ASC AUTOINCREMENT, " +
                "name VARCHAR (1, 50), display  VARCHAR (1, 50), " +
                "keyboard VARCHAR (1, 50), mouse VARCHAR (1, 50));";
            string SQLCommand_delete = "DROP TABLE workplace;";
            string MonitorName = "'***'";
            try
            {
                MonitorName = "'" + args[0] + "'";
            }
            catch
            {
                Console.WriteLine("Нет аргументов командной строки");
            }
            string SQLCommand_insert = "INSERT INTO workplace " +
                "(name, display, keyboard, mouse) " +
                "VALUES ( 'WorkPC001', " +
                MonitorName/*"'Disp001'"*/ +
                ", 'Keyboard001', 'Mouse001');";
            string SQLCommand_update = "update workplace set mouse ='Mouse004' where display = 'HP';";
            string SQLCommand_print = "SELECT * FROM workplace;";
            //string SQLCommand_deleteTable = "delete from workplace where id >= 7;";
            SQL_Print(ConnectParametr, SQLCommand_create);
            SQL_Print(ConnectParametr, SQLCommand_insert);
            SQL_Print(ConnectParametr, SQLCommand_update);
            SQL_Print(ConnectParametr, SQLCommand_print);
            //SQL_Print(ConnectParametr, SQLCommand_deleteTable);

            Console.WriteLine("Удалить таблицу? (Y)");
            if (Console.ReadLine() == "Y")
            {
                SQL_Print(ConnectParametr, SQLCommand_delete);
                Console.WriteLine("Таблица удалена...");
            }

            Console.ReadKey();

        }
    }
}
