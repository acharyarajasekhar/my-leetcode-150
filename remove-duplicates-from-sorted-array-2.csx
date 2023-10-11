public int RemoveDuplicates(int[] nums)
{
    int lastNumCount = 0, lastNum = -100000, i = 0, j = 0, n = nums.Length;
    while (j < n)
    {
        if (lastNum == nums[j] && lastNumCount < 2)
        {
            nums[i++] = nums[j];
            lastNumCount++;
        }
        else if (lastNum != nums[j])
        {
            nums[i++] = nums[j];
            lastNum = nums[j];
            lastNumCount = 1;
        }
        j++;
    }
    return i;
}

var nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
int k = RemoveDuplicates(nums);


Console.WriteLine(k);
Console.WriteLine("************");
for (int i = 0; i < nums.Length; i++)
{
    if (i >= k) Console.Write("- ");
    else Console.Write(nums[i] + " ");
}