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
        x = ix;
        y = iy;
    }
    public override void onHit(GameObject target)
    {
        if(target is Vehicle)
        {
            Vehicle veh = (Vehicle)target; // casting
            veh.whenHit(1);
            Destroy();
        }
    }

}
