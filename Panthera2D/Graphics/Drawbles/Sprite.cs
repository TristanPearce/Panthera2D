using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Panthera2D.Graphics.Drawbles;

public class Sprite
{
    public Vector2 Position { get; set; }
    public Vector2 Scale { get; set; }

    public Texture2D Texture { get; set; }
}
