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
    public override void onHit(GameObject target,Vehicle shooter)
    {
        if (target is Vehicle)
        {
            Vehicle veh = (Vehicle)target; // casting
            veh.whenHit(1);
            if(shooter is Player)
            {
                Player player = (Player)shooter;
                player.score += veh.scoreValue;
            }
            Destroy();
        }

    }
}
