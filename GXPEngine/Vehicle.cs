 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Vehicle : Sprite
{
    public int health = 1;
    float fireSpeedMS = 500;

    float lastShot;
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
        lastShot = Time.time + Utils.Random(1000,1500);
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
        Shoot();
        AI();
        //rotation += LookAt(scene.Player);
    }
    public void whenHit(int damage)
    {
        health -= damage;
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
    public virtual void AI()
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
        if (DistanceTo(activeScene.player)>200)
        {
            
        }
    }
}
