using System;
using System.Net.NetworkInformation;
using System.Threading;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main main;

    public static mGraphics g;

    public static GameMidlet midlet;

    public static string res = "res";

    public static string mainThreadName;

    public static bool started;

    public static bool isIpod;

    public static bool isIphone4;

    public static bool isPC;

    public static bool isWindowsPhone;

    public static bool isIPhone;

    public static string IMEI;

    public static int versionIp;

    public static int numberQuit = 1;

    public static int typeClient = 4;

    public const sbyte PC_VERSION = 4;

    public const sbyte IP_APPSTORE = 5;

    public const sbyte WINDOWSPHONE = 6;

    private int level;

    public const sbyte IP_JB = 3;

    private int updateCount;

    private int paintCount;

    private int count;

    private int fps;

    private int max;

    private int up;

    private int upmax;

    private long timefps;

    private long timeup;

    private bool isRun;

    public static int waitTick;

    public static int f;

    public static bool isResume;

    public static bool isMiniApp = true;

    public static bool isQuitApp;

    private Vector2 lastMousePos = default(Vector2);

    public static int a = 1;

    public static bool isCompactDevice = true;

    private void Start()
    {
        if (started)
        {
            return;
        }
        if (Thread.CurrentThread.Name != "Main")
        {
            Thread.CurrentThread.Name = "Main";
        }
        mainThreadName = Thread.CurrentThread.Name;
        isPC = Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer;
        isIPhone = Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android;
        started = true;
        if (isPC)
        {
            level = Rms.loadRMSInt("levelScreenKN");
            if (level == 1)
            {
                Screen.SetResolution(720, 320, fullscreen: false);
            }
            else
            {
                Screen.SetResolution(1024, 600, fullscreen: false);
            }
        }
        else if (isIPhone)
        {
            Screen.fullScreen = true;
            GameCanvas.isTouch = true;
        }
        MainMod.GI().LoadGame();
    }

    private void SetInit()
    {
        base.enabled = true;
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void OnGUI()
    {
        if (count >= 10)
        {
            if (fps == 0)
            {
                timefps = mSystem.currentTimeMillis();
            }
            else if (mSystem.currentTimeMillis() - timefps > 1000)
            {
                max = fps;
                fps = 0;
                timefps = mSystem.currentTimeMillis();
            }
            fps++;
            checkInput();
            Session_ME.update();
            Session_ME2.update();
            if (!isPC && paintCount <= updateCount)
            {
                return;
            }
            if (Event.current.type.Equals(EventType.Repaint) && SceneSwitcher.GetCurrSceneName() == MainMod.sceneName)
            {
                GameMidlet.gameCanvas.paint(g);
                paintCount++;
                g.reset();
            }
        }
    }

    public void setsizeChange()
    {
        if (!isRun)
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Application.runInBackground = true;
            base.useGUILayout = false;
            isCompactDevice = detectCompactDevice();
            if (main == null)
            {
                main = this;
            }
            isRun = true;
            ScaleGUI.initScaleGUI();
            if (isPC)
            {
                IMEI = SystemInfo.deviceUniqueIdentifier;
            }
            else
            {
                IMEI = GetMacAddress();
            }
            isPC = true;
            if (isPC)
            {
                Screen.fullScreen = false;
            }
            if (isIPhone)
            {
                Screen.fullScreen = true;
            }
            if (isPC)
            {
                typeClient = 4;
            }
            if (isWindowsPhone)
            {
                typeClient = 6;
            }
            if (isIPhone)
            {
                typeClient = 4;
            }
            if (iPhoneSettings.generation == iPhoneGeneration.iPodTouch4Gen)
            {
                isIpod = true;
            }
            if (iPhoneSettings.generation == iPhoneGeneration.iPhone4)
            {
                isIphone4 = true;
            }
            g = new mGraphics();
            midlet = new GameMidlet();
            TileMap.loadBg();
            Paint.loadbg();
            PopUp.loadBg();
            GameScr.loadBg();
            InfoMe.gI().loadCharId();
            Panel.loadBg();
            Menu.loadBg();
            Key.mapKeyPC();
            SoundMn.gI().loadSound(TileMap.mapID);
            g.CreateLineMaterial();
        }
    }

    public static void setBackupIcloud(string path)
    {
    }

    public string GetMacAddress()
    {
        string empty = string.Empty;
        NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        for (int i = 0; i < allNetworkInterfaces.Length; i++)
        {
            PhysicalAddress physicalAddress = allNetworkInterfaces[i].GetPhysicalAddress();
            if (physicalAddress.ToString() != string.Empty)
            {
                return physicalAddress.ToString();
            }
        }
        return string.Empty;
    }

    public void doClearRMS(bool isForce)
    {
        if (isForce || isPC)
        {
            int num = Rms.loadRMSInt("lastZoomlevel");
            if (isForce || num != mGraphics.zoomLevel)
            {
                Rms.clearAll();
                Rms.saveRMSString("GameVersion", GameMidlet.VERSION);
                Rms.saveRMSInt("lastZoomlevel", mGraphics.zoomLevel);
                Rms.saveRMSInt("levelScreenKN", level);
                Rms.saveRMSInt("isPaintAura", 1);
            }
        }
    }

    public static void closeKeyBoard()
    {
        if (TouchScreenKeyboard.visible)
        {
            TField.kb.active = false;
            TField.kb = null;
        }
    }

    private void FixedUpdate()
    {
        Rms.update();
        count++;
        if (count >= 10)
        {
            if (up == 0)
            {
                timeup = mSystem.currentTimeMillis();
            }
            else if (mSystem.currentTimeMillis() - timeup > 1000)
            {
                upmax = up;
                up = 0;
                timeup = mSystem.currentTimeMillis();
            }
            up++;
            setsizeChange();
            updateCount++;
            GameMidlet.gameCanvas.update();
            Image.update();
            DataInputStream.update();
            f++;
            if (f > 8)
            {
                f = 0;
            }
            if (!isPC)
            {
                _ = 1 / a;
            }
        }
    }

    private void Update()
    {
    }

    private void checkInput()
    {
        if (SceneSwitcher.GetCurrSceneName() != MainMod.sceneName)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            GameMidlet.gameCanvas.pointerPressed((int)(mousePosition.x / (float)mGraphics.zoomLevel), (int)(((float)Screen.height - mousePosition.y) / (float)mGraphics.zoomLevel) + mGraphics.addYWhenOpenKeyBoard);
            lastMousePos.x = mousePosition.x / (float)mGraphics.zoomLevel;
            lastMousePos.y = mousePosition.y / (float)mGraphics.zoomLevel + (float)mGraphics.addYWhenOpenKeyBoard;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition2 = Input.mousePosition;
            GameMidlet.gameCanvas.pointerDragged((int)(mousePosition2.x / (float)mGraphics.zoomLevel), (int)(((float)Screen.height - mousePosition2.y) / (float)mGraphics.zoomLevel) + mGraphics.addYWhenOpenKeyBoard);
            lastMousePos.x = mousePosition2.x / (float)mGraphics.zoomLevel;
            lastMousePos.y = mousePosition2.y / (float)mGraphics.zoomLevel + (float)mGraphics.addYWhenOpenKeyBoard;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition3 = Input.mousePosition;
            lastMousePos.x = mousePosition3.x / (float)mGraphics.zoomLevel;
            lastMousePos.y = mousePosition3.y / (float)mGraphics.zoomLevel + (float)mGraphics.addYWhenOpenKeyBoard;
            GameMidlet.gameCanvas.pointerReleased((int)(mousePosition3.x / (float)mGraphics.zoomLevel), (int)(((float)Screen.height - mousePosition3.y) / (float)mGraphics.zoomLevel) + mGraphics.addYWhenOpenKeyBoard);
        }
        if (Input.anyKeyDown && Event.current.type == EventType.KeyDown)
        {
            int num = MyKeyMap.map(Event.current.keyCode);
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                switch (Event.current.keyCode)
                {
                    case KeyCode.Alpha2:
                        num = 64;
                        break;
                    case KeyCode.Minus:
                        num = 95;
                        break;
                }
            }
            if (Input.GetKey(KeyCode.LeftControl) && Event.current.keyCode == KeyCode.V)
            {
                try
                {
                    MainMod.pasteText = GUIUtility.systemCopyBuffer;
                    MainMod.pasteText = MainMod.pasteText.Replace(Environment.NewLine, " ").Replace("\t", " ").Replace("  ", " ");
                    if (MainMod.pasteText.Length > 200)
                    {
                        MainMod.pasteText = MainMod.pasteText.Substring(0, 200);
                    }
                }
                catch
                {
                }
            }
            if (num != 0)
            {
                GameMidlet.gameCanvas.keyPressedz(num);
            }
        }
        if (Event.current.type == EventType.KeyUp)
        {
            int num2 = MyKeyMap.map(Event.current.keyCode);
            if (num2 != 0)
            {
                GameMidlet.gameCanvas.keyReleasedz(num2);
            }
        }
        if (isPC)
        {
            GameMidlet.gameCanvas.scrollMouse((int)(Input.GetAxis("Mouse ScrollWheel") * 10f));
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;
            int x2 = (int)x / mGraphics.zoomLevel;
            int y2 = (Screen.height - (int)y) / mGraphics.zoomLevel;
            GameMidlet.gameCanvas.pointerMouse(x2, y2);
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log(">> QUIT <<");
        GameCanvas.bRun = false;
        Session_ME.gI().close();
        Session_ME2.gI().close();
        if (isPC)
        {
            Application.Quit();
        }
    }

    private void OnApplicationPause(bool paused)
    {
        isResume = false;
        if (paused)
        {
            if (GameCanvas.isWaiting())
            {
                isQuitApp = true;
            }
        }
        else
        {
            isResume = true;
        }
        if (TouchScreenKeyboard.visible)
        {
            TField.kb.active = false;
            TField.kb = null;
        }
        if (isQuitApp)
        {
            Application.Quit();
        }
    }

    public static void exit()
    {
        if (isPC)
        {
            main.OnApplicationQuit();
        }
        else
        {
            a = 0;
        }
    }

    public static bool detectCompactDevice()
    {
        if (iPhoneSettings.generation == iPhoneGeneration.iPhone || iPhoneSettings.generation == iPhoneGeneration.iPhone3G || iPhoneSettings.generation == iPhoneGeneration.iPodTouch1Gen || iPhoneSettings.generation == iPhoneGeneration.iPodTouch2Gen)
        {
            return false;
        }
        return true;
    }

    public static bool checkCanSendSMS()
    {
        if (iPhoneSettings.generation == iPhoneGeneration.iPhone3GS || iPhoneSettings.generation == iPhoneGeneration.iPhone4 || iPhoneSettings.generation > iPhoneGeneration.iPodTouch4Gen)
        {
            return true;
        }
        return false;
    }
}
