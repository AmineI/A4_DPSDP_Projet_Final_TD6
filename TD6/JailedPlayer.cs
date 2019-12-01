namespace TD6
{
    public class JailedPlayer : IPlayer
    {


        private Player player;
        private int turnInJail;

        public JailedPlayer(Player player, int turnInJail = 0)
        {
            this.player = player;
            this.turnInJail = turnInJail;
        }

        public int DiceValue => player.DiceValue;

        public bool IsDiceDouble => player.IsDiceDouble;

        public int Id => player.Id;

        public string PlayerName => player.PlayerName;

        public int CurrentPosition => player.CurrentPosition;

        public int Money => player.Money;

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

        public void GetOutOfJail()
        {
            //TODO 
            Player Newplayer = new Player(this);
            player.ReplaceInstances(this, Newplayer);

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
                GetOutOfJail();
                player.Move(DiceValue);
            }
            else
            {
                turnInJail++;
            }
        }

        

    }
}
