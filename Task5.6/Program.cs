var User = GetUserData();
ShowUserData(User);

(string Name, string LastName, byte Age, string[] PetNames, string[] FavColors) GetUserData()
{
    string name = GetStringData("Ваше имя");

    string lastName = GetStringData("Ваша фамилия");

    byte age = GetByteData("Ваш возраст");

    string[] petNames = null;
    if (AnsweredYes("Есть у Вас питомцы?"))
    {
        petNames = CreateArray(GetByteData("Количество питомцев"), "Введите имя питомца");
    }

    string[] favColors = null;
    if (AnsweredYes("Есть у Вас любимые цвета?"))
    {
        favColors = CreateArray(GetByteData("Количество любимых цветов"), "Введите цвет");
    }

    var User = (name, lastName, age, petNames, favColors);
    return User;
}

void ShowUserData((string Name, string LastName, byte Age, string[] PetNames, string[] FavColors) user)
{
    Console.WriteLine($"Имя: {user.Name}");
    Console.WriteLine($"Фамилия: {user.LastName}");
    Console.WriteLine($"Возраст: {user.Age}");
    if (user.PetNames != null)
    {
        for (int i = 0; i < user.PetNames.Length; i++)
            Console.WriteLine($"Имя питомца {i + 1}: {user.PetNames[i]}");

    }
    if (user.FavColors != null)
    {
        for (int i = 0; i < user.FavColors.Length; i++)
            Console.WriteLine($"Любимый цвет {i + 1}: {user.FavColors[i]}");
    }
}

string GetStringData(string message)
{
    string[] forbiddenSymbols = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    string inputString;

    bool keepAsking;

    do
    {
        Console.WriteLine(message);
        inputString = Console.ReadLine();

        if (inputString.Trim().Length == 0)
        {
            keepAsking = true;
        }
        else
        { 
            keepAsking = false;

            foreach (string symbol in forbiddenSymbols)
            {
                if (inputString.Contains(symbol))
                {
                    Console.WriteLine("В имени или названии цвета не должно быть цифр");
                    keepAsking = true;
                    break;
                }
            }
        }
    } while (keepAsking);

    return inputString;
}

byte GetByteData(string message)
{
    byte inputNum;

    bool keepAsking;

    do
    {
        keepAsking = false;

        Console.WriteLine(message);
        if (!byte.TryParse(Console.ReadLine(), out inputNum) || inputNum == 0)
        {
            keepAsking = true;
            Console.WriteLine("Некорректное число");
        }        
        
    } while (keepAsking);

    return inputNum;
}

bool AnsweredYes(string message)
{
    string[] yesNo = new string[] { "Да", "Нет" };

    string inputString;

    bool keepAsking;

    do
    { 
        Console.WriteLine(message);
        Console.Write("Варианты ответов ");
        foreach(string item in yesNo)
        {
            Console.Write(item + " ");
        }
        inputString = Console.ReadLine();

        if(yesNo.Contains(inputString))
        {
            keepAsking = false;
            return (inputString == yesNo[0]) ? true : false;
        }
        else
        {
            keepAsking = true;
            Console.WriteLine("Некорректный ответ");
        }        

    } while (keepAsking);

    return false;
}

string[] CreateArray(byte numItems, string message)
{
    var result = new string[numItems];
    for(int i = 0; i < numItems; i++)
    {
        result[i] = GetStringData($"{message} {i + 1}");
    }
    return result;
}