using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EasterAssignment.Classes.ServiceClasses;
using EasterAssignment.Classes.ContentManagerClasses;
using EasterAssignment.Classes.SpriteClasses;

namespace EasterAssignment.Classes
{
    public class HighscoreItemSprite : ISpriteWithBounds
    {
        
        public string SpriteID { get; set; }
        public string SpriteTextureKey { get; set; }
        public Vector2 SpritePosition { get; set; }
        public string HighScoreItemName { get; set; }
        public Rectangle Bounds { get; set; }
        
        public HighscoreItemSprite(string ID,string ItemName, string TextureKey,Vector2 Position)
        {
            SpriteID = ID;
            HighScoreItemName = ItemName;
            SpriteTextureKey = TextureKey;
            SpritePosition = Position;
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, TextureManager.AllTextures[TextureKey].Width, TextureManager.AllTextures[TextureKey].Height);
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(TextureManager.AllTextures[SpriteTextureKey], SpritePosition, Color.White);
            spriteBatch.DrawString(Helper.SpriteFont, HighScoreItemName, SpritePosition, Color.White);
            spriteBatch.End();
        }
    }
}
