using Aoc2020.Trees;
using NUnit.Framework;
using System.Collections.Generic;

namespace Aoc2020.Tests.Trees {

    [TestFixture]
    class TreeAreaTraverserTest {

        private TreeAreaTraverser treeAreaTraverser;

        [SetUp]
        public void SetUp() {
            string lines = "..##.......\n" +
                           "#...#...#..\n" +
                            ".#....#..#.\n" +
                            "..#.#...#.#\n" +
                            ".#...##..#.\n" +
                            "..#.##.....\n" +
                            ".#.#.#....#\n" +
                            ".#........#\n" +
                            "#.##...#...\n" +
                            "#...##....#\n" +
                            ".#..#...#.#";


            TreeArea treeArea = new TreeArea(new List<string>(lines.Split("\n")));
            treeAreaTraverser = new TreeAreaTraverser(treeArea);

        }


        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(3, 1, 7)]
        [TestCase(5, 1, 3)]
        [TestCase(7, 1, 4)]
        [TestCase(1, 2, 2)]
        public void TraverseTest(int right, int down, int expected) {
            Assert.AreEqual(expected, treeAreaTraverser.Traverse(right, down));
        }

     
    }
}
