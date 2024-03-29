using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FindWords
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lire les mots du dictionnaire depuis un fichier texte
            string[] dictionary = File.ReadAllLines("dictionary.txt");

            // Mots fournis par l'utilisateur
            string[] userInput = { "Dome", "teac", "tiodi", "se" };

            // Convertir les mots fournis par l'utilisateur en un ensemble de caractères triés
            var userWordSets = userInput.Select(word => new string(word.ToLower().OrderBy(c => c).ToArray())).ToArray();

            // Recherche des mots dans le dictionnaire
            foreach (var userWordSet in userWordSets)
            {
                Console.WriteLine($"Mots qui peuvent être formés avec les lettres de '{userWordSet}' :");

                foreach (var word in dictionary)
                {
                    var sortedWord = new string(word.ToLower().OrderBy(c => c).ToArray());
                    if (string.Join("", sortedWord.Intersect(userWordSet)) == sortedWord)
                    {
                        Console.WriteLine(word);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
