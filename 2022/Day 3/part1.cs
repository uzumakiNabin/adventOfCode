using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    public static void Main()
    {
        string first, second;
        int total = 0;
        string[] list = File.ReadAllLines("input.txt");
        for (int i = 0; i < list.Length; i++)
        {
            first = list[i].Substring(0, list[i].Length / 2);
            second = list[i].Substring(list[i].Length / 2);
            for (int j = 0; j < first.Length; j++)
            {
                if (second.IndexOf(first[j]) > -1)
                {
                    total += GetPriority(first[j]);
                    break;
                }
            }
        }
        Console.WriteLine("Total priority is {0:D}", total);
    }

    public static int GetPriority(char ch)
    {
        int ascii = (int)ch;
        if (ascii >= 97 && ascii <= 122)
        {
            return ascii - 96;
        }
        else
        {
            return ascii - 38;
        }
    }
}