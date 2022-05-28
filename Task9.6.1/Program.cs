Exception[] exceptions = new Exception[]
{
    new FileNotFoundException(),
    new ArgumentNullException(),
    new MyException("Новое исключение."),
    new PathTooLongException(),
    new IndexOutOfRangeException()
};

foreach (var item in exceptions)
{
    try
    {
        throw item;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

Console.ReadLine();