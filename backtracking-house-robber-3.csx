private int LeftNodeIndex(int indx) => (2 * indx) + 1;
private int RightNodeIndex(int indx) => (2 * indx) + 2;

private void Rob(int[] arr)
{
    var options = Travel(arr, 0);
    Console.WriteLine(Math.Max(options[0], options[1]));
}

private int[] Travel(int[] arr, int indx)
{
    if (indx >= arr.Length) return new int[] { 0, 0 };

    var leftNodeOptions = Travel(arr, LeftNodeIndex(indx));
    var rightNodeOptions = Travel(arr, RightNodeIndex(indx));

    var currentOptions = new int[] { 0, 0 };
    currentOptions[0] = arr[indx] + leftNodeOptions[1] + rightNodeOptions[1];
    currentOptions[1] = Math.Max(leftNodeOptions[0], leftNodeOptions[1]) + Math.Max(rightNodeOptions[0], rightNodeOptions[1]);

    return currentOptions;
}

Rob(new int[] { 3, 5, 25, 10, 12, 3, 1 });
Rob(new int[] { 3, 4, 5, 2, 3, 0, 1 });