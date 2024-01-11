using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Scripts.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprint0.Scripts
{
    internal class MobileStaticSprite : ISprite
    {
        public bool IsVisible { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public int TimeSinceLastFrame { get; set; }
        public int MillisecondsPerFrame { get; set; }
        public Rectangle TexturePosition { get; set; }
        public int Gap { get; set; }
        public int CurrentFrame { get; set; }
        public int TotalFrames { get; set; }

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

        public void Update(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                if (IsVisible) Move();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible) return;
            int width, height;
            Rectangle sourceRectangle, destinationRectangle;
            if (TexturePosition.Center == Point.Zero)
            {
                width = Texture.Width;
                height = Texture.Height;
                sourceRectangle = new Rectangle(0, 0, width, height);
                destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width * 4, height * 4);

            }
            else
            {
                width = TexturePosition.Width;
                height = TexturePosition.Height;
                sourceRectangle = TexturePosition;
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
