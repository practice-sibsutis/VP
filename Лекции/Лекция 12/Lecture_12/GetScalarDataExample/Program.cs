using Microsoft.Data.Sqlite;

using (var connection = new SqliteConnection("Data Source=..\\..\\..\\..\\CreateTableQueryExample\\bin\\Debug\\net7.0\\usersdata.db"))
{
    connection.Open();

    string sqlExpression = "SELECT COUNT(*) FROM Users";
    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
    object count = command.ExecuteScalar();

    command.CommandText = "SELECT MIN(Age) FROM Users";
    object minAge = command.ExecuteScalar();

    command.CommandText = "SELECT AVG(Age) FROM Users";
    object avgAge = command.ExecuteScalar();

    Console.WriteLine($"В таблице {count} объектa(ов)");
    Console.WriteLine($"Минимальный возраст: {minAge}");
    Console.WriteLine($"Средний возраст: {avgAge}");
}
Console.Read();