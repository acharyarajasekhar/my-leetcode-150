private bool IsValidPlindrome(string s)
{
    var i = 0;
    var j = s.Length - 1;
    while (i <= j)
    {
        if (s[i] != s[j]) return false;
        i++; j--;
    }
    return true;
}

Console.WriteLine(IsValidPlindrome("kayak"));
Console.WriteLine(IsValidPlindrome("RACEACAR"));
Console.WriteLine(IsValidPlindrome("A"));