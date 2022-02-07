using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class RocketTank : Sprite
{
    Scene activeScene;
    public RocketTank(Scene scene) : base("PNG/Sprites/Building/spaceBuilding_001.png")
    {
        activeScene = scene;
        x = Utils.Random(0,800);
        y = Utils.Random(0,600);
    }
    void Update()
    {
        CheckCollision();
    }
    void CheckCollision()
    {
        if (HitTest(activeScene.player))
        {
            activeScene.player.ChangeRockets(1);
            activeScene.rocketTank = null;
            Destroy();
        }
    }
}
