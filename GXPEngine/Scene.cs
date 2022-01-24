using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
class Scene : GameObject
{
    public Player player { get; private set; } // only public get, no public set
    EasyDraw UI;
    bool playerAlive = true;

    List<Vehicle> enemies = new List<Vehicle>();
    public Scene()
    {
        enemies.Clear();
        player = new Player(this);
        AddChild(player);
        UI = new EasyDraw(800, 600);
        AddChild(UI);
    }
    void UpdateUI()
    {
        UI.Clear(0, 0, 0, 0);
        UI.TextAlign(CenterMode.Min, CenterMode.Min);
        UI.Text(player.health.ToString(), 700, 0);
        UI.TextAlign(CenterMode.Min, CenterMode.Min);
        UI.Text((player.score * 1000).ToString(), 0, 0);

    }
    void Update()
    {
        UpdateUI();
        if (enemies.Count < player.score + 3 && playerAlive)
        {
            var newEnemy = new Vehicle(this);
            enemies.Add(newEnemy);
            AssignSpawnPosition(newEnemy);
        }        
    }
    void AssignSpawnPosition(Vehicle vehicle)
    {
        bool valid = false;
        while (!valid)
        {
            vehicle.x = RandomFloat.GetRandom(0, 800);
            vehicle.y = RandomFloat.GetRandom(0, 600);
            vehicle.rotation = Utils.Random(0, 359);
            if (player.DistanceTo(vehicle) > 50)
            {
                if (vehicle.y < player.y)
                    valid = true;
                else
                {
                    if (vehicle.x > player.x + 50 || vehicle.x < player.x - 50)
                        valid = true;
                }
            }
        }
        this.AddChild(vehicle);
    }
    public void RemoveEnemy(Vehicle vehicle)
    {
        enemies.Remove(vehicle);
        RemoveChild(vehicle);
        vehicle.Destroy();
    }
    public void GameOver()
    {
        foreach(Vehicle vehicle in enemies)
        {
            RemoveEnemy(vehicle);
        }
        playerAlive = false;
    }
}
