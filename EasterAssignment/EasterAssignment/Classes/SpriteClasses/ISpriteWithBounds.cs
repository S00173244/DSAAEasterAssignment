using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterAssignment.Classes.SpriteClasses
{
    public interface ISpriteWithBounds : IBaseSprite
    {
        Rectangle Bounds { get; set; }
    }
}
