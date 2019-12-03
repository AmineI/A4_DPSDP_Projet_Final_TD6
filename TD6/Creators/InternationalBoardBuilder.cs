using System;

namespace TD6
{
    public class InternationalBoardBuilder : IBoardBuilder
    {
        public static Board BuildDefaultBoard()
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


        Board builtBoard;
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

        public Board GetBuiltBoard()
        {
            return builtBoard;
        }
        public IBoardBuilder BuildGoSpace()
        {
            builtBoard.Add(spaceFactory.CreateGoSpace());
            return this;
        }
        public IBoardBuilder BuildBrownSection()
        {
            builtBoard.Add(spaceFactory.CreateProperty("BROWN_1", "Old Kent Road"));
            builtBoard.Add(spaceFactory.CreateCommunityChest("BROWN_2"));
            builtBoard.Add(spaceFactory.CreateProperty("BROWN_3", "Whitechapel Road"));
            builtBoard.Add(spaceFactory.CreateIncomeTax("BROWN_4"));

            return this;
        }
            //TODO : All builder functions.
        public IBoardBuilder BuildFirstStation()
        {
            throw new NotImplementedException();
        }
        public IBoardBuilder BuildCyanSection()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildJail()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildPurpleSection()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildSecondStation()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildOrangeSection()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildParking()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildRedSection()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildThirdStation()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildYellowSection()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildGoToJail()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildGreenSection()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildFourthStation()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildBlueSection()
        {
            throw new NotImplementedException();
        }

    }
}