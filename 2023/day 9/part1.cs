static int getSum(string[] list)
{
    int result = 0;
    foreach (string line in list)
    {
        int[] reading = Regex.Matches(line, @"-?\d+").Select(x => Int32.Parse(x.Value)).ToArray();
        List<int[]> seq = new() { reading };
        int j = 0;
        while (true)
        {
            int[] newSeq = new int[seq[j].Length - 1];
            for (int i = 0; i < seq[j].Length - 1; i++)
            {
                newSeq[i] = seq[j][i + 1] - seq[j][i];
            }
            if (newSeq[0] == 0)
            {
                if (newSeq.Count(x => x == 0) == newSeq.Length)
                {
                    break;
                }
            }
            seq.Add(newSeq);
            j++;
        }
        int toAdd = 0;
        for (int k = seq.Count - 1; k >= 0; k--)
        {
            toAdd += seq[k].Last();
        }

        result += toAdd;
    }
    return result;
}