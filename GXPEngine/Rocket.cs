using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Rocket : Projectile
{
    public Rocket(float direction, float ix, float iy, Vehicle shooter) : base(1, shooter, "PNG/Sprites/Missiles/spaceMissiles_021.png")
    {
        rotation = direction - 90;
        SetScaleXY(-1);
        x = ix;
        y = iy;
    }
    public override void onHit(GameObject target, Vehicle shooter)
    {
        if (target is Vehicle)
        {
            Vehicle veh = (Vehicle)target; // casting
            veh.ChangeHealth(-1,false);
            Explosion explosion = new Explosion(CoreParameters.rocketExplosionSize, shooter.activeScene, x, y);
            if (shooter is Player)
            {
                Player player = (Player)shooter;
                player.score += veh.scoreValue;
            }
            Destroy();
        }
        else
        {
            if (target is Asteroid)
            {
                shooter.activeScene.RemoveChild(this);
                Explosion explosion = new Explosion(CoreParameters.rocketExplosionSize, shooter.activeScene, x, y);
                Destroy();
            }
        }
    }
}
