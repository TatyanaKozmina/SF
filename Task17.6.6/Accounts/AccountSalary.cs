public class AccountSalary : AbstractAccount, ICalc
{
    public AccountSalary(double balance) : base(balance)
    {
    }

    public void CalcInterest()
    {
        // расчет процентной ставки зарплатного аккаунта по правилам банка
        Interest = Balance * 0.5;
        Console.WriteLine($"Процентная ставка = {Interest}");
    }
}
