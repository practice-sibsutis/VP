using Microsoft.Data.Sqlite;

using (var connection = new SqliteConnection("Data Source=..\\..\\..\\..\\CreateTableQueryExample\\bin\\Debug\\net7.0\\usersdata.db"))
{
    connection.Open();

    SqliteCommand command = new SqliteCommand();
    command.Connection = connection;
    command.CommandText = "INSERT INTO Users (Name, Age) VALUES ('Tom', 36)";
    int number = command.ExecuteNonQuery();

    Console.WriteLine($"В таблицу Users добавлено объектов: {number}");

    command.CommandText = "INSERT INTO Users (Name, Age) VALUES ('Alice', 32), ('Bob', 28)";
    number = command.ExecuteNonQuery();

    Console.WriteLine($"В таблицу Users добавлено объектов: {number}");
}
Console.Read();