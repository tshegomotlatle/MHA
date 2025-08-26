using MHA.Interfaces;
using MHA.Models.Enums;

namespace MHA.Implementations;

public class BridgeRepair : IBaseImplementation
{
    private readonly List<(int Total, List<int> Values)> _keyValuePairs;

    public BridgeRepair(List<(int Total, List<int> Values)> keyValuePairs)
    {
        _keyValuePairs = keyValuePairs;
    }
    
    public int Calculate()
    {
        int counter = 0;
        List<(int Total, List<int> Values)> result = [];
        List<List<Operators>> operatorsResults = [];

        for (int i = 0; i < _keyValuePairs.Count; i++)
        {
            List<List<Operators>> operators = GetOperatorPermutations(_keyValuePairs.ElementAt(i).Values.Count);

            for (int j = 0; j < operators.Count; j++)
            {
                int sum = CalculateSum(operators[j], _keyValuePairs.ElementAt(i).Values);
                if (sum == _keyValuePairs.ElementAt(i).Total)
                {
                    result.Add(_keyValuePairs.ElementAt(i));
                    operatorsResults.Add(operators[j]);
                    counter++;
                    break;
                }
            }
        }

        return counter;
    }

    private static List<List<Operators>> GetOperatorPermutations(int length)
    {
        var results = new List<List<Operators>>();
        Generate([], length, results);
        return results;
    }

    private static void Generate(List<Operators> current, int length, List<List<Operators>> results)
    {
        if (current.Count == length)
        {
            results.Add([.. current]);
            return;
        }

        // Try Add
        current.Add(Operators.Add);
        Generate(current, length, results);
        current.RemoveAt(current.Count - 1);

        // Try Multiply
        current.Add(Operators.Multiply);
        Generate(current, length, results);
        current.RemoveAt(current.Count - 1);
    }


    private static int CalculateSum(List<Operators> operators, List<int> list)
    {
        int sum = 0;
        for (int i = 0; i < operators.Count; i++)
        {
            if (operators[i] == Operators.Add)
            {
                sum += list[i];
            }
            else
            {
                sum *= list[i];
            }
        }

        return sum;
    }
}
