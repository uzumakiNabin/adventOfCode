static int getTotal(string[] list)
{
    int total = 0;
    string firstIntPattern = @"\d";
    foreach (string line in list)
    {
        MatchCollection matches = Regex.Matches(line, firstIntPattern);
        total += Int32.Parse(matches[0].Value + matches[matches.Count - 1].Value);
    }
    return total;
}