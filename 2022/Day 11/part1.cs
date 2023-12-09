using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

class Program
{
    public static void Main()
    {
        List<Monkey> monkeys = new List<Monkey>();
        string[] list = File.ReadAllLines("input.txt");
        List<int> startingItems = new List<int>();
        string formula = "", test = "";
        int ifTrue = 0, ifFalse = 0;
        foreach (string str in list)
        {
            if (str.Contains("Starting"))
            {
                string[] items = str.Split(':')[1].Split(',');
                foreach (string item in items)
                {
                    startingItems.Add(Int32.Parse(item));
                }
            }
            else if (str.Contains("Operation"))
            {
                formula = str.Split(':')[1];
            }
            else if (str.Contains("Test"))
            {
                test = str.Split(':')[1];
            }
            else if (str.Contains("true"))
            {
                string[] ifTrueStr = str.Split(':')[1].Split(' ');
                ifTrue = Int32.Parse(ifTrueStr[ifTrueStr.Length - 1]);
            }
            else if (str.Contains("false"))
            {
                string[] ifFalseStr = str.Split(':')[1].Split(' ');
                ifFalse = Int32.Parse(ifFalseStr[ifFalseStr.Length - 1]);
                monkeys.Add(new Monkey()
                {
                    StartingItems = new List<int>(startingItems),
                    Formula = formula.Trim(),
                    Test = test.Trim(),
                    IfTrue = ifTrue,
                    IfFalse = ifFalse,
                });
                startingItems.Clear();
                formula = "";
                test = "";
                ifTrue = 0;
                ifFalse = 0;
            }
        }
        int[] monkeyInspectCount = new int[monkeys.Count];
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < monkeys.Count; j++)
            {
                Monkey mk = monkeys.ElementAt(j);
                for (int k = 0; k < mk.StartingItems.Count; k++)
                {
                    string action = mk.Formula.Split(' ')[3];
                    string firstValue = mk.Formula.Split(' ')[2];
                    string secondValue = mk.Formula.Split(' ')[4];
                    int firstInt = 0, secondInt = 0, newInt = 0;
                    if (firstValue == "old")
                    {
                        firstInt = mk.StartingItems.ElementAt(k);
                    }
                    else
                    {
                        firstInt = Int32.Parse(firstValue);
                    }
                    if (secondValue == "old")
                    {
                        secondInt = mk.StartingItems.ElementAt(k);
                    }
                    else
                    {
                        secondInt = Int32.Parse(secondValue);
                    }
                    switch (action)
                    {
                        case "+":
                            newInt = firstInt + secondInt;
                            break;
                        case "-":
                            newInt = firstInt - secondInt;
                            break;
                        case "*":
                            newInt = firstInt * secondInt;
                            break;
                        case "/":
                            newInt = firstInt * secondInt;
                            break;
                        default:
                            newInt = 0;
                            break;
                    }
                    newInt /= 3;
                    int divisibleBy = Int32.Parse(mk.Test.Split(' ')[2]);
                    if (newInt % divisibleBy == 0)
                    {
                        monkeys.ElementAt(mk.IfTrue).StartingItems.Add(newInt);
                    }
                    else
                    {
                        monkeys.ElementAt(mk.IfFalse).StartingItems.Add(newInt);
                    }
                    monkeyInspectCount[j]++;
                }
                mk.StartingItems.Clear();
            }
        }
        Array.Sort(monkeyInspectCount);
        for (int i = 0; i < monkeyInspectCount.Length; i++)
        {
            Console.WriteLine("{0:D} inspected {1:D} times", i, monkeyInspectCount[i]);
        }
        Console.WriteLine("Monkey business is {0:D}", monkeyInspectCount[monkeyInspectCount.Length - 1] * monkeyInspectCount[monkeyInspectCount.Length - 2]);
    }
}

class Monkey
{
    public List<int> StartingItems { get; set; }
    public string Formula { get; set; }
    public string Test { get; set; }
    public int IfTrue { get; set; }
    public int IfFalse { get; set; }
}
