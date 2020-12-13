using System.Collections.Generic;

namespace Tests
{
    public static class Extensions
    {
        public static void TryAddNextItem(this Queue<BinTreeItem> queue, BinTreeItem currentItem, BinTreeItem nextPossibleItem)
        {
            if (ConformToEvensOddsSequence(currentItem.Value, nextPossibleItem.Value))
                queue.Enqueue(nextPossibleItem);
        }

        public static bool ConformToEvensOddsSequence(int x , int y)
        {
            return (x + y) % 2 == 1;
        }
    }
}
