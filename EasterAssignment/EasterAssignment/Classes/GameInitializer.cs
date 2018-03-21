using EasterAssignment.Classes;
using EasterAssignment.Classes.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment
{
    public class GameInitializer
    {
        Random rn = new Random();

        
        public void CreateScenes()
        {
            
            try
            {
                Scene menuScene = new Scene("", Keys.Escape);
                MenuItemSprite menu1 = new MenuItemSprite("MI1","Play", "", new Vector2());
                MenuItemSprite menu2 = new MenuItemSprite("MI1", "HighScores", "", new Vector2());
                MenuItemSprite menu3 = new MenuItemSprite("MI1", "Exit", "", new Vector2());

            }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating Menu Scene : {0}", e.Message);

            }


            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating Play Scene : {0}", e.Message);
                
            }
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
                return player;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating Player : {0}", e.Message);
                return null;
            }
                      
        }


       



    }
}
