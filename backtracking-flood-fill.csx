private void floodFill(int[,] arr, int i, int j, int src, int target)
{
    try
    {
        if (i >= 0 && i < arr.GetLength(0) && j >= 0 && j < arr.GetLength(1) && arr[i, j] == src)
        {
            arr[i, j] = target;
            floodFill(arr, i, j + 1, src, target);
            floodFill(arr, i, j - 1, src, target);
            floodFill(arr, i + 1, j, src, target);
            floodFill(arr, i - 1, j, src, target);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        Console.WriteLine(i + " " + j);
    }
}

private void Print(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write(arr[i, j] + ", ");
        }
        Console.WriteLine();
    }
}

int[,] arr = { { 1, 1, 0, 1, 0 }, { 0, 0, 0, 0, 1 }, { 0, 0, 0, 1, 1 }, { 1, 1, 1, 1, 0 }, { 1, 0, 0, 0, 0 } };
int i = 4, j = 3, target = 3;
Print(arr);
var src = arr[i, j];
Console.WriteLine("************");
floodFill(arr, i, j, src, target);
Print(arr);
int[,] arr1 = { { 1, 1, 0, 1, 0 }, { 0, 1, 0, 1, 1 }, { 0, 1, 0, 1, 1 }, { 1, 1, 1, 1, 0 }, { 1, 0, 0, 0, 0 } };
i = 4; j = 0;
src = arr1[i, j];
Console.WriteLine("************");
floodFill(arr1, i, j, src, target);
Print(arr1);