public abstract class AbstractAccount
{
    // баланс учетной записи
    public double Balance { get; set; }

    // процентная ставка
    public double Interest { get; set; }

    public AbstractAccount(double balance)
    {
        Balance = balance;
    }
}