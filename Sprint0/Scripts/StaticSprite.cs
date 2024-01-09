using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Scripts.Interfaces;

namespace Sprint0.Scripts
{
    internal class StaticSprite : ISprite
    {
        public bool IsVisible { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle SpritePosition = new Rectangle(0, 0, 0, 0);

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
            SpritePosition = spritePosition;
            IsVisible = true;
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
    }
}
