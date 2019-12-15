namespace TD6
{
    public delegate IBoard IBoardCreator();
    public interface IBoardBuilder
    {
        /// <summary>
        /// Gets the final board built.
        /// </summary>
        /// <returns>The board built by the builder</returns>
        IBoard GetBuiltBoard();

        /// <summary>
        /// Resets the Builder to its default state.
        /// </summary>
        void Reset();

        IBoardBuilder BuildBrownSection();
        IBoardBuilder BuildFirstStation();
        IBoardBuilder BuildCyanSection();
        IBoardBuilder BuildJail();
        IBoardBuilder BuildPurpleSection();
        IBoardBuilder BuildSecondStation();
        IBoardBuilder BuildOrangeSection();
        IBoardBuilder BuildParking();
        IBoardBuilder BuildRedSection();
        IBoardBuilder BuildThirdStation();
        IBoardBuilder BuildYellowSection();
        IBoardBuilder BuildGoToJail();
        IBoardBuilder BuildGreenSection();
        IBoardBuilder BuildFourthStation();
        IBoardBuilder BuildBlueSection();
    }
}