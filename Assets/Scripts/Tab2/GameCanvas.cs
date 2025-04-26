using System;
using System.Threading;
using UnityEngine;

public class GameCanvas2 : IActionListener2
{
    public static bool isLoadRes = false;

    public static long timeNow = 0L;

    public static bool open3Hour;

    public static bool lowGraphic = false;

    public static bool serverchat = false;

    public static bool isMoveNumberPad = true;

    public static bool isLoading;

    public static bool isTouch = false;

    public static bool isTouchControl;

    public static bool isTouchControlSmallScreen;

    public static bool isTouchControlLargeScreen;

    public static bool isConnectFail;

    public static GameCanvas2 instance;

    public static bool bRun;

    public static bool[] keyPressed = new bool[30];

    public static bool[] keyReleased = new bool[30];

    public static bool[] keyHold = new bool[30];

    public static bool isPointerDown;

    public static bool isPointerClick;

    public static bool isPointerJustRelease;

    public static bool isPointerMove;

    public static int px;

    public static int py;

    public static int pxFirst;

    public static int pyFirst;

    public static int pxLast;

    public static int pyLast;

    public static int pxMouse;

    public static int pyMouse;

    public static Position2[] arrPos = new Position2[4];

    public static int gameTick;

    public static int taskTick;

    public static bool isEff1;

    public static bool isEff2;

    public static long timeTickEff1;

    public static long timeTickEff2;

    public static int w;

    public static int h;

    public static int hw;

    public static int hh;

    public static int wd3;

    public static int hd3;

    public static int w2d3;

    public static int h2d3;

    public static int w3d4;

    public static int h3d4;

    public static int wd6;

    public static int hd6;

    public static mScreen2 currentScreen;

    public static Menu2 menu = new Menu2();

    public static Panel2 panel;

    public static Panel2 panel2;

    public static ChooseCharScr2 chooseCharScr;

    public static LoginScr2 loginScr;

    public static RegisterScreen2 registerScr;

    public static Dialog2 currentDialog;

    public static MsgDlg2 msgdlg;

    public static InputDlg2 inputDlg;

    public static MyVector2 currentPopup = new MyVector2();

    public static int requestLoseCount;

    public static MyVector2 listPoint;

    public static Paint2 paintz;

    public static bool isGetResFromServer;

    public static Image2[] imgBG;

    public static int skyColor;

    public static int curPos = 0;

    public static int[] bgW;

    public static int[] bgH;

    public static int planet = 0;

    private mGraphics2 g = new mGraphics2();

    public static MyHashTable2 danhHieu = new MyHashTable2();

    public static MyVector2 messageServer = new MyVector2(string.Empty);

    public static bool isPlaySound = true;

    private static int clearOldData;

    public static int timeOpenKeyBoard;

    public static bool isFocusPanel2;

    public static int fps = 0;

    public static int max;

    public static int up;

    public static int upmax;

    private long timefps = mSystem2.currentTimeMillis() + 1000;

    private long timeup = mSystem2.currentTimeMillis() + 1000;

    private static int dir_ = -1;

    private int tickWaitThongBao;

    public bool isPaintCarret;

    public static MyVector2 debugUpdate;

    public static MyVector2 debugPaint;

    public static MyVector2 debugSession;

    public static bool paintBG;

    public static int gsskyHeight;

    public static int gsgreenField1Y;

    public static int gsgreenField2Y;

    public static int gshouseY;

    public static int gsmountainY;

    public static int bgLayer0y;

    public static int bgLayer1y;

    public static Image2 imgCloud;

    public static Image2 imgSun;

    public static Image2 imgSun2;

    public static Image2 imgClear;

    public static Image2[] imgBorder = new Image2[3];

    public static Image2[] imgSunSpec = new Image2[3];

    public static int borderConnerW;

    public static int borderConnerH;

    public static int borderCenterW;

    public static int borderCenterH;

    public static int[] cloudX;

    public static int[] cloudY;

    public static int sunX;

    public static int sunY;

    public static int sunX2;

    public static int sunY2;

    public static int[] layerSpeed;

    public static int[] moveX;

    public static int[] moveXSpeed;

    public static bool isBoltEff;

    public static bool boltActive;

    public static int tBolt;

    public static Image2 imgBgIOS;

    public static int typeBg = -1;

    public static int transY;

    public static int[] yb = new int[5];

    public static int[] colorTop;

    public static int[] colorBotton;

    public static int yb1;

    public static int yb2;

    public static int yb3;

    public static int nBg = 0;

    public static int lastBg = -1;

    public static int[] bgRain = new int[3] { 1, 4, 11 };

    public static int[] bgRainFont = new int[1] { -1 };

    public static Image2 imgCaycot;

    public static Image2 tam;

    public static int typeBackGround = -1;

    public static int saveIDBg = -10;

    public static bool isLoadBGok;

    private static long lastTimePress = 0L;

    public static int keyAsciiPress;

    public static int pXYScrollMouse;

    private static Image2 imgSignal;

    public static MyVector2 flyTexts = new MyVector2();

    public int longTime;

    public static long timeBreakLoading;

    private static string thongBaoTest;

    public static int xThongBaoTranslate = w - 60;

    public static bool isPointerJustDown = false;

    public static bool csWait;

    public static MyRandom2 r = new MyRandom2();

    public static bool isBlackScreen;

    public static int[] bgSpeed;

    public static int cmdBarX;

    public static int cmdBarY;

    public static int cmdBarW;

    public static int cmdBarH;

    public static int cmdBarLeftW;

    public static int cmdBarRightW;

    public static int cmdBarCenterW;

    public static int hpBarX;

    public static int hpBarY;

    public static int hpBarW;

    public static int expBarW;

    public static int lvPosX;

    public static int moneyPosX;

    public static int hpBarH;

    public static int girlHPBarY;

    public int timeOut;

    public int[] dustX;

    public int[] dustY;

    public int[] dustState;

    public static int[] wsX;

    public static int[] wsY;

    public static int[] wsState;

    public static int[] wsF;

    public static Image2[] imgWS;

    public static Image2 imgShuriken;

    public static Image2[][] imgDust;

    public static bool isResume;

    public static ServerListScreen2 serverScreen;

    public static ServerScr2 serverScr;

    public bool resetToLoginScr;

    public static long TIMEOUT;

    public static int timeLoading = 15;

    public GameCanvas2()
    {
        string version = Rms2.loadRMSString("GameVersion");
        if (version == null || !version.Equals(GameMidlet2.VERSION))
        {
            Main2.main.doClearRMS(true);
        }
        else
        {
            Main2.main.doClearRMS(false);
        }
        initGame();
    }

    public static string getPlatformName()
    {
        return "Pc platform xxx";
    }

    public void initGame()
    {
        MotherCanvas2.instance.setChildCanvas(this);
        w = MotherCanvas2.instance.getWidthz();
        h = MotherCanvas2.instance.getHeightz();
        hw = w / 2;
        hh = h / 2;
        isTouch = true;
        if (w >= 240)
        {
            isTouchControl = true;
        }
        if (w < 320)
        {
            isTouchControlSmallScreen = true;
        }
        if (w >= 320)
        {
            isTouchControlLargeScreen = true;
        }
        msgdlg = new MsgDlg2();
        if (h <= 160)
        {
            Paint2.hTab = 15;
            mScreen2.cmdH = 17;
        }
        GameScr2.d = ((w <= h) ? h : w) + 20;
        instance = this;
        mFont2.init();
        mScreen2.ITEM_HEIGHT = mFont2.tahoma_8b.getHeight() + 8;
        initPaint();
        loadDust();
        loadWaterSplash();
        panel = new Panel2();
        imgShuriken = loadImage("/mainImage/myTexture2df.png");
        int num = Rms2.loadRMSInt("clienttype");
        if (num != -1)
        {
            if (num > 7)
            {
                Rms2.saveRMSInt("clienttype", mSystem2.clientType);
            }
            else
            {
                mSystem2.clientType = num;
            }
        }
        imgClear = loadImage("/mainImage/myTexture2der.png");
        debugUpdate = new MyVector2();
        debugPaint = new MyVector2();
        debugSession = new MyVector2();
        for (int i = 0; i < 3; i++)
        {
            imgBorder[i] = loadImage("/mainImage/myTexture2dbd" + i + ".png");
        }
        borderConnerW = mGraphics2.getImageWidth(imgBorder[0]);
        borderConnerH = mGraphics2.getImageHeight(imgBorder[0]);
        borderCenterW = mGraphics2.getImageWidth(imgBorder[1]);
        borderCenterH = mGraphics2.getImageHeight(imgBorder[1]);
        Panel2.graphics = 1;
        lowGraphic = true;
        GameScr2.isPaintChatVip = Rms2.loadRMSInt("serverchat") != 1;
        Char2.isPaintAura = Rms2.loadRMSInt("isPaintAura") == 1;
        Char2.isPaintAura2 = Rms2.loadRMSInt("isPaintAura2") == 1;
        Res2.init();
        SmallImage2.loadBigImage();
        Panel2.WIDTH_PANEL = 176;
        if (Panel2.WIDTH_PANEL > w)
        {
            Panel2.WIDTH_PANEL = w;
        }
        InfoMe2.gI().loadCharId();
        Command2.btn0left = loadImage("/mainImage/btn0left.png");
        Command2.btn0mid = loadImage("/mainImage/btn0mid.png");
        Command2.btn0right = loadImage("/mainImage/btn0right.png");
        Command2.btn1left = loadImage("/mainImage/btn1left.png");
        Command2.btn1mid = loadImage("/mainImage/btn1mid.png");
        Command2.btn1right = loadImage("/mainImage/btn1right.png");
        serverScreen = new ServerListScreen2();
        ServerListScreen2.createDeleteRMS();
        serverScr = new ServerScr2();
        chooseCharScr = new ChooseCharScr2();
    }

    public static GameCanvas2 gI()
    {
        return instance;
    }

    public void initPaint()
    {
        paintz = new Paint2();
    }

    public static void closeKeyBoard()
    {
        mGraphics2.addYWhenOpenKeyBoard = 0;
        timeOpenKeyBoard = 0;
        Main2.closeKeyBoard();
    }

    public void update()
    {
        if (mSystem2.currentTimeMillis() > timefps)
        {
            timefps += 1000L;
            max = fps;
            fps = 0;
        }
        fps++;
        if (messageServer.size() > 0 && thongBaoTest == null)
        {
            startserverThongBao((string)messageServer.elementAt(0));
            messageServer.removeElementAt(0);
        }
        if (gameTick % 5 == 0)
        {
            timeNow = mSystem2.currentTimeMillis();
        }
        Res2.updateOnScreenDebug();
        try
        {
            if (TouchScreenKeyboard.visible)
            {
                timeOpenKeyBoard++;
                if (timeOpenKeyBoard > ((!Main2.isWindowsPhone) ? 10 : 5))
                {
                    mGraphics2.addYWhenOpenKeyBoard = 94;
                }
            }
            else
            {
                mGraphics2.addYWhenOpenKeyBoard = 0;
                timeOpenKeyBoard = 0;
            }
            debugUpdate.removeAllElements();
            long num = mSystem2.currentTimeMillis();
            if (num - timeTickEff1 >= 780 && !isEff1)
            {
                timeTickEff1 = num;
                isEff1 = true;
            }
            else
            {
                isEff1 = false;
            }
            if (num - timeTickEff2 >= 7800 && !isEff2)
            {
                timeTickEff2 = num;
                isEff2 = true;
            }
            else
            {
                isEff2 = false;
            }
            if (taskTick > 0)
            {
                taskTick--;
            }
            gameTick++;
            if (gameTick > 10000)
            {
                if (mSystem2.currentTimeMillis() - lastTimePress > 20000 && currentScreen == loginScr)
                {
                    startOKDlg(mResources2.maychutathoacmatsong);
                }
                gameTick = 0;
            }
            if (currentScreen != null)
            {
                if (ChatPopup2.serverChatPopUp != null)
                {
                    ChatPopup2.serverChatPopUp.update();
                    ChatPopup2.serverChatPopUp.updateKey();
                }
                else if (ChatPopup2.currChatPopup != null)
                {
                    ChatPopup2.currChatPopup.update();
                    ChatPopup2.currChatPopup.updateKey();
                }
                else if (currentDialog != null)
                {
                    currentDialog.update();
                }
                else if (menu.showMenu)
                {
                    menu.updateMenu();
                    menu.updateMenuKey();
                }
                else if (panel.isShow)
                {
                    panel.update();
                    if (isPointer(panel.X, panel.Y, panel.W, panel.H))
                    {
                        isFocusPanel2 = false;
                    }
                    if (panel2 != null && panel2.isShow)
                    {
                        panel2.update();
                        if (isPointer(panel2.X, panel2.Y, panel2.W, panel2.H))
                        {
                            isFocusPanel2 = true;
                        }
                    }
                    if (panel2 != null)
                    {
                        if (isFocusPanel2)
                        {
                            panel2.updateKey();
                        }
                        else
                        {
                            panel.updateKey();
                        }
                    }
                    else
                    {
                        panel.updateKey();
                    }
                    if (panel.chatTField != null && panel.chatTField.isShow)
                    {
                        panel.chatTFUpdateKey();
                    }
                    else if (panel2 != null && panel2.chatTField != null && panel2.chatTField.isShow)
                    {
                        panel2.chatTFUpdateKey();
                    }
                    else if ((isPointer(panel.X, panel.Y, panel.W, panel.H) && panel2 != null) || panel2 == null)
                    {
                        panel.updateKey();
                    }
                    else if (panel2 != null && panel2.isShow && isPointer(panel2.X, panel2.Y, panel2.W, panel2.H))
                    {
                        panel2.updateKey();
                    }
                    if (isPointer(panel.X + panel.W, panel.Y, w - panel.W * 2, panel.H)
                        && isPointerJustRelease
                        && panel.isDoneCombine)
                    {
                        if (isPointer((w - MainMod2.logoW) / 2, 5, MainMod2.logoW, MainMod2.logoH))
                        {
                            MainMod2.GI().OpenMenu();
                            SoundMn2.gI().buttonClick();
                            clearAllPointerEvent();
                        }
                        else
                        {
                            panel.hide();
                        }
                    }
                }
                if (!isLoading)
                {
                    currentScreen.update();
                }
                if (!panel.isShow && ChatPopup2.serverChatPopUp == null)
                {
                    currentScreen.updateKey();
                }
                Hint2.update();
                SoundMn2.gI().update();
            }
            Timer2.update();
            InfoDlg2.update();
            if (resetToLoginScr)
            {
                resetToLoginScr = false;
                doResetToLoginScr(serverScreen);
            }
            if (Controller2_.isConnectOK)
            {
                if (Controller2_.isMain)
                {
                    GameMidlet2.IP = ServerListScreen2.address[ServerListScreen2.ipSelect];
                    GameMidlet2.PORT = ServerListScreen2.port[ServerListScreen2.ipSelect];
                    ServerListScreen2.testConnect = 2;
                    Rms2.saveRMSInt("svselect", ServerListScreen2.ipSelect);
                    Service2.gI().setClientType();
                    Service2.gI().androidPack();
                }
                else
                {
                    Service2.gI().setClientType2();
                    Service2.gI().androidPack2();
                }
                Controller2_.isConnectOK = false;
            }
            if (Controller2_.isDisconnected)
            {
                if (!Controller2_.isMain)
                {
                    if (currentScreen == serverScreen && !Service2.reciveFromMainSession)
                    {
                        serverScreen.cancel();
                    }
                    if (currentScreen == loginScr && !Service2.reciveFromMainSession)
                    {
                        onDisconnected();
                    }
                }
                else
                {
                    onDisconnected();
                }
                Controller2_.isDisconnected = false;
            }
            if (Controller2_.isConnectionFail)
            {
                Debug.Log("connect fail");
                if (!Controller2_.isMain)
                {
                    if (currentScreen == serverScreen && ServerListScreen2.isGetData && !Service2.reciveFromMainSession)
                    {
                        ServerListScreen2.testConnect = 0;
                        serverScreen.cancel();
                    }
                    if (currentScreen == loginScr && !Service2.reciveFromMainSession)
                    {
                        onConnectionFail();
                    }
                }
                else if (Session_ME2_.gI().isCompareIPConnect())
                {
                    onConnectionFail();
                }
                Controller2_.isConnectionFail = false;
            }
            if (Main2.isResume)
            {
                Main2.isResume = false;
                if (currentDialog != null && currentDialog.left != null && currentDialog.left.actionListener != null)
                {
                    currentDialog.left.performAction();
                }
            }
            if (currentScreen == null || !(currentScreen is GameScr2))
            {
                return;
            }
            xThongBaoTranslate += dir_ * 2;
            if (xThongBaoTranslate - Panel2.imgNew.getWidth() <= 60)
            {
                dir_ = 0;
                tickWaitThongBao++;
                if (tickWaitThongBao > 150)
                {
                    tickWaitThongBao = 0;
                    thongBaoTest = null;
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void onDisconnected()
    {
        if (Controller2_.isConnectionFail)
        {
            Controller2_.isConnectionFail = false;
        }
        isResume = true;
        Session_ME2_.gI().clearSendingMessage();
        Session_ME2_2.gI().clearSendingMessage();
        Session_ME2_.gI().close();
        Session_ME2_2.gI().close();
        if (Controller2_.isLoadingData)
        {
            instance.resetToLoginScrz();
            startOK(mResources2.pls_restart_game_error, 8885, null);
            Controller2_.isDisconnected = false;
            return;
        }
        if (currentScreen != serverScreen)
        {
            startOKDlg(mResources2.maychutathoacmatsong);
        }
        else
        {
            endDlg();
        }
        Char2.isLoadingMap = false;
        if (Controller2_.isMain)
        {
            ServerListScreen2.testConnect = 0;
        }
        instance.resetToLoginScrz();
        startOKDlg(mResources2.maychutathoacmatsong);
        mSystem2.endKey();
    }

    public void onConnectionFail()
    {
        if (currentScreen.Equals(SplashScr2.instance))
        {
            if (ServerListScreen2.hasConnected != null)
            {
                ServerListScreen2.GetServerList(ServerListScreen2.linkDefault);
                if (!ServerListScreen2.hasConnected[0])
                {
                    ServerListScreen2.hasConnected[0] = true;
                    ServerListScreen2.ipSelect = 0;
                    GameMidlet2.IP = ServerListScreen2.address[ServerListScreen2.ipSelect];
                    Rms2.saveRMSInt("svselect", ServerListScreen2.ipSelect);
                    connect();
                }
                else if (!ServerListScreen2.hasConnected[2])
                {
                    ServerListScreen2.hasConnected[2] = true;
                    ServerListScreen2.ipSelect = 2;
                    GameMidlet2.IP = ServerListScreen2.address[ServerListScreen2.ipSelect];
                    Rms2.saveRMSInt("svselect", ServerListScreen2.ipSelect);
                    connect();
                }
                else
                {
                    startOK(mResources2.pls_restart_game_error, 8885, null);
                }
            }
            else
            {
                //startOK(mResources.pls_restart_game_error, 8885, null);
            }
            return;
        }
        Session_ME2_.gI().clearSendingMessage();
        Session_ME2_2.gI().clearSendingMessage();
        ServerListScreen2.isWait = false;
        if (Controller2_.isLoadingData)
        {
            startOK(mResources2.pls_restart_game_error, 8885, null);
            Controller2_.isConnectionFail = false;
            return;
        }
        isResume = true;
        LoginScr2.isContinueToLogin = false;
        if (loginScr != null)
        {
            instance.resetToLoginScrz();
        }
        else
        {
            loginScr = new LoginScr2();
        }
        LoginScr2.serverName = ServerListScreen2.nameServer[ServerListScreen2.ipSelect];
        if (currentScreen != serverScreen)
        {
            ServerListScreen2.countDieConnect = 0;
        }
        else
        {
            endDlg();
            ServerListScreen2.loadScreen = true;
            serverScreen.switchToMe();
        }
        Char2.isLoadingMap = false;
        if (Controller2_.isMain)
        {
            ServerListScreen2.testConnect = 0;
        }
        mSystem2.endKey();
    }

    public static bool isWaiting()
    {
        if (InfoDlg2.isShow || (msgdlg != null && msgdlg.info.Equals(mResources2.PLEASEWAIT)) || Char2.isLoadingMap || LoginScr2.isContinueToLogin)
        {
            return true;
        }
        return false;
    }

    public static void connect()
    {
        if (!Session_ME2_.gI().isConnected())
        {
            Session_ME2_.gI().connect(GameMidlet2.IP, GameMidlet2.PORT);
        }
    }

    public static void connect2()
    {
        if (!Session_ME2_2.gI().isConnected())
        {
            Res2.outz("IP2= " + GameMidlet2.IP2 + " PORT 2= " + GameMidlet2.PORT2);
            Session_ME2_2.gI().connect(GameMidlet2.IP2, GameMidlet2.PORT2);
        }
    }

    public static void resetTrans(mGraphics2 g)
    {
        g.translate(-g.getTranslateX(), -g.getTranslateY());
        g.setClip(0, 0, w, h);
    }

    public static void resetTransGameScr(mGraphics2 g)
    {
        g.translate(-g.getTranslateX(), -g.getTranslateY());
        g.translate(0, 0);
        g.setClip(0, 0, w, h);
        g.translate(-GameScr2.cmx, -GameScr2.cmy);
    }

    public void initGameCanvas()
    {
        debug("SP2i1", 0);
        w = MotherCanvas2.instance.getWidthz();
        h = MotherCanvas2.instance.getHeightz();
        debug("SP2i2", 0);
        hw = w / 2;
        hh = h / 2;
        wd3 = w / 3;
        hd3 = h / 3;
        w2d3 = 2 * w / 3;
        h2d3 = 2 * h / 3;
        w3d4 = 3 * w / 4;
        h3d4 = 3 * h / 4;
        wd6 = w / 6;
        hd6 = h / 6;
        debug("SP2i3", 0);
        mScreen2.initPos();
        debug("SP2i4", 0);
        debug("SP2i5", 0);
        inputDlg = new InputDlg2();
        debug("SP2i6", 0);
        listPoint = new MyVector2();
        debug("SP2i7", 0);
    }

    public void start()
    {
    }

    public int getWidth()
    {
        return (int)ScaleGUI2.WIDTH;
    }

    public int getHeight()
    {
        return (int)ScaleGUI2.HEIGHT;
    }

    public static void debug(string s, int type)
    {
    }

    public void doResetToLoginScr(mScreen2 screen)
    {
        try
        {
            SoundMn2.gI().stopAll();
            LoginScr2.isContinueToLogin = false;
            TileMap2.lastType = (TileMap2.bgType = 0);
            Char2.clearMyChar();
            GameScr2.clearGameScr();
            GameScr2.resetAllvector();
            InfoDlg2.hide();
            GameScr2.info1.hide();
            GameScr2.info2.hide();
            GameScr2.info2.cmdChat = null;
            Hint2.isShow = false;
            ChatPopup2.currChatPopup = null;
            Controller2_.isStopReadMessage = false;
            GameScr2.loadCamera(fullmScreen: true, -1, -1);
            GameScr2.cmx = 100;
            panel.currentTabIndex = 0;
            panel.selected = isTouch ? (-1) : 0;
            panel.init();
            panel2 = null;
            GameScr2.isPaint = true;
            ClanMessage2.vMessage.removeAllElements();
            GameScr2.textTime.removeAllElements();
            GameScr2.vClan.removeAllElements();
            GameScr2.vFriend.removeAllElements();
            GameScr2.vEnemies.removeAllElements();
            TileMap2.vCurrItem.removeAllElements();
            BackgroudEffect2.vBgEffect.removeAllElements();
            EffecMn2.vEff.removeAllElements();
            Effect2_.newEff.removeAllElements();
            menu.showMenu = false;
            panel.vItemCombine.removeAllElements();
            panel.isShow = false;
            if (panel.tabIcon != null)
            {
                panel.tabIcon.isShow = false;
            }
            // if (mGraphics2.zoomLevel == 1)
            // {
            //     SmallImage2.clearHastable();
            // }
            Session_ME2_.gI().close();
            Session_ME2_2.gI().close();
            screen.switchToMe();
        }
        catch (Exception ex)
        {
            Cout2.println("Loi tai doResetToLoginScr " + ex.ToString());
        }
        ServerListScreen2.isAutoConect = true;
        ServerListScreen2.countDieConnect = 0;
        ServerListScreen2.testConnect = -1;
        ServerListScreen2.loadScreen = true;
    }

    public static void showErrorForm(int type, string moreInfo)
    {
    }

    public static void paintCloud(mGraphics2 g)
    {
    }

    public static void updateBG()
    {
    }

    public static void fillRect(mGraphics2 g, int color, int x, int y, int w, int h, int detalY)
    {
        g.setColor(color);
        int cmy = GameScr2.cmy;
        if (cmy > GameCanvas2.h)
        {
            cmy = GameCanvas2.h;
        }
        g.fillRect(x, y - ((detalY != 0) ? (cmy >> detalY) : 0), w, h + ((detalY != 0) ? (cmy >> detalY) : 0));
    }

    public static void paintBackgroundtLayer(mGraphics2 g, int layer, int deltaY, int color1, int color2)
    {
        try
        {
            int num = layer - 1;
            if (num == imgBG.Length - 1 && (GameScr2.gI().isRongThanXuatHien || GameScr2.gI().isFireWorks))
            {
                g.setColor(GameScr2.gI().mautroi);
                g.fillRect(0, 0, w, h);
                if (typeBg == 2 || typeBg == 4 || typeBg == 7)
                {
                    drawSun1(g);
                    drawSun2(g);
                }
                if (GameScr2.gI().isFireWorks && !lowGraphic)
                {
                    FireWorkEff2.paint(g);
                }
            }
            else
            {
                if (imgBG == null || imgBG[num] == null)
                {
                    return;
                }
                if (moveX[num] != 0)
                {
                    moveX[num] += moveXSpeed[num];
                }
                int cmy = GameScr2.cmy;
                if (cmy > h)
                {
                    cmy = h;
                }
                if (layerSpeed[num] != 0)
                {
                    for (int i = -((GameScr2.cmx + moveX[num] >> layerSpeed[num]) % bgW[num]); i < GameScr2.gW; i += bgW[num])
                    {
                        g.drawImage(imgBG[num], i, yb[num] - ((deltaY > 0) ? (cmy >> deltaY) : 0), 0);
                    }
                }
                else
                {
                    for (int j = 0; j < GameScr2.gW; j += bgW[num])
                    {
                        g.drawImage(imgBG[num], j, yb[num] - ((deltaY > 0) ? (cmy >> deltaY) : 0), 0);
                    }
                }
                if (color1 != -1)
                {
                    if (num == nBg - 1)
                    {
                        fillRect(g, color1, 0, -(cmy >> deltaY), GameScr2.gW, yb[num], deltaY);
                    }
                    else
                    {
                        fillRect(g, color1, 0, yb[num - 1] + bgH[num - 1], GameScr2.gW, yb[num] - (yb[num - 1] + bgH[num - 1]), deltaY);
                    }
                }
                if (color2 != -1)
                {
                    if (num == 0)
                    {
                        fillRect(g, color2, 0, yb[num] + bgH[num], GameScr2.gW, GameScr2.gH - (yb[num] + bgH[num]), deltaY);
                    }
                    else
                    {
                        fillRect(g, color2, 0, yb[num] + bgH[num], GameScr2.gW, yb[num - 1] - (yb[num] + bgH[num]) + 80, deltaY);
                    }
                }
                if (currentScreen == GameScr2.instance)
                {
                    if (layer == 1 && typeBg == 11)
                    {
                        g.drawImage(imgSun2, -(GameScr2.cmx >> layerSpeed[0]) + 400, yb[0] + 30 - (cmy >> 2), StaticObj2.BOTTOM_HCENTER);
                    }
                    if (layer == 1 && typeBg == 13)
                    {
                        g.drawImage(imgBG[1], -(GameScr2.cmx >> layerSpeed[0]) + 200, yb[0] - (cmy >> 3) + 30, 0);
                        g.drawRegion(imgBG[1], 0, 0, bgW[1], bgH[1], 2, -(GameScr2.cmx >> layerSpeed[0]) + 200 + bgW[1], yb[0] - (cmy >> 3) + 30, 0);
                    }
                    if (layer == 3 && TileMap2.mapID == 1)
                    {
                        for (int k = 0; k < TileMap2.pxh / mGraphics2.getImageHeight(imgCaycot); k++)
                        {
                            g.drawImage(imgCaycot, -(GameScr2.cmx >> layerSpeed[2]) + 300, k * mGraphics2.getImageHeight(imgCaycot) - (cmy >> 3), 0);
                        }
                    }
                }
                int x = -(GameScr2.cmx + moveX[num] >> layerSpeed[num]);
                EffecMn2.paintBackGroundUnderLayer(g, x, yb[num] + bgH[num] - (cmy >> deltaY), num);
            }
        }
        catch (Exception ex)
        {
            Cout2.LogError("Loi ham paint bground: " + ex.ToString());
        }
    }

    public static void drawSun1(mGraphics2 g)
    {
        if (imgSun != null)
        {
            g.drawImage(imgSun, sunX, sunY, 0);
        }
        if (!isBoltEff)
        {
            return;
        }
        if (gameTick % 200 == 0)
        {
            boltActive = true;
        }
        if (boltActive)
        {
            tBolt++;
            if (tBolt == 10)
            {
                tBolt = 0;
                boltActive = false;
            }
            if (tBolt % 2 == 0)
            {
                g.setColor(16777215);
                g.fillRect(0, 0, w, h);
            }
        }
    }

    public static void drawSun2(mGraphics2 g)
    {
        if (imgSun2 != null)
        {
            g.drawImage(imgSun2, sunX2, sunY2, 0);
        }
    }

    public static bool isHDVersion()
    {
        if (mGraphics2.zoomLevel > 1)
        {
            return true;
        }
        return false;
    }

    public static void paint_ios_bg(mGraphics2 g)
    {
        if (mSystem2.clientType != 5)
        {
            return;
        }
        if (imgBgIOS != null)
        {
            g.setColor(0);
            g.fillRect(0, 0, w, h);
            for (int i = 0; i < 3; i++)
            {
                g.drawImage(imgBgIOS, imgBgIOS.getWidth() * i, h / 2, mGraphics2.VCENTER | mGraphics2.HCENTER);
            }
        }
        else
        {
            int num = ((TileMap2.bgID % 2 != 0) ? 1 : 2);
            imgBgIOS = mSystem2.loadImage("/bg/bg_ios_" + num + ".png");
        }
    }

    public static void paintBGGameScr(mGraphics2 g)
    {
        if (!isLoadBGok)
        {
            g.setColor(0);
            g.fillRect(0, 0, w, h);
        }
        if (Char2.isLoadingMap)
        {
            return;
        }
        int gW = GameScr2.gW;
        int gH = GameScr2.gH;
        g.translate(-g.getTranslateX(), -g.getTranslateY());
        try
        {
            if (paintBG)
            {
                if (currentScreen == GameScr2.gI())
                {
                    if (TileMap2.mapID == 137 || TileMap2.mapID == 115 || TileMap2.mapID == 117 || TileMap2.mapID == 118 || TileMap2.mapID == 120 || TileMap2.isMapDouble)
                    {
                        g.setColor(0);
                        g.fillRect(0, 0, w, h);
                        return;
                    }
                    if (TileMap2.mapID == 138)
                    {
                        g.setColor(6776679);
                        g.fillRect(0, 0, w, h);
                        return;
                    }
                }
                if (typeBg == 0)
                {
                    paintBackgroundtLayer(g, 4, 6, colorTop[3], colorBotton[3]);
                    paintBackgroundtLayer(g, 3, 4, -1, colorBotton[2]);
                    paintBackgroundtLayer(g, 2, 3, -1, colorBotton[1]);
                    paintBackgroundtLayer(g, 1, 2, -1, colorBotton[0]);
                }
                else if (typeBg == 1)
                {
                    paintBackgroundtLayer(g, 4, 6, -1, -1);
                    paintBackgroundtLayer(g, 3, 3, -1, -1);
                    fillRect(g, colorTop[2], 0, -(GameScr2.cmy >> 5), gW, yb[2], 5);
                    fillRect(g, colorBotton[2], 0, yb[2] + bgH[2] - (GameScr2.cmy >> 3), gW, 70, 3);
                    paintBackgroundtLayer(g, 2, 2, -1, -1);
                    paintBackgroundtLayer(g, 1, 1, -1, colorBotton[0]);
                }
                else if (typeBg == 2)
                {
                    paintBackgroundtLayer(g, 5, 10, colorTop[4], colorBotton[4]);
                    paintBackgroundtLayer(g, 4, 8, -1, colorTop[2]);
                    paintBackgroundtLayer(g, 3, 5, -1, colorBotton[2]);
                    paintBackgroundtLayer(g, 2, 2, -1, colorBotton[1]);
                    paintBackgroundtLayer(g, 1, 1, -1, colorBotton[0]);
                    paintCloud(g);
                }
                else if (typeBg == 3)
                {
                    int num = GameScr2.cmy - (325 - GameScr2.gH23);
                    g.translate(0, -num);
                    fillRect(g, (!GameScr2.gI().isRongThanXuatHien && !GameScr2.gI().isFireWorks) ? colorTop[2] : GameScr2.gI().mautroi, 0, num - (GameScr2.cmy >> 3), gW, yb[2] - num + (GameScr2.cmy >> 3) + 100, 2);
                    paintBackgroundtLayer(g, 3, 2, -1, colorBotton[2]);
                    paintBackgroundtLayer(g, 2, 0, -1, -1);
                    paintBackgroundtLayer(g, 1, 0, -1, colorBotton[0]);
                    g.translate(0, -g.getTranslateY());
                }
                else if (typeBg == 4)
                {
                    paintBackgroundtLayer(g, 4, 7, colorTop[3], -1);
                    paintBackgroundtLayer(g, 3, 3, -1, (!isHDVersion()) ? colorTop[1] : colorBotton[2]);
                    paintBackgroundtLayer(g, 2, 2, colorTop[1], colorBotton[1]);
                    paintBackgroundtLayer(g, 1, 1, -1, colorBotton[0]);
                }
                else if (typeBg == 5)
                {
                    paintBackgroundtLayer(g, 4, 15, colorTop[3], -1);
                    drawSun1(g);
                    g.translate(100, 10);
                    drawSun1(g);
                    g.translate(-100, -10);
                    drawSun2(g);
                    paintBackgroundtLayer(g, 3, 10, -1, -1);
                    paintBackgroundtLayer(g, 2, 6, -1, -1);
                    paintBackgroundtLayer(g, 1, 4, -1, -1);
                    g.translate(0, 27);
                    paintBackgroundtLayer(g, 1, 2, -1, -1);
                    g.translate(0, 20);
                    paintBackgroundtLayer(g, 1, 2, -1, colorBotton[0]);
                    g.translate(-g.getTranslateX(), -g.getTranslateY());
                }
                else if (typeBg == 6)
                {
                    paintBackgroundtLayer(g, 5, 10, colorTop[4], colorBotton[4]);
                    drawSun1(g);
                    drawSun2(g);
                    g.translate(60, 40);
                    drawSun2(g);
                    g.translate(-60, -40);
                    paintBackgroundtLayer(g, 4, 7, -1, colorBotton[3]);
                    BackgroudEffect2.paintFarAll(g);
                    paintBackgroundtLayer(g, 3, 4, -1, -1);
                    paintBackgroundtLayer(g, 2, 3, -1, colorBotton[1]);
                    paintBackgroundtLayer(g, 1, 2, -1, colorBotton[0]);
                }
                else if (typeBg == 7)
                {
                    paintBackgroundtLayer(g, 4, 6, colorTop[3], colorBotton[3]);
                    paintBackgroundtLayer(g, 3, 5, -1, -1);
                    paintBackgroundtLayer(g, 2, 4, -1, -1);
                    paintBackgroundtLayer(g, 1, 3, -1, colorBotton[0]);
                }
                else if (typeBg == 8)
                {
                    paintBackgroundtLayer(g, 4, 8, colorTop[3], colorBotton[3]);
                    drawSun1(g);
                    drawSun2(g);
                    paintBackgroundtLayer(g, 3, 4, -1, colorBotton[2]);
                    paintBackgroundtLayer(g, 2, 2, -1, colorBotton[1]);
                    if (((TileMap2.mapID < 92 || TileMap2.mapID > 96) && TileMap2.mapID != 51 && TileMap2.mapID != 52) || currentScreen == loginScr)
                    {
                        paintBackgroundtLayer(g, 1, 1, -1, colorBotton[0]);
                    }
                }
                else if (typeBg == 9)
                {
                    paintBackgroundtLayer(g, 4, 8, colorTop[3], colorBotton[3]);
                    drawSun1(g);
                    drawSun2(g);
                    g.translate(-80, 20);
                    drawSun2(g);
                    g.translate(80, -20);
                    BackgroudEffect2.paintFarAll(g);
                    paintBackgroundtLayer(g, 3, 5, -1, -1);
                    paintBackgroundtLayer(g, 2, 3, -1, -1);
                    paintBackgroundtLayer(g, 1, 2, -1, colorBotton[0]);
                }
                else if (typeBg == 10)
                {
                    int num2 = GameScr2.cmy - (380 - GameScr2.gH23);
                    g.translate(0, -num2);
                    fillRect(g, (!GameScr2.gI().isRongThanXuatHien) ? colorTop[1] : GameScr2.gI().mautroi, 0, num2 - (GameScr2.cmy >> 2), gW, yb[1] - num2 + (GameScr2.cmy >> 2) + 100, 2);
                    paintBackgroundtLayer(g, 2, 2, -1, colorBotton[1]);
                    drawSun1(g);
                    drawSun2(g);
                    paintBackgroundtLayer(g, 1, 0, -1, -1);
                    g.translate(0, -g.getTranslateY());
                }
                else if (typeBg == 11)
                {
                    paintBackgroundtLayer(g, 3, 6, colorTop[2], colorBotton[2]);
                    drawSun1(g);
                    paintBackgroundtLayer(g, 2, 3, -1, colorBotton[1]);
                    paintBackgroundtLayer(g, 1, 2, -1, colorBotton[0]);
                }
                else if (typeBg == 12)
                {
                    g.setColor(9161471);
                    g.fillRect(0, 0, w, h);
                    paintBackgroundtLayer(g, 3, 4, -1, 14417919);
                    paintBackgroundtLayer(g, 2, 3, -1, 14417919);
                    paintBackgroundtLayer(g, 1, 2, -1, 14417919);
                    paintCloud(g);
                }
                else if (typeBg == 13)
                {
                    g.setColor(15268088);
                    g.fillRect(0, 0, w, h);
                    paintBackgroundtLayer(g, 1, 5, -1, 15268088);
                }
                else if (typeBg == 15)
                {
                    g.setColor(2631752);
                    g.fillRect(0, 0, w, h);
                    paintBackgroundtLayer(g, 2, 3, -1, colorBotton[1]);
                    paintBackgroundtLayer(g, 1, 2, -1, colorBotton[0]);
                }
                else if (typeBg == 16)
                {
                    paintBackgroundtLayer(g, 4, 6, colorTop[3], colorBotton[3]);
                    for (int i = 0; i < imgSunSpec.Length; i++)
                    {
                        g.drawImage(imgSunSpec[i], cloudX[i], cloudY[i], 33);
                    }
                    paintBackgroundtLayer(g, 3, 4, -1, colorBotton[2]);
                    paintBackgroundtLayer(g, 2, 3, -1, colorBotton[1]);
                    paintBackgroundtLayer(g, 1, 2, -1, colorBotton[0]);
                }
                else if (typeBg == 19)
                {
                    paintBackgroundtLayer(g, 5, 10, colorTop[4], colorBotton[4]);
                    paintBackgroundtLayer(g, 4, 8, -1, colorTop[2]);
                    paintBackgroundtLayer(g, 3, 5, -1, colorBotton[2]);
                    paintBackgroundtLayer(g, 2, 2, -1, colorBotton[1]);
                    paintBackgroundtLayer(g, 1, 1, -1, colorBotton[0]);
                    paintCloud(g);
                }
                else
                {
                    fillRect(g, colorBotton[3], 0, yb[3] + bgH[3], GameScr2.gW, yb[2] + bgH[2], 6);
                    paintBackgroundtLayer(g, 4, 6, colorTop[3], colorBotton[3]);
                    drawSun1(g);
                    paintBackgroundtLayer(g, 3, 4, -1, colorBotton[2]);
                    paintBackgroundtLayer(g, 2, 3, -1, colorBotton[1]);
                    paintBackgroundtLayer(g, 1, 2, -1, colorBotton[0]);
                }
                return;
            }
            g.setColor(2315859);
            g.fillRect(0, 0, w, h);
            if (tam != null)
            {
                for (int j = -((GameScr2.cmx >> 2) % mGraphics2.getImageWidth(tam)); j < GameScr2.gW; j += mGraphics2.getImageWidth(tam))
                {
                    g.drawImage(tam, j, (GameScr2.cmy >> 3) + h / 2 - 50, 0);
                }
            }
            g.setColor(5084791);
            g.fillRect(0, (GameScr2.cmy >> 3) + h / 2 - 50 + mGraphics2.getImageHeight(tam), gW, h);
        }
        catch (Exception)
        {
            g.setColor(0);
            g.fillRect(0, 0, w, h);
            g.drawImageScale(MainMod2.imgBg, 0, 0, w, h, 0);
        }
    }

    public static void resetBg()
    {
    }

    public static void getYBackground(int typeBg)
    {
        try
        {
            int gH = GameScr2.gH23;
            switch (typeBg)
            {
                case 0:
                    yb[0] = gH - bgH[0] + 70;
                    yb[1] = yb[0] - bgH[1] + 20;
                    yb[2] = yb[1] - bgH[2] + 30;
                    yb[3] = yb[2] - bgH[3] + 50;
                    break;
                case 1:
                    yb[0] = gH - bgH[0] + 120;
                    yb[1] = yb[0] - bgH[1] + 40;
                    yb[2] = yb[1] - 90;
                    yb[3] = yb[2] - 25;
                    break;
                case 2:
                    yb[0] = gH - bgH[0] + 150;
                    yb[1] = yb[0] - bgH[1] - 60;
                    yb[2] = yb[1] - bgH[2] - 40;
                    yb[3] = yb[2] - bgH[3] - 10;
                    yb[4] = yb[3] - bgH[4];
                    break;
                case 3:
                    yb[0] = gH - bgH[0] + 10;
                    yb[1] = yb[0] + 80;
                    yb[2] = yb[1] - bgH[2] - 10;
                    break;
                case 4:
                    yb[0] = gH - bgH[0] + 130;
                    yb[1] = yb[0] - bgH[1];
                    yb[2] = yb[1] - bgH[2] - 20;
                    yb[3] = yb[1] - bgH[2] - 80;
                    break;
                case 5:
                    yb[0] = gH - bgH[0] + 40;
                    yb[1] = yb[0] - bgH[1] + 10;
                    yb[2] = yb[1] - bgH[2] + 15;
                    yb[3] = yb[2] - bgH[3] + 50;
                    break;
                case 6:
                    yb[0] = gH - bgH[0] + 100;
                    yb[1] = yb[0] - bgH[1] - 30;
                    yb[2] = yb[1] - bgH[2] + 10;
                    yb[3] = yb[2] - bgH[3] + 15;
                    yb[4] = yb[3] - bgH[4] + 15;
                    break;
                case 7:
                    yb[0] = gH - bgH[0] + 20;
                    yb[1] = yb[0] - bgH[1] + 15;
                    yb[2] = yb[1] - bgH[2] + 20;
                    yb[3] = yb[1] - bgH[2] - 10;
                    break;
                case 8:
                    yb[0] = gH - 103 + 150;
                    if (TileMap2.mapID == 103)
                    {
                        yb[0] -= 100;
                    }
                    yb[1] = yb[0] - bgH[1] - 10;
                    yb[2] = yb[1] - bgH[2] + 40;
                    yb[3] = yb[2] - bgH[3] + 10;
                    break;
                case 9:
                    yb[0] = gH - bgH[0] + 100;
                    yb[1] = yb[0] - bgH[1] + 22;
                    yb[2] = yb[1] - bgH[2] + 50;
                    yb[3] = yb[2] - bgH[3];
                    break;
                case 10:
                    yb[0] = gH - bgH[0] - 45;
                    yb[1] = yb[0] - bgH[1] - 10;
                    break;
                case 11:
                    yb[0] = gH - bgH[0] + 60;
                    yb[1] = yb[0] - bgH[1] + 5;
                    yb[2] = yb[1] - bgH[2] - 15;
                    break;
                case 12:
                    yb[0] = gH + 40;
                    yb[1] = yb[0] - 40;
                    yb[2] = yb[1] - 40;
                    break;
                case 13:
                    yb[0] = gH - 80;
                    yb[1] = yb[0];
                    break;
                case 15:
                    yb[0] = gH - 20;
                    yb[1] = yb[0] - 80;
                    break;
                case 16:
                    yb[0] = gH - bgH[0] + 75;
                    yb[1] = yb[0] - bgH[1] + 50;
                    yb[2] = yb[1] - bgH[2] + 50;
                    yb[3] = yb[2] - bgH[3] + 90;
                    break;
                case 19:
                    yb[0] = gH - bgH[0] + 150;
                    yb[1] = yb[0] - bgH[1] - 60;
                    yb[2] = yb[1] - bgH[2] - 40;
                    yb[3] = yb[2] - bgH[3] - 10;
                    yb[4] = yb[3] - bgH[4];
                    break;
                default:
                    yb[0] = gH - bgH[0] + 75;
                    yb[1] = yb[0] - bgH[1] + 50;
                    yb[2] = yb[1] - bgH[2] + 50;
                    yb[3] = yb[2] - bgH[3] + 90;
                    break;
            }
        }
        catch (Exception)
        {
            int gH2 = GameScr2.gH23;
            for (int i = 0; i < yb.Length; i++)
            {
                yb[i] = 1;
            }
        }
    }

    public static void loadBG(int typeBG)
    {
        try
        {
            isLoadBGok = true;
            if (typeBg == 12)
            {
                BackgroudEffect2.yfog = TileMap2.pxh - 100;
            }
            else
            {
                BackgroudEffect2.yfog = TileMap2.pxh - 160;
            }
            BackgroudEffect2.clearImage();
            randomRaintEff(typeBG);
            if ((TileMap2.lastBgID == typeBG && TileMap2.lastType == TileMap2.bgType) || typeBG == -1)
            {
                return;
            }
            transY = 12;
            TileMap2.lastBgID = (sbyte)typeBG;
            TileMap2.lastType = (sbyte)TileMap2.bgType;
            layerSpeed = new int[5] { 1, 2, 3, 7, 8 };
            moveX = new int[5];
            moveXSpeed = new int[5];
            typeBg = typeBG;
            isBoltEff = false;
            GameScr2.firstY = GameScr2.cmy;
            imgBG = null;
            imgCloud = null;
            imgSun = null;
            imgCaycot = null;
            GameScr2.firstY = -1;
            switch (typeBg)
            {
                case 0:
                    imgCaycot = loadImageRMS("/bg/caycot.png");
                    layerSpeed = new int[4] { 1, 3, 5, 7 };
                    nBg = 4;
                    if (TileMap2.bgType == 2)
                    {
                        transY = 8;
                    }
                    break;
                case 1:
                    transY = 7;
                    nBg = 4;
                    break;
                case 2:
                    moveX = new int[5] { 0, 0, 1, 0, 0 };
                    moveXSpeed = new int[5] { 0, 0, 2, 0, 0 };
                    nBg = 5;
                    break;
                case 3:
                    nBg = 3;
                    break;
                case 4:
                    BackgroudEffect2.addEffect(3);
                    moveX = new int[5] { 0, 1, 0, 0, 0 };
                    moveXSpeed = new int[5] { 0, 1, 0, 0, 0 };
                    nBg = 4;
                    break;
                case 5:
                    nBg = 4;
                    break;
                case 6:
                    moveX = new int[5] { 1, 0, 0, 0, 0 };
                    moveXSpeed = new int[5] { 2, 0, 0, 0, 0 };
                    nBg = 5;
                    break;
                case 7:
                    nBg = 4;
                    break;
                case 8:
                    transY = 8;
                    nBg = 4;
                    break;
                case 9:
                    BackgroudEffect2.addEffect(9);
                    nBg = 4;
                    break;
                case 10:
                    nBg = 2;
                    break;
                case 11:
                    transY = 7;
                    layerSpeed[2] = 0;
                    nBg = 3;
                    break;
                case 12:
                    moveX = new int[5] { 1, 1, 0, 0, 0 };
                    moveXSpeed = new int[5] { 2, 1, 0, 0, 0 };
                    nBg = 3;
                    break;
                case 13:
                    nBg = 2;
                    break;
                case 15:
                    Res2.outz("HELL");
                    nBg = 2;
                    break;
                case 16:
                    layerSpeed = new int[4] { 1, 3, 5, 7 };
                    nBg = 4;
                    break;
                case 19:
                    moveX = new int[5] { 0, 2, 1, 0, 0 };
                    moveXSpeed = new int[5] { 0, 2, 1, 0, 0 };
                    nBg = 5;
                    break;
                default:
                    layerSpeed = new int[4] { 1, 3, 5, 7 };
                    nBg = 4;
                    break;
            }
            if (typeBG <= 16)
            {
                skyColor = StaticObj2.SKYCOLOR[typeBg];
            }
            else
            {
                try
                {
                    string path = "/bg/b" + typeBg + 3 + ".png";
                    if (TileMap2.bgType != 0)
                    {
                        path = "/bg/b" + typeBg + 3 + "-" + TileMap2.bgType + ".png";
                    }
                    int[] data = new int[1];
                    Image2 image = loadImageRMS(path);
                    image.getRGB(ref data, 0, 1, mGraphics2.getRealImageWidth(image) / 2, 0, 1, 1);
                    skyColor = data[0];
                }
                catch (Exception)
                {
                    skyColor = StaticObj2.SKYCOLOR[StaticObj2.SKYCOLOR.Length - 1];
                }
            }
            colorTop = new int[StaticObj2.SKYCOLOR.Length];
            colorBotton = new int[StaticObj2.SKYCOLOR.Length];
            for (int i = 0; i < StaticObj2.SKYCOLOR.Length; i++)
            {
                colorTop[i] = StaticObj2.SKYCOLOR[i];
                colorBotton[i] = StaticObj2.SKYCOLOR[i];
            }
            if (lowGraphic)
            {
                tam = loadImageRMS("/bg/b63.png");
                return;
            }
            imgBG = new Image2[nBg];
            bgW = new int[nBg];
            bgH = new int[nBg];
            colorBotton = new int[nBg];
            colorTop = new int[nBg];
            if (TileMap2.bgType == 100)
            {
                imgBG[0] = loadImageRMS("/bg/b100.png");
                imgBG[1] = loadImageRMS("/bg/b100.png");
                imgBG[2] = loadImageRMS("/bg/b82-1.png");
                imgBG[3] = loadImageRMS("/bg/b93.png");
                for (int j = 0; j < nBg; j++)
                {
                    if (imgBG[j] != null)
                    {
                        int[] data2 = new int[1];
                        imgBG[j].getRGB(ref data2, 0, 1, mGraphics2.getRealImageWidth(imgBG[j]) / 2, 0, 1, 1);
                        colorTop[j] = data2[0];
                        data2 = new int[1];
                        imgBG[j].getRGB(ref data2, 0, 1, mGraphics2.getRealImageWidth(imgBG[j]) / 2, mGraphics2.getRealImageHeight(imgBG[j]) - 1, 1, 1);
                        colorBotton[j] = data2[0];
                        bgW[j] = mGraphics2.getImageWidth(imgBG[j]);
                        bgH[j] = mGraphics2.getImageHeight(imgBG[j]);
                    }
                    else if (nBg > 1)
                    {
                        imgBG[j] = loadImageRMS("/bg/b" + typeBg + "0.png");
                        bgW[j] = mGraphics2.getImageWidth(imgBG[j]);
                        bgH[j] = mGraphics2.getImageHeight(imgBG[j]);
                    }
                }
            }
            else
            {
                for (int k = 0; k < nBg; k++)
                {
                    string path2 = "/bg/b" + typeBg + k + ".png";
                    if (TileMap2.bgType != 0)
                    {
                        path2 = "/bg/b" + typeBg + k + "-" + TileMap2.bgType + ".png";
                    }
                    imgBG[k] = loadImageRMS(path2);
                    if (imgBG[k] != null)
                    {
                        int[] data3 = new int[1];
                        imgBG[k].getRGB(ref data3, 0, 1, mGraphics2.getRealImageWidth(imgBG[k]) / 2, 0, 1, 1);
                        colorTop[k] = data3[0];
                        data3 = new int[1];
                        imgBG[k].getRGB(ref data3, 0, 1, mGraphics2.getRealImageWidth(imgBG[k]) / 2, mGraphics2.getRealImageHeight(imgBG[k]) - 1, 1, 1);
                        colorBotton[k] = data3[0];
                        bgW[k] = mGraphics2.getImageWidth(imgBG[k]);
                        bgH[k] = mGraphics2.getImageHeight(imgBG[k]);
                    }
                    else if (nBg > 1)
                    {
                        imgBG[k] = loadImageRMS("/bg/b" + typeBg + "0.png");
                        bgW[k] = mGraphics2.getImageWidth(imgBG[k]);
                        bgH[k] = mGraphics2.getImageHeight(imgBG[k]);
                    }
                }
            }
            getYBackground(typeBg);
            cloudX = new int[5]
            {
                GameScr2.gW / 2 - 40,
                GameScr2.gW / 2 + 40,
                GameScr2.gW / 2 - 100,
                GameScr2.gW / 2 - 80,
                GameScr2.gW / 2 - 120
            };
            cloudY = new int[5] { 130, 100, 150, 140, 80 };
            imgSunSpec = null;
            if (typeBg != 0)
            {
                if (typeBg == 2)
                {
                    imgSun = loadImageRMS("/bg/sun0.png");
                    sunX = GameScr2.gW / 2 + 50;
                    sunY = yb[4] - 40;
                    TileMap2.imgWaterflow = loadImageRMS("/tWater/wts");
                }
                else if (typeBg == 19)
                {
                    TileMap2.imgWaterflow = loadImageRMS("/tWater/water_flow_32");
                }
                else if (typeBg == 4)
                {
                    imgSun = loadImageRMS("/bg/sun2.png");
                    sunX = GameScr2.gW / 2 + 30;
                    sunY = yb[3];
                }
                else if (typeBg == 7)
                {
                    imgSun = loadImageRMS("/bg/sun3" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                    imgSun2 = loadImageRMS("/bg/sun4" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                    sunX = GameScr2.gW - GameScr2.gW / 3;
                    sunY = yb[3] - 80;
                    sunX2 = sunX - 100;
                    sunY2 = yb[3] - 30;
                }
                else if (typeBg == 6)
                {
                    imgSun = loadImageRMS("/bg/sun5" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                    imgSun2 = loadImageRMS("/bg/sun6" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                    sunX = GameScr2.gW - GameScr2.gW / 3;
                    sunY = yb[4];
                    sunX2 = sunX - 100;
                    sunY2 = yb[4] + 20;
                }
                else if (typeBG == 5)
                {
                    imgSun = loadImageRMS("/bg/sun8" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                    imgSun2 = loadImageRMS("/bg/sun7" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                    sunX = GameScr2.gW / 2 - 50;
                    sunY = yb[3] + 20;
                    sunX2 = GameScr2.gW / 2 + 20;
                    sunY2 = yb[3] - 30;
                }
                else if (typeBg == 8 && TileMap2.mapID < 90)
                {
                    imgSun = loadImageRMS("/bg/sun9" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                    imgSun2 = loadImageRMS("/bg/sun10" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                    sunX = GameScr2.gW / 2 - 30;
                    sunY = yb[3] + 60;
                    sunX2 = GameScr2.gW / 2 + 20;
                    sunY2 = yb[3] + 10;
                }
                else
                {
                    switch (typeBG)
                    {
                        case 9:
                            imgSun = loadImageRMS("/bg/sun11" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                            imgSun2 = loadImageRMS("/bg/sun12" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                            sunX = GameScr2.gW - GameScr2.gW / 3;
                            sunY = yb[4] + 20;
                            sunX2 = sunX - 80;
                            sunY2 = yb[4] + 40;
                            break;
                        case 10:
                            imgSun = loadImageRMS("/bg/sun13" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                            imgSun2 = loadImageRMS("/bg/sun14" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                            sunX = GameScr2.gW - GameScr2.gW / 3;
                            sunY = yb[1] - 30;
                            sunX2 = sunX - 80;
                            sunY2 = yb[1];
                            break;
                        case 11:
                            imgSun = loadImageRMS("/bg/sun15" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                            imgSun2 = loadImageRMS("/bg/b113" + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                            sunX = GameScr2.gW / 2 - 30;
                            sunY = yb[2] - 30;
                            break;
                        case 12:
                            cloudY = new int[5] { 200, 170, 220, 150, 250 };
                            break;
                        case 16:
                            {
                                cloudX = new int[7] { 90, 170, 250, 320, 400, 450, 500 };
                                cloudY = new int[7]
                                {
                            yb[2] + 5,
                            yb[2] - 20,
                            yb[2] - 50,
                            yb[2] - 30,
                            yb[2] - 50,
                            yb[2],
                            yb[2] - 40
                                };
                                imgSunSpec = new Image2[7];
                                for (int l = 0; l < imgSunSpec.Length; l++)
                                {
                                    int num = 161;
                                    if (l == 0 || l == 2 || l == 3 || l == 2 || l == 6)
                                    {
                                        num = 160;
                                    }
                                    imgSunSpec[l] = loadImageRMS("/bg/sun" + num + ".png");
                                }
                                break;
                            }
                        case 19:
                            moveX = new int[5] { 0, 2, 1, 0, 0 };
                            moveXSpeed = new int[5] { 0, 2, 1, 0, 0 };
                            nBg = 5;
                            break;
                        default:
                            imgCloud = null;
                            imgSun = null;
                            imgSun2 = null;
                            imgSun = loadImageRMS("/bg/sun" + typeBG + ((TileMap2.bgType != 0) ? ("-" + TileMap2.bgType) : string.Empty) + ".png");
                            sunX = GameScr2.gW - GameScr2.gW / 3;
                            sunY = yb[2] - 30;
                            break;
                    }
                }
            }
            paintBG = false;
            if (!paintBG)
            {
                paintBG = true;
            }
        }
        catch (Exception)
        {
            isLoadBGok = false;
        }
    }

    private static void randomRaintEff(int typeBG)
    {
        for (int i = 0; i < bgRain.Length; i++)
        {
            if (typeBG == bgRain[i] && Res2.random(0, 2) == 0)
            {
                BackgroudEffect2.addEffect(0);
                break;
            }
        }
    }

    public void keyPressedz(int keyCode)
    {
        lastTimePress = mSystem2.currentTimeMillis();
        if ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 122) || keyCode == 10 || keyCode == 8 || keyCode == 13 || keyCode == 32 || keyCode == 31)
        {
            keyAsciiPress = keyCode;
        }
        mapKeyPress(keyCode);
    }

    public void mapKeyPress(int keyCode)
    {
        if (currentDialog != null)
        {
            currentDialog.keyPress(keyCode);
            keyAsciiPress = 0;
            return;
        }
        currentScreen.keyPress(keyCode);
        switch (keyCode)
        {
            case -38:
            case -1:
                if ((currentScreen is GameScr2 || currentScreen is CrackBallScr2) && Char2.myCharz().isAttack)
                {
                    clearKeyHold();
                    clearKeyPressed();
                }
                else
                {
                    keyHold[21] = true;
                    keyPressed[21] = true;
                }
                break;
            case -39:
            case -2:
                if ((currentScreen is GameScr2 || currentScreen is CrackBallScr2) && Char2.myCharz().isAttack)
                {
                    clearKeyHold();
                    clearKeyPressed();
                }
                else
                {
                    keyHold[22] = true;
                    keyPressed[22] = true;
                }
                break;
            case -3:
                if ((currentScreen is GameScr2 || currentScreen is CrackBallScr2) && Char2.myCharz().isAttack)
                {
                    clearKeyHold();
                    clearKeyPressed();
                }
                else
                {
                    keyHold[23] = true;
                    keyPressed[23] = true;
                }
                break;
            case -4:
                if ((currentScreen is GameScr2 || currentScreen is CrackBallScr2) && Char2.myCharz().isAttack)
                {
                    clearKeyHold();
                    clearKeyPressed();
                }
                else
                {
                    keyHold[24] = true;
                    keyPressed[24] = true;
                }
                break;
            case -5:
            case 10:
                if ((currentScreen is GameScr2 || currentScreen is CrackBallScr2) && Char2.myCharz().isAttack)
                {
                    clearKeyHold();
                    clearKeyPressed();
                    break;
                }
                keyHold[25] = true;
                keyPressed[25] = true;
                keyHold[15] = true;
                keyPressed[15] = true;
                break;
            case 48:
                keyHold[0] = true;
                keyPressed[0] = true;
                break;
            case 49:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[1] = true;
                    keyPressed[1] = true;
                }
                break;
            case 51:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[3] = true;
                    keyPressed[3] = true;
                }
                break;
            case 55:
                keyHold[7] = true;
                keyPressed[7] = true;
                break;
            case 57:
                keyHold[9] = true;
                keyPressed[9] = true;
                break;
            case 42:
                keyHold[10] = true;
                keyPressed[10] = true;
                break;
            case 35:
                keyHold[11] = true;
                keyPressed[11] = true;
                break;
            case -21:
            case -6:
                keyHold[12] = true;
                keyPressed[12] = true;
                break;
            case -22:
            case -7:
                keyHold[13] = true;
                keyPressed[13] = true;
                break;
            case 50:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[2] = true;
                    keyPressed[2] = true;
                }
                break;
            case 52:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[4] = true;
                    keyPressed[4] = true;
                }
                break;
            case 54:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[6] = true;
                    keyPressed[6] = true;
                }
                break;
            case 56:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[8] = true;
                    keyPressed[8] = true;
                }
                break;
            case 53:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[5] = true;
                    keyPressed[5] = true;
                }
                break;
            case -8:
                keyHold[14] = true;
                keyPressed[14] = true;
                break;
            case -26:
                keyHold[16] = true;
                keyPressed[16] = true;
                break;
            case 113:
                keyHold[17] = true;
                keyPressed[17] = true;
                break;
        }
    }

    public void keyReleasedz(int keyCode)
    {
        keyAsciiPress = 0;
        mapKeyRelease(keyCode);
    }

    public void mapKeyRelease(int keyCode)
    {
        switch (keyCode)
        {
            case -38:
            case -1:
                keyHold[21] = false;
                break;
            case -39:
            case -2:
                keyHold[22] = false;
                break;
            case -3:
                keyHold[23] = false;
                break;
            case -4:
                keyHold[24] = false;
                break;
            case -5:
            case 10:
                keyHold[25] = false;
                keyReleased[25] = true;
                keyHold[15] = true;
                keyPressed[15] = true;
                break;
            case 48:
                keyHold[0] = false;
                keyReleased[0] = true;
                break;
            case 49:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[1] = false;
                    keyReleased[1] = true;
                }
                break;
            case 51:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[3] = false;
                    keyReleased[3] = true;
                }
                break;
            case 55:
                keyHold[7] = false;
                keyReleased[7] = true;
                break;
            case 57:
                keyHold[9] = false;
                keyReleased[9] = true;
                break;
            case 42:
                keyHold[10] = false;
                keyReleased[10] = true;
                break;
            case 35:
                keyHold[11] = false;
                keyReleased[11] = true;
                break;
            case -21:
            case -6:
                keyHold[12] = false;
                keyReleased[12] = true;
                break;
            case -22:
            case -7:
                keyHold[13] = false;
                keyReleased[13] = true;
                break;
            case 50:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[2] = false;
                    keyReleased[2] = true;
                }
                break;
            case 52:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[4] = false;
                    keyReleased[4] = true;
                }
                break;
            case 54:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[6] = false;
                    keyReleased[6] = true;
                }
                break;
            case 56:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[8] = false;
                    keyReleased[8] = true;
                }
                break;
            case 53:
                if (currentScreen == CrackBallScr2.instance || (currentScreen == GameScr2.instance && isMoveNumberPad && !ChatTextField2.gI().isShow))
                {
                    keyHold[5] = false;
                    keyReleased[5] = true;
                }
                break;
            case -8:
                keyHold[14] = false;
                break;
            case -26:
                keyHold[16] = false;
                break;
            case 113:
                keyHold[17] = false;
                keyReleased[17] = true;
                break;
        }
    }

    public void pointerMouse(int x, int y)
    {
        pxMouse = x;
        pyMouse = y;
    }

    public void scrollMouse(int a)
    {
        pXYScrollMouse = a;
        if (panel != null && panel.isShow)
        {
            panel.updateScroolMouse(a);
        }
    }

    public void pointerDragged(int x, int y)
    {
        if (Res2.abs(x - pxLast) >= 10 || Res2.abs(y - pyLast) >= 10)
        {
            isPointerClick = false;
            isPointerDown = true;
            isPointerMove = true;
        }
        px = x;
        py = y;
        curPos++;
        if (curPos > 3)
        {
            curPos = 0;
        }
        arrPos[curPos] = new Position2(x, y);
    }

    public static bool isHoldPress()
    {
        if (mSystem2.currentTimeMillis() - lastTimePress >= 800)
        {
            return true;
        }
        return false;
    }

    public void pointerPressed(int x, int y)
    {
        isPointerJustRelease = false;
        isPointerJustDown = true;
        isPointerDown = true;
        isPointerClick = true;
        isPointerMove = false;
        lastTimePress = mSystem2.currentTimeMillis();
        pxFirst = x;
        pyFirst = y;
        pxLast = x;
        pyLast = y;
        px = x;
        py = y;
    }

    public void pointerReleased(int x, int y)
    {
        isPointerDown = false;
        isPointerJustRelease = true;
        isPointerMove = false;
        mScreen2.keyTouch = -1;
        px = x;
        py = y;
    }

    public static bool isPointerHoldIn(int x, int y, int w, int h)
    {
        if (!isPointerDown && !isPointerJustRelease)
        {
            return false;
        }
        if (px >= x && px <= x + w && py >= y && py <= y + h)
        {
            return true;
        }
        return false;
    }

    public static bool isMouseFocus(int x, int y, int w, int h)
    {
        if (pxMouse >= x && pxMouse <= x + w && pyMouse >= y && pyMouse <= y + h)
        {
            return true;
        }
        return false;
    }

    public static void clearKeyPressed()
    {
        for (int i = 0; i < keyPressed.Length; i++)
        {
            keyPressed[i] = false;
        }
        isPointerJustRelease = false;
    }

    public static void clearKeyHold()
    {
        for (int i = 0; i < keyHold.Length; i++)
        {
            keyHold[i] = false;
        }
    }

    public static void checkBackButton()
    {
        if (ChatPopup2.serverChatPopUp == null && ChatPopup2.currChatPopup == null)
        {
            startYesNoDlg(mResources2.DOYOUWANTEXIT, new Command2(mResources2.YES, instance, 8885, null), new Command2(mResources2.NO, instance, 8882, null));
        }
    }

    public void paintChangeMap(mGraphics2 g)
    {
        string empty = string.Empty;
        resetTrans(g);
        g.setColor(0);
        g.fillRect(0, 0, w, h);
        //g.drawImage(SplashScr.imgLogo, w / 2, h / 2 - 24, StaticObj.BOTTOM_HCENTER);

        int imgW = MainMod2.imgLogoBig.getWidth() * mGraphics2.zoomLevel / 4;
        int imgH = MainMod2.imgLogoBig.getHeight() * mGraphics2.zoomLevel / 4;
        g.drawImageScale(MainMod2.imgLogoBig, (w - imgW) / 2, (h - imgH) / 2 - 30, imgW, imgH);

        paintShukiren(hw, h / 2 + 24, g);
        mFont2.tahoma_7b_white.drawString(g, mResources2.PLEASEWAIT + ((LoginScr2.timeLogin <= 0) ? empty : (" " + LoginScr2.timeLogin + "s")), w / 2, h / 2, 2);
    }

    public void paint(mGraphics2 gx)
    {
        try
        {
            debugPaint.removeAllElements();
            debug("PA", 1);
            if (currentScreen != null)
            {
                currentScreen.paint(g);
            }
            debug("PB", 1);
            g.translate(-g.getTranslateX(), -g.getTranslateY());
            g.setClip(0, 0, w, h);
            if (panel.isShow)
            {
                panel.paint(g);
                if (panel2 != null && panel2.isShow)
                {
                    panel2.paint(g);
                }
                if (panel.chatTField != null && panel.chatTField.isShow)
                {
                    panel.chatTField.paint(g);
                }
                if (panel2 != null && panel2.chatTField != null && panel2.chatTField.isShow)
                {
                    panel2.chatTField.paint(g);
                }
            }
            Res2.paintOnScreenDebug(g);
            InfoDlg2.paint(g);
            if (currentDialog != null)
            {
                debug("PC", 1);
                currentDialog.paint(g);
            }
            else if (menu.showMenu)
            {
                debug("PD", 1);
                menu.paintMenu(g);
            }
            GameScr2.info1.paint(g);
            GameScr2.info2.paint(g);
            if (GameScr2.gI().popUpYesNo != null)
            {
                GameScr2.gI().popUpYesNo.paint(g);
            }
            if (ChatPopup2.currChatPopup != null)
            {
                ChatPopup2.currChatPopup.paint(g);
            }
            Hint2.paint(g);
            if (ChatPopup2.serverChatPopUp != null)
            {
                ChatPopup2.serverChatPopUp.paint(g);
            }
            for (int i = 0; i < Effect2_2.vEffect2.size(); i++)
            {
                Effect2_2 effect = (Effect2_2)Effect2_2.vEffect2.elementAt(i);
                if (effect is ChatPopup2 && !effect.Equals(ChatPopup2.currChatPopup) && !effect.Equals(ChatPopup2.serverChatPopUp))
                {
                    effect.paint(g);
                }
            }
            if (Char2.isLoadingMap || LoginScr2.isContinueToLogin || ServerListScreen2.waitToLogin || ServerListScreen2.isWait)
            {
                paintChangeMap(g);
                if (timeLoading > 0 && LoginScr2.timeLogin <= 0)
                {
                    startWaitDlg();
                    if (mSystem2.currentTimeMillis() - TIMEOUT >= 1000)
                    {
                        timeLoading--;
                        Res2.outz("[COUNT] == " + timeLoading);
                        if (timeLoading == 0)
                        {
                            timeLoading = 15;
                        }
                        TIMEOUT = mSystem2.currentTimeMillis();
                    }
                }
                if (mSystem2.currentTimeMillis() > timeBreakLoading)
                {
                    timeBreakLoading = mSystem2.currentTimeMillis() + 30000;
                    if (currentScreen != null)
                    {
                        if (currentScreen is GameScr2)
                        {
                            GameScr2.gI().switchToMe();
                        }
                        else if (!(currentScreen is SplashScr2) && currentScreen is LoginScr2)
                        {
                            gI().resetToLoginScrz();
                        }
                    }
                }
            }
            debug("PE", 1);
            resetTrans(g);
            EffecMn2.paintLayer4(g);
            resetTrans(g);
            int num = h / 4;
            if (currentScreen != null && currentScreen is GameScr2 && thongBaoTest != null)
            {
                g.setClip(60, num, w - 120, mFont2.tahoma_7_white.getHeight() + 2);
                mFont2.tahoma_7_grey.drawString(g, thongBaoTest, xThongBaoTranslate, num + 1, 0);
                mFont2.tahoma_7_yellow.drawString(g, thongBaoTest, xThongBaoTranslate, num, 0);
                g.setClip(0, 0, w, h);
            }
        }
        catch (Exception)
        {
        }
    }

    public static void endDlg()
    {
        if (inputDlg != null)
        {
            inputDlg.tfInput.setMaxTextLenght(500);
        }
        currentDialog = null;
        InfoDlg2.hide();
    }

    public static void startOKDlg(string info)
    {
        closeKeyBoard();
        msgdlg.setInfo(info, null, new Command2(mResources2.OK, instance, 8882, null), null);
        currentDialog = msgdlg;
    }

    public static void startWaitDlg(string info)
    {
        closeKeyBoard();
        msgdlg.setInfo(info, null, new Command2(mResources2.CANCEL, instance, 8882, null), null);
        currentDialog = msgdlg;
        msgdlg.isWait = true;
    }

    public static void startOKDlg(string info, bool isError)
    {
        closeKeyBoard();
        msgdlg.setInfo(info, null, new Command2(mResources2.CANCEL, instance, 8882, null), null);
        currentDialog = msgdlg;
        msgdlg.isWait = true;
    }

    public static void startWaitDlg()
    {
        closeKeyBoard();
        Char2.isLoadingMap = true;
    }

    public void openWeb(string strLeft, string strRight, string url, string str)
    {
        msgdlg.setInfo(str, new Command2(strLeft, this, 8881, url), null, new Command2(strRight, this, 8882, null));
        currentDialog = msgdlg;
    }

    public static void startOK(string info, int actionID, object p)
    {
        closeKeyBoard();
        msgdlg.setInfo(info, null, new Command2(mResources2.OK, instance, actionID, p), null);
        msgdlg.show();
    }

    public static void startYesNoDlg(string info, int iYes, object pYes, int iNo, object pNo)
    {
        closeKeyBoard();
        msgdlg.setInfo(info, new Command2(mResources2.YES, instance, iYes, pYes), new Command2(string.Empty, instance, iYes, pYes), new Command2(mResources2.NO, instance, iNo, pNo));
        msgdlg.show();
    }

    public static void startYesNoDlg(string info, Command2 cmdYes, Command2 cmdNo)
    {
        closeKeyBoard();
        msgdlg.setInfo(info, cmdYes, null, cmdNo);
        msgdlg.show();
    }

    public static void startserverThongBao(string msgSv)
    {
        thongBaoTest = msgSv;
        xThongBaoTranslate = w - 60;
        dir_ = -1;
    }

    public static string getMoneys(int m)
    {
        string text = string.Empty;
        int num = m / 1000 + 1;
        for (int i = 0; i < num; i++)
        {
            if (m >= 1000)
            {
                int num2 = m % 1000;
                text = ((num2 != 0) ? ((num2 >= 10) ? ((num2 >= 100) ? ("." + num2 + text) : (".0" + num2 + text)) : (".00" + num2 + text)) : (".000" + text));
                m /= 1000;
                continue;
            }
            text = m + text;
            break;
        }
        return text;
    }

    public static int getX(int start, int w)
    {
        return (px - start) / w;
    }

    public static int getY(int start, int w)
    {
        return (py - start) / w;
    }

    protected void sizeChanged(int w, int h)
    {
    }

    public static bool isGetResourceFromServer()
    {
        return true;
    }

    public static Image2 loadImageRMS(string path)
    {
        path = Main2.res + "/x" + mGraphics2.zoomLevel + path;
        path = cutPng(path);
        Image2 result = null;
        try
        {
            result = Image2.createImage(path);
        }
        catch (Exception ex)
        {
            try
            {
                string[] array = Res2.split(path, "/", 0);
                string filename = "x" + mGraphics2.zoomLevel + array[array.Length - 1];
                sbyte[] array2 = Rms2.loadRMS(filename);
                if (array2 != null)
                {
                    sbyte[] newArr = MainMod2.DecryptBytes(array2);
                    result = Image2.createImage(newArr, 0, newArr.Length);
                    array2 = null;
                    newArr = null;
                }
            }
            catch (Exception)
            {
                Cout2.LogError("Loi ham khong tim thay a: " + ex.ToString());
            }
        }
        return result;
    }

    public static Image2 loadImage(string path)
    {
        path = Main2.res + "/x4" + path;
        path = cutPng(path);
        Image2 result = null;
        try
        {
            result = Image2.CreateImageResize(path);
        }
        catch (Exception)
        {
        }
        return result;
    }

    public static Image2 LoadImageFromRoot(string path)
    {
        path = Main2.res + path;
        path = cutPng(path);
        Image2 result = null;
        try
        {
            result = Image2.createImage(path);
        }
        catch (Exception)
        {
        }
        return result;
    }

    public static string cutPng(string str)
    {
        string result = str;
        if (str.Contains(".png"))
        {
            result = str.Replace(".png", string.Empty);
        }
        return result;
    }

    public static int random(int a, int b)
    {
        return a + r.nextInt(b - a);
    }

    public bool startDust(int dir, int x, int y)
    {
        if (lowGraphic)
        {
            return false;
        }
        int num = ((dir != 1) ? 1 : 0);
        if (dustState[num] != -1)
        {
            return false;
        }
        dustState[num] = 0;
        dustX[num] = x;
        dustY[num] = y;
        return true;
    }

    public void loadWaterSplash()
    {
        if (!lowGraphic)
        {
            imgWS = new Image2[3];
            for (int i = 0; i < 3; i++)
            {
                imgWS[i] = loadImage("/e/w" + i + ".png");
            }
            wsX = new int[2];
            wsY = new int[2];
            wsState = new int[2];
            wsF = new int[2];
            wsState[0] = (wsState[1] = -1);
        }
    }

    public bool startWaterSplash(int x, int y)
    {
        if (lowGraphic)
        {
            return false;
        }
        int num = ((wsState[0] != -1) ? 1 : 0);
        if (wsState[num] != -1)
        {
            return false;
        }
        wsState[num] = 0;
        wsX[num] = x;
        wsY[num] = y;
        return true;
    }

    public void updateWaterSplash()
    {
        if (lowGraphic)
        {
            return;
        }
        for (int i = 0; i < 2; i++)
        {
            if (wsState[i] == -1)
            {
                continue;
            }
            wsY[i]--;
            if (gameTick % 2 == 0)
            {
                wsState[i]++;
                if (wsState[i] > 2)
                {
                    wsState[i] = -1;
                }
                else
                {
                    wsF[i] = wsState[i];
                }
            }
        }
    }

    public void updateDust()
    {
        if (lowGraphic)
        {
            return;
        }
        for (int i = 0; i < 2; i++)
        {
            if (dustState[i] != -1)
            {
                dustState[i]++;
                if (dustState[i] >= 5)
                {
                    dustState[i] = -1;
                }
                if (i == 0)
                {
                    dustX[i]--;
                }
                else
                {
                    dustX[i]++;
                }
                dustY[i]--;
            }
        }
    }

    public static bool isPaint(int x, int y)
    {
        if (x < GameScr2.cmx)
        {
            return false;
        }
        if (x > GameScr2.cmx + GameScr2.gW)
        {
            return false;
        }
        if (y < GameScr2.cmy)
        {
            return false;
        }
        if (y > GameScr2.cmy + GameScr2.gH + 30)
        {
            return false;
        }
        return true;
    }

    public void paintDust(mGraphics2 g)
    {
        if (lowGraphic)
        {
            return;
        }
        for (int i = 0; i < 2; i++)
        {
            if (dustState[i] != -1 && isPaint(dustX[i], dustY[i]))
            {
                g.drawImage(imgDust[i][dustState[i]], dustX[i], dustY[i], 3);
            }
        }
    }

    public void loadDust()
    {
        if (lowGraphic)
        {
            return;
        }
        if (imgDust == null)
        {
            imgDust = new Image2[2][];
            for (int i = 0; i < imgDust.Length; i++)
            {
                imgDust[i] = new Image2[5];
            }
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    imgDust[j][k] = loadImage("/e/d" + j + k + ".png");
                }
            }
        }
        dustX = new int[2];
        dustY = new int[2];
        dustState = new int[2];
        dustState[0] = (dustState[1] = -1);
    }

    public static void paintShukiren(int x, int y, mGraphics2 g)
    {
        g.drawRegion(imgShuriken, 0, Main2.f * 16, 16, 16, 0, x, y, mGraphics2.HCENTER | mGraphics2.VCENTER);
    }

    public void resetToLoginScrz()
    {
        resetToLoginScr = true;
    }

    public static bool isPointer(int x, int y, int w, int h)
    {
        if (!isPointerDown && !isPointerJustRelease)
        {
            return false;
        }
        if (px >= x && px <= x + w && py >= y && py <= y + h)
        {
            return true;
        }
        return false;
    }

    public void perform(int idAction, object p)
    {
        switch (idAction)
        {
            case 9000:
                endDlg();
                MainMod2.imgLogoBig = null;
                SmallImage2.loadBigRMS();
                mSystem2.gcc();
                ServerListScreen2.bigOk = true;
                ServerListScreen2.loadScreen = true;
                GameScr2.gI().loadGameScr();
                if (currentScreen != loginScr)
                {
                    serverScreen.switchToMe2();
                }
                break;
            case 999:
                mSystem2.closeBanner();
                endDlg();
                break;
            case 888396:
                endDlg();
                break;
            case 888397:
                {
                    string text5 = (string)p;
                    break;
                }
            case 9999:
                endDlg();
                connect();
                Service2.gI().setClientType();
                if (loginScr == null)
                {
                    loginScr = new LoginScr2();
                }
                loginScr.doLogin();
                break;
            case 8881:
                {
                    string url = (string)p;
                    try
                    {
                        GameMidlet2.instance.platformRequest(url);
                    }
                    catch (Exception)
                    {
                    }
                    currentDialog = null;
                    break;
                }
            case 8882:
                InfoDlg2.hide();
                currentDialog = null;
                ServerListScreen2.isAutoConect = false;
                ServerListScreen2.countDieConnect = 0;
                break;
            case 8884:
                endDlg();
                loginScr.switchToMe();
                break;
            case 8885:
                GameMidlet2.instance.exit();
                break;
            case 8886:
                {
                    endDlg();
                    string name = (string)p;
                    Service2.gI().addFriend(name);
                    break;
                }
            case 8887:
                {
                    endDlg();
                    int charId = (int)p;
                    Service2.gI().addPartyAccept(charId);
                    break;
                }
            case 8888:
                {
                    int charId2 = (int)p;
                    Service2.gI().addPartyCancel(charId2);
                    endDlg();
                    break;
                }
            case 8889:
                {
                    string str = (string)p;
                    endDlg();
                    Service2.gI().acceptPleaseParty(str);
                    break;
                }
            case 88810:
                {
                    int playerMapId = (int)p;
                    endDlg();
                    Service2.gI().acceptInviteTrade(playerMapId);
                    break;
                }
            case 88811:
                endDlg();
                Service2.gI().cancelInviteTrade();
                break;
            case 88814:
                {
                    Item2[] items = (Item2[])p;
                    endDlg();
                    Service2.gI().crystalCollectLock(items);
                    break;
                }
            case 88817:
                ChatPopup2.addChatPopup(string.Empty, 1, Char2.myCharz().npcFocus);
                Service2.gI().menu(Char2.myCharz().npcFocus.template.npcTemplateId, menu.menuSelectedItem, 0);
                break;
            case 88818:
                {
                    short menuId3 = (short)p;
                    Service2.gI().textBoxId(menuId3, inputDlg.tfInput.getText());
                    endDlg();
                    break;
                }
            case 88819:
                {
                    short menuId2 = (short)p;
                    Service2.gI().menuId(menuId2);
                    break;
                }
            case 88820:
                {
                    string[] array = (string[])p;
                    if (Char2.myCharz().npcFocus == null)
                    {
                        break;
                    }
                    int menuSelectedItem = menu.menuSelectedItem;
                    if (array.Length > 1)
                    {
                        MyVector2 myVector = new MyVector2();
                        for (int i = 0; i < array.Length - 1; i++)
                        {
                            myVector.addElement(new Command2(array[i + 1], instance, 88821, menuSelectedItem));
                        }
                        menu.startAt(myVector, 3);
                    }
                    else
                    {
                        ChatPopup2.addChatPopup(string.Empty, 1, Char2.myCharz().npcFocus);
                        Service2.gI().menu(Char2.myCharz().npcFocus.template.npcTemplateId, menuSelectedItem, 0);
                    }
                    break;
                }
            case 88821:
                {
                    int menuId = (int)p;
                    ChatPopup2.addChatPopup(string.Empty, 1, Char2.myCharz().npcFocus);
                    Service2.gI().menu(Char2.myCharz().npcFocus.template.npcTemplateId, menuId, menu.menuSelectedItem);
                    break;
                }
            case 88822:
                ChatPopup2.addChatPopup(string.Empty, 1, Char2.myCharz().npcFocus);
                Service2.gI().menu(Char2.myCharz().npcFocus.template.npcTemplateId, menu.menuSelectedItem, 0);
                break;
            case 88823:
                startOKDlg(mResources2.SENTMSG);
                break;
            case 88824:
                startOKDlg(mResources2.NOSENDMSG);
                break;
            case 88825:
                startOKDlg(mResources2.sendMsgSuccess, isError: false);
                break;
            case 88826:
                startOKDlg(mResources2.cannotSendMsg, isError: false);
                break;
            case 88827:
                startOKDlg(mResources2.sendGuessMsgSuccess);
                break;
            case 88828:
                startOKDlg(mResources2.sendMsgFail);
                break;
            case 88829:
                {
                    string text4 = inputDlg.tfInput.getText();
                    if (!text4.Equals(string.Empty))
                    {
                        Service2.gI().changeName(text4, (int)p);
                        InfoDlg2.showWait();
                    }
                    break;
                }
            case 88836:
                inputDlg.tfInput.setMaxTextLenght(6);
                inputDlg.show(mResources2.INPUT_PRIVATE_PASS, new Command2(mResources2.ACCEPT, instance, 888361, null), TField2.INPUT_TYPE_NUMERIC);
                break;
            case 888361:
                {
                    string text3 = inputDlg.tfInput.getText();
                    endDlg();
                    if (text3.Length < 6 || text3.Equals(string.Empty))
                    {
                        startOKDlg(mResources2.ALERT_PRIVATE_PASS_1);
                        break;
                    }
                    try
                    {
                        Service2.gI().activeAccProtect(int.Parse(text3));
                        break;
                    }
                    catch (Exception ex3)
                    {
                        startOKDlg(mResources2.ALERT_PRIVATE_PASS_2);
                        Cout2.println("Loi tai 888361 Gamescavas " + ex3.ToString());
                        break;
                    }
                }
            case 88837:
                {
                    string text2 = inputDlg.tfInput.getText();
                    endDlg();
                    try
                    {
                        Service2.gI().openLockAccProtect(int.Parse(text2.Trim()));
                        break;
                    }
                    catch (Exception ex2)
                    {
                        Cout2.println("Loi tai 88837 " + ex2.ToString());
                        break;
                    }
                }
            case 88839:
                {
                    string text = inputDlg.tfInput.getText();
                    endDlg();
                    if (text.Length < 6 || text.Equals(string.Empty))
                    {
                        startOKDlg(mResources2.ALERT_PRIVATE_PASS_1);
                        break;
                    }
                    try
                    {
                        startYesNoDlg(mResources2.cancelAccountProtection, 888391, text, 8882, null);
                        break;
                    }
                    catch (Exception)
                    {
                        startOKDlg(mResources2.ALERT_PRIVATE_PASS_2);
                        break;
                    }
                }
            case 888391:
                {
                    string s = (string)p;
                    endDlg();
                    Service2.gI().clearAccProtect(int.Parse(s));
                    break;
                }
            case 888392:
                Service2.gI().menu(4, menu.menuSelectedItem, 0);
                break;
            case 888393:
                if (loginScr == null)
                {
                    loginScr = new LoginScr2();
                }
                loginScr.doLogin();
                Main2.closeKeyBoard();
                break;
            case 888394:
                endDlg();
                break;
            case 888395:
                endDlg();
                break;
            case 101023:
                Main2.numberQuit = 0;
                break;
            case 101024:
                endDlg();
                break;
            case 101025:
                endDlg();
                if (ServerListScreen2.loadScreen)
                {
                    serverScreen.switchToMe();
                }
                else
                {
                    serverScreen.show2();
                }
                break;
        }
    }

    public static void clearAllPointerEvent()
    {
        isPointerClick = false;
        isPointerDown = false;
        isPointerJustDown = false;
        isPointerJustRelease = false;
        GameScr2.gI().lastSingleClick = 0L;
        GameScr2.gI().isPointerDowning = false;
    }

    public static void backToRegister()
    {
    }
}
