class CoreParameters
{
    //this is the score value of a level 1 enemy
    public const float scoreLvL1 = 0.05f;
    //this controls the size of the explosion when a level 1 enemy is destroyed
    public const float explosionLvL1 = 3f;
    public const int healthLvl1 = 1;

    //this is the spawn interval for rocket tanks
    public const float rocketSpawnInterval = 10000f;
    //this is the explosion size from a rocket;
    public const float rocketExplosionSize = 10f;

    //this controls the explosion duration in seconds;
    public const float explosionDuration = 1000f;

    //this controls after how much time in seconds a projectile will disappear.
    public const float projectileLifeTime = 5000f;

    //the player health
    public const int playerHealth = 15;

    public const float playerMoveSpeed = 1f;
    public const float playerRotateSpeed = 0.2f;
}