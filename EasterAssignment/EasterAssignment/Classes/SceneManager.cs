using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment.Classes
{
    public static class SceneManager
    {
        public static Stack<Scene> AllScenes { get; set; }
        public static Scene ActiveScene { get; set; }
        public static Scene PreviousScene { get; set; }
        
    }
}
