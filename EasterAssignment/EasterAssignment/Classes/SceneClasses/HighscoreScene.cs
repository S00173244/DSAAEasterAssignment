using EasterAssignment.Classes.ContentManagerClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        
        public List<HighscoreItemSprite> AllHighscoreItems { get; set; }

        public HighscoreScene()
        {
            AllTheSpritesWithinTheScene = new List<IBaseSprite>();
           
            AllHighscoreItems = new List<HighscoreItemSprite>();
            BackgroundTextureKey = "highscore";
        }

        public void Update(GameTime gameTime) { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(TextureManager.AllTextures[BackgroundTextureKey], Vector2.Zero, Color.White);


            spriteBatch.End();
        }
    }
}
