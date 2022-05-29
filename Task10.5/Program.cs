class Program
{
    static ILogger Logger { get; set; }

    static void Main()
    {
        Logger = new Logger();

        Calc calculator = new Calc(Logger);

        calculator.Sum();
        //calculator.Multiply();
    }
}