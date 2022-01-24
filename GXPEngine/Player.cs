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
        x = 400;
        y = 300;
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
        string output = x.ToString() + " , " + y.ToString();
        //Console.WriteLine(output);
    }
    void MovePlayer()
    {

        if (Input.GetKey(68) && x < 800)
        {
            //Move(movementSpeed * Time.deltaTime, 0);
            x += movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(65) && x > 0)
        {
            //Move(-movementSpeed * Time.deltaTime, 0);
            x -= movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(87)&& y > 0)
        {
            //Move(0, -movementSpeed * Time.deltaTime);
            y -= movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(83) && y < 600)
        {
            //Move(0, movementSpeed * Time.deltaTime);
            y += movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(69))
        {
            rotation += rotateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(81))
        {
            rotation -= rotateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(32))
        {
            Shoot();
        }
    }
}
