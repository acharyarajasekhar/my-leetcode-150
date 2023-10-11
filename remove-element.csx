public int RemoveElement(int[] nums, int val)
{
    int i = 0, j = 0, k = 0;
    while (j < nums.Length)
    {
        if (nums[j] == val)
        {
            j++;
        }
        else
        {
            nums[i++] = nums[j++];
            k++;
        }
    }
    return k;
}

var nums = new int[] {0,1,2,2,3,0,4,2};
int val = 2;
int k = RemoveElement(nums, val);

Console.WriteLine(k);
Console.WriteLine("************");
for(int i=0;i<nums.Length;i++) {
    if(i >= k) Console.Write("- ");
    else Console.Write(nums[i] + " ");
}