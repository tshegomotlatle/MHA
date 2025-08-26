using MHA.Implementations;
using MHA.Interfaces;
using System;
using System.Collections.Generic;

namespace MHA;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Running all implementations...\n");

        // Create array of BaseImplementation instances
        IBaseImplementation[] implementations = [
            CreateHistorianHysteria(),
            CreateRedNosedReport(),
            CreateMullItOver(),
            CreateCeresSearch(),
            CreatePrintQueue(),
            CreateGuardGallivant(),
            CreateBridgeRepair(),
            CreateResonantCollinearity()
        ];

        // Execute all implementations
        for (int i = 0; i < implementations.Length; i++)
        {
            string implementationName = implementations[i].GetType().Name;
            Console.WriteLine($"--- {implementationName} ---");

            try
            {
                int result = implementations[i].Calculate();
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
        }

        Console.WriteLine("All implementations completed.");
        Console.ReadKey();
    }

    private static HistorianHysteria CreateHistorianHysteria()
    {
        var list1 = new List<int> { 3, 4, 2, 1, 3, 3 };
        var list2 = new List<int> { 4, 3, 5, 3, 9, 3 };
        return new HistorianHysteria(list1, list2);
    }

    private static RedNosedReport CreateRedNosedReport()
    {
        var reports = new List<List<int>>
        {
            new List<int> { 7, 6, 4, 2, 1 },
            new List<int> { 1, 2, 7, 8, 9 },
            new List<int> { 9, 7, 6, 2, 1 },
            new List<int> { 1, 3, 2, 4, 5 },
            new List<int> { 8, 6, 4, 4, 1 },
            new List<int> { 1, 3, 6, 7, 9 }
        };
        return new RedNosedReport(reports);
    }

    private static MullItOver CreateMullItOver()
    {
        string corruptedMemory = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        return new MullItOver(corruptedMemory);
    }

    private static CeresSearch CreateCeresSearch()
    {
        var grid = new List<List<char>>
        {
            new List<char> { 'M', 'M', 'M', 'S', 'X', 'X', 'M', 'A', 'S', 'M' },
            new List<char> { 'M', 'S', 'A', 'M', 'X', 'M', 'S', 'M', 'S', 'A' },
            new List<char> { 'A', 'M', 'X', 'S', 'X', 'M', 'A', 'A', 'M', 'M' },
            new List<char> { 'M', 'S', 'A', 'M', 'A', 'S', 'M', 'S', 'M', 'X' },
            new List<char> { 'X', 'M', 'A', 'S', 'A', 'M', 'X', 'A', 'M', 'M' },
            new List<char> { 'X', 'X', 'A', 'M', 'M', 'X', 'X', 'A', 'M', 'A' },
            new List<char> { 'S', 'M', 'S', 'M', 'S', 'A', 'S', 'X', 'S', 'S' },
            new List<char> { 'S', 'A', 'X', 'A', 'M', 'A', 'S', 'A', 'A', 'A' },
            new List<char> { 'M', 'A', 'M', 'M', 'M', 'X', 'M', 'M', 'M', 'M' },
            new List<char> { 'M', 'X', 'M', 'X', 'A', 'X', 'M', 'A', 'S', 'X' }
        };
        return new CeresSearch(grid);
    }

    private static PrintQueue CreatePrintQueue()
    {
        var ordering = new List<(int, int)>
        {
            (47, 53), (97, 13), (97, 61), (97, 47), (75, 29), (61, 13), (75, 53),
            (29, 13), (97, 29), (53, 29), (61, 53), (97, 53), (61, 29), (47, 13),
            (75, 47), (97, 75), (47, 61), (75, 61), (47, 29), (75, 13), (53, 13)
        };

        var updates = new List<List<int>>
        {
            new List<int> { 75, 47, 61, 53, 29 },
            new List<int> { 97, 61, 53, 29, 13 },
            new List<int> { 75, 29, 13 },
            new List<int> { 75, 97, 47, 61, 53 },
            new List<int> { 61, 13, 29 },
            new List<int> { 97, 13, 75, 29, 47 }
        };

        return new PrintQueue(ordering, updates);
    }

    private static GuardGallivant CreateGuardGallivant()
    {
        var map = new List<List<char>>
        {
            new List<char> { '.', '.', '.', '.', '#', '.', '.', '.', '.', '.' },
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '.', '#' },
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
            new List<char> { '.', '.', '#', '.', '.', '.', '.', '.', '.', '.' },
            new List<char> { '.', '^', '.', '.', '.', '.', '.', '.', '.', '.' },
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '#', '.' },
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
            new List<char> { '.', '#', '.', '.', '^', '.', '.', '.', '.', '.' },
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '.', '#' },
            new List<char> { '#', '.', '.', '.', '.', '.', '.', '.', '.', '.' }
        };
        return new GuardGallivant(map);
    }

    private static BridgeRepair CreateBridgeRepair()
    {
        var equations = new List<(int Total, List<int> Values)>
        {
            (190, new List<int> { 10, 19 }),
            (3267, new List<int> { 81, 40, 27 }),
            (83, new List<int> { 17, 5 }),
            (156, new List<int> { 15, 6 }),
            (7290, new List<int> { 6, 8, 6, 15 }),
            (161011, new List<int> { 16, 10, 13 }),
            (192, new List<int> { 17, 8, 14 }),
            (21037, new List<int> { 9, 7, 18, 13 }),
            (292, new List<int> { 11, 6, 16, 20 })
        };
        return new BridgeRepair(equations);
    }

    private static ResonantCollinearity CreateResonantCollinearity()
    {
        var antennaMap = new List<List<char>>
        {
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '0', '.', '.', '.' },
            new List<char> { '.', '.', '.', '.', '.', '0', '.', '.', '.', '.', '.', '.' },
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '0', '.', '.', '.', '.' },
            new List<char> { '.', '.', '.', '.', '0', '.', '.', '.', '.', '.', '.', '.' },
            new List<char> { '.', '.', '.', '.', '.', '.', 'A', '.', '.', '.', '.', '.' },
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', 'A', '.', '.', '.' },
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '.', 'A', '.', '.' },
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
            new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' }
        };
        return new ResonantCollinearity(antennaMap);
    }
}