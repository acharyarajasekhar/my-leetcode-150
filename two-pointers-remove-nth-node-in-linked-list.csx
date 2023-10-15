public class LinkedListNode
{
    public int Value;
    public LinkedListNode Next;
}

private LinkedListNode ToLinkedList(int[] arr)
{
    LinkedListNode head = null, prev = null;
    foreach (var a in arr)
    {
        var current = new LinkedListNode() { Value = a };
        if (head == null) head = current;
        if (prev != null) prev.Next = current;
        prev = current;
    }

    return head;
}

private void PrintLL(LinkedListNode h)
{
    var current = h;
    while (current != null)
    {
        Console.WriteLine(current.Value);
        current = current.Next;
    }
}

private void RemoveNthNode(LinkedListNode head, int n)
{
    var left = head;
    var right = head;
    for (int i = 0; i < n; i++)
    {
        right = right.Next;
    }

    while (right.Next != null)
    {
        left = left.Next;
        right = right.Next;
    }

    left.Next = left.Next.Next;
}

var head = ToLinkedList(new int[] { 23, 28, 10, 5, 67, 39, 70, 28 });
PrintLL(head);
Console.WriteLine("***********");
RemoveNthNode(head, 4);
PrintLL(head);
Console.WriteLine("***********");