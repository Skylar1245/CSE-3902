using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Scripts.Interfaces;
using Sprint0.Scripts.Sprite_Classes;
using System.Collections.Generic;

namespace Sprint0
{

    internal class AnimatedSprite : AbstractSprite, ISprite
    {
        private int Rows { get; set; }
        private int Columns { get; set; }
        /// <summary>
        /// Constructor for AnimatedSprite Class. <paramref name="texture"/> stores which Atlas to read from,
        /// <paramref name="columns"/> is the amount of Columns in the atlas and 
        /// <paramref name="rows"/> is the amount of rows.
        /// </summary>
        /// <param name="texture"></param> 
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public AnimatedSprite(Texture2D texture, Vector2 position, int rows, int columns, Rectangle texturePosition = default, int gap = default, int millisecondsPerFrame = default)
        {
            Position = position;
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
            IsVisible = true;
            TexturePosition = texturePosition;
            Gap = gap;
            TimeSinceLastFrame = 0;
            MillisecondsPerFrame = millisecondsPerFrame;
        }

        public override void Update(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                if (IsVisible)
                {
                    CurrentFrame++;
                    if (CurrentFrame == TotalFrames)
                        CurrentFrame = 0;
                }
            }
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
            int width = TexturePosition.Width / Columns;
            int height = TexturePosition.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;

            int startX = (width * column) + TexturePosition.X;
            int startY = (height * row) + TexturePosition.Y;

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

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible) return;

            if (TexturePosition.Center == Point.Zero)
            {
                TidyDraw(spriteBatch);
            }
            else
            {
                MessyDraw(spriteBatch);
            }
        }
    }
}
