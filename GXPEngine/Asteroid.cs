using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;

class Asteroid : Sprite
{
    public Asteroid(TiledObject obj = null) : base("PNG/Sprites/Meteors/spaceMeteors_002.png")
    {
        x = obj.X;
        y = obj.Y;
        scaleX = obj.Width;
        scaleY = obj.Height;
        rotation = obj.Rotation;
    }
}
