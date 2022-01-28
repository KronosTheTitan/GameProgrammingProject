 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Vehicle : Sprite
{
    int health = 0;
    float fireSpeedMS = 500;

    float lastShot;
    public float scoreValue = CoreParameters.scoreLvL1;

    float rotateSpeed = 0.2f;

    float targetRotation;

    public Scene activeScene;
    public Vehicle(Scene scene,string sprite) : base(sprite)
    {
        SetOrigin(width / 2, height / 2);
        activeScene = scene;
        createCollider();
        lastShot = Time.time + Utils.Random(1000,1500);
        ChangeHealth(CoreParameters.healthLvl1,false);
    }
    public void Start()
    {

    }
    public virtual void Update()
    {
        if(health <= 0)
        {
            activeScene.RemoveEnemy(this);
        }
        AI();
        //rotation += LookAt(scene.Player);
    }
    public int ChangeHealth(int healthModifier,bool explodeOnDeath)
    {
        health += healthModifier;
        if(health <= 0 && explodeOnDeath)
        {
            Explosion explosion = new Explosion(CoreParameters.explosionLvL1, activeScene, x, y);
        }
        return health;
    }
    public void Shoot()
    {
        if (lastShot + fireSpeedMS < Time.time)
        {
            lastShot = Time.time;
            Bullet bullet = new Bullet(rotation - 90, x, y,this);
            activeScene.AddChild(bullet);
        }
    }
    public void ShootRocket(int rocketcount)
    {
        if (lastShot + fireSpeedMS < Time.time && rocketcount > 0)
        {
            lastShot = Time.time;
            Rocket rocket = new Rocket(rotation - 90, x, y, this);
            activeScene.AddChild(rocket);
        }
    }
    void AI()
    {
        if (DistanceTo(activeScene.player) < 400)
        {
            if (Input.GetKey(Key.LEFT_SHIFT))
            {
            Console.WriteLine("Player pos: {0},{1}",activeScene.player.x, activeScene.player.y);
            Console.WriteLine("My pos: {0},{1}",x,y);
            }
            targetRotation = Mathf.Atan2(activeScene.player.y - y, activeScene.player.x - x) * 180 / (Mathf.PI); // convert from radians to degrees
            targetRotation += 90; // to correc for the sprite rotation
            if(targetRotation <= rotation - 10)
            {
                rotation -= rotateSpeed * Time.deltaTime;
            }
            if (targetRotation >= rotation + 10)
                rotation += rotateSpeed * Time.deltaTime;
        }
        Shoot();
    }
}
