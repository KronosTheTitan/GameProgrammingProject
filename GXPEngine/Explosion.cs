using GXPEngine;

class Explosion : Sprite
{
    float creationTime;
    Scene scene;
    public Explosion(float size, Scene iScene) : base("Square")
    {
        creationTime = Time.time;
        scene = iScene;
        createCollider();
    }
    void Update()
    {
        if(Time.time > creationTime + CoreParameters.explosionDuration)
        {
            scene.RemoveChild(this);
            Destroy();
        }
    }
}