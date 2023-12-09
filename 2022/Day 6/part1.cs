using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    public static void Main()
    {
        int total = 0;
        string[] list = File.ReadAllLines("input.txt");
        foreach (string str in list)
        {
            for (int i = 0; i < str.Length - 3; i++)
            {
                if (IsRepeated(str[i], str[i + 1], str[i + 2], str[i + 3]))
                {
                    continue;
                }
                else
                {
                    total = i + 4;
                    break;
                }
            }
            Console.WriteLine("Start of packet marker at {0:D}", total);
        }
    }

    public static bool IsRepeated(char a, char b, char c, char d)
    {
        if (a == b || a == c || a == d || b == c || b == d || c == d)
        {
            return true;
        }
        return false;
    }
}