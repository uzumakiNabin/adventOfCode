using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    public static void Main()
    {
        string[] list = File.ReadAllLines("input.txt");
        string action;
        int value = 0;
        string[,] screen = new string[6, 40];
        int spriteRow = 0, spritePosition = 1, cycleRow = 0, cyclePosition = 0;
        foreach (string str in list)
        {
            action = str.Split(' ')[0];
            if (action == "noop")
            {
                if (cyclePosition > 39)
                {
                    cycleRow++;
                    cyclePosition = cyclePosition % 40;
                    spriteRow++;
                }
                if ((spriteRow == cycleRow) && (cyclePosition <= spritePosition + 1 && cyclePosition >= spritePosition - 1))
                {
                    screen[cycleRow, cyclePosition] = "#";
                }
                else
                {
                    screen[cycleRow, cyclePosition] = ".";
                }
                cyclePosition++;
            }
            else
            {
                value = Int32.Parse(str.Split(' ')[1]);
                for (int i = 0; i < 2; i++)
                {
                    if (cyclePosition > 39)
                    {
                        cycleRow++;
                        cyclePosition = cyclePosition % 40;
                        spriteRow++;
                    }
                    if ((spriteRow == cycleRow) && (cyclePosition <= spritePosition + 1 && cyclePosition >= spritePosition - 1))
                    {
                        screen[cycleRow, cyclePosition] = "#";
                    }
                    else
                    {
                        screen[cycleRow, cyclePosition] = ".";
                    }
                    cyclePosition++;
                }
                spritePosition += value;
            }
        }
        for (int i = 0; i < screen.GetLength(0); i++)
        {
            Console.WriteLine();
            for (int j = 0; j < screen.GetLength(1); j++)
            {
                Console.Write(screen[i, j]);
            }
        }
    }
}
