using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Scripts.Interfaces;
using System.Collections.Generic;

namespace Sprint0
{

    internal class MobileAnimatedSprite : ISprite
    {
        public bool IsVisible { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        //Animation frames
        public Rectangle SpritePosition { get; set; }
        public int Gap { get; set; }
        public int CurrentFrame { get; set; }
        public int TotalFrames { get; set; }
        //Slow animations
        public int TimeSinceLastFrame { get; set; }
        public int MillisecondsPerFrame { get; set; }

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
            Position = position;
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
            IsVisible = true;

            TimeSinceLastFrame = 0;
            MillisecondsPerFrame = 500;
        }

        public MobileAnimatedSprite(Texture2D texture, Vector2 position, int rows, int columns, Rectangle spritePosition, int gap)
        {
            Position = position;
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
            IsVisible = true;
            SpritePosition = spritePosition;
            Gap = gap;

            TimeSinceLastFrame = 0;
            MillisecondsPerFrame = 500;
        }

        public void Update(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                CurrentFrame++;
                if (IsVisible) Move();
                if (CurrentFrame == TotalFrames)
                    CurrentFrame = 0;
            }
        }

        private void Move()
        {
            _ = Position.X > 1650 ? Position = new Vector2(-50, Position.Y) : Position = new Vector2(Position.X + 10, Position.Y);
        }

        private void TidyDraw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new(width * column, height * row, width, height);
            Rectangle destinationRectangle = new((int)Position.X, (int)Position.Y, width * 4, height * 4);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        private void MessyDraw(SpriteBatch spriteBatch)
        {
            int width = SpritePosition.Width / Columns;
            int height = SpritePosition.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;

            int startX = (width * column) + SpritePosition.X;
            int startY = (height * row) + SpritePosition.Y;

            if (CurrentFrame >= Columns)
            {
                startY += Gap;
                startX += (CurrentFrame - Columns) * Gap;

            }
            else
            {
                startX += (CurrentFrame * Gap);
            }

            Rectangle sourceRectangle = new(startX, startY, width, height);
            Rectangle destinationRectangle = new((int)Position.X, (int)Position.Y, width * 4, height * 4);

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
