using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenerCipher
{
    class Program
    {
        public static char[] AlphabetArray = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        static void Main(string[] args)
        {
            string s = Encryption("quark", "salamander");
            Console.WriteLine(s);
            Console.WriteLine(Decryption("quark", s));
            Console.ReadLine();
        }

        static string Encryption(string key, string s)
        {
            string encryptedString = "";
            List<char> charList = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                charList.Add(s.ToLower()[i]);
            }
            int k = 0;
            for (int i = 0; i < charList.Count; i++)
            {
                int j = 0;
                foreach (var item in AlphabetArray)
                {
                    if (charList[i] == item)
                    {
                        if (k > 4)
                        {
                            k = 0;
                        }
                        int move = Math.Abs(key[k] - 'a');
                        int ch = j + move;
                        if (ch >= AlphabetArray.Length)
                        {
                            ch = ch - AlphabetArray.Length;
                        }
                        encryptedString += AlphabetArray[ch];
                        k++;
                        break;
                    }
                    j++;
                }
            }
            return encryptedString;
        }

        static string Decryption(string key, string s)
        {
            string decryptedString = "";
            List<char> charList = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                charList.Add(s.ToLower()[i]);
            }
            int k = 0;
            for (int i = 0; i < charList.Count; i++)
            {
                int j = 0;
                foreach (var item in AlphabetArray)
                {
                    if (charList[i] == item)
                    {
                        if (k > 4)
                        {
                            k = 0;
                        }
                        int move = Math.Abs(key[k] - 'a');
                        int ch = j - move;
                        if (ch < 0)
                        {
                            ch = ch + AlphabetArray.Length;
                        }
                        decryptedString += AlphabetArray[ch];
                        k++;
                    }
                    j++;
                }
            }
            return decryptedString;
        }
    }
}
