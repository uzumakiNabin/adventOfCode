static int getSum(string[] list)
{
    int result = 1;
    long durations = Int64.Parse(String.Join("", Regex.Split(Regex.Replace(list[0], @"Time:\s+", ""), @"\s+")));
    long distances = Int64.Parse(String.Join("", Regex.Split(Regex.Replace(list[1], @"Distance:\s+", ""), @"\s+")));

    int win = 0;
    for (long j = 1; j <= durations / 2; j++)
    {
        long myDistance = j * (durations - j);
        if (myDistance > distances)
        {
            win = (int)((durations / 2) - j + 1) * 2;

            if (durations % 2 == 0) win--;
            break;
        }
    }
    result *= win;

    return result;
}