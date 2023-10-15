public class Element
{
    public int Value { get; set; }
    public int Index { get; set; }
}

public class MaxHeap
{
    private readonly Element[] arr;
    private int _size = 0;

    public bool IsEmpty() => _size == 0;
    private bool IsRoot(int indx) => indx == 0;
    private bool HasLeftChild(int indx) => _size > GetLeftChildIndex(indx);
    private bool HasRightChild(int indx) => _size > GetRightChildIndex(indx);
    private bool HasParent(int indx) => GetParentIndex(indx) <= 0;
    private int GetLeftChildIndex(int indx) => (2 * indx) + 1;
    private int GetRightChildIndex(int indx) => (2 * indx) + 2;
    private int GetParentIndex(int indx) => (indx - 1) / 2;
    private Element GetLeftChild(int indx) => arr[GetLeftChildIndex(indx)];
    private Element GetRightChild(int indx) => arr[GetRightChildIndex(indx)];
    private Element GetParent(int indx) => arr[GetParentIndex(indx)];
    private Element GetElementAt(int indx) => arr[indx];

    public MaxHeap(int size)
    {
        arr = new Element[size];
    }

    public void Add(Element element)
    {
        //Console.WriteLine("Add element " + element + " at " + _size + " with size " + arr.Length);
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
        while (!IsRoot(indx) && GetParent(indx).Value < GetElementAt(indx).Value)
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
            var largestElementIndex = GetLeftChildIndex(indx);
            if (HasRightChild(indx) && GetRightChild(indx).Value > GetLeftChild(indx).Value)
            {
                largestElementIndex = GetRightChildIndex(indx);
            }

            //Console.WriteLine("index: " + indx + ", smallerIndex: " + largestElementIndex);

            if (GetElementAt(indx).Value >= GetElementAt(largestElementIndex).Value)
            {
                //Console.WriteLine("Break at index: " + indx + ", smallerIndex: " + largestElementIndex);
                break;
            }

            Swap(indx, largestElementIndex);

            //Console.WriteLine("Swap of elements at index: " + indx + ", smallerIndex: " + largestElementIndex);

            indx = largestElementIndex;
        }
    }

    public Element Peek()
    {
        if (_size >= 0)
        {
            return arr[0];
        }
        else
        {
            throw new Exception("Array is empty");
        }
    }

    public Element Pop()
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
            Console.Write(r + ", ");
        }
    }
}

var arr = new int[] { -4, 5, 4, -4, 4, 6, 7, 20 };
var k = 3;

var heap = new MaxHeap(arr.Length);

for (int i = 0; i < arr.Length; i++)
{
    while (!heap.IsEmpty() && heap.Peek().Index <= i - k) { heap.Pop(); }
    heap.Add(new Element() { Index = i, Value = arr[i] });
    if (i >= k - 1) Console.WriteLine(heap.Peek().Value);
}