using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment.Classes
{
     public interface IScene
    {
        string BackgroundTextureKey { get; set; }
        List<IBaseSprite> AllTheSpritesWithinTheScene { get; set; }


        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        //public IScene(string textureKeyForBackground,Keys keyToActivateScene)
        //{
        //    BackgroundTextureKey = textureKeyForBackground;
        //    SceneActivateKey = keyToActivateScene;
        //}

       
    }
}
