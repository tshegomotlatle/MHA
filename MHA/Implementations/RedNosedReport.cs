using MHA.Interfaces;

namespace MHA.Implementations;

public class RedNosedReport : IBaseImplementation
{
    private List<List<int>> _list;

    public RedNosedReport(List<List<int>> list){
        _list = list;
    }

    public int Calculate()
    {
        int countSafe = 0;
        for (int k = 0; k < _list.Count; k++)
        {
            bool isSafe = true;
            int? previousValue = null;
            List<int> list = [];

            // Added efficiency if the list is found to be not safe already dont bother with the rest of the calculations
            for (int i = 0; i < _list[k].Count && isSafe == true; i++)
            {
                var currentValue = _list[k][i];

                //First item in the list
                if (previousValue == null)
                {
                    previousValue = _list[k][i];
                    continue;
                }
                
                // Difference between current value and previous value
                var valueDifference = currentValue - previousValue;

                // assign new previous value
                previousValue = currentValue;

                // If value difference is 0, then we are neither increasing nor decreasing
                if (valueDifference == 0 || Math.Abs(valueDifference.Value) > 3)
                {
                    isSafe = false;
                }
                else // else add to list to check later
                {
                    list.Add(valueDifference.Value);
                }
                Console.Write(valueDifference.ToString() + " ");

            }

            Console.WriteLine();
            if (isSafe && (list.TrueForAll(x => x > 0) || list.TrueForAll(x => x < 0)))
            {
                countSafe++;
            }
        }

        return countSafe;
    }
}
