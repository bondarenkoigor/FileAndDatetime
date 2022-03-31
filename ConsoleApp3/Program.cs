using System;
using System.IO;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("file.txt")) File.WriteAllText("file.txt", "");
            for (int i = 0; i<10; i++)
            {
                Console.WriteLine($"{i}/10");
                Console.Write("Введите имя:");
                string name = Console.ReadLine();
                Console.Write("Введите дату рождения(d/m/y):");
                int day = int.Parse(Console.ReadLine()), month = int.Parse(Console.ReadLine()), year = int.Parse(Console.ReadLine());
                File.AppendAllText("file.txt", $"{name}/{new DateTime(year, month, day).ToShortDateString()}\n");
            }

            string[] fileText;
            if (File.Exists("file.txt")) fileText = File.ReadAllText("file.txt").Split("\n");
            else {
                Console.WriteLine("file not found");
                return;
            }

            int oldestIndex = 0, youngestIndex = 0;
            for (int i = 0; i<fileText.Length - 1; i++)
            {
                DateTime iDate = Convert.ToDateTime(fileText[i].Substring(fileText[i].IndexOf("/") + 1));
                DateTime oldestDate = Convert.ToDateTime(fileText[oldestIndex].Substring(fileText[oldestIndex].IndexOf("/") + 1));
                DateTime youngestDate = Convert.ToDateTime(fileText[youngestIndex].Substring(fileText[youngestIndex].IndexOf("/") + 1));
                if (DateTime.Now.Subtract(iDate) > DateTime.Now.Subtract(oldestDate)) oldestIndex = i;
                if (DateTime.Now.Subtract(iDate) < DateTime.Now.Subtract(youngestDate)) youngestIndex = i;
            }
            File.WriteAllText("result.txt",$"Старший: {fileText[oldestIndex]}\nМладший: {fileText[youngestIndex]}");
        }
    }
}
