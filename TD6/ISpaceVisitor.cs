using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public interface ISpaceVisitor
    {
        void WalkOnProperty(Property property);
        void WalkOnEvent(EventSpace eventSpace);
        void StopOnProperty(Property property);
        void StopOnEvent(EventSpace eventSpace);

    }
}
