private bool CanMatchsticksToSquare(int[] arr, int[] sides, int sideLength, int i)
{
    Console.WriteLine("----> i=" + i);
    Print(sides);
    if (i == arr.Length)
    {
        Console.WriteLine("##################################");
        return sides[0] == sideLength && sides[1] == sideLength && sides[2] == sideLength && sides[3] == sideLength;
    }

    for (int k = 0; k < sides.Length; k++)
    {
        if (sides[k] + arr[i] <= sideLength)
        {
            sides[k] += arr[i];
            if (CanMatchsticksToSquare(arr, sides, sideLength, i + 1))
            {
                return true;
            }
            sides[k] -= arr[i];
        }
    }
    return false;
}

private void SortByDescending(int[] arr)
{
    for (int i = 0; i < arr.Length - 1; i++)
    {
        var max = i;
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[max] < arr[j])
            {
                max = j;
            }
        }
        Swap(arr, i, max);
    }
}

private void Swap(int[] arr, int i, int j)
{
    var temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}

private int getOneSideLength(int[] arr)
{
    var sum = 0;
    foreach (var a in arr) sum += a;
    return sum / 4;
}

private void Print(int[] arr)
{
    foreach (var a in arr) Console.Write(a + ", ");
    Console.WriteLine();
}

//int[] arr = { 1, 1, 2, 2, 2 };
int[] arr = { 3, 4, 4, 1, 2, 2 };
//int[] arr = { 5, 6, 1, 1, 2, 2 };
//int[] arr = { 3, 3, 3, 3, 4 };
var oneSide = getOneSideLength(arr);

Print(arr);
Console.WriteLine("One Side Length: " + oneSide);
SortByDescending(arr);

if (arr.Length < 4 || arr[0] > oneSide) Console.WriteLine(false);
else
{
    int[] sides = { 0, 0, 0, 0 };
    Console.WriteLine(CanMatchsticksToSquare(arr, sides, oneSide, 0));
    Print(arr);
}
