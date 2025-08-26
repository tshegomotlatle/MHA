using MHA.Implementations;

namespace MHA.Tests.Implementations
{
    public class CeresSearchTests
    {
        private CeresSearch CreateSearch(List<List<char>> grid) => new(grid);

        [Fact]
        public void FindsHorizontalForward()
        {
            var grid = new List<List<char>>
            {
                new() { 'x','m','a','s' }
            };

            Assert.Equal(1, CreateSearch(grid).Calculate());
        }

        [Fact]
        public void FindsHorizontalBackward()
        {
            var grid = new List<List<char>>
            {
                new() { 's','a','m','x' }
            };

            Assert.Equal(1, CreateSearch(grid).Calculate());
        }

        [Fact]
        public void FindsVerticalForward()
        {
            var grid = new List<List<char>>
            {
                new() { 'x' },
                new() { 'm' },
                new() { 'a' },
                new() { 's' },
            };

            Assert.Equal(1, CreateSearch(grid).Calculate());
        }

        [Fact]
        public void FindsVerticalBackward()
        {
            var grid = new List<List<char>>
            {
                new() { 's' },
                new() { 'a' },
                new() { 'm' },
                new() { 'x' },
            };

            Assert.Equal(1, CreateSearch(grid).Calculate());
        }

        [Fact]
        public void FindsDiagonalRightForward()
        {
            var grid = new List<List<char>>
            {
                new() { 'x','.','.','.' },
                new() { '.','m','.','.' },
                new() { '.','.','a','.' },
                new() { '.','.','.','s' },
            };

            Assert.Equal(1, CreateSearch(grid).Calculate());
        }

        [Fact]
        public void FindsDiagonalRightBackward()
        {
            var grid = new List<List<char>>
            {
                new() { 's','.','.','.' },
                new() { '.','a','.','.' },
                new() { '.','.','m','.' },
                new() { '.','.','.','x' },
            };

            Assert.Equal(1, CreateSearch(grid).Calculate());
        }

        [Fact]
        public void FindsDiagonalLeftForward()
        {
            var grid = new List<List<char>>
            {
                new() { '.','.','.','x' },
                new() { '.','.','m','.' },
                new() { '.','a','.','.' },
                new() { 's','.','.','.' },
            };

            Assert.Equal(1, CreateSearch(grid).Calculate());
        }

        [Fact]
        public void FindsDiagonalLeftBackward()
        {
            var grid = new List<List<char>>
            {
                new() { '.','.','.','s' },
                new() { '.','.','a','.' },
                new() { '.','m','.','.' },
                new() { 'x','.','.','.' },
            };

            Assert.Equal(1, CreateSearch(grid).Calculate());
        }

        [Fact]
        public void FindsMultipleInRow()
        {
            var grid = new List<List<char>>
            {
                new() { 'x','m','a','s','x','m','a','s' }
            };

            Assert.Equal(2, CreateSearch(grid).Calculate());
        }

        [Fact]
        public void FindsOverlapping()
        {
            var grid = new List<List<char>>
            {
                new() { 'x','m','a','s','a','m','x' }
            };

            // "xmas" (forward) and "samx" (backward) overlap
            Assert.Equal(2, CreateSearch(grid).Calculate());
        }

        [Fact]
        public void CaseInsensitiveMatch()
        {
            var grid = new List<List<char>>
            {
                new() { 'X','M','a','S' }
            };

            Assert.Equal(1, CreateSearch(grid).Calculate());
        }

        [Fact]
        public void NoMatches()
        {
            var grid = new List<List<char>>
            {
                new() { 'a','b','c','d' },
                new() { 'e','f','g','h' },
                new() { 'i','j','k','l' },
                new() { 'm','n','o','p' },
            };

            Assert.Equal(0, CreateSearch(grid).Calculate());
        }

        [Fact]
        public void EmptyGrid_ReturnsZero()
        {
            var grid = new List<List<char>>();
            Assert.Equal(0, CreateSearch(grid).Calculate());
        }

        [Fact]
        public void SingleRow_NotEnoughCharacters_ReturnsZero()
        {
            var grid = new List<List<char>> { new() { 'x', 'm', 'a' } };
            Assert.Equal(0, CreateSearch(grid).Calculate());
        }
    }
}
