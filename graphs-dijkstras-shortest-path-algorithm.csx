private int getMinUnvisitedVertext(bool[] visited, int[] value)
{
    int min = int.MaxValue;
    int vertex = -1;
    for (int i = 0; i < visited.Length; i++)
    {
        if (visited[i] == false && value[i] < min)
        {
            vertex = i;
            min = value[i];
        }
    }
    return vertex;
}

private void CalculateShortestPath(int[,] graph, int s)
{
    int n = graph.GetLength(0);
    bool[] visited = new bool[n];
    int[] value = new int[n];
    for (int i = 1; i < n; i++) value[i] = int.MaxValue;
    int[] parent = new int[n];
    for (int i = 0; i < n; i++) parent[i] = -1;

    for (int k = 0; k < n - 1; k++)
    {
        var vertexU = getMinUnvisitedVertext(visited, value);
        visited[vertexU] = true;

        for (int vertexV = 0; vertexV < n; vertexV++)
        {
            if (graph[vertexU, vertexV] != 0
            && visited[vertexV] == false
            && value[vertexU] != int.MaxValue
            && graph[vertexU, vertexV] + value[vertexU] < value[vertexV])
            {
                value[vertexV] = graph[vertexU, vertexV] + value[vertexU];
                parent[vertexV] = vertexU;
            }
        }
    }

    for (int k = 0; k < n; k++)
    {
        Console.WriteLine(parent[k] + " -> " + k + " = " + value[k]);
    }
}

int[,] graph = {
{0,10,3,0,0},
{10,0,4,2,0},
{3,4,0,8,2},
{0,2,8,0,5},
{0,0,2,5,0}
};

CalculateShortestPath(graph, 0);