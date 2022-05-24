using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Core.Application.Helpers
{
    public class QueueLettersConverter
    {
        public IList<char> Alphabet { get; private set; }

        public QueueLettersConverter()
        {
            Alphabet = GetDefaultAlphabet('A', 10);
        }
        public QueueLettersConverter(IList<char> alphabet)
        {
            Alphabet = alphabet;
        }

        private static IList<char> GetDefaultAlphabet(char firstSymbol, int power)
        {
            var result = new List<char>();
            for (int i = firstSymbol; i < firstSymbol + power; i++)
            {
                result.Add(char.ConvertFromUtf32(i)[0]);
            }
            return result;
        }

        public string NumberToLetters(int number)
        {
            var result = new StringBuilder();
            do
            {
                result.Append(Alphabet[number % Alphabet.Count]);
                number = number / Alphabet.Count;
            } while (number > 0);
            return result.ToString();
        }
        public int LettersToNumber(string letters)
        {
            int result = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                result += ((int)Math.Pow(Alphabet.Count, i)) * Alphabet.IndexOf(letters[i]);
            }
            return result;
        }
    }
}
