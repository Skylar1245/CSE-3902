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

        public StaticSprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }
        public void Update(GameTime gameTime = null)
        {
           //static sprite does not need updated
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible) return;
            int width = Texture.Width;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width * 4, height * 4);

            //Overloaded with samplterState, fixes blurry sprites from upscaling
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
