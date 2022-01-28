using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
class Scene : GameObject
{
    public Player player { get; private set; } // only public get, no public set
    EasyDraw UI;

    MainMenu mainMenu;

    List<Vehicle> enemies = new List<Vehicle>();
    public RocketTank rocketTank;
    Asteroid[] asteroids = new Asteroid[3];
    float lastRocket = 0;
    public Scene(MainMenu iMainMenu)
    {
        mainMenu = iMainMenu;
        enemies.Clear();
        player = new Player(this);
        AddChild(player);
        for (int i = 0; i < 3; i++)
        {
            asteroids[i] = new Asteroid(Utils.Random(1, 2), this);
        }
        AssignObjectPosition(player);
        UI = new EasyDraw(800, 600);
        AddChild(UI);
    }
    void UpdateUI()
    {
        UI.Clear(0, 0, 0, 0);
        UI.TextAlign(CenterMode.Min, CenterMode.Min);
        UI.Text(player.ChangeHealth(0,false).ToString(), 700, 0);
        UI.TextAlign(CenterMode.Min, CenterMode.Min);
        UI.Text(Math.Round((player.score * 1000)).ToString(), 0, 0);

    }
    void Update()
    {
        if (enemies.Count < player.score + 3)
        {
            var newEnemy = new Vehicle(this, "PNG/Sprites/Ships/spaceShips_001.png");
            enemies.Add(newEnemy);
            AssignObjectPosition(newEnemy);
        }
        if(Time.time > lastRocket + CoreParameters.rocketSpawnInterval && rocketTank == null)
        {
            rocketTank = new RocketTank(this);
            AssignObjectPosition(rocketTank);
            lastRocket = Time.time;
        }
        UpdateUI();
    }
    void AssignObjectPosition(Sprite sprite)
    {
        bool valid = false;
        while (!valid)
        {
            sprite.x = RandomFloat.GetRandom(0, 800);
            sprite.y = RandomFloat.GetRandom(0, 600);
            sprite.rotation = Utils.Random(0, 359);
            GameObject[] collisions = GetCollisions();
            if (player.DistanceTo(sprite) > 200 || sprite is Player)
            {
                if(collisions.Length <= 0)
                {
                    Console.WriteLine("ouside of collision " + collisions.Length);
                    valid = true;
                }
            }
        }
        this.AddChild(sprite);
        Console.WriteLine("complete");
    }
    public void RemoveEnemy(Vehicle vehicle)
    {
        enemies.Remove(vehicle);
        RemoveChild(vehicle);
        vehicle.Destroy();
    }
    public void GameOver()
    {
        mainMenu.visible = true;
        if (mainMenu.highScore < player.score * 1000)
        {
            mainMenu.highScore = (int)player.score * 1000;
            mainMenu.SaveHighScore();
        }
        Destroy();
    }
}
