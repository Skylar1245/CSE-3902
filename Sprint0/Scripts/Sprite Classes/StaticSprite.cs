using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Scripts.Interfaces;
using System.Collections.Generic;

namespace Sprint0.Scripts
{
    internal class StaticSprite : ISprite
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

        public StaticSprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            IsVisible = true;
        }

        public StaticSprite(Texture2D texture, Vector2 position, Rectangle spritePosition)
        {
            Texture = texture;
            Position = position;
            TexturePosition = spritePosition;
            IsVisible = true;
        }
        public void Focus(List<ISprite> sprites)
        {
            foreach (ISprite sprite in sprites)
            {
                sprite.IsVisible = false;

            }
            //In case this is also in sprites
            this.IsVisible = true;
        }

        public void Update(GameTime gameTime = null)
        {
            //static sprite does not need updated
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
    }
}
