public class Map
{
    public long Source { get; set; }
    public long Dest { get; set; }
    public long Range { get; set; }
    public Map(long s, long d, long r)
    {
        Source = s; Dest = d; Range = r;
    }
}

public long CountPairs(int[] nums, int k)
{
    int result = 0;
    for (int i = 0; i < nums.Length - 1; i++)
    {
        for (int j = i + 1; j < nums.Length; j++)
        {
            if ((nums[i] == nums[j]) && ((i * j) % k == 0))
            {

                result++;
            }
        }
    }
    Stopwatch watch = Stopwatch.StartNew();
    string[] test = File.ReadAllLines(@"E:\Projects\test\aoc23input.txt");
    long zz = getSum(test);
    watch.Stop();
    Console.WriteLine("{0} ms spent", watch.ElapsedMilliseconds);
    return zz;
}

static long getSum(string[] list)
{
    long result = Int64.MaxValue;
    long[] seeds = list[0].Replace("seeds: ", "").Trim().Split(" ").Select(x => Int64.Parse(x)).ToArray();
    int s2fl = Array.IndexOf(list, "soil-to-fertilizer map:");
    int f2wl = Array.IndexOf(list, "fertilizer-to-water map:");
    int w2ll = Array.IndexOf(list, "water-to-light map:");
    int l2tl = Array.IndexOf(list, "light-to-temperature map:");
    int t2hl = Array.IndexOf(list, "temperature-to-humidity map:");
    int h2ll = Array.IndexOf(list, "humidity-to-location map:");

    Map[] s2sm = list.Take(3..(s2fl - 1)).Select(x => toMap(x)).ToArray();
    Map[] s2fm = list.Take((s2fl + 1)..(f2wl - 1)).Select(x => toMap(x)).ToArray();
    Map[] f2wm = list.Take((f2wl + 1)..(w2ll - 1)).Select(x => toMap(x)).ToArray();
    Map[] w2lm = list.Take((w2ll + 1)..(l2tl - 1)).Select(x => toMap(x)).ToArray();
    Map[] l2tm = list.Take((l2tl + 1)..(t2hl - 1)).Select(x => toMap(x)).ToArray();
    Map[] t2hm = list.Take((t2hl + 1)..(h2ll - 1)).Select(x => toMap(x)).ToArray();
    Map[] h2lm = list.Take((h2ll + 1)..(list.Length)).Select(x => toMap(x)).ToArray();

    for (int i = 0; i < seeds.Length; i += 2)
    {
        Console.WriteLine("Checking seed {0}", seeds[i]);
        for (long j = 0; j < seeds[i + 1] - 1; j++)
        {
            long location = mapS2D(h2lm, mapS2D(t2hm, mapS2D(l2tm, mapS2D(w2lm, mapS2D(f2wm, mapS2D(s2fm, mapS2D(s2sm, seeds[i] + j)))))));
            if (location < result)
            {
                result = location;
            }
        }
    }
    return result;
}

static Map toMap(string str)
{
    string[] strings = str.Trim().Split(" ");
    return new Map(Int64.Parse(strings[1]), Int64.Parse(strings[0]), Int64.Parse(strings[2]));
}

static long mapS2D(Map[] maps, long seed)
{
    long result = 0;
    foreach (Map m in maps)
    {
        if (seed >= m.Source && (seed - m.Source < m.Range))
        {
            result = m.Dest + (seed - m.Source);
        }
    }
    if (result == 0)
    {
        result = seed;
    }
    return result;
}