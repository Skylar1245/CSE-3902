using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class Text
    {
        private SpriteFont Font;
        public string Data;
        
        public Text(SpriteFont font, string data)
        {
            Font = font;
            Data = data;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(Font, Data, location, Color.Black);

            spriteBatch.End();
        }
    }
}