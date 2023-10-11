public int MajorityElement(int[] nums)
{
    var n = nums.Length;
    var m = n / 2;
    var dict = new Dictionary<int, int>();
    for (int i = 0; i < n; i++)
    {
        if (dict.ContainsKey(nums[i]))
        {
            dict[nums[i]] = dict[nums[i]] + 1;
        }
        else
        {
            dict.Add(nums[i], 1);
        }
        if (dict[nums[i]] > m) return nums[i];
    }
    return -1;
}

var nums = new int[] {2,2,1,1,1,1,2};
var result = MajorityElement(nums);
Console.WriteLine(result);