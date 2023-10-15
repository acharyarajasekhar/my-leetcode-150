private bool IsValidPlindrome(string s)
{
    var i = 0;
    var j = s.Length - 1;
    var k = 0;
    while (i <= j)
    {
        if (s[i] != s[j])
        {
            if (k != 0) return false;
            k++;
            if (s[i + 1] == s[j]) i++;
            if (s[i] == s[j - 1]) j--;
        }
        else
        {
            i++; j--;
        }
    }
    return true;
}

Console.WriteLine(IsValidPlindrome("kayak"));
Console.WriteLine(IsValidPlindrome("RACEACAR"));
Console.WriteLine(IsValidPlindrome("ABCEEBA"));
Console.WriteLine(IsValidPlindrome("ABEECBA"));
Console.WriteLine(IsValidPlindrome("ABGECBA"));
Console.WriteLine(IsValidPlindrome("kayakr"));
Console.WriteLine(IsValidPlindrome("A"));