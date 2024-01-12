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

        private MouseState previousState;
        private MouseState currentState;
        public MouseActions()
        {
            Mappings = new Dictionary<object, Action>
            {
                { MouseButtons.Left, LeftClick }
            };
            previousState = Mouse.GetState();
        }

        public void Update(GameTime gameTime)
        {
            currentState = Mouse.GetState();

            if (currentState.LeftButton == ButtonState.Pressed && previousState.LeftButton == ButtonState.Released)
            {
                Mappings[MouseButtons.Left].Invoke();
            }
            if (currentState.RightButton == ButtonState.Pressed && previousState.RightButton == ButtonState.Released)
            {
                Mappings[MouseButtons.Right].Invoke();
            }

            previousState = currentState;
        }

        public void Add(object key, Action action)
        {
            Mappings.Add(key, action);
        }

        private void LeftClick()
        {
            if (currentState.Position.Y <= 450)
            {
                if (currentState.Position.X <= 800)
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
                if (currentState.Position.X < 800)
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
