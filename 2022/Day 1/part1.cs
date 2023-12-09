using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    public static void Main()
    {
        List<int> totalList = new List<int>();
        int total = 0;
        string[] list = File.ReadAllLines("input.txt");
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i] == "")
            {
                totalList.Add(total);
                total = 0;
                continue;
            }
            total += Int32.Parse(list[i]);
        }
        Console.WriteLine("Most Calorie is {0}", GetMax(totalList));
    }

    public static int GetMax(List<int> lst)
    {
        int max = Int32.MinValue;
        for (int i = 0; i < lst.Count; i++)
        {
            if (lst[i] > max)
            {
                max = lst[i];
            }
        }
        return max;
    }
}