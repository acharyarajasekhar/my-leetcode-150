private List<List<Pair>> ToAdjacencyList(int[,] times, int n)
{
    var pairs = new List<List<Pair>>();
    for (int i = 0; i <= n; i++)
    {
        pairs.Add(new List<Pair>());
    }
    for (int i = 0; i < times.GetLength(0); i++)
    {
        var ui = times[i, 0];
        var vi = times[i, 1];
        var wi = times[i, 2];
        pairs[ui].Add(new Pair(vi, wi));
    }
    return pairs;
}

private void Print(List<List<Pair>> pairs)
{
    for (int i = 0; i < pairs.Count; i++)
    {
        Console.Write("\n" + i + " : ");
        foreach (var pair in pairs[i])
        {
            Console.Write(i + " -> " + pair.vi + " = " + pair.wi + ", ");
        }
    }
}

struct Pair
{
    public int vi;
    public int wi;

    public Pair(int v, int w)
    {
        vi = v;
        wi = w;
    }
}

var n = 4;
int[,] input = { { 3, 1, 1 }, { 2, 3, 1 }, { 2, 4, 1 } };

Print(ToAdjacencyMatrix(input, n));