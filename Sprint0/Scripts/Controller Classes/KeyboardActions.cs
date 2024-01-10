using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Scripts.Interfaces;
using System;
using System.Collections.Generic;

namespace Sprint0.Scripts
{
    internal class KeyboardActions : IController
    {
        public Dictionary<object, Action> Mappings { get; }

        public int TimeSinceLastFrame { get; set; }
        public int MillisecondsPerFrame { get; set; }

        public KeyboardActions()
        {
            Mappings = new Dictionary<object, Action>();
            TimeSinceLastFrame = 0;
            MillisecondsPerFrame = 100;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                foreach (object obj in Mappings.Keys)
                {
                    Keys key = (Keys)obj;
                    if (state.IsKeyDown(key))
                    {
                        Mappings[key].Invoke();
                    }
                }
            }
        }

        public void Add(object key, Action action)
        {
            Mappings.Add(key, action);
        }
    }
}
