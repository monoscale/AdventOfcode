using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc2020.Ferry {
    public class Layout {

        private IList<List<char>> grid;

        public Layout(IList<List<char>> grid) {
            this.grid = grid;
            foreach (IList<char> row in grid) {
                row.Insert(0, '.');
                row.Add('.');
            }

            grid.Insert(0, new string('.', grid[0].Count).ToCharArray().ToList());
            grid.Add(new string('.', grid[0].Count).ToCharArray().ToList());
        }

        public int GetOccupiedSeats() {
            int count = 0;
            foreach(var row in grid) {
                count += row.Count(c => c.Equals('#'));
            }
            return count;
        }


        public void RunUntilStabilized() {
            IList<List<char>> previous;
            do {
                previous = MakeCopy(grid);
                NextIteration();
            } while (AnyChanges(previous));
        }

        private bool AnyChanges(IList<List<char>> previous) {
            int i = 0, j = 0;
            while (i < previous.Count && previous[i][j].Equals(grid[i][j])) {
                j++;
                if (j == previous[i].Count) {
                    i++;
                    j = 0;
                }
            }

            return i != previous.Count || j != 0;
        }

        public string PrettyPrint() {
            StringBuilder builder = new StringBuilder();
            foreach(var row in grid) {
                foreach(char c in row) {
                    builder.Append(c);
                }
                builder.Append("\n");
            }

            return builder.ToString();
        }

        public void NextIteration() {
            var copy = MakeCopy(grid);

            for (int i = 1; i < grid.Count - 1; i++) {
                for (int j = 1; j < grid[i].Count - 1; j++) {
                    char c = grid[i][j];
                    if (c == 'L' && NoOccupiedAdjacentSeats(i, j)) {
                        copy[i][j] = '#';
                    } else if (c == '#' && FourOrMoreOccupiedAdjacentSeats(i, j)) {
                        copy[i][j] = 'L';
                    }
                }
            }
            grid = MakeCopy(copy);
        }

        private IList<List<char>> MakeCopy(IList<List<char>> gridToCopy) {
            IList<List<char>> copy = new List<List<char>>(gridToCopy.Count);
            for (int i = 0; i < gridToCopy.Count; i++) {
                List<char> row = new List<char>(gridToCopy[i].Count);
                for (int j = 0; j < gridToCopy[i].Count; j++) {
                    row.Add(gridToCopy[i][j]);
                }
                copy.Add(row);
            }
            return copy;
        }

        private bool NoOccupiedAdjacentSeats(int i, int j) {
            IList<char> adjacentSeats = new List<char> {
                grid[i - 1][j-1],
                grid[i-1][j],
                grid[i-1][j+1],
                grid[i][j-1],
                grid[i][j+1],
                grid[i + 1][j-1],
                grid[i + 1][j],
                grid[i + 1][j+1]
                };

            return adjacentSeats.All(c => !c.Equals('#'));
        }

        private bool FourOrMoreOccupiedAdjacentSeats(int i, int j) {
            IList<char> adjacentSeats = new List<char> {
                grid[i - 1][j-1],
                grid[i-1][j],
                grid[i-1][j+1],
                grid[i][j-1],
                grid[i][j+1],
                grid[i + 1][j-1],
                grid[i + 1][j],
                grid[i + 1][j+1]
                };
            return adjacentSeats.Where(c => c.Equals('#')).Count() >= 4;
        }


    }
}
