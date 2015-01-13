﻿using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Geoms
{
    /// <summary>
    /// Represents a heightfield geom.
    /// </summary>
    public sealed class Heightfield : Geom
    {
        HeightfieldData data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Heightfield"/> class with the
        /// specified data.
        /// </summary>
        /// <param name="data">The heightfield data object.</param>
        /// <param name="placeable">
        /// <b>true</b> if this geom can be transformed in the world using the
        /// position and rotation functions; otherwise, the geom will have a fixed
        /// orientation where the global y-axis will represent height.
        /// </param>
        public Heightfield(HeightfieldData data, bool placeable)
            : this(null, data, placeable)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Heightfield"/> class on the
        /// given space and with the specified data.
        /// </summary>
        /// <param name="space">The space that is to contain the geom.</param>
        /// <param name="data">The heightfield data object.</param>
        /// <param name="placeable">
        /// <b>true</b> if this geom can be transformed in the world using the
        /// position and rotation functions; otherwise, the geom will have a fixed
        /// orientation where the global y-axis will represent height.
        /// </param>
        public Heightfield(Space space, HeightfieldData data, bool placeable)
            : base(NativeMethods.dCreateHeightfield(space != null ? space.Id : dSpaceID.Null, data.Id, placeable ? 1 : 0))
        {
            this.data = data;
        }

        public HeightfieldData Data
        {
            get { return data; }
            set
            {
                data = value;
                NativeMethods.dGeomHeightfieldSetHeightfieldData(Id, value.Id);
            }
        }
    }
}
