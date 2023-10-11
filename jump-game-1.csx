private bool canJump(int[] nums)
{
    if (nums.Length == 1) return true;
    if (nums[0] == 0) return false;

    var indexToJumpTo = nums.Length - 1;
    for (var i = (nums.Length - 2); i >= 0; i--)
    {
        if (i + nums[i] >= indexToJumpTo) indexToJumpTo = i;
    }
    return indexToJumpTo == 0;
}

int[] nums = new int[] { 2, 3, 1, 1, 4 };
Console.WriteLine(canJump(nums));
