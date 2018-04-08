using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment.Classes.ContentManagerClasses
{
    public static class SceneManager
    {
        public static Stack<IScene> AllScenes { get; set; }
        public static IScene ActiveScene { get; set; }
        public static IScene PreviousScene { get; set; }
        public static Keys ChangeSceneKey = Keys.Escape;
        
       

    }
}
