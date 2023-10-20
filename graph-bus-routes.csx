struct QueueItem
{
    public int Stop { get; set; }
    public int RouteLength { get; set; }

    public QueueItem(int s, int r)
    {
        Stop = s;
        RouteLength = r;
    }
}

private int NumBusesToDestination(int[][] routes, int source, int target)
{
    var stopToBusMap = new Dictionary<int, List<int>>();
    for (int i = 0; i < routes.Length; i++)
    {
        foreach (var stop in routes[i])
        {
            if (stopToBusMap.ContainsKey(stop))
            {
                stopToBusMap[stop].Add(i);
            }
            else
            {
                stopToBusMap.Add(stop, new List<int>() { i });
            }
        }
    }

    foreach (var stp in stopToBusMap)
    {
        Console.WriteLine("Stop: " + stp.Key + ", Bus No(s): " + string.Join(',', stp.Value.ToArray()));
    }

    Console.WriteLine("**********************");

    Queue<QueueItem> q = new Queue<QueueItem>();
    q.Enqueue(new QueueItem(source, 0));

    List<int> visitedStops = new List<int>();
    visitedStops.Add(source);
    var busesVisited = new List<int>();

    while (q.Count != 0)
    {
        var current = q.Dequeue();
        Console.WriteLine("currentStop: " + current.Stop);

        if (current.Stop == target)
        {
            Console.WriteLine("********************");
            foreach (var bus in busesVisited) Console.WriteLine(bus);
            return busesVisited.Count;
        }

        foreach (var busRouteId in stopToBusMap[current.Stop])
        {
            if (!busesVisited.Contains(busRouteId))
            {
                busesVisited.Add(busRouteId);
                Console.WriteLine("busId: " + busRouteId);
                foreach (var newStop in routes[busRouteId])
                {
                    Console.WriteLine("newStop: " + newStop);
                    if (!visitedStops.Contains(newStop))
                    {
                        q.Enqueue(new QueueItem(newStop, current.RouteLength + 1));
                        visitedStops.Add(newStop);
                        Console.WriteLine("visitedStop: " + newStop);
                    }
                    else
                    {
                        Console.WriteLine("already-visited-Stop: " + newStop);
                    }
                }
            }

        }
    }

    return -1;
}

var input = new int[][] { new int[] { 4, 2, 12 }, new int[] { 3, 26 }, new int[] { 1, 10 }, new int[] { 4, 26, 6 } };

var busCount = NumBusesToDestination(input, 3, 12);

Console.WriteLine("Bus Count: " + busCount);