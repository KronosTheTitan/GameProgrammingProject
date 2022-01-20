using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
class Scene : Sprite
{
    public Player player;
    public CollisionManager collisionManager = new CollisionManager();
    public List<Vehicle> enemies = new List<Vehicle>();
    public Scene() : base("checkers.png")
    {
        enemies.Clear();
    }
    public void Update()
    {
        if (enemies.Count < player.score + 3)
        {
            var newEnemy = new Vehicle(this);
            enemies.Add(newEnemy);
            AssignSpawnPosition(newEnemy);
        }        
    }
    public void AssignSpawnPosition(Vehicle vehicle)
    {
        bool valid = false;
        while (!valid)
        {
            vehicle.x = RandomFloat.GetRandom(0, 800);
            vehicle.y = RandomFloat.GetRandom(0, 600);
            if (player.DistanceTo(vehicle) > 5)
                valid = true;
        }
        this.AddChild(vehicle);
    }
}
