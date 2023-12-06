static int getSum(string[] list)
{
    int result = 0;
    for (int i = 0; i < list.Length; i++)
    {
        string line = list[i];
        string? prev = i == 0 ? null : list[i - 1];
        string? next = i == list.Length - 1 ? null : list[i + 1];
        MatchCollection matches = Regex.Matches(line, @"\d+");
        foreach (Match match in matches)
        {
            string surroundingTxt = "";
            if (i == 0)
            {
                if (match.Index == 0)
                {
                    surroundingTxt = next?.Substring(0, match.Value.Length + 1) + line[match.Index + match.Value.Length].ToString();
                }
                else if (match.Index + match.Value.Length == line.Length)
                {
                    surroundingTxt = line[match.Index - 1].ToString() + next?.Substring(match.Index - 1);
                }
                else
                {
                    surroundingTxt = line[match.Index - 1].ToString() + next?.Substring(match.Index - 1, match.Value.Length + 2) + line[match.Index + match.Value.Length].ToString();
                }
            }
            else if (i == list.Length - 1)
            {
                if (match.Index == 0)
                {
                    surroundingTxt = prev?.Substring(0, match.Value.Length + 1) + line[match.Index + match.Value.Length].ToString();
                }
                else if (match.Index + match.Value.Length == line.Length)
                {
                    surroundingTxt = line[match.Index - 1].ToString() + prev?.Substring(match.Index - 1);
                }
                else
                {
                    surroundingTxt = line[match.Index - 1].ToString() + prev?.Substring(match.Index - 1, match.Value.Length + 2) + line[match.Index + match.Value.Length].ToString();
                }
            }
            else
            {
                if (match.Index == 0)
                {
                    surroundingTxt = prev?.Substring(0, match.Value.Length + 1) + line[match.Index + match.Value.Length].ToString() + next?.Substring(0, match.Value.Length + 1);
                }
                else if (match.Index + match.Value.Length == line.Length)
                {
                    surroundingTxt = line[match.Index - 1].ToString() + prev?.Substring(match.Index - 1) + next?.Substring(match.Index - 1);
                }
                else
                {
                    surroundingTxt = line[match.Index - 1].ToString() + prev?.Substring(match.Index - 1, match.Value.Length + 2) + line[match.Index + match.Value.Length].ToString() + next?.Substring(match.Index - 1, match.Value.Length + 2);
                }
            }
            if (Regex.Match(surroundingTxt, @"[^\d\.]").Success)
            {
                result += Int32.Parse(match.Value);
            }
        }
    }
    return result;
}