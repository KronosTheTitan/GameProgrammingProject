using GXPEngine;

class Explosion : AnimationSprite
{
    float creationTime;
    Sound sound = new Sound("mixkit-fire-explosion-1343.wav");
    Scene scene;
    public Explosion(float size, Scene iScene,float ix,float iy) : base("explosion1.png",8,8)
    {
        creationTime = Time.time;
        SetOrigin(width / 2, height / 2);
        scale = size;
        scene = iScene;
        x = ix;
        y = iy;
        SetFrame(0);
        SetCycle(1, 64);
        scene.AddChild(this);
        sound.Play();        
    }
    void Update()
    {
        if(Time.time > creationTime + CoreParameters.explosionDuration)
        {
            scene.RemoveChild(this);
            Destroy();
        }
        GameObject[] collisions = GetCollisions();
        if (collisions.Length > 0)
        {
            foreach (GameObject gameObject in collisions)
            {
                if(gameObject is Vehicle)
                {
                    Vehicle veh = (Vehicle)gameObject;
                    veh.ChangeHealth(-2,false);
                    scene.player.score += veh.scoreValue;
                }
            }
        }
        Animate(0.4f);
    }
}