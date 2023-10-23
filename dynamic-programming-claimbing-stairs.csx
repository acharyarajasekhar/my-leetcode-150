private int ClaimbStairs(int n)
{
    if (n <= 2) return n;

    var dp = new int[n + 1];
    dp[1] = 1;
    dp[2] = 2;

    for (int i = 3; i <= n; i++)
    {
        dp[i] = dp[i - 1] + dp[i - 2];
    }

    return dp[n];
}


Console.WriteLine(ClaimbStairs(8));