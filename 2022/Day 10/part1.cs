using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    public static void Main()
    {
        string[] list = File.ReadAllLines("input.txt");
        string action;
        int value = 0, cycle = 0, register = 1, total = 0;
        foreach (string str in list)
        {
            action = str.Split(' ')[0];
            if (action == "noop")
            {
                cycle++;
                for (int i = 20; i < 221; i += 40)
                {
                    if (cycle == i)
                    {
                        total += i * register;
                    }
                }
            }
            else
            {
                value = Int32.Parse(str.Split(' ')[1]);
                for (int i = 0; i < 2; i++)
                {
                    cycle++;
                    for (int j = 20; j < 221; j += 40)
                    {
                        if (cycle == j)
                        {
                            total += j * register;
                        }
                    }
                }
                register += value;
            }
        }
        Console.WriteLine("Total strength is {0:D}", total);
    }
}