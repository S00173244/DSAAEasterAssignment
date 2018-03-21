using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EasterAssignment.Classes
{
    class MenuItemSprite : BaseSprite
    {
        
        public string SpriteID { get; set; }

        public string SpriteTextureKey { get; set; }

        public Vector2 SpritePosition { get; set; }
        public string MenuItemName { get; set; }
        
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
            spriteBatch.End();
        }
    }
}
