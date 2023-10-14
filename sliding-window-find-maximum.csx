private void repeatedSubSeq(int[] arr, int k)
{
    for (int i = 0; i <= arr.Length - k; i++)
    {
        int max = arr[i];
        for (int j = i; j < i + k; j++)
        {
            if (arr[j] > max) max = arr[j];
        }
        Console.WriteLine(max);
    }
}

var arr = new int[] { -4, 5, 4, -4, 4, 6, 7, 20 };
var k = 3;

repeatedSubSeq(arr, k);