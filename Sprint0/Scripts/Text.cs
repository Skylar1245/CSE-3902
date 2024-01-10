using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Scripts.Interfaces;

namespace Sprint0
{
    internal class Text : ISprite
    {
        private SpriteFont Font;
        public string Data;

        public bool IsVisible { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

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