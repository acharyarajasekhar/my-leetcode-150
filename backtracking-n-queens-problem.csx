private void backtrack(int r)
{
    if (r == n)
    {
        Console.WriteLine();
        foreach (var c in cols) Console.Write(c + ", ");
        return;
    }
    for (int c = 0; c < n; c++)
    {
        if (cols.Contains(c) || negDiag.Contains(r - c) || posDiag.Contains(r + c))
        {
            continue;
        }

        cols.Add(c);
        negDiag.Add(r - c);
        posDiag.Add(r + c);

        backtrack(r + 1);

        cols.Remove(c);
        negDiag.Remove(r - c);
        posDiag.Remove(r + c);
    }
}

var n = 4;
var cols = new List<int>();
var posDiag = new List<int>(); // r+c
var negDiag = new List<int>(); // r-c

backtrack(0);