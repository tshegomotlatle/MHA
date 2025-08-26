using System.Text.RegularExpressions;
using MHA.Interfaces;

namespace MHA.Implementations;

public class MullItOver : IBaseImplementation
{
    private readonly string _corruptedMemory;
    
    public MullItOver(string corruptMemory)
    {
        _corruptedMemory = corruptMemory;
    }

    public int Calculate()
    {
        var sum = 0;
        var regex = @"mul\((\d{1,3}),(\d{1,3})\)";
        var matches = Regex.Matches(_corruptedMemory, regex);

        foreach (Match match in matches)
        {
            string a = match.Groups[1].Value;
            string b = match.Groups[2].Value;

            sum += int.Parse(a) * int.Parse(b);
        }

        return sum;
    }

    
}