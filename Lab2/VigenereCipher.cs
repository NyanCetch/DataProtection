using System;

namespace Lab2
{
    public class VigenereCipher
    {
        public static string GetEncryptedText(string message, string key, int keyShift)
        {
            if (!IsCyrillic(message) || !IsCyrillic(key))
                return "Используйте только русские буквы!";
            
            // Шифрование ключа шифром Цезаря

            string encryptedKey = "";
            for (int i = 0; i < key.Length; ++i)
            {
                encryptedKey += ApplyShift(key[i] - 'а', keyShift);
            }
            Console.WriteLine("Ключ: " + encryptedKey);
            
            // Шифрование текста с помощью ключа
            
            int k = 0;
            string encryptedText = "";
            for (int i = 0; i < message.Length; ++i)
            {
                if (Char.IsLetter(message[i]))
                {
                    encryptedText += ApplyShift(encryptedKey[k++] - 'а', message[i] - 'а');
                    if (k == key.Length)
                        k = 0;
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
                    Console.Write("{0} ", ApplyShift(i - 'а', j));
                }
                Console.WriteLine();
            }
        }

        private static char ApplyShift(int index, int step)
        {
            return Convert.ToChar('а' + ((index + step) % 32));
        }

        private static bool IsCyrillic(string text)
        {
            bool isCyrillic = true;
            foreach (char c in text)
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