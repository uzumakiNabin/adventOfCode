using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    public static void Main()
    {
        int total = 0;
        string[] list = File.ReadAllLines("input.txt");
        for (int i = 0; i < list.Length; i += 3)
        {
            for (int j = 0; j < list[i].Length; j++)
            {
                if (list[i + 1].IndexOf(list[i][j]) > -1 && list[i + 2].IndexOf(list[i][j]) > -1)
                {
                    total += GetPriority(list[i][j]);
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