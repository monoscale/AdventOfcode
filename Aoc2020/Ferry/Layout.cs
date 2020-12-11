using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Ferry {
    public class Layout {

        private IList<List<char>> grid;

        public Layout(IList<List<char>> grid) {
            this.grid = grid;

            grid.Prepend(new string('.', grid[0].Count).ToCharArray().ToList());
            grid.Add(new string('.', grid[0].Count).ToCharArray().ToList());
        }



        private void NextIteration() {
            var copy = grid;

            for (int i = 0; i < grid.Count; i++) {
                for (int j = 0; j < grid[i].Count; j++) {
                    char c = grid[i][j];
                    if (c == 'L') {
                        NoOccupiedAdjacentSeats(i, j);
                    }
                }
            }
        }

        private bool NoOccupiedAdjacentSeats(int i, int j) {
            IList<char> adjacentSeats = new List<char> {
                grid[i - 1][j-1],
                grid[i-1][j],
                grid[i-1][j+1],
                grid[i][j-1],
                grid[i][j],
                grid[i][j+1],
                grid[i + 1][j-1],
                grid[i + 1][j],
                grid[i + 1][j+1]
                };
        }


    }
}
