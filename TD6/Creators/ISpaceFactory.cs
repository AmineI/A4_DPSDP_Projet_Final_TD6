using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    /// <summary>
    /// Delegate used to store a function generating a space.
    /// </summary>
    /// <param name="id">id to give to the generated space.</param>
    /// <returns>A new instance of a predefined space, with the specified id.</returns>
    public delegate IVisitableSpace SpaceFactoryFunction(string id);

    public interface ISpaceFactory
    {
        IVisitableSpace CreateProperty(string id, string name);
        IVisitableSpace CreateGoSpace(string id = Constants.GO_SPACE_ID);
        IVisitableSpace CreateJailSpace(string id = Constants.JAIL_SPACE_ID);
        IVisitableSpace CreateGoToJailSpace(string id = Constants.GO_TO_JAIL_SPACE_ID);
        IVisitableSpace CreateParkingSpace(string id = Constants.PARKING_SPACE_ID);
        IVisitableSpace CreateCommunityChest(string id);
        IVisitableSpace CreateIncomeTax(string id);

        //TODO Add other spaces types

    }
}
