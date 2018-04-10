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
    public class MenuItemSprite : ISpriteWithBounds
    {
        
        public string SpriteID { get; set; }
        public string SpriteTextureKey { get; set; }
        public Vector2 SpritePosition { get; set; }
        public string MenuItemName { get; set; }
        public Rectangle Bounds { get; set; }
        
        public MenuItemSprite(string ID,string ItemName, string TextureKey,Vector2 Position)
        {
            SpriteID = ID;
            MenuItemName = ItemName;
            SpriteTextureKey = TextureKey;
            SpritePosition = Position;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(TextureManager.AllTextures[SpriteTextureKey], SpritePosition, Color.White);
            spriteBatch.DrawString(Helper.SpriteFont, MenuItemName, SpritePosition, Color.White);
            spriteBatch.End();
        }
    }
}
