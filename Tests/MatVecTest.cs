using System;
using Xunit;
using VecMat;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTests
{
    public class MatVecTest
    {
        [Fact]
        public void Mat2Vec2()
        {
            Mat2 a = new Mat2(2.0, 1.0, 3.0, 2.0);
            Mat2 b = new Mat2(5.0, -6.0, 1.0, 8.0);
            Vec2 u = new Vec2(5.0, 1.0);
            Vec2 v = new Vec2(-6.0, 8.0);

            Vec2 s = a * u;
            Vec2 t = a * v;

            Mat2 c = Mat2.FromColumns(s, t);
            Assert.Equal(c, a * b);
        }

        [Fact]
        public void Mat3Vec3()
        {
            Mat3 a = new Mat3(1.0, 2.0, 3.0, 0.0, 1.0, 4.0, 0.0, 0.0, 1.0);
            Mat3 b = new Mat3(1.0, -2.0, 5.0, 0.0, 1.0, -4.0, 0.0, 0.0, 1.0);
            Vec3 u = new Vec3(1.0, 0.0, 0.0);
            Vec3 v = new Vec3(-2.0, 1.0, 0.0);
            Vec3 w = new Vec3(5.0, -4.0, 1.0);

            Vec3 r = a * u;
            Vec3 s = a * v;
            Vec3 t = a * w;
            Mat3 c = Mat3.FromColumns(r, s, t);
            Assert.Equal(c, a * b);
        }
    }
}
