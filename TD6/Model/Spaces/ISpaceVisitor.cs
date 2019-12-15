using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public interface ISpaceVisitor
    {
        /// <summary>
        /// Dices value rolled to end up visiting a space.
        /// </summary>
        int DicesValue { get; }
        /// <summary>
        /// Action that the player has to execute when walking on a specified property.
        /// </summary>
        /// <param name="property">Property to walk on</param>
        void WalkOnProperty(Property property);

        /// <summary>
        /// Action that the player has to execute when walking on a specified event space.
        /// </summary>
        /// <param name="eventSpace">EventSpace to walk on</param>
        void WalkOnEvent(EventSpace eventSpace);

        /// <summary>
        /// Action that the player has to execute when stopping on a specified property.
        /// </summary>
        /// <param name="property">Property to stop on</param>
        void StopOnProperty(Property property);

        /// <summary>
        /// Action that the player has to execute when stopping on a specified event space.
        /// </summary>
        /// <param name="eventSpace">EventSpace to stop on</param>
        void StopOnEvent(EventSpace eventSpace);

    }
}
