using System;
using System.Collections.Generic;
using Xunit;
using MHA.Implementations;

namespace MHA.Tests.Implementations
{
    public class PrintQueueTests
    {
        private PrintQueue CreateQueue(
            List<(int, int)> ordering,
            List<List<int>> updates) => new(ordering, updates);

        [Fact]
        public void SingleUpdate_ValidOrder_ReturnsMiddleValue()
        {
            var ordering = new List<(int, int)>
            {
                (47, 53)
            };

            var updates = new List<List<int>>
            {
                new() { 75, 47, 61, 53, 29 } // 47 before 53
            };

            var queue = CreateQueue(ordering, updates);

            // Middle = index 2 => 61
            Assert.Equal(61, queue.Calculate());
        }

        [Fact]
        public void SingleUpdate_InvalidOrder_ReturnsZero()
        {
            var ordering = new List<(int, int)>
            {
                (47, 53)
            };

            var updates = new List<List<int>>
            {
                new() { 75, 53, 61, 47, 29 } // 53 before 47 -> invalid
            };

            var queue = CreateQueue(ordering, updates);

            Assert.Equal(0, queue.Calculate());
        }

        [Fact]
        public void MultipleUpdates_MixedValidity_ReturnsSumOfValidMiddles()
        {
            var ordering = new List<(int, int)>
            {
                (47, 53),
                (61, 29)
            };

            var updates = new List<List<int>>
            {
                new() { 75, 47, 61, 53, 29 },  // valid: middle = 61
                new() { 75, 53, 61, 47, 29 },  // invalid (53 before 47)
                new() { 61, 29, 47, 53, 75 }   // valid: middle = 47
            };

            var queue = CreateQueue(ordering, updates);

            Assert.Equal(108, queue.Calculate()); // 61 + 47
        }

        [Fact]
        public void Update_IrrelevantPages_StillValid()
        {
            var ordering = new List<(int, int)>
            {
                (47, 53)
            };

            var updates = new List<List<int>>
            {
                new() { 10, 20, 30 } // no 47 or 53, should be valid
            };

            var queue = CreateQueue(ordering, updates);

            Assert.Equal(20, queue.Calculate()); // middle = 20
        }

        [Fact]
        public void EmptyUpdateList_ReturnsZero()
        {
            var ordering = new List<(int, int)> { (1, 2) };
            var updates = new List<List<int>>();

            var queue = CreateQueue(ordering, updates);

            Assert.Equal(0, queue.Calculate());
        }

        [Fact]
        public void SinglePageUpdate_AlwaysValid()
        {
            var ordering = new List<(int, int)>
            {
                (47, 53)
            };

            var updates = new List<List<int>>
            {
                new() { 47 }
            };

            var queue = CreateQueue(ordering, updates);

            Assert.Equal(47, queue.Calculate()); // only one element = middle
        }

        [Fact]
        public void TwoPageUpdate_ValidAccordingToRule()
        {
            var ordering = new List<(int, int)>
            {
                (47, 53)
            };

            var updates = new List<List<int>>
            {
                new() { 47, 53 } // valid
            };

            var queue = CreateQueue(ordering, updates);

            Assert.Equal(53, queue.Calculate()); // middle = second element
        }

        [Fact]
        public void TwoPageUpdate_InvalidAccordingToRule()
        {
            var ordering = new List<(int, int)>
            {
                (47, 53)
            };

            var updates = new List<List<int>>
            {
                new() { 53, 47 } // invalid
            };

            var queue = CreateQueue(ordering, updates);

            Assert.Equal(0, queue.Calculate());
        }

        [Fact]
        public void MultipleRules_AllMustBeSatisfied()
        {
            var ordering = new List<(int, int)>
            {
                (10, 20),
                (20, 30),
                (30, 40)
            };

            var updates = new List<List<int>>
            {
                new() { 10, 20, 30, 40 },  // valid
                new() { 40, 30, 20, 10 }   // invalid
            };

            var queue = CreateQueue(ordering, updates);

            // only first is valid: middle of 10,20,30,40 = index 2 = 30
            Assert.Equal(30, queue.Calculate());
        }

        [Fact]
        public void ComplexUpdate_WithUnrelatedPages_StillRespectsRules()
        {
            var ordering = new List<(int, int)>
            {
                (47, 53),
                (61, 29)
            };

            var updates = new List<List<int>>
            {
                new() { 100, 47, 200, 61, 53, 29, 300 }
            };

            var queue = CreateQueue(ordering, updates);

            // 61 must come before 29 -> true
            // 47 before 53 -> true
            // middle = index 3 (61)
            Assert.Equal(61, queue.Calculate());
        }
    }
}
