using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Sprint0.Scripts.Interfaces
{
    /// <summary>
    /// Interface for all game controls
    /// </summary>
    internal interface IController
    {
        /// <summary>
        /// Map of all buttons and their actions.
        /// </summary>
        Dictionary<object, Action> Mappings { get; }
        /// <summary>
        /// Time since last frame occurred, used to with millisecondsPerFrame.
        /// </summary>
        int TimeSinceLastFrame { get; set; }
        /// <summary>
        /// Time allotted per frame, used with timeSinceLastFrame.
        /// </summary>
        int MillisecondsPerFrame { get; set; }
        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="gameTime"></param>
        void Update(GameTime gameTime);
        /// <summary>
        /// Adds the <paramref name="key"/> and its associated <paramref name="action"/> to this controllers mapping.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        void Add(object key, Action action);
    }
}
