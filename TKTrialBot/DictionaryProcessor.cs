using System.IO;

namespace TKTrialBot
{
    public static class DictionaryProcessor
    {
        private static string filePath = @"C:\MyDictionary.txt";
        public static List<DictionaryItem>? LoadFromFile()
        {
            if(File.Exists(filePath))
            {
                List<DictionaryItem>? DictionaryItems = new();
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string str = string.Empty;
                    while ((str = sr.ReadLine()) != null)
                    {
                        var words = str.Split(",");
                        DictionaryItem item = new DictionaryItem(words[0], words[1], words[2]);
                        DictionaryItems.Add(item);
                    }
                }
                return DictionaryItems;
            }
            return null;
        }

        public static async Task SaveToFile(List<DictionaryItem> items)
        {
            File.WriteAllText(filePath, string.Empty);
            foreach (var item in items)
            {                
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine($"{item.RusWord},{item.EngWord},{item.Theme}");
                }
            }
        }
    }
}
