private string minWindow(string s, string t)
{
    if (string.IsNullOrEmpty(t)) return "";

    var tw = new Dictionary<char, int>();
    var sw = new Dictionary<char, int>();

    foreach (var c in t)
    {
        if (!tw.ContainsKey(c)) { tw.Add(c, 0); }
        tw[c]++;
    }

    int have = 0, need = tw.Count;
    int left = -1, right = -1, len = Int32.MaxValue;
    int l = 0, r = 0;
    for (; r < s.Length; r++)
    {
        if (!sw.ContainsKey(s[r])) sw.Add(s[r], 0);
        sw[s[r]]++;

        if (tw.ContainsKey(s[r]) && tw[s[r]] == sw[s[r]])
        {
            have++;
        }

        while (have == need)
        {
            //Console.WriteLine("******* " + s.Substring(l, r - l + 1));
            if ((r - l + 1) < len)
            {
                left = l;
                right = r;
                len = r - l + 1;
            }
            sw[s[l]]--;
            if (tw.ContainsKey(s[l]) && sw[s[l]] < tw[s[l]])
            {
                have--;
            }
            l++;
        }
    }

    //Console.WriteLine(s.Substring(left, right - left + 1));

    return s.Substring(left, right - left + 1);
}


Console.WriteLine(minWindow("cabwefgewcwaefgcf", "cae"));
Console.WriteLine(minWindow("cabwefgewcwaefgcf", "caee"));
Console.WriteLine(minWindow("cabwefgewcwaefgcf", "ffcaee"));
Console.WriteLine(minWindow("cabwefgewcwaefgcf", "ffcae"));