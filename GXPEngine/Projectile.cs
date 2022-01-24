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
    public Projectile(float ispeed, Vehicle iShooter) : base("circle.png")
    {
        speed = ispeed;
        shooter = iShooter;
        SetOrigin(width / 2, height / 2);
        creationTime = Time.time;
    }
    public void Update()
    {
        if (creationTime + CoreParameters.projectileLifeTime < Time.time)
            Destroy();
        Move(speed * Time.deltaTime, 0);
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
