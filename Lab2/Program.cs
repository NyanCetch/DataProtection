using System;

namespace Lab2
 {
     internal class Program
     {
         public static void Main(string[] args)
         {
             Console.Write("Введите текст: ");
             string text = Console.ReadLine().ToLower();
             
             Console.Write("Придумайте ключ: ");
             string key = Console.ReadLine().ToLower();
             
             Console.Write("Укажите сдвиг: ");
             int keyShift = Int32.Parse(Console.ReadLine());
             
             VigenereCipher.ShowTable();
             Console.WriteLine("Шифр: " + VigenereCipher.GetEncryptedText(text, key, keyShift));
             
             Console.Write("Для продолжения нажмите любую кнопку...");
             Console.ReadKey();
         }
     }
 }