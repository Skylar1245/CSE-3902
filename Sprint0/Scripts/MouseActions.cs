using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Sprint0.Scripts
{
    internal class MouseActions : IController
    {
        public enum MouseButtons
        {
            Left,
            Right,
            Middle
        }

        public enum MousePositions
        {
            Quad1,
            Quad2,
            Quad3,
            Quad4
        }
        public Dictionary<object, Action> mappings { get; }
        public int timeSinceLastFrame { get; set; }
        public int millisecondsPerFrame { get; set; }
        public MouseState state = Mouse.GetState();
        public MouseActions()
        {
            mappings = new Dictionary<object, Action>
            {
                { MouseButtons.Left, LeftClick }
            };
        }

        public void Update(GameTime gameTime)
        {
            MouseState currentState = Mouse.GetState();

            if (state.LeftButton == ButtonState.Released && currentState.LeftButton == ButtonState.Pressed)
            {
                mappings[MouseButtons.Left].Invoke();
            }
            if (state.RightButton == ButtonState.Released && currentState.RightButton == ButtonState.Pressed)
            {
                mappings[MouseButtons.Right].Invoke();
            }

            state = Mouse.GetState();
        }

        public void Add(object key, Action action)
        {
            mappings.Add(key, action);
        }

        private void LeftClick()
        {
            if (state.Position.Y <= 450)
            {
                if (state.Position.X <= 800)
                {
                    mappings[MousePositions.Quad1].Invoke();
                }
                else
                {
                    mappings[MousePositions.Quad2].Invoke();
                }
            }
            else
            {
                if (state.Position.X < 800)
                {
                    mappings[MousePositions.Quad3].Invoke();
                }
                else
                {
                    mappings[MousePositions.Quad4].Invoke();
                }

            }
        }
    }
}
