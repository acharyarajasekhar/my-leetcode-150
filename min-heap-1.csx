public class MinHeap
{
    private readonly int[] arr;
    private int _size = 0;

    private bool IsRoot(int indx) => indx == 0;
    private bool HasLeftChild(int indx) => _size > GetLeftChildIndex(indx);
    private bool HasRightChild(int indx) => _size > GetRightChildIndex(indx);
    private bool HasParent(int indx) => GetParentIndex(indx) <= 0;
    private int GetLeftChildIndex(int indx) => (2 * indx) + 1;
    private int GetRightChildIndex(int indx) => (2 * indx) + 2;
    private int GetParentIndex(int indx) => (indx - 1) / 2;
    private int GetLeftChild(int indx) => arr[GetLeftChildIndex(indx)];
    private int GetRightChild(int indx) => arr[GetRightChildIndex(indx)];
    private int GetParent(int indx) => arr[GetParentIndex(indx)];
    private int GetCurrent(int indx) => arr[indx];

    public MinHeap(int size)
    {
        arr = new int[size];
    }

    public void Add(int element)
    {
        Console.WriteLine("Add element " + element + " at " + _size + " with size " + arr.Length);
        if (_size == arr.Length) Console.WriteLine("Array size is full");
        arr[_size] = element;
        Swim(_size);
        _size++;
    }

    private void Swap(int l, int r)
    {
        var temp = arr[l];
        arr[l] = arr[r];
        arr[r] = temp;
    }

    private void Swim(int indx)
    {
        while (!IsRoot(indx) && GetParent(indx) > GetCurrent(indx))
        {
            int parentIndex = GetParentIndex(indx);
            Console.WriteLine("swapping of elements " + parentIndex + " and " + indx);
            Swap(indx, parentIndex);
            indx = parentIndex;
        }
    }

    public void PrintArray()
    {
        foreach (var r in arr)
        {
            Console.Write(r + ", ");
        }
    }
}

var minHeap = new MinHeap(8);
minHeap.Add(6);
minHeap.Add(8);
minHeap.Add(7);
minHeap.Add(5);
minHeap.Add(9);
minHeap.Add(4);
minHeap.Add(2);
minHeap.Add(3);

minHeap.PrintArray();