public void Rotate(int[] nums, int k)
{
    int n = nums.Length;
    if (k == 0 || n == 1 || n == k) return;

    int i = 0, j = 0, temp = nums[0];
    for (int t = 0; t < n; t++)
    {
        j = (j + k) % n;
        if (j >= n) continue;
        (nums[j], temp) = (temp, nums[j]);

        if (i == j)
        {
            i++;
            j++;
            temp = nums[j];
        }
    }
}

var nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
int k = 3;
Rotate(nums, k);
foreach (var n in nums)
{
    Console.Write(n + " ");
}