using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Rocket : Projectile
{
    public Rocket(float direction, float ix, float iy) : base(1)
    {
        rotation = direction;
        x = ix;
        y = iy;
    }
}
