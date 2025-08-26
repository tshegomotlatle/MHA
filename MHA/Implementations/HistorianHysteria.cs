using MHA.Interfaces;

namespace MHA.Implementations;

public class HistorianHysteria : IBaseImplementation
{
    private readonly List<int> _list1;
    private readonly List<int> _list2;

    public HistorianHysteria(List<int> list1, List<int> list2)
    {
        _list1 = list1;
        _list2 = list2;
    }

    public int Calculate()
    {
        //Sort both lists
        _list1.Sort();
        _list2.Sort();

        List<int> listDifferences = [];
        int totalDifference = 0;

        for (int i = 0; i < _list1.Count && i < _list2.Count; i++)
        {
            listDifferences.Add(Math.Abs(_list1[i] - _list2[i]));
            totalDifference += listDifferences[i];
        }

        listDifferences.ForEach(item =>
        {
            Console.WriteLine(item);
        });

        return totalDifference;
    }
}
