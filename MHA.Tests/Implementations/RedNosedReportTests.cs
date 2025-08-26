using System.Collections.Generic;
using Xunit;
using MHA.Implementations;

namespace MHA.Tests.Implementations;
public class RedNosedReportTests
{
    [Fact]
    public void SingleReport_SingleElement_ShouldBeSafe()
    {
        var data = new List<List<int>> { new List<int> { 5 } };
        var report = new RedNosedReport(data);

        int result = report.Calculate();

        // A single element cannot violate rules -> Safe
        Assert.Equal(1, result);
    }

    [Fact]
    public void SingleReport_TwoElementsIncreasingWithinBounds_ShouldBeSafe()
    {
        var data = new List<List<int>> { new List<int> { 1, 3 } };
        var report = new RedNosedReport(data);

        int result = report.Calculate();

        Assert.Equal(1, result);
    }

    [Fact]
    public void SingleReport_TwoElementsIncreasingTooLarge_ShouldBeUnsafe()
    {
        var data = new List<List<int>> { new List<int> { 1, 10 } };
        var report = new RedNosedReport(data);

        int result = report.Calculate();

        Assert.Equal(0, result);
    }

    [Fact]
    public void SingleReport_TwoElementsEqual_ShouldBeUnsafe()
    {
        var data = new List<List<int>> { new List<int> { 4, 4 } };
        var report = new RedNosedReport(data);

        int result = report.Calculate();

        Assert.Equal(0, result);
    }

    [Fact]
    public void SingleReport_AlternatingUpAndDown_ShouldBeUnsafe()
    {
        var data = new List<List<int>> { new List<int> { 1, 3, 2, 4 } };
        var report = new RedNosedReport(data);

        int result = report.Calculate();

        Assert.Equal(0, result);
    }

    [Fact]
    public void MultipleReports_MixOfSafeAndUnsafe_ShouldCountCorrectly()
    {
        var data = new List<List<int>>
        {
            new List<int> { 5, 4, 3, 2, 1 }, // safe (strictly decreasing)
            new List<int> { 1, 2, 3, 4, 5 }, // safe (strictly increasing)
            new List<int> { 1, 2, 6 },       // unsafe (diff = 4)
            new List<int> { 9, 9, 9 },       // unsafe (no change)
            new List<int> { 2, 5, 8 }        // safe (all +3)
        };

        var report = new RedNosedReport(data);

        int result = report.Calculate();

        Assert.Equal(3, result); // 3 safe, 2 unsafe
    }

    [Fact]
    public void LargeReport_AllIncreasingWithinBounds_ShouldBeSafe()
    {
        var bigList = new List<int>();
        for (int i = 0; i < 1000; i++)
            bigList.Add(i + 1); // strictly +1 each step

        var data = new List<List<int>> { bigList };
        var report = new RedNosedReport(data);

        int result = report.Calculate();

        Assert.Equal(1, result);
    }

    [Fact]
    public void LargeReport_AllDecreasingWithinBounds_ShouldBeSafe()
    {
        var bigList = new List<int>();
        for (int i = 1000; i > 0; i--)
            bigList.Add(i); // strictly -1 each step

        var data = new List<List<int>> { bigList };
        var report = new RedNosedReport(data);

        int result = report.Calculate();

        Assert.Equal(1, result);
    }

    [Fact]
    public void LargeReport_WithInvalidJump_ShouldBeUnsafe()
    {
        var bigList = new List<int>();
        for (int i = 0; i < 500; i++)
            bigList.Add(i + 1);
        bigList.Add(1000); // huge jump

        var data = new List<List<int>> { bigList };
        var report = new RedNosedReport(data);

        int result = report.Calculate();

        Assert.Equal(0, result);
    }
}
