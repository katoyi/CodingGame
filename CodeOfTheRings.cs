using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


class Player
{

    static void Main(string[] args)
    {
        string magicPhrase = Console.ReadLine();

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        string[] alphabet = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", " " };

        Func<int, int, string, string> recupMot = (from, to, direction) =>
          {
              string result = string.Empty;
              for (int i = from; i < to; i++)
              {
                  result = result + direction;
              }
              return result;
          };

        Func<string, string[]> morcelleMot = (mot) =>
        {
            magicPhrase = magicPhrase.ToUpper();
            string[] mots = new string[magicPhrase.Length];
            for (int i = 0; i < magicPhrase.Length; i++)
            {
                mots[i] = magicPhrase[i].ToString();
            }
            return mots;
        };


        var resultat = string.Empty;
        string[] phrase = morcelleMot(magicPhrase);
        int tourNbre = 0;
        while (true)
        {
            int lastPosition = 0;
            for (int i = 0; i < phrase.Count(); i++)
            {
                int position = Array.IndexOf(alphabet, phrase[i]) + 1;
                if (position == 27 && tourNbre < 29)
                {
                    resultat += ">.";
                    tourNbre++;
                }
                else
                {
                    if (tourNbre == 30)
                    {
                        var posOfLetter = Array.IndexOf(phrase, " ") - 1;
                        lastPosition = Array.IndexOf(alphabet, phrase[posOfLetter]);
                    }
                    if (position >= lastPosition)
                    {
                        resultat += recupMot(lastPosition, position, "+");
                    }
                    else
                    {
                        resultat += recupMot(position, lastPosition, "-");
                    }
                    resultat += ".";
                }
                lastPosition = position;
            }
            break;
        }

        Console.WriteLine(resultat);
    }
}
