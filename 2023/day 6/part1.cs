static int getSum(string[] list)
{
    int result = 1;
    int[] durations = Regex.Split(Regex.Replace(list[0], @"Time:\s+", ""), @"\s+").Select(x => Int32.Parse(x)).ToArray();
    int[] distances = Regex.Split(Regex.Replace(list[1], @"Distance:\s+", ""), @"\s+").Select(x => Int32.Parse(x)).ToArray();

    for (int i = 0; i < durations.Length; i++)
    {
        int win = 0;
        for (int j = 1; j <= durations[i] / 2; j++)
        {
            if (j * (durations[i] - j) > distances[i])
            {
                win = ((durations[i] / 2) - j + 1) * 2;

                if (durations[i] % 2 == 0) win--;
                break;
            }
        }
        result *= win;
    }

    return result;
}