using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    /// <summary>
    /// Represents a quadtree collision space.
    /// </summary>
    public sealed class QuadTreeSpace : Space
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuadTreeSpace"/> class.
        /// </summary>
        /// <param name="center">The center of the root block.</param>
        /// <param name="extents">The size of the root block.</param>
        /// <param name="depth">
        /// The depth of the tree. The number of blocks that are created is 4^depth.
        /// </param>
        public QuadTreeSpace(Vector3 center, Vector3 extents, int depth)
            : this(null, center, extents, depth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuadTreeSpace"/> class
        /// inside the specified space.
        /// </summary>
        /// <param name="space">The space which will contain the new quadtree space.</param>
        /// <param name="center">The center of the root block.</param>
        /// <param name="extents">The size of the root block.</param>
        /// <param name="depth">
        /// The depth of the tree. The number of blocks that are created is 4^depth.
        /// </param>
        public QuadTreeSpace(Space space, Vector3 center, Vector3 extents, int depth)
            : base(NativeMethods.dQuadTreeSpaceCreate(space != null ? space.Id : dSpaceID.Null,
                                                      ref center, ref extents, depth))
        {
        }
    }
}
