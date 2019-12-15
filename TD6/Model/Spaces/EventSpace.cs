using System;

namespace TD6
{
    public class EventSpace : Space, IVisitableSpace
    {
        /// <summary>
        /// A delegate that does nothing. The default event.
        /// </summary>
        public static Action<IPlayer> NoAction = delegate { };

        /// <summary>
        /// Event to realize when the user stops on the space.
        /// Action is a delegate type taking a Player parameter and not returning anything.
        /// <example> For exemple
        /// <code>
        /// Action≪Joueur≫ SayHelloToPlayer = delegate (Player player){ Console.WriteLine($"Hi {player}"); };
        /// </code>
        /// </example>
        /// </summary>
        protected Action<IPlayer> onStopAction = NoAction;
        public Action<IPlayer> OnStopAction { get => onStopAction; }

        /// <summary>
        /// Event to realize when the user "walks" on the space, regardless of whether he stops on it or not.
        /// </summary>
        protected Action<IPlayer> onWalkAction = NoAction;
        public Action<IPlayer> OnWalkAction { get => onWalkAction; }

        public Color Color { get => Color.White; }

        public EventSpace(string id, string name, Action<IPlayer> onStopAction, IBoard board = null) : base(id, name, board)
        {
            this.onStopAction = onStopAction ?? NoAction;//If the action is null, we set it as "NoAction" (an empty action delegate)
        }
        public EventSpace(string id, string name, Action<IPlayer> onStopAction, Action<IPlayer> onWalkAction, IBoard board = null) : this(id, name, onStopAction, board)
        {
            this.onWalkAction = onWalkAction ?? NoAction;
        }

        public void AcceptStopping(ISpaceVisitor visitor)
        {
            visitor.StopOnEvent(this);
        }

        public void AcceptWalking(ISpaceVisitor visitor)
        {
            visitor.WalkOnEvent(this);
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}