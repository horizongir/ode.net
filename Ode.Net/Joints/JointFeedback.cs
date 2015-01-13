using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class JointFeedback : IDisposable
    {
        readonly dJointFeedbackHandle handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="JointFeedback"/> class.
        /// </summary>
        public JointFeedback()
        {
            handle = new dJointFeedbackHandle();
        }

        internal dJointFeedbackHandle Handle
        {
            get { return handle; }
        }

        public Vector3 ForceOnBody1
        {
            get { return handle.ForceOnBody1; }
        }

        public Vector3 TorqueOnBody1
        {
            get { return handle.TorqueOnBody1; }
        }

        public Vector3 ForceOnBody2
        {
            get { return handle.ForceOnBody2; }
        }

        public Vector3 TorqueOnBody2
        {
            get { return handle.TorqueOnBody2; }
        }

        public void Dispose()
        {
            if (!handle.IsInvalid)
            {
                handle.Close();
            }
        }
    }
}
