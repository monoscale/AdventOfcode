using Aoc2019.Geometry;
using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aoc2019.Days {
    /// <summary>
    /// The algorithm first determines the unique points of each wire.
    /// At last, we bruteforce a check for points which occur in the first wire and also in the second wire.
    /// 
    /// I tried implementing the minimum bounding box, but in practice this resulted in not much performance improvement, so it was deleted.
    /// </summary>
    public class Day3 : Day<int, int> {

        private HashSet<Point> uniquePointsOfFirstWire;
        private HashSet<Point> uniquePointsOfSecondWire;

        public override string Title => "Crossed Wires";

        protected override void ReadInput(StreamReader input) {
            uniquePointsOfFirstWire = ProcessLine(input.ReadLine());
            uniquePointsOfSecondWire = ProcessLine(input.ReadLine());
        }

        private HashSet<Point> ProcessLine(string line) {
            Point startPoint = new Point(0, 0);
            HashSet<Point> points = new HashSet<Point>();
            foreach (string part in line.Split(',')) {
                IList<Point> wirePoints = ProcessWirePart(startPoint, part);
                foreach (Point point in wirePoints) {
                    points.Add(point);
                }
                startPoint = wirePoints[wirePoints.Count - 1]; // last point is the startpoint of following wire
            }
            return points;
        }

        private IList<Point> ProcessWirePart(Point startPoint, string part) {
            Point previousPoint = startPoint;
            char direction = part[0];
            int count = int.Parse(part.Substring(1));

            IList<Point> points = new List<Point>();
            for (int i = 0; i < count; i++) {
                Point newPoint;
                switch (direction) {
                    case 'R': newPoint = new Point(previousPoint.X + 1, previousPoint.Y); break;
                    case 'U': newPoint = new Point(previousPoint.X, previousPoint.Y + 1); break;
                    case 'L': newPoint = new Point(previousPoint.X - 1, previousPoint.Y); break;
                    case 'D': newPoint = new Point(previousPoint.X, previousPoint.Y - 1); break;
                    default: newPoint = startPoint; break;
                }
                points.Add(newPoint);
                previousPoint = newPoint;
            }
            return points;
        }


        protected override int SolvePartOne() {
            List<Point> intersections = new List<Point>();
            foreach (Point p1 in uniquePointsOfFirstWire) {
                foreach (Point p2 in uniquePointsOfSecondWire) {
                    if (p1.Equals(p2)) {
                        intersections.Add(p1);
                    }
                }
            }

            return intersections.Min(p => Math.Abs(p.X) + Math.Abs(p.Y));
        }

        protected override int SolvePartTwo() {
            return 0;
        }
    }
}
