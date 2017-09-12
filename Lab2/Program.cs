using System;
 using System.Collections.Generic;
 using System.Linq;
 
 namespace Lab2
 {
     internal class Program
     {
         public static void Main(string[] args)
         {
             Console.Write("Введите текст: ");
             string text = Console.ReadLine();
             
             Console.Write("Придумайте ключ: ");
             string key = Console.ReadLine();
             
             VigenereCipher.ShowTable();
             Console.WriteLine("Шифр: " + VigenereCipher.GetEncryptedText(text, key, 3));
             Console.ReadKey();
         }
     }
 }