using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Scripts.Interfaces;
using System.Collections.Generic;

namespace Sprint0.Scripts
{
    internal class MobileStaticSprite : ISprite
    {
        public bool IsVisible { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle SpritePosition = new Rectangle(0, 0, 0, 0);


        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 100;

        public MobileStaticSprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            IsVisible = true;
        }

        public MobileStaticSprite(Texture2D texture, Vector2 position, Rectangle spritePosition)
        {
            Texture = texture;
            Position = position;
            SpritePosition = spritePosition;
            IsVisible = true;
        }

        private void Move()
        {
            _ = Position.Y > 950 ? Position = new Vector2(Position.X, -50) : Position = new Vector2(Position.X, Position.Y + 10);
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                Move();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible) return;
            int width, height;
            Rectangle sourceRectangle, destinationRectangle;
            if (SpritePosition.Center == Point.Zero)
            {
                width = Texture.Width;
                height = Texture.Height;
                sourceRectangle = new Rectangle(0, 0, width, height);
                destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width * 4, height * 4);

            }
            else
            {
                width = SpritePosition.Width;
                height = SpritePosition.Height;
                sourceRectangle = SpritePosition;
                destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width * 4, height * 4);
            }
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Focus(List<ISprite> sprites)
        {
            this.IsVisible = true;
            foreach (ISprite sprite in sprites)
            {
                if (this != sprite)
                {
                    sprite.IsVisible = false;
                }
            }
        }
    }
}
