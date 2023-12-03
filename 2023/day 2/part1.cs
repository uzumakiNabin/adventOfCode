static int getSum(string[] list, int givenRed, int givenGreen, int givenBlue)
{
    int gameId, count, maxRed, maxGreen, maxBlue;
    Bag bag = new(givenRed, givenGreen, givenBlue);
    int gameSum = 0;

    foreach (string line in list)
    {
        gameId = Int32.Parse(Regex.Match(line, @"\bGame\s+(?<id>\d+)").Groups["id"].Value);
        maxRed = 0;
        maxGreen = 0;
        maxBlue = 0;
        MatchCollection matches = Regex.Matches(line, @"\b(?<count>\d+)\s+(?<color>\w+)");
        foreach (Match match in matches)
        {
            count = Int32.Parse(match.Groups["count"].Value);
            string color = match.Groups["color"].Value;
            switch (color)
            {
                case "red":
                    maxRed = maxRed >= count ? maxRed : count;
                    break;
                case "green":
                    maxGreen = maxGreen >= count ? maxGreen : count;
                    break;
                case "blue":
                    maxBlue = maxBlue >= count ? maxBlue : count;
                    break;
                default:
                    break;
            }
        }
        Game game = new(gameId, new Bag(maxRed, maxGreen, maxBlue));
        if (bag.isGameValid(game))
        {
            gameSum += game.id;
        }
    }
    return gameSum;
}

public class Bag
{
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public Bag(int r, int g, int b)
    {
        Red = r;
        Green = g;
        Blue = b;
    }

    public bool isGameValid(Game game)
    {
        if (game.MaxDrawn.Red <= Red && game.MaxDrawn.Green <= Green && game.MaxDrawn.Blue <= Blue)
        {
            return true;
        }
        return false;
    }
}

public class Game
{
    public int id { get; set; }
    public Bag MaxDrawn { get; set; }

    public Game(int gameId, Bag maxDrawnBag)
    {
        id = gameId;
        MaxDrawn = maxDrawnBag;
    }
}