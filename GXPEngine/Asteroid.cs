using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Asteroid : Sprite
{
    public Asteroid(float size, Scene scene) : base("PNG/Sprites/Meteors/spaceMeteors_002.png")
    {
        bool valid = false;
        while (!valid)
        {
            x = RandomFloat.GetRandom(0, 800);
            y = RandomFloat.GetRandom(0, 600);
            rotation = Utils.Random(0, 359);
            if (scene.player.DistanceTo(this) > 150)
            {
                valid = true;
                Console.WriteLine(DistanceTo(scene.player));
            }
        }
        scale = size;
        scene.AddChild(this);
    }
}
