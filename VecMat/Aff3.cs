using System;

namespace VecMat
{
    public struct Aff3 : IEquatable<Aff3>
    {
        private Mat3 mA;
        private Vec3 mD;

        public static Aff3 Identity()
        {
            return new Aff3
            {
                mA = Mat3.Identity()
            };
        }

        public bool Equals(Aff3 s)
        {
            return mA.Equals(s.mA) && mD.Equals(s.mD);
        }

        public override bool Equals(object obj)
        {
            return obj is null ? false : (obj is Aff3 s) && Equals(s);
        }

        public static bool operator ==(Aff3 s, Aff3 t)
        {
            return s.Equals(t);
        }

        public static bool operator !=(Aff3 s, Aff3 t)
        {
            return !s.Equals(t);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(mA.GetHashCode(), mD.GetHashCode());
        }

        public static Vec3 operator *(Aff3 s, Vec3 u)
        {
            // Transform vector 
            return s.mA * u;
        }

        public static Vec3 operator ^(Aff3 s, Vec3 u)
        {
            // Transform point
            return s.mA * u + s.mD;
        }

        public static Aff3 operator *(Aff3 s, Aff3 t)
        {
            return new Aff3
            {
                mA = s.mA * t.mA,
                mD = s.mA * t.mD + s.mD
            };
        }

        public Aff3 Inverse()
        {
            // General inverse
            // TODO: implement orthogonal inverse
            Mat3 iA = mA.Inverse();
            return new Aff3
            {
                mA = iA,
                mD = iA * (-mD)
            };
        }
    }
}
