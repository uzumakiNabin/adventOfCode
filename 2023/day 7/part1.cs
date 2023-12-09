public class Hand
{
    public string Cards { get; set; }
    public int Bid { get; set; }
    public int Value { get; set; }
    public Hand(string c, int b, int v)
    {
        Cards = c;
        Bid = b;
        Value = v;
    }
}

static int getSum(string[] list)
{
    int result = 0;
    Hand[] hands = list.Select(x => toHand(x)).OrderBy(x => x.Value).ThenBy(x => x.Cards).ToArray();

    for (int i = 0; i < hands.Length; i++)
    {
        result += hands[i].Bid * (i + 1);
    }

    return result;
}

static int getHandValue(string hand)
{
    if (hand.Count(x => x == hand[0]) == 5)
    {
        return 7;
    }
    string charCount = getCharCount(hand);
    if (charCount.Contains('4'))
    {
        return 6;
    }
    else if (charCount.Contains('3'))
    {
        if (charCount.Contains('2'))
        {
            return 5;
        }
        return 4;
    }
    else if (charCount.Count(x => x == '2') == 2)
    {
        return 3;
    }
    else if (charCount.Count(x => x == '2') == 1)
    {
        return 2;
    }
    return 1;
}

static string getCharCount(string hand)
{
    string result = "";
    while (hand.Length > 0)
    {
        int count = hand.Count(x => x == hand[0]);
        result += $"{hand[0]}{count}";
        hand = hand.Replace(hand[0].ToString(), "");
    }
    return result;
}

static Hand toHand(string str)
{
    string[] strArr = str.Split(' ');
    string cardsForSorting = strArr[0].Replace("2", "a")
        .Replace("3", "b")
        .Replace("4", "c")
        .Replace("5", "d")
        .Replace("6", "e")
        .Replace("7", "f")
        .Replace("8", "g")
        .Replace("9", "h")
        .Replace("T", "i")
        .Replace("J", "j")
        .Replace("Q", "k")
        .Replace("K", "l")
        .Replace("A", "m");
    return new Hand(cardsForSorting, Int32.Parse(strArr[1]), getHandValue(cardsForSorting));
}