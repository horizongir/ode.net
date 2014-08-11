﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net
{
    /// <summary>
    /// Specifies ODE library initialization options.
    /// </summary>
    [Flags]
    public enum InitFlags
    {
        /// <summary>
        /// Specifies that no initialization flags are set. Resources allocated in TLS
        /// for threads using ODE will be cleared using automatic resource tracking.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// Specifies that resources allocated in TLS for threads using ODE
        /// are to be cleared by library client with explicit call.
        /// </summary>
        ManualThreadCleanup = 0x00000001
    }

    /// <summary>
    /// Specifies which data is to be pre-allocated in calls to
    /// <see cref="Ode.AllocateDataForThread"/>.
    /// </summary>
    [Flags]
    public enum AllocateDataFlags
    {
        /// <summary>
        /// Specifies that the basic data set required for normal library
        /// operation should be allocated.
        /// </summary>
        BasicData = 0x00000001,

        /// <summary>
        /// Specifies that collision detection data should be allocated.
        /// </summary>
        CollisionData = 0x00000001,

        /// <summary>
        /// Specifies that all the possible data that is currently defined or will be defined
        /// in the future should be allocated.
        /// </summary>
        All = ~BasicData
    }

    /// <summary>
    /// Specifies the direction axis for capsule-like masses.
    /// </summary>
    public enum DirectionAxis
    {
        /// <summary>
        /// Specifies that the long axis of the mass is the x-axis.
        /// </summary>
        X = 1,

        /// <summary>
        /// Specifies that the long axis of the mass is the y-axis.
        /// </summary>
        Y = 2,

        /// <summary>
        /// Specifies that the long axis of the mass is the z-axis.
        /// </summary>
        Z = 3
    }
}
