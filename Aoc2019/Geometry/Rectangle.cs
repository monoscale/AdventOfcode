using System;
using System.Collections.Generic;
using System.Text;

namespace Aoc2019.Geometry {
    public class Rectangle {

        public Point LeftBottom { get; set; }
        public Point RightTop { get; set; }

        public Rectangle(Point lb, Point rt) {
            LeftBottom = lb;
            RightTop = rt;
        }

        public bool PointIsInRectangle(Point p) {
            return
                p.X >= LeftBottom.X &&
                p.Y >= LeftBottom.Y &&
                p.X <= RightTop.X &&
                p.Y <= RightTop.Y;
        }
    }
}
