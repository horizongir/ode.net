using Ode.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode.Net.Joints
{
    public sealed class JointGroup : IEnumerable<Joint>
    {
        readonly List<Joint> joints = new List<Joint>();

        internal void Add(Joint joint)
        {
            if (joint == null)
            {
                throw new ArgumentNullException("joint");
            }

            joints.Add(joint);
        }

        public void Clear()
        {
            foreach (var joint in joints)
            {
                joint.Dispose();
            }

            joints.Clear();
        }

        public IEnumerator<Joint> GetEnumerator()
        {
            return joints.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return joints.GetEnumerator();
        }
    }
}
