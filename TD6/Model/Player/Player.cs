﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public class Player : IPlayer, ISpaceVisitor
    {
        //Auto-properties : Can be publicly accessed but can only be set in the constructor. Id and name never changes so it is fine to use them as auto-properties.
        public int Id { get; }
        public string PlayerName { get; }

        public char DisplayCharacter { get; set; }

        private int currentPosition = 0;
        private int money;
        private int dice1;
        private int dice2;
        private int doubleCount;
        public int CurrentPosition { get => currentPosition; }
        public int Money { get => money; }
        public int DicesValue { get => dice1 + dice2; }

        public bool IsDiceDouble { get => dice1 == dice2; }

        private IGame gameInstance;

        public IGame GameInstance { get => gameInstance; }
        //The board is not necessarily initialized when we create the player, so we get the board dynamically from the Game.
        private IBoard GameBoard { get => gameInstance.Board; }
        public IView View { get => gameInstance.View; }
        public IList<Property> OwnedProperties { get; set; }

        public IList<Land> BuildableOwnedLands
        {
            get => OwnedProperties.OfType<Land>().Where(land => land.IsHouseBuildable()).ToList();
        }

        public bool HasLost => Money < 0;
        public bool Replay { get; set; }

        /// <param name="gameBoard">Game instance the player is playing on. Defaults to the singleton Game instance.</param>
        public Player(int id, string playerName, int money, char displayCharacter = 'x', IGame gameInstance = null)
        {
            this.Id = id;
            this.PlayerName = playerName;
            this.money = money;
            this.DisplayCharacter = displayCharacter;
            OwnedProperties = new List<Property>();

            this.gameInstance = gameInstance ?? Game.Instance;
            // The null-coalescing operator ?? returns the value of its left-hand operand if it isn't null; otherwise, it evaluates the right-hand operand and returns its result
        }

        public static void UpdatePlayersOwnershipOnLandOwnerChange(object sender, OwnerChangeEventArgs eventArgs)
        {
            Property updatedProperty = sender as Property;
            if (updatedProperty != null)
            {
                eventArgs.PreviousOwner?.OwnedProperties.Remove(updatedProperty);//Remove from the old owner if there was one
                eventArgs.NewOwner?.OwnedProperties.Add(updatedProperty);//Add to the new owner if there is one
            }
        }


        public void RollDices()
        {
            dice1 = Dice.RollDice();
            dice2 = Dice.RollDice();
        }

        public void Pay(int amount, IPlayer destinationPlayer = null)
        {
            money -= amount;
            if (destinationPlayer != null)
            {
                destinationPlayer.Earn(amount);
            }
        }


        public void Earn(int amount)
        {
            money += amount;
        }
        /// <summary>
        /// Function putting the player in a jailed state, using a jailedPlayer decorator
        /// </summary>
        private void GetJailed()
        {
            JailedPlayer jailedPlayer = new JailedPlayer(this);
            gameInstance.ReplaceIPlayerInstances(this, jailedPlayer);
        }
        public void GoToJail()
        {
            Teleport(GameBoard.JailSpace, false);
            this.GetJailed();//Then set it to the jailed state.
        }

        public void GetOutOfJail()
        {
            throw new InvalidOperationException("The player is not in jail.");
        }

        /// <summary>
        /// Moves the player, and walk on each space on the way to the destination, then stop on the destination space. Fires any action due to walking or stopping on a space.
        /// </summary>
        /// <param name="distanceToMove">distance to move, forwards or backwards depending on if it is positive or negative </param>
        public void Move(int distanceToMove)
        {
            //Choose whether to increment or decrement the position depending on the distance to move (positive or negative)
            Action MovePositionByOne;
            if (distanceToMove > 0)
            {
                MovePositionByOne = () => currentPosition++;
            }
            else
            {
                MovePositionByOne = () => currentPosition--;
            }

            for (int step = 0; step < Math.Abs(distanceToMove); step++)
            {
                MovePositionByOne();
                if (currentPosition >= GameBoard.Count)
                {//If we are after the end of the board, we go back to the beginning.
                    currentPosition -= GameBoard.Count;
                }
                else if (currentPosition < 0)
                {//If we are before the beginning of the board, we go back to the end of the board.
                    currentPosition += GameBoard.Count;
                }

                View.ClearView();
                View.DisplayBoard(gameInstance);
                //We "visit" the space we just landed on. If the space has an action occuring on walk, it will happen.
                GameBoard[currentPosition].AcceptWalking((ISpaceVisitor)this);
            }
            //Now that we walked the requested distance,   
            View.ClearView();

            View.DisplayBoard(gameInstance, currentPosition);
            View.Pause();
            //We stop on the space. If the space has an action occuring on stop, it will happen.
            View.DisplayMessage($"You are stopping on the {GameBoard[CurrentPosition]}");
            GameBoard[currentPosition].AcceptStopping((ISpaceVisitor)this);
        }

        /// <summary>
        /// Teleport the player on a space, with or without passing through the go space and earning its money
        /// </summary>
        /// <param name="arrival">Destination space</param>
        /// <param name="passThroughGoSpace">True if the user has to pass through the go space while teleporting.</param>
        public void Teleport(IVisitableSpace arrival, bool passThroughGoSpace = false)
        {
            int destinationIndex = GameBoard.IndexOfSpace(arrival);
            if (passThroughGoSpace && destinationIndex < currentPosition)
            {//Some luck cards can teleport us while still going through the Go space.
                //In this case we walk on the Go Space
                GameBoard[0].AcceptWalking((ISpaceVisitor)this);
            }//Whereas the "Go to Jail" event don't
            currentPosition = destinationIndex;

            View.ClearView();

            View.DisplayBoard(gameInstance, CurrentPosition);
            View.DisplayMessage($"You are stopping on : {GameBoard[CurrentPosition]}");

            //Then we stop on the destination Space
            GameBoard[currentPosition].AcceptStopping((ISpaceVisitor)this);
        }

        public void WalkOnProperty(Property property)
        {
            //When you walk on a property, nothing actually happens in the real Monopoly.
        }

        public void WalkOnEvent(EventSpace eventSpace)
        {
            //We call the walk action delegate of this event space.
            eventSpace.OnWalkAction((IPlayer)this);
        }

        public void StopOnProperty(Property property)
        {
            //If there is no owner, we ask the current player if he wants to buy the property
            if (property.Owner == null)
            {
                if (money >= property.BuyPrice)
                {
                    if (View.GetPurchaseConfirmation(property, property.BuyPrice))
                    {
                        Pay(property.BuyPrice, null);
                        property.Owner = this;
                        View.DisplayMessage(ToString());
                    }
                }
                else
                {
                    View.DisplayMessage("You don't have enough money");
                }
            }
            //If the property has an owner who is not the current player, the current player has to pay the rent
            else if (property.Owner != this)
            {
                Pay(property.RentPrice, property.Owner);
                View.DisplayMessage($"You had to pay the {property.RentPrice} rent");
                View.DisplayMessage(ToString());
                View.DisplayMessage(property.Owner.ToString());
            }

        }

        public void StopOnEvent(EventSpace eventSpace)
        {
            //We call the stop action delegate of this event space.
            eventSpace.OnStopAction((IPlayer)this);
        }


        /// <summary>
        /// Function for a player turn, launch dice, move(DiceValue)
        /// </summary>
        public void PlayTurn()
        {
            Replay = false;
            // We launch the dices with a function 
            RollDices();
            View.DisplayMessage($"You rolled a {dice1} and {dice2}, for a total of {DicesValue}\n");
            View.Pause();
            if (IsDiceDouble)
            {
                doubleCount++;
                View.DisplayMessage($"It's a double ! You made {doubleCount} doubles in a row !");

                if (doubleCount == 3)
                {
                    View.DisplayMessage("That means you are going straight to jail !");
                    doubleCount = 0;
                    GoToJail();
                    return;
                }
                else
                {
                    View.DisplayMessage("That means you will replay after this turn !");
                    Replay = true;
                }
            }

            Move(DicesValue);
            View.EndOfTurnInterface(gameInstance, this);
        }

        public override string ToString()
        {
            return $"player {PlayerName},{Money}$, displayed as {DisplayCharacter} (Owns {OwnedProperties.Count} properties)";
        }
    }


}
