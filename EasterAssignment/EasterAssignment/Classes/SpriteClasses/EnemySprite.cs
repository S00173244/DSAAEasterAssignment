using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace EasterAssignment.Classes.SpriteClasses
{
    public class EnemySprite : ISpriteWithBounds
    {
        public string SpriteID { get; set; }


        public Vector2 SpritePosition { get; set; }

        public string SpriteTextureKey { get; set; }
        public int Speed { get; set; }
        public Rectangle Bounds { get; set; }


        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
