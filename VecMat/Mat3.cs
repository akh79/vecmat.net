using System;

namespace VecMat
{
    public struct Mat3 : IEquatable<Mat3>
    {
        private double m11, m12, m13, m21, m22, m23, m31, m32, m33;

        public Mat3(double e11, double e12, double e13, double e21, double e22, double e23, double e31, double e32, double e33)
        {
            m11 = e11; m12 = e12; m13 = e13;
            m21 = e21; m22 = e22; m23 = e23;
            m31 = e31; m32 = e32; m33 = e33;
        }

        public static Mat3 FromColumns(Vec3 u, Vec3 v, Vec3 w)
        {
            return new Mat3(
                        u.x, v.x, w.x,
                        u.y, v.y, w.y,
                        u.z, v.z, w.z);
        }

        public static Mat3 FromRows(Vec3 u, Vec3 v, Vec3 w)
        {
            return new Mat3(
                        u.x, u.y, u.z,
                        v.x, v.y, v.z,
                        w.x, w.y, w.z);
        }

        public static Mat3 Identity()
        {
            return new Mat3(
                1.0, 0.0, 0.0,
                0.0, 1.0, 0.0,
                0.0, 0.0, 1.0);
        }

        public bool Equals(Mat3 b)
        {
            return (m11 == b.m11 && m12 == b.m12 && m13 == b.m13 && 
                    m21 == b.m21 && m22 == b.m22 && m23 == b.m23 &&
                    m31 == b.m31 && m32 == b.m32 && m33 == b.m33
                    );
        }

        public override bool Equals(object obj)
        {
            return obj is null ? false : (obj is Mat3 b) && Equals(b);
        }

        public static bool operator ==(Mat3 a, Mat3 b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Mat3 a, Mat3 b)
        {
            return !a.Equals(b);
        }
        public override int GetHashCode()
        {   
            return HashCode.Combine(HashCode.Combine(m11, m12, m13), 
                             HashCode.Combine(m21, m22, m23),
                             HashCode.Combine(m31, m32, m33));
        }

        public double Determinant()
        {
            double res11 = +m22 * m33 - m23 * m32;
            double res21 = -m21 * m33 + m23 * m31;
            double res31 = +m21 * m32 - m22 * m31;

            return m11 * res11 + m12 * res21 + m13 * res31;
        }

        public static Vec3 operator *(Mat3 a, Vec3 u)
        {
            return new Vec3(
                a.m11 * u.x + a.m12 * u.y + a.m13 * u.z,
                a.m21 * u.x + a.m22 * u.y + a.m23 * u.z,
                a.m31 * u.x + a.m32 * u.y + a.m33 * u.z
                );
        }

        public static Mat3 operator *(Mat3 a, Mat3 b)
        {
            return new Mat3(
                a.m11 * b.m11 + a.m12 * b.m21 + a.m13 * b.m31, a.m11 * b.m12 + a.m12 * b.m22 + a.m13 * b.m32, a.m11 * b.m13 + a.m12 * b.m23 + a.m13 * b.m33,
                a.m21 * b.m11 + a.m22 * b.m21 + a.m23 * b.m31, a.m21 * b.m12 + a.m22 * b.m22 + a.m23 * b.m32, a.m21 * b.m13 + a.m22 * b.m23 + a.m23 * b.m33,
                a.m31 * b.m11 + a.m32 * b.m21 + a.m33 * b.m31, a.m31 * b.m12 + a.m32 * b.m22 + a.m33 * b.m32, a.m31 * b.m13 + a.m32 * b.m23 + a.m33 * b.m33
                );
        }

        public Mat3 Transpose()
        {
            return new Mat3(m11, m21, m31, m12, m22, m32, m13, m23, m33);
        }

        public Mat3 Inverse()
        {
            // Simplified C++ version of standard taken from here
            //	https://github.com/niswegmann/small-matrix-inverse
            // and ported to C#

            Mat3 res = new Mat3();

            /* Compute adjoint: */

            res.m11 = +m22 * m33 - m23 * m32;
            res.m12 = -m12 * m33 + m13 * m32;
            res.m13 = +m12 * m23 - m13 * m22;
            res.m21 = -m21 * m33 + m23 * m31;
            res.m22 = +m11 * m33 - m13 * m31;
            res.m23 = -m11 * m23 + m13 * m21;
            res.m31 = +m21 * m32 - m22 * m31;
            res.m32 = -m11 * m32 + m12 * m31;
            res.m33 = +m11 * m22 - m12 * m21;

            /* Compute determinant: */

            double det = m11 * res.m11 + m12 * res.m21 + m13 * res.m31;

            /* Multiply adjoint with reciprocal of determinant: */

            det = 1.0 / det;

            res.m11 *= det;
            res.m12 *= det;
            res.m13 *= det;
            res.m21 *= det;
            res.m22 *= det;
            res.m23 *= det;
            res.m31 *= det;
            res.m32 *= det;
            res.m33 *= det;

            return res;
        }
    }
}
