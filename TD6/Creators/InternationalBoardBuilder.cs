using System;

namespace TD6
{
    public class InternationalBoardBuilder : IBoardBuilder
    {
        public static IBoard BuildDefaultBoard()
        {
            ISpaceFactory defaultFactory = new DefaultInternationalSpaceFactory();
            return new InternationalBoardBuilder(defaultFactory).BuildGoSpace()
                                                   .BuildBrownSection().BuildFirstStation().BuildCyanSection()
                                                   .BuildJail()
                                                   .BuildPurpleSection().BuildSecondStation().BuildOrangeSection()
                                                   .BuildParking()
                                                   .BuildRedSection().BuildThirdStation().BuildYellowSection()
                                                   .BuildGoToJail()
                                                   .BuildGreenSection().BuildFourthStation().BuildBlueSection()
                                                   .GetBuiltBoard();
        }


        IBoard builtBoard;
        ISpaceFactory spaceFactory;


        public InternationalBoardBuilder()
        {
            Reset();
            spaceFactory = new DefaultInternationalSpaceFactory();
        }

        /// <summary>
        /// Constructor allowing to specify a custom factory to use, that would provide different prices for example.
        /// </summary>
        /// <param name="spaceFactory">Space Factory to use when building the board.</param>
        public InternationalBoardBuilder(ISpaceFactory spaceFactory)
        {
            Reset();
            this.spaceFactory = spaceFactory;
        }

        public void Reset()
        {
            builtBoard = new Board();
        }

        public IBoard GetBuiltBoard()
        {
            return builtBoard;
        }
        public IBoardBuilder BuildGoSpace()
        {
            builtBoard.Add(spaceFactory.CreateGoSpace(builtBoard));
            return this;
        }
        public IBoardBuilder BuildBrownSection()
        {
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard,"BROWN_1", "Old Kent Road"));
            builtBoard.Add(spaceFactory.CreateCommunityChest(builtBoard,"BROWN_2"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard,"BROWN_3", "Whitechapel Road"));
            builtBoard.Add(spaceFactory.CreateIncomeTax(builtBoard,"BROWN_4"));

            return this;
        }

        public IBoardBuilder BuildFirstStation()
        {            
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard,"STATION_1", "Kings Cross Station"));
            return this;
        }
        public IBoardBuilder BuildCyanSection()
        {
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "CYAN_1", "The Angel Islington"));
            builtBoard.Add(spaceFactory.CreateChanceSpace(builtBoard, "CYAN_2"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "CYAN_3", "Euston Road"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "CYAN_4", "Pentonville Road"));
            
            return this;
        }

        public IBoardBuilder BuildJail()
        {

            builtBoard.Add(spaceFactory.CreateJailSpace(builtBoard));
            return this;
        }

        public IBoardBuilder BuildPurpleSection()
        {
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "PURPLE_1", "Pall Mall"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "PURPLE_2", "Electric Company"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "PURPLE_3", "Whitehall"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "PURPLE_4", "Northumberland Avenue"));
            return this;
        }

        public IBoardBuilder BuildSecondStation()
        {
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "STATION_2", "Marylebone Station"));
            return this;
        }

        public IBoardBuilder BuildOrangeSection()
        {
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "ORANGE_1", "Bow Street"));
            builtBoard.Add(spaceFactory.CreateCommunityChest(builtBoard, "ORANGE_2"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "ORANGE_3", "Marlborough Street"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "ORANGE_4", "Vine Street"));
            return this;
        }

        public IBoardBuilder BuildParking()
        {
            builtBoard.Add(spaceFactory.CreateParkingSpace(builtBoard));
            return this;
        }

        public IBoardBuilder BuildRedSection()
        {
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "RED_1", "The Strand"));
            builtBoard.Add(spaceFactory.CreateChanceSpace(builtBoard, "RED_2"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "RED_3", "Fleet Street"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "RED_4", "Trafalgar Square"));
            return this;
        }

        public IBoardBuilder BuildThirdStation()
        {
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "STATION_3", "Fenchurch St Station"));
            return this;
        }

        public IBoardBuilder BuildYellowSection()
        {
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "YELLOW_1", "Leicester Square"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "YELLOW_2", "Coventry Street"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "YELLOW_3", "Water Works"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "YELLOW_4", "Picadilly"));
            return this;
        }

        public IBoardBuilder BuildGoToJail()
        {
            builtBoard.Add(spaceFactory.CreateGoToJailSpace(builtBoard));
            return this;
        }

        public IBoardBuilder BuildGreenSection()
        {
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "GREEN_1", "Regent Street"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "GREEN_2", "Oxford Street"));
            builtBoard.Add(spaceFactory.CreateCommunityChest(builtBoard, "GREEN_3"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "GREEN_4", "Bond Street"));
            return this;
        }

        public IBoardBuilder BuildFourthStation()
        {
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "STATION_4", "Liverpool Street Station"));
            return this;
        }

        public IBoardBuilder BuildBlueSection()
        {
            builtBoard.Add(spaceFactory.CreateChanceSpace(builtBoard, "BLUE_1"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "BLUE_2", "Park Lane"));
            builtBoard.Add(spaceFactory.CreateLuxuryTax(builtBoard, "BLUE_3"));
            builtBoard.Add(spaceFactory.CreateProperty(builtBoard, "BLUE_4", "Coventry Street"));
            return this;
        }

    }
}