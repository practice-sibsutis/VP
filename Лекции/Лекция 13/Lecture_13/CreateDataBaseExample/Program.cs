using CreateDataBaseExample;
using Microsoft.EntityFrameworkCore;

using (UsersDataBaseContext usersContext = new UsersDataBaseContext())
{
    User tom = new User { Id = 1, Name = "Tom", Age = 33 };
    User alice = new User { Id = 2, Name = "Alice", Age = 26 };

    usersContext.Users.Add(tom);
    usersContext.Users.Add(alice);
    
    usersContext.SaveChanges();

    Console.WriteLine("Объекты были успешно сохранены");

    var users = usersContext.Users.ToList();
    Console.WriteLine("Список объектов:");

    foreach (var user in users)
    {
        Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
    }
}
