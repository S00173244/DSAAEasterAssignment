using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment.Classes
{
     public class Scene
    {
        public string BackgroundTextureKey { get; set; }
        public List<BaseSprite> AllTheSpriteWithinTheScene { get; set; }
        public Keys SceneActivateKey { get; set; }
       
        public Scene(string textureKeyForBackground,Keys keyToActivateScene)
        {
            BackgroundTextureKey = textureKeyForBackground;
            SceneActivateKey = keyToActivateScene;
        }

       
    }
}
