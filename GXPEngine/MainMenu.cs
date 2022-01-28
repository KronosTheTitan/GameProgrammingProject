using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.IO;
using System.Threading.Tasks;

class MainMenu : GameObject
{
    MyGame myGame;
    StartButton button;
    public int highScore = 0;
    EasyDraw UI;
    public MainMenu(MyGame iMyGame)
    {
        myGame = iMyGame;
        button = new StartButton();
        AddChild(button);
        UI = new EasyDraw(800,600);
        AddChild(UI);
        ReadHighScore();
    }
    void Update()
    {
        if(Input.GetMouseButtonUp(0) && visible)
        {
            if (button.HitTestPoint(Input.mouseX, Input.mouseY))
                StartGame();
        }
        UI.Clear(0, 0, 0, 0);
        UI.TextAlign(CenterMode.Center, CenterMode.Center);
        UI.Text("Current high score : " + highScore.ToString(),400,200);
    }
    void StartGame()
    {
        visible = false;
        myGame.AddChild(new Scene(this));
    }
    public void SaveHighScore()
    {
        string text =
            highScore.ToString();

        File.WriteAllText("HighScore.txt", text);
    }
    void ReadHighScore()
    {
        string text = File.ReadAllText("HighScore.txt");
        Int32.TryParse(text, out highScore);
    }
}
