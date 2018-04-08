using EasterAssignment.Classes.SpriteClasses;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment.Classes.SceneClasses
{
    public class PlayScene : IScene
    {
        public string BackgroundTextureKey { get; set; }
        public List<IBaseSprite> AllTheSpritesWithinTheScene { get; set; }
        public Keys SceneActivateKey { get; set; }
        public bool IsActive { get; set; }

        public Queue<EnemySprite> AllEnemies;
    }
}
