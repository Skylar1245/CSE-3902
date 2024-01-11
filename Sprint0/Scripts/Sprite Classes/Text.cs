using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Scripts.Interfaces;
using System.Collections.Generic;

namespace Sprint0
{
    internal class Text : ISprite
    {
        private readonly SpriteFont Font;
        public string Data;

        public bool IsVisible { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public int TimeSinceLastFrame { get; set; }
        public int MillisecondsPerFrame { get; set; }

        public Rectangle TexturePosition { get; set; }
        public int Gap { get; set; }
        public int CurrentFrame { get; set; }
        public int TotalFrames { get; set; }
        public Text(SpriteFont font, string data, Vector2 position)
        {
            Font = font;
            Data = data;
            Position = position;
        }

        public void Update(GameTime gameTime)
        {
            //Text does not need updated
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, Data, Position, Color.Black);
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