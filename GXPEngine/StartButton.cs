using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class StartButton : Sprite
{
    public StartButton() : base("Start.png")
    {
        x = 400;
        y = 300;
        SetOrigin(width / 2, height / 2);
        createCollider();
    }
}
