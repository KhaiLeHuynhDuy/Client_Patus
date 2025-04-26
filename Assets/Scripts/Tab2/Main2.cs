using System;
using System.Net.NetworkInformation;
using System.Threading;
using UnityEngine;

public class Main2 : MonoBehaviour
{
	public static Main2 main;

	public static mGraphics2 g;

	public static GameMidlet2 midlet;

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
			// level = Rms2.loadRMSInt("levelScreenKN");
			// if (level == 1)
			// {
			// 	Screen.SetResolution(720, 320, fullscreen: false);
			// }
			// else
			// {
			// 	Screen.SetResolution(1024, 600, fullscreen: false);
			// }
		}
		else if (isIPhone)
		{
			Screen.fullScreen = true;
			GameCanvas2.isTouch = true;
		}
		MainMod2.GI().LoadGame();
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
				timefps = mSystem2.currentTimeMillis();
			}
			else if (mSystem2.currentTimeMillis() - timefps > 1000)
			{
				max = fps;
				fps = 0;
				timefps = mSystem2.currentTimeMillis();
			}
			fps++;
			checkInput();
			Session_ME2_.update();
			Session_ME2_2.update();
			if (!isPC && paintCount <= updateCount)
			{
				return;
			}
			if (Event.current.type.Equals(EventType.Repaint) && SceneSwitcher.GetCurrSceneName() == MainMod2.sceneName)
			{
				GameMidlet2.gameCanvas.paint(g);
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
			ScaleGUI2.initScaleGUI();
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
			if (iPhoneSettings2.generation == iPhoneGeneration2.iPodTouch4Gen)
			{
				isIpod = true;
			}
			if (iPhoneSettings2.generation == iPhoneGeneration2.iPhone4)
			{
				isIphone4 = true;
			}
			g = new mGraphics2();
			midlet = new GameMidlet2();
			TileMap2.loadBg();
			Paint2.loadbg();
			PopUp2.loadBg();
			GameScr2.loadBg();
			InfoMe2.gI().loadCharId();
			Panel2.loadBg();
			Menu2.loadBg();
			Key2.mapKeyPC();
			SoundMn2.gI().loadSound(TileMap2.mapID);
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
			int num = Rms2.loadRMSInt("lastZoomlevel");
			if (isForce || num != mGraphics2.zoomLevel)
			{
				Rms2.clearAll();
				Rms2.saveRMSString("GameVersion", GameMidlet2.VERSION);
				Rms2.saveRMSInt("lastZoomlevel", mGraphics2.zoomLevel);
				Rms2.saveRMSInt("levelScreenKN", level);
			}
		}
	}

	public static void closeKeyBoard()
	{
		if (TouchScreenKeyboard.visible)
		{
			TField2.kb.active = false;
			TField2.kb = null;
		}
	}

	private void FixedUpdate()
	{
		Rms2.update();
		count++;
		if (count >= 10)
		{
			if (up == 0)
			{
				timeup = mSystem2.currentTimeMillis();
			}
			else if (mSystem2.currentTimeMillis() - timeup > 1000)
			{
				upmax = up;
				up = 0;
				timeup = mSystem2.currentTimeMillis();
			}
			up++;
			setsizeChange();
			updateCount++;
			GameMidlet2.gameCanvas.update();
			Image2.update();
			DataInputStream2.update();
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
		if (SceneSwitcher.GetCurrSceneName() != MainMod2.sceneName)
		{
			return;
		}
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePosition = Input.mousePosition;
			GameMidlet2.gameCanvas.pointerPressed((int)(mousePosition.x / (float)mGraphics2.zoomLevel), (int)(((float)Screen.height - mousePosition.y) / (float)mGraphics2.zoomLevel) + mGraphics2.addYWhenOpenKeyBoard);
			lastMousePos.x = mousePosition.x / (float)mGraphics2.zoomLevel;
			lastMousePos.y = mousePosition.y / (float)mGraphics2.zoomLevel + (float)mGraphics2.addYWhenOpenKeyBoard;
		}
		if (Input.GetMouseButton(0))
		{
			Vector3 mousePosition2 = Input.mousePosition;
			GameMidlet2.gameCanvas.pointerDragged((int)(mousePosition2.x / (float)mGraphics2.zoomLevel), (int)(((float)Screen.height - mousePosition2.y) / (float)mGraphics2.zoomLevel) + mGraphics2.addYWhenOpenKeyBoard);
			lastMousePos.x = mousePosition2.x / (float)mGraphics2.zoomLevel;
			lastMousePos.y = mousePosition2.y / (float)mGraphics2.zoomLevel + (float)mGraphics2.addYWhenOpenKeyBoard;
		}
		if (Input.GetMouseButtonUp(0))
		{
			Vector3 mousePosition3 = Input.mousePosition;
			lastMousePos.x = mousePosition3.x / (float)mGraphics2.zoomLevel;
			lastMousePos.y = mousePosition3.y / (float)mGraphics2.zoomLevel + (float)mGraphics2.addYWhenOpenKeyBoard;
			GameMidlet2.gameCanvas.pointerReleased((int)(mousePosition3.x / (float)mGraphics2.zoomLevel), (int)(((float)Screen.height - mousePosition3.y) / (float)mGraphics2.zoomLevel) + mGraphics2.addYWhenOpenKeyBoard);
		}
		if (Input.anyKeyDown && Event.current.type == EventType.KeyDown)
		{
			int num = MyKeyMap2.map(Event.current.keyCode);
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
					MainMod2.pasteText = GUIUtility.systemCopyBuffer;
					MainMod2.pasteText = MainMod2.pasteText.Replace(Environment.NewLine, " ").Replace("\t", " ").Replace("  ", " ");
					if (MainMod2.pasteText.Length > 200)
					{
						MainMod2.pasteText = MainMod2.pasteText.Substring(0, 200);
					}
				}
				catch
				{
				}
			}
			if (num != 0)
			{
				GameMidlet2.gameCanvas.keyPressedz(num);
			}
		}
		if (Event.current.type == EventType.KeyUp)
		{
			int num2 = MyKeyMap2.map(Event.current.keyCode);
			if (num2 != 0)
			{
				GameMidlet2.gameCanvas.keyReleasedz(num2);
			}
		}
		if (isPC)
		{
			GameMidlet2.gameCanvas.scrollMouse((int)(Input.GetAxis("Mouse ScrollWheel") * 10f));
			float x = Input.mousePosition.x;
			float y = Input.mousePosition.y;
			int x2 = (int)x / mGraphics2.zoomLevel;
			int y2 = (Screen.height - (int)y) / mGraphics2.zoomLevel;
			GameMidlet2.gameCanvas.pointerMouse(x2, y2);
		}
	}

	private void OnApplicationQuit()
	{
		Debug.Log(">> QUIT <<");
		GameCanvas2.bRun = false;
		Session_ME2_.gI().close();
		Session_ME2_2.gI().close();
		if (isPC)
		{
			//Application.Quit();
		}
	}

	private void OnApplicationPause(bool paused)
	{
		isResume = false;
		if (paused)
		{
			if (GameCanvas2.isWaiting())
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
			TField2.kb.active = false;
			TField2.kb = null;
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
			//a = 0;
		}
	}

	public static bool detectCompactDevice()
	{
		if (iPhoneSettings2.generation == iPhoneGeneration2.iPhone || iPhoneSettings2.generation == iPhoneGeneration2.iPhone3G || iPhoneSettings2.generation == iPhoneGeneration2.iPodTouch1Gen || iPhoneSettings2.generation == iPhoneGeneration2.iPodTouch2Gen)
		{
			return false;
		}
		return true;
	}

	public static bool checkCanSendSMS()
	{
		if (iPhoneSettings2.generation == iPhoneGeneration2.iPhone3GS || iPhoneSettings2.generation == iPhoneGeneration2.iPhone4 || iPhoneSettings2.generation > iPhoneGeneration2.iPodTouch4Gen)
		{
			return true;
		}
		return false;
	}
}
