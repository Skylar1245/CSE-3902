using Sprint0.Scripts.Interfaces;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Sprint0.Scripts
{
    internal class KeyboardActions : IController
    {
        public Dictionary<object, Action> mappings { get; }

        public int timeSinceLastFrame { get; set; }
        public int millisecondsPerFrame { get; set; }

        public KeyboardActions() {
            mappings = new Dictionary<object, Action>();
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 100;
        }
        
        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                foreach (Keys key in mappings.Keys)
                {
                    if (state.IsKeyDown(key))
                    {
                        mappings[key].Invoke();
                    }
                }
            }
        }

        public void Add(object key, Action action)
        {
            mappings.Add(key, action);
        }
    }
}
