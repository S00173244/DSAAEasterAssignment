using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment.Classes
{
     public class Scene
    {
        private string backgroundKey;
        private IList<string> s;
        public Scene(string keyForBackground)
        {
            backgroundKey = keyForBackground;
        }

        public string BackgroundKey
        {
            get
            {
                return backgroundKey;
            }

            set
            {
                backgroundKey = value;
            }
        }
    }
}
