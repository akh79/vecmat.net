using System;
using Xunit;
using VecMat;

namespace xUnitTests
{
    public class MatTest
    {
        [Fact]
        public void Mat2Test()
        {
            Mat2 a = new Mat2(2.0, 1.0, 3.0, 2.0);
            Mat2 b = new Mat2(2.0, -1.0, -3.0, 2.0);
            Assert.Equal(a, a * Mat2.Identity());
            Assert.Equal(b, Mat2.Identity() * b);
            Assert.Equal(a * b, Mat2.Identity());
            Assert.Equal(a.Transpose().Transpose(), a);

            a = new Mat2(3.0, 2.0, 8.0, 5.0);
            b = new Mat2(6.0, 9.0, 8.0, 12.0);
            Assert.Equal(a.Determinant() * b.Determinant(), (a * b).Determinant());
        }

        [Fact]
        public void Mat3Test()
        {
            Mat3 a = new Mat3(1.0, 2.0, 3.0, 0.0, 1.0, 4.0, 0.0, 0.0, 1.0);
            Mat3 b = new Mat3(1.0, -2.0, 5.0, 0.0, 1.0, -4.0, 0.0, 0.0, 1.0);
            Assert.Equal(1.0, Math.Abs(a.Determinant()));
            Assert.Equal(1.0, Math.Abs(b.Determinant()));
            Assert.Equal(a * Mat3.Identity(), a);
            Assert.Equal(b, Mat3.Identity() * b);
            Assert.Equal(a * b, Mat3.Identity());
            Assert.Equal(b, b.Transpose().Transpose());

            a = new Mat3(2.0, 1.0, 3.0, 5.0, 3.0, 2.0, 1.0, 4.0, 3.0);
            b = new Mat3(4.0, -3.0, 5.0, 3.0, -2.0, 8.0, 1.0, -7.0, -.0);
            Assert.Equal(a.Determinant() * b.Determinant(), (a * b).Determinant());
        }
    }
}
