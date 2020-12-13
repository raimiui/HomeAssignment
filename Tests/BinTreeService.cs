using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class BinTreeService
    {
        /// <summary>
        /// Gets valid paths, for each counts sums of items and returns max sum
        /// </summary>
        public int GetMaxSum(int[][] binTreeData)
        {
            var validPaths = GetValidPaths(new BinTree(binTreeData));
            return validPaths?.Any() ?? false ? validPaths.Select(x => x.Sum()).Max() : -1;
        }

        public IEnumerable<IList<int>> GetValidPaths(BinTree binTree)
        {
            var startItem = new BinTreeItem(0, 0, binTree.Data[0][0]);
            return GetValidPaths(binTree, startItem, new List<int>());
        }

        private IEnumerable<IList<int>> GetValidPaths(BinTree binTree, BinTreeItem currentItem, IList<int> currentPath)
        {
            currentPath.Add(currentItem.Value);

            // if path reached the end - add to validPaths
            if (binTree.Data.Length == currentPath.Count)
                binTree.ValidPaths.Add(currentPath);

            // save currentPath length in order to know how many items to copy to possible alternative path
            var currentPathLength = currentPath.Count;
            
            var nextValidItemsQueue = GetNextValidItems(binTree.Data, currentItem);

            var needsAlternativePath = false;
            while (nextValidItemsQueue.TryDequeue(out BinTreeItem item))
            {
                GetValidPaths(binTree, item, needsAlternativePath ? currentPath.Take(currentPathLength).ToList() : currentPath);
                needsAlternativePath = true;
            }

            return binTree.ValidPaths;
        }

        private Queue<BinTreeItem> GetNextValidItems(int[][] binTree, BinTreeItem currentItem)
        {
            var result = new Queue<BinTreeItem>();

            if (currentItem.X != binTree.Length - 1) // wile bottom is not reached
            {
                result.TryAddNextItem(currentItem, new BinTreeItem(currentItem.X + 1, currentItem.Y, binTree[currentItem.X + 1][currentItem.Y]));
                result.TryAddNextItem(currentItem, new BinTreeItem(currentItem.X + 1, currentItem.Y + 1, binTree[currentItem.X + 1][currentItem.Y + 1]));
            }

            return result;
        }
    }
}