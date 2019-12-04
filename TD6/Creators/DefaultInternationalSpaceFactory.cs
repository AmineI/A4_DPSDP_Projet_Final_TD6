using System;
using System.Collections.Generic;

namespace TD6
{
    /// <summary>
    /// Our default space factory according to the international street names and prices.
    /// </summary>
    public class DefaultInternationalSpaceFactory : ISpaceFactory
    {
        //TODO Factory methods for the other spaces, to write in the Interface

        private static Dictionary<string, SpaceFactoryFunction> PropertyCreators = new Dictionary<string, SpaceFactoryFunction>
        {
            ["Old Kent Road"] = (id, board) => new Land(id, "Old Kent Road", Color.Brown, 60, new[] { 2, 10, 30, 90, 160, 250 }, 50, board),
            ["Whitechapel Road"] = (id, board) => new Land(id, "Whitechapel Road", Color.Brown, 80, new[] { 4, 20, 60, 180, 320, 450 }, 50, board)
            //TODO : create the property creators for each property
        };

        //Store the actions we'll make the event spaces do as static delegates in the factory.
        public static Action<IPlayer> PassGo = delegate (IPlayer player) { player.Earn(1500); };


        public static Action<IPlayer> PayIncomeTax = delegate (IPlayer player) { player.Pay(200); };




        //TODO : Maybe the visit Jail event should display a message on walk.

        public IVisitableSpace CreateProperty(IBoard board, string id, string nameOfThePropertyToCreate)
        {
            IVisitableSpace newCreatedSpace = PropertyCreators[nameOfThePropertyToCreate](id, board);
            if (newCreatedSpace == null)
            {
                throw new ArgumentOutOfRangeException(nameOfThePropertyToCreate, "There is no information about this property in this factory.");
            }
            return newCreatedSpace;
        }

        public IVisitableSpace CreateGoSpace(IBoard board, string id = Constants.GO_SPACE_ID)
        {
            return new EventSpace(id, "Go", onStopAction: null, onWalkAction: PassGo, board);
        }

        public IVisitableSpace CreateJailSpace(IBoard board, string id = Constants.JAIL_SPACE_ID)
        {
            //TODO
            throw new NotImplementedException();
        }

        public IVisitableSpace CreateGoToJailSpace(IBoard board, string id = Constants.GO_TO_JAIL_SPACE_ID)
        {
            //TODO
            throw new NotImplementedException();
        }
        public IVisitableSpace CreateParkingSpace(IBoard board, string id = "PARKING")
        {
            //TODO If time remains. For now, a parking space does nothing
            return new EventSpace(id, "Parking (Not Implemented)", onStopAction: null, board);
        }

        public IVisitableSpace CreateCommunityChest(IBoard board, string id)
        {
            //TODO if time remains. For now, a community chest does nothing.
            return new EventSpace(id, "Community Chest (Not Implemented)", onStopAction: null, board);
        }

        public IVisitableSpace CreateIncomeTax(IBoard board, string id)
        {
            return new EventSpace(id, "Income Tax", PayIncomeTax, board);
        }

    }
}
