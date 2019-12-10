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
    /// <param name="board">Board the space will be added on.</param>
    /// <returns>A new instance of a predefined space, with the specified id.</returns>
    public delegate IVisitableSpace SpaceFactoryFunction(string id, IBoard board);

    public interface ISpaceFactory
    {
        IVisitableSpace CreateProperty(IBoard board, string id, string name);
        IVisitableSpace CreateGoSpace(IBoard board, string id = Constants.GO_SPACE_ID);
        IVisitableSpace CreateJailSpace(IBoard board, string id = Constants.JAIL_SPACE_ID);
        IVisitableSpace CreateGoToJailSpace(IBoard board, string id = Constants.GO_TO_JAIL_SPACE_ID);
        IVisitableSpace CreateParkingSpace(IBoard board, string id = Constants.PARKING_SPACE_ID);
        IVisitableSpace CreateCommunityChest(IBoard board, string id);
        IVisitableSpace CreateChanceSpace(IBoard board, string id);
        IVisitableSpace CreateIncomeTax(IBoard board, string id);
        IVisitableSpace CreateLuxuryTax(IBoard board, string id);
    }
}
