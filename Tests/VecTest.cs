using System;
using Xunit;
using VecMat;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTests
{
    public class VecTest
    {
        [Fact]
        public void Vec2Test()
        {
            Vec2 zero = new Vec2();
            Vec2 v = new Vec2(1.0, -1.0);
            Assert.Equal(zero + v, v);

            Vec2 u = new Vec2(-2.0, 6.0);
            v = new Vec2(4.0, -12.0);
            Assert.Equal(2.0 * u - u, u);
            Assert.Equal(v + 2.0 * u, zero);
        }

        [Fact]
        public void Vec3Test()
        {
            Vec3 u = new Vec3();
            Vec3 v = new Vec3(1.0, -1.0, 0.5);
            Assert.Equal(u + v, v);
        }

        [Fact]
        public void Vec3CrossTest()
        {
            Vec3 u = new Vec3(1.0, -1.0, 1.0);
            Vec3 v = new Vec3(-1.0, 1.0, -1.0);
            Vec3 w = Vec3.Cross(u, v);
            Assert.Equal(0.0, Vec3.Dot(u, w));
            Assert.Equal(0.0, Vec3.Dot(v, w));
        }
    }
}
