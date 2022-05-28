public class NumberReaderClass
{
    public delegate void Number12EnteredDelegate(int number);
    public event Number12EnteredDelegate Number12EnteredEvent;

    public delegate bool Number3EnteredDelegate();
    public event Number3EnteredDelegate Number3EnteredEvent;

    private bool stop;
    public bool Stop { get { return stop; } }

    public void EnterNumber()
    {
        Console.WriteLine("Введите 1, 2 или 3.");
        Console.WriteLine("1 - сортировать по возрастанию");
        Console.WriteLine("2 - сортировать по убыванию");
        Console.WriteLine("3 - остановить программу");

        int number = Convert.ToInt32(Console.ReadLine());

        switch (number)
        {
            case 1:
            case 2:
                Number_1_Or_2_Entered(number);
                break;
            case 3:
                stop = Number_3_Entered();
                break;
            default:
                throw new MyExceptionClass("Некорректное число. Возможные значения 1, 2 и 3.");
        }
    }

    protected virtual void Number_1_Or_2_Entered(int number)
    {
        Number12EnteredEvent(number);
    }
    protected virtual bool Number_3_Entered()
    {
        return Number3EnteredEvent();
    }
}