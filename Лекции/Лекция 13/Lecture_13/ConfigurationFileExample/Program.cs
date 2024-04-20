using ConfigurationFileExample;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
// установка пути к текущему каталогу
builder.SetBasePath(Directory.GetCurrentDirectory());
// получаем конфигурацию из файла appsettings.json
builder.AddJsonFile("appsettings.json");
// создаем конфигурацию
var config = builder.Build();
// получаем строку подключения
string connectionString = config.GetConnectionString("DefaultConnection");

var optionsBuilder = new DbContextOptionsBuilder<UsersdataContext>();
var options = optionsBuilder.UseSqlite(connectionString).Options;

using (UsersdataContext db = new UsersdataContext(options))
{
    var users = db.Users.ToList();
    foreach (User user in users)
        Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
}