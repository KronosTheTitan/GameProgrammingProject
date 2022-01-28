using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Projectile : Sprite
{
    public float speed;
    Vehicle shooter;
    float creationTime;
    bool expires;
    public Projectile(float ispeed, Vehicle iShooter,string sprite,bool iexpires = true) : base(sprite)
    {
        speed = ispeed;
        shooter = iShooter;
        expires = iexpires;
        SetOrigin(width / 2, height / 2);
        creationTime = Time.time;
    }
    public void Update()
    {
        if (creationTime + CoreParameters.projectileLifeTime < Time.time && expires)
            Destroy();
        Move(0, speed * Time.deltaTime);
        GameObject[] collisions = GetCollisions();
        if (collisions.Length > 0)
        {
            foreach (GameObject gameObject in collisions)
            {
                if (!(gameObject is RocketTank) && gameObject != shooter)
                {
                    onHit(gameObject, shooter);
                }
            }
        }
    }
    public virtual void onHit(GameObject target, Vehicle shooter)
    {

    }
}
