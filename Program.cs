using System.Diagnostics;

namespace Module13Zadanie;

class Program
{
    public static void Main(string[] args)
    {
        List<string> listWords = new List<string>();
        LinkedList<string> linkedListWords = new LinkedList<string>();
        string[] words;

        string path = "C:\\Users\\shabalin_sa\\source\\repos\\Module13Zadanie\\Text1.txt"; //Указываем путь к тексту

        using (var streamreader = new StreamReader(path))
        {
            var text = streamreader.ReadToEnd().ToLower(); // Считывание символов 
            text = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
             
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries); // Текст делится на слова, пробелы и переносы строк
        }

        var stopwatchOne = Stopwatch.StartNew(); //Первое измерение затраченного времени
        foreach (var word in words)
            listWords.Add(word);
        Console.WriteLine($"Вставка в List<T>\t: {stopwatchOne.Elapsed.TotalMilliseconds} мс");//Результат производительность вставки в List<T

        linkedListWords.AddFirst("1");
        var stopwatchTwo = Stopwatch.StartNew(); //Второе измерение затраченного времени
        foreach (var word in words)
            linkedListWords.AddAfter(linkedListWords.First, word);
        Console.WriteLine($"Вставка в LinkedList<T>\t: {stopwatchTwo.Elapsed.TotalMilliseconds} мс"); //Результат производительность вставки в LinkedList<T>

    }
}