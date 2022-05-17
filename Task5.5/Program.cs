Console.WriteLine("Введите фразу");
string phrase = Console.ReadLine();

Console.WriteLine("Введите глубину эха");
int echodeep = int.Parse(Console.ReadLine());

Echo(phrase, echodeep);

void Echo(string source, int deep)
{
    Console.WriteLine(source);
    if(deep > 1 && source.Length > 2)
    {
        deep--;
        source = source.Remove(0, 2);
        Echo(source, deep);
    }
}
