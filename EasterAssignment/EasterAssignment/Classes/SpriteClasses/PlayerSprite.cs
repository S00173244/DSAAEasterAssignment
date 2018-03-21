using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CameraNS;
using Engine;
using Microsoft.Xna.Framework.Input;
using EasterAssignment.Classes.SpriteClasses;

namespace EasterAssignment.Classes
{
    public class PlayerSprite :SpriteWithBounds
    {
       


        public string SpriteID { get; set; }
       

        public Vector2 SpritePosition { get; set; }

        public string SpriteTextureKey { get; set; }
        public int Speed { get; set; }
        public Rectangle Bounds { get; set; }

        public PlayerSprite(string ID, Vector2 Position, string TextureKey)
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
            Move(Speed);
        }

        public void Move(int speed)
        {
            
            Vector2 direction = new Vector2(0, 0);

            if(InputEngine.IsKeyHeld(Keys.A)){
                direction.X = -1;
            } else if (InputEngine.IsKeyHeld(Keys.D))
            {
                direction.X = 1;
            }

            if (InputEngine.IsKeyHeld(Keys.W))
            {
                direction.Y = -1;

            } else if(InputEngine.IsKeyHeld(Keys.S)){
                direction.Y = 1;
            }

            SpritePosition = SpritePosition * Speed * direction;
        }
    }
}
