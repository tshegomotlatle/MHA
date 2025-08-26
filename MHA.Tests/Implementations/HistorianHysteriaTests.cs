using System;
using System.Collections.Generic;
using Xunit;
using MHA.Implementations;

namespace MHA.Tests.Implementations;
public class HistorianHysteriaTests
{
    [Fact]
    public void ExampleFromPrompt_ShouldReturn11()
    {
        // AoC Day 1 example
        var list1 = new List<int> { 3, 4, 2, 1, 3, 3 };
        var list2 = new List<int> { 4, 3, 5, 3, 9, 3 };

        var hysteria = new HistorianHysteria(list1, list2);
        int result = hysteria.Calculate();

        Assert.Equal(11, result);
    }

    [Fact]
    public void EqualLists_ShouldReturnZero()
    {
        var list1 = new List<int> { 1, 2, 3, 4, 5 };
        var list2 = new List<int> { 1, 2, 3, 4, 5 };

        var hysteria = new HistorianHysteria(list1, list2);
        int result = hysteria.Calculate();

        Assert.Equal(0, result);
    }

    [Fact]
    public void CompletelyDifferentLists_ShouldReturnMaxDifference()
    {
        var list1 = new List<int> { 1, 1, 1 };
        var list2 = new List<int> { 9, 9, 9 };

        var hysteria = new HistorianHysteria(list1, list2);
        int result = hysteria.Calculate();

        Assert.Equal(24, result); // (9-1) + (9-1) + (9-1)
    }

    [Fact]
    public void OneListEmpty_ShouldReturnZero()
    {
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int>();

        var hysteria = new HistorianHysteria(list1, list2);
        int result = hysteria.Calculate();

        Assert.Equal(0, result);
    }

    [Fact]
    public void BothListsEmpty_ShouldReturnZero()
    {
        var list1 = new List<int>();
        var list2 = new List<int>();

        var hysteria = new HistorianHysteria(list1, list2);
        int result = hysteria.Calculate();

        Assert.Equal(0, result);
    }

    [Fact]
    public void UnequalLengths_ShouldCompareOnlyMinCount()
    {
        var list1 = new List<int> { 1, 5, 9 };
        var list2 = new List<int> { 2, 6 };

        var hysteria = new HistorianHysteria(list1, list2);
        int result = hysteria.Calculate();

        // After sorting:
        // list1: 1,5,9
        // list2: 2,6
        // Compare pairs: |1-2|=1, |5-6|=1 → total=2
        Assert.Equal(2, result);
    }

    [Fact]
    public void NegativeNumbers_ShouldWorkCorrectly()
    {
        var list1 = new List<int> { -5, -1, -3 };
        var list2 = new List<int> { -2, -4, -6 };

        var hysteria = new HistorianHysteria(list1, list2);
        int result = hysteria.Calculate();

        // Sort:
        // list1: -5,-3,-1
        // list2: -6,-4,-2
        // | -5-(-6) |=1, | -3-(-4) |=1, | -1-(-2) |=1 → total=3
        Assert.Equal(3, result);
    }

    [Fact]
    public void SingleElementLists_ShouldReturnDifference()
    {
        var list1 = new List<int> { 42 };
        var list2 = new List<int> { 40 };

        var hysteria = new HistorianHysteria(list1, list2);
        int result = hysteria.Calculate();

        Assert.Equal(2, result);
    }
}
