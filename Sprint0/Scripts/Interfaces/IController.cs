using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Xml.Serialization;

namespace Sprint0.Scripts.Interfaces
{
    /// <summary>
    /// Interface for all game controls
    /// </summary>
    internal interface IController
    {
        Dictionary<object, Action> mappings { get; }
        int timeSinceLastFrame { get; set; }
        int millisecondsPerFrame { get; set; }
        void Update(GameTime gameTime);

        void Add(object key, Action action);
    }
}
