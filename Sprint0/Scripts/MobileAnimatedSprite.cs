using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Scripts.Interfaces;

namespace Sprint0
{

    internal class MobileAnimatedSprite : ISprite
    {
        public bool IsVisible { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        //Slow animations
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 100;

        /// <summary>
        /// Constructor for AnimatedSprite Class. <paramref name="texture"/> stores which Atlas to read from,
        /// <paramref name="columns"/> is the amount of Columns in the atlas and 
        /// <paramref name="rows"/> is the amount of rows.
        /// </summary>
        /// <param name="texture"></param> 
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public MobileAnimatedSprite(Texture2D texture, Vector2 position, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            IsVisible = true;
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
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width *4, height *4);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
