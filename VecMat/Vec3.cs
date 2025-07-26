using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace VecMat
{
    public struct Vec3 : IEquatable<Vec3>
    {
        public double x, y, z;

        public Vec3(double X, double Y, double Z)
        {
            x = X; y = Y; z = Z;
        }

        public Vec3(Vec2 u, double Z)
        {
            x = u.x; y = u.y; z = Z;
        }

        public bool Equals(Vec3 v) => x == v.x && y == v.y && z == v.z;

        public override bool Equals(object obj)
        {
            return obj is null ? false : (obj is Vec3 v) && Equals(v);
        }

        public static bool operator ==(Vec3 u, Vec3 v)
        {
            return u.Equals(v);
        }

        public static bool operator !=(Vec3 u, Vec3 v)
        {
            return !u.Equals(v);
        }

        public bool NearlyEqual(Vec3 u, double tolerance)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z);
        }

        public static Vec3 operator -(Vec3 u)
        {
            return new Vec3(-u.x, -u.y, -u.z);
        }

        public static Vec3 operator +(Vec3 u, Vec3 v)
        {
            return new Vec3(u.x + v.x, u.y + v.y, u.z + v.z);
        }

        public static Vec3 operator -(Vec3 u, Vec3 v)
        {
            return new Vec3(u.x - v.x, u.y - v.y, u.z - v.z);
        }

        public static Vec3 operator *(double s, Vec3 u)
        {
            return new Vec3(s * u.x, s * u.y, s * u.z);
        }

        public static double Dot(Vec3 u, Vec3 v) => (u.x * v.x + u.y * v.y + u.z * v.z);

        public static Vec3 Cross(Vec3 u, Vec3 v)
        {
            return new Vec3(
                u.y * v.z - u.z * v.y,
                u.z * v.x - u.x * v.z,
                u.x * v.y - u.y * v.x
                );
        }

        public static double Norm(Vec3 u)
        {
            return Math.Sqrt(u.x * u.x + u.y * u.y + u.z * u.z);
        }
    }
}
