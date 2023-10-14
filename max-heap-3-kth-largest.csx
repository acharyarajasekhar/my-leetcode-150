public class MaxHeap
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
    private int GetElementAt(int indx) => arr[indx];

    public MaxHeap(int size)
    {
        arr = new int[size];
    }

    public void Add(int element)
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
        while (!IsRoot(indx) && GetParent(indx) < GetElementAt(indx))
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
            if (HasRightChild(indx) && GetRightChild(indx) > GetLeftChild(indx))
            {
                largestElementIndex = GetRightChildIndex(indx);
            }

            //Console.WriteLine("index: " + indx + ", smallerIndex: " + largestElementIndex);

            if (GetElementAt(indx) >= GetElementAt(largestElementIndex))
            {
                //Console.WriteLine("Break at index: " + indx + ", smallerIndex: " + largestElementIndex);
                break;
            }

            Swap(indx, largestElementIndex);

            //Console.WriteLine("Swap of elements at index: " + indx + ", smallerIndex: " + largestElementIndex);

            indx = largestElementIndex;
        }
    }

    public int Pop()
    {
        if (_size >= 0)
        {
            var elementToReturn = arr[0];
            //Console.WriteLine("Returning element " + elementToReturn);
            arr[0] = arr[_size - 1];
            arr[_size - 1] = 0;
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

var maxHeap = new MaxHeap(8);
maxHeap.Add(6);
maxHeap.Add(8);
maxHeap.Add(7);
maxHeap.Add(5);
maxHeap.Add(9);
maxHeap.Add(4);
maxHeap.Add(2);
maxHeap.Add(3);

maxHeap.PrintArray();

int k = 4;

Console.WriteLine("\n\nKth Largest Element: k=" + k + "\n");

var elementToReturn = 0;

for (int i = 0; i < k; i++)
{
    elementToReturn = maxHeap.Pop();
}

Console.WriteLine(elementToReturn);