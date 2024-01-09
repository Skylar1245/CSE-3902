using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Scripts.Interfaces;

namespace Sprint0.Scripts
{
    internal class MobileStaticSprite : ISprite
    {
        public bool IsVisible { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        private int currentFrame;
        private int totalFrames;

        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 100;

        public MobileStaticSprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }
        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                currentFrame++;
                Move();
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }
        }

        private void Move()
        {
            _ = Position.X > 1650 ? Position = new Vector2(-50, Position.Y) : Position = new Vector2(Position.X + 10, Position.Y);
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
