class Calc : ICalc
{
    ILogger Logger { get; }

    public Calc(ILogger logger)
    {
        Logger = logger;
    }

    public void Sum()
    {
        Action<double, double> summa = new Action<double, double>(CalcSum);
        DoOperation(summa);
    }

    public void Multiply()
    {
        Action<double, double> multi = new Action<double, double>(CalcMultiply);
        DoOperation(multi);
    }

    private void DoOperation(Action<double, double> action)
    {
        bool repeat = true;

        while (repeat)
        {
            try
            {
                Console.Write("Введите первое число: ");
                double firstNum = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите второе число: ");
                double secondNum = Convert.ToDouble(Console.ReadLine());

                action(firstNum, secondNum);
            }
            catch (OverflowException)
            {
                Logger.Error("Слишком большое число.");
            }
            catch (FormatException)
            {
                Logger.Error("Это не число.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }

            Console.Write("Посчитаем ещё? Д/Н: ");
            if (Console.ReadLine().ToUpper() != "Д")
                repeat = false;
        }
    }

    private void CalcSum(double firstNum, double secondNum)
    {
        Logger.Event($"Сумма {firstNum} и {secondNum} равна {firstNum + secondNum}");
    }

    private void CalcMultiply(double firstNum, double secondNum)
    {
        Logger.Event($"Произведение {firstNum} и {secondNum} равно {firstNum * secondNum}");
    }
}