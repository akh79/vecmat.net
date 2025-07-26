using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace VecMat
{
    public struct Vec2 : IEquatable<Vec2>
    {
        public double x, y;

        public Vec2(double X, double Y)
        { 
            x = X; y = Y;
        }

        public static Vec2 UnitX() => new Vec2(1.0, 0.0);

        public static Vec2 UnitY() => new Vec2(0.0, 1.0);

        public bool Equals(Vec2 v) => x == v.x && y == v.y;

        public override bool Equals(object obj)
        {
            return obj is null ? false : (obj is Vec2 v) && Equals(v);
        }

        public static bool operator ==(Vec2 u, Vec2 v)
        {
            return u.Equals(v);
        }

        public static bool operator !=(Vec2 u, Vec2 v)
        {
            return !u.Equals(v);
        }

        public bool NearlyEqual(Vec2 u, double tolerance)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public static Vec2 operator -(Vec2 u)
        {
            return new Vec2(-u.x, -u.y);
        }

        public static Vec2 operator +(Vec2 u, Vec2 v)
        {
            return new Vec2(u.x + v.x, u.y + v.y);
        }

        public static Vec2 operator -(Vec2 u, Vec2 v)
        {
            return new Vec2(u.x - v.x, u.y - v.y);
        }

        public static Vec2 operator *(double s, Vec2 v)
        {
            return new Vec2(s * v.x, s * v.y);
        }

        public static double Dot(Vec2 u, Vec2 v) => (u.x * v.x + u.y * v.y);

        public static double Cross(Vec2 u, Vec2 v) => (u.x * v.y - u.y * v.x);

        public static double Norm(Vec2 u) => Math.Sqrt(u.x * u.x + u.y * u.y);
    }
}
