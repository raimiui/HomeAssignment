using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class BinTreeManager
    {
        public int GetMaxSum(int[][] binTree)
        {
            var validPaths = GetValidPaths(binTree);
            return validPaths?.Any() ?? false ? validPaths.Select(x => x.Sum()).Max() : -1;
        }

        public IEnumerable<IList<int>> GetValidPaths(int[][] binTree, IList<int> currentPath = null, IList<IList<int>> validPaths = null, BinTreeItem currentItem = null)
        {
            if (!binTree.Any())
                return default;

            if (currentItem == null)
            {
                currentItem = new BinTreeItem(0, 0, binTree[0][0]);
                currentPath = new List<int>();
                validPaths = new List<IList<int>> { currentPath };
            }

            var nextValidItems = GetNextValidItems(binTree, currentItem);

            // add item to current path
            currentPath.Add(currentItem.Value);

            var alternativePath = new List<int>(currentPath);

            if (nextValidItems.TryDequeue(out BinTreeItem nextItem))
                GetValidPaths(binTree, currentPath, validPaths, nextItem);
            else if (binTree.Length != currentPath.Count)   // discard if path did not end
                validPaths.Remove(currentPath);

            if (nextValidItems.TryDequeue(out BinTreeItem nextItemAlternative))
            {
                validPaths.Add(alternativePath);
                GetValidPaths(binTree, alternativePath, validPaths, nextItemAlternative);
            }

            return validPaths;
        }

        public Queue<BinTreeItem> GetNextValidItems(int[][] binTree, BinTreeItem currentItem)
        {
            var result = new Queue<BinTreeItem>();

            // don't check if last line
            if (currentItem.X == binTree.Length - 1)
                return result;

            var nextPossibleItem1 = new BinTreeItem(currentItem.X + 1, currentItem.Y, binTree[currentItem.X + 1][currentItem.Y]);

            if (CanValueContinuePath(currentItem.Value, nextPossibleItem1.Value))
                result.Enqueue(nextPossibleItem1);

            var nextPossibleItem2 = new BinTreeItem(currentItem.X + 1, currentItem.Y + 1, binTree[currentItem.X + 1][currentItem.Y + 1]);
            if (CanValueContinuePath(currentItem.Value, nextPossibleItem2.Value))
                result.Enqueue(nextPossibleItem2);

            return result;
        }

        public bool CanValueContinuePath(int currentValue, int nextValue)
        {
            return (currentValue + nextValue) % 2 == 1;
        }
    }
}