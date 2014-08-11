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
    /// Represents a 3x3 matrix.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3 : IEquatable<Matrix3>
    {
        /// <summary>
        /// Specifies the first row of the matrix.
        /// </summary>
        public Vector3 Row1;

        /// <summary>
        /// Specifies the second row of the matrix.
        /// </summary>
        public Vector3 Row2;

        /// <summary>
        /// Specifies the third row of the matrix.
        /// </summary>
        public Vector3 Row3;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3"/> structure
        /// with the specified element values.
        /// </summary>
        /// <param name="m11">The value at the first row and first column of the matrix.</param>
        /// <param name="m12">The value at the first row and second column of the matrix.</param>
        /// <param name="m13">The value at the first row and third column of the matrix.</param>
        /// <param name="m21">The value at the second row and first column of the matrix.</param>
        /// <param name="m22">The value at the second row and second column of the matrix.</param>
        /// <param name="m23">The value at the second row and third column of the matrix.</param>
        /// <param name="m31">The value at the third row and first column of the matrix.</param>
        /// <param name="m32">The value at the third row and second column of the matrix.</param>
        /// <param name="m33">The value at the third row and third column of the matrix.</param>
        public Matrix3(
            dReal m11, dReal m12, dReal m13,
            dReal m21, dReal m22, dReal m23,
            dReal m31, dReal m32, dReal m33)
        {
            Row1.X = m11;
            Row1.Y = m12;
            Row1.Z = m13;
            Row1.W = 0;
            Row2.X = m21;
            Row2.Y = m22;
            Row2.Z = m23;
            Row2.W = 0;
            Row3.X = m31;
            Row3.Y = m32;
            Row3.Z = m33;
            Row3.W = 0;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified
        /// <see cref="Matrix3"/> value.
        /// </summary>
        /// <param name="other">A <see cref="Matrix3"/> value to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same element values as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Matrix3 other)
        {
            return Row1 == other.Row1 && Row2 == other.Row2 && Row3 == other.Row3;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is an instance of <see cref="Matrix3"/> and
        /// has the same element values as this instance; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Matrix3)
            {
                return Equals((Matrix3)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Row1.GetHashCode() ^ Row2.GetHashCode() ^ Row3.GetHashCode();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// The string representation of all the elements in the matrix.
        /// </returns>
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", Row1, Row2, Row3);
        }

        /// <summary>
        /// Tests whether two <see cref="Matrix3"/> structures are equal.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Matrix3"/> structure on the left of the equality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Matrix3"/> structure on the right of the equality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have
        /// all their elements equal; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Matrix3 left, Matrix3 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Matrix3"/> structures are different.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Matrix3"/> structure on the left of the inequality operator.
        /// </param>
        /// <param name="right">
        /// The <see cref="Matrix3"/> structure on the right of the inequality operator.
        /// </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ
        /// in any of their elements; <b>false</b> if <paramref name="left"/> and
        /// <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Matrix3 left, Matrix3 right)
        {
            return !left.Equals(right);
        }
    }
}
