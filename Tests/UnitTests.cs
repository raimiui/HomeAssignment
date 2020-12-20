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
        public bool Extensions_ConformToEvensOddsSequence(int currentValue, int nextValue)
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
            },
            new object[] {
                new int[][]
                {
                    new []{ 215                                                         },
                    new []{ 192,124                                                     },
                    new []{ 117,269,442                                                 },
                    new []{ 218,836,347,235                                             },
                    new []{ 320,805,522,417,345                                         },
                    new []{ 229,601,728,835,133,124                                     },
                    new []{ 248,202,277,433,207,263,257                                 },
                    new []{ 359,464,504,528,516,716,871,182                             },
                    new []{ 461,441,426,656,863,560,380,171,923                         },
                    new []{ 381,348,573,533,448,632,387,176,975,449                     },
                    new []{ 223,711,445,645,245,543,931,532,937,541,444                 },
                    new []{ 330,131,333,928,376,733,017,778,839,168,197,197             },
                    new []{ 131,171,522,137,217,224,291,413,528,520,227,229,928         },
                    new []{ 223,626,034,683,839,052,627,310,713,999,629,817,410,121     },
                    new []{ 924,622,911,233,325,139,721,218,253,223,107,233,230,124,233 },
                },
                8186 // answer for the question from home assignment
            }
        };
    }
}