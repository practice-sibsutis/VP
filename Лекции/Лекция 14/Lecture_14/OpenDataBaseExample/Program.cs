using OpenDataBaseExample;

using (UsersdataContext usersdataContext = new UsersdataContext())
{
    var users = usersdataContext.Users.ToList();

    Console.WriteLine("Список объектов:");
    foreach (var user in users)
    {
        Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
    }
}