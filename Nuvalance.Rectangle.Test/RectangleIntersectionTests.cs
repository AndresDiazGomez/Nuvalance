namespace Nuvalance.Rectangle.Test
{
    public class RectangleIntersectionTests
    {
        [Fact]
        public void Rectangle_GetFirstIntersection()
        {
            var rectangleOne = GetRectangle_X1Y2_X3Y0();
            var rectangleTwo = GetRectangle_X0Y3_X2Y1();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(1, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetSecondIntersection()
        {
            var rectangleOne = GetRectangle_X0Y3_X2Y1();
            var rectangleTwo = GetRectangle_X1Y2_X3Y0();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(1, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetThirdIntersection()
        {
            var rectangleOne = GetRectangle_X1Y3_X3Y1();
            var rectangleTwo = GetRectangle_X0Y2_X2Y0();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(1, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetFourthIntersection()
        {
            var rectangleOne = GetRectangle_X0Y2_X2Y0();
            var rectangleTwo = GetRectangle_X1Y3_X3Y1();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(1, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetFifthIntersection()
        {
            var rectangleOne = GetRectangle_X0Y2_X2Y0();
            var rectangleTwo = GetRectangle_X2Y2_X4Y0();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(0, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetSixthIntersection()
        {
            var rectangleOne = GetRectangle_X0Y3_X3Y1();
            var rectangleTwo = GetRectangle_X1Y2_X2Y0();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(1, item.Y);
                },
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(1, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetSeventhIntersection()
        {
            var rectangleOne = GetRectangle_X0Y2_X3Y1();
            var rectangleTwo = GetRectangle_X1Y3_X2Y0();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(1, item.Y);
                },
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(1, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetEighthIntersection()
        {
            var rectangleOne = GetRectangle_X0Y8_X10Y0();
            var rectangleTwo = GetRectangle_X2Y9_X7Y3();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(8, item.Y);
                },
                item =>
                {
                    Assert.Equal(7, item.X);
                    Assert.Equal(8, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetNoIntersection()
        {
            var rectangleOne = GetRectangle_X0Y2_X2Y0();
            var rectangleTwo = GetRectangle_X3Y2_X5Y0();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.False(intersection.Result);
        }

        private Rectangle GetRectangle_X1Y2_X3Y0()
        {
            var pointA = new Point(1, 2);
            var pointC = new Point(3, 0);
            return new Rectangle(pointA, pointC);
        }

        private Rectangle GetRectangle_X0Y3_X2Y1()
        {
            var pointA = new Point(0, 3);
            var pointC = new Point(2, 1);
            return new Rectangle(pointA, pointC);
        }

        private Rectangle GetRectangle_X1Y3_X3Y1()
        {
            var pointA = new Point(1, 3);
            var pointC = new Point(3, 1);
            return new Rectangle(pointA, pointC);
        }

        private Rectangle GetRectangle_X0Y2_X2Y0()
        {
            var pointA = new Point(0, 2);
            var pointC = new Point(2, 0);
            return new Rectangle(pointA, pointC);
        }

        private Rectangle GetRectangle_X2Y2_X4Y0()
        {
            var pointA = new Point(2, 2);
            var pointC = new Point(4, 0);
            return new Rectangle(pointA, pointC);
        }

        private Rectangle GetRectangle_X3Y2_X5Y0()
        {
            var pointA = new Point(3, 2);
            var pointC = new Point(5, 0);
            return new Rectangle(pointA, pointC);
        }

        private Rectangle GetRectangle_X0Y3_X3Y1()
        {
            var pointA = new Point(0, 3);
            var pointC = new Point(3, 1);
            return new Rectangle(pointA, pointC);
        }

        private Rectangle GetRectangle_X1Y2_X2Y0()
        {
            var pointA = new Point(1, 2);
            var pointC = new Point(2, 0);
            return new Rectangle(pointA, pointC);
        }

        private Rectangle GetRectangle_X0Y2_X3Y1()
        {
            var pointA = new Point(0, 2);
            var pointC = new Point(3, 1);
            return new Rectangle(pointA, pointC);
        }

        private Rectangle GetRectangle_X1Y3_X2Y0()
        {
            var pointA = new Point(1, 3);
            var pointC = new Point(2, 0);
            return new Rectangle(pointA, pointC);
        }

        private Rectangle GetRectangle_X0Y8_X10Y0()
        {
            var pointA = new Point(0, 8);
            var pointC = new Point(10, 0);
            return new Rectangle(pointA, pointC);
        }

        private Rectangle GetRectangle_X2Y9_X7Y3()
        {
            var pointA = new Point(2, 9);
            var pointC = new Point(7, 3);
            return new Rectangle(pointA, pointC);
        }
    }
}