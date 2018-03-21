using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CameraNS;

namespace EasterAssignment.Classes.SpriteClasses
{
    public class Collectable : SpriteWithBounds
    {
        public Rectangle Bounds { get; set; }

        public string SpriteID { get; set; }

        public Vector2 SpritePosition { get; set; }

        public string SpriteTextureKey { get; set; }


        public Collectable(string ID ,Vector2 Position, string TextureKey)
        {
            SpriteID = ID;
            SpritePosition = Position;
            SpriteTextureKey = TextureKey;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Camera.CurrentCameraTranslation);

            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
