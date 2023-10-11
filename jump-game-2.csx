private int jump(int[] nums)
{
    int n = nums.Length;
    int destination = n - 1;
    int jumps = 0, coverage = 0, lastJump = 0;

    for (int i = 0; i < n; i++)
    {
        coverage = Math.Max(coverage, i + nums[i]);
        if (i == lastJump)
        {
            lastJump = coverage;
            jumps++;

            if (coverage >= destination) break;
        }
    }
    return jumps;
}

Console.WriteLine(jump(new int[] { 2, 3, 1, 1, 4 }));
Console.WriteLine(jump(new int[] { 2, 4, 1, 2, 3, 1, 1, 2 }));
