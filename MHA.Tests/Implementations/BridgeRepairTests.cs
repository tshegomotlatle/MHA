using System;
using System.Collections.Generic;
using Xunit;
using MHA.Implementations;

namespace MHA.Tests.Implementations
{
    public class BridgeRepairTests
    {
        [Fact]
        public void Calculate_WithSimpleAdditions_ReturnsCorrectCount()
        {
            // Arrange
            var input = new List<(int Total, List<int> Values)>
            {
                (5, new List<int>{2, 3}),   // 2 + 3 = 5
                (6, new List<int>{1, 2, 3}) // 1 + 2 + 3 = 6
            };
            var bridgeRepair = new BridgeRepair(input);

            // Act
            int result = bridgeRepair.Calculate();

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Calculate_WithMultiplication_ReturnsCorrectCount()
        {
            // Arrange
            var input = new List<(int Total, List<int> Values)>
            {
                (6, new List<int>{2, 3}),    // 2 * 3 = 6
                (24, new List<int>{2, 3, 4}) // 2 * 3 * 4 = 24
            };
            var bridgeRepair = new BridgeRepair(input);

            // Act
            int result = bridgeRepair.Calculate();

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Calculate_WithMixedOperators_ReturnsCorrectCount()
        {
            // Arrange
            var input = new List<(int Total, List<int> Values)>
            {
                (8, new List<int>{2, 3, 2}) // 2 * 3 + 2 = 8
            };
            var bridgeRepair = new BridgeRepair(input);

            // Act
            int result = bridgeRepair.Calculate();

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Calculate_WithNoMatchingCombination_ReturnsZero()
        {
            // Arrange
            var input = new List<(int Total, List<int> Values)>
            {
                (10, new List<int>{1, 2, 3}) // cannot reach 10 with add/multiply
            };
            var bridgeRepair = new BridgeRepair(input);

            // Act
            int result = bridgeRepair.Calculate();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Calculate_WithEmptyList_ReturnsZero()
        {
            // Arrange
            var input = new List<(int Total, List<int> Values)>();
            var bridgeRepair = new BridgeRepair(input);

            // Act
            int result = bridgeRepair.Calculate();

            // Assert
            Assert.Equal(0, result);
        }
    }
}
