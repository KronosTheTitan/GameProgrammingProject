using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Player : Vehicle
{
    public int rockets = 0;

    public float score;

    public Player(Scene scene) : base(scene)
    {
        SetOrigin(width/2,height/2);
        activeScene = scene;
        x = activeScene.width/2;
        y = activeScene.height/2;
        createCollider();
        health = 5;
    }
    public override void Update()
    {
        if (health <= 0)
        {
            Destroy();
        }
        //Scene.collisionManager.GetCurrentCollisions(this,false,true);
        MovePlayer();
        Shoot();
        string output = x.ToString() + " , " + y.ToString();
        //Console.WriteLine(output);
    }
    void MovePlayer()
    {

        if (Input.GetKey(68))
        {
            Move(movementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(65))
        {
            Move(-movementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(87))
        {
            Move(0, -movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(83))
        {
            Move(0, movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(69))
        {
            rotation += rotateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(81))
        {
            rotation -= rotateSpeed * Time.deltaTime;
        }
    }
    public override void Shoot()
    {
        if (Input.GetKey(32) && lastShot + fireSpeedMS < Time.time)
        {
            lastShot = Time.time;
            Bullet bullet = new Bullet(rotation-90,x,y);
            bullet.shooter = this;
            activeScene.AddChild(bullet);
            Console.WriteLine("bullet fired");
        }
        if ((Input.GetKey(86) && lastShot + fireSpeedMS < Time.time) && rockets > 0)
        {
            lastShot = Time.time;
            Rocket rocket = new Rocket(rotation-90,x,y);
            rocket.shooter = this;
            activeScene.AddChild(rocket);
            rockets--;
            Console.WriteLine("rocket fired");
        }
    }
}
