static int getSum(string[] list)
{
    int count, maxRed, maxGreen, maxBlue;
    int gameSum = 0;

    foreach (string line in list)
    {
        maxRed = 1;
        maxGreen = 1;
        maxBlue = 1;
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
        gameSum += (maxRed * maxGreen * maxBlue);
    }
    return gameSum;
}