using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Bullet : Projectile
{
    public Bullet(float direction, float ix, float iy) : base(2)
    {
        rotation = direction;
        speed = 1;
        x = ix;
        y = iy;
    }
    public override void onHit(GameObject target,Vehicle shooter)
    {
        if(target is Vehicle)
        {
            Vehicle veh = (Vehicle)target; // casting
            if (shooter is Player)
            {
                Player player = (Player)shooter;
                veh.whenHit(1);
                if(veh.health == 0)
                    player.score += veh.scoreValue;
                Destroy();
            }
            else
            {

            }
        }
    }
}
