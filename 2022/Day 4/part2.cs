using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    public static void Main()
    {
        int total = 0;
        string[] list = File.ReadAllLines("input.txt");
        for (int i = 0; i < list.Length; i++)
        {
            string[] RangeList = list[i].Split(',');
            int FirstStart = Int32.Parse(RangeList[0].Split('-')[0]);
            int FirstEnd = Int32.Parse(RangeList[0].Split('-')[1]);
            int SecondStart = Int32.Parse(RangeList[1].Split('-')[0]);
            int SecondEnd = Int32.Parse(RangeList[1].Split('-')[1]);
            if ((FirstStart >= SecondStart && FirstEnd <= SecondEnd) || (SecondStart >= FirstStart && SecondEnd <= FirstEnd) || (FirstStart >= SecondStart && FirstStart <= SecondEnd) || (SecondStart >= FirstStart && SecondStart <= FirstEnd))
            {
                total++;
            }
        }
        Console.WriteLine("Total number of overlapping groups is {0:D}", total);
    }
}