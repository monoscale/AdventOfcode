using Aoc2020.Trees;
using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aoc2020.Days {
    public class Day3 : Day<int, long> {
        public override string Title => "Toboggan Trajectory";

        private TreeAreaTraverser treeAreaTraverser;

        protected override void ReadInput(StreamReader input) {
            List<string> lines = new List<string>();
            string line;
            while ((line = input.ReadLine()) != null) {
                lines.Add(line);
            }
            TreeArea treeArea = new TreeArea(lines);
            treeAreaTraverser = new TreeAreaTraverser(treeArea);
        }

        protected override int SolvePartOne() {
            return treeAreaTraverser.Traverse(3, 1);
        }

        protected override long SolvePartTwo() {
            List<Tuple<int, int>> slopes = new List<Tuple<int, int>>();
            slopes.Add(new Tuple<int, int>(1, 1));
            slopes.Add(new Tuple<int, int>(3, 1));
            slopes.Add(new Tuple<int, int>(5, 1));
            slopes.Add(new Tuple<int, int>(7, 1));
            slopes.Add(new Tuple<int, int>(1, 2));
            return slopes
                .Select(slope => treeAreaTraverser.Traverse(slope.Item1, slope.Item2))
                .Select(i => Convert.ToInt64(i)) // convert to long because the resulting number is too large
                .Aggregate(1L, (acc, x) => acc * x);
        }
    }
}
