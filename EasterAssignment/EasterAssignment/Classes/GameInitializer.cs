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
        Random rn = new Random();
        Game game;
        ContentManager contentManager;

        public GameInitializer(Game currentGame, ContentManager currentContentManager)
        {
            game = currentGame;
            contentManager = currentContentManager;
        }
        
        public SceneManager InitializeTheGame()
        {
            
            Helper.CurrentGame = game;
            CreateMap();
            LoadContents();
           
            SetupInputEngine();
            LoadSpriteFont();
            return CreateScenes(); ;
        }

        public SceneManager CreateScenes()
        {
            SceneManager sceneManager = new SceneManager();
            MenuScene menuScene = new MenuScene();

            try
            {
                
                MenuItemSprite menu1 = new MenuItemSprite("MI1","Play", "rectangle", new Vector2(100,30));
                MenuItemSprite menu2 = new MenuItemSprite("MI2", "HighScores", "rectangle", new Vector2(100,50));
                MenuItemSprite menu3 = new MenuItemSprite("MI3", "Exit", "rectangle", new Vector2(100,70));
                menuScene.AllTheSpritesWithinTheScene.Add(new MenuItemSprite("MI1", "Play", "rectangle", new Vector2(100, 30)));
                menuScene.AllTheSpritesWithinTheScene.Add(menu2);
                menuScene.AllTheSpritesWithinTheScene.Add(menu3);
                sceneManager.ActiveScene = menuScene;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating Menu Scene : {0}", e.Message);

            }

            

            try
            {
               

                IScene playScene = new PlayScene();
                playScene.AllTheSpritesWithinTheScene.Add(CreatePlayer());
                playScene.AllTheSpritesWithinTheScene.AddRange(CreateCollectables(rn.Next(10,20)));

                sceneManager.AllScenes.Push(playScene);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating Play Scene : {0}", e.Message);
                
            }

            return sceneManager;
        }
        public void CreateMap()
        {
            try
            {
                Map.MapSize = new Vector2(1000, 1000);
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
                    Collectable collectable = new Collectable("C" + i, new Vector2(rn.Next((int)Map.MapSize.X), rn.Next((int)Map.MapSize.Y)), "");
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
                PlayerSprite player = new PlayerSprite("P1", new Vector2(rn.Next((int)Map.MapSize.X), rn.Next((int)Map.MapSize.Y)), "");
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
