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

        void AcceptWalking(ISpaceVisitor visitor);
        void AcceptStopping(ISpaceVisitor visitor);
    }
}
