using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Scripts.Interfaces;
using Sprint0.Scripts.Sprite_Classes;
using System.Collections.Generic;

namespace Sprint0.Scripts
{
    internal class StaticSprite : AbstractSprite, ISprite
    {
        public StaticSprite(Texture2D texture, Vector2 position, Rectangle spritePosition = default)
        {
            Texture = texture;
            Position = position;
            TexturePosition = spritePosition;
            IsVisible = true;
        }
    }
}
