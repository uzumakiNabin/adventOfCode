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
        int top, left, right, bot;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // if (i == 0 || j == 0 || i == rows - 1 || j == columns - 1)
                // {
                //     total++;
                //     continue;
                // }
                top = left = right = bot = 0;
                for (int k = i - 1; k >= 0; k--)
                {
                    if (grid[k][j] >= grid[i][j])
                    {
                        top++;
                        break;
                    }
                    top++;
                }
                for (int k = j - 1; k >= 0; k--)
                {
                    if (grid[i][k] >= grid[i][j])
                    {
                        left++;
                        break;
                    }
                    left++;
                }
                for (int k = j + 1; k < columns; k++)
                {
                    if (grid[i][k] >= grid[i][j])
                    {
                        right++;
                        break;
                    }
                    right++;
                }
                for (int k = i + 1; k < rows; k++)
                {
                    if (grid[k][j] >= grid[i][j])
                    {
                        bot++;
                        break;
                    }
                    bot++;
                }
                if ((top * left * right * bot) > total)
                {
                    total = top * left * right * bot;
                }
            }
        }
        Console.WriteLine("Highest scenary score is {0:D}", total);
    }
}