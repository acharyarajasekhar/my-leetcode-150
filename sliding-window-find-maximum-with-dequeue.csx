public class DoubleEndedLinkedList
{
    public int Index { get; set; }
    public int Value { get; set; }
    public DoubleEndedLinkedList Next { get; set; }
    public DoubleEndedLinkedList Prev { get; set; }
}

public class DeQueue
{
    public DoubleEndedLinkedList Front { get; set; }
    public DoubleEndedLinkedList Back { get; set; }

    public void AddToFront(int val, int indx)
    {
        var current = new DoubleEndedLinkedList() { Value = val, Index = indx };
        if (Front == null)
        {
            Front = current;
            Back = current;
        }
        else
        {
            current.Next = Front;
            Front.Prev = current;
            Front = current;
        }
    }

    public void AddToBack(int val, int indx)
    {
        var current = new DoubleEndedLinkedList() { Value = val, Index = indx };
        if (Back == null)
        {
            Front = current;
            Back = current;
        }
        else
        {
            current.Prev = Back;
            Back.Next = current;
            Back = current;
        }
    }

    public void RemoveFromFront()
    {
        if (Front != null)
        {
            var temp = Front;
            var retValue = Front.Value;
            Front = Front.Next;
            temp = null;
        }
    }

    public void RemoveFromBack()
    {
        if (Back != null)
        {
            var temp = Back;
            var retValue = Back.Value;
            Back = Back.Prev;
            temp = null;
        }
    }

    public bool IsEmpty()
    {
        return Front == null;
    }
}

var arr = new int[] { -4, 5, 4, -4, 4, 6, 7, 20 };
var k = 3;

var dequeue = new DeQueue();

for (var i = 0; i < arr.Length; i++)
{
    if (!dequeue.IsEmpty() && dequeue.Front != null && dequeue.Front.Index <= i - k)
    {
        dequeue.RemoveFromFront();
    }
    while (!dequeue.IsEmpty() && dequeue.Back != null && dequeue.Back.Value < arr[i])
    {
        dequeue.RemoveFromBack();
    }
    dequeue.AddToBack(arr[i], i);
    if (i >= k - 1) Console.WriteLine(dequeue.Front.Value);
}