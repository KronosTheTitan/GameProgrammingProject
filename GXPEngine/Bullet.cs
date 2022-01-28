using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Bullet : Projectile
{
    public Bullet(float direction, float ix, float iy,Vehicle shooter) : base(0.5f,shooter, "PNG/Sprites/Missiles/spaceMissiles_018.png")
    {
        rotation = direction-90;
        SetScaleXY(-1);
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
                veh.ChangeHealth(-1,true);
                if(veh.ChangeHealth(0,false) == 0)
                    player.score += veh.scoreValue;
                Destroy();
            }
            else
            {
                if (veh is Player)
                    veh.ChangeHealth(-1,true);
                shooter.activeScene.RemoveChild(this);
                Destroy();
            }
        }
        else
        {
            if(target is Asteroid)
            {
                shooter.activeScene.RemoveChild(this);
                Destroy();
            }
        }
    }
}
