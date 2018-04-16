using EasterAssignment.Classes;
using EasterAssignment.Classes.ContentManagerClasses;
using EasterAssignment.Classes.SceneClasses;
using EasterAssignment.Classes.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using EasterAssignment.Classes.ServiceClasses;

namespace EasterAssignment
{
    public class GameInitializer
    {
        
        Game game;
        ContentManager contentManager;

        public GameInitializer(Game currentGame, ContentManager currentContentManager)
        {
            game = currentGame;
            contentManager = currentContentManager;
        }
        
        public SceneManager InitializeTheGame()
        {
            game.IsMouseVisible = true;
           
            Helper.CurrentGame = game;
            CreateMap();
            LoadContents();
           
            SetupInputEngine();
            LoadSpriteFont();
            return CreateScenes();
        }

        public SceneManager CreateScenes()
        {
            SceneManager sceneManager = new SceneManager();
            sceneManager.AllScenes = new Stack<IScene>();


            try
            {
                MenuScene menuScene = new MenuScene();
                menuScene.BackgroundTextureKey = "menu";
                menuScene.AllTheSpritesWithinTheScene = new List<IBaseSprite>();
                MenuItemSprite menu1 = new MenuItemSprite("MI1","Play", "rectangle", new Vector2(100,100));
                MenuItemSprite menu2 = new MenuItemSprite("MI2", "HighScores", "rectangle", new Vector2(100,200));
                MenuItemSprite menu3 = new MenuItemSprite("MI3", "Exit", "rectangle", new Vector2(100,300));
                menuScene.AllTheSpritesWithinTheScene.Add(menu1);
                menuScene.AllTheSpritesWithinTheScene.Add(menu2);
                menuScene.AllTheSpritesWithinTheScene.Add(menu3);
                sceneManager.ActiveScene = menuScene;


                PlayScene playScene = new PlayScene();
                playScene.BackgroundTextureKey = "play";
                playScene.AllTheSpritesWithinTheScene = new List<IBaseSprite>();
                playScene.Player = new PlayerSprite();
                playScene.Player = CreatePlayer();
                Helper.currentPlayer = playScene.Player;
                playScene.AllTheSpritesWithinTheScene.Add(playScene.Player);
                playScene.Collectables = new List<Collectable>();
                playScene.Collectables = CreateCollectables(Helper.random.Next(10, 20));
                playScene.AllTheSpritesWithinTheScene.AddRange(playScene.Collectables);
                playScene.AllSpawnPoints = new List<SpawnPoint>();
                playScene.AllSpawnPoints = CreateSpawnPoints();
                playScene.AllTheSpritesWithinTheScene.AddRange(playScene.AllSpawnPoints);
                playScene.AllDespawnPoints = new List<DespawnPoint>();
                playScene.AllDespawnPoints = CreateDespawnPoints();
                playScene.AllTheSpritesWithinTheScene.AddRange(playScene.AllDespawnPoints);
                playScene.AllEnemies = new Queue<EnemySprite>();
                playScene.AllEnemies = CreateEnemies();
                playScene.AllTheSpritesWithinTheScene.AddRange(playScene.AllEnemies);
            sceneManager.AllScenes.Push(playScene);

        }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating Scenes : {0}", e.Message);

            }

           

            return sceneManager;
        }

        public List<SpawnPoint> CreateSpawnPoints()
        {
            List<SpawnPoint> allSpawnPoints = new List<SpawnPoint>();

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    SpawnPoint spawnpoint = new SpawnPoint("SP" + (i + 1), new Vector2(Helper.random.Next((int)Map.MapSize.X), Helper.random.Next((int)Map.MapSize.Y)), "spawn");
                    spawnpoint.SpritePosition = Vector2.Clamp(spawnpoint.SpritePosition, Vector2.Zero, Map.MapSize);

                    allSpawnPoints.Add(spawnpoint);
                }
               
            }
            catch (Exception e)
            {

                Console.WriteLine("Error while creating Spawnpoints : {0}", e.Message);
            }

           


            return allSpawnPoints;

        }
        public List<DespawnPoint> CreateDespawnPoints()
        {
            List<DespawnPoint> allDespawnPoints = new List<DespawnPoint>();

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    DespawnPoint despawnpoint = new DespawnPoint("SP" + (i + 1), new Vector2(Helper.random.Next((int)Map.MapSize.X), Helper.random.Next((int)Map.MapSize.Y)), "despawn");
                    despawnpoint.SpritePosition = Vector2.Clamp(despawnpoint.SpritePosition, Vector2.Zero, Map.MapSize);
                    allDespawnPoints.Add(despawnpoint);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine("Error while creating Despawnpoints : {0}", e.Message);
            }




            return allDespawnPoints;

        }

        public Queue<EnemySprite> CreateEnemies()
        {

            Queue<EnemySprite> allEnemies = new Queue<EnemySprite>();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    EnemySprite enemy = new EnemySprite("E" + 1, "enemy", new Vector2(0, 0), Helper.random.Next(5, 10));
                    enemy.Speed = Helper.random.Next(5, 10);
                    enemy.IsVisible = false;
                    allEnemies.Enqueue(enemy);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating Enemies : {0}", e.Message);

            }
            
            return allEnemies;
        }
        public void CreateMap()
        {
            try
            {
                Map.MapSize = new Vector2(2000, 2000);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error while creating Map : {0}", e.Message);
               
            }
           

        }

        
        public List<Collectable> CreateCollectables(int numOfCollectables)
        {
            try
            {
                List<Collectable> collectableList = new List<Collectable>();
                for (int i = 0; i < numOfCollectables; i++)
                {
                    Collectable collectable = new Collectable("C" + i, new Vector2(Helper.random.Next((int)Map.MapSize.X), Helper.random.Next((int)Map.MapSize.Y)), "collectable");
                    
                    collectableList.Add(collectable);
                }
                return collectableList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating Collectables : {0}",e.Message);
                return null;
            }

        }


        public PlayerSprite CreatePlayer()
        {
            try
            {
                PlayerSprite player = new PlayerSprite("P1", new Vector2(Helper.random.Next((int)Map.MapSize.X), Helper.random.Next((int)Map.MapSize.Y)), "player");
                player.Speed = 5;
                SetupCamera(player);
                
                return player;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating Player : {0}", e.Message);
                return null;
            }
                      
        }

        public void LoadContents()
        {
            try
            {
                TextureManager.AllTextures = Loader.ContentLoad<Texture2D>(contentManager, "Images");
            }
            catch (Exception e)
            {

                Console.WriteLine("Error while loading textures : {0}", e.Message);
            }

            try
            {
                AudioManager.AllSoundEffects = Loader.ContentLoad<SoundEffect>(contentManager, "Sounds");
            }
            catch (Exception e)
            {

                Console.WriteLine("Error while loading sounds : {0}", e.Message);
            }
        }
       

        public void SetupCamera(PlayerSprite player)
        {
            new Camera(game, player.SpritePosition, Map.MapSize);
            Camera.player = player;
        }

        public void SetupInputEngine()
        {
            new InputEngine(game);
        }

        public void LoadSpriteFont()
        {
            Helper.SpriteFont = contentManager.Load<SpriteFont>("Fonts/menuItemFont");
        }

    }
}
