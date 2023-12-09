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

static int getSum(string[] list)
{
    string instruction = list[0];
    Dictionary<string, Element> map = new();
    for (int i = 2; i < list.Length; i++)
    {
        MatchCollection matches = Regex.Matches(list[i], @"\w+");
        map.Add(matches[0].Value, new Element(matches[1].Value, matches[2].Value));
    }
    string start = "AAA";
    int j = 0, repeat = 0;
    while (start != "ZZZ")
    {
        Element el = map[start];
        if (instruction[j++] == 'L')
        {
            start = el.Left;
        }
        else
        {
            start = el.Right;
        }
        if (j == instruction.Length)
        {
            j = 0;
            repeat++;
        }
    }
    return repeat * instruction.Length + j;
}