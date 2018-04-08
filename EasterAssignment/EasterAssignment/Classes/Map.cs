using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment.Classes
{
    public static class Map
    {
        private static Vector2 mapSize;

        public static Vector2 MapSize
        {
            get
            {
                return mapSize;
            }

            set
            {
                mapSize = value;
            }
        }
    }
}
