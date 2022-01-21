 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Vehicle : Sprite
{
    public int health = 3;
    public float fireSpeedMS = 1000;

    public float lastShot;
    public float scoreValue = CoreParameters.scoreLvL1;

    public float movementSpeed = 1;
    public float rotateSpeed = 1;

    public float targetRotation;

    public Scene activeScene;
    public Vehicle(Scene scene) : base("triangle.png")
    {
        SetOrigin(width / 2, height / 2);
        activeScene = scene;
        x = 250;
        y = 250;
        createCollider();
    }
    public void Start()
    {

    }
    public virtual void Update()
    {
        if(health <= 0)
        {
            activeScene.enemies.Remove(this);
            Destroy();
        }
        Shoot();
        AI();
        //rotation += LookAt(scene.Player);
    }
    public void whenHit(int damage)
    {
        health -= damage;
    }
    public virtual void Shoot()
    {
        if (lastShot + fireSpeedMS < Time.time)
        {
            lastShot = Time.time;
            Bullet bullet = new Bullet(rotation - 90, x, y);
            bullet.shooter = this;
            activeScene.AddChild(bullet);
        }
    }
    public virtual void AI()
    {
        targetRotation = Mathf.Atan2(activeScene.player.y, activeScene.player.x);
        if(targetRotation != rotation - 10 || targetRotation != rotation + 10)
        {
            //rotation -= rotateSpeed * Time.deltaTime;
        }
        if(DistanceTo(activeScene.player)>200)
        {
            
        }
    }
}
