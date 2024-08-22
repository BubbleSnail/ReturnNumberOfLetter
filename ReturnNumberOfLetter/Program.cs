using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace ReturnNumberOfLetter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Enter sentence
           

            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Enter a sentence: (or type 'exit' to quit): ");
                string sentence = Console.ReadLine();
                if (sentence.Trim().ToLower() == "exit")
            {
                keepRunning = false;
                Console.WriteLine("Exiting the application...");
                continue;
            }
            // Result
            int averageLetters = AverageLettersPerWord(sentence);
            Console.WriteLine($"Average number of letters per word (2 or more characters): {averageLetters}");
            Console.WriteLine("Press Enter again to continue");
            Console.ReadLine();
            }
        }
        public static int AverageLettersPerWord(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
            {
                return 0; // Return 0 for NULL and Empty
            }

            // Use a regular expression to remove punctuation and split the sentence into words
            var words = Regex.Split(sentence, @"\W+")
                             .Where(word => !string.IsNullOrWhiteSpace(word) && word.Length >= 2);

            // Calculate the total number of letters and the count of valid words
            int totalLetters = words.Sum(word => word.Length);
            int wordCount = words.Count();

            // Calculate average number of letters per word. Return 0 if there are no valid words to avoid division by zero
            return wordCount > 0 ? totalLetters / wordCount : 0;
        }
    }
}
