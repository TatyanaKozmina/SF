using System.Diagnostics;

// Готовим данные для теста

// читаем весь файл в строку текста
string text = File.ReadAllText($"C:/SF/C#/Text1.txt");

// Сохраняем символы-разделители в массив
char[] delimiters = new char[] { ' ', '\r', '\n' };

// Создаём список
List<string> wordsList = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

// Создаём связанный список
LinkedList<string> wordsLinkedList = new LinkedList<string>(wordsList);

Console.WriteLine("Введите 1, чтобы протестировать вставку в список.");
Console.WriteLine("Введите 2, чтобы протестировать вставку в связанный список.");

string response = Console.ReadLine();

switch(response)
{
    case "1":
        // Находим индекс элемента в середине списка. 
        int idx = wordsList.Count / 2;

        // Запускаем тест вставки
        Stopwatch sw = Stopwatch.StartNew();
        wordsList.Insert(idx, "test");
        Console.WriteLine($"Вставка в список заняла {sw.Elapsed.TotalMilliseconds} милисекунд") ;

        break;
    case "2":
        // Находим элемент в связанном списке. 
        var node = wordsLinkedList.Find("Екатерингоф");
        if (node != null)
        {
            // Запускаем тест вставки
            sw = Stopwatch.StartNew();
            wordsLinkedList.AddAfter(node, "test");
            Console.WriteLine($"Вставка в связанный список заняла {sw.Elapsed.TotalMilliseconds} милисекунд");
        }
        break;
}

Console.ReadLine();