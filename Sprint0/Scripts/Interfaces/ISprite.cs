using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0.Scripts.Interfaces
{
    /// <summary>
    /// Interface for all sprites in game, use for ANY sprite.
    /// </summary>
    internal interface ISprite
    {
        /// <summary>
        /// The texture this sprite will read from.
        /// </summary>
        Texture2D Texture { get; set; }
        /// <summary>
        /// The position of this sprites frames on its <seealso cref="Texture"/>
        /// </summary>
        Rectangle TexturePosition { get; set; }
        /// <summary>
        /// The gap between sprite frames for animated sprites
        /// </summary>
        int Gap { get; set; }
        /// <summary>
        /// Boolean value to determine if this sprite should be drawn or not.
        /// </summary>
        bool IsVisible { get; set; }
        /// <summary>
        /// Current Position of this sprite.
        /// </summary>
        Vector2 Position { get; set; }
        /// <summary>
        /// Tracks the current animation frame.
        /// </summary>
        int CurrentFrame { get; set; }
        /// <summary>
        /// The total amount of frames in this sprites animation
        /// </summary>
        int TotalFrames { get; set; }
        /// <summary>
        /// The amount of frames per millisecond this sprite will update
        /// </summary>
        int MillisecondsPerFrame { get; set; }
        /// <summary>
        /// Tracks the time since the last frame update
        /// </summary>
        int TimeSinceLastFrame { get; set; }
        /// <summary>
        /// Makes this sprite the only visible sprite in <paramref name="sprites"/>.
        /// </summary>
        /// <param name="sprites"></param>
        void Focus(List<ISprite> sprites);
        /// <summary>
        /// Update method of this sprite, optionally pass 
        /// <paramref name="gameTime"/> for animated sprites.
        /// </summary>
        /// <param name="gameTime"></param>
        void Update(GameTime gameTime = null);
        /// <summary>
        /// Draw method for this sprite, makes the initial sprite on screen,
        /// requires <paramref name="spriteBatch"/> to locate files.
        /// </summary>
        /// <param name="spriteBatch"></param>
        void Draw(SpriteBatch spriteBatch);
    }
}
