private int[,] ToAdjacencyMatrix(int[,] times, int n, bool isDirectedGraph = true)
{
    int[,] temp = new int[n, n];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            for (int k = 0; k < times.GetLength(0); k++)
            {
                if (times[k, 0] == i + 1 && times[k, 1] == j + 1)
                {
                    temp[i, j] = times[k, 2];
                }
                if (!isDirectedGraph && times[k, 1] == i + 1 && times[k, 0] == j + 1)
                {
                    temp[i, j] = times[k, 2];
                }
            }
        }
    }
    return temp;
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

var n = 4;
int[,] input = { { 3, 1, 1 }, { 2, 3, 1 }, { 2, 4, 1 } };

Print(ToAdjacencyMatrix(input, n));
Console.WriteLine("**********");
Print(ToAdjacencyMatrix(input, n, false));