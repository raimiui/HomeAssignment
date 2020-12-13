using System;
using System.Collections.Generic;

namespace Tests
{
    public class BinTree
    {
        public BinTree(int[][] data)
        {
            if (data.Length == 0)
                throw new ArgumentException("Must provide non empty binary tree.");

            Data = data;
        }
        public int[][] Data { get; private set; }
        public IList<IList<int>> ValidPaths { get; set; } = new List<IList<int>>();
    }
}