public static class Calculator
{
    // Метод для расчета процентной ставки
    public static void CalculateInterest(ICalc accountCalcMethod)
    {
        accountCalcMethod.CalcInterest();        
    }
}