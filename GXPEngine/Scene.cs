using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
class Scene : Sprite
{
    public Scene() : base("checkers.png")
    {

    }
    public Player player;
    public CollisionManager collisionManager = new CollisionManager();
    public List<Bullet> bullets = new List<Bullet>();
}
