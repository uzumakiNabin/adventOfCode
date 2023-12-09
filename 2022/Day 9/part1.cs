using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    public static void Main()
    {
        string[] list = File.ReadAllLines("input.txt");
        int[,] ropes = new int[1100, 1100];
        int headX = 549, headY = 549;
        int tailX = 549, tailY = 549;
        ropes[tailY, tailX]++;
        string direction;
        int steps;
        string newTailLoc = "";
        int total = 0;
        foreach (string str in list)
        {
            direction = str.Split(' ')[0];
            steps = Int32.Parse(str.Split(' ')[1]);
            switch (direction)
            {
                case "U":
                    for (int i = 0; i < steps; i++)
                    {
                        headY--;
                        newTailLoc = AdustTail(headX, headY, tailX, tailY);
                        tailX = Int32.Parse(newTailLoc.Split(' ')[0]);
                        tailY = Int32.Parse(newTailLoc.Split(' ')[1]);
                        try
                        {
                            ropes[tailX, tailY]++;
                        }
                        catch
                        {
                            Console.WriteLine("{0} {1}", tailX, tailY);
                        }

                    }
                    break;
                case "D":
                    for (int i = 0; i < steps; i++)
                    {
                        headY++;
                        newTailLoc = AdustTail(headX, headY, tailX, tailY);
                        tailX = Int32.Parse(newTailLoc.Split(' ')[0]);
                        tailY = Int32.Parse(newTailLoc.Split(' ')[1]);
                        try
                        {
                            ropes[tailX, tailY]++;
                        }
                        catch
                        {
                            Console.WriteLine("{0} {1}", tailX, tailY);
                        }
                    }
                    break;
                case "L":
                    for (int i = 0; i < steps; i++)
                    {
                        headX--;
                        newTailLoc = AdustTail(headX, headY, tailX, tailY);
                        tailX = Int32.Parse(newTailLoc.Split(' ')[0]);
                        tailY = Int32.Parse(newTailLoc.Split(' ')[1]);
                        try
                        {
                            ropes[tailX, tailY]++;
                        }
                        catch
                        {
                            Console.WriteLine("{0} {1}", tailX, tailY);
                        }
                    }
                    break;
                case "R":
                    for (int i = 0; i < steps; i++)
                    {
                        headX++;
                        newTailLoc = AdustTail(headX, headY, tailX, tailY);
                        tailX = Int32.Parse(newTailLoc.Split(' ')[0]);
                        tailY = Int32.Parse(newTailLoc.Split(' ')[1]);
                        try
                        {
                            ropes[tailX, tailY]++;
                        }
                        catch
                        {
                            Console.WriteLine("{0} {1}", tailX, tailY);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        for (int i = 0; i < 1100; i++)
        {
            for (int j = 0; j < 1100; j++)
            {
                if (ropes[i, j] > 0)
                {
                    total++;
                }
            }
        }
        Console.WriteLine("Total numbers of locations visited by tail is {0:D}", total);
    }

    public static bool IsTailAdjacent(int headX, int headY, int tailX, int tailY)
    {
        if (Math.Abs(headX - tailX) <= 1 && Math.Abs(headY - tailY) <= 1)
        {
            return true;
        }
        return false;
    }

    public static string AdustTail(int headX, int headY, int tailX, int tailY)
    {
        if (!IsTailAdjacent(headX, headY, tailX, tailY))
        {
            if (headX == tailX)
            {
                return tailX + " " + ((headY > tailY) ? (tailY + 1) : (tailY - 1)).ToString();
            }
            else if (headY == tailY)
            {
                return ((headX > tailX) ? (tailX + 1) : (tailX - 1)).ToString() + " " + tailY;
            }
            else
            {
                return ((headX > tailX) ? (tailX + 1) : (tailX - 1)).ToString() + " " + ((headY > tailY) ? (tailY + 1) : (tailY - 1)).ToString();
            }
        }
        return tailX + " " + tailY;
    }
}