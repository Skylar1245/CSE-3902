using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Scripts.Interfaces;
using Sprint0.Scripts.Sprite_Classes;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprint0.Scripts
{
    internal class MobileStaticSprite : AbstractSprite, ISprite
    {
        public MobileStaticSprite(Texture2D texture, Vector2 position, Rectangle spritePosition = default, int millisecondsPerFrame = default)
        {
            Texture = texture;
            Position = position;
            TexturePosition = spritePosition;
            IsVisible = true;
            TimeSinceLastFrame = 0;
            MillisecondsPerFrame = millisecondsPerFrame;
        }

        private void Move()
        {
            _ = Position.Y > 950 ? Position = new Vector2(Position.X, -50) : Position = new Vector2(Position.X, Position.Y + 10);
        }

        public override void Update(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                if (IsVisible) Move();
            }
        }
    }
}
