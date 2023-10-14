private void repeatedSubSeq(string s, int k)
{
    var dict = new Dictionary<string, int>();

    for (int i = 0; i <= s.Length - k; i++)
    {
        var subString = s.Substring(i, k);
        if (dict.ContainsKey(subString))
        {
            dict[subString]++;
        }
        else dict.Add(subString, 1);
    }

    foreach (var ss in dict.Where(d => d.Value > 1))
    {
        Console.WriteLine(ss.Key);
    }
}

var s = "GAGTCACAGTAGTTTCA";
var k = 3;

repeatedSubSeq(s, k);