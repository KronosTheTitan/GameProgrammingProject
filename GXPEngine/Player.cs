using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Player : Sprite
{
    float movementSpeed = 1;
    float rotateSpeed = 1;
    float fireSpeedMS = 1000;

    float lastShot;
    Scene activeScene = new Scene();
    public Player() : base("triangle.png")
    {
        SetOrigin(width/2,height/2);
        //createCollider();
    }
    void Update()
    {
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
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastShot = Time.time;
            new Bullet(rotation);
            Console.WriteLine("shot fired");
        }
    }
}
