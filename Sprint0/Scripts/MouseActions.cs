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
        public Dictionary<object, Action> mappings { get; }
        public int timeSinceLastFrame { get; set; }
        public int millisecondsPerFrame { get; set; }
        public MouseState state = Mouse.GetState();
        public MouseActions()
        {
            mappings = new Dictionary<object, Action>
            {
                { "LeftClick", LeftClick }
            };
        }

        public void Update(GameTime gameTime)
        {
            MouseState currentState = Mouse.GetState();

            if (state.LeftButton == ButtonState.Released && currentState.LeftButton == ButtonState.Pressed)
            {
                mappings["LeftClick"].Invoke();
            }
            if (state.RightButton == ButtonState.Released && currentState.RightButton == ButtonState.Pressed)
            {
                mappings["RightCLick"].Invoke();
            }

            state = Mouse.GetState();
        }

        private void LeftClick()
        {
            Debug.WriteLine("Left click at " + state.Position);
            if (state.Position.Y <= 450)
            {
                if (state.Position.X <= 800)
                {
                    Debug.WriteLine("Invoking Quad1");
                    mappings["Quad1"].Invoke();
                }
                else
                {
                    Debug.WriteLine("Invoking Quad2");
                    mappings["Quad2"].Invoke();
                }
            }
            else
            {
                if (state.Position.X < 800)
                {
                    Debug.WriteLine("Invoking Quad3");
                    mappings["Quad3"].Invoke();
                }
                else
                {
                    Debug.WriteLine("Invoking Quad4");
                    mappings["Quad4"].Invoke();
                }

            }
        }
    }
}
