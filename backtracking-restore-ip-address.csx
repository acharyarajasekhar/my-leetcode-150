private void Print(Stack<int> address)
{
    var temp = address.ToList();
    temp.Reverse();
    Console.WriteLine(string.Join(".", temp.ToArray()));
}

private void backtrack(string s, int i, Stack<int> address)
{
    if (address.Count == 4)
    {
        if (i == s.Length) { Print(address); }
        return;
    }

    for (int j = 1; j <= i + 4; j++)
    {
        if (i + j <= s.Length)
        {
            var ss = s.Substring(i, j);
            var ss_num = int.Parse(ss);
            if (ss_num >= 0 && ss_num <= 255 && !ss.StartsWith("0"))
            {
                address.Push(ss_num);
                backtrack(s, i + j, address);
                address.Pop();
            }
            else
            {
                break;
            }
        }
        else
        {
            break;
        }
    }
}


var address = new Stack<int>();
backtrack("1253412125", 0, address);
Console.WriteLine("---------------");
address.Clear();
backtrack("00000000", 0, address);
Console.WriteLine("---------------");
address.Clear();
backtrack("25525511135", 0, address);