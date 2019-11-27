﻿using System;

namespace TD6
{
    public class EventSpace : Space
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
        protected Action<IPlayer> onStopAction = null;
        public Action<IPlayer> OnStopAction { get => onStopAction ?? NoAction; }

        /// <summary>
        /// Event to realize when the user "walks" on the space, regardless of whether he stops on it or not.
        /// </summary>
        protected Action<IPlayer> onWalkAction = null;
        public Action<IPlayer> OnWalkAction { get => onWalkAction ?? NoAction; }


        public EventSpace(string id, string name, Action<IPlayer> onStopAction) : base(id, name)
        {
            this.onStopAction = onStopAction;
        }
        public EventSpace(string id, string name, Action<IPlayer> onStopAction, Action<IPlayer> onWalkAction) : this(id, name, onStopAction)
        {
            this.onWalkAction = onWalkAction;
        }
    }
}