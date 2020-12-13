using NUnit.Framework;
using System;
using System.Collections;

namespace Tests
{
    public class Tests
    {
        [TestCaseSource(nameof(MaxSumTestCases))]
        public void BinTreeManager_gets_maxSum(int[][] binTree, int expectedResult)
        {
            // Arrange
            var binTreeManager = new BinTreeService();

            // Act
            var result = binTreeManager.GetMaxSum(binTree);

            // Assert
            Assert.IsTrue(expectedResult == result, $"Expected: {expectedResult}, but was: {result}.");
        }

        [Test]
        public void BinTreeManager_GetMaxSum_ThrowsException_WhenEmptyDataProvided()
        {
            // Arrange
            var binTreeManager = new BinTreeService();

            // Assert
            Assert.That(() => binTreeManager.GetMaxSum(new int[][] { }), Throws.TypeOf<ArgumentException>());
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
            return Extensions.ConformToEvensOddsSequence(currentValue, nextValue);
        }

        static readonly object[] MaxSumTestCases =
        {
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
            },
            new object[] {
                new int[][]
                {
                    new []{       7       },
                    new []{      2,2      },
                    new []{     5,5,5     },
                    new []{    4,4,4,4    },
                    new []{   1,1,1,1,1   },
                    new []{  0,0,0,0,0,0  },
                    new []{ 1,1,1,1,1,1,1 },
                },
                20 // mulltiple even sums
            }
        };
    }
}