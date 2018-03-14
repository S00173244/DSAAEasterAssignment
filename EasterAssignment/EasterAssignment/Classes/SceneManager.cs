using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment.Classes
{
    public class SceneManager
    {
        private Scene activeScene;
        private Scene previousScene;

        public Scene ActiveScene
        {
            get
            {
                return activeScene;
            }

            set
            {
                activeScene = value;
            }
        }

        public Scene PreviousScene
        {
            get
            {
                return previousScene;
            }

            set
            {
                previousScene = value;
            }
        }
    }
}
