using System.Collections.Generic;

namespace Aoc2020.Trees {
    public class TreeArea {

        public IList<char[]> Characters { get; private set; }

        public TreeArea(IList<string> lines) {
            Characters = new List<char[]>();
            foreach (string line in lines) {
                Characters.Add(line.ToCharArray());
            }
        }

    }
}
