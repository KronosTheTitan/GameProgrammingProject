using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Vehicle : Sprite
{
    int health = 3;
    public Vehicle() : base("triangle.png")
    {
        x = 250;
        y = 250;
        createCollider();
    }
    void Update()
    {
        if(health <= 0)
        {
            Destroy();
        }
    }
    public void whenHit(int damage)
    {
        health -= damage;
    }
}
