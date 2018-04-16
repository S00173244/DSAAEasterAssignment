using EasterAssignment.Classes.ContentManagerClasses;
using EasterAssignment.Classes.ServiceClasses;
using EasterAssignment.Classes.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment.Classes.SceneClasses
{
    public class PlayScene : IScene
    {
        public string BackgroundTextureKey { get; set; }
        public List<IBaseSprite> AllTheSpritesWithinTheScene { get; set; }
        public Keys SceneActivateKey { get; set; }
        public bool IsActive { get; set; }

        public PlayerSprite Player { get; set; }
        public List<Collectable> Collectables { get; set; }
        public Queue<EnemySprite> AllEnemies { get; set; }
        public List<SpawnPoint> AllSpawnPoints { get; set; }
        public List<DespawnPoint> AllDespawnPoints { get; set; }
        public bool Gameover { get; set; }

        public PlayScene()
        {
            Gameover = false;
        }
        public void Update(GameTime gameTime)
        {


            Player.Update(gameTime);
            Collectables.ForEach(c => c.Update(gameTime));

            List<Collectable> collected = Collectables.FindAll(c => c.HasCollidedWithPlayer);

            foreach (var item in collected)
            {
                AllTheSpritesWithinTheScene.Remove(item);
                Collectables.Remove(item);
            }
            
           

            var spawnPointsWithinTheViewport = AllSpawnPoints.FindAll(c => Helper.CurrentGame.GraphicsDevice.Viewport.Bounds.Contains(c.SpritePosition - new Vector2(Camera.CamPos.X, Camera.CamPos.Y)));
            var despawnPointsWithinTheViewport = AllDespawnPoints.FindAll(c => Helper.CurrentGame.GraphicsDevice.Viewport.Bounds.Contains(c.SpritePosition - new Vector2(Camera.CamPos.X, Camera.CamPos.Y)));

            if (spawnPointsWithinTheViewport.Count > 0 && despawnPointsWithinTheViewport.Count > 0)
            {

                if (!AllEnemies.Peek().IsVisible)
                {
                    AllEnemies.Peek().IsVisible = true;
                    AllEnemies.Peek().SpritePosition = spawnPointsWithinTheViewport.ElementAt(Helper.random.Next(spawnPointsWithinTheViewport.Count)).SpritePosition;
                    AllEnemies.Peek().TargetDestination = despawnPointsWithinTheViewport.ElementAt(Helper.random.Next(despawnPointsWithinTheViewport.Count)).SpritePosition;
                }
            }

            if (AllEnemies.Peek().IsVisible)
            {
                AllEnemies.Peek().Update(gameTime);
                if (AllEnemies.Peek().TargetReached)
                {
                                   
                    AllEnemies.Enqueue(AllEnemies.Dequeue());
                }

            }


            if(Collectables.Count <= 0)
            {
                Gameover= true;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(TextureManager.AllTextures[BackgroundTextureKey], Vector2.Zero, Color.White);
            

            spriteBatch.End();
            AllTheSpritesWithinTheScene.ForEach(c => c.Draw(spriteBatch));
        }


    }
    
}
