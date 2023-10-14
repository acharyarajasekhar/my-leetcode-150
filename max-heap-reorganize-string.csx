public class CharElement
{
    public char ch { get; set; }
    public int frequency { get; set; }
}

public class MaxHeap
{
    private readonly CharElement[] arr;
    private int _size = 0;

    private bool IsRoot(int indx) => indx == 0;
    private bool HasLeftChild(int indx) => _size > GetLeftChildIndex(indx);
    private bool HasRightChild(int indx) => _size > GetRightChildIndex(indx);
    private bool HasParent(int indx) => GetParentIndex(indx) <= 0;
    private int GetLeftChildIndex(int indx) => (2 * indx) + 1;
    private int GetRightChildIndex(int indx) => (2 * indx) + 2;
    private int GetParentIndex(int indx) => (indx - 1) / 2;
    private CharElement GetLeftChild(int indx) => arr[GetLeftChildIndex(indx)];
    private CharElement GetRightChild(int indx) => arr[GetRightChildIndex(indx)];
    private CharElement GetParent(int indx) => arr[GetParentIndex(indx)];
    private CharElement GetElementAt(int indx) => arr[indx];

    public MaxHeap(int size)
    {
        arr = new CharElement[size];
    }

    public void Add(char _ch, int _frequency)
    {
        //Console.WriteLine("Add element " + element + " at " + _size + " with size " + arr.Length);
        if (_size == arr.Length) Console.WriteLine("Array size is full");
        arr[_size] = new CharElement() { ch = _ch, frequency = _frequency };
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
        while (!IsRoot(indx) && GetParent(indx).frequency < GetElementAt(indx).frequency)
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
            if (HasRightChild(indx) && GetRightChild(indx).frequency > GetLeftChild(indx).frequency)
            {
                largestElementIndex = GetRightChildIndex(indx);
            }

            //Console.WriteLine("index: " + indx + ", smallerIndex: " + largestElementIndex);

            if (GetElementAt(indx).frequency >= GetElementAt(largestElementIndex).frequency)
            {
                //Console.WriteLine("Break at index: " + indx + ", smallerIndex: " + largestElementIndex);
                break;
            }

            Swap(indx, largestElementIndex);

            //Console.WriteLine("Swap of elements at index: " + indx + ", smallerIndex: " + largestElementIndex);

            indx = largestElementIndex;
        }
    }

    public CharElement Peek()
    {
        if (_size >= 0) return arr[0];
        else return null;
    }

    public CharElement Pop()
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
            Console.Write("[" + r.ch + "," + r.frequency + "], ");
        }
    }
}

string s = "programming";
var dict = new Dictionary<char, int>();
foreach (var c in s)
{
    if (dict.ContainsKey(c))
    {
        dict[c]++;
    }
    else dict.Add(c, 1);
}

var heap = new MaxHeap(dict.Count);

foreach (var d in dict)
{
    Console.WriteLine(d);
    heap.Add(d.Key, d.Value);
}

heap.PrintArray();

CharElement lastVisited = null;
string resultStr = "";
while (heap.Peek() != null)
{
    if (lastVisited != null && lastVisited.frequency > 0)
    {
        heap.Add(lastVisited.ch, lastVisited.frequency);
    }
    lastVisited = heap.Pop();
    resultStr += lastVisited.ch;
    lastVisited.frequency--;
}

Console.WriteLine("\n\nResult: " + resultStr);