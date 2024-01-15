using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Scripts.Interfaces;
using System.Collections.Generic;

namespace Sprint0.Scripts
{
    internal class StaticSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Rectangle TexturePosition { get; set; }
        public int Gap { get; set; }
        public bool IsVisible { get; set; }
        public Vector2 Position { get; set; }
        public int CurrentFrame { get; set; }
        public int TotalFrames { get; set; }
        public int MillisecondsPerFrame { get; set; }
        public int TimeSinceLastFrame { get; set; }
        public StaticSprite(Texture2D texture, Vector2 position, Rectangle spritePosition = default)
        {
            Texture = texture;
            Position = position;
            TexturePosition = spritePosition;
            IsVisible = true;
        }

        public virtual void Update(GameTime gameTime = null) { }
        public virtual void Draw(SpriteBatch spriteBatch)
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
    }
}
