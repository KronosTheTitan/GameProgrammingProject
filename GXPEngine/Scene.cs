using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
class Scene : GameObject
{
    public Player player { get; private set; } // only public get, no public set
    EasyDraw UI;

    MainMenu mainMenu;

    List<Vehicle> enemies = new List<Vehicle>();
    public RocketTank rocketTank;
    float lastRocket = 0;

    TiledLoader loader = new TiledLoader("main.tmx");
    public Scene(MainMenu iMainMenu)
    {
        mainMenu = iMainMenu;
        CreateScene();
        enemies.Clear();
        player = new Player(this);
        AddChild(player);
        UI = new EasyDraw(800, 600,false);
        AddChild(UI);
    }
    void UpdateUI()
    {
        UI.Clear(0, 0, 0, 0);
        UI.TextAlign(CenterMode.Min, CenterMode.Min);
        UI.Text(player.ChangeHealth(0,false).ToString(), 700, 0);
        UI.TextAlign(CenterMode.Min, CenterMode.Min);
        UI.Text(Math.Round((player.score * 1000)).ToString(), 0, 0);
        UI.Text(player.ChangeRockets(0).ToString(), 0, 20);

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
    bool AssignObjectPosition(Sprite sprite)
    {
        bool valid = false;
        sprite.x = RandomFloat.GetRandom(0, 800);
        sprite.y = RandomFloat.GetRandom(0, 600);
        sprite.rotation = Utils.Random(0, 359);
        this.AddChild(sprite);
        GameObject[] collisions = sprite.GetCollisions();
        if (player.DistanceTo(sprite) > 200)
        {
            if (collisions.Length < 1)
            {
                Console.WriteLine("ouside of collision " + collisions.Length);
                valid = true;
            }
            else
            {
                Console.WriteLine("Collision! at x : " + sprite.x + " y : " + sprite.y + " count : " + collisions.Length);
                foreach(GameObject gameObject in collisions)
                {
                    Console.WriteLine(gameObject.GetType());
                }
            }
        }
        if (!valid)
        {
            if (sprite is Vehicle && !(sprite is Player))
            {
                Vehicle veh = (Vehicle)sprite;
                RemoveEnemy(veh);
                return true;
            }
            else
            {
                if (sprite is RocketTank)
                    rocketTank = null;
                sprite.Destroy();
                return false;
            }
        }                                                             
        else
            return true;
    }
    public void RemoveEnemy(Vehicle vehicle)
    {
        Console.WriteLine("removed Enemy");
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
    void CreateScene(bool includeImageLayers = true)
    {
        loader.autoInstance = true;
        loader.addColliders = false;
        loader.rootObject = game;
        if (includeImageLayers) loader.LoadImageLayers();
        loader.rootObject = this;
        loader.LoadTileLayers(0);
        loader.addColliders = true;
        loader.LoadTileLayers(1);
        loader.LoadObjectGroups();
    }
}
