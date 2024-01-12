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

        private KeyboardState previousState;
        public KeyboardActions()
        {

            Mappings = new Dictionary<object, Action>();
            previousState = Keyboard.GetState();
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState currentState = Keyboard.GetState();

            foreach (object obj in Mappings.Keys)
            {
                Keys key = (Keys)obj;
                if (currentState.IsKeyDown(key) && previousState.IsKeyUp(key))
                {
                    Mappings[key].Invoke();
                }
            }
            previousState = currentState;
        }

        public void Add(object key, Action action)
        {
            Mappings.Add(key, action);
        }
    }
}
