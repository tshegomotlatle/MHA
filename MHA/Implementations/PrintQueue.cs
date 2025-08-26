

using MHA.Interfaces;

namespace MHA.Implementations;

public class PrintQueue : IBaseImplementation
{
    private readonly List<(int Key, int Value)> _updateOrdering;
    private readonly List<List<int>> _updates;

    public PrintQueue(List<(int, int)> ordering, List<List<int>> updates)
    {
        _updateOrdering = ordering;
        _updates = updates;
    }    

    public int Calculate()
    {
        List<List<int>> validUpdates = [];
        for (int k = 0; k < _updates.Count; k++)
        {
            bool isValid = false;
            for (int i = 0; i < _updates[k].Count; i++)
            {
                isValid = IsUpdateValid(_updates[k][i], _updates[k].Skip(i + 1));
                if (!isValid)
                {
                    break;
                }
            }

            if (isValid)
            {
                validUpdates.Add(_updates[k]);
            }
        }

        int total = CalculateTotalMiddleValues(validUpdates);

        return total;
    }

    private static int CalculateTotalMiddleValues(List<List<int>> validUpdates)
    {
        int sum = 0;
        for (int i = 0; i < validUpdates.Count ; i++)
        {
            sum += validUpdates[i][validUpdates[i].Count / 2];
        }

        return sum;
    }

    private bool IsUpdateValid(int currentUpdate, IEnumerable<int> upcomingUpdates)
    {
        foreach (int next in upcomingUpdates)
        {
            // if there is a rule that says "next must come before currentUpdate"
            // but we encounter currentUpdate first, that's invalid
            if (_updateOrdering.Any(x => x.Key == next && x.Value == currentUpdate))
            {
                return false;
            }
        }
        return true;
    }
}