public class Card
{
    public int Count { get; set; }
    public int Value { get; set; }
    public Card(int count, int value)
    {
        Count = count;
        Value = value;
    }
}

static int getSum(string[] list)
{
    int result = 0;
    Card[] cards = new Card[list.Length];
    list = list.Select(x => Regex.Replace(x, @"Card\s+\d+:\s+", "")).ToArray();
    for (int i = 0; i < list.Length; i++)
    {
        int couponValue = 0;
        string[] splitNums = Regex.Split(list[i], @"\s+\|\s+");
        int[] winningNums = Regex.Split(splitNums[0].Trim(), @"\s+").Select(x => Int32.Parse(x)).ToArray();
        int[] elfNums = Regex.Split(splitNums[1].Trim(), @"\s+").Select(x => Int32.Parse(x)).ToArray();
        foreach (int num in elfNums)
        {
            if (winningNums.Contains(num))
            {
                couponValue++;
            }
        }
        cards[i] = new Card(1, couponValue);

    }

    for (int i = 0; i < cards.Length; i++)
    {
        for (int j = 0; j < cards[i].Count; j++)
        {
            for (int k = 1; k <= cards[i].Value; k++)
            {
                if (k + i <= cards.Length)
                {
                    cards[k + i].Count++;
                }
                else
                {
                    break;
                }
            }
        }
    }
    return cards.Sum(x => result + x.Count);
}