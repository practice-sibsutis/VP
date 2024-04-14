/*
 * Для чтения используется SqliteDataReader 
 * 
 * Свойства:
 * HasRow - содержит ли SqliteDataReader хотя бы одну строку = {True | False}
 * Item[Int32] - возвращает значение столбца по номеру
 * Item[string] - возвращает значение столбца по имени
 * 
 * Методы:
 * Close - закрывает SqliteDataReader
 * GetValue(Int32) - возвращает значение столбца по номеру
 * Read - считывает следующую строку в полученном наборе
 */

using Microsoft.Data.Sqlite;

string sqlExpression = "SELECT * FROM Users";
using (var connection = new SqliteConnection("Data Source=..\\..\\..\\..\\CreateTableQueryExample\\bin\\Debug\\net7.0\\usersdata.db"))
{
    connection.Open();

    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
    using (SqliteDataReader reader = command.ExecuteReader())
    {
        if (reader.HasRows)
        {
            while (reader.Read() == true)
            {
                var id = reader.GetValue(0);
                var name = reader.GetValue(1);
                var age = reader.GetValue(2);

                /*
                 * object id = reader[0];
                 * object name = reader[1];
                 * object age = reader[2];
                 */

                /*
                 * object id = reader["_id"];
                 * object name = reader["Name"];
                 * object age = reader["Age"];
                 */

                Console.WriteLine($"{id} \t {name} \t {age}");
            }
        }
    }
}
Console.Read();