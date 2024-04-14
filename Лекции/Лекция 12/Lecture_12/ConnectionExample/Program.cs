/*
 * SqliteConnection - создаёт соединение с базой данных
 * 
 * Data Source - путь к файлу бд
 * Mode - режим подключения = {ReadWriteCreate | ReadWrite | ReadOnly | Memory}
 * Cache - режим кэширования = {Default | Private | Shared}
 * Password - ключ шифрования
 * Foreign Keys - поддержка внешних ключей = {True | False}
 * Recursive triggers - поддержка рекурсивных триггеров = {True | False}
 * 
 * Пример строки подключения: "Data Source=usersdata3.db;Cache=Shared;Mode=ReadOnly;";
 */

using Microsoft.Data.Sqlite;

using (var connection = new SqliteConnection("Data Source=usersdata.db"))
{
    connection.Open();
    Console.WriteLine("Done!");
}

Console.Read();
