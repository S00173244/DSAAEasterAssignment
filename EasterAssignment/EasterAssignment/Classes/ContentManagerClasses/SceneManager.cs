using EasterAssignment.Classes.SceneClasses;
using EasterAssignment.Classes.ServiceClasses;
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

        public void Update()
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


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ActiveScene.AllTheSpritesWithinTheScene.ForEach(c => c.Draw(spriteBatch));
        }

        public IScene CreateHighscoreScene() {

            IScene highscoreScene = new HighscoreScene();

            return highscoreScene;
        }
    }
        
       

    
}
