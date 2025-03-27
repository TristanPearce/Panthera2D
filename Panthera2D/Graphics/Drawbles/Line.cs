using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Panthera2D.Graphics.Drawbles;

public class Line
{
    public Vector2 Start { get; set; }
    public Vector2 End { get; set; }
    public Color Color { get; set; }
    public float Thickness { get; set; }
}
