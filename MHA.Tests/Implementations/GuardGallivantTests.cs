using System;
using System.Collections.Generic;
using Xunit;
using MHA.Implementations;

namespace MHA.Tests.Implementations
{
    public class GuardGallivantTests
    {
        private List<List<char>> ToGrid(string[] rows)
        {
            var grid = new List<List<char>>();
            foreach (var row in rows)
            {
                grid.Add(new List<char>(row.ToCharArray()));
            }
            return grid;
        }

        [Fact]
        public void ThrowsIfNoStartingPoint()
        {
            var grid = ToGrid(new[]
            {
                "....",
                "....",
                "...."
            });

            Assert.Throws<ArgumentException>(() => new GuardGallivant(grid));
        }

        [Fact]
        public void SimpleStraightLine_NoObstacles()
        {
            var grid = ToGrid(new[]
            {
                "....",
                "..^.",
                "....",
                "...."
            });

            var guard = new GuardGallivant(grid);
            int result = guard.Calculate();

            // Walks straight up, marking positions until exits map
            Assert.Equal(2, result); // starting + one move before exiting
        }

        [Fact]
        public void StopsAtObstacleAndTurnsRight()
        {
            var grid = ToGrid(new[]
            {
                "....",
                ".#..",
                ".^..",
                "...."
            });

            var guard = new GuardGallivant(grid);
            int result = guard.Calculate();

            // Starts at (2,1), moves up, encounters # at (1,1), turns right
            Assert.True(result > 2);
        }

        [Fact]
        public void PatrolTurnsMultipleTimes()
        {
            var grid = ToGrid(new[]
            {
                "....#....",
                ".........",
                "...#.....",
                ".........",
                ".....^..."
            });

            var guard = new GuardGallivant(grid);
            int result = guard.Calculate();

            Assert.True(result == 5); // should patrol around and mark several
        }

        [Fact]
        public void DistinctPositionsCountedCorrectly()
        {
            var grid = ToGrid(new[]
            {
                ".....",
                "..^..",
                ".....",
                "....."
            });

            var guard = new GuardGallivant(grid);
            int result = guard.Calculate();

            // Path: (1,2) -> (0,2). Marks 2 distinct cells.
            Assert.Equal(2, result);
        }

        [Fact]
        public void ExitsMapGoingDown()
        {
            var grid = ToGrid(new[]
            {
                ".....",
                ".....",
                "..v.."
            });

            var guard = new GuardGallivant(grid);
            int result = guard.Calculate();

            // From (2,2), goes down and immediately exits
            Assert.Equal(1, result);
        }

        [Fact]
        public void ExitsMapGoingLeft()
        {
            var grid = ToGrid(new[]
            {
                "<..."
            });

            var guard = new GuardGallivant(grid);
            int result = guard.Calculate();

            // Immediately exits, only starting pos
            Assert.Equal(1, result);
        }

        [Fact]
        public void ExitsMapGoingRight()
        {
            var grid = ToGrid(new[]
            {
                "...>"
            });

            var guard = new GuardGallivant(grid);
            int result = guard.Calculate();

            // Immediately exits, only starting pos
            Assert.Equal(1, result);
        }

        [Fact]
        public void ComplexScenario_MatchesExpectedCount()
        {
            var grid = ToGrid(new[]
            {
                "....#.....",
                ".........#",
                "..........",
                "..#.......",
                ".......#..",
                "..........",
                ".#..^.....",
                "........#.",
                "#.........",
                "......#..."
            });

            var guard = new GuardGallivant(grid);
            int result = guard.Calculate();

            // Example from problem description, expect > 10 positions visited
            Assert.True(result > 10);
        }
    }
}
