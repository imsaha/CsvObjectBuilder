using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsvObject
{
    public static class StringHelper
    {
        public static string GetPascalCase(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            var newString = string.Empty;
            var words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                // Remove special characters
                var word = Regex.Replace(words[i], "[^a-zA-Z0-9_]+", string.Empty);

                // Capitalize first later
                newString += $"{word[0].ToString().ToUpper()}{word[1..]}";
            }

            return newString;
        }
    }
}
