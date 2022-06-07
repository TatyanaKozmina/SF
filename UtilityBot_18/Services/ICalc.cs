namespace UtilityBot_18.Services
{
    public interface ICalc
    {
        Task<int> CalculateAsync(string calcType, string text, CancellationToken ct);
    }
}