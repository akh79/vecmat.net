using System;
using System.CodeDom;

namespace VecMat
{
    struct Aff2 : IEquatable<Aff2>
    {
        // Affine transformation is always invertible
        // C# allows creating identity transformation
        // in the default constructor starting from C# 10
        // So the default constructed transformation is NOT ivertible

        private Mat2 mA;
        private Vec2 mD;

        public static Aff2 Identity()
        {
            return new Aff2
            {
                mA = Mat2.Identity()
            };
        }

        public bool Equals(Aff2 s)
        {
            return mA.Equals(s.mA) && mD.Equals(s.mD);
        }

        public override bool Equals(object obj)
        {
            return obj is null ? false : (obj is Aff2 s) && Equals(s);
        }

        public static bool operator ==(Aff2 s, Aff2 t)
        {
            return s.Equals(t);
        }

        public static bool operator !=(Aff2 s, Aff2 t)
        {
            return !s.Equals(t);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(mA.GetHashCode(), mD.GetHashCode());
        }

        public static Vec2 operator *(Aff2 s, Vec2 u)
        {
            // Transform vector 
            return s.mA * u;
        }

        public static Vec2 operator ^(Aff2 s, Vec2 u)
        {
            // Transform point
            return s.mA * u + s.mD;
        }

        public static Aff2 operator *(Aff2 s, Aff2 t)
        {
            return new Aff2
            {
                mA = s.mA * t.mA,
                mD = s.mA * t.mD + s.mD
            };
        }

        public Aff2 Inverse()
        {
            // General inverse
            // TODO: implement orthogonal inverse
            Mat2 iA = mA.Inverse();
            return new Aff2
            {
                mA = iA,
                mD = iA * (-mD)
            };
        }
    }
}