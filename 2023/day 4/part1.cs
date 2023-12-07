static int getSum(string[] list)
{
    int result = 0;
    list = list.Select(x => Regex.Replace(x, @"Card\s+\d+:\s+", "")).ToArray();
    foreach (string line in list)
    {
        int couponValue = 0;
        string[] splitNums = Regex.Split(line, @"\s+\|\s+");
        int[] winningNums = Regex.Split(splitNums[0].Trim(), @"\s+").Select(x => Int32.Parse(x)).ToArray();
        int[] elfNums = Regex.Split(splitNums[1].Trim(), @"\s+").Select(x => Int32.Parse(x)).ToArray();
        foreach (int num in elfNums)
        {
            if (winningNums.Contains(num))
            {
                couponValue = couponValue == 0 ? 1 : couponValue * 2;
            }
        }
        result += couponValue;
    }
    return result;
}