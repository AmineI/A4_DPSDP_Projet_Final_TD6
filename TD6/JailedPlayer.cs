namespace TD6
{
    public class JailedPlayer : IPlayer
    {
        Player player;

        public int DiceValue => player.DiceValue;

        public bool IsDiceDouble => player.IsDiceDouble;

        public void RollDices()
        {
            player.RollDices();
        }

        public void Earn(int amount)
        {
            player.Earn(amount);
        }

        public void Pay(int amount, IPlayer destinationPlayer)
        {
            player.Pay(amount, destinationPlayer);
        }

        public void PlayTurn()
        {
            RollDices();
            //TODO
            //
            // Si Double :
            //      Sort de prison et continue sur un tour "normal" avec son lancer de dé
            // Si pas double
            //      Sort si tour 3
            //
            if (IsDiceDouble)
            {
                //TODO
            }
        }

        

    }
}
