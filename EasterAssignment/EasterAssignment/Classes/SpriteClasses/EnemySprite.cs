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
    public class EnemySprite : ISpriteWithBounds
    {
        public string SpriteID { get; set; }

        
        public Vector2 SpritePosition { get; set; }

        public string SpriteTextureKey { get; set; }
        public int Speed { get; set; }
        public Rectangle Bounds { get; set; }
        public bool TargetReached { get; set; }
        public Vector2 TargetDestination { get; set; }
        public bool IsVisible  { get; set; }
        private Vector2 direction = Vector2.Zero;
        private float distanceFromStartToTarget;
        private Vector2 start;
        private List<Projectile> allProjectiles = new List<Projectile>();
        public EnemySprite(string ID, string TextureKey, Vector2 Position, int currentSpeed)
        {
            SpriteID = ID;
            SpriteTextureKey = TextureKey;
            SpritePosition = Position;
            Speed = currentSpeed;
            
            
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, TextureManager.AllTextures[TextureKey].Width, TextureManager.AllTextures[TextureKey].Height);

        }


        public void Update(GameTime gameTime)
        {
            if(direction == Vector2.Zero)
            {
                direction = Vector2.Normalize(TargetDestination - SpritePosition);
                distanceFromStartToTarget = Vector2.Distance(SpritePosition, TargetDestination);
                start = SpritePosition;
                Console.WriteLine(direction.ToString());
            }
            if (IsVisible)
            {

                SpritePosition += direction * Speed;

                if (Vector2.Distance(start, SpritePosition) >= distanceFromStartToTarget)
                {
                    SpritePosition = TargetDestination;
                    TargetReached = true;
                }
                
            }
            if (TargetReached)
            {
                direction = Vector2.Zero;
                IsVisible = false;
                SpritePosition = Vector2.Zero;
                distanceFromStartToTarget = 0;
                TargetReached = false;
            }
            FireAtPlayer(gameTime);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Camera.CurrentCameraTranslation);
                spriteBatch.Draw(TextureManager.AllTextures[SpriteTextureKey], SpritePosition, Color.White);
                spriteBatch.End();
            }
           
        }

        public void FireAtPlayer(GameTime gameTime)
        {
            Projectile projectile = new Projectile();
            projectile.SpritePosition = SpritePosition;
            projectile.TargetDestination=Helper.currentPlayer.SpritePosition;
            projectile.SpriteTextureKey = "cannon";
            projectile.Speed = 2;

            allProjectiles.Add(projectile);
            if (allProjectiles.Count > 0)
            {
                allProjectiles.ForEach(c => c.Update(gameTime));
                allProjectiles.RemoveAll(c => c.TargetReached);
            }
        }
    }
}
