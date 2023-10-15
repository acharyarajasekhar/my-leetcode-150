private void ReverseTheWordsInString(char[] ch)
{
    Console.WriteLine(ch);

    var n = ch.Length;
    for (int i = 0, j = n - 1; i < j; i++, j--)
    {
        Swap(ch, i, j);
    }

    Console.WriteLine(ch);

    int start = 0, end = 0;
    while (end < n)
    {
        if (ch[end] != ' ')
        {
            end++;
        }
        else
        {
            ReverseWord(ch, start, end);
            start = end + 1;
            end = end + 1;
        }
    }

    ReverseWord(ch, start, end);

    Console.WriteLine(ch);
}

private void ReverseWord(char[] ch, int start, int end)
{
    for (int k = start, l = end - 1; k < l; k++, l--)
    {
        Swap(ch, k, l);
    }
}

private void Swap(char[] s, int i, int j)
{
    var temp = s[i];
    s[i] = s[j];
    s[j] = temp;
}

var s = "Acharya Raja Sekhar Brundhavanam";
ReverseTheWordsInString(s.ToCharArray());
Console.WriteLine();