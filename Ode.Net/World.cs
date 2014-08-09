using Ode.Net.Native;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dReal = System.Single;

namespace Ode.Net
{
    /// <summary>
    /// Represents a container for rigid bodies and joints.
    /// </summary>
    public class World : IDisposable
    {
        /// <summary>
        /// Represents an unlimited number of island step threads when setting
        /// thread count properties. This field is constant.
        /// </summary>
        public const int StepThreadCountUnlimited = 0;
        readonly dWorldID id;

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> class.
        /// </summary>
        public World()
        {
            id = NativeMethods.dWorldCreate();
        }

        /// <summary>
        /// Gets or sets the world's global gravity vector.
        /// </summary>
        public Vector3 Gravity
        {
            get
            {
                Vector3 result;
                NativeMethods.dWorldGetGravity(id, out result);
                return result;
            }
            set
            {
                NativeMethods.dWorldSetGravity(id, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Gets or sets the global ERP value, that controls how much error
        /// correction is performed in each time step.
        /// </summary>
        public dReal Erp
        {
            get { return NativeMethods.dWorldGetERP(id); }
            set { NativeMethods.dWorldSetERP(id, value); }
        }

        /// <summary>
        /// Gets or sets the global CFM (constraint force mixing) value.
        /// </summary>
        public dReal Cfm
        {
            get { return NativeMethods.dWorldGetCFM(id); }
            set { NativeMethods.dWorldSetCFM(id, value); }
        }

        /// <summary>
        /// Gets or sets the maximum number of threads to be used for island stepping.
        /// </summary>
        public int StepIslandsProcessingMaxThreadCount
        {
            get { return (int)NativeMethods.dWorldGetStepIslandsProcessingMaxThreadCount(id); }
            set { NativeMethods.dWorldSetStepIslandsProcessingMaxThreadCount(id, (uint)value); }
        }

        /// <summary>
        /// Sets the world to use shared working memory along with another world.
        /// </summary>
        /// <param name="fromWorld">The world to use shared memory with.</param>
        /// <exception cref="InvalidOperationException">
        /// Failed to setup shared working memory between the two worlds.
        /// </exception>
        public void UseSharedWorkingMemory(World fromWorld)
        {
            var fromId = fromWorld == null ? dWorldID.Null : fromWorld.id;
            var result = NativeMethods.dWorldUseSharedWorkingMemory(id, fromId);
            if (result == 0)
            {
                throw new InvalidOperationException("Could not set shared working memory between the two worlds.");
            }
        }

        /// <summary>
        /// Releases internal working memory allocated for the world.
        /// </summary>
        public void CleanupWorkingMemory()
        {
            NativeMethods.dWorldCleanupWorkingMemory(id);
        }

        /// <summary>
        /// Sets the memory reservation policy to be used with world stepping operations.
        /// </summary>
        /// <param name="policyInfo">
        /// The memory reservation policy descriptor. If the descriptor is <b>null</b>,
        /// the current reservation policy will be reset to default parameters.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Failed to set memory reservation policy for world stepping operations.
        /// </exception>
        public void SetStepMemoryReservationPolicy(WorldStepReserveInfo policyInfo)
        {
            var result = policyInfo == null
                ? NativeMethods.dWorldSetStepMemoryReservationPolicy(id, IntPtr.Zero)
                : NativeMethods.dWorldSetStepMemoryReservationPolicy(id, ref policyInfo.info);
            if (result == 0)
            {
                throw new InvalidOperationException("Could not set memory reservation policy for stepping operations.");
            }
        }

        /// <summary>
        /// Sets the memory manager to be used with world stepping operations.
        /// </summary>
        /// <param name="memoryManager">
        /// The memory manager descriptor. If the descriptor is <b>null</b>,
        /// the default memory manager is used.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Failed to set memory manager for world stepping operations.
        /// </exception>
        public void SetStepMemoryManager(WorldStepMemoryFunctionsInfo memoryManager)
        {
            var result = memoryManager == null
                ? NativeMethods.dWorldSetStepMemoryManager(id, IntPtr.Zero)
                : NativeMethods.dWorldSetStepMemoryManager(id, ref memoryManager.info);
            if (result == 0)
            {
                throw new InvalidOperationException("Could not set memory manager for stepping operations.");
            }
        }

        /// <summary>
        /// Steps the world using the specified time delta.
        /// </summary>
        /// <param name="stepSize">
        /// The number of seconds that the simulation has to advance.
        /// </param>
        /// <exception cref="InsufficientMemoryException">
        /// The memory allocation has failed for operation. In such a case all the
        /// objects remain in unchanged state and simulation can be retried as soon
        /// as more memory is available.
        /// </exception>
        public void Step(dReal stepSize)
        {
            var result = NativeMethods.dWorldStep(id, stepSize);
            if (result == 0)
            {
                throw new InsufficientMemoryException("Memory allocation has failed for stepping operation.");
            }
        }

        /// <summary>
        /// Quick-steps the world using the specified time delta. For large systems
        /// this is much faster than <see cref="Step"/>, but it is less accurate.
        /// </summary>
        /// <param name="stepSize">
        /// The number of seconds that the simulation has to advance.
        /// </param>
        /// <exception cref="InsufficientMemoryException">
        /// The memory allocation has failed for operation. In such a case all the
        /// objects remain in unchanged state and simulation can be retried as soon
        /// as more memory is available.
        /// </exception>
        public void QuickStep(dReal stepSize)
        {
            var result = NativeMethods.dWorldQuickStep(id, stepSize);
            if (result == 0)
            {
                throw new InsufficientMemoryException("Memory allocation has failed for stepping operation.");
            }
        }

        /// <summary>
        /// Destroys the world and everything in it.
        /// </summary>
        public void Dispose()
        {
            id.Close();
        }
    }
}
