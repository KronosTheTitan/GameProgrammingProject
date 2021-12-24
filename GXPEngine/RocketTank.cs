using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class RocketTank : Sprite
{
    Scene activeScene;
    public RocketTank(Scene scene) : base("colors.png")
    {
        activeScene = scene;
        createCollider();
        x = 100;
        y = 100;
    }
    void Update()
    {
        CheckCollision();
    }
    void CheckCollision()
    {
        if (HitTest(activeScene.player))
        {
            activeScene.player.rockets += 1;
            Destroy();
        }
    }
}
