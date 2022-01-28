using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Player : Vehicle
{
    int rockets = 0;

    public float score;

    float movementSpeed = CoreParameters.playerMoveSpeed;
    float rotateSpeed = CoreParameters.playerRotateSpeed;

    public Player(Scene scene) : base(scene, "PNG/Sprites/Ships/spaceShips_007.png")
    {
        SetOrigin(width / 2, height / 2);
        scale = 0.5f;
        activeScene = scene;
        x = 400;
        y = 300;
        createCollider();
        ChangeHealth(14, false);
    }
    public override void Update()
    {
        if (ChangeHealth(0, false) <= 0)
        {
            activeScene.GameOver();
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
        if (Input.GetKey(87) && y > 0)
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
        if (Input.GetKeyDown(86))
        {
            ShootRocket(rockets);
        }
    }
    public int ChangeRockets(int input)
    {
        rockets += input;
        return rockets;
    }
    void ShootRocket(int rocketcount)
    {
        if (lastShot + fireSpeedMS < Time.time && rocketcount > 0)
        {
            lastShot = Time.time;
            rockets--;
            Rocket rocket = new Rocket(rotation - 90, x, y, this);
            activeScene.AddChild(rocket);
        }

    }
}
