using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    public static void Main()
    {
        string[] list = File.ReadAllLines("input.txt");
        //string[] list = new string[] { "R 5"};
        int[,] ropes = new int[25, 25];
        int headX = 13, headY = 13;
        int[,] RopeLocations = new int[2, 9];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                RopeLocations[i, j] = 13;
            }
        }
        ropes[RopeLocations[0, 8], RopeLocations[1, 8]]++;
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
                        for (int j = 0; j < RopeLocations.GetLength(1); j++)
                        {
                            if (j == 0)
                            {
                                newTailLoc = AdjustTail(headX, headY, RopeLocations[0, j], RopeLocations[1, j]);
                            }
                            else
                            {
                                newTailLoc = AdjustTail(RopeLocations[0, j - 1], RopeLocations[1, j - 1], RopeLocations[0, j], RopeLocations[1, j]);
                            }
                            RopeLocations[0, j] = Int32.Parse(newTailLoc.Split(' ')[0]);
                            RopeLocations[1, j] = Int32.Parse(newTailLoc.Split(' ')[1]);
                            // ropes[RopeLocations[1, j], RopeLocations[0, j]] = j + 2;
                            if (j == RopeLocations.GetLength(1) - 1)
                            {
                                try
                                {
                                    ropes[RopeLocations[0, j], RopeLocations[1, j]]++;
                                }
                                catch
                                {
                                    Console.WriteLine("{0} {1}", RopeLocations[0, j], RopeLocations[1, j]);
                                }
                            }
                        }
                    }
                    break;
                case "D":
                    for (int i = 0; i < steps; i++)
                    {
                        headY++;
                        for (int j = 0; j < RopeLocations.GetLength(1); j++)
                        {
                            if (j == 0)
                            {
                                newTailLoc = AdjustTail(headX, headY, RopeLocations[0, j], RopeLocations[1, j]);
                            }
                            else
                            {
                                newTailLoc = AdjustTail(RopeLocations[0, j - 1], RopeLocations[1, j - 1], RopeLocations[0, j], RopeLocations[1, j]);
                            }
                            RopeLocations[0, j] = Int32.Parse(newTailLoc.Split(' ')[0]);
                            RopeLocations[1, j] = Int32.Parse(newTailLoc.Split(' ')[1]);
                            // ropes[RopeLocations[1, j], RopeLocations[0, j]] = j + 2;
                            if (j == RopeLocations.GetLength(1) - 1)
                            {
                                try
                                {
                                    ropes[RopeLocations[0, j], RopeLocations[1, j]]++;
                                }
                                catch
                                {
                                    Console.WriteLine("{0} {1}", RopeLocations[0, j], RopeLocations[1, j]);
                                }
                            }
                        }
                    }
                    break;
                case "L":
                    for (int i = 0; i < steps; i++)
                    {
                        headX--;
                        for (int j = 0; j < RopeLocations.GetLength(1); j++)
                        {
                            if (j == 0)
                            {
                                newTailLoc = AdjustTail(headX, headY, RopeLocations[0, j], RopeLocations[1, j]);
                            }
                            else
                            {
                                newTailLoc = AdjustTail(RopeLocations[0, j - 1], RopeLocations[1, j - 1], RopeLocations[0, j], RopeLocations[1, j]);
                            }
                            RopeLocations[0, j] = Int32.Parse(newTailLoc.Split(' ')[0]);
                            RopeLocations[1, j] = Int32.Parse(newTailLoc.Split(' ')[1]);
                            // ropes[RopeLocations[1, j], RopeLocations[0, j]] = j + 2;
                            if (j == RopeLocations.GetLength(1) - 1)
                            {
                                try
                                {
                                    ropes[RopeLocations[0, j], RopeLocations[1, j]]++;
                                }
                                catch
                                {
                                    Console.WriteLine("{0} {1}", RopeLocations[0, j], RopeLocations[1, j]);
                                }
                            }
                        }
                    }
                    break;
                case "R":
                    for (int i = 0; i < steps; i++)
                    {
                        headX++;
                        for (int j = 0; j < RopeLocations.GetLength(1); j++)
                        {
                            if (j == 0)
                            {
                                newTailLoc = AdjustTail(headX, headY, RopeLocations[0, j], RopeLocations[1, j]);
                            }
                            else
                            {
                                newTailLoc = AdjustTail(RopeLocations[0, j - 1], RopeLocations[1, j - 1], RopeLocations[0, j], RopeLocations[1, j]);
                            }
                            RopeLocations[0, j] = Int32.Parse(newTailLoc.Split(' ')[0]);
                            RopeLocations[1, j] = Int32.Parse(newTailLoc.Split(' ')[1]);
                            // ropes[RopeLocations[1, j], RopeLocations[0, j]] = j + 2;
                            if (j == RopeLocations.GetLength(1) - 1)
                            {
                                try
                                {
                                    ropes[RopeLocations[0, j], RopeLocations[1, j]]++;
                                }
                                catch
                                {
                                    Console.WriteLine("{0} {1}", RopeLocations[0, j], RopeLocations[1, j]);
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        ropes[headY, headX] = 9;
        Console.WriteLine("Rope locations:");
        for (int j = 0; j < RopeLocations.GetLength(1); j++)
        {
            ropes[RopeLocations[1, j], RopeLocations[0, j]] = j;
            Console.WriteLine("{0:D}  {1:D}", RopeLocations[1, j], RopeLocations[0, j]);
        }
        for (int i = 0; i < 25; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < 25; j++)
            {
                if (ropes[i, j] > 0)
                {
                    total++;
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
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

    public static string AdjustTail(int headX, int headY, int tailX, int tailY)
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