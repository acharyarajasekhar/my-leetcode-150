private bool findSumOfThree(int[] nums, int target)
{
    var n = nums.Length;
    for (int i = 0; i < n - 2; i++)
    {
        for (int j = i + 1; j < n - 1; j++)
        {
            for (int k = j + 1; k < n; k++)
            {
                if (nums[i] + nums[j] + nums[k] == target)
                {
                    Console.WriteLine(nums[i] + "+" + nums[j] + "+" + nums[k]);
                    return true;
                }
            }
        }
    }
    return false;
}

Console.WriteLine(findSumOfThree(new int[] { 3, 7, 1, 2, 8, 4, 5 }, 10));
Console.WriteLine(findSumOfThree(new int[] { 0, -1, 1 }, 2));