using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Scripts.Interfaces;
using System;
using System.Collections.Generic;

namespace Sprint0.Scripts
{
    internal class MouseActions : IController
    {
        /// <summary>
        /// Enumerator for MouseButtons, supports Left, Right, and Middle clicks.
        /// </summary>
        public enum MouseButtons
        {
            Left,
            Right,
            Middle
        }
        /// <summary>
        /// Enumerator for MousePositions, supports Quads[1 - 4].
        /// </summary>
        public enum MousePositions
        {
            Quad1,
            Quad2,
            Quad3,
            Quad4
        }
        public Dictionary<object, Action> Mappings { get; }
        public int TimeSinceLastFrame { get; set; }
        public int MillisecondsPerFrame { get; set; }
        public MouseState state = Mouse.GetState();
        public MouseActions()
        {
            Mappings = new Dictionary<object, Action>
            {
                { MouseButtons.Left, LeftClick }
            };
        }

        public void Update(GameTime gameTime)
        {
            MouseState currentState = Mouse.GetState();

            if (state.LeftButton == ButtonState.Released && currentState.LeftButton == ButtonState.Pressed)
            {
                Mappings[MouseButtons.Left].Invoke();
            }
            if (state.RightButton == ButtonState.Released && currentState.RightButton == ButtonState.Pressed)
            {
                Mappings[MouseButtons.Right].Invoke();
            }

            state = Mouse.GetState();
        }

        public void Add(object key, Action action)
        {
            Mappings.Add(key, action);
        }

        private void LeftClick()
        {
            if (state.Position.Y <= 450)
            {
                if (state.Position.X <= 800)
                {
                    Mappings[MousePositions.Quad1].Invoke();
                }
                else
                {
                    Mappings[MousePositions.Quad2].Invoke();
                }
            }
            else
            {
                if (state.Position.X < 800)
                {
                    Mappings[MousePositions.Quad3].Invoke();
                }
                else
                {
                    Mappings[MousePositions.Quad4].Invoke();
                }

            }
        }
    }
}
