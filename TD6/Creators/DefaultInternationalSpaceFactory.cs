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
            ["Old Kent Road"] = (id, board) => new Land(id, "Old Kent Road", Color.Brown,
                60, new[] { 2, 10, 30, 90, 160, 250 }, 50, board),
            ["Whitechapel Road"] = (id, board) => new Land(id, "Whitechapel Road", Color.Brown,
                80, new[] { 4, 20, 60, 180, 320, 450 }, 50, board),
            ["Kings Cross Station"] = (id, board) => new Railroad(id, "Kings Cross Station",
                200, new[] { 25, 50, 100, 200 }, board),

            ["The Angel Islington"] = (id, board) => new Land(id, "The Angel Islington", Color.Cyan,
                100, new[] { 6, 30, 90, 270, 400, 550 }, 50, board),
            ["Euston Road"] = (id, board) => new Land(id, "Euston Road", Color.Cyan,
                100, new[] { 6, 30, 90, 270, 400, 550 }, 50, board),
            ["Pentonville Road"] = (id, board) => new Land(id, "Pentonville Road", Color.Cyan,
                120, new[] { 8, 40, 100, 300, 450, 600 }, 50, board),

            ["Pall Mall"] = (id, board) => new Land(id, "Pall Mall", Color.Purple,
                140, new[] { 10, 50, 150, 450, 625, 750 }, 100, board),
            ["Electric Company"] = (id, board) => new Utility(id, "Electric Company",
                150, new[] { 4, 10 }, board),
            ["Whitehall"] = (id, board) => new Land(id, "Whitehall", Color.Purple,
                140, new[] { 10, 50, 150, 450, 625, 750 }, 100, board),
            ["Northumberland Avenue"] = (id, board) => new Land(id, "Northumberland Avenue", Color.Purple,
                160, new[] { 12, 60, 180, 500, 700, 900 }, 100, board),

            ["Marylebone Station"] = (id, board) => new Railroad(id, "Marylebone Station",
                200, new[] { 25, 50, 100, 200 }, board),
            ["Bow Street"] = (id, board) => new Land(id, "Bow Street", Color.Orange,
                180, new[] { 14, 70, 200, 550, 750, 950 }, 100, board),
            ["Marlborough Street"] = (id, board) => new Land(id, "Marlborough Street", Color.Orange,
                180, new[] { 14, 70, 200, 550, 750, 950 }, 100, board),
            ["Vine Street"] = (id, board) => new Land(id, "Vine Street", Color.Orange,
                200, new[] { 16, 80, 220, 600, 800, 1000 }, 100, board),

            ["The Strand"] = (id, board) => new Land(id, "The Strand", Color.Red,
                220, new[] { 18, 90, 250, 700, 875, 1050 }, 150, board),
            ["Fleet Street"] = (id, board) => new Land(id, "Fleet Street", Color.Red,
                220, new[] { 18, 90, 250, 700, 875, 1050 }, 150, board),
            ["Trafalgar Square"] = (id, board) => new Land(id, "Trafalgar Square", Color.Red,
                240, new[] { 20, 100, 300, 750, 925, 1100 }, 150, board),
            ["Fenchurch St Station"] = (id, board) => new Railroad(id, "Fenchurch St Station",
                200, new[] { 25, 50, 100, 200 }, board),

            ["Leicester Square"] = (id, board) => new Land(id, "Leicester Square", Color.Yellow,
                260, new[] { 22, 110, 330, 800, 975, 1150 }, 150, board),
            ["Coventry Street"] = (id, board) => new Land(id, "Coventry Street", Color.Yellow,
                260, new[] { 22, 110, 330, 800, 975, 1150 }, 150, board),
            ["Water Works"] = (id, board) => new Utility(id, "Water Works",
                150, new[] { 4, 10 }, board),
            ["Picadilly"] = (id, board) => new Land(id, "Picadilly", Color.Yellow,
                280, new[] { 24, 120, 360, 850, 1025, 1200 }, 150, board),

            ["Regent Street"] = (id, board) => new Land(id, "Regent Street", Color.Green,
                300, new[] { 26, 130, 390, 900, 1100, 1275 }, 200, board),
            ["Oxford Street"] = (id, board) => new Land(id, "Oxford Street", Color.Green,
                300, new[] { 26, 130, 390, 900, 1100, 1275 }, 200, board),
            ["Bond Street"] = (id, board) => new Land(id, "Bond Street", Color.Green,
                320, new[] { 28, 150, 450, 1000, 1200, 1400 }, 200, board),
            ["Liverpool Street Station"] = (id, board) => new Railroad(id, "Liverpool Street Station",
                200, new[] { 25, 50, 100, 200 }, board),

            ["Park Lane"] = (id, board) => new Land(id, "Park Lane", Color.Blue,
                350, new[] { 35, 175, 500, 1100, 1300, 1500 }, 200, board),
            ["Mayfair"] = (id, board) => new Land(id, "Mayfair", Color.Blue,
                400, new[] { 50, 200, 600, 1400, 1700, 2000 }, 200, board),

        };

        //Store the actions we'll make the event spaces do as static delegates in the factory.
        public static Action<IPlayer> PassGo = delegate (IPlayer player) { player.Earn(200); };
        public static Action<IPlayer> PassJail = delegate (IPlayer player) { };//TODO : When a player passes the Jail visit space we can display a message


        public static Action<IPlayer> GoToJail = delegate (IPlayer player) { player.GoToJail(); };
        public static Action<IPlayer> PayIncomeTax = delegate (IPlayer player) { player.Pay(200); };
        public static Action<IPlayer> PayLuxuryTax = delegate (IPlayer player) { player.Pay(75); };

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
            return new EventSpace(id, "Go", onStopAction: null, onWalkAction: PassGo, board: board);
        }

        public IVisitableSpace CreateJailSpace(IBoard board, string id = Constants.JAIL_SPACE_ID)
        {
            return new EventSpace(id, "Jail (visit only)", onStopAction: PassJail, onWalkAction: PassJail, board: board);
        }

        public IVisitableSpace CreateGoToJailSpace(IBoard board, string id = Constants.GO_TO_JAIL_SPACE_ID)
        {
            return new EventSpace(id, "Go To Jail", onStopAction: GoToJail, board: board);
        }
        public IVisitableSpace CreateIncomeTax(IBoard board, string id)
        {
            return new EventSpace(id, "Income Tax", PayIncomeTax, board);
        }

        public IVisitableSpace CreateLuxuryTax(IBoard board, string id)
        {
            return new EventSpace(id, "Income Tax", PayLuxuryTax, board);
        }
        public IVisitableSpace CreateParkingSpace(IBoard board, string id = "PARKING")
        {
            //TODO If time remains. For now, a parking space does nothing
            return new EventSpace(id, "Parking (Not Implemented)", onStopAction: null, board: board);
        }

        public IVisitableSpace CreateCommunityChest(IBoard board, string id)
        {
            //TODO if time remains. For now, a community chest does nothing.
            return new EventSpace(id, "Community Chest (Not Implemented)", onStopAction: null, board: board);
        }


        public IVisitableSpace CreateChanceSpace(IBoard board, string id)
        {
            //TODO if time remains. For now, a chance space does nothing.
            return new EventSpace(id, "Chance space (Not Implemented)", onStopAction: null, board: board);
        }

    }
}
