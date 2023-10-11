public int RemoveDuplicates(int[] nums)
{
    int i = 0, n = nums.Length;
    for (int j = 1; j < n; j++)
    {
        if (nums[i] < nums[j])
        {
            nums[++i] = nums[j];
        }
    }

    return i + 1;
}

var nums = new int[] {0,0,1,1,1,2,2,3,3,4};
int k = RemoveDuplicates(nums);


Console.WriteLine(k);
Console.WriteLine("************");
for(int i=0;i<nums.Length;i++) {
    if(i >= k) Console.Write("- ");
    else Console.Write(nums[i] + " ");
}