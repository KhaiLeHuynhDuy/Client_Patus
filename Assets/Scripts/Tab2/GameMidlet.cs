using UnityEngine;

public class GameMidlet2
{
    public static string IP = "";

    public static int PORT = 14445;

    public static string IP2;

    public static int PORT2;

    public static sbyte PROVIDER;

    public static int LANGUAGE;

    public static string VERSION = GameMidlet.VERSION;

    public static GameCanvas2 gameCanvas;

    public static GameMidlet2 instance;

    public static bool isConnect2;

    public static bool isBackWindowsPhone;

    public GameMidlet2()
    {
        initGame();
    }

    public void initGame()
    {
        instance = this;
        MotherCanvas2.instance = new MotherCanvas2();
        Session_ME2_.gI().setHandler(Controller2_.gI());
        Session_ME2_2.gI().setHandler(Controller2_.gI());
        Session_ME2_2.isMainSession = false;
        instance = this;
        gameCanvas = new GameCanvas2();
        gameCanvas.start();
        SplashScr2.LoadImg();
        SplashScr2.loadSplashScr();
        GameCanvas2.currentScreen = new SplashScr2();
    }

    public void exit()
    {
        if (Main2.typeClient == 6)
        {
            mSystem2.exitWP();
            return;
        }
        GameCanvas2.bRun = false;
        mSystem2.gcc();
        notifyDestroyed();
    }

    public void notifyDestroyed()
    {
        Main2.exit();
    }

    public void platformRequest(string url)
    {
        Application.OpenURL(url);
    }
}
