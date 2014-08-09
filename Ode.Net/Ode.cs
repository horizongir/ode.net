using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net
{
    /// <summary>
    /// This class provides methods for ODE initialization and finalization.
    /// </summary>
    public static class Ode
    {
        /// <summary>
        /// Initializes the ODE library.
        /// </summary>
        /// <param name="initFlags">Specifies ODE library initialization options.</param>
        public static void Init(InitFlags initFlags = InitFlags.None)
        {
            var result = NativeMethods.dInitODE2(initFlags);
            if (result == 0)
            {
                throw new InvalidOperationException("Failed to initialize ODE library.");
            }
        }

        /// <summary>
        /// Allocates thread local data to allow the current thread to call ODE.
        /// </summary>
        /// <param name="allocateFlags">Specifies thread allocation options.</param>
        public static void AllocateDataForThread(AllocateDataFlags allocateFlags)
        {
            var result = NativeMethods.dAllocateODEDataForThread(allocateFlags);
            if (result == 0)
            {
                throw new InsufficientMemoryException("The requested data could not be allocated.");
            }
        }

        /// <summary>
        /// Releases thread local data that was allocated for the current thread.
        /// </summary>
        public static void CleanupAllDataForThread()
        {
            NativeMethods.dCleanupODEAllDataForThread();
        }

        /// <summary>
        /// Releases all the resources allocated for library including all the
        /// thread local data that might be allocated for all the threads that
        /// were using ODE.
        /// </summary>
        public static void Close()
        {
            NativeMethods.dCloseODE();
        }
    }
}
