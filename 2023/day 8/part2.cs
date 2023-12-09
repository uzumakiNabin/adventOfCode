public class Element
{
    public string Left { get; set; }
    public string Right { get; set; }
    public Element(string l, string r)
    {
        Left = l;
        Right = r;
    }
}

static long getSum(string[] list)
{
    string instruction = list[0];
    Dictionary<string, Element> map = new();
    for (int i = 2; i < list.Length; i++)
    {
        MatchCollection matches = Regex.Matches(list[i], @"\w+");
        map.Add(matches[0].Value, new Element(matches[1].Value, matches[2].Value));
    }
    string[] starts = map.Where(x => x.Key[2] == 'A').Select(x => x.Key).ToArray();
    int[] steps = new int[starts.Length];

    for (int l = 0; l < starts.Length; l++)
    {
        int j = 0, repeat = 0;
        string ss = starts[l];
        while (ss[2] != 'Z')
        {
            Element elem = map[ss];
            if (instruction[j++] == 'L')
            {
                ss = elem.Left;
            }
            else
            {
                ss = elem.Right;
            }
            if (j == instruction.Length)
            {
                j = 0;
                repeat++;
            }
        }
        steps[l] = repeat * instruction.Length + j;
    }
    return steps.Aggregate((long)1, (lcm, next) => getLCM(lcm, next));
}

static long getHCF(long a, long b)
{
    if (b == 0)
    {
        return a;
    }
    return getHCF(b, a % b);
}

static long getLCM(long a, long b)
{
    return (a * b) / getHCF(a, b);
}