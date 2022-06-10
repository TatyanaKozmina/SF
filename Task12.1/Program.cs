// Заранее создадим список пользователей
List<User> users = new();
users.Add(new User("AlexA", "Алексей", false));
users.Add(new User("OlgaK", "Ольга", true));
users.Add(new User("PaulS", "Павел", false));

Console.WriteLine("Введите логин:");
string login = Console.ReadLine();

if (users.Exists(x => x.Login.Equals(login, StringComparison.OrdinalIgnoreCase)))
{
    var user = users.Where(x => x.Login.Equals(login, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

    Console.WriteLine($"Здравствуйте, {user.Name}!");

    if (!user.IsPremium)
        ShowAds();
}
else
{
    Console.WriteLine("Такого пользователя не существует.");
}

Console.ReadLine();

static void ShowAds()
{
    Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
    // Остановка на 1 с
    Thread.Sleep(1000);

    Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
    // Остановка на 2 с
    Thread.Sleep(2000);

    Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
    // Остановка на 3 с
    Thread.Sleep(3000);
}