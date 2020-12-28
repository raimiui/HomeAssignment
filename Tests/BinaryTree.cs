using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class BinaryTree
    {
        private int[][] _data;

        public BinaryTree(int[][] data)
        {
            if (data == null || data.Length == 0)
                throw new ArgumentException("Must provide non empty binary tree.");

            _data = data;

            FindValidPaths(0, 0, new List<int>());
        }

        public IList<IList<int>> ValidPaths { get; } = new List<IList<int>>();

        public int MaxSum => ValidPaths.Any() ? ValidPaths.Select(x => x.Sum()).Max() : -1;


        #region Private methods
        
        private void FindValidPaths(int i, int j, IList<int> currentPath)
        {
            currentPath.Add(_data[i][j]);

            if (currentPath.Count == _data.Length)
                ValidPaths.Add(currentPath);

            // save currentPath length in order to know how many items to copy to possible alternative path
            var currentPathLength = currentPath.Count;
            var needsAlternativePath = false;

            var nextValidItemsQueue = GetNextValidItems(i, j);
            while (nextValidItemsQueue.TryDequeue(out (int i, int j) item))
            {
                FindValidPaths(item.i, item.j, needsAlternativePath ? currentPath.Take(currentPathLength).ToList() : currentPath);
                needsAlternativePath = true;
            }
        }

        private Queue<(int i, int j)> GetNextValidItems(int i, int j)
        {
            var queue = new Queue<(int, int)>();

            if (i != _data.Length - 1) // while bottom is not reached
            {
                if((_data[i][j] + _data[i + 1][j]) % 2 == 1)
                    queue.Enqueue((i + 1, j));

                if ((_data[i][j] + _data[i + 1][j + 1]) % 2 == 1)
                    queue.Enqueue((i + 1, j + 1));
            }

            return queue;
        }
        
        #endregion Private methods
    }
}