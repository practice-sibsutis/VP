using System.Data;
using System.Data.SQLite;

string connectionString = "Data Source=..\\..\\..\\..\\CreateTableQueryExample\\bin\\Debug\\net7.0\\usersdata.db";
string sql = "SELECT * FROM Users";
using (SQLiteConnection connection = new SQLiteConnection(connectionString))
{
    // Создаем объект DataAdapter
    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, connection);
    // Создаем объект Dataset
    DataSet ds = new DataSet();
    // Заполняем Dataset
    adapter.Fill(ds);
    // Отображаем данные
    // перебор всех таблиц
    foreach (DataTable dt in ds.Tables)
    {
        foreach (DataColumn column in dt.Columns)
            Console.Write($"{column.ColumnName}\t");
        Console.WriteLine();
        // перебор всех строк таблицы
        foreach (DataRow row in dt.Rows)
        {
            // получаем все ячейки строки
            var cells = row.ItemArray;
            foreach (object cell in cells)
                Console.Write($"{cell}\t");
            Console.WriteLine();
        }
    }
}
Console.Read();