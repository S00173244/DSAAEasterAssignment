using EasterAssignment.Classes.SceneClasses;
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

namespace EasterAssignment.Classes.ContentManagerClasses
{
    public class SceneManager
    {
        
        public Stack<IScene> AllScenes { get; set; }
        
        public IScene ActiveScene { get; set; }
        public IScene PreviousScene { get; set; }
        public static Keys ChangeSceneKey = Keys.Escape;
        LinkedList<HighScoreData> AllHighScores;


        public SceneManager()
        {
            AllHighScores = new LinkedList<HighScoreData>();
        }
        public void Update(GameTime gameTime)
        {
            if (ActiveScene.GetType().Name == "MenuScene")
            {
                
                MenuItemSprite s = ActiveScene.AllTheSpritesWithinTheScene.OfType<MenuItemSprite>().FirstOrDefault(x => x.Bounds.Contains(InputEngine.MousePosition) && InputEngine.IsMouseLeftClick());
                
                if(s!= null)
                {
                    if (s.SpriteID == "MI1")
                    {
                        PreviousScene = ActiveScene;
                        ActiveScene = AllScenes.Pop();
                        AllScenes.Push(PreviousScene);


                    }
                    else if (s.SpriteID == "MI2")
                    {
                        PreviousScene = ActiveScene;
                        ActiveScene = CreateHighscoreScene();
                        AllScenes.Push(PreviousScene);
                    }
                    else if (s.SpriteID == "MI3")
                    {
                        Helper.CurrentGame.Exit();
                    }
                }
                
            }else if (InputEngine.IsKeyPressed(ChangeSceneKey) )
            {
                if(ActiveScene.GetType().Name == "PlayScene")
                {
                    PreviousScene = ActiveScene;
                    ActiveScene = AllScenes.Pop();
                    AllScenes.Push(PreviousScene);
                }else if(ActiveScene.GetType().Name == "HighscoreScene")
                {
                    ActiveScene = AllScenes.Pop();
                }
                
            }


            if (ActiveScene.GetType().Name == "PlayScene")
            {
                ActiveScene.Update(gameTime);
                PlayScene playScene = (PlayScene)ActiveScene;
                if (playScene.Gameover)
                {
                    ActiveScene = CreateHighscoreScene();
                }
            }



        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ActiveScene.Draw(spriteBatch);
            
            
        }


        public PlayScene CreatePlayScene()
        {
            PlayScene playScene = new PlayScene();
            GameInitializer gI = new GameInitializer(Helper.CurrentGame,Helper.CurrentGame.Content);

            playScene.BackgroundTextureKey = "play";
            playScene.AllTheSpritesWithinTheScene = new List<IBaseSprite>();
            playScene.Player = new PlayerSprite();
            playScene.Player = gI.CreatePlayer();
            Helper.currentPlayer = playScene.Player;
            playScene.AllTheSpritesWithinTheScene.Add(playScene.Player);
            playScene.Collectables = new List<Collectable>();
            playScene.Collectables = gI.CreateCollectables(Helper.random.Next(10, 20));
            playScene.AllTheSpritesWithinTheScene.AddRange(playScene.Collectables);
            playScene.AllSpawnPoints = new List<SpawnPoint>();
            playScene.AllSpawnPoints = gI.CreateSpawnPoints();
            playScene.AllTheSpritesWithinTheScene.AddRange(playScene.AllSpawnPoints);
            playScene.AllDespawnPoints = new List<DespawnPoint>();
            playScene.AllDespawnPoints = gI.CreateDespawnPoints();
            playScene.AllTheSpritesWithinTheScene.AddRange(playScene.AllDespawnPoints);
            playScene.AllEnemies = new Queue<EnemySprite>();
            playScene.AllEnemies = gI.CreateEnemies();
            playScene.AllTheSpritesWithinTheScene.AddRange(playScene.AllEnemies);
            

            return playScene;
        }
        public HighscoreScene CreateHighscoreScene() {


            HighscoreScene highscoreScene = new HighscoreScene();


            return highscoreScene;
        }
    }
        
       

    
}
