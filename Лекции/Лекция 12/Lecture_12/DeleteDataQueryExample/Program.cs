using Microsoft.Data.Sqlite;

string sqlExpression = "DELETE  FROM Users WHERE Name='Tom'";
using (var connection = new SqliteConnection("Data Source=..\\..\\..\\..\\CreateTableQueryExample\\bin\\Debug\\net7.0\\usersdata.db"))
{
    connection.Open();

    SqliteCommand command = new SqliteCommand(sqlExpression, connection);

    int number = command.ExecuteNonQuery();

    Console.WriteLine($"Удалено объектов: {number}");
}
Console.Read();
