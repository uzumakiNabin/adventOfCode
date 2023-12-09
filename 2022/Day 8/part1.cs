using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    public static void Main()
    {
        string[] list = File.ReadAllLines("input.txt");
        int total = 0;
        int rows = list.Length;
        int columns = list[0].Length;
        int[][] grid = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            grid[i] = new int[columns];
            for (int j = 0; j < columns; j++)
            {
                grid[i][j] = Int32.Parse(list[i][j].ToString());
            }
        }
        bool top = true, left = true, right = true, bot = true;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (i == 0 || j == 0 || i == rows - 1 || j == columns - 1)
                {
                    total++;
                    continue;
                }
                top = left = right = bot = true;
                for (int k = 0; k < i; k++)
                {
                    if (grid[k][j] >= grid[i][j])
                    {
                        top = false;
                        break;
                    }
                }
                for (int k = 0; k < j; k++)
                {
                    if (grid[i][k] >= grid[i][j])
                    {
                        left = false;
                        break;
                    }
                }
                for (int k = columns - 1; k > j; k--)
                {
                    if (grid[i][k] >= grid[i][j])
                    {
                        right = false;
                        break;
                    }
                }
                for (int k = rows - 1; k > i; k--)
                {
                    if (grid[k][j] >= grid[i][j])
                    {
                        bot = false;
                        break;
                    }
                }
                if (top || left || right || bot)
                {
                    total++;
                }
            }
        }
        Console.WriteLine("Total number of visible trees are {0:D}", total);
    }
}