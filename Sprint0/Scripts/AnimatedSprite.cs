using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Scripts.Interfaces;
using System.Diagnostics;
using System.Data.Common;
using System.Collections.Generic;

namespace Sprint0
{

    internal class AnimatedSprite : ISprite
    {
        public bool IsVisible { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        //Animation frames
        private Rectangle SpritePosition = new Rectangle(0, 0, 0, 0);
        private int Gap = 0;
        private int currentFrame;
        private int totalFrames;
        //Slow animations
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 500;

        /// <summary>
        /// Constructor for AnimatedSprite Class. <paramref name="texture"/> stores which Atlas to read from,
        /// <paramref name="columns"/> is the amount of Columns in the atlas and 
        /// <paramref name="rows"/> is the amount of rows.
        /// </summary>
        /// <param name="texture"></param> 
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public AnimatedSprite(Texture2D texture, Vector2 position, int rows, int columns)
        {
            Position = position;
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            IsVisible = true;
        }

        public AnimatedSprite(Texture2D texture, Vector2 position, int rows, int columns, Rectangle spritePosition, int gap)
        {
            Position = position;
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            IsVisible = true;
            SpritePosition = spritePosition;
            Gap = gap;
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }
        }

        private void TidyDraw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width * 4, height * 4);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        private void MessyDraw(SpriteBatch spriteBatch)
        {
            int width = SpritePosition.Width / Columns;
            int height = SpritePosition.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            int startX = (width * column) + SpritePosition.X;
            int startY = (height * row) + SpritePosition.Y;

            if (currentFrame >= Columns)
            {
                startY += Gap;
                startX += (currentFrame - Columns) * Gap;

            }
            else
            {
                startX += (currentFrame * Gap);
            }

            Rectangle sourceRectangle = new Rectangle(startX, startY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width * 4, height * 4);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible) return;

            if (SpritePosition.Center == Point.Zero)
            {
                TidyDraw(spriteBatch);
            }
            else
            {
                MessyDraw(spriteBatch);
            }
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
