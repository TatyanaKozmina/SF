string[] names = new string[] { "Olga", "Max", "Vera", "Alex", "Nikita" };
Console.WriteLine("Неотсортированный массив имён");
PrintNames();

NumberReaderClass numberReader = new NumberReaderClass();
numberReader.Number12EnteredEvent += SortNames;
numberReader.Number3EnteredEvent += StopWork;

while (!numberReader.Stop)
{
    try
    {
        numberReader.EnterNumber();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

Console.ReadLine();

void SortNames(int number)
{
    for (int i = 0; i < names.Length; i++)
    {
        for (int j = i + 1; j < names.Length; j++)
        {
            bool needSwap = false;
            if (number == 1) needSwap = String.Compare(names[i], names[j]) > 0;
            else if (number == 2) needSwap = String.Compare(names[i], names[j]) < 0;

            if (needSwap)
            {
                var item = names[i];
                names[i] = names[j];
                names[j] = item;
            }
        }
    }

    PrintNames();
}

void PrintNames()
{
    for (int i = 0; i < names.Length; i++)
        Console.WriteLine(names[i]);
}

bool StopWork()
{
    Console.WriteLine("Останавливаемся");
    return true;
}