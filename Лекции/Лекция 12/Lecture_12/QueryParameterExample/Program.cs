/*
 * SqliteParameter()
 * SqliteParameter(String, Object): первый параметр конструктора передает имя, а второй - значение параметра
 * SqliteParameter(String, SqliteType): первый параметр конструктора передает имя параметра, а второй - его тип в виде объекта SqliteType
 * SqliteParameter(String, SqliteType, Int32): первый параметр конструктора передает имя параметра, второй - его тип, а третий - максимальный размер значения параметра в байтах
 * SqliteParameter(String, SqliteType, Int32, String): конструктор последовательно принимает значения для имя параметра, его типа, максимального размера и имени столбца в таблице
 * 
 * Основные свойства:
 * SqliteType - устанавливает тип параметра в виде типа SqliteType
 * IsNullable - допускает ли параметр значение null
 * ParameterName - представляет имя параметра
 * Size - максимальный размер данных параметра в байтах
 * Value - значение параметра
 */

// данные для добавления
using Microsoft.Data.Sqlite;

int userage = 28;
string username = "Dan";
// выражение SQL для добавления данных
string sqlExpression = "INSERT INTO Users (Name, Age) VALUES (@name, @age)";
using (var connection = new SqliteConnection("Data Source=..\\..\\..\\..\\CreateTableQueryExample\\bin\\Debug\\net7.0\\usersdata.db"))
{
    connection.Open();

    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
    // создаем параметр для имени
    SqliteParameter nameParam = new SqliteParameter("@name", username);
    // добавляем параметр к команде
    command.Parameters.Add(nameParam);
    // создаем параметр для возраста
    SqliteParameter ageParam = new SqliteParameter("@age", userage);
    // добавляем параметр к команде
    command.Parameters.Add(ageParam);

    int number = command.ExecuteNonQuery();
    Console.WriteLine($"Добавлено объектов: {number}");


    command.Parameters.Clear();
    nameParam = new SqliteParameter("@name", SqliteType.Text, 4);
    // определяем значение
    nameParam.Value = "Daniel";
    // также можно определить тип и размер через свойства
    // nameParam.SqliteType = SqliteType.Text;
    // nameParam.Size = 3;
    // добавляем параметр к команде
    command.Parameters.Add(nameParam);
    // создаем параметр для возраста
    ageParam = new SqliteParameter("@age", 23);
    // добавляем параметр к команде
    command.Parameters.Add(ageParam);

    number = command.ExecuteNonQuery();
    Console.WriteLine($"Добавлено объектов: {number}");



    // вывод данных
    command.CommandText = "SELECT * FROM Users";
    using (SqliteDataReader reader = command.ExecuteReader())
    {
        if (reader.HasRows) // если есть данные
        {
            while (reader.Read())   // построчно считываем данные
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int age = reader.GetInt32(2);

                Console.WriteLine($"{id} \t {name} \t {age}");
            }
        }
    }
}
Console.Read();