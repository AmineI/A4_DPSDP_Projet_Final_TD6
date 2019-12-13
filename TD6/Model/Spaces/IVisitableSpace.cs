using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public interface IVisitableSpace
    {
        string Id { get; }
        string Name { get; }

        Color Color { get; }

        /// <summary>
        /// Accept a visitor that is walking on the space but not necessarily stopping on it, and act according to the type of space visited (by calling the visitor's WalkOn[TheSpaceType] method.).
        /// </summary>
        /// <param name="visitor">Visitor that is walking on the space</param>
        void AcceptWalking(ISpaceVisitor visitor);
        /// <summary>
        /// Accept a visitor that is stopping on the space after walking on it, and act according to the type of space visited  (by calling the visitor's StopOn[TheSpaceType] method.)
        /// </summary>
        /// <param name="visitor">Visitor that is stopping on the space</param>
        void AcceptStopping(ISpaceVisitor visitor);
    }
}
