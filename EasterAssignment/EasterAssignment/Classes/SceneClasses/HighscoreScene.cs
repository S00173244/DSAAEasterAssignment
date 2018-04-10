using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment.Classes.SceneClasses
{
    public class HighscoreScene : IScene
    {
        public string BackgroundTextureKey { get; set; }
        public List<IBaseSprite> AllTheSpritesWithinTheScene { get; set; }
       
       
    }
}
