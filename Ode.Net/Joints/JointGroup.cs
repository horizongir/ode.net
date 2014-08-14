using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class JointGroup : IDisposable
    {
        readonly dJointGroupID id;

        public JointGroup()
        {
            id = NativeMethods.dJointGroupCreate(0);
        }

        internal dJointGroupID Id
        {
            get { return id; }
        }

        public void Clear()
        {
            NativeMethods.dJointGroupEmpty(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
