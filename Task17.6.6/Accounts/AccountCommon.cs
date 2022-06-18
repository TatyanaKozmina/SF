public class AccountCommon : AbstractAccount, ICalc
{
    public AccountCommon(double balance) : base(balance)
    {
    }

    public void CalcInterest()
    {
        // расчет процентной ставки обычного аккаунта по правилам банка
        Interest = Balance * 0.4;

        if (Balance < 1000)
            Interest -= Balance * 0.2;

        if (Balance < 50000)
            Interest -= Balance * 0.4;

        Console.WriteLine($"Процентная ставка = {Interest}");
    }
}
