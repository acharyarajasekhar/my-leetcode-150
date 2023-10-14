public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public double Distance { get; set; }
}

public class MinHeap
{
    private readonly Point[] arr;
    private int _size = 0;

    private bool IsRoot(int indx) => indx == 0;
    private bool HasLeftChild(int indx) => _size > GetLeftChildIndex(indx);
    private bool HasRightChild(int indx) => _size > GetRightChildIndex(indx);
    private bool HasParent(int indx) => GetParentIndex(indx) <= 0;
    private int GetLeftChildIndex(int indx) => (2 * indx) + 1;
    private int GetRightChildIndex(int indx) => (2 * indx) + 2;
    private int GetParentIndex(int indx) => (indx - 1) / 2;
    private Point GetLeftChild(int indx) => arr[GetLeftChildIndex(indx)];
    private Point GetRightChild(int indx) => arr[GetRightChildIndex(indx)];
    private Point GetParent(int indx) => arr[GetParentIndex(indx)];
    private Point GetElementAt(int indx) => arr[indx];

    public MinHeap(int size)
    {
        arr = new Point[size];
    }

    public void Add(int x, int y)
    {
        var distance = Math.Sqrt((x * x) + (y * y));

        //Console.WriteLine("Add element " + element + " at " + _size + " with size " + arr.Length);
        if (_size == arr.Length) Console.WriteLine("Array size is full");
        arr[_size] = new Point() { X = x, Y = y, Distance = distance };
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
        while (!IsRoot(indx) && GetParent(indx).Distance > GetElementAt(indx).Distance)
        {
            int parentIndex = GetParentIndex(indx);
            //Console.WriteLine("swapping of elements " + parentIndex + " and " + indx);
            Swap(indx, parentIndex);
            indx = parentIndex;
        }
    }

    private void Sink(int indx)
    {
        while (HasLeftChild(indx))
        {
            var smallerElementIndex = GetLeftChildIndex(indx);
            if (HasRightChild(indx) && GetRightChild(indx).Distance < GetLeftChild(indx).Distance)
            {
                smallerElementIndex = GetRightChildIndex(indx);
            }

            //Console.WriteLine("index: " + indx + ", smallerIndex: " + smallerElementIndex);

            if (GetElementAt(indx).Distance <= GetElementAt(smallerElementIndex).Distance)
            {
                //Console.WriteLine("Break at index: " + indx + ", smallerIndex: " + smallerElementIndex);
                break;
            }

            Swap(indx, smallerElementIndex);

            //Console.WriteLine("Swap of elements at index: " + indx + ", smallerIndex: " + smallerElementIndex);

            indx = smallerElementIndex;
        }
    }

    public Point Peek()
    {
        if (_size >= 0) return arr[0];
        else return null;
    }

    public Point Pop()
    {
        if (_size >= 0)
        {
            var elementToReturn = arr[0];
            //Console.WriteLine("Returning element " + elementToReturn);
            arr[0] = arr[_size - 1];
            arr[_size - 1] = null;
            _size--;
            //PrintArray();
            Sink(0);

            return elementToReturn;
        }
        else
        {
            throw new Exception("Array is empty");
        }
    }

    public void PrintArray()
    {
        foreach (var r in arr)
        {
            Console.Write("[" + r.X + "," + r.Y + "], ");
        }
    }
}

var heap = new MinHeap(6);
heap.Add(1, 3);
heap.Add(-2, 4);
heap.Add(2, -1);
heap.Add(-2, 2);
heap.Add(5, -3);
heap.Add(3, -2);

int k = 3;

for (int i = 0; i < k; i++)
{
    var point = heap.Pop();
    Console.WriteLine("[" + point.X + ", " + point.Y + "]");
}
