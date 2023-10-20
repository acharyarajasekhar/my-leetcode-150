private int NetworkDelay(List<List<Pair>> graph, int n, int k)
{
    int[] distance = new int[n];
    for (int i = 0; i < n; i++) distance[i] = int.MaxValue;
    distance[k - 1] = 0;
    PriorityQueue<Pair, int> pq = new PriorityQueue<Pair, int>();
    pq.Enqueue(new Pair(k, 0), 0);
    Console.WriteLine("\n***************************");
    while (pq.Count != 0)
    {
        var ui = pq.Dequeue();
        foreach (var connectedPair in graph[ui.vi])
        {
            if (ui.wi + connectedPair.wi < distance[connectedPair.vi - 1])
            {
                distance[connectedPair.vi - 1] = ui.wi + connectedPair.wi;
                pq.Enqueue(new Pair(connectedPair.vi, distance[connectedPair.vi - 1]), distance[connectedPair.vi - 1]);
            }
        }
    }

    int delay = 0;
    for (int i = 0; i < n; i++)
    {
        if (distance[i] == int.MaxValue) { delay = -1; break; }
        if (delay < distance[i]) delay = distance[i];
    }
    return delay;
}

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

var graph = ToAdjacencyList(input, n);

Print(graph);

Console.WriteLine(NetworkDelay(graph, n, 2));