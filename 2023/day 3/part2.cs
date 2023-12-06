public class Location
{
    public string Line { get; set; }
    public int Index { get; set; }
    public char Dir { get; set; }
    public Location(string ln, int idx, char dr)
    {
        Line = ln;
        Index = idx;
        Dir = dr;
    }
}

static int getSum(string[] list)
{
    int result = 0;
    for (int i = 0; i < list.Length; i++)
    {
        string line = list[i];
        string? prev = i == 0 ? null : list[i - 1];
        string? next = i == list.Length - 1 ? null : list[i + 1];
        MatchCollection matches = Regex.Matches(line, @"\*");
        foreach (Match match in matches)
        {
            List<Location> locations = new();
            bool prevExist = false, nextExist = false;
            if (i == 0)
            {
                if (match.Index == 0)
                {
                    if (Int32.TryParse(line[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(line.Substring(match.Index + 1), match.Index + 1, 'F'));
                    }
                    if (Int32.TryParse(next?[match.Index].ToString(), out _))
                    {
                        locations.Add(new Location(next.Substring(match.Index), match.Index, 'F'));
                    }

                    if (locations.Count != 2 && Int32.TryParse(next?[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(next.Substring(match.Index + 1), match.Index + 1, 'F'));
                    }
                }
                else if (match.Index == line.Length - 1)
                {
                    if (Int32.TryParse(line[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(line[0..(match.Index)], match.Index - 1, 'B'));
                    }
                    if (Int32.TryParse(next?[match.Index].ToString(), out _))
                    {
                        locations.Add(new Location(next, match.Index, 'B'));
                    }

                    if (locations.Count != 2 && Int32.TryParse(next?[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(next[0..(match.Index)], match.Index - 1, 'B'));
                    }
                }
                else
                {
                    if (Int32.TryParse(line[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(line[0..(match.Index)], match.Index - 1, 'B'));
                    }
                    if (Int32.TryParse(line[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(line.Substring(match.Index + 1), match.Index + 1, 'F'));
                    }
                    if (Int32.TryParse(next?[match.Index].ToString(), out _))
                    {
                        nextExist = true;
                        locations.Add(new Location(next, match.Index, '2'));
                    }


                    if (!nextExist && locations.Count != 2 && Int32.TryParse(next?[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(next[0..(match.Index)], match.Index, 'B'));
                    }
                    if (!nextExist && locations.Count != 2 && Int32.TryParse(next?[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(next.Substring(match.Index + 1), match.Index, 'F'));
                    }

                }
            }
            else if (i == list.Length - 1)
            {
                if (match.Index == 0)
                {
                    if (Int32.TryParse(line[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(line.Substring(match.Index + 1), match.Index + 1, 'F'));
                    }
                    if (Int32.TryParse(prev?[match.Index].ToString(), out _))
                    {
                        locations.Add(new Location(prev.Substring(match.Index), match.Index, 'F'));
                    }

                    if (locations.Count != 2 && Int32.TryParse(prev?[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(prev.Substring(match.Index + 1), match.Index + 1, 'F'));
                    }
                }
                else if (match.Index == line.Length - 1)
                {
                    if (Int32.TryParse(line[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(line[0..(match.Index)], match.Index - 1, 'B'));
                    }
                    if (Int32.TryParse(prev?[match.Index].ToString(), out _))
                    {
                        locations.Add(new Location(prev, match.Index, 'B'));
                    }

                    if (locations.Count != 2 && Int32.TryParse(prev?[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(prev[0..(match.Index)], match.Index - 1, 'B'));
                    }
                }
                else
                {
                    if (Int32.TryParse(line[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(line[0..(match.Index)], match.Index - 1, 'B'));
                    }
                    if (Int32.TryParse(line[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(line.Substring(match.Index + 1), match.Index + 1, 'F'));
                    }
                    if (Int32.TryParse(prev?[match.Index].ToString(), out _))
                    {
                        locations.Add(new Location(prev, match.Index, '2'));
                        prevExist = true;
                    }


                    if (!prevExist && locations.Count != 2 && Int32.TryParse(prev?[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(prev[0..(match.Index)], match.Index, 'B'));
                    }
                    if (!prevExist && locations.Count != 2 && Int32.TryParse(prev?[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(prev.Substring(match.Index + 1), match.Index, 'F'));
                    }

                }
            }
            else
            {
                if (match.Index == 0)
                {
                    if (Int32.TryParse(line[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(line.Substring(match.Index + 1), match.Index + 1, 'F'));
                    }
                    if (Int32.TryParse(prev?[match.Index].ToString(), out _))
                    {
                        locations.Add(new Location(prev.Substring(match.Index), match.Index, 'F'));
                        prevExist = true;
                    }
                    if (Int32.TryParse(next?[match.Index].ToString(), out _))
                    {
                        locations.Add(new Location(next.Substring(match.Index), match.Index, 'F'));
                        nextExist = true;
                    }


                    if (!prevExist && locations.Count != 2 && Int32.TryParse(prev?[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(prev.Substring(match.Index + 1), match.Index, 'F'));
                    }
                    if (!nextExist && locations.Count != 2 && Int32.TryParse(next?[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(next.Substring(match.Index + 1), match.Index, 'F'));
                    }

                }
                else if (match.Index == line.Length - 1)
                {
                    if (Int32.TryParse(line[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(line[0..(match.Index)], match.Index - 1, 'B'));
                    }
                    if (Int32.TryParse(prev?[match.Index].ToString(), out _))
                    {
                        locations.Add(new Location(prev, match.Index, 'B'));
                        prevExist = true;
                    }
                    if (Int32.TryParse(next?[match.Index].ToString(), out _))
                    {
                        locations.Add(new Location(next, match.Index, 'B'));
                        nextExist = true;
                    }


                    if (!prevExist && locations.Count != 2 && Int32.TryParse(prev?[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(prev[0..(match.Index)], match.Index, 'B'));
                    }
                    if (!nextExist && locations.Count != 2 && Int32.TryParse(next?[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(next[0..(match.Index)], match.Index, 'B'));
                    }

                }
                else
                {
                    if (Int32.TryParse(line[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(line[0..(match.Index)], match.Index - 1, 'B'));
                    }
                    if (Int32.TryParse(line[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(line.Substring(match.Index + 1), match.Index + 1, 'F'));
                    }
                    if (Int32.TryParse(prev?[match.Index].ToString(), out _))
                    {
                        locations.Add(new Location(prev, match.Index, '2'));
                        prevExist = true;
                    }
                    if (Int32.TryParse(next?[match.Index].ToString(), out _))
                    {
                        locations.Add(new Location(next, match.Index, '2'));
                        nextExist = true;
                    }


                    if (!prevExist && locations.Count != 2 && Int32.TryParse(prev?[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(prev[0..(match.Index)], match.Index, 'B'));
                    }
                    if (!nextExist && locations.Count != 2 && Int32.TryParse(next?[match.Index - 1].ToString(), out _))
                    {
                        locations.Add(new Location(next[0..(match.Index)], match.Index, 'B'));
                    }
                    if (!prevExist && locations.Count != 2 && Int32.TryParse(prev?[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(prev.Substring(match.Index + 1), match.Index, 'F'));
                    }
                    if (!nextExist && locations.Count != 2 && Int32.TryParse(next?[match.Index + 1].ToString(), out _))
                    {
                        locations.Add(new Location(next.Substring(match.Index + 1), match.Index, 'F'));
                    }

                }
            }

            if (locations.Count == 2)
            {
                result += Int32.Parse(getNumberFromString(locations[0])) * Int32.Parse(getNumberFromString(locations[1]));
            }
        }
    }
    return result;
}

static string getNumberFromString(Location lc)
{
    string result = "";
    if (lc.Dir == 'F')
    {
        foreach (char c in lc.Line)
        {
            if (Int32.TryParse(c.ToString(), out _))
            {
                result += c;
            }
            else
            {
                break;
            }
        }
    }
    else if (lc.Dir == 'B')
    {
        for (int i = lc.Line.Length - 1; i >= 0; i--)
        {
            if (Int32.TryParse(lc.Line[i].ToString(), out _))
            {
                result = lc.Line[i].ToString() + result;
            }
            else
            {
                break;
            }
        }
    }
    else if (lc.Dir == '2')
    {
        return getNumberFromString(new Location(lc.Line[0..lc.Index], 0, 'B')) + getNumberFromString(new Location(lc.Line.Substring(lc.Index), 0, 'F'));
    }
    return result;
}