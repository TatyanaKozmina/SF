sbyte[] testvals = { 2, 0, 4, -1 };

foreach (sbyte i in testvals)
{
    Console.WriteLine($"\nTest for value {i}");
    sbyte j = 0;
    while (j < i)
    {
        Console.WriteLine($"Prefix cycle j = {j}");
        j++;
    }

    Console.WriteLine();

    j = 0;
    do
    {
        Console.WriteLine($"Postfix cycle j = {j}");
        j++;
    } while (j < i);
}

Console.ReadLine();
