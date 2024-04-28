// Добавление
using CRUDExample;

using (UsersdataContext db = new UsersdataContext())
{
    User tom = new User { Name = "Tom", Age = 33 };
    User alice = new User { Name = "Alice", Age = 26 };

    // Добавление
    db.Users.Add(tom);
    db.Users.Add(alice);
    db.SaveChanges();
}

// получение
using (UsersdataContext db = new UsersdataContext())
{
    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Данные после добавления:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}

// Редактирование
using (UsersdataContext db = new UsersdataContext())
{
    // получаем первый объект
    User? user = db.Users.FirstOrDefault();
    if (user != null)
    {
        user.Name = "Bob";
        user.Age = 44;
        //обновляем объект
        db.Users.Update(user);
        db.SaveChanges();
    }
    // выводим данные после обновления
    Console.WriteLine("\nДанные после редактирования:");
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}

// Удаление
using (UsersdataContext db = new UsersdataContext())
{
    // получаем первый объект
    User? user = db.Users.FirstOrDefault();
    if (user != null)
    {
        //удаляем объект
        db.Users.Remove(user);
        db.SaveChanges();
    }
    // выводим данные после обновления
    Console.WriteLine("\nДанные после удаления:");
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}