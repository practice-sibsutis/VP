/*
 * SqliteCommand реализует интерфейс System.Data.IDbCommand
 * и позволяет выполнять запросы к БД
 * 
 * SqliteCommand()
 * SqliteCommand(string)
 * SqliteCommand(string, SqliteConnection)
 * SqliteCommand(string, SqliteConnection, SqliteTransaction)
 * 
 * Или метод CreateCommand объъекта SqliteConnection:
 * SqliteCommand command = connection.CreateCommand();
 */

using Microsoft.Data.Sqlite;

using (var connection = new SqliteConnection("Data Source=usersdata.db"))
{
    connection.Open();
    SqliteCommand command = new SqliteCommand();
    command.Connection = connection;
    command.CommandText = "CREATE TABLE Users(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL, Age INTEGER NOT NULL);";

    /*
     * Выполнение запроса:
     * ExecuteNonQuery для INSERT, UPDATE, DELETE, CREATE
     * ExecuteReader для SELECT
     * ExecuteScalar для SELECT, возвращающего одно значение
     */

    command.ExecuteNonQuery();

    Console.WriteLine("Таблица Users создана");
}
Console.Read();

