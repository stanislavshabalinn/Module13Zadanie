using System.Diagnostics;

namespace Module13Zadanie;

class Program
{
    public static void Main(string[] args)
    {
        List<string> listWords = new List<string>();
        LinkedList<string> linkedListWords = new LinkedList<string>();
        string[] words;

        string path = "C:\\Users\\shabalin_sa\\source\\repos\\Module13Zadanie\\Text1.txt";

        using (var streamreader = new StreamReader(path))
        {
            var text = streamreader.ReadToEnd().ToLower();
            text = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
             
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        var stopwatchOne = Stopwatch.StartNew();
        foreach (var word in words)
            listWords.Add(word);
        Console.WriteLine($"Вставка в List<T>\t: {stopwatchOne.Elapsed.TotalMilliseconds} мс");

        linkedListWords.AddFirst("1");
        var stopwatchTwo = Stopwatch.StartNew();
        foreach (var word in words)
            linkedListWords.AddAfter(linkedListWords.First, word);
        Console.WriteLine($"Вставка в LinkedList<T>\t: {stopwatchTwo.Elapsed.TotalMilliseconds} мс");

    }
}