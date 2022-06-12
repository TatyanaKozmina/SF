Console.WriteLine("Программа начала работу. Это может занять несколько минут.");

// Считываем текст из файла в строку
string text = File.ReadAllText($"C:/SF/C#/Text1.txt");
var noPunctuationText = new string(text.Where(c => (!char.IsPunctuation(c) && !c.Equals("-"))).ToArray());

// Получаем только уникальные слова из текста
char[] delimiters = new char[] { ' ', '\r', '\n' };
HashSet<string> wordsHashSet = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToHashSet();

// Получаем все слова из текста
List<string> wordsList = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();

// Составляем словарь, где ключ - уникальное слово, значение - сколько раз слово встречается в тексте
Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();
foreach(var word in wordsHashSet)
{
    wordsDictionary.Add(word, wordsList.FindAll(c => c.Equals(word)).Count);
}

// Составляем список числа вхождений слов и сортируем его по возрастанию
List<int> occurences = wordsDictionary.Values.ToList();
occurences.Sort();

// Печатаем 10 чаще всего встречающихся слов
int counter = 0;
for(int i = occurences.Count - 1; i >= 0; i--)
{
    counter++;
    if (counter > 10)
        break;

    string word = wordsDictionary.Where(c => c.Value.Equals(occurences[i])).FirstOrDefault().Key;
    Console.WriteLine($"{counter}.  {occurences[i]} - {word}");
}

Console.ReadLine();