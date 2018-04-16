using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using EasterAssignment.Classes.ContentManagerClasses;
using EasterAssignment.Classes.ServiceClasses;

namespace EasterAssignment.Classes.SpriteClasses
{
    public class SpawnPoint : ISpriteWithBounds
    {
        public string SpriteID { get; set; }


        public Vector2 SpritePosition { get; set; }

        public string SpriteTextureKey { get; set; }
    
        public Rectangle Bounds { get; set; }

        public SpawnPoint(string ID, Vector2 Position, string TextureKey)
        {
            SpriteID = ID;
            SpritePosition = Position;
            SpriteTextureKey = TextureKey;
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, TextureManager.AllTextures[TextureKey].Width, TextureManager.AllTextures[TextureKey].Height);


        }

        public void Update(GameTime gameTime)
        {
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Camera.CurrentCameraTranslation);
            spriteBatch.Draw(TextureManager.AllTextures[SpriteTextureKey], SpritePosition, Color.White);
            spriteBatch.End();
        }
    }
}
