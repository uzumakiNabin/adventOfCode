using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    public static void Main()
    {
        List<int> totalList = new List<int>();
        int total = 0;
        string MyMove = "";
        string[] list = File.ReadAllLines("input.txt");
        for (int i = 0; i < list.Length; i++)
        {
            string[] moves = list[i].Split(' ');
            MyMove = GetMyMove(moves[0], moves[1]);
            total += CalculateScore(moves[0], MyMove);
        }
        Console.WriteLine("Total score is {0:D}", total);
    }
    private enum OpponentPick
    {
        A = 1,
        B = 2,
        C = 3
    }
    private enum PickScore
    {
        X = 1,
        Y = 2,
        Z = 3
    }
    private enum GameScore
    {
        Win = 6,
        Draw = 3,
        Lose = 0
    }

    public static int CalculateScore(string opponent, string mine)
    {
        string GameState = "";
        int result = (int)Enum.Parse(typeof(PickScore), mine) - (int)Enum.Parse(typeof(OpponentPick), opponent);
        if (result == 0)
        {
            GameState = "Draw";
        }
        else if (result == 1 || result == -2)
        {
            GameState = "Win";
        }
        else
        {
            GameState = "Lose";
        }
        return (int)Enum.Parse(typeof(PickScore), mine) + (int)Enum.Parse(typeof(GameScore), GameState);
    }

    public static string GetMyMove(string opponent, string res)
    {
        int value = (int)Enum.Parse(typeof(OpponentPick), opponent);
        switch (res)
        {
            case "X":
                return Enum.GetName(typeof(PickScore), value == 1 ? 3 : value - 1);
            case "Y":
                return Enum.GetName(typeof(PickScore), value);
            case "Z":
                return Enum.GetName(typeof(PickScore), value == 3 ? 1 : value + 1);
            default:
                break;
        }
        return "";
    }
}