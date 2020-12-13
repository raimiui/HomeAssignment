using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(0, 1, ExpectedResult = true)]
        [TestCase(1, 0, ExpectedResult = true)]
        [TestCase(1, 2, ExpectedResult = true)]
        [TestCase(2, 1, ExpectedResult = true)]
        [TestCase(7, 10, ExpectedResult = true)]
        [TestCase(10, 7, ExpectedResult = true)]
        [TestCase(1, 1, ExpectedResult = false)]
        [TestCase(1, 11, ExpectedResult = false)]
        [TestCase(10, 10, ExpectedResult = false)]
        [TestCase(10, 20, ExpectedResult = false)]
        public bool BinTree_CanValueContinuePath(int currentValue, int nextValue)
        {
            // Arrange
            var binTree = new BinTreeManager();

            // Act
            var result = binTree.CanValueContinuePath(currentValue, nextValue);

            // Assert
            return result;
        }


        [TestCaseSource(nameof(MaxSumTestCases))]
        public void BinTreeManager_gets_maxSum(int[][] binTree, int expectedResult)
        {
            // Arrange
            var binTreeManager = new BinTreeManager();

            // Act
            var result = binTreeManager.GetMaxSum(binTree);

            // Assert
            Assert.IsTrue(expectedResult == result, $"Expected: {expectedResult}, but was: {result}.");
        }

        static object[] MaxSumTestCases =
        {
            new object[] {
                new int[][] {},
                -1 // no paths (empty input)
            },
            new object[] {
                new int[][]
                {
                    new []{    1    },
                    new []{   1,3   },
                },
                -1 // no paths (2 levels)
            },
            new object[] {
                new int[][]
                {
                    new []{    1    },
                    new []{   1,2   },
                    new []{  7,8,30  },
                },
                -1 // no paths (3 levels)
            },
            new object[] {
                new int[][]
                {
                    new []{    551    },
                },
                551 // has path (single level)
            },
            new object[] {
                new int[][]
                {
                    new []{    1    },
                    new []{   1,2   },
                    new []{  7,8,3  },
                    new []{ 1,2,4,3 },
                },
                10 // counts max for a single possible path (1,2,3,4)
            },
            new object[] {
                new int[][]
                {
                    new []{    1    },
                    new []{   1,2   },
                    new []{  7,8,3  },
                    new []{ 1,2,6,4 },
                },
                12 // selects max path when 2 possible (1,2,3,6)
            },
            new object[] {
                new int[][]
                {
                    new []{    1    },
                    new []{   1,2   },
                    new []{  7,8,3  },
                    new []{ 1,2,4,6 },
                },
                12 // selects max path when 2 possible variant 2 (1,2,3,6)
            },
            new object[] {
                new int[][]
                {
                    new []{    1    },
                    new []{   8,9   },
                    new []{  1,5,9  },
                    new []{ 4,5,2,3 },
                },
                16 // provided case
            },
            new object[] {
                new int[][]
                {
                    new []{      1      },
                    new []{     8,6     },
                    new []{    1,5,9    },
                    new []{   4,5,2,8   },
                    new []{  7,8,4,5,2  },
                    new []{ 1,5,4,5,2,8 },
                },
                31 // random case
            }
        };
    }
}