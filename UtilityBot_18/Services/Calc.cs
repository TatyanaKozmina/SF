namespace UtilityBot_18.Services
{
    internal class Calc : ICalc
    {
        public async Task<int> CalculateAsync(string calcType, string text, CancellationToken ct)
        {
            await Task.Delay(0);
            switch (calcType.ToUpper())
            {
                case "LEN":
                    Func<string, int> calcDelegate = Len;
                    return calcDelegate.Invoke(text);
                case "SUM":
                    calcDelegate = Sum;
                    return calcDelegate.Invoke(text);
            }
            throw new Exception("Кнопки не существует.");
        }

        private int Sum(string text)
        {
            int result = 0;
            string[] arguments = text.Split(" ");
            try
            {
                foreach (string item in arguments)
                {
                    int argument = int.Parse(item);
                    result += argument;
                }
            }
            catch (Exception)
            {
                throw new Exception("Не могу преобразовать введённый текст в число.");
            }
            return result;
        }

        private int Len(string text) => text.Length;

    }
}
