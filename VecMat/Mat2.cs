using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace VecMat
{
    public struct Mat2 : IEquatable<Mat2>
    {
        private double m11, m12, m21, m22;

        public Mat2(double e11, double e12, double e21, double e22)
        {
            m11 = e11; m12 = e12;
            m21 = e21; m22 = e22;
        }

        public static Mat2 FromColumns(Vec2 u, Vec2 v)
        {
            // From column vectors
            return new Mat2(
                        u.x, v.x,
                        u.y, v.y);
        }

        public static Mat2 FromRows(Vec2 u, Vec2 v)
        {
            // From row vectors
            return new Mat2(
                        u.x, u.y,
                        v.x, v.y);
        }

        public static Mat2 Identity()
        {
            return new Mat2(
                1.0, 0.0,
                0.0, 1.0);
        }

        public bool Equals(Mat2 b)
        {
            return (m11 == b.m11 && m12 == b.m12 && m21 == b.m21 && m22 == b.m22);
        }

        public override bool Equals(object obj)
        {
            return obj is null ? false : (obj is Mat2 b) && Equals(b);
        }

        public static bool operator ==(Mat2 a, Mat2 b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Mat2 a, Mat2 b)
        {
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(m11, m12, m21, m22);
        }

        public double Determinant()
        {
            return (m11 * m22 - m12 * m21);
        }

        public static Vec2 operator *(Mat2 a, Vec2 u)
        {
            return new Vec2(a.m11 * u.x + a.m12 * u.y,
                            a.m21 * u.x + a.m22 * u.y);
        }

        public static Mat2 operator *(Mat2 a, Mat2 b)
        {
            return new Mat2(
                a.m11 * b.m11 + a.m12 * b.m21, a.m11 * b.m12 + a.m12 * b.m22,
                a.m21 * b.m11 + a.m22 * b.m21, a.m21 * b.m12 + a.m22 * b.m22);
        }

        public Mat2 Transpose()
        {
            return new Mat2(m11, m21, m12, m22);
        }

        public Mat2 Inverse()
        {
            // Simplified C# version of volklore ported from C++ from here
            // https://github.com/niswegmann/small-matrix-inverse

            // Compute reciprocal of determinant
            double det = 1.0 / (m11 * m22 - m12 * m21);

            // Adjoint multiplied by the reciprocal of determinant
            return new Mat2(
                +m22 * det, -m12 * det,
                -m21 * det, +m11 * det);
        }
    }
}