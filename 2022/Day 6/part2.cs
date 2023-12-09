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
            for (int i = 0; i < str.Length - 13; i++)
            {
                if (IsRepeated(str.Substring(i, 14)))
                {
                    continue;
                }
                else
                {
                    total = i + 14;
                    break;
                }
            }
            Console.WriteLine("Start of packet marker at {0:D}", total);
        }
    }

    public static bool IsRepeated(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            char ch = str[i];
            string strWithoutCh = str.Substring(0, i) + str.Substring(i + 1);
            if (strWithoutCh.Contains(ch.ToString()))
            {
                return true;
            }
        }
        return false;
    }
}