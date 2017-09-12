using System;
using System.ComponentModel.Design;
using System.Configuration;
using System.Linq;

namespace Lab2
{
    public class VigenereCipher
    {
        public static string GetEncryptedText(string message, string key, int keyShift)
        {
            if (!IsCyrillic(message) || !IsCyrillic(key))
                return "Используйте только русские буквы и пробел!";
            
            // Шифрование ключа шифром Цезаря

            string encryptedKey = "";
            for (int i = 0; i < key.Length; ++i)
            {
                encryptedKey += ApplyShift(key[i], keyShift);
            }
            
            // Шифрование текста с помощью ключа

//            // Циклическая запись ключа
//            int count = (Int32) (Math.Ceiling((double) (message.Length) / encryptedKey.Length));
//            string alignedKey = String
//                .Concat(Enumerable
//                    .Repeat(encryptedKey, count));
//            // Убираем лишние символы
//            int difference = alignedKey.Length - message.Length;
//            if (difference != 0)
//                alignedKey = alignedKey.Remove(alignedKey.Length - difference);
            
            
            // Зашифрованный текст
            
//            string[] lines = message.Split(' '); // Сплитим текст по пробелам
//            
//            int keyInd = 0;
//            foreach (string l in lines)
//            {
//                string encryptedWord = "";
//                foreach (char c in l)
//                {
//                    
//                }
//                encryptedText += 
//            }
            Console.WriteLine("Ключ: " + encryptedKey);
            int k = 0;
            string encryptedText = "";
            for (int i = 0; i < message.Length; ++i)
            {
                //encryptedText += ApplyShift(alignedKey[i], message[i] - 'а');
                if (Char.IsLetter(message[i]))
                {
                    //encryptedText += ApplyShift(encryptedKey[i % encryptedKey.Length], message[i] - 'а');
                    char firstLetter = Char.IsUpper(message[i]) ? 'А' : 'а';
                    encryptedText += ApplyShift(encryptedKey[k], message[i] - firstLetter);
                    k = (k != encryptedKey.Length ? ++k : 0);
                }
                else
                {
                    encryptedText += message[i];
                }
            }

            return encryptedText;
        }

        public static void ShowTable()
        {
            for (char i = 'а'; i <= 'я'; ++i)
            {
                for (int j = 0; j < 32; ++j)
                {
                    Console.Write("{0} ", ApplyShift(i, j));
                }
                Console.WriteLine();
            }
        }

        private static char ApplyShift(char letter, int step)
        {
            char firstLetter = Char.IsUpper(letter) ? 'А' : 'а';
            return Convert.ToChar(firstLetter + ((letter - firstLetter + step) % 32));
        }

        private static bool IsCyrillic(string text)
        {
            bool isCyrillic = true;
            foreach (char c in text.ToLower())
            {
                if (Char.IsLetter(c) && (c < 'а' || c > 'я'))
                {
                    isCyrillic = false;
                    break;
                }
            }
            return isCyrillic;
        }
    }
}