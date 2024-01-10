using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Scripts.Interfaces;

namespace Sprint0.Scripts
{
    internal class MobileStaticSprite : StaticSprite
    {
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 100;

        public MobileStaticSprite(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
            //No different construction needed
        }

        public MobileStaticSprite(Texture2D texture, Vector2 position, Rectangle spritePosition)
            : base(texture, position, spritePosition)
        {
            //No different construction needed
        }

        private void Move()
        {
            _ = Position.Y > 950 ? Position = new Vector2(Position.X, -50) : Position = new Vector2(Position.X, Position.Y + 10);
        }

        public new void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                Move();
            }
        }
    }
}
