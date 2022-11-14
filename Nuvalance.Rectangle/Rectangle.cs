using System.Diagnostics;

namespace Nuvalance.Rectangle
{
    /// <summary>
    /// Representation of a rectangle in a cartesian coordinate system.
    /// </summary>
    [DebuggerDisplay("({PointA.X}, {PointA.Y}) ({PointC.X}, {PointC.Y})")]
    public class Rectangle
    {
        /// <summary>
        /// Initialize a new <see cref="Rectangle"/> class with the top left and bottom right points information.
        /// </summary>
        /// <param name="topLeft">Top left point.</param>
        /// <param name="rightBottom">Right bottom point.</param>
        public Rectangle(Point topLeft, Point rightBottom)
        {
            int leftX = Math.Min(topLeft.X, rightBottom.X);
            int rightX = Math.Max(topLeft.X, rightBottom.X);
            int topY = Math.Max(topLeft.Y, rightBottom.Y);
            int bottomY = Math.Min(topLeft.Y, rightBottom.Y);

            PointA = new Point(leftX, topY);
            PointB = new Point(rightX, topY);
            PointC = new Point(rightX, bottomY);
            PointD = new Point(leftX, bottomY);
        }

        /// <summary>
        /// Left top corner point
        /// </summary>
        public Point PointA { get; }

        /// <summary>
        /// Right top corner point
        /// </summary>
        public Point PointB { get; }

        /// <summary>
        /// Right bottom corner point
        /// </summary>
        public Point PointC { get; }

        /// <summary>
        /// Left bottom corner point
        /// </summary>
        public Point PointD { get; }

        /// <summary>
        /// Get an intersection result comparing the current to another rectangle.
        /// </summary>
        /// <param name="other">Other rectangle to compare with.</param>
        /// <returns>A IntersectionResult with the points of intersection.</returns>
        public IntersectionResult GetIntersection(Rectangle other)
        {
            if (!AreIntersected(other))
            {
                return IntersectionResult.NoIntersection;
            }
            var pointA = new Point(Math.Max(PointA.X, other.PointA.X), Math.Min(PointA.Y, other.PointA.Y));
            var pointC = new Point(Math.Min(PointC.X, other.PointC.X), Math.Max(PointC.Y, other.PointC.Y));
            var rectangle = new Rectangle(pointA, pointC);
            var points = new List<Point>();
            if (IsPointOnAnyAxis(rectangle.PointA) && other.IsPointOnAnyAxis(rectangle.PointA))
            {
                points.Add(rectangle.PointA);
            }
            if (IsPointOnAnyAxis(rectangle.PointB) && other.IsPointOnAnyAxis(rectangle.PointB))
            {
                points.Add(rectangle.PointB);
            }
            if (IsPointOnAnyAxis(rectangle.PointC) && other.IsPointOnAnyAxis(rectangle.PointC))
            {
                points.Add(rectangle.PointC);
            }
            if (IsPointOnAnyAxis(rectangle.PointD) && other.IsPointOnAnyAxis(rectangle.PointD))
            {
                points.Add(rectangle.PointD);
            }
            return new IntersectionResult(points.Distinct());
        }

        /// <summary>
        /// Indicates whether the given point is on the axis of the current rectangle.
        /// </summary>
        /// <param name="point">The point to compare with.</param>
        /// <returns>true if the point is on any axis; otherwise, false.</returns>
        public bool IsPointOnAnyAxis(Point point)
        {
            return PointA.IsOnTheSameAxis(point) ||
                PointB.IsOnTheSameAxis(point) ||
                PointC.IsOnTheSameAxis(point) ||
                PointD.IsOnTheSameAxis(point);
        }

        private bool AreIntersected(Rectangle other)
        {
            if (other == null)
            {
                return false;
            }

            // if rectangle has no area
            if (PointA.IsOnTheSameAxis(PointC) ||
                other.PointA.IsOnTheSameAxis(other.PointC))
            {
                return false;
            }

            // If one rectangle is located on left side of the other
            if (PointA.X > other.PointC.X ||
                other.PointA.X > PointC.X)
            {
                return false;
            }

            // If one rectangle is located above the other
            if (PointC.Y > other.PointA.Y ||
                other.PointC.Y > PointA.Y)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Represents the result of an intersection of two rectangles.
        /// It contains the information of the found points.
        /// </summary>
        public class IntersectionResult
        {
            /// <summary>
            /// No intersection result.
            /// </summary>
            public static IntersectionResult NoIntersection = new IntersectionResult();

            /// <summary>
            /// Initialized a new <see cref="IntersectionResult"/> class with the given points.
            /// </summary>
            /// <param name="interesectionPoints">The set of intersection points</param>
            public IntersectionResult(IEnumerable<Point> interesectionPoints)
            {
                Intersections = interesectionPoints ?? new List<Point>();
            }

            private IntersectionResult()
            {
                Intersections = new List<Point>();
            }

            /// <summary>
            /// List of intersections points.
            /// </summary>
            public IEnumerable<Point> Intersections { get; }

            /// <summary>
            /// Indicate wether or not the result is an intersection.
            /// </summary>
            public bool Result => Intersections.Any();
        }
    }
}