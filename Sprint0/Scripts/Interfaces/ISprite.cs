using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Scripts.Interfaces;
using System.Collections.Generic;

namespace Sprint0.Scripts.Interfaces
{
    /// <summary>
    /// Interface for all sprites in game, use for ANY sprite.
    /// </summary>
    internal interface ISprite
    {
        /// <summary>
        /// Boolean value to determine if this sprite should be drawn or not.
        /// </summary>
        bool IsVisible { get; set; }
        /// <summary>
        /// Current Position of this sprite.
        /// </summary>
        Vector2 Position { get; set; }
        /// <summary>
        /// The texture this sprite will read from.
        /// </summary>
        Texture2D Texture { get; set; }

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
