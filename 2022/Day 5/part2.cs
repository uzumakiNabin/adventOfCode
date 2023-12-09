using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    public static void Main()
    {
        string[] list = File.ReadAllLines("input.txt");
        List<string> cargo = new List<string>();
        List<string> instructions = new List<string>();
        List<List<char>> crates = new List<List<char>>();
        foreach (string str in list)
        {
            if (str.Length > 0)
            {
                if (str[0] == 'm')
                {
                    instructions.Add(str);
                }
                else if (str.Contains("["))
                {
                    cargo.Add(str);
                }
            }
        }
        cargo.Reverse();
        foreach (string str in cargo)
        {
            for (int i = 0; i < str.Length; i += 4)
            {
                if (str[i + 1] != ' ')
                {
                    try
                    {
                        crates[i / 4].Add(str[i + 1]);
                    }
                    catch
                    {
                        crates.Add(new List<char>());
                        crates[i / 4].Add(str[i + 1]);
                    }
                }
            }
        }
        int amount = 0, from = 0, target = 0;
        foreach (string instr in instructions)
        {
            string[] instrArray = instr.Split(' ');
            amount = Int32.Parse(instrArray[1]);
            from = Int32.Parse(instrArray[3]) - 1;
            target = Int32.Parse(instrArray[5]) - 1;
            for (int i = crates[from].Count - amount; i < crates[from].Count; i++)
            {
                crates[target].Add(crates[from][i]);
            }
            crates[from].RemoveRange(crates[from].Count - amount, amount);
        }
        string TopCargo = "";
        foreach (List<char> crate in crates)
        {
            TopCargo += crate[crate.Count - 1].ToString();
        }
        Console.WriteLine("Top cargoes are {0}", TopCargo);
    }
}