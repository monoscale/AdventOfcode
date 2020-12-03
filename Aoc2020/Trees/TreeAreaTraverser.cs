namespace Aoc2020.Trees {
    public class TreeAreaTraverser {

        private TreeArea treeArea;

        public TreeAreaTraverser(TreeArea treeArea) {
            this.treeArea = treeArea;
        }


        /// <summary>
        /// Traverse the area using the slope and returns the amount of trees encountered.
        /// </summary>
        /// <returns></returns>
        public int Traverse(int right, int down) {
            int currentColumn = 0;
            int treeCount = 0;
            for (int currentRow = 0; currentRow < treeArea.Characters.Count; currentRow += down) {
                if (treeArea.Characters[currentRow][currentColumn % treeArea.Characters[0].Length] == '#') {
                    treeCount++;
                }
                currentColumn += right;
            }
            return treeCount;
        }

    }
}
