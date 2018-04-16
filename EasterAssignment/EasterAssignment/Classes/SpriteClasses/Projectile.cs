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
    public class Projectile : ISpriteWithBounds
    {

        public string SpriteID { get; set; }


        public Vector2 SpritePosition { get; set; }

        public string SpriteTextureKey { get; set; }
        public int Speed { get; set; }
        public Rectangle Bounds { get; set; }
        public Vector2 TargetDestination { get; set; }
        private Vector2 direction = Vector2.Zero;
        private float distanceFromStartToTarget;
        private Vector2 start;
        public bool TargetReached { get; set; }

        public void Update(GameTime gameTime)
        {
            if (direction == Vector2.Zero)
            {
                direction = Vector2.Normalize(TargetDestination - SpritePosition);
                distanceFromStartToTarget = Vector2.Distance(SpritePosition, TargetDestination);
                start = SpritePosition;
                
               
            }
            SpritePosition += direction * Speed;

            if (Vector2.Distance(start, SpritePosition) >= distanceFromStartToTarget)
            {
                SpritePosition = TargetDestination;
                TargetReached = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Camera.CurrentCameraTranslation);
            spriteBatch.Draw(TextureManager.AllTextures[SpriteTextureKey], SpritePosition, Color.White);
            spriteBatch.End();
        }
    }
}
