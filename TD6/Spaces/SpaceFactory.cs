using System;

namespace TD6.Spaces
{
    public static class SpaceFactory
    {
        public static Action<IPlayer> PassGo = delegate (IPlayer player) { player.Earn(1500); };

        public static EventSpace CreateGoSpace(string id = "GO")
        {
            return new EventSpace(id, "Go", onStopAction: null, onWalkAction: PassGo);
        }
        //TODO Factory for the other spaces : Go To Jail, Visit Jail, etc
        //TODO : Maybe the visit Jail should display a message on walk.
    }
}
