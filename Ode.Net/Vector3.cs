using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net
{
    /// <summary>
    /// Represents a vector with three components.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3 : IEquatable<Vector3>
    {
        /// <summary>
        /// Represents a <see cref="Vector3"/> with ones in all of its components.
        /// </summary>
        public static readonly Vector3 One = new Vector3(1, 1, 1);

        /// <summary>
        /// Represents a <see cref="Vector3"/> with all of its components set to zero.
        /// </summary>
        public static readonly Vector3 Zero = new Vector3(0, 0, 0);

        /// <summary>
        /// Specifies the x-component of the vector.
        /// </summary>
        public dReal X;

        /// <summary>
        /// Specifies the y-component of the vector.
        /// </summary>
        public dReal Y;

        /// <summary>
        /// Specifies the z-component of the vector.
        /// </summary>
        public dReal Z;

        /// <summary>
        /// Provides padding for alignment purposes. This field is unused.
        /// </summary>
        internal dReal W;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> structure
        /// with all components set to the same value.
        /// </summary>
        /// <param name="value">The value to initialize each component to.</param>
        public Vector3(dReal value)
        {
            X = Y = Z = value;
            W = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> structure
        /// with the specified component values.
        /// </summary>
        /// <param name="x">The value of the x-component of the vector.</param>
        /// <param name="y">The value of the y-component of the vector.</param>
        /// <param name="z">The value of the z-component of the vector.</param>
        public Vector3(dReal x, dReal y, dReal z)
        {
            X = x;
            Y = y;
            Z = z;
            W = 0;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified
        /// <see cref="Vector3"/> value.
        /// </summary>
        /// <param name="other">A <see cref="Vector3"/> value to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same X, Y and Z components as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Vector3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is an instance of <see cref="Vector3"/> and
        /// has the same X, Y and Z components as this instance; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector3)
            {
                return Equals((Vector3)obj);
            }
            
            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// The string representation of the X, Y and Z components of this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }

        /// <summary>
        /// Tests whether two <see cref="Vector3"/> structures are equal.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Vector3"/> structure on the left of the equality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Vector3"/> structure on the right of the equality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have
        /// equal X, Y and Z components; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Vector3"/> structures are different.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Vector3"/> structure on the left of the inequality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Vector3"/> structure on the right of the inequality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ
        /// in X, Y or Z components; <b>false</b> if <paramref name="left"/> and
        /// <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !left.Equals(right);
        }
    }
}
