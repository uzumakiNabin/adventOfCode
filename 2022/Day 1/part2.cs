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
        Console.WriteLine("Most Calorie is {0}", GetSumTop3(totalList));
    }

    public static int GetSumTop3(List<int> lst)
    {
        lst.Sort();
        int count = lst.Count;
        return lst[count - 1] + lst[count - 2] + lst[count - 3];
    }
}