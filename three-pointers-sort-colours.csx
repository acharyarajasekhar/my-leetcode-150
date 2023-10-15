private void SortColours(int[] nums)
{
    var n = nums.Length;
    int i = 0, j = 0, k = n - 1;
    while (j < k)
    {
        if (nums[j] == 0)
        {
            Swap(nums, i, j);
            i++;
            j++;
        }
        else if (nums[j] == 1)
        {
            j++;
        }
        else if (nums[j] == 2)
        {
            Swap(nums, j, k);
            k--;
        }
    }
}

private void Swap(int[] nums, int i, int j)
{
    var temp = nums[i];
    nums[i] = nums[j];
    nums[j] = temp;
}

var input = new int[] { 2, 2, 1, 1, 0 };
SortColours(input);
foreach (var a in input) Console.WriteLine(a);
Console.WriteLine("************************");
var input2 = new int[] { 1, 0, 2, 1, 2, 2 };
SortColours(input2);
foreach (var a in input2) Console.WriteLine(a);