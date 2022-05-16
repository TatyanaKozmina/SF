(string Name, string LastName, string Login, int LoginLength, bool HasPet, string[] favcolors, double Age) User;

for (int i = 1; i < 4; i++)
{
    Console.WriteLine("Введите имя");
    User.Name = Console.ReadLine();

    Console.WriteLine("Введите фамилию");
    User.LastName = Console.ReadLine();

    Console.WriteLine("Введите логин");
    User.Login = Console.ReadLine();
    User.LoginLength = User.Login.Length;

    Console.WriteLine("Есть ли у вас животные? Да или Нет");
    User.HasPet = (Console.ReadLine() == "Да") ? true : false;

    Console.WriteLine("Введите возраст пользователя");
    if (double.TryParse(Console.ReadLine(), out double res))
        User.Age = res;

    User.favcolors = new string[3];
    Console.WriteLine("Введите три любимых цвета пользователя");
    for (int j = 0; j < User.favcolors.Length; j++)
    {
        Console.WriteLine($"Введите цвет {j + 1}");
        User.favcolors[j] = Console.ReadLine();
    }
}