static int getTotal(string[] list)
{
    int total = 0;
    string firstIntPattern = @"\d|one|two|three|four|five|six|seven|eight|nine";
    Regex lastIntPattern = new(firstIntPattern, RegexOptions.RightToLeft);
    foreach (string line in list)
    {
        Match match = Regex.Match(line, firstIntPattern);
        Match lastMatch = lastIntPattern.Match(line);

        total += Int32.Parse(getNumber(match.Value) + getNumber(lastMatch.Value));
    }
    return total;
}

static string getNumber(string str)
{
    string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    if (numbers.Contains(str))
    {
        return (Array.IndexOf(numbers, str) + 1).ToString();
    }
    return str;
}