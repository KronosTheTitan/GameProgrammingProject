using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Bullet : Sprite
{
    float speed = 1;
    public Bullet(float direction) : base("colors.png")
    {
        rotation = direction;
    }
    void Update()
    {
        Move(speed * Time.deltaTime, 0);
    }
}
