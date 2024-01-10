using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Scripts.Interfaces;

namespace Sprint0.Scripts
{
    internal class MobileStaticSprite : StaticSprite
    {

=========
    internal class MobileStaticSprite : StaticSprite
    {
>>>>>>>>> Temporary merge branch 2
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
            }
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
=========
                Move();
            }

>>>>>>>>> Temporary merge branch 2
        }
    }
}
