using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment.Classes
{
    public interface IBaseSprite
    {
        string SpriteID { get; set; }
        string SpriteTextureKey { get; set; }
        Vector2 SpritePosition { get; set; }

        
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);

    }
}
