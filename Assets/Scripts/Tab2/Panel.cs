using System;
using System.Collections.Generic;
using System.Threading;
using Mod2.XMAP;
using UnityEngine;

public class Panel2 : IActionListener2, IChatable2
{
    public class PlayerChat
    {
        public string name;

        public int charID;

        public bool isNewMessage;

        public List<InfoItem2> chats = new List<InfoItem2>();

        public PlayerChat(string name, int charId)
        {
            this.name = name;
            charID = charId;
            isNewMessage = true;
        }
    }

    public bool isShow;

    public int X;

    public int Y;

    public int W;

    public int H;

    public int ITEM_HEIGHT;

    public int TAB_W;

    public int TAB_W_NEW;

    public int cmtoY;

    public int cmy;

    public int cmdy;

    public int cmvy;

    public int cmyLim;

    public int xc;

    public int[] cmyLast;

    public int cmtoX;

    public int cmx;

    public int cmxLim;

    public int cmxMap;

    public int cmyMap;

    public int cmxMapLim;

    public int cmyMapLim;

    public int cmyQuest;

    public static Image2 imgBantay;

    public static Image2 imgX;

    public static Image2 imgMap;

    public TabClanIcon2 tabIcon;

    public MyVector2 vItemCombine = new MyVector2();

    public int moneyGD;

    public int friendMoneyGD;

    public bool isLock;

    public bool isFriendLock;

    public bool isAccept;

    public bool isFriendAccep;

    public string topName;

    public ChatTextField2 chatTField;

    public static string specialInfo;

    public static short spearcialImage;

    public static Image2 imgStar;

    public static Image2 imgMaxStar;

    public static Image2 imgStar8;

    public static Image2 imgNew;

    public static Image2 imgXu;

    public static Image2 imgThoivang;

    public static Image2 imgTicket;

    public static Image2 imgLuong;

    public static Image2 imgLuongKhoa;

    private static Image2 imgUp;

    private static Image2 imgDown;

    private int pa1;

    private int pa2;

    private bool trans;

    private int pX;

    private int pY;

    private Command2 left = new Command2(mResources2.SELECT, 0);

    public int type;

    public int currentTabIndex;

    public int startTabPos;

    public int[] lastTabIndex;

    public string[][] currentTabName;

    private int[] currClanOption;

    public int mainTabPos = 4;

    public int shopTabPos = 50;

    public int boxTabPos = 50;

    public string[][] mainTabName;

    public string[] mapNames;

    public string[] planetNames;

    public static string[] strTool = new string[7]
    {
        mResources2.gameInfo,
        mResources2.change_flag,
        mResources2.change_zone,
        mResources2.chat_world,
        mResources2.account,
        mResources2.option,
        mResources2.change_account
    };

    public static string[] strCauhinh = new string[4]
    {
        (!GameCanvas2.isPlaySound) ? mResources2.turnOnSound : mResources2.turnOffSound,
        mResources2.increase_vga,
        mResources2.analog,
        (mGraphics2.zoomLevel <= 1) ? mResources2.x2Screen : mResources2.x1Screen
    };

    public static string[] strModFunc = new string[1]
    {
        ""
    };

    public static string[] strAccount = new string[5]
    {
        mResources2.inventory_Pass,
        mResources2.friend,
        mResources2.enemy,
        mResources2.msg,
        mResources2.charger
    };

    public static string[] strAuto = new string[1] { mResources2.useGem };

    public static int graphics = 0;

    public string[][] shopTabName;

    public int[] maxPageShop;

    public int[] currPageShop;

    private static string[][] boxTabName = new string[2][]
    {
        mResources2.chestt,
        mResources2.inventory
    };

    private static string[][] boxCombine = new string[2][]
    {
        mResources2.combine,
        mResources2.inventory
    };

    private static string[][] boxZone = new string[1][] { mResources2.zonee };

    private static string[][] boxMap = new string[1][] { mResources2.mapp };

    private static string[][] boxGD = new string[3][]
    {
        mResources2.inventory,
        mResources2.item_give,
        mResources2.item_receive
    };

    private static string[][] boxPet = mResources2.petMainTab;

    public string[][][] tabName = new string[29][][]
    {
        null,
        null,
        boxTabName,
        boxZone,
        boxMap,
        null,
        null,
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
        boxCombine,
        boxGD,
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
        boxPet,
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
        new string[1][] { new string[1] { string.Empty } },
         new string[1][] { new string[1] { string.Empty } },
         boxPet
    };

    private static readonly sbyte BOX_BAG = 0;

    private static readonly sbyte BAG_BOX = 1;

    private static readonly sbyte BODY_BOX = 3;

    private static readonly sbyte BAG_BODY = 4;

    private static readonly sbyte BODY_BAG = 5;

    private static readonly sbyte BAG_PET = 6;

    private static readonly sbyte PET_BAG = 7;

    private static readonly sbyte BAG_PET2 = 8;

    private static readonly sbyte PET2_BAG = 9;

    public int hasUse;

    public int hasUseBag;

    public int currentListLength;

    private int[] lastSelect;

    public static int[] mapIdTraidat = new int[16]
    {
        21, 0, 1, 2, 24, 3, 4, 5, 6, 27,
        28, 29, 30, 42, 47, 46
    };

    public static int[] mapXTraidat = new int[16]
    {
        39, 42, 105, 93, 61, 93, 142, 165, 210, 100,
        165, 220, 233, 10, 125, 125
    };

    public static int[] mapYTraidat = new int[16]
    {
        28, 60, 48, 96, 88, 131, 136, 95, 32, 200,
        189, 167, 120, 110, 20, 20
    };

    public static int[] mapIdNamek = new int[14]
    {
        22, 7, 8, 9, 25, 11, 12, 13, 10, 31,
        32, 33, 34, 43
    };

    public static int[] mapXNamek = new int[14]
    {
        55, 30, 93, 80, 24, 149, 219, 220, 233, 170,
        148, 195, 148, 10
    };

    public static int[] mapYNamek = new int[14]
    {
        136, 84, 69, 34, 25, 42, 32, 110, 192, 70,
        106, 156, 210, 57
    };

    public static int[] mapIdSaya = new int[14]
    {
        23, 14, 15, 16, 26, 17, 18, 20, 19, 35,
        36, 37, 38, 44
    };

    public static int[] mapXSaya = new int[14]
    {
        90, 95, 144, 234, 231, 122, 176, 158, 205, 54,
        105, 159, 231, 27
    };

    public static int[] mapYSaya = new int[14]
    {
        10, 43, 20, 36, 69, 87, 112, 167, 160, 151,
        173, 207, 194, 29
    };

    public static int[][] mapId = new int[3][] { mapIdTraidat, mapIdNamek, mapIdSaya };

    public static int[][] mapX = new int[3][] { mapXTraidat, mapXNamek, mapXSaya };

    public static int[][] mapY = new int[3][] { mapYTraidat, mapYNamek, mapYSaya };

    public Item2 currItem;

    public Clan2 currClan;

    public ClanMessage2 currMess;

    public Member2 currMem;

    public Clan2[] clans;

    public MyVector2 member;

    public MyVector2 myMember;

    public MyVector2 logChat = new MyVector2();

    public MyVector2 vPlayerMenu = new MyVector2();

    public MyVector2 vFriend = new MyVector2();

    public MyVector2 vMyGD = new MyVector2();

    public MyVector2 vFriendGD = new MyVector2();

    public MyVector2 vTop = new MyVector2();

    public MyVector2 vEnemy = new MyVector2();

    public MyVector2 vFlag = new MyVector2();

    public MyVector2 vPlayerMenu_id = new MyVector2();

    public Command2 cmdClose;

    public static bool CanNapTien = false;

    public static int WIDTH_PANEL = 240;

    private int position;

    public string playerChat;

    public Dictionary<string, PlayerChat> chats = new Dictionary<string, PlayerChat>();

    public Char2 charMenu;

    private bool isThachDau;

    public int typeShop = -1;

    public int xScroll;

    public int yScroll;

    public int wScroll;

    public int hScroll;

    public ChatPopup2 cp;

    public int idIcon;

    public int[] partID;

    private int timeShow;

    public bool isBoxClan;

    public int w;

    private int pa;

    public int selected;

    private int cSelected;

    private int newSelected;

    private bool isClanOption;

    public bool isSearchClan;

    public bool isMessage;

    public bool isViewMember;

    public const int TYPE_MAIN = 0;

    public const int TYPE_SHOP = 1;

    public const int TYPE_BOX = 2;

    public const int TYPE_ZONE = 3;

    public const int TYPE_MAP = 4;

    public const int TYPE_CLANS = 5;

    public const int TYPE_INFOMATION = 6;

    public const int TYPE_BODY = 7;

    public const int TYPE_MESS = 8;

    public const int TYPE_ARCHIVEMENT = 9;

    public const int PLAYER_MENU = 10;

    public const int TYPE_FRIEND = 11;

    public const int TYPE_COMBINE = 12;

    public const int TYPE_GIAODICH = 13;

    public const int TYPE_MAPTRANS = 14;

    public const int TYPE_TOP = 15;

    public const int TYPE_ENEMY = 16;

    public const int TYPE_KIGUI = 17;

    public const int TYPE_FLAG = 18;

    public const int TYPE_OPTION = 19;

    public const int TYPE_ACCOUNT = 20;

    public const int TYPE_PET_MAIN = 21;

    public const int TYPE_AUTO = 22;

    public const int TYPE_GAMEINFO = 23;

    public const int TYPE_GAMEINFOSUB = 24;

    public const int TYPE_SPEACIALSKILL = 25;

    private int pointerDownTime;

    private int pointerDownFirstX;

    private int[] pointerDownLastX = new int[3];

    private bool pointerIsDowning;

    private bool isDownWhenRunning;

    private int waitToPerform;

    private int cmRun;

    private int keyTouchCombine = -1;

    private int keyTouchMapButton = -1;

    public int indexMouse = -1;

    private bool justRelease;

    private int keyTouchTab = -1;

    private int nTableItem;

    public string[][] clansOption = new string[2][]
    {
        mResources2.findClan,
        mResources2.createClan
    };

    public string clanInfo = string.Empty;

    public string clanReport = string.Empty;

    private bool isHaveClan;

    private Scroll2 scroll;

    private int cmvx;

    private int cmdx;

    private bool isSelectPlayerMenu;

    private string[] strStatus = new string[6]
    {
        mResources2.follow,
        mResources2.defend,
        mResources2.attack,
        mResources2.gohome,
        mResources2.fusion,
        mResources2.fusionForever
    };

    private static string log;

    private int tt;

    private int currentButtonPress;

    public static long[] t_tiemnang = new long[14]
    {
        50000000L, 250000000L, 1250000000L, 5000000000L, 15000000000L, 30000000000L, 45000000000L, 60000000000L, 75000000000L, 90000000000L,
        110000000000L, 130000000000L, 150000000000L, 170000000000L
    };

    private int[] zoneColor = new int[3] { 43520, 14743570, 14155776 };

    public string[] combineInfo;

    public string[] combineTopInfo;

    public static int[] color1 = new int[3] { 2327248, 8982199, 16713222 };

    public static int[] color2 = new int[3] { 4583423, 16719103, 16714764 };

    private int sellectInventory;

    private Item2 itemInvenNew;

    private Effect2_ eBanner;

    private static FrameImage2 screenTab6;

    private int compare;

    public static string strWantToBuy = string.Empty;

    public int xstart;

    public int ystart;

    public int popupW = 140;

    public int popupH = 160;

    public int cmySK;

    public int cmtoYSK;

    public int cmdySK;

    public int cmvySK;

    public int cmyLimSK;

    public int popupY;

    public int popupX;

    public int isborderIndex;

    public int isselectedRow;

    public int indexSize = 28;

    public int indexTitle;

    public int indexSelect;

    public int indexRow = -1;

    public int indexRowMax;

    public int indexMenu;

    public int columns = 6;

    public int rows;

    public int inforX;

    public int inforY;

    public int inforW;

    public int inforH;

    private int yPaint;

    private int xMap;

    private int yMap;

    private int xMapTask;

    private int yMapTask;

    private int xMove;

    private int yMove;

    public static bool isPaintMap = true;

    public bool isClose;

    private int infoSelect;

    public static MyVector2 vGameInfo = new MyVector2(string.Empty);

    public static string[] contenInfo;

    public bool isViewChatServer;

    private int currInfoItem;

    public Char2 charInfo;

    private bool isChangeZone;

    private bool isKiguiXu;

    private bool isKiguiLuong;

    private int delayKigui;

    public sbyte combineSuccess = -1;

    public int idNPC;

    public int xS;

    public int yS;

    private int rS;

    private int angleS;

    private int angleO;

    private int iAngleS;

    private int iDotS;

    private int speed;

    private int[] xArgS;

    private int[] yArgS;

    private int[] xDotS;

    private int[] yDotS;

    private int time;

    private int typeCombine;

    private int countUpdate;

    private int countR;

    private int countWait;

    private bool isSpeedCombine;

    private bool isCompleteEffCombine = true;

    private bool isPaintCombine;

    public bool isDoneCombine = true;

    public short iconID1;

    public short iconID2;

    public short iconID3;

    public short[] iconID;

    public string[][] speacialTabName;

    public static int[] sizeUpgradeEff = new int[3] { 2, 1, 1 };

    public static int nsize = 1;

    public const sbyte COLOR_WHITE = 0;

    public const sbyte COLOR_GREEN = 1;

    public const sbyte COLOR_PURPLE = 2;

    public const sbyte COLOR_ORANGE = 3;

    public const sbyte COLOR_BLUE = 4;

    public const sbyte COLOR_YELLOW = 5;

    public const sbyte COLOR_RED = 6;

    public const sbyte COLOR_BLACK = 7;

    public static int[][] colorUpgradeEffect = new int[7][]
    {
        new int[6] { 16777215, 15000805, 13487823, 11711155, 9671828, 7895160 },
        new int[6] { 61952, 58624, 52224, 45824, 39168, 32768 },
        new int[6] { 13500671, 12058853, 10682572, 9371827, 7995545, 6684800 },
        new int[6] { 16744192, 15037184, 13395456, 11753728, 10046464, 8404992 },
        new int[6] { 37119, 33509, 28108, 24499, 21145, 17536 },
        new int[6] { 16776192, 15063040, 12635136, 11776256, 10063872, 8290304 },
        new int[6] { 16711680, 15007744, 13369344, 11730944, 10027008, 8388608 }
    };

    public const int color_item_white = 15987701;

    public const int color_item_green = 2786816;

    public const int color_item_purple = 7078041;

    public const int color_item_orange = 12537346;

    public const int color_item_blue = 1269146;

    public const int color_item_yellow = 13279744;

    public const int color_item_red = 11599872;

    public const int color_item_black = 2039326;

    private Image2 imgo_0;

    private Image2 imgo_1;

    private Image2 imgo_2;

    private Image2 imgo_3;

    public const int numItem = 20;

    public const sbyte INVENTORY_TAB = 1;

    public sbyte size_tab;

    private bool isnewInventory;

    public Panel2()
    {
        init();
        cmdClose = new Command2(string.Empty, this, 1003, null);
        cmdClose.img = GameCanvas2.loadImage("/mainImage/myTexture2dbtX.png");
        cmdClose.cmdClosePanel = true;
        currItem = null;
    }

    public static void loadBg()
    {
        imgMap = GameCanvas2.loadImage("/img/map" + TileMap2.planetID + ".png");
        imgBantay = GameCanvas2.loadImage("/mainImage/myTexture2dbantay.png");
        imgX = GameCanvas2.loadImage("/mainImage/myTexture2dbtX.png");
        imgXu = GameCanvas2.loadImage("/mainImage/myTexture2dimgMoney.png");
        imgThoivang = GameCanvas2.loadImage("/mainImage/thoivang.png");
        imgLuong = GameCanvas2.loadImage("/mainImage/myTexture2dimgDiamond.png");
        imgLuongKhoa = GameCanvas2.loadImage("/mainImage/luongkhoa.png");
        imgUp = GameCanvas2.loadImage("/mainImage/myTexture2dup.png");
        imgDown = GameCanvas2.loadImage("/mainImage/myTexture2ddown.png");
        imgStar = GameCanvas2.loadImage("/mainImage/star.png");
        imgMaxStar = GameCanvas2.loadImage("/mainImage/starE.png");
        imgStar8 = GameCanvas2.loadImage("/mainImage/star8.png");
        imgNew = GameCanvas2.loadImage("/mainImage/new.png");
        imgTicket = GameCanvas2.loadImage("/mainImage/ticket12.png");
    }

    public void init()
    {
        pX = GameCanvas2.pxLast + cmxMap;
        pY = GameCanvas2.pyLast + cmyMap;
        lastTabIndex = new int[tabName.Length];
        for (int i = 0; i < lastTabIndex.Length; i++)
        {
            lastTabIndex[i] = -1;
        }
    }

    public int getXMap()
    {
        for (int i = 0; i < mapId[TileMap2.planetID].Length; i++)
        {
            if (TileMap2.mapID == mapId[TileMap2.planetID][i])
            {
                return mapX[TileMap2.planetID][i];
            }
        }
        return -1;
    }

    public int getYMap()
    {
        for (int i = 0; i < mapId[TileMap2.planetID].Length; i++)
        {
            if (TileMap2.mapID == mapId[TileMap2.planetID][i])
            {
                return mapY[TileMap2.planetID][i];
            }
        }
        return -1;
    }

    public int getXMapTask()
    {
        if (Char2.myCharz().taskMaint == null)
        {
            return -1;
        }
        for (int i = 0; i < mapId[TileMap2.planetID].Length; i++)
        {
            if (GameScr2.mapTasks[Char2.myCharz().taskMaint.index] == mapId[TileMap2.planetID][i])
            {
                return mapX[TileMap2.planetID][i];
            }
        }
        return -1;
    }

    public int getYMapTask()
    {
        if (Char2.myCharz().taskMaint == null)
        {
            return -1;
        }
        for (int i = 0; i < mapId[TileMap2.planetID].Length; i++)
        {
            if (GameScr2.mapTasks[Char2.myCharz().taskMaint.index] == mapId[TileMap2.planetID][i])
            {
                return mapY[TileMap2.planetID][i];
            }
        }
        return -1;
    }

    private void setType(int position)
    {
        typeShop = -1;
        W = WIDTH_PANEL;
        H = GameCanvas2.h;
        X = 0;
        Y = 0;
        ITEM_HEIGHT = 24;
        this.position = position;
        switch (position)
        {
            case 0:
                xScroll = 2;
                yScroll = 80;
                wScroll = W - 4;
                hScroll = H - 96;
                cmx = wScroll;
                cmtoX = 0;
                X = 0;
                break;
            case 1:
                wScroll = W - 4;
                xScroll = GameCanvas2.w - wScroll;
                yScroll = 80;
                hScroll = H - 96;
                X = xScroll - 2;
                cmx = -(GameCanvas2.w + W);
                cmtoX = GameCanvas2.w - W;
                break;
        }
        TAB_W = W / 5 - 1;
        currentTabIndex = 0;
        currentTabName = tabName[type];
        if (currentTabName.Length < 5)
        {
            TAB_W += 5;
        }
        startTabPos = xScroll + wScroll / 2 - currentTabName.Length * TAB_W / 2;
        lastSelect = new int[currentTabName.Length];
        cmyLast = new int[currentTabName.Length];
        for (int i = 0; i < currentTabName.Length; i++)
        {
            lastSelect[i] = (GameCanvas2.isTouch ? (-1) : 0);
        }
        if (lastTabIndex[type] != -1)
        {
            currentTabIndex = lastTabIndex[type];
        }
        if (currentTabIndex < 0)
        {
            currentTabIndex = 0;
        }
        if (currentTabIndex > currentTabName.Length - 1)
        {
            currentTabIndex = currentTabName.Length - 1;
        }
        scroll = null;
    }

    public void setTypeMapTrans()
    {
        type = 14;
        setType(0);
        setTabMapTrans();
        cmx = (cmtoX = 0);
    }

    public void setTypeInfomatioin()
    {
        type = 6;
        cmx = wScroll;
        cmtoX = 0;
    }

    public void setTypeMap()
    {
        if (!GameScr2.gI().isMapFize() && isPaintMap)
        {
            if (Hint2.isOnTask(2, 0))
            {
                Hint2.isViewMap = true;
                GameScr2.info1.addInfo(mResources2.go_to_quest, 0);
            }
            if (Hint2.isOnTask(3, 0))
            {
                Hint2.isViewPotential = true;
            }
            type = 4;
            currentTabName = tabName[type];
            startTabPos = xScroll + wScroll / 2 - currentTabName.Length * TAB_W / 2;
            cmx = (cmtoX = 0);
            setTabMap();
        }
    }

    public void setTypeArchivement()
    {
        currentListLength = Char2.myCharz().arrArchive.Length;
        setType(0);
        type = 9;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = 0);
        }
        selected = (GameCanvas2.isTouch ? (-1) : 0);
    }

    public void setTypeKiGuiOnly()
    {
        type = 17;
        setType(1);
        setTabKiGui();
        typeShop = 2;
        currentTabIndex = 0;
    }

    public void setTabChatManager()
    {
        currentListLength = chats.Count;
        ITEM_HEIGHT = 24;
        selected = (GameCanvas2.isTouch ? (-1) : 0);
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
    }

    public void setTabChatPlayer()
    {
    }

    public void setTypeChatPlayer()
    {
    }

    public void setTabKiGui()
    {
        ITEM_HEIGHT = 24;
        currentListLength = Char2.myCharz().arrItemShop[4].Length;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        selected = (GameCanvas2.isTouch ? (-1) : 0);
    }

    public void setTypeBodyOnly()
    {
        type = 7;
        setType(1);
        setTabInventory(resetSelect: true);
        currentTabIndex = 0;
    }

    public void addChatMessage(InfoItem2 info)
    {
        logChat.insertElementAt(info, 0);
        if (logChat.size() > 20)
        {
            logChat.removeElementAt(logChat.size() - 1);
        }
    }

    private bool IsNewMessage(string name)
    {
        return false;
    }

    public bool IsHaveNewMessage()
    {
        return false;
    }

    private void ClearNewMessage(string name)
    {
    }

    public void addPlayerMenu(Command2 pm)
    {
        vPlayerMenu.addElement(pm);
    }

    public void setTabPlayerMenu()
    {
        ITEM_HEIGHT = 24;
        currentListLength = vPlayerMenu.size();
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        selected = (GameCanvas2.isTouch ? (-1) : 0);
    }

    public void setTypeFlag()
    {
        type = 18;
        setType(0);
        ITEM_HEIGHT = 24;
        selected = (GameCanvas2.isTouch ? (-1) : 0);
        setTabFlag();
    }

    public void setTabFlag()
    {
        currentListLength = vFlag.size();
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        if (selected > currentListLength - 1)
        {
            selected = currentListLength - 1;
        }
        cmx = (cmtoX = 0);
    }

    public void setTypePlayerMenu(Char2 c)
    {
        type = 10;
        setType(0);
        setTabPlayerMenu();
        charMenu = c;
    }

    public void setTypeFriend()
    {
        type = 11;
        setType(0);
        ITEM_HEIGHT = 24;
        selected = (GameCanvas2.isTouch ? (-1) : 0);
        setTabFriend();
    }

    public void setTypeEnemy()
    {
        type = 16;
        setType(0);
        ITEM_HEIGHT = 24;
        selected = (GameCanvas2.isTouch ? (-1) : 0);
        setTabEnemy();
    }

    public void setTypeTop(sbyte t)
    {
        type = 15;
        setType(0);
        ITEM_HEIGHT = 24;
        selected = (GameCanvas2.isTouch ? (-1) : 0);
        setTabTop();
        isThachDau = t != 0;
    }

    public void setTabTop()
    {
        currentListLength = vTop.size();
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        if (selected > currentListLength - 1)
        {
            selected = currentListLength - 1;
        }
        cmx = (cmtoX = 0);
    }

    public void setTabFriend()
    {
        currentListLength = vFriend.size();
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        if (selected > currentListLength - 1)
        {
            selected = currentListLength - 1;
        }
        cmx = (cmtoX = 0);
    }

    public void setTabEnemy()
    {
        currentListLength = vEnemy.size();
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        if (selected > currentListLength - 1)
        {
            selected = currentListLength - 1;
        }
        cmx = (cmtoX = 0);
    }

    public void setTypeMessage()
    {
        type = 8;
        setType(0);
        setTabMessage();
        currentTabIndex = 0;
    }

    public void setTypeShop(int typeShop)
    {
        type = 1;
        setType(0);
        setTabShop();
        currentTabIndex = 0;
        this.typeShop = typeShop;
    }

    public void setTypeBox()
    {
        type = 2;
        if (GameCanvas2.w > 2 * WIDTH_PANEL)
        {
            boxTabName = new string[1][] { mResources2.chestt };
        }
        else
        {
            boxTabName = new string[2][]
            {
                mResources2.chestt,
                mResources2.inventory
            };
        }
        tabName[2] = boxTabName;
        setType(0);
        if (currentTabIndex == 0)
        {
            setTabBox();
        }
        if (currentTabIndex == 1)
        {
            setTabInventory(resetSelect: true);
        }
        if (GameCanvas2.w > 2 * WIDTH_PANEL)
        {
            GameCanvas2.panel2 = new Panel2();
            GameCanvas2.panel2.tabName[7] = new string[1][] { new string[1] { string.Empty } };
            GameCanvas2.panel2.setTypeBodyOnly();
            GameCanvas2.panel2.show();
        }
    }

    public void setTypeCombine()
    {
        type = 12;
        if (GameCanvas2.w > 2 * WIDTH_PANEL)
        {
            boxCombine = new string[1][] { mResources2.combine };
        }
        else
        {
            boxCombine = new string[2][]
            {
                mResources2.combine,
                mResources2.inventory
            };
        }
        tabName[type] = boxCombine;
        setType(0);
        if (currentTabIndex == 0)
        {
            setTabCombine();
        }
        if (currentTabIndex == 1)
        {
            setTabInventory(resetSelect: true);
        }
        if (GameCanvas2.w > 2 * WIDTH_PANEL)
        {
            GameCanvas2.panel2 = new Panel2();
            GameCanvas2.panel2.tabName[7] = new string[1][] { new string[1] { string.Empty } };
            GameCanvas2.panel2.setTypeBodyOnly();
            GameCanvas2.panel2.show();
        }
        combineSuccess = -1;
        isDoneCombine = true;
    }

    public void setTabCombine()
    {
        currentListLength = vItemCombine.size() + 1;
        ITEM_HEIGHT = 24;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 9;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        selected = (GameCanvas2.isTouch ? (-1) : 0);
    }

    public void setTypeAuto()
    {
        type = 22;
        setType(0);
        setTabAuto();
        cmx = (cmtoX = 0);
    }

    private void setTabAuto()
    {
        currentListLength = strAuto.Length;
        ITEM_HEIGHT = 24;
        selected = (GameCanvas2.isTouch ? (-1) : 0);
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
    }

    public void setTypePetMain()
    {
        type = 21;
        if (GameCanvas2.panel2 != null)
        {
            boxPet = mResources2.petMainTab2;
        }
        else
        {
            boxPet = mResources2.petMainTab;
        }
        tabName[21] = boxPet;
        if (Char2.myCharz().cgender == 1)
        {
            strStatus = new string[6]
            {
                mResources2.follow,
                mResources2.defend,
                mResources2.attack,
                mResources2.gohome,
                mResources2.fusion,
                mResources2.fusionForever
            };
        }
        else
        {
            strStatus = new string[5]
            {
                mResources2.follow,
                mResources2.defend,
                mResources2.attack,
                mResources2.gohome,
                mResources2.fusion
            };
        }
        setType(2);
        if (currentTabIndex == 0)
        {
            setTabPetInventory(false);
        }
        else if (currentTabIndex == 1)
        {
            setTabPetSkill(false);
        }
        else if (currentTabIndex == 2)
        {
            setTabPetStatus();
        }
        else if (currentTabIndex == 3)
        {
            setTabInventory(resetSelect: true);
        }
    }

    public void setTypePet2Main()
    {
        type = 28;
        if (GameCanvas2.panel2 != null)
        {
            boxPet = mResources2.petMainTab2;
        }
        else
        {
            boxPet = mResources2.petMainTab;
        }
        tabName[28] = boxPet;
        if (Char2.myCharz().cgender == 1)
        {
            strStatus = new string[6]
            {
                mResources2.follow,
                mResources2.defend,
                mResources2.attack,
                mResources2.gohome,
                mResources2.fusion,
                mResources2.fusionForever
            };
        }
        else
        {
            strStatus = new string[5]
            {
                mResources2.follow,
                mResources2.defend,
                mResources2.attack,
                mResources2.gohome,
                mResources2.fusion
            };
        }
        setType(2);
        if (currentTabIndex == 0)
        {
            setTabPetInventory(true);
        }
        else if (currentTabIndex == 1)
        {
            setTabPetSkill(true);
        }
        else if (currentTabIndex == 2)
        {
            setTabPetStatus();
        }
        else if (currentTabIndex == 3)
        {
            setTabInventory(resetSelect: true);
        }
    }

    public void setTypeMain()
    {
        type = 0;
        setType(0);
        if (currentTabIndex == 1)
        {
            setTabInventory(resetSelect: true);
        }
        if (currentTabIndex == 2)
        {
            setTabSkill();
        }
        if (currentTabIndex == 3)
        {
            if (mainTabName.Length == 4)
            {
                setTabTool();
            }
            else
            {
                setTabClans();
            }
        }
        if (currentTabIndex == 4)
        {
            setTabTool();
        }
    }

    public void setTypeZone()
    {
        type = 3;
        setType(0);
        setTabZone();
        cmx = (cmtoX = 0);
    }

    public void addItemDetail(Item2 item)
    {
        try
        {
            cp = new ChatPopup2();
            string empty = string.Empty;
            string text = string.Empty;
            if (item.template.gender != Char2.myCharz().cgender)
            {
                if (item.template.gender == 0)
                {
                    text = text + "\n|7|1|" + mResources2.from_earth;
                }
                else if (item.template.gender == 1)
                {
                    text = text + "\n|7|1|" + mResources2.from_namec;
                }
                else if (item.template.gender == 2)
                {
                    text = text + "\n|7|1|" + mResources2.from_sayda;
                }
            }
            string text2 = string.Empty;
            if (item.itemOption != null)
            {
                for (int i = 0; i < item.itemOption.Length; i++)
                {
                    if (item.itemOption[i].optionTemplate.id == 72)
                    {
                        text2 = " [+" + item.itemOption[i].param + "]";
                    }
                }
            }
            bool flag = false;
            if (item.itemOption != null)
            {
                for (int j = 0; j < item.itemOption.Length; j++)
                {
                    if (item.itemOption[j].optionTemplate.id == 41)
                    {
                        flag = true;
                        if (item.itemOption[j].param == 1)
                        {
                            text = text + "|0|1|" + item.template.name + text2;
                        }
                        if (item.itemOption[j].param == 2)
                        {
                            text = text + "|2|1|" + item.template.name + text2;
                        }
                        if (item.itemOption[j].param == 3)
                        {
                            text = text + "|8|1|" + item.template.name + text2;
                        }
                        if (item.itemOption[j].param == 4)
                        {
                            text = text + "|7|1|" + item.template.name + text2;
                        }
                    }
                }
            }
            if (!flag)
            {
                text = text + "|0|1|" + item.template.name + text2;
            }
            if (item.itemOption != null)
            {
                for (int k = 0; k < item.itemOption.Length; k++)
                {
                    if (item.itemOption[k].optionTemplate.name.StartsWith("$") ? true : false)
                    {
                        empty = item.itemOption[k].getOptiongColor();
                        if (item.itemOption[k].param == 1)
                        {
                            text = text + "\n|1|1|" + empty;
                        }
                        if (item.itemOption[k].param == 0)
                        {
                            text = text + "\n|0|1|" + empty;
                        }
                        continue;
                    }
                    empty = item.itemOption[k].getOptionString();
                    if (!empty.Equals(string.Empty) && item.itemOption[k].optionTemplate.id != 72)
                    {
                        if (item.itemOption[k].optionTemplate.id == 102)
                        {
                            cp.starSlot = (sbyte)item.itemOption[k].param;
                            Res2.outz("STAR SLOT= " + cp.starSlot);
                        }
                        else if (item.itemOption[k].optionTemplate.id == 107)
                        {
                            cp.maxStarSlot = (sbyte)item.itemOption[k].param;
                            Res2.outz("STAR SLOT= " + cp.maxStarSlot);
                        }
                        else
                        {
                            text = text + "\n|1|1|" + empty;
                        }
                    }
                }
            }
            if (currItem.template.strRequire > 1)
            {
                string text3 = mResources2.pow_request + ": " + currItem.template.strRequire;
                if (currItem.template.strRequire > Char2.myCharz().cPower)
                {
                    text = text + "\n|3|1|" + text3;
                    string text4 = text;
                    text = text4 + "\n|3|1|" + mResources2.your_pow + ": " + Char2.myCharz().cPower;
                }
                else
                {
                    text = text + "\n|6|1|" + text3;
                }
            }
            else
            {
                text += "\n|6|1|";
            }
            currItem.compare = getCompare(currItem);
            text += "\n--";
            text = text + "\n|6|" + item.template.description;
            if (!item.reason.Equals(string.Empty))
            {
                if (!item.template.description.Equals(string.Empty))
                {
                    text += "\n--";
                }
                text = text + "\n|2|" + item.reason;
            }
            if (cp.maxStarSlot > 0)
            {
                text += "\n\n";
            }
            popUpDetailInit(cp, text);
            idIcon = item.template.iconID;
            partID = null;
            charInfo = null;
        }
        catch (Exception ex)
        {
            Res2.outz("ex " + ex.StackTrace);
        }
    }

    public void popUpDetailInit(ChatPopup2 cp, string chat)
    {
        cp.isClip = false;
        cp.sayWidth = 180;
        cp.cx = 3 + X - ((X != 0) ? (Res2.abs(cp.sayWidth - W) + 8) : 0);
        cp.says = mFont2.tahoma_7_red.splitFontArray(chat, cp.sayWidth - 10);
        cp.delay = 10000000;
        cp.c = null;
        cp.sayRun = 7;
        cp.ch = 15 - cp.sayRun + cp.says.Length * 12 + 10;
        if (cp.ch > GameCanvas2.h - 80)
        {
            cp.ch = GameCanvas2.h - 80;
            cp.lim = cp.says.Length * 12 - cp.ch + 17;
            if (cp.lim < 0)
            {
                cp.lim = 0;
            }
            ChatPopup2.cmyText = 0;
            cp.isClip = true;
        }
        cp.cy = GameCanvas2.menu.menuY - cp.ch;
        while (cp.cy < 10)
        {
            cp.cy++;
            GameCanvas2.menu.menuY++;
        }
        cp.mH = 0;
        cp.strY = 10;
    }

    public void popUpDetailInitArray(ChatPopup2 cp, string[] chat)
    {
        cp.sayWidth = 160;
        cp.cx = 3 + X;
        cp.says = chat;
        cp.delay = 10000000;
        cp.c = null;
        cp.sayRun = 7;
        cp.ch = 15 - cp.sayRun + cp.says.Length * 12 + 10;
        cp.cy = GameCanvas2.menu.menuY - cp.ch;
        cp.mH = 0;
        cp.strY = 10;
    }

    public void addMessageDetail(ClanMessage2 cm)
    {
        cp = new ChatPopup2();
        string text = "|0|" + cm.playerName;
        text = text + "\n|1|" + Member2.getRole(cm.role);
        for (int i = 0; i < myMember.size(); i++)
        {
            Member2 member = (Member2)myMember.elementAt(i);
            if (cm.playerId == member.ID)
            {
                string text2 = text;
                text = text2 + "\n|5|" + mResources2.clan_capsuledonate + ": " + member.clanPoint;
                text2 = text;
                text = text2 + "\n|5|" + mResources2.clan_capsuleself + ": " + member.curClanPoint;
                text2 = text;
                text = text2 + "\n|4|" + mResources2.give_pea + ": " + member.donate + mResources2.time;
                text2 = text;
                text = text2 + "\n|4|" + mResources2.receive_pea + ": " + member.receive_donate + mResources2.time;
                partID = new int[3] { member.head, member.leg, member.body };
                break;
            }
        }
        text += "\n--";
        for (int j = 0; j < cm.chat.Length; j++)
        {
            text = text + "\n" + cm.chat[j];
        }
        if (cm.type == 1)
        {
            string text2 = text;
            text = text2 + "\n|6|" + mResources2.received + " " + cm.recieve + "/" + cm.maxCap;
        }
        popUpDetailInit(cp, text);
        charInfo = null;
    }

    public void addThachDauDetail(TopInfo2 t)
    {
        string text = "|0|1|" + t.name;
        text = text + "\n|1|Top " + t.rank;
        text = text + "\n|1|" + t.info;
        text = text + "\n|2|" + t.info2;
        cp = new ChatPopup2();
        popUpDetailInit(cp, text);
        partID = new int[3] { t.headID, t.leg, t.body };
        currItem = null;
        charInfo = null;
    }

    public void addClanMemberDetail(Member2 m)
    {
        string text = "|0|1|" + m.name;
        string text2 = "\n|2|1|";
        if (m.role == 0)
        {
            text2 = "\n|7|1|";
        }
        if (m.role == 1)
        {
            text2 = "\n|1|1|";
        }
        if (m.role == 2)
        {
            text2 = "\n|0|1|";
        }
        text = text + text2 + Member2.getRole(m.role);
        string text3 = text;
        text = text3 + "\n|2|1|" + mResources2.power + ": " + m.powerPoint;
        text += "\n--";
        text3 = text;
        text = text3 + "\n|5|" + mResources2.clan_capsuledonate + ": " + m.clanPoint;
        text3 = text;
        text = text3 + "\n|5|" + mResources2.clan_capsuleself + ": " + m.curClanPoint;
        text3 = text;
        text = text3 + "\n|4|" + mResources2.give_pea + ": " + m.donate + mResources2.time;
        text3 = text;
        text = text3 + "\n|4|" + mResources2.receive_pea + ": " + m.receive_donate + mResources2.time;
        text3 = text;
        text = text3 + "\n|6|" + mResources2.join_date + ": " + m.joinTime;
        cp = new ChatPopup2();
        popUpDetailInit(cp, text);
        partID = new int[3] { m.head, m.leg, m.body };
        currItem = null;
        charInfo = null;
    }

    public void addClanDetail(Clan2 cl)
    {
        try
        {
            string text = "|0|" + cl.name;
            string[] array = mFont2.tahoma_7_green.splitFontArray(cl.slogan, wScroll - 60);
            for (int i = 0; i < array.Length; i++)
            {
                text = text + "\n|2|" + array[i];
            }
            text += "\n--";
            string text2 = text;
            text = text2 + "\n|7|" + mResources2.clan_leader + ": " + cl.leaderName;
            text2 = text;
            text = text2 + "\n|1|" + mResources2.power_point + ": " + cl.powerPoint;
            text2 = text;
            text = text2 + "\n|4|" + mResources2.member + ": " + cl.currMember + "/" + cl.maxMember;
            text2 = text;
            text = text2 + "\n|4|" + mResources2.level + ": " + cl.level;
            text2 = text;
            text = text2 + "\n|4|" + mResources2.clan_birthday + ": " + NinjaUtil2.getDate(cl.date);
            cp = new ChatPopup2();
            popUpDetailInit(cp, text);
            idIcon = ClanImage2.getClanImage((short)cl.imgID).idImage[0];
            currItem = null;
        }
        catch (Exception ex)
        {
            Res2.outz("Throw  exception " + ex.StackTrace);
        }
    }

    public void addSkillDetail(SkillTemplate2 tp, Skill2 skill, Skill2 nextSkill)
    {
        string text = "|0|" + tp.name;
        for (int i = 0; i < tp.description.Length; i++)
        {
            text = text + "\n|4|" + tp.description[i];
        }
        text += "\n--";
        if (skill != null)
        {
            string text2 = text;
            text = text2 + "\n|2|" + mResources2.cap_do + ": " + skill.point;
            text = text + "\n|5|" + NinjaUtil2.Replace(tp.damInfo, "#", skill.damage + string.Empty);
            text2 = text;
            text = text2 + "\n|5|" + mResources2.KI_consume + skill.manaUse + ((tp.manaUseType != 1) ? string.Empty : "%");
            text2 = text;
            text = text2 + "\n|5|" + mResources2.cooldown + ": " + skill.strTimeReplay() + "s";
            text += "\n--";
            if (skill.point == tp.maxPoint)
            {
                text = text + "\n|0|" + mResources2.max_level_reach;
            }
            else
            {
                if (!skill.template.isSkillSpec())
                {
                    text2 = text;
                    text = text2 + "\n|1|" + mResources2.next_level_require + Res2.formatNumber(nextSkill.powRequire) + " " + mResources2.potential;
                }
                text = text + "\n|4|" + NinjaUtil2.Replace(tp.damInfo, "#", nextSkill.damage + string.Empty);
            }
        }
        else
        {
            text = text + "\n|2|" + mResources2.not_learn;
            string text2 = text;
            text = text2 + "\n|1|" + mResources2.learn_require + Res2.formatNumber(nextSkill.powRequire) + " " + mResources2.potential;
            text = text + "\n|4|" + NinjaUtil2.Replace(tp.damInfo, "#", nextSkill.damage + string.Empty);
            text2 = text;
            text = text2 + "\n|4|" + mResources2.KI_consume + nextSkill.manaUse + ((tp.manaUseType != 1) ? string.Empty : "%");
            text2 = text;
            text = text2 + "\n|4|" + mResources2.cooldown + ": " + nextSkill.strTimeReplay() + "s";
        }
        currItem = null;
        partID = null;
        charInfo = null;
        cp = new ChatPopup2();
        popUpDetailInit(cp, text);
        idIcon = 0;
    }

    public void show()
    {
        if (GameCanvas2.isTouch)
        {
            cmdClose.x = 156;
            cmdClose.y = 3;
        }
        else
        {
            cmdClose.x = GameCanvas2.w - 19;
            cmdClose.y = GameCanvas2.h - 19;
        }
        cmdClose.isPlaySoundButton = false;
        ChatPopup2.currChatPopup = null;
        InfoDlg2.hide();
        timeShow = 20;
        isShow = true;
        isClose = false;
        SoundMn2.gI().panelOpen();
        if (isTypeShop())
        {
            Char2.myCharz().setPartOld();
        }
    }

    public void chatTFUpdateKey()
    {
        if (chatTField != null && chatTField.isShow)
        {
            if (chatTField.left != null && (GameCanvas2.keyPressed[12] || mScreen2.getCmdPointerLast(chatTField.left)) && chatTField.left != null)
            {
                chatTField.left.performAction();
            }
            if (chatTField.right != null && (GameCanvas2.keyPressed[13] || mScreen2.getCmdPointerLast(chatTField.right)) && chatTField.right != null)
            {
                chatTField.right.performAction();
            }
            if (chatTField.center != null && (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] || mScreen2.getCmdPointerLast(chatTField.center)) && chatTField.center != null)
            {
                chatTField.center.performAction();
            }
            if (chatTField.isShow && GameCanvas2.keyAsciiPress != 0)
            {
                chatTField.keyPressed(GameCanvas2.keyAsciiPress);
                GameCanvas2.keyAsciiPress = 0;
            }
            GameCanvas2.clearKeyHold();
            GameCanvas2.clearKeyPressed();
        }
    }

    public void updateKey()
    {
        if ((chatTField != null && chatTField.isShow) || !GameCanvas2.panel.isDoneCombine || InfoDlg2.isShow)
        {
            return;
        }
        if (tabIcon != null && tabIcon.isShow)
        {
            tabIcon.updateKey();
        }
        else
        {
            if (isClose || !isShow)
            {
                return;
            }
            if (cmdClose.isPointerPressInside())
            {
                cmdClose.performAction();
                return;
            }
            if (GameCanvas2.keyPressed[13])
            {
                if (type != 4)
                {
                    hide();
                    return;
                }
                setTypeMain();
                cmx = (cmtoX = 0);
            }
            if (GameCanvas2.keyPressed[12] || GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25])
            {
                if (left.idAction > 0)
                {
                    perform(left.idAction, left.p);
                }
                else
                {
                    waitToPerform = 2;
                }
            }
            if (Equals(GameCanvas2.panel) && GameCanvas2.panel2 == null
                && GameCanvas2.isPointerJustRelease
                && !GameCanvas2.isPointer(X, Y, W, H)
                && !pointerIsDowning)
            {
                if (GameCanvas2.isPointer((GameCanvas2.w - MainMod2.logoW) / 2, 5, MainMod2.logoW, MainMod2.logoH))
                {
                    MainMod2.GI().OpenMenu();
                    SoundMn2.gI().buttonClick();
                    GameCanvas2.clearAllPointerEvent();
                }
                else
                {
                    hide();
                }
                return;
            }
            if (!isClanOption)
            {
                updateKeyInTabBar();
            }
            switch (type)
            {
                case 3:
                case 8:
                case 9:
                case 10:
                case 11:
                case 14:
                case 15:
                case 16:
                case 18:
                case 23:
                case 24:
                case 26:
                case 27:
                    updateKeyScrollView();
                    break;
                case 21:
                case 28:
                    if (currentTabIndex == 0 || currentTabIndex == 2)
                    {
                        updateKeyScrollView();
                    }
                    else if (currentTabIndex == 1)
                    {
                        updateKeyPetStatus();
                    }
                    break;
                case 0:
                    if (currentTabIndex == 0)
                    {
                        updateKeyQuest();
                        GameCanvas2.clearKeyPressed();
                        return;
                    }
                    if (currentTabIndex == 1)
                    {
                        updateKeyInventory();
                    }
                    if (currentTabIndex == 2)
                    {
                        updateKeySkill();
                    }
                    if (currentTabIndex == 3)
                    {
                        if (mainTabName.Length == 4)
                        {
                            updateKeyTool();
                        }
                        else
                        {
                            updateKeyClans();
                        }
                    }
                    if (currentTabIndex == 4)
                    {
                        updateKeyTool();
                    }
                    break;
                case 2:
                    updateKeyInventory();
                    break;
                case 1:
                case 17:
                case 25:
                    if (currentTabIndex < currentTabName.Length - ((GameCanvas2.panel2 == null) ? 1 : 0) && type != 17)
                    {
                        updateKeyScrollView();
                    }
                    else if (typeShop == 0)
                    {
                        updateKeyInventory();
                    }
                    else
                    {
                        updateKeyScrollView();
                    }
                    break;
                case 4:
                    updateKeyMap();
                    GameCanvas2.clearKeyPressed();
                    return;
                case 7:
                    updateKeyInventory();
                    break;
                case 12:
                    updateKeyCombine();
                    break;
                case 13:
                    updateKeyGiaoDich();
                    break;
                case 19:
                    updateKeyOption();
                    break;
                case 20:
                    updateKeyOption();
                    break;
                case 22:
                    updateKeyAuto();
                    break;
            }
            GameCanvas2.clearKeyHold();
            for (int i = 0; i < GameCanvas2.keyPressed.Length; i++)
            {
                GameCanvas2.keyPressed[i] = false;
            }
        }
    }

    private void updateKeyAuto()
    {
    }

    private void updateKeyPetStatus()
    {
        updateKeyScrollView();
    }

    private void updateKeyPetSkill()
    {
    }

    private void keyGiaodich()
    {
        updateKeyScrollView();
    }

    private void updateKeyGiaoDich()
    {
        if (currentTabIndex == 0)
        {
            if (Equals(GameCanvas2.panel))
            {
                updateKeyInventory();
            }
            if (Equals(GameCanvas2.panel2))
            {
                keyGiaodich();
            }
        }
        if (currentTabIndex == 1 || currentTabIndex == 2)
        {
            keyGiaodich();
        }
    }

    private void updateKeyTool()
    {
        updateKeyScrollView();
    }

    private void updateKeySkill()
    {
        updateKeyScrollView();
    }

    private void updateKeyClanIcon()
    {
        updateKeyScrollView();
    }

    public void setTabGiaoDich(bool isMe)
    {
        currentListLength = ((!isMe) ? (vFriendGD.size() + 3) : (vMyGD.size() + 3));
        ITEM_HEIGHT = 24;
        selected = (GameCanvas2.isTouch ? (-1) : 0);
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
    }

    public void setTypeGiaoDich(Char2 cGD)
    {
        type = 13;
        tabName[type] = boxGD;
        isAccept = false;
        isLock = false;
        isFriendLock = false;
        vMyGD.removeAllElements();
        vFriendGD.removeAllElements();
        moneyGD = 0;
        friendMoneyGD = 0;
        if (GameCanvas2.w > 2 * WIDTH_PANEL)
        {
            GameCanvas2.panel2 = new Panel2();
            GameCanvas2.panel2.type = 13;
            GameCanvas2.panel2.tabName[type] = new string[1][] { mResources2.item_receive };
            GameCanvas2.panel2.setType(1);
            GameCanvas2.panel2.setTabGiaoDich(isMe: false);
            GameCanvas2.panel.tabName[type] = new string[2][]
            {
                mResources2.inventory,
                mResources2.item_give
            };
            GameCanvas2.panel2.show();
            GameCanvas2.panel2.charMenu = cGD;
        }
        if (Equals(GameCanvas2.panel))
        {
            setType(0);
        }
        if (currentTabIndex == 0)
        {
            setTabInventory(resetSelect: true);
        }
        if (currentTabIndex == 1)
        {
            setTabGiaoDich(isMe: true);
        }
        if (currentTabIndex == 2)
        {
            setTabGiaoDich(isMe: false);
        }
        charMenu = cGD;
    }

    private void paintGiaoDich(mGraphics2 g, bool isMe)
    {
        g.setColor(16711680);
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        MyVector2 myVector = ((!isMe) ? vFriendGD : vMyGD);
        for (int i = 0; i < currentListLength; i++)
        {
            int num = xScroll + 36;
            int num2 = yScroll + i * ITEM_HEIGHT;
            int num3 = wScroll - 36;
            int num4 = ITEM_HEIGHT - 1;
            int num5 = xScroll;
            int num6 = yScroll + i * ITEM_HEIGHT;
            int num7 = 34;
            int num8 = ITEM_HEIGHT - 1;
            if (num2 - cmy > yScroll + hScroll || num2 - cmy < yScroll - ITEM_HEIGHT)
            {
                continue;
            }
            if (i == currentListLength - 1)
            {
                if (!isMe)
                {
                    continue;
                }
                g.setColor(15196114);
                g.fillRect(num5, num2, wScroll, num4);
                if (!isLock)
                {
                    if (!isFriendLock)
                    {
                        global::mFont2.tahoma_7_grey.drawString(g, mResources2.opponent + mResources2.not_lock_trade, xScroll + wScroll / 2, num2 + num4 / 2 - 4, global::mFont2.CENTER);
                    }
                    else
                    {
                        global::mFont2.tahoma_7_grey.drawString(g, mResources2.opponent + mResources2.locked_trade, xScroll + wScroll / 2, num2 + num4 / 2 - 4, global::mFont2.CENTER);
                    }
                }
                else if (isFriendLock)
                {
                    g.setColor(15196114);
                    g.fillRect(num5, num2, wScroll, num4);
                    g.drawImage((i != selected) ? GameScr2.imgLbtn2 : GameScr2.imgLbtnFocus2, xScroll + wScroll - 5, num2 + 2, StaticObj2.TOP_RIGHT);
                    ((i != selected) ? global::mFont2.tahoma_7b_dark : global::mFont2.tahoma_7b_green2).drawString(g, mResources2.done, xScroll + wScroll - 22, num2 + 7, 2);
                    global::mFont2.tahoma_7_grey.drawString(g, mResources2.opponent + mResources2.locked_trade, xScroll + 5, num2 + num4 / 2 - 4, global::mFont2.LEFT);
                }
                else
                {
                    global::mFont2.tahoma_7_grey.drawString(g, mResources2.opponent + mResources2.not_lock_trade, xScroll + wScroll / 2, num2 + num4 / 2 - 4, global::mFont2.CENTER);
                }
                continue;
            }
            if (i == currentListLength - 2)
            {
                if (isMe)
                {
                    g.setColor(15196114);
                    g.fillRect(num5, num2, wScroll, num4);
                    if (!isAccept)
                    {
                        if (!isLock)
                        {
                            g.drawImage((i != selected) ? GameScr2.imgLbtn2 : GameScr2.imgLbtnFocus2, xScroll + wScroll - 5, num2 + 2, StaticObj2.TOP_RIGHT);
                            ((i != selected) ? global::mFont2.tahoma_7b_dark : global::mFont2.tahoma_7b_green2).drawString(g, mResources2.mlock, xScroll + wScroll - 22, num2 + 7, 2);
                            global::mFont2.tahoma_7_grey.drawString(g, mResources2.you + mResources2.not_lock_trade, xScroll + 5, num2 + num4 / 2 - 4, global::mFont2.LEFT);
                        }
                        else
                        {
                            g.drawImage((i != selected) ? GameScr2.imgLbtn2 : GameScr2.imgLbtnFocus2, xScroll + wScroll - 5, num2 + 2, StaticObj2.TOP_RIGHT);
                            ((i != selected) ? global::mFont2.tahoma_7b_dark : global::mFont2.tahoma_7b_green2).drawString(g, mResources2.CANCEL, xScroll + wScroll - 22, num2 + 7, 2);
                            global::mFont2.tahoma_7_grey.drawString(g, mResources2.you + mResources2.locked_trade, xScroll + 5, num2 + num4 / 2 - 4, global::mFont2.LEFT);
                        }
                    }
                }
                else if (!isFriendLock)
                {
                    global::mFont2.tahoma_7b_dark.drawString(g, mResources2.not_lock_trade_upper, xScroll + wScroll / 2, num2 + num4 / 2 - 4, global::mFont2.CENTER);
                }
                else
                {
                    global::mFont2.tahoma_7b_dark.drawString(g, mResources2.locked_trade_upper, xScroll + wScroll / 2, num2 + num4 / 2 - 4, global::mFont2.CENTER);
                }
                continue;
            }
            if (i == currentListLength - 3)
            {
                if (isLock)
                {
                    g.setColor(13748667);
                }
                else
                {
                    g.setColor((i != selected) ? 15196114 : 16383818);
                }
                g.fillRect(num, num2, num3, num4);
                if (isLock)
                {
                    g.setColor(13748667);
                }
                else
                {
                    g.setColor((i != selected) ? 9993045 : 7300181);
                }
                g.fillRect(num5, num6, num7, num8);
                g.drawImage(imgXu, num5 + num7 / 2, num6 + num8 / 2, 3);
                global::mFont2.tahoma_7_green2.drawString(g, NinjaUtil2.getMoneys((!isMe) ? friendMoneyGD : moneyGD) + " " + mResources2.XU, num + 5, num2 + 11, 0);
                global::mFont2.tahoma_7_green.drawString(g, mResources2.money_trade, num + 5, num2, 0);
                continue;
            }
            if (myVector.size() == 0)
            {
                return;
            }
            if (isLock)
            {
                g.setColor(13748667);
            }
            else
            {
                g.setColor((i != selected) ? 15196114 : 16383818);
            }
            g.fillRect(num, num2, num3, num4);
            if (isLock)
            {
                g.setColor(13748667);
            }
            else
            {
                g.setColor((i != selected) ? 9993045 : 9541120);
            }
            Item2 item = (Item2)myVector.elementAt(i);
            if (item != null)
            {
                for (int j = 0; j < item.itemOption.Length; j++)
                {
                    if (item.itemOption[j].optionTemplate.id != 72 || item.itemOption[j].param <= 0)
                    {
                        continue;
                    }
                    sbyte color_Item_Upgrade = GetColor_Item_Upgrade(item.itemOption[j].param);
                    int color_ItemBg = GetColor_ItemBg(color_Item_Upgrade);
                    if (color_ItemBg != -1)
                    {
                        if (isLock)
                        {
                            g.setColor(13748667);
                        }
                        else
                        {
                            g.setColor((i != selected) ? GetColor_ItemBg(color_Item_Upgrade) : GetColor_ItemBg(color_Item_Upgrade));
                        }
                    }
                }
            }
            g.fillRect(num5, num6, num7, num8);
            if (item == null)
            {
                continue;
            }
            string text = string.Empty;
            mFont2 mFont2 = mFont2.tahoma_7_green2;
            if (item.itemOption != null)
            {
                for (int k = 0; k < item.itemOption.Length; k++)
                {
                    if (item.itemOption[k].optionTemplate.id == 72)
                    {
                        text = " [+" + item.itemOption[k].param + "]";
                    }
                    if (item.itemOption[k].optionTemplate.id == 41)
                    {
                        if (item.itemOption[k].param == 1)
                        {
                            mFont2 = GetFont(0);
                        }
                        else if (item.itemOption[k].param == 2)
                        {
                            mFont2 = GetFont(2);
                        }
                        else if (item.itemOption[k].param == 3)
                        {
                            mFont2 = GetFont(8);
                        }
                        else if (item.itemOption[k].param == 4)
                        {
                            mFont2 = GetFont(7);
                        }
                    }
                }
            }
            mFont2.drawString(g, "[" + item.template.id + "] " + item.template.name + text, num + 5, num2 + 1, 0);
            string text2 = string.Empty;
            if (item.itemOption != null)
            {
                if (item.itemOption.Length > 0 && item.itemOption[0] != null)
                {
                    text2 += item.itemOption[0].getOptionString();
                }
                mFont2 mFont3 = mFont2.tahoma_7_blue;
                if (item.compare < 0 && item.template.type != 5)
                {
                    mFont3 = mFont2.tahoma_7_red;
                }
                if (item.itemOption.Length > 1)
                {
                    for (int l = 1; l < item.itemOption.Length; l++)
                    {
                        if (item.itemOption[l] != null && item.itemOption[l].optionTemplate.id != 102 && item.itemOption[l].optionTemplate.id != 107)
                        {
                            text2 = text2 + "," + item.itemOption[l].getOptionString();
                        }
                    }
                }
                mFont3.drawString(g, text2, num + 5, num2 + 11, mFont2.LEFT);
            }
            SmallImage2.drawSmallImage(g, item.template.iconID, num5 + num7 / 2, num6 + num8 / 2, 0, 3);
            if (item.itemOption != null)
            {
                for (int m = 0; m < item.itemOption.Length; m++)
                {
                    paintOptItem(g, item.itemOption[m].optionTemplate.id, item.itemOption[m].param, num5, num6, num7, num8);
                }
                for (int n = 0; n < item.itemOption.Length; n++)
                {
                    paintOptSlotItem(g, item.itemOption[n].optionTemplate.id, item.itemOption[n].param, num5, num6, num7, num8);
                }
            }
            if (item.quantity > 1)
            {
                mFont2.tahoma_7_yellow.drawString(g, string.Empty + item.quantity, num5 + num7, num6 + num8 - mFont2.tahoma_7_yellow.getHeight(), 1);
            }
        }
        paintScrollArrow(g);
    }

    private void updateKeyMap()
    {
        if (GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21])
        {
            yMove -= 5;
            cmyMap = yMove - (yScroll + hScroll / 2);
            if (yMove < yScroll)
            {
                yMove = yScroll;
            }
        }
        if (GameCanvas2.keyHold[(!Main2.isPC) ? 8 : 22])
        {
            yMove += 5;
            cmyMap = yMove - (yScroll + hScroll / 2);
            if (yMove > yScroll + 200)
            {
                yMove = yScroll + 200;
            }
        }
        if (GameCanvas2.keyHold[(!Main2.isPC) ? 4 : 23])
        {
            xMove -= 5;
            cmxMap = xMove - wScroll / 2;
            if (xMove < 16)
            {
                xMove = 16;
            }
        }
        if (GameCanvas2.keyHold[(!Main2.isPC) ? 6 : 24])
        {
            xMove += 5;
            cmxMap = xMove - wScroll / 2;
            if (xMove > 250)
            {
                xMove = 250;
            }
        }
        if (GameCanvas2.isPointerDown)
        {
            pointerIsDowning = true;
            if (!trans)
            {
                pa1 = cmxMap;
                pa2 = cmyMap;
                trans = true;
            }
            cmxMap = pa1 + (GameCanvas2.pxLast - GameCanvas2.px);
            cmyMap = pa2 + (GameCanvas2.pyLast - GameCanvas2.py);
        }
        if (GameCanvas2.isPointerJustRelease)
        {
            trans = false;
            GameCanvas2.pxLast = GameCanvas2.px;
            GameCanvas2.pyLast = GameCanvas2.py;
            pX = GameCanvas2.pxLast + cmxMap;
            pY = GameCanvas2.pyLast + cmyMap;
        }
        if (GameCanvas2.isPointerClick)
        {
            pointerIsDowning = false;
        }
        if (cmxMap < 0)
        {
            cmxMap = 0;
        }
        if (cmxMap > cmxMapLim)
        {
            cmxMap = cmxMapLim;
        }
        if (cmyMap < 0)
        {
            cmyMap = 0;
        }
        if (cmyMap > cmyMapLim)
        {
            cmyMap = cmyMapLim;
        }
    }

    private void updateKeyCombine()
    {
        if (currentTabIndex == 0)
        {
            updateKeyScrollView();
            keyTouchCombine = -1;
            if (selected == vItemCombine.size() && GameCanvas2.isPointerClick)
            {
                GameCanvas2.isPointerClick = false;
                keyTouchCombine = 1;
            }
        }
        if (currentTabIndex == 1)
        {
            updateKeyScrollView();
        }
    }

    private void updateKeyQuest()
    {
        if (GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21])
        {
            cmyQuest -= 5;
        }
        if (GameCanvas2.keyHold[(!Main2.isPC) ? 8 : 22])
        {
            cmyQuest += 5;
        }
        if (cmyQuest < 0)
        {
            cmyQuest = 0;
        }
        int num = indexRowMax * 12 - (hScroll - 60);
        if (num < 0)
        {
            num = 0;
        }
        if (cmyQuest > num)
        {
            cmyQuest = num;
        }
        if (scroll != null)
        {
            if (!GameCanvas2.isTouch)
            {
                scroll.cmy = cmyQuest;
            }
            scroll.updateKey();
        }
        int num2 = xScroll + wScroll / 2 - 35;
        int num3 = ((GameCanvas2.h <= 300) ? 15 : 20);
        int num4 = yScroll + hScroll - num3 - 15;
        int px = GameCanvas2.px;
        int py = GameCanvas2.py;
        keyTouchMapButton = -1;
        if (isPaintMap && !GameScr2.gI().isMapDocNhan() && px >= num2 && px <= num2 + 70 && py >= num4 && py <= num4 + 30 && (scroll == null || !scroll.pointerIsDowning))
        {
            keyTouchMapButton = 1;
            if (GameCanvas2.isPointerJustRelease)
            {
                SoundMn2.gI().buttonClick();
                waitToPerform = 2;
                GameCanvas2.clearAllPointerEvent();
            }
        }
    }

    private void getCurrClanOtion()
    {
        isClanOption = false;
        if (type != 0 || mainTabName.Length != 5 || currentTabIndex != 3)
        {
            return;
        }
        isClanOption = false;
        if (selected == 0)
        {
            currClanOption = new int[clansOption.Length];
            for (int i = 0; i < currClanOption.Length; i++)
            {
                currClanOption[i] = i;
            }
            if (!isViewMember)
            {
                isClanOption = true;
            }
        }
        else if (selected != 1 && !isSearchClan && selected > 0)
        {
            currClanOption = new int[1];
            for (int j = 0; j < currClanOption.Length; j++)
            {
                currClanOption[j] = j;
            }
            isClanOption = true;
        }
    }

    private void updateKeyClansOption()
    {
        if (currClanOption == null)
        {
            return;
        }
        if (GameCanvas2.keyPressed[(!Main2.isPC) ? 4 : 23])
        {
            currMess = getCurrMessage();
            cSelected--;
            if (selected == 0 && cSelected < 0)
            {
                cSelected = currClanOption.Length - 1;
            }
            if (selected > 1 && isMessage && currMess.option != null && cSelected < 0)
            {
                cSelected = currMess.option.Length - 1;
            }
        }
        else if (GameCanvas2.keyPressed[(!Main2.isPC) ? 6 : 24])
        {
            currMess = getCurrMessage();
            cSelected++;
            if (selected == 0 && cSelected > currClanOption.Length - 1)
            {
                cSelected = 0;
            }
            if (selected > 1 && isMessage && currMess.option != null && cSelected > currMess.option.Length - 1)
            {
                cSelected = 0;
            }
        }
    }

    private void updateKeyClans()
    {
        updateKeyScrollView();
        updateKeyClansOption();
    }

    private void checkOptionSelect()
    {
        try
        {
            if (type != 0 || currentTabIndex != 3 || mainTabName.Length != 5 || selected == -1)
            {
                return;
            }
            int num = 0;
            if (selected == 0)
            {
                num = xScroll + wScroll / 2 - clansOption.Length * TAB_W / 2;
                cSelected = (GameCanvas2.px - num) / TAB_W;
            }
            else
            {
                currMess = getCurrMessage();
                if (currMess != null && currMess.option != null)
                {
                    num = xScroll + wScroll - 2 - currMess.option.Length * 40;
                    cSelected = (GameCanvas2.px - num) / 40;
                }
            }
            if (GameCanvas2.px < num)
            {
                cSelected = -1;
            }
        }
        catch (Exception ex)
        {
            Res2.outz("Throw err " + ex.StackTrace);
        }
    }

    public void updateScroolMouse(int a)
    {
        bool flag = false;
        if (GameCanvas2.pxMouse > wScroll)
        {
            return;
        }
        if (indexMouse == -1)
        {
            indexMouse = selected;
        }
        if (a > 0)
        {
            indexMouse -= a;
            flag = true;
        }
        else if (a < 0)
        {
            indexMouse += -a;
            flag = true;
        }
        if (indexMouse < 0)
        {
            indexMouse = 0;
        }
        if (flag)
        {
            cmtoY = indexMouse * 12;
            if (cmtoY > cmyLim)
            {
                cmtoY = cmyLim;
            }
            if (cmtoY < 0)
            {
                cmtoY = 0;
            }
        }
    }

    private void updateKeyScrollView()
    {
        if (currentListLength <= 0)
        {
            return;
        }
        bool flag = false;
        if (GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21])
        {
            flag = true;
            if (isTabInven() && isnewInventory)
            {
                if (selected > 0 && sellectInventory == 0)
                {
                    selected--;
                }
            }
            else
            {
                selected--;
                if (type == 24 || type == 27)
                {
                    selected -= 2;
                    if (selected < 0)
                    {
                        selected = 0;
                    }
                }
                else if (selected < 0)
                {
                    if (Equals(GameCanvas2.panel) && typeShop == 2 && currentTabIndex <= 3 && maxPageShop[currentTabIndex] > 1)
                    {
                        InfoDlg2.showWait();
                        if (currPageShop[currentTabIndex] <= 0)
                        {
                            Service2.gI().kigui(4, -1, (sbyte)currentTabIndex, maxPageShop[currentTabIndex] - 1, -1);
                        }
                        else
                        {
                            Service2.gI().kigui(4, -1, (sbyte)currentTabIndex, currPageShop[currentTabIndex] - 1, -1);
                        }
                        return;
                    }
                    selected = currentListLength - 1;
                    if (isClanOption)
                    {
                        selected = -1;
                    }
                    if (size_tab > 0)
                    {
                        selected = -1;
                    }
                }
                lastSelect[currentTabIndex] = selected;
                cSelected = 0;
                getCurrClanOtion();
            }
        }
        else if (GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22])
        {
            flag = true;
            if (isTabInven() && isnewInventory)
            {
                if (selected < 1 && sellectInventory == 0)
                {
                    selected++;
                }
            }
            else
            {
                selected++;
                if (type == 24 || type == 27)
                {
                    selected += 2;
                    if (selected > currentListLength - 1)
                    {
                        selected = currentListLength - 1;
                    }
                }
                else if (selected > currentListLength - 1)
                {
                    if (Equals(GameCanvas2.panel) && typeShop == 2 && currentTabIndex <= 3 && maxPageShop[currentTabIndex] > 1)
                    {
                        InfoDlg2.showWait();
                        if (currPageShop[currentTabIndex] >= maxPageShop[currentTabIndex] - 1)
                        {
                            Service2.gI().kigui(4, -1, (sbyte)currentTabIndex, 0, -1);
                        }
                        else
                        {
                            Service2.gI().kigui(4, -1, (sbyte)currentTabIndex, currPageShop[currentTabIndex] + 1, -1);
                        }
                        return;
                    }
                    selected = 0;
                }
                lastSelect[currentTabIndex] = selected;
                cSelected = 0;
                getCurrClanOtion();
            }
        }
        if (isnewInventory && GameCanvas2.keyPressed[5] && itemInvenNew != null)
        {
            pointerDownTime = 0;
            waitToPerform = 2;
        }
        if (flag)
        {
            cmtoY = selected * ITEM_HEIGHT - hScroll / 2;
            if (cmtoY > cmyLim)
            {
                cmtoY = cmyLim;
            }
            if (cmtoY < 0)
            {
                cmtoY = 0;
            }
            cmy = cmtoY;
        }
        if (GameCanvas2.isPointerDown)
        {
            justRelease = false;
            if (!pointerIsDowning && GameCanvas2.isPointer(xScroll, yScroll, wScroll, hScroll))
            {
                for (int i = 0; i < pointerDownLastX.Length; i++)
                {
                    pointerDownLastX[0] = GameCanvas2.py;
                }
                pointerDownFirstX = GameCanvas2.py;
                pointerIsDowning = true;
                isDownWhenRunning = cmRun != 0;
                cmRun = 0;
            }
            else if (pointerIsDowning)
            {
                pointerDownTime++;
                if (pointerDownTime > 5 && pointerDownFirstX == GameCanvas2.py && !isDownWhenRunning)
                {
                    pointerDownFirstX = -1000;
                    selected = (cmtoY + GameCanvas2.py - yScroll) / ITEM_HEIGHT;
                    if (selected >= currentListLength)
                    {
                        selected = -1;
                    }
                    checkOptionSelect();
                }
                else
                {
                    indexMouse = -1;
                }
                int num = GameCanvas2.py - pointerDownLastX[0];
                if (num != 0 && selected != -1)
                {
                    selected = -1;
                    cSelected = -1;
                }
                for (int num2 = pointerDownLastX.Length - 1; num2 > 0; num2--)
                {
                    pointerDownLastX[num2] = pointerDownLastX[num2 - 1];
                }
                pointerDownLastX[0] = GameCanvas2.py;
                cmtoY -= num;
                if (cmtoY < 0)
                {
                    cmtoY = 0;
                }
                if (cmtoY > cmyLim)
                {
                    cmtoY = cmyLim;
                }
                if (cmy < 0 || cmy > cmyLim)
                {
                    num /= 2;
                }
                cmy -= num;
                if (cmy < -(GameCanvas2.h / 3))
                {
                }
                else
                {
                }
                if (isnewInventory)
                {
                    int num3 = GameCanvas2.px - xScroll;
                    int num4 = GameCanvas2.py - yScroll;
                    sellectInventory = num4 / 34 * 5 + num3 / 34;
                }
            }
        }
        if (!GameCanvas2.isPointerJustRelease || !pointerIsDowning)
        {
            return;
        }
        justRelease = true;
        int i2 = GameCanvas2.py - pointerDownLastX[0];
        GameCanvas2.isPointerJustRelease = false;
        if (Res2.abs(i2) < 20 && Res2.abs(GameCanvas2.py - pointerDownFirstX) < 20 && !isDownWhenRunning)
        {
            cmRun = 0;
            cmtoY = cmy;
            pointerDownFirstX = -1000;
            selected = (cmtoY + GameCanvas2.py - yScroll) / ITEM_HEIGHT;
            if (selected >= currentListLength)
            {
                selected = -1;
            }
            checkOptionSelect();
            pointerDownTime = 0;
            waitToPerform = 10;
            if (isnewInventory)
            {
                waitToPerform = -1;
            }
            SoundMn2.gI().panelClick();
        }
        else if (selected != -1 && pointerDownTime > 5)
        {
            pointerDownTime = 0;
            waitToPerform = 1;
        }
        else if (selected == -1 && !isDownWhenRunning)
        {
            if (cmy < 0)
            {
                cmtoY = 0;
            }
            else if (cmy > cmyLim)
            {
                cmtoY = cmyLim;
            }
            else
            {
                int num5 = GameCanvas2.py - pointerDownLastX[0] + (pointerDownLastX[0] - pointerDownLastX[1]) + (pointerDownLastX[1] - pointerDownLastX[2]);
                num5 = ((num5 > 10) ? 10 : ((num5 < -10) ? (-10) : 0));
                cmRun = -num5 * 100;
            }
        }
        if ((isTabInven() || type == 13) && GameCanvas2.py < yScroll + 21)
        {
            selected = 0;
            updateKeyInvenTab();
        }
        pointerIsDowning = false;
        pointerDownTime = 0;
        GameCanvas2.isPointerJustRelease = false;
    }

    public string subArray(string[] str)
    {
        return null;
    }

    private void updateKeyInTabBar()
    {
        if ((scroll != null && scroll.pointerIsDowning) || pointerIsDowning)
        {
            return;
        }
        int num = currentTabIndex;
        if (isTabInven() && isnewInventory)
        {
            if (selected == -1)
            {
                if (GameCanvas2.keyPressed[6])
                {
                    currentTabIndex++;
                    if (currentTabIndex >= currentTabName.Length)
                    {
                        if (GameCanvas2.panel2 != null)
                        {
                            currentTabIndex = currentTabName.Length - 1;
                            GameCanvas2.isFocusPanel2 = true;
                        }
                        else
                        {
                            currentTabIndex = 0;
                        }
                    }
                    selected = lastSelect[currentTabIndex];
                    lastTabIndex[type] = currentTabIndex;
                }
                if (GameCanvas2.keyPressed[4])
                {
                    currentTabIndex--;
                    if (currentTabIndex < 0)
                    {
                        currentTabIndex = currentTabName.Length - 1;
                    }
                    if (GameCanvas2.isFocusPanel2)
                    {
                        GameCanvas2.isFocusPanel2 = false;
                    }
                    selected = lastSelect[currentTabIndex];
                    lastTabIndex[type] = currentTabIndex;
                }
            }
            else if (selected > 0)
            {
                if (GameCanvas2.keyPressed[8])
                {
                    if (newSelected == 0)
                    {
                        sellectInventory++;
                    }
                    else
                    {
                        sellectInventory += 5;
                    }
                }
                else if (GameCanvas2.keyPressed[2])
                {
                    if (newSelected == 0)
                    {
                        sellectInventory--;
                    }
                    else
                    {
                        sellectInventory -= 5;
                    }
                }
                else if (GameCanvas2.keyPressed[4])
                {
                    if (newSelected == 0)
                    {
                        sellectInventory -= 5;
                    }
                    else
                    {
                        sellectInventory--;
                    }
                }
                else if (GameCanvas2.keyPressed[6])
                {
                    if (newSelected == 0)
                    {
                        sellectInventory += 5;
                    }
                    else
                    {
                        sellectInventory++;
                    }
                }
            }
            if (sellectInventory < 0)
            {
            }
            if (sellectInventory == nTableItem)
            {
                sellectInventory = 0;
            }
        }
        else if (!IsTabOption())
        {
            if (GameCanvas2.keyPressed[(!Main2.isPC) ? 6 : 24])
            {
                if (isTabInven())
                {
                    if (selected >= 0)
                    {
                        updateKeyInvenTab();
                    }
                    else
                    {
                        currentTabIndex++;
                        if (currentTabIndex >= currentTabName.Length)
                        {
                            if (GameCanvas2.panel2 != null)
                            {
                                currentTabIndex = currentTabName.Length - 1;
                                GameCanvas2.isFocusPanel2 = true;
                            }
                            else
                            {
                                currentTabIndex = 0;
                            }
                        }
                        selected = lastSelect[currentTabIndex];
                        lastTabIndex[type] = currentTabIndex;
                    }
                }
                else
                {
                    currentTabIndex++;
                    if (currentTabIndex >= currentTabName.Length)
                    {
                        if (GameCanvas2.panel2 != null)
                        {
                            currentTabIndex = currentTabName.Length - 1;
                            GameCanvas2.isFocusPanel2 = true;
                        }
                        else
                        {
                            currentTabIndex = 0;
                        }
                    }
                    selected = lastSelect[currentTabIndex];
                    lastTabIndex[type] = currentTabIndex;
                }
            }
            if (GameCanvas2.keyPressed[(!Main2.isPC) ? 4 : 23])
            {
                currentTabIndex--;
                if (currentTabIndex < 0)
                {
                    currentTabIndex = currentTabName.Length - 1;
                }
                if (GameCanvas2.isFocusPanel2)
                {
                    GameCanvas2.isFocusPanel2 = false;
                }
                selected = lastSelect[currentTabIndex];
                lastTabIndex[type] = currentTabIndex;
            }
        }
        keyTouchTab = -1;
        for (int i = 0; i < currentTabName.Length; i++)
        {
            if (!GameCanvas2.isPointer(startTabPos + i * TAB_W, 52, TAB_W - 1, 25))
            {
                continue;
            }
            keyTouchTab = i;
            if (GameCanvas2.isPointerJustRelease)
            {
                if (type == 8)
                {
                    MainMod2.DoChatGlobal();
                    break;
                }
                currentTabIndex = i;
                lastTabIndex[type] = i;
                GameCanvas2.isPointerJustRelease = false;
                selected = lastSelect[currentTabIndex];
                if (num == currentTabIndex && cmRun == 0)
                {
                    cmtoY = 0;
                    selected = GameCanvas2.isTouch ? (-1) : 0;
                }
                break;
            }
        }
        if (num == currentTabIndex)
        {
            return;
        }
        size_tab = 0;
        SoundMn2.gI().panelClick();
        switch (type)
        {
            case 21:
            case 28:
                if (currentTabIndex == 0)
                {
                    setTabPetInventory(type == 28);
                }
                else if (currentTabIndex == 1)
                {
                    setTabPetSkill(type == 28);
                }
                else if (currentTabIndex == 2)
                {
                    setTabPetStatus();
                }
                else if (currentTabIndex == 3)
                {
                    setTabInventory(resetSelect: true);
                }
                break;
            case 0:
                if (currentTabIndex == 0)
                {
                    setTabTask();
                }
                if (currentTabIndex == 1)
                {
                    setTabInventory(resetSelect: true);
                }
                if (currentTabIndex == 2)
                {
                    setTabSkill();
                }
                if (currentTabIndex == 3)
                {
                    if (mainTabName.Length > 4)
                    {
                        setTabClans();
                    }
                    else
                    {
                        setTabTool();
                    }
                }
                if (currentTabIndex == 4)
                {
                    setTabTool();
                }
                break;
            case 2:
                if (currentTabIndex == 0)
                {
                    setTabBox();
                }
                if (currentTabIndex == 1)
                {
                    setTabInventory(resetSelect: true);
                }
                break;
            case 3:
                setTabZone();
                break;
            case 1:
                setTabShop();
                break;
            case 25:
                setTabSpeacialSkill();
                break;
            case 12:
                if (currentTabIndex == 0)
                {
                    setTabCombine();
                }
                if (currentTabIndex == 1)
                {
                    setTabInventory(resetSelect: true);
                }
                break;
            case 13:
                if (currentTabIndex == 0)
                {
                    if (Equals(GameCanvas2.panel))
                    {
                        setTabInventory(resetSelect: true);
                    }
                    else if (Equals(GameCanvas2.panel2))
                    {
                        setTabGiaoDich(isMe: false);
                    }
                }
                if (currentTabIndex == 1)
                {
                    setTabGiaoDich(isMe: true);
                }
                if (currentTabIndex == 2)
                {
                    setTabGiaoDich(isMe: false);
                }
                break;
        }
        selected = lastSelect[currentTabIndex];
    }

    private void setTabPetStatus()
    {
        currentListLength = strStatus.Length;
        ITEM_HEIGHT = 24;
        selected = (GameCanvas2.isTouch ? (-1) : 0);
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
    }

    private void setTabPetSkill(bool isPet2)
    {
        ITEM_HEIGHT = 30;
        currentListLength = (isPet2 ? Char2.MyPet2z() : Char2.myPetz()).arrPetSkill.Length + 5;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = cmtoY = cmyLast[currentTabIndex];
        if (cmy < 0)
        {
            cmy = cmtoY = 0;
        }
        if (cmy > cmyLim)
        {
            cmy = cmyLim;
        }
        selected = GameCanvas2.isTouch ? (-1) : 0;
    }

    private void setTabTool()
    {
        SoundMn2.gI().getSoundOption();
        currentListLength = strTool.Length;
        ITEM_HEIGHT = 24;
        selected = (GameCanvas2.isTouch ? (-1) : 0);
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
    }

    public void initTabClans()
    {
        if (isSearchClan)
        {
            currentListLength = ((clans != null) ? (clans.Length + 2) : 2);
            clanInfo = mResources2.clan_list;
        }
        else if (isViewMember)
        {
            clanReport = string.Empty;
            currentListLength = ((member != null) ? member.size() : myMember.size()) + 2;
            clanInfo = mResources2.member + " " + ((currClan == null) ? Char2.myCharz().clan.name : currClan.name);
        }
        else if (isMessage)
        {
            currentListLength = ClanMessage2.vMessage.size() + 2;
            clanInfo = mResources2.msg;
            clanReport = string.Empty;
        }
        if (Char2.myCharz().clan == null)
        {
            clansOption = new string[2][]
            {
                mResources2.findClan,
                mResources2.createClan
            };
        }
        else if (!isViewMember)
        {
            if (myMember.size() > 1)
            {
                clansOption = new string[3][]
                {
                    mResources2.chatClan,
                    mResources2.request_pea2,
                    mResources2.memberr
                };
            }
            else
            {
                clansOption = new string[1][] { mResources2.memberr };
            }
        }
        else if (Char2.myCharz().role > 0)
        {
            clansOption = new string[2][]
            {
                mResources2.msgg,
                mResources2.leaveClan
            };
        }
        else if (myMember.size() > 1)
        {
            clansOption = new string[4][]
            {
                mResources2.msgg,
                mResources2.leaveClan,
                mResources2.khau_hieuu,
                mResources2.bieu_tuongg
            };
        }
        else
        {
            clansOption = new string[3][]
            {
                mResources2.msgg,
                mResources2.khau_hieuu,
                mResources2.bieu_tuongg
            };
        }
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
    }

    public void setTabClans()
    {
        GameScr2.isNewClanMessage = false;
        ITEM_HEIGHT = 24;
        if (lastSelect != null && lastSelect[3] == 0)
        {
            lastSelect[3] = -1;
        }
        currentListLength = 2;
        if (Char2.myCharz().clan != null)
        {
            isMessage = true;
            isViewMember = false;
            isSearchClan = false;
        }
        else
        {
            isMessage = false;
            isViewMember = false;
            isSearchClan = true;
        }
        if (Char2.myCharz().clan != null)
        {
            currentListLength = ClanMessage2.vMessage.size() + 2;
        }
        initTabClans();
        cSelected = -1;
        if (chatTField == null)
        {
            chatTField = new ChatTextField2();
            chatTField.tfChat.y = GameCanvas2.h - 35 - global::ChatTextField2.gI().tfChat.height;
            chatTField.initChatTextField();
            chatTField.parentScreen = GameCanvas2.panel;
        }
        if (Char2.myCharz().clan == null)
        {
            clanReport = mResources2.findingClan;
            Service2.gI().searchClan(string.Empty);
        }
        selected = lastSelect[currentTabIndex];
        if (GameCanvas2.isTouch)
        {
            selected = -1;
        }
    }

    public void initLogMessage()
    {
        currentListLength = logChat.size() + 1;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        cmx = (cmtoX = 0);
    }

    private void setTabMessage()
    {
        ITEM_HEIGHT = 24;
        initLogMessage();
        selected = (GameCanvas2.isTouch ? (-1) : 0);
    }

    public void setTabShop()
    {
        ITEM_HEIGHT = 24;
        if (currentTabIndex == currentTabName.Length - 1 && GameCanvas2.panel2 == null && typeShop != 2)
        {
            currentListLength = checkCurrentListLength(Char2.myCharz().arrItemBody.Length + Char2.myCharz().arrItemBag.Length);
        }
        else
        {
            currentListLength = Char2.myCharz().arrItemShop[currentTabIndex].Length;
        }
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        selected = (GameCanvas2.isTouch ? (-1) : 0);
    }

    private void setTabSkill()
    {
        ITEM_HEIGHT = 30;
        currentListLength = Char2.myCharz().nClass.skillTemplates.Length + 6;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = cmtoY = cmyLast[currentTabIndex];
        if (cmy < 0)
        {
            cmy = cmtoY = 0;
        }
        if (cmy > cmyLim)
        {
            cmy = cmyLim;
        }
        selected = GameCanvas2.isTouch ? (-1) : 0;
    }

    private void setTabMapTrans()
    {
        ITEM_HEIGHT = 24;
        currentListLength = mapNames.Length;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = cmtoY = cmyLast[currentTabIndex];
        if (cmy < 0)
        {
            cmy = cmtoY = 0;
        }
        if (cmy > cmyLim)
        {
            cmy = cmyLim;
        }
        selected = GameCanvas2.isTouch ? (-1) : 0;
    }

    private void setTabZone()
    {
        ITEM_HEIGHT = 24;
        currentListLength = GameScr2.gI().zones.Length;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        cmy = (cmtoY = 0);
        selected = (GameCanvas2.isTouch ? (-1) : 0);
    }

    private void setTabBox()
    {
        currentListLength = checkCurrentListLength(Char2.myCharz().arrItemBox.Length);
        ITEM_HEIGHT = 24;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 9;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        selected = (GameCanvas2.isTouch ? (-1) : 0);
    }

    private void setTabPetInventory(bool isPet2)
    {
        ITEM_HEIGHT = 30;
        Item2[] arrItemBody = (isPet2 ? Char2.MyPet2z() : Char2.myPetz()).arrItemBody;
        currentListLength = arrItemBody.Length;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = 0);
        }
        selected = (GameCanvas2.isTouch ? (-1) : 0);
    }

    private void setTabInventory(bool resetSelect)
    {
        if (isnewInventory)
        {
            int num = Char2.myCharz().arrItemBody.Length + Char2.myCharz().arrItemBag.Length;
            currentListLength = checkCurrentListLength(num);
            currentListLength = 3;
            newSelected = 0;
            size_tab = (sbyte)(num / 20 + ((num % 20 > 0) ? 1 : 0));
            Res2.outz("sizeTab = " + size_tab);
            return;
        }
        currentListLength = checkCurrentListLength(Char2.myCharz().arrItemBody.Length + Char2.myCharz().arrItemBag.Length);
        ITEM_HEIGHT = 24;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = 0);
        }
        if (resetSelect)
        {
            selected = (GameCanvas2.isTouch ? (-1) : 0);
        }
    }

    private void setTabMap()
    {
        if (!isPaintMap)
        {
            return;
        }
        if (TileMap2.lastPlanetId != TileMap2.planetID)
        {
            Res2.outz("LOAD TAM HINH");
            imgMap = GameCanvas2.loadImageRMS("/img/map" + TileMap2.planetID + ".png");
            TileMap2.lastPlanetId = TileMap2.planetID;
        }
        cmxMap = getXMap() - wScroll / 2;
        cmyMap = getYMap() + yScroll - (yScroll + hScroll / 2);
        pa1 = cmxMap;
        pa2 = cmyMap;
        cmxMapLim = 250 - wScroll;
        cmyMapLim = 220 - hScroll;
        if (cmxMapLim < 0)
        {
            cmxMapLim = 0;
        }
        if (cmyMapLim < 0)
        {
            cmyMapLim = 0;
        }
        for (int i = 0; i < mapId[TileMap2.planetID].Length; i++)
        {
            if (TileMap2.mapID == mapId[TileMap2.planetID][i])
            {
                xMove = mapX[TileMap2.planetID][i] + xScroll;
                yMove = mapY[TileMap2.planetID][i] + yScroll + 5;
                break;
            }
        }
        xMap = getXMap() + xScroll;
        yMap = getYMap() + yScroll;
        xMapTask = getXMapTask() + xScroll;
        yMapTask = getYMapTask() + yScroll;
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

    private void setTabTask()
    {
        cmyQuest = 0;
    }

    public void moveCamera()
    {
        if (timeShow > 0)
        {
            timeShow--;
        }
        if (justRelease && Equals(GameCanvas2.panel) && typeShop == 2 && maxPageShop[currentTabIndex] > 1)
        {
            if (cmy < -50)
            {
                InfoDlg2.showWait();
                justRelease = false;
                if (currPageShop[currentTabIndex] <= 0)
                {
                    Service2.gI().kigui(4, -1, (sbyte)currentTabIndex, maxPageShop[currentTabIndex] - 1, -1);
                }
                else
                {
                    Service2.gI().kigui(4, -1, (sbyte)currentTabIndex, currPageShop[currentTabIndex] - 1, -1);
                }
            }
            else if (cmy > cmyLim + 50)
            {
                justRelease = false;
                InfoDlg2.showWait();
                if (currPageShop[currentTabIndex] >= maxPageShop[currentTabIndex] - 1)
                {
                    Service2.gI().kigui(4, -1, (sbyte)currentTabIndex, 0, -1);
                }
                else
                {
                    Service2.gI().kigui(4, -1, (sbyte)currentTabIndex, currPageShop[currentTabIndex] + 1, -1);
                }
            }
        }
        if (cmx != cmtoX && !pointerIsDowning)
        {
            cmvx = cmtoX - cmx << 2;
            cmdx += cmvx;
            cmx += cmdx >> 3;
            cmdx &= 15;
        }
        if (Math2.abs(cmtoX - cmx) < 10)
        {
            cmx = cmtoX;
        }
        if (isClose)
        {
            isClose = false;
            cmtoX = wScroll;
        }
        if (cmtoX >= wScroll - 10 && cmx >= wScroll - 10 && position == 0)
        {
            isShow = false;
            cleanCombine();
            if (isChangeZone)
            {
                isChangeZone = false;
                if (Char2.myCharz().cHP > 0 && Char2.myCharz().statusMe != 14)
                {
                    InfoDlg2.showWait();
                    if (type == 3)
                    {
                        Service2.gI().requestChangeZone(selected, -1);
                    }
                    else if (type == 14)
                    {
                        AutoXmap2.SelectMapTrans(selected);
                    }
                }
            }
            if (isSelectPlayerMenu)
            {
                isSelectPlayerMenu = false;
                int num = vPlayerMenu.size() - vPlayerMenu_id.size();
                if (Char2.myCharz().charFocus != null)
                {
                    if (selected - num < 0)
                    {
                        Char2.myCharz().charFocus.menuSelect = selected;
                    }
                    else
                    {
                        Char2.myCharz().charFocus.menuSelect = short.Parse((string)vPlayerMenu_id.elementAt(selected - num));
                    }
                }
                Command2 command = (Command2)vPlayerMenu.elementAt(selected);
                command.performAction();
            }
            vPlayerMenu.removeAllElements();
            vPlayerMenu_id.removeAllElements();
            charMenu = null;
        }
        if (cmRun != 0 && !pointerIsDowning)
        {
            cmtoY += cmRun / 100;
            if (cmtoY < 0)
            {
                cmtoY = 0;
            }
            else if (cmtoY > cmyLim)
            {
                cmtoY = cmyLim;
            }
            else
            {
                cmy = cmtoY;
            }
            cmRun = cmRun * 9 / 10;
            if (cmRun < 100 && cmRun > -100)
            {
                cmRun = 0;
            }
        }
        if (cmy != cmtoY && !pointerIsDowning)
        {
            cmvy = cmtoY - cmy << 2;
            cmdy += cmvy;
            cmy += cmdy >> 4;
            cmdy &= 15;
        }
        cmyLast[currentTabIndex] = cmy;
    }

    public void paintDetail(mGraphics2 g)
    {
        if (cp == null || cp.says == null)
        {
            return;
        }
        cp.paint(g);
        int num = cp.cx + 13;
        int num2 = cp.cy + 11;
        if (type == 15)
        {
            num += 5;
            num2 += 26;
        }
        if (type == 0 && currentTabIndex == 3)
        {
            if (isSearchClan)
            {
                num -= 5;
            }
            else if (partID != null || charInfo != null)
            {
                num = cp.cx + 21;
                num2 = cp.cy + 40;
            }
        }
        if (partID != null)
        {
            Part2 part = GameScr2.parts[partID[0]];
            Part2 part2 = GameScr2.parts[partID[1]];
            Part2 part3 = GameScr2.parts[partID[2]];
            SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[0][0][0]].id, num + Char2.CharInfo[0][0][1] + part.pi[Char2.CharInfo[0][0][0]].dx, num2 - Char2.CharInfo[0][0][2] + part.pi[Char2.CharInfo[0][0][0]].dy, 0, 0);
            SmallImage2.drawSmallImage(g, part2.pi[Char2.CharInfo[0][1][0]].id, num + Char2.CharInfo[0][1][1] + part2.pi[Char2.CharInfo[0][1][0]].dx, num2 - Char2.CharInfo[0][1][2] + part2.pi[Char2.CharInfo[0][1][0]].dy, 0, 0);
            SmallImage2.drawSmallImage(g, part3.pi[Char2.CharInfo[0][2][0]].id, num + Char2.CharInfo[0][2][1] + part3.pi[Char2.CharInfo[0][2][0]].dx, num2 - Char2.CharInfo[0][2][2] + part3.pi[Char2.CharInfo[0][2][0]].dy, 0, 0);
        }
        else if (charInfo != null)
        {
            charInfo.paintCharBody(g, num + 5, num2 + 25, 1, 0, isPaintBag: true);
        }
        else if (idIcon != -1)
        {
            SmallImage2.drawSmallImage(g, idIcon, num, num2, 0, 3);
        }
        if (currItem != null && currItem.template.type != 5)
        {
            if (currItem.compare > 0)
            {
                g.drawImage(imgUp, num - 7, num2 + 13, 3);
                mFont2.tahoma_7b_green.drawString(g, Res2.abs(currItem.compare) + string.Empty, num + 1, num2 + 8, 0);
            }
            else if (currItem.compare < 0 && currItem.compare != -1)
            {
                g.drawImage(imgDown, num - 7, num2 + 13, 3);
                mFont2.tahoma_7b_red.drawString(g, Res2.abs(currItem.compare) + string.Empty, num + 1, num2 + 8, 0);
            }
        }
    }

    public void paintTop(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        g.setColor(0);
        if (currentListLength == 0)
        {
            return;
        }
        int num = (cmy + hScroll) / 24 + 1;
        if (num < hScroll / 24 + 1)
        {
            num = hScroll / 24 + 1;
        }
        if (num > currentListLength)
        {
            num = currentListLength;
        }
        int num2 = cmy / 24;
        if (num2 >= num)
        {
            num2 = num - 1;
        }
        if (num2 < 0)
        {
            num2 = 0;
        }
        for (int i = num2; i < num; i++)
        {
            int num3 = xScroll;
            int num4 = yScroll + i * ITEM_HEIGHT;
            int num5 = 24;
            int h = ITEM_HEIGHT - 1;
            int num6 = xScroll + num5;
            int num7 = yScroll + i * ITEM_HEIGHT;
            int num8 = wScroll - num5;
            int num9 = ITEM_HEIGHT - 1;
            g.setColor((i != selected) ? 15196114 : 16383818);
            g.fillRect(num6, num7, num8, num9);
            g.setColor((i != selected) ? 9993045 : 9541120);
            g.fillRect(num3, num4, num5, h);
            TopInfo2 topInfo = (TopInfo2)vTop.elementAt(i);
            if (topInfo.headICON != -1)
            {
                SmallImage2.drawSmallImage(g, topInfo.headICON, num3, num4, 0, 0);
            }
            else
            {
                Part2 part = GameScr2.parts[topInfo.headID];
                SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[0][0][0]].id, num3 + part.pi[Char2.CharInfo[0][0][0]].dx, num4 + num9 - 1, 0, mGraphics2.BOTTOM | mGraphics2.LEFT);
            }
            g.setClip(xScroll, yScroll + cmy, wScroll, hScroll);
            if (topInfo.pId != Char2.myCharz().charID)
            {
                mFont2.tahoma_7b_green.drawString(g, topInfo.name, num6 + 5, num7, 0);
            }
            else
            {
                mFont2.tahoma_7b_red.drawString(g, topInfo.name, num6 + 5, num7, 0);
            }
            mFont2.tahoma_7_blue.drawString(g, topInfo.info, num6 + num8 - 5, num7 + 11, 1);
            mFont2.tahoma_7_green2.drawString(g, mResources2.rank + ": " + topInfo.rank + string.Empty, num6 + 5, num7 + 11, 0);
        }
        paintScrollArrow(g);
    }

    public void paint(mGraphics2 g)
    {
        g.translate(-g.getTranslateX(), -g.getTranslateY() + mGraphics2.addYWhenOpenKeyBoard);
        g.translate(-cmx, 0);
        g.translate(X, Y);
        if (GameCanvas2.panel.combineSuccess != -1)
        {
            if (Equals(GameCanvas2.panel))
            {
                paintCombineEff(g);
            }
            return;
        }
        GameCanvas2.paintz.paintFrameSimple(X, Y, W, H, g);
        try
        {
            paintTopInfo(g);
        }
        catch (Exception)
        {
        }
        paintBottomMoneyInfo(g);
        paintTab(g);
        switch (type)
        {
            case 9:
                paintArchivement(g);
                break;
            case 21:
            case 28:
                if (currentTabIndex == 0)
                {
                    paintPetInventory(g, type == 28);
                }
                else if (currentTabIndex == 1)
                {
                    paintPetSkill(g, type == 28);
                }
                else if (currentTabIndex == 2)
                {
                    paintPetStatus(g);
                }
                else if (currentTabIndex == 3)
                {
                    paintInventory(g);
                }
                break;
            case 24:
                paintGameSubInfo(g);
                break;
            case 23:
                paintGameInfo(g);
                break;
            case 0:
                if (currentTabIndex == 0)
                {
                    paintTask(g);
                }
                if (currentTabIndex == 1)
                {
                    paintInventory(g);
                }
                if (currentTabIndex == 2)
                {
                    paintSkill(g);
                }
                if (currentTabIndex == 3)
                {
                    if (mainTabName.Length == 4)
                    {
                        paintTools(g);
                    }
                    else
                    {
                        paintClans(g);
                    }
                }
                if (currentTabIndex == 4)
                {
                    paintTools(g);
                }
                break;
            case 2:
                if (currentTabIndex == 0)
                {
                    paintBox(g);
                }
                if (currentTabIndex == 1)
                {
                    paintInventory(g);
                }
                break;
            case 3:
                paintZone(g);
                break;
            case 1:
                paintShop(g);
                break;
            case 25:
                paintSpeacialSkill(g);
                break;
            case 4:
                paintMap(g);
                break;
            case 7:
                paintInventory(g);
                break;
            case 17:
                paintShop(g);
                break;
            case 8:
                paintLogChat(g);
                break;
            case 10:
                paintPlayerMenu(g);
                break;
            case 11:
                paintFriend(g);
                break;
            case 16:
                paintEnemy(g);
                break;
            case 15:
                paintTop(g);
                break;
            case 12:
                if (currentTabIndex == 0)
                {
                    paintCombine(g);
                }
                if (currentTabIndex == 1)
                {
                    paintInventory(g);
                }
                break;
            case 13:
                if (currentTabIndex == 0)
                {
                    if (Equals(GameCanvas2.panel))
                    {
                        paintInventory(g);
                    }
                    else
                    {
                        paintGiaoDich(g, isMe: false);
                    }
                }
                if (currentTabIndex == 1)
                {
                    paintGiaoDich(g, isMe: true);
                }
                if (currentTabIndex == 2)
                {
                    paintGiaoDich(g, isMe: false);
                }
                break;
            case 14:
                paintMapTrans(g);
                break;
            case 18:
                paintFlagChange(g);
                break;
            case 19:
                paintOption(g);
                break;
            case 20:
                paintAccount(g);
                break;
            case 22:
                paintAuto(g);
                break;
            case 26:
                PaintModFunc(g);
                break;
            case 27:
                paintPlayerInfo(g);
                break;
        }
        GameScr2.resetTranslate(g);
        paintDetail(g);
        if (cmx == cmtoX && !GameCanvas2.menu.showMenu)
        {
            cmdClose.paint(g);
        }
        if (tabIcon != null && tabIcon.isShow)
        {
            tabIcon.paint(g);
        }
        g.translate(-g.getTranslateX(), -g.getTranslateY());
        g.translate(X, Y);
        g.translate(-cmx, 0);
    }

    private void paintShop(mGraphics2 g)
    {
        try
        {
            if (type == 1 && currentTabIndex == currentTabName.Length - 1 && GameCanvas2.panel2 == null && typeShop != 2)
            {
                paintInventory(g);
                return;
            }
            g.setColor(16711680);
            g.setClip(xScroll, yScroll, wScroll, hScroll);
            if (typeShop == 2 && Equals(GameCanvas2.panel))
            {
                if (currentTabIndex <= 3 && GameCanvas2.isTouch)
                {
                    if (cmy < -50)
                    {
                        GameCanvas2.paintShukiren(xScroll + wScroll / 2, yScroll + 30, g);
                    }
                    else if (cmy < 0)
                    {
                        mFont2.tahoma_7_grey.drawString(g, mResources2.getDown, xScroll + wScroll / 2, yScroll + 15, 2);
                    }
                    else if (cmyLim >= 0)
                    {
                        if (cmy > cmyLim + 50)
                        {
                            GameCanvas2.paintShukiren(xScroll + wScroll / 2, yScroll + hScroll - 30, g);
                        }
                        else if (cmy > cmyLim)
                        {
                            mFont2.tahoma_7_grey.drawString(g, mResources2.getUp, xScroll + wScroll / 2, yScroll + hScroll - 25, 2);
                        }
                    }
                }
                if (Char2.myCharz().arrItemShop[currentTabIndex].Length == 0 && type != 17)
                {
                    mFont2.tahoma_7_grey.drawString(g, mResources2.notYetSell, xScroll + wScroll / 2, yScroll + hScroll / 2 - 10, 2);
                    return;
                }
            }
            g.translate(0, -cmy);
            Item2[] array = Char2.myCharz().arrItemShop[currentTabIndex];
            if (typeShop == 2 && (currentTabIndex == 4 || type == 17))
            {
                array = Char2.myCharz().arrItemShop[4];
                if (array.Length == 0)
                {
                    mFont2.tahoma_7_grey.drawString(g, mResources2.notYetSell, xScroll + wScroll / 2, yScroll + hScroll / 2 - 10, 2);
                    return;
                }
            }
            int num = array.Length;
            for (int i = 0; i < num; i++)
            {
                int num2 = xScroll + 26;
                int num3 = yScroll + i * ITEM_HEIGHT;
                int num4 = wScroll - 26;
                int h = ITEM_HEIGHT - 1;
                int num5 = xScroll;
                int num6 = yScroll + i * ITEM_HEIGHT;
                int num7 = 24;
                int num8 = ITEM_HEIGHT - 1;
                if (num3 - cmy > yScroll + hScroll || num3 - cmy < yScroll - ITEM_HEIGHT)
                {
                    continue;
                }
                g.setColor((i != selected) ? 15196114 : 16383818);
                g.fillRect(num2, num3, num4, h);
                g.setColor((i != selected) ? 9993045 : 9541120);
                g.fillRect(num5, num6, num7, num8);
                Item2 item = array[i];
                if (item != null)
                {
                    string text = string.Empty;
                    mFont2 mFont2 = mFont2.tahoma_7_green2;
                    if (item.isMe != 0 && typeShop == 2 && currentTabIndex <= 3 && !Equals(GameCanvas2.panel2))
                    {
                        mFont2 = mFont2.tahoma_7b_green;
                    }
                    if (item.itemOption != null)
                    {
                        for (int j = 0; j < item.itemOption.Length; j++)
                        {
                            if (item.itemOption[j].optionTemplate.id == 72)
                            {
                                text = " [+" + item.itemOption[j].param + "]";
                            }
                            if (item.itemOption[j].optionTemplate.id == 41)
                            {
                                if (item.itemOption[j].param == 1)
                                {
                                    mFont2 = GetFont(0);
                                }
                                else if (item.itemOption[j].param == 2)
                                {
                                    mFont2 = GetFont(2);
                                }
                                else if (item.itemOption[j].param == 3)
                                {
                                    mFont2 = GetFont(8);
                                }
                                else if (item.itemOption[j].param == 4)
                                {
                                    mFont2 = GetFont(7);
                                }
                            }
                        }
                    }
                    mFont2.drawString(g, "[" + item.template.id + "] " + item.template.name + text, num2 + 5, num3 + 1, 0);
                    string text2 = string.Empty;
                    if (item.itemOption != null && item.itemOption.Length >= 1)
                    {
                        if (item.itemOption[0] != null && item.itemOption[0].optionTemplate.id != 102 && item.itemOption[0].optionTemplate.id != 107)
                        {
                            text2 += item.itemOption[0].getOptionString();
                        }
                        mFont2 mFont3 = mFont2.tahoma_7_blue;
                        if (item.compare < 0 && item.template.type != 5)
                        {
                            mFont3 = mFont2.tahoma_7_red;
                        }
                        if (typeShop == 2 && item.itemOption.Length > 1 && item.buyType != -1)
                        {
                            text2 += string.Empty;
                        }
                        if (typeShop != 2 || (typeShop == 2 && item.buyType <= 1))
                        {
                            mFont3.drawString(g, text2, num2 + 5, num3 + 11, 0);
                        }
                    }
                    if (item.buySpec > 0)
                    {
                        SmallImage2.drawSmallImage(g, item.iconSpec, num2 + num4 - 7, num3 + 9, 0, 3);
                        mFont2.tahoma_7b_blue.drawString(g, Res2.formatNumber(item.buySpec), num2 + num4 - 15, num3 + 1, mFont2.RIGHT);
                    }
                    if (item.buyCoin != 0 || item.buyGold != 0)
                    {
                        if (typeShop != 2 && item.powerRequire == 0)
                        {
                            if (item.buyCoin > 0 && item.buyGold > 0)
                            {
                                if (item.buyCoin > 0)
                                {
                                    g.drawImage(imgXu, num2 + num4 - 7, num3 + 7, 3);
                                    mFont2 = (Char2.myCharz().thoiVang >= item.buyCoin) ? mFont2.tahoma_7b_yellow : mFont2.tahoma_7b_red;
                                    mFont2.drawString(g, Res2.formatNumber2(item.buyCoin), num2 + num4 - 15, num3 + 1, mFont2.RIGHT);
                                }
                                if (item.buyGold > 0)
                                {
                                    g.drawImage(imgLuong, num2 + num4 - 7, num3 + 7 + 11, 3);
                                    mFont2 = (Char2.myCharz().luong >= item.buyGold) ? mFont2.tahoma_7b_green : mFont2.tahoma_7b_red;
                                    mFont2.drawString(g, Res2.formatNumber2(item.buyGold), num2 + num4 - 15, num3 + 12, mFont2.RIGHT);
                                }
                            }
                            else
                            {
                                if (item.buyCoin > 0)
                                {
                                    g.drawImage(imgXu, num2 + num4 - 7, num3 + 7, 3);
                                    mFont2 = (Char2.myCharz().thoiVang >= item.buyCoin) ? mFont2.tahoma_7b_yellow : mFont2.tahoma_7b_red;
                                    mFont2.drawString(g, Res2.formatNumber2(item.buyCoin), num2 + num4 - 15, num3 + 1, mFont2.RIGHT);
                                }
                                if (item.buyGold > 0)
                                {
                                    g.drawImage(imgLuong, num2 + num4 - 7, num3 + 7, 3);
                                    mFont2 = (Char2.myCharz().luong >= item.buyGold) ? mFont2.tahoma_7b_green : mFont2.tahoma_7b_red;
                                    mFont2.drawString(g, Res2.formatNumber2(item.buyGold), num2 + num4 - 15, num3 + 1, mFont2.RIGHT);
                                }
                                try
                                {
                                    if (MainMod.readNameKiGui && !Char2.myCharz().cName.Equals(item.nameNguoiKyGui))
                                    {
                                        mFont2 = mFont2.tahoma_7b_green;
                                        mFont2.drawString(g, item.nameNguoiKyGui, num2 + num4, num3 + 1 + mFont2.tahoma_7b_red.getHeight(), mFont2.RIGHT);
                                    }
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                        if (typeShop == 2 && currentTabIndex <= 3 && !Equals(GameCanvas2.panel2))
                        {
                            if (item.buyCoin > 0 && item.buyGold > 0)
                            {
                                if (item.buyCoin > 0)
                                {
                                    g.drawImage(imgThoivang, num2 + num4 - 7, num3 + 7, 3); // HERE
                                    mFont2.tahoma_7b_yellow.drawString(g, Res2.formatNumber2(item.buyCoin), num2 + num4 - 15, num3 + 1, mFont2.RIGHT);
                                }
                                if (item.buyGold > 0)
                                {
                                    g.drawImage(imgLuong, num2 + num4 - 7, num3 + 7 + 11, 3);
                                    mFont2.tahoma_7b_green.drawString(g, Res2.formatNumber2(item.buyGold), num2 + num4 - 15, num3 + 12, mFont2.RIGHT);
                                }
                            }
                            else
                            {
                                if (item.buyCoin > 0)
                                {
                                    g.drawImage(imgThoivang, num2 + num4 - 7, num3 + 7, 3); // HERE
                                    mFont2.tahoma_7b_yellow.drawString(g, Res2.formatNumber2(item.buyCoin), num2 + num4 - 15, num3 + 1, mFont2.RIGHT);
                                }
                                if (item.buyGold > 0)
                                {
                                    g.drawImage(imgLuong, num2 + num4 - 7, num3 + 7, 3);
                                    mFont2.tahoma_7b_green.drawString(g, Res2.formatNumber2(item.buyGold), num2 + num4 - 15, num3 + 1, mFont2.RIGHT);
                                }
                            }
                        }
                    }
                    SmallImage2.drawSmallImage(g, item.template.iconID, num5 + num7 / 2, num6 + num8 / 2, 0, 3);
                    if (item.quantity > 1)
                    {
                        mFont2.tahoma_7_yellow.drawString(g, string.Empty + item.quantity, num5 + num7, num6 + num8 - mFont2.tahoma_7_yellow.getHeight(), 1);
                    }
                    if (item.newItem && GameCanvas2.gameTick % 10 > 5)
                    {
                        g.drawImage(imgNew, num5 + num7 / 2, num3 + 19, 3);
                    }
                }
                if (typeShop != 2 || (!Equals(GameCanvas2.panel2) && currentTabIndex != 4) || item.buyType == 0)
                {
                    continue;
                }
                if (item.buyType == 1)
                {
                    mFont2.tahoma_7_green.drawString(g, mResources2.dangban, num2 + num4 - 5, num3 + 1, mFont2.RIGHT);
                    if (item.buyCoin != -1)
                    {
                        g.drawImage(imgThoivang, num2 + num4 - 7, num3 + 19, 3);
                        mFont2.tahoma_7b_yellow.drawString(g, Res2.formatNumber2(item.buyCoin), num2 + num4 - 15, num3 + 13, mFont2.RIGHT);
                    }
                    else if (item.buyGold != -1)
                    {
                        g.drawImage(imgLuongKhoa, num2 + num4 - 7, num3 + 17, 3);
                        mFont2.tahoma_7b_red.drawString(g, Res2.formatNumber2(item.buyGold), num2 + num4 - 15, num3 + 11, mFont2.RIGHT);
                    }
                }
                else if (item.buyType == 2)
                {
                    mFont2.tahoma_7b_blue.drawString(g, mResources2.daban, num2 + num4 - 5, num3 + 1, mFont2.RIGHT);
                    if (item.buyCoin != -1)
                    {
                        g.drawImage(imgThoivang, num2 + num4 - 7, num3 + 17, 3);
                        mFont2.tahoma_7b_yellow.drawString(g, Res2.formatNumber2(item.buyCoin), num2 + num4 - 15, num3 + 11, mFont2.RIGHT);
                    }
                    else if (item.buyGold != -1)
                    {
                        g.drawImage(imgLuongKhoa, num2 + num4 - 7, num3 + 17, 3);
                        mFont2.tahoma_7b_red.drawString(g, Res2.formatNumber2(item.buyGold), num2 + num4 - 15, num3 + 11, mFont2.RIGHT);
                    }
                }
            }
            paintScrollArrow(g);
        }
        catch (Exception)
        {
        }
    }

    private void paintAuto(mGraphics2 g)
    {
    }

    private void paintPetStatus(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        for (int i = 0; i < strStatus.Length; i++)
        {
            int x = xScroll;
            int num = yScroll + i * ITEM_HEIGHT;
            int num2 = wScroll - 1;
            int h = ITEM_HEIGHT - 1;
            if (num - cmy <= yScroll + hScroll && num - cmy >= yScroll - ITEM_HEIGHT)
            {
                g.setColor((i != selected) ? 15196114 : 16383818);
                g.fillRect(x, num, num2, h);
                mFont2.tahoma_7b_dark.drawString(g, strStatus[i], xScroll + wScroll / 2, num + 6, mFont2.CENTER);
            }
        }
        paintScrollArrow(g);
    }

    private void paintPetSkill(mGraphics2 g, bool isPet2)
    {
        g.setColor(16711680);
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        Char2 pet = isPet2 ? Char2.MyPet2z() : Char2.myPetz();
        int num = 5 + pet.arrPetSkill.Length;
        for (int i = 0; i < num; i++)
        {
            int num2 = xScroll + 30;
            int num3 = yScroll + i * ITEM_HEIGHT;
            int num4 = wScroll - 30;
            int h = ITEM_HEIGHT - 1;
            int num5 = xScroll;
            int num6 = yScroll + i * ITEM_HEIGHT;
            _ = ITEM_HEIGHT - 1;
            if (num3 - cmy > yScroll + hScroll || num3 - cmy < yScroll - ITEM_HEIGHT)
            {
                continue;
            }
            g.setColor((i != selected) ? 15196114 : 16383818);
            if (i >= 5)
            {
                g.setColor((i != selected) ? 16765060 : 16776068);
            }
            g.fillRect(num2, num3, num4, h);
            g.drawImage(GameScr2.imgSkill, num5, num6, 0);
            if (i == 0)
            {
                SmallImage2.drawSmallImage(g, 567, num5 + 4, num6 + 4, 0, 0);
                string st = mResources2.HP + " " + mResources2.root + ": " + NinjaUtil2.getMoneys(pet.cHPGoc);
                mFont2.tahoma_7b_blue.drawString(g, st, num2 + 5, num3 + 3, 0);
                mFont2.tahoma_7_green2.drawString(g, NinjaUtil2.getMoneys(pet.cHPGoc + 1000) + " " + mResources2.potential + ": " + mResources2.increase + " " + pet.hpFrom1000TiemNang, num2 + 5, num3 + 15, 0);
            }
            if (i == 1)
            {
                SmallImage2.drawSmallImage(g, 569, num5 + 4, num6 + 4, 0, 0);
                string st2 = mResources2.KI + " " + mResources2.root + ": " + NinjaUtil2.getMoneys(pet.cMPGoc);
                mFont2.tahoma_7b_blue.drawString(g, st2, num2 + 5, num3 + 3, 0);
                mFont2.tahoma_7_green2.drawString(g, NinjaUtil2.getMoneys(pet.cMPGoc + 1000) + " " + mResources2.potential + ": " + mResources2.increase + " " + pet.mpFrom1000TiemNang, num2 + 5, num3 + 15, 0);
            }
            if (i == 2)
            {
                SmallImage2.drawSmallImage(g, 568, num5 + 4, num6 + 4, 0, 0);
                string st3 = mResources2.hit_point + " " + mResources2.root + ": " + NinjaUtil2.getMoneys(pet.cDamGoc);
                mFont2.tahoma_7b_blue.drawString(g, st3, num2 + 5, num3 + 3, 0);
                mFont2.tahoma_7_green2.drawString(g, NinjaUtil2.getMoneys(pet.cDamGoc * 100) + " " + mResources2.potential + ": " + mResources2.increase + " " + pet.damFrom1000TiemNang, num2 + 5, num3 + 15, 0);
            }
            if (i == 3)
            {
                SmallImage2.drawSmallImage(g, 721, num5 + 4, num6 + 4, 0, 0);
                string st4 = mResources2.armor + " " + mResources2.root + ": " + NinjaUtil2.getMoneys(pet.cDefGoc);
                mFont2.tahoma_7b_blue.drawString(g, st4, num2 + 5, num3 + 3, 0);
                mFont2.tahoma_7_green2.drawString(g, NinjaUtil2.getMoneys(500000 + pet.cDefGoc * 100000) + " " + mResources2.potential + ": " + mResources2.increase + " " + pet.defFrom1000TiemNang, num2 + 5, num3 + 15, 0);
            }
            if (i == 4)
            {
                SmallImage2.drawSmallImage(g, 719, num5 + 4, num6 + 4, 0, 0);
                string st5 = mResources2.critical + " " + mResources2.root + ": " + pet.cCriticalGoc + "%";
                int num10 = pet.cCriticalGoc;
                if (num10 > t_tiemnang.Length - 1)
                {
                    num10 = t_tiemnang.Length - 1;
                }
                long num9 = t_tiemnang[num10];
                mFont2.tahoma_7b_blue.drawString(g, st5, num2 + 5, num3 + 3, 0);
                long number = num9;
                mFont2.tahoma_7_green2.drawString(g, Res2.formatNumber2(number) + " " + mResources2.potential + ": " + mResources2.increase + " " + pet.criticalFrom1000Tiemnang, num2 + 5, num3 + 15, 0);
            }
            if (i < 5)
            {
                continue;
            }
            Skill2 skill = pet.arrPetSkill[i - 5];
            g.drawImage(GameScr2.imgSkill2, num5, num6, 0);
            if (skill.template != null)
            {
                mFont2.tahoma_7_blue.drawString(g, skill.template.name, num2 + 5, num3 + 3, 0);
                mFont2.tahoma_7_green2.drawString(g, mResources2.level + ": " + skill.point, num2 + 5, num3 + 15, 0);
                SmallImage2.drawSmallImage(g, skill.template.iconId, num5 + 4, num6 + 4, 0, 0);
            }
            else
            {
                mFont2.tahoma_7_green2.drawString(g, skill.moreInfo, num2 + 5, num3 + 3, 0);
                mFont2.tahoma_7_green2.drawString(g, mResources2.level + ": " + 0, num2 + 5, num3 + 15, 0);
                SmallImage2.drawSmallImage(g, GameScr2.efs[98].arrEfInfo[0].idImg, num5 + 8, num6 + 7, 0, 0);
            }
        }
        paintScrollArrow(g);
    }

    private void paintPetInventory(mGraphics2 g, bool isPet2)
    {
        g.setColor(16711680);
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        Item2[] arrItemBody = (isPet2 ? Char2.MyPet2z() : Char2.myPetz()).arrItemBody;
        for (int i = 0; i < arrItemBody.Length; i++)
        {
            int num = i;
            _ = i - arrItemBody.Length;
            int num3 = xScroll + 36;
            int num4 = yScroll + i * ITEM_HEIGHT;
            int num5 = wScroll - 36;
            int h = ITEM_HEIGHT - 1;
            int num6 = xScroll;
            int num7 = yScroll + i * ITEM_HEIGHT;
            int num8 = 34;
            int num9 = ITEM_HEIGHT - 1;
            if (num4 - cmy > yScroll + hScroll || num4 - cmy < yScroll - ITEM_HEIGHT)
            {
                continue;
            }
            Item2 item = arrItemBody[num];
            g.setColor((i == selected) ? 16383818 : 15196114);
            g.fillRect(num3, num4, num5, h);
            g.setColor((i == selected) ? 9541120 : 9993045);
            if (item != null)
            {
                for (int j = 0; j < item.itemOption.Length; j++)
                {
                    if (item.itemOption[j].optionTemplate.id == 72 && item.itemOption[j].param > 0)
                    {
                        sbyte color_Item_Upgrade = GetColor_Item_Upgrade(item.itemOption[j].param);
                        int color_ItemBg = GetColor_ItemBg(color_Item_Upgrade);
                        if (color_ItemBg != -1)
                        {
                            g.setColor((i != selected) ? GetColor_ItemBg(color_Item_Upgrade) : GetColor_ItemBg(color_Item_Upgrade));
                        }
                    }
                }
            }
            g.fillRect(num6, num7, num8, num9);
            if (item != null && item.isSelect && GameCanvas2.panel.type == 12)
            {
                g.setColor((i != selected) ? 6047789 : 7040779);
                g.fillRect(num6, num7, num8, num9);
            }
            if (item != null)
            {
                string text = string.Empty;
                mFont2 mFont2 = mFont2.tahoma_7_green2;
                if (item.itemOption != null)
                {
                    for (int k = 0; k < item.itemOption.Length; k++)
                    {
                        if (item.itemOption[k].optionTemplate.id == 72)
                        {
                            text = " [+" + item.itemOption[k].param + "]";
                        }
                        if (item.itemOption[k].optionTemplate.id == 41)
                        {
                            if (item.itemOption[k].param == 1)
                            {
                                mFont2 = GetFont(0);
                            }
                            else if (item.itemOption[k].param == 2)
                            {
                                mFont2 = GetFont(2);
                            }
                            else if (item.itemOption[k].param == 3)
                            {
                                mFont2 = GetFont(8);
                            }
                            else if (item.itemOption[k].param == 4)
                            {
                                mFont2 = GetFont(7);
                            }
                        }
                    }
                }
                mFont2.drawString(g, "[" + item.template.id + "] " + item.template.name + text, num3 + 5, num4 + 1, 0);
                string text2 = string.Empty;
                if (item.itemOption != null)
                {
                    if (item.itemOption.Length > 0 && item.itemOption[0] != null && item.itemOption[0].optionTemplate.id != 102 && item.itemOption[0].optionTemplate.id != 107)
                    {
                        text2 += item.itemOption[0].getOptionString();
                    }
                    mFont2 mFont3 = mFont2.tahoma_7_blue;
                    if (item.compare < 0 && item.template.type != 5)
                    {
                        mFont3 = mFont2.tahoma_7_red;
                    }
                    if (item.itemOption.Length > 1)
                    {
                        for (int l = 1; l < 2; l++)
                        {
                            if (item.itemOption[l] != null && item.itemOption[l].optionTemplate.id != 102 && item.itemOption[l].optionTemplate.id != 107)
                            {
                                text2 = text2 + "," + item.itemOption[l].getOptionString();
                            }
                        }
                    }
                    mFont3.drawString(g, text2, num3 + 5, num4 + 11, mFont2.LEFT);
                }
                SmallImage2.drawSmallImage(g, item.template.iconID, num6 + num8 / 2, num7 + num9 / 2, 0, 3);
                if (item.itemOption != null)
                {
                    for (int m = 0; m < item.itemOption.Length; m++)
                    {
                        paintOptItem(g, item.itemOption[m].optionTemplate.id, item.itemOption[m].param, num6, num7, num8, num9);
                    }
                    for (int n = 0; n < item.itemOption.Length; n++)
                    {
                        paintOptSlotItem(g, item.itemOption[n].optionTemplate.id, item.itemOption[n].param, num6, num7, num8, num9);
                    }
                }
                if (item.quantity > 1)
                {
                    mFont2.tahoma_7_yellow.drawString(g, string.Empty + item.quantity, num6 + num8, num7 + num9 - mFont2.tahoma_7_yellow.getHeight(), 1);
                }
            }
        }
        paintScrollArrow(g);
    }

    private void paintScrollArrow(mGraphics2 g)
    {
        g.translate(-g.getTranslateX(), -g.getTranslateY());
        if ((cmy > 24 && currentListLength > 0) || (Equals(GameCanvas2.panel) && typeShop == 2 && maxPageShop[currentTabIndex] > 1))
        {
            g.drawRegion(Mob2.imgHP, 0, 0, 9, 6, 1, xScroll + wScroll - 12, yScroll + 3, 0);
        }
        if ((cmy < cmyLim && currentListLength > 0) || (Equals(GameCanvas2.panel) && typeShop == 2 && maxPageShop[currentTabIndex] > 1))
        {
            g.drawRegion(Mob2.imgHP, 0, 0, 9, 6, 0, xScroll + wScroll - 12, yScroll + hScroll - 8, 0);
        }
    }

    private void paintTools(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        for (int i = 0; i < strTool.Length; i++)
        {
            int num = xScroll;
            int num2 = yScroll + i * ITEM_HEIGHT;
            int num3 = wScroll - 1;
            int h = ITEM_HEIGHT - 1;
            if (num2 - cmy > yScroll + hScroll || num2 - cmy < yScroll - ITEM_HEIGHT)
            {
                continue;
            }
            g.setColor((i != selected) ? 15196114 : 16383818);
            g.fillRect(num, num2, num3, h);
            mFont2.tahoma_7b_dark.drawString(g, strTool[i], xScroll + wScroll / 2, num2 + 6, mFont2.CENTER);
            if (!strTool[i].Equals(mResources2.gameInfo))
            {
                continue;
            }
            for (int j = 0; j < vGameInfo.size(); j++)
            {
                GameInfo2 gameInfo = (GameInfo2)vGameInfo.elementAt(j);
                if (!gameInfo.hasRead)
                {
                    if (GameCanvas2.gameTick % 20 > 10)
                    {
                        g.drawImage(imgNew, num + 10, num2 + 10, 3);
                    }
                    break;
                }
            }
        }
        paintScrollArrow(g);
    }

    private void paintGameSubInfo(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        for (int i = 0; i < contenInfo.Length; i++)
        {
            int num = xScroll;
            int num2 = yScroll + i * 15;
            int num3 = wScroll - 1;
            int num4 = ITEM_HEIGHT - 1;
            if (num2 - cmy <= yScroll + hScroll && num2 - cmy >= yScroll - ITEM_HEIGHT)
            {
                mFont2.tahoma_7b_dark.drawString(g, contenInfo[i], xScroll + 5, num2 + 6, mFont2.LEFT);
            }
        }
        paintScrollArrow(g);
    }

    private void paintPlayerInfo(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        for (int i = 0; i < contenInfo.Length; i++)
        {
            int num = xScroll;
            int num2 = yScroll + i * 15;
            int num3 = wScroll - 1;
            int num4 = ITEM_HEIGHT - 1;
            if (num2 - cmy <= yScroll + hScroll && num2 - cmy >= yScroll - ITEM_HEIGHT)
            {
                mFont2.tahoma_7b_dark.drawString(g, contenInfo[i], xScroll + 5, num2 + 6, mFont2.LEFT);
            }
        }
        paintScrollArrow(g);
    }

    private void paintGameInfo(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        for (int i = 0; i < vGameInfo.size(); i++)
        {
            GameInfo2 gameInfo = (GameInfo2)vGameInfo.elementAt(i);
            int num = xScroll;
            int num2 = yScroll + i * ITEM_HEIGHT;
            int num3 = wScroll - 1;
            int h = ITEM_HEIGHT - 1;
            if (num2 - cmy <= yScroll + hScroll && num2 - cmy >= yScroll - ITEM_HEIGHT)
            {
                g.setColor((i != selected) ? 15196114 : 16383818);
                g.fillRect(num, num2, num3, h);
                mFont2.tahoma_7b_dark.drawString(g, gameInfo.main, xScroll + wScroll / 2, num2 + 6, mFont2.CENTER);
                if (!gameInfo.hasRead && GameCanvas2.gameTick % 20 > 10)
                {
                    g.drawImage(imgNew, num + 10, num2 + 10, 3);
                }
            }
        }
        paintScrollArrow(g);
    }

    private void paintSkill(mGraphics2 g)
    {
        g.setColor(16711680);
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        int num = Char2.myCharz().nClass.skillTemplates.Length;
        for (int i = 0; i < num + 6; i++)
        {
            int num2 = xScroll + 30;
            int num3 = yScroll + i * ITEM_HEIGHT;
            int num4 = wScroll - 30;
            int h = ITEM_HEIGHT - 1;
            int num5 = xScroll;
            int num6 = yScroll + i * ITEM_HEIGHT;
            _ = ITEM_HEIGHT - 1;
            if (num3 - cmy > yScroll + hScroll || num3 - cmy < yScroll - ITEM_HEIGHT)
            {
                continue;
            }
            g.setColor((i != selected) ? 15196114 : 16383818);
            if (i == 5)
            {
                g.setColor((i != selected) ? 16765060 : 16776068);
            }
            g.fillRect(num2, num3, num4, h);
            g.drawImage(GameScr2.imgSkill, num5, num6, 0);
            if (i == 0)
            {
                SmallImage2.drawSmallImage(g, 567, num5 + 4, num6 + 4, 0, 0);
                string st = mResources2.HP + " " + mResources2.root + ": " + NinjaUtil2.getMoneys(Char2.myCharz().cHPGoc);
                mFont2.tahoma_7b_blue.drawString(g, st, num2 + 5, num3 + 3, 0);
                mFont2.tahoma_7_green2.drawString(g, NinjaUtil2.getMoneys(Char2.myCharz().cHPGoc + 1000) + " " + mResources2.potential + ": " + mResources2.increase + " " + Char2.myCharz().hpFrom1000TiemNang, num2 + 5, num3 + 15, 0);
            }
            if (i == 1)
            {
                SmallImage2.drawSmallImage(g, 569, num5 + 4, num6 + 4, 0, 0);
                string st2 = mResources2.KI + " " + mResources2.root + ": " + NinjaUtil2.getMoneys(Char2.myCharz().cMPGoc);
                mFont2.tahoma_7b_blue.drawString(g, st2, num2 + 5, num3 + 3, 0);
                mFont2.tahoma_7_green2.drawString(g, NinjaUtil2.getMoneys(Char2.myCharz().cMPGoc + 1000) + " " + mResources2.potential + ": " + mResources2.increase + " " + Char2.myCharz().mpFrom1000TiemNang, num2 + 5, num3 + 15, 0);
            }
            if (i == 2)
            {
                SmallImage2.drawSmallImage(g, 568, num5 + 4, num6 + 4, 0, 0);
                string st3 = mResources2.hit_point + " " + mResources2.root + ": " + NinjaUtil2.getMoneys(Char2.myCharz().cDamGoc);
                mFont2.tahoma_7b_blue.drawString(g, st3, num2 + 5, num3 + 3, 0);
                mFont2.tahoma_7_green2.drawString(g, NinjaUtil2.getMoneys(Char2.myCharz().cDamGoc * 100) + " " + mResources2.potential + ": " + mResources2.increase + " " + Char2.myCharz().damFrom1000TiemNang, num2 + 5, num3 + 15, 0);
            }
            if (i == 3)
            {
                SmallImage2.drawSmallImage(g, 721, num5 + 4, num6 + 4, 0, 0);
                string st4 = mResources2.armor + " " + mResources2.root + ": " + NinjaUtil2.getMoneys(Char2.myCharz().cDefGoc);
                mFont2.tahoma_7b_blue.drawString(g, st4, num2 + 5, num3 + 3, 0);
                mFont2.tahoma_7_green2.drawString(g, NinjaUtil2.getMoneys(500000 + Char2.myCharz().cDefGoc * 100000) + " " + mResources2.potential + ": " + mResources2.increase + " " + Char2.myCharz().defFrom1000TiemNang, num2 + 5, num3 + 15, 0);
            }
            if (i == 4)
            {
                SmallImage2.drawSmallImage(g, 719, num5 + 4, num6 + 4, 0, 0);
                string st5 = mResources2.critical + " " + mResources2.root + ": " + Char2.myCharz().cCriticalGoc + "%";
                long num9 = 50000000L;
                int num10 = Char2.myCharz().cCriticalGoc;
                if (num10 > t_tiemnang.Length - 1)
                {
                    num10 = t_tiemnang.Length - 1;
                }
                num9 = t_tiemnang[num10];
                mFont2.tahoma_7b_blue.drawString(g, st5, num2 + 5, num3 + 3, 0);
                long number = num9;
                mFont2.tahoma_7_green2.drawString(g, Res2.formatNumber2(number) + " " + mResources2.potential + ": " + mResources2.increase + " " + Char2.myCharz().criticalFrom1000Tiemnang, num2 + 5, num3 + 15, 0);
            }
            if (i == 5)
            {
                if (specialInfo != null)
                {
                    SmallImage2.drawSmallImage(g, spearcialImage, num5 + 4, num6 + 4, 0, 0);
                    string[] array = mFont2.tahoma_7.splitFontArray(specialInfo, 120);
                    for (int j = 0; j < array.Length; j++)
                    {
                        mFont2.tahoma_7_green2.drawString(g, array[j], num2 + 5, num3 + 3 + j * 12, 0);
                    }
                }
                else
                {
                    mFont2.tahoma_7_green2.drawString(g, string.Empty, num2 + 5, num3 + 9, 0);
                }
            }
            if (i < 6)
            {
                continue;
            }
            int num11 = i - 6;
            SkillTemplate2 skillTemplate = Char2.myCharz().nClass.skillTemplates[num11];
            SmallImage2.drawSmallImage(g, skillTemplate.iconId, num5 + 4, num6 + 4, 0, 0);
            Skill2 skill = Char2.myCharz().getSkill(skillTemplate);
            if (skill != null)
            {
                mFont2.tahoma_7b_blue.drawString(g, skillTemplate.name, num2 + 5, num3 + 3, 0);
                mFont2.tahoma_7_blue.drawString(g, mResources2.level + ": " + skill.point, num2 + num4 - 5, num3 + 3, mFont2.RIGHT);
                if (skill.point == skillTemplate.maxPoint)
                {
                    mFont2.tahoma_7_green2.drawString(g, mResources2.max_level_reach, num2 + 5, num3 + 15, 0);
                }
                else if (skill.template.isSkillSpec())
                {
                    string text = mResources2.proficiency + ": ";
                    int x = mFont2.tahoma_7_green2.getWidthExactOf(text) + num2 + 5;
                    int num12 = num3 + 15;
                    mFont2.tahoma_7_green2.drawString(g, text, num2 + 5, num12, 0);
                    mFont2.tahoma_7_green2.drawString(g, "(" + skill.strCurExp() + ")", num2 + num4 - 5, num12, mFont2.RIGHT);
                    num12 += 4;
                    g.setColor(7169134);
                    g.fillRect(x, num12, 50, 5);
                    int num13 = skill.curExp * 50 / 1000;
                    g.setColor(11992374);
                    g.fillRect(x, num12, num13, 5);
                    if (skill.curExp < 1000)
                    {
                    }
                }
                else
                {
                    Skill2 skill2 = skillTemplate.skills[skill.point];
                    mFont2.tahoma_7_green2.drawString(g, mResources2.level + " " + (skill.point + 1) + " " + mResources2.need + " " + Res2.formatNumber2(skill2.powRequire) + " " + mResources2.potential, num2 + 5, num3 + 15, 0);
                }
            }
            else
            {
                Skill2 skill3 = skillTemplate.skills[0];
                string st6 = mResources2.need_upper + " " + Res2.formatNumber2(skill3.powRequire) + " " + mResources2.potential_to_learn;
                if (skill3.template.id == 24 || skill3.template.id == 25 || skill3.template.id == 26)
                {
                    st6 = mResources2.need_upper + " " + Res2.formatNumber2(skill3.powRequire) + " " + mResources2.potential_to_learn_Whis;
                }
                mFont2.tahoma_7b_green.drawString(g, skillTemplate.name, num2 + 5, num3 + 3, 0);
                mFont2.tahoma_7_green2.drawString(g, st6, num2 + 5, num3 + 15, 0);
            }
        }
        paintScrollArrow(g);
    }

    private void paintMapTrans(mGraphics2 g)
    {
        g.setColor(16711680);
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        for (int i = 0; i < mapNames.Length; i++)
        {
            int num = xScroll + 36;
            int num2 = yScroll + i * ITEM_HEIGHT;
            int num3 = wScroll - 36;
            int h = ITEM_HEIGHT - 1;
            int num4 = xScroll;
            int num5 = yScroll + i * ITEM_HEIGHT;
            int num7 = ITEM_HEIGHT - 1;
            if (num2 - cmy <= yScroll + hScroll && num2 - cmy >= yScroll - ITEM_HEIGHT)
            {
                g.setColor((i != selected) ? 15196114 : 16383818);
                g.fillRect(xScroll, num2, wScroll, h);
                mFont2.tahoma_7b_blue.drawString(g, mapNames[i], 5, num2 + 1, 0);
                mFont2.tahoma_7_grey.drawString(g, planetNames[i], 5, num2 + 11, 0);
            }
        }
        paintScrollArrow(g);
    }

    private void paintZone(mGraphics2 g)
    {
        g.setColor(16711680);
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        int[] zones = GameScr2.gI().zones;
        int[] pts = GameScr2.gI().pts;
        for (int i = 0; i < pts.Length; i++)
        {
            int num = xScroll + 36;
            int num2 = yScroll + i * ITEM_HEIGHT;
            int num3 = wScroll - 36;
            int h = ITEM_HEIGHT - 1;
            int num4 = xScroll;
            int y = yScroll + i * ITEM_HEIGHT;
            int num5 = 34;
            int h2 = ITEM_HEIGHT - 1;
            if (num2 - cmy > yScroll + hScroll || num2 - cmy < yScroll - ITEM_HEIGHT)
            {
                continue;
            }
            g.setColor((i != selected) ? 15196114 : 16383818);
            g.fillRect(num, num2, num3, h);
            g.setColor(zoneColor[pts[i]]);
            g.fillRect(num4, y, num5, h2);
            if (zones[i] != -1)
            {
                if (pts[i] != 1)
                {
                    mFont2.tahoma_7_yellow.drawString(g, zones[i] + string.Empty, num4 + num5 / 2, num2 + 6, mFont2.CENTER);
                }
                else
                {
                    mFont2.tahoma_7_grey.drawString(g, zones[i] + string.Empty, num4 + num5 / 2, num2 + 6, mFont2.CENTER);
                }
                mFont2.tahoma_7_green2.drawString(g, GameScr2.gI().numPlayer[i] + "/" + GameScr2.gI().maxPlayer[i], num + 5, num2 + 6, 0);
            }
            if (GameScr2.gI().rankName1[i] != null)
            {
                mFont2.tahoma_7_grey.drawString(g, GameScr2.gI().rankName1[i] + "(Top " + GameScr2.gI().rank1[i] + ")", num + num3 - 2, num2 + 1, mFont2.RIGHT);
                mFont2.tahoma_7_grey.drawString(g, GameScr2.gI().rankName2[i] + "(Top " + GameScr2.gI().rank2[i] + ")", num + num3 - 2, num2 + 11, mFont2.RIGHT);
            }
        }
        paintScrollArrow(g);
    }

    private void paintSpeacialSkill(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        g.setColor(0);
        if (currentListLength == 0)
        {
            return;
        }
        int num = (cmy + hScroll) / 24 + 1;
        if (num < hScroll / 24 + 1)
        {
            num = hScroll / 24 + 1;
        }
        if (num > currentListLength)
        {
            num = currentListLength;
        }
        int num2 = cmy / 24;
        if (num2 >= num)
        {
            num2 = num - 1;
        }
        if (num2 < 0)
        {
            num2 = 0;
        }
        for (int i = num2; i < num; i++)
        {
            int num3 = xScroll;
            int num4 = yScroll + i * ITEM_HEIGHT;
            int num5 = 24;
            int num6 = ITEM_HEIGHT - 1;
            int num7 = xScroll + num5;
            int num8 = yScroll + i * ITEM_HEIGHT;
            int num9 = wScroll - num5;
            int h = ITEM_HEIGHT - 1;
            g.setColor((i != selected) ? 15196114 : 16383818);
            g.fillRect(num7, num8, num9, h);
            g.setColor((i != selected) ? 9993045 : 9541120);
            g.fillRect(num3, num4, num5, num6);
            SmallImage2.drawSmallImage(g, Char2.myCharz().imgSpeacialSkill[currentTabIndex][i], num3 + num5 / 2, num4 + num6 / 2, 0, 3);
            string[] array = mFont2.tahoma_7_grey.splitFontArray(Char2.myCharz().infoSpeacialSkill[currentTabIndex][i], 140);
            for (int j = 0; j < array.Length; j++)
            {
                mFont2.tahoma_7_grey.drawString(g, array[j], num7 + 5, num8 + 1 + j * 11, 0);
            }
        }
        paintScrollArrow(g);
    }

    private void paintBox(mGraphics2 g)
    {
        g.setColor(16711680);
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        try
        {
            Item2[] arrItemBox = Char2.myCharz().arrItemBox;
            currentListLength = checkCurrentListLength(arrItemBox.Length);
            int num = arrItemBox.Length / 20 + ((arrItemBox.Length % 20 > 0) ? 1 : 0);
            TAB_W_NEW = wScroll / num;
            for (int i = 0; i < currentListLength; i++)
            {
                int num2 = xScroll + 36;
                int num3 = yScroll + i * ITEM_HEIGHT;
                int num4 = wScroll - 36;
                int h = ITEM_HEIGHT - 1;
                int num5 = xScroll;
                int num6 = yScroll + i * ITEM_HEIGHT;
                int num7 = 34;
                int num8 = ITEM_HEIGHT - 1;
                if (num3 - cmy > yScroll + hScroll || num3 - cmy < yScroll - ITEM_HEIGHT)
                {
                    continue;
                }
                if (i == 0)
                {
                    for (int j = 0; j < num; j++)
                    {
                        int num9 = ((j == newSelected && selected == 0) ? ((GameCanvas2.gameTick % 10 < 7) ? (-1) : 0) : 0);
                        g.setColor((j != newSelected) ? 15723751 : 16383818);
                        g.fillRect(xScroll + j * TAB_W_NEW, num3 + 9 + num9, TAB_W_NEW - 1, 14);
                        global::mFont2.tahoma_7_grey.drawString(g, string.Empty + j, xScroll + j * TAB_W_NEW + TAB_W_NEW / 2, yScroll + 11 + num9, global::mFont2.CENTER);
                    }
                    continue;
                }
                g.setColor((i != selected) ? 15196114 : 16383818);
                g.fillRect(num2, num3, num4, h);
                g.setColor((i != selected) ? 9993045 : 9541120);
                int inventorySelect_body = GetInventorySelect_body(i, newSelected);
                Item2 item = arrItemBox[inventorySelect_body];
                if (item != null)
                {
                    for (int k = 0; k < item.itemOption.Length; k++)
                    {
                        if (item.itemOption[k].optionTemplate.id == 72 && item.itemOption[k].param > 0)
                        {
                            sbyte color_Item_Upgrade = GetColor_Item_Upgrade(item.itemOption[k].param);
                            int color_ItemBg = GetColor_ItemBg(color_Item_Upgrade);
                            if (color_ItemBg != -1)
                            {
                                g.setColor((i != selected) ? GetColor_ItemBg(color_Item_Upgrade) : GetColor_ItemBg(color_Item_Upgrade));
                            }
                        }
                    }
                }
                g.fillRect(num5, num6, num7, num8);
                if (item == null)
                {
                    continue;
                }
                string text = string.Empty;
                mFont2 mFont2 = mFont2.tahoma_7_green2;
                if (item.itemOption != null)
                {
                    for (int l = 0; l < item.itemOption.Length; l++)
                    {
                        if (item.itemOption[l].optionTemplate.id == 72)
                        {
                            text = " [+" + item.itemOption[l].getOptionString() + "]";
                        }
                        if (item.itemOption[l].optionTemplate.id == 41)
                        {
                            if (item.itemOption[l].param == 1)
                            {
                                mFont2 = GetFont(0);
                            }
                            else if (item.itemOption[l].param == 2)
                            {
                                mFont2 = GetFont(2);
                            }
                            else if (item.itemOption[l].param == 3)
                            {
                                mFont2 = GetFont(8);
                            }
                            else if (item.itemOption[l].param == 4)
                            {
                                mFont2 = GetFont(7);
                            }
                        }
                    }
                }
                mFont2.drawString(g, "[" + item.template.id + "] " + item.template.name + text, num2 + 5, num3 + 1, 0);
                string text2 = string.Empty;
                if (item.itemOption != null)
                {
                    if (item.itemOption.Length > 0 && item.itemOption[0] != null)
                    {
                        text2 += item.itemOption[0].getOptionString();
                    }
                    mFont2 mFont3 = mFont2.tahoma_7_blue;
                    if (item.compare < 0 && item.template.type != 5)
                    {
                        mFont3 = mFont2.tahoma_7_red;
                    }
                    if (item.itemOption.Length > 1)
                    {
                        for (int m = 1; m < item.itemOption.Length; m++)
                        {
                            if (item.itemOption[m] != null && item.itemOption[m].optionTemplate.id != 102 && item.itemOption[m].optionTemplate.id != 107)
                            {
                                text2 = text2 + "," + item.itemOption[m].getOptionString();
                            }
                        }
                    }
                    mFont3.drawString(g, text2, num2 + 5, num3 + 11, mFont2.LEFT);
                }
                SmallImage2.drawSmallImage(g, item.template.iconID, num5 + num7 / 2, num6 + num8 / 2, 0, 3);
                if (item.itemOption != null)
                {
                    for (int n = 0; n < item.itemOption.Length; n++)
                    {
                        paintOptItem(g, item.itemOption[n].optionTemplate.id, item.itemOption[n].param, num5, num6, num7, num8);
                    }
                    for (int num10 = 0; num10 < item.itemOption.Length; num10++)
                    {
                        paintOptSlotItem(g, item.itemOption[num10].optionTemplate.id, item.itemOption[num10].param, num5, num6, num7, num8);
                    }
                }
                if (item.quantity > 1)
                {
                    mFont2.tahoma_7_yellow.drawString(g, string.Empty + item.quantity, num5 + num7, num6 + num8 - mFont2.tahoma_7_yellow.getHeight(), 1);
                }
            }
        }
        catch (Exception)
        {
        }
        paintScrollArrow(g);
    }

    public Member2 getCurrMember()
    {
        if (selected < 2)
        {
            return null;
        }
        if (selected > ((member == null) ? myMember.size() : member.size()) + 1)
        {
            return null;
        }
        return (member == null) ? ((Member2)myMember.elementAt(selected - 2)) : ((Member2)member.elementAt(selected - 2));
    }

    public ClanMessage2 getCurrMessage()
    {
        if (selected < 2)
        {
            return null;
        }
        if (selected > ClanMessage2.vMessage.size() + 1)
        {
            return null;
        }
        return (ClanMessage2)ClanMessage2.vMessage.elementAt(selected - 2);
    }

    public Clan2 getCurrClan()
    {
        if (selected < 2)
        {
            return null;
        }
        if (selected > clans.Length + 1)
        {
            return null;
        }
        return clans[selected - 2];
    }

    private void paintLogChat(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        g.setColor(0);
        if (logChat.size() == 0)
        {
            mFont2.tahoma_7_green2.drawString(g, mResources2.no_msg, xScroll + wScroll / 2, yScroll + hScroll / 2 - mFont2.tahoma_7.getHeight() / 2 + 24, 2);
        }
        for (int i = 0; i < currentListLength; i++)
        {
            int num = xScroll;
            int num2 = yScroll + i * ITEM_HEIGHT;
            int num3 = 24;
            int h = ITEM_HEIGHT - 1;
            int num4 = xScroll + num3;
            int num5 = yScroll + i * ITEM_HEIGHT;
            int num6 = wScroll - num3;
            int num7 = ITEM_HEIGHT - 1;
            if (i == 0)
            {
                g.setColor(15196114);
                g.fillRect(num, num5, wScroll, num7);
                g.drawImage((i != selected) ? GameScr2.imgLbtn2 : GameScr2.imgLbtnFocus2, xScroll + wScroll - 5, num5 + 2, StaticObj2.TOP_RIGHT);
                ((i != selected) ? mFont2.tahoma_7b_dark : mFont2.tahoma_7b_green2).drawString(g, (!isViewChatServer) ? mResources2.on : mResources2.off, xScroll + wScroll - 22, num5 + 7, 2);
                mFont2.tahoma_7_grey.drawString(g, (!isViewChatServer) ? mResources2.onPlease : mResources2.offPlease, xScroll + 5, num5 + num7 / 2 - 4, mFont2.LEFT);
                continue;
            }
            g.setColor((i != selected) ? 15196114 : 16383818);
            g.fillRect(num4, num5, num6, num7);
            g.setColor((i != selected) ? 9993045 : 9541120);
            g.fillRect(num, num2, num3, h);
            InfoItem2 infoItem = (InfoItem2)logChat.elementAt(i - 1);
            if (infoItem.charInfo.headICON != -1)
            {
                SmallImage2.drawSmallImage(g, infoItem.charInfo.headICON, num, num2, 0, 0);
            }
            else
            {
                Part2 part = GameScr2.parts[infoItem.charInfo.head];
                SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[0][0][0]].id, num + part.pi[Char2.CharInfo[0][0][0]].dx, num2 + part.pi[Char2.CharInfo[0][0][0]].dy, 0, 0);
            }
            g.setClip(xScroll, yScroll + cmy, wScroll, hScroll);
            mFont2 tahoma_7b_dark = mFont2.tahoma_7b_dark;
            tahoma_7b_dark = mFont2.tahoma_7b_green2;
            tahoma_7b_dark.drawString(g, (infoItem.charInfo.isTichDo ? "      " : infoItem.charInfo.isTichXanh ? "      " : string.Empty) + infoItem.charInfo.cName, num4 + 5, num5, 0);
            //
            if (infoItem.charInfo.isTichDo)
            {
                MainMod2.PaintTicks(g, false, num4 + 4, num5);
            }
            else if (infoItem.charInfo.isTichXanh)
            {
                MainMod2.PaintTicks(g, true, num4 + 4, num5);
            }
            //
            if (!infoItem.isChatServer)
            {
                mFont2.tahoma_7_blue.drawString(g, Res2.split(infoItem.s, "|", 0)[2], num4 + 5, num5 + 11, 0);
            }
            else
            {
                mFont2.tahoma_7_red.drawString(g, Res2.split(infoItem.s, "|", 0)[2], num4 + 5, num5 + 11, 0);
            }
        }
        paintScrollArrow(g);
    }

    private void paintFlagChange(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        g.setColor(0);
        for (int i = 0; i < currentListLength; i++)
        {
            int num = xScroll + 26;
            int num2 = yScroll + i * ITEM_HEIGHT;
            int num3 = wScroll - 26;
            int h = ITEM_HEIGHT - 1;
            int num4 = xScroll;
            int num5 = yScroll + i * ITEM_HEIGHT;
            int num6 = 24;
            int num7 = ITEM_HEIGHT - 1;
            if (num2 - cmy > yScroll + hScroll || num2 - cmy < yScroll - ITEM_HEIGHT)
            {
                continue;
            }
            g.setColor((i != selected) ? 15196114 : 16383818);
            g.fillRect(num, num2, num3, h);
            g.setColor((i != selected) ? 9993045 : 9541120);
            g.fillRect(num4, num5, num6, num7);
            Item2 item = (Item2)vFlag.elementAt(i);
            if (item == null)
            {
                continue;
            }
            mFont2.tahoma_7_green2.drawString(g, item.template.name, num + 5, num2 + 1, 0);
            string text = string.Empty;
            if (item.itemOption != null && item.itemOption.Length >= 1)
            {
                if (item.itemOption[0] != null && item.itemOption[0].optionTemplate.id != 102 && item.itemOption[0].optionTemplate.id != 107)
                {
                    text += item.itemOption[0].getOptionString();
                }
                mFont2 tahoma_7_blue = mFont2.tahoma_7_blue;
                tahoma_7_blue.drawString(g, text, num + 5, num2 + 11, 0);
                SmallImage2.drawSmallImage(g, item.template.iconID, num4 + num6 / 2, num5 + num7 / 2, 0, 3);
            }
        }
        paintScrollArrow(g);
    }

    private void paintEnemy(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        g.setColor(0);
        if (currentListLength == 0)
        {
            mFont2.tahoma_7_green2.drawString(g, mResources2.no_enemy, xScroll + wScroll / 2, yScroll + hScroll / 2 - mFont2.tahoma_7.getHeight() / 2, 2);
            return;
        }
        for (int i = 0; i < currentListLength; i++)
        {
            int num = xScroll;
            int num2 = yScroll + i * ITEM_HEIGHT;
            int num3 = 24;
            int h = ITEM_HEIGHT - 1;
            int num4 = xScroll + num3;
            int num5 = yScroll + i * ITEM_HEIGHT;
            int num6 = wScroll - num3;
            int h2 = ITEM_HEIGHT - 1;
            g.setColor((i != selected) ? 15196114 : 16383818);
            g.fillRect(num4, num5, num6, h2);
            g.setColor((i != selected) ? 9993045 : 9541120);
            g.fillRect(num, num2, num3, h);
            InfoItem2 infoItem = (InfoItem2)vEnemy.elementAt(i);
            if (infoItem.charInfo.headICON != -1)
            {
                SmallImage2.drawSmallImage(g, infoItem.charInfo.headICON, num, num2, 0, 0);
            }
            else
            {
                Part2 part = GameScr2.parts[infoItem.charInfo.head];
                SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[0][0][0]].id, num + part.pi[Char2.CharInfo[0][0][0]].dx, num2 + 3 + part.pi[Char2.CharInfo[0][0][0]].dy, 0, 0);
            }
            g.setClip(xScroll, yScroll + cmy, wScroll, hScroll);
            if (infoItem.isOnline)
            {
                mFont2.tahoma_7b_green.drawString(g, infoItem.charInfo.cName, num4 + 5, num5, 0);
                mFont2.tahoma_7_blue.drawString(g, infoItem.s, num4 + 5, num5 + 11, 0);
            }
            else
            {
                mFont2.tahoma_7_grey.drawString(g, infoItem.charInfo.cName, num4 + 5, num5, 0);
                mFont2.tahoma_7_grey.drawString(g, infoItem.s, num4 + 5, num5 + 11, 0);
            }
        }
        paintScrollArrow(g);
    }

    private void paintFriend(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        g.setColor(0);
        if (currentListLength == 0)
        {
            mFont2.tahoma_7_green2.drawString(g, mResources2.no_friend, xScroll + wScroll / 2, yScroll + hScroll / 2 - mFont2.tahoma_7.getHeight() / 2, 2);
            return;
        }
        for (int i = 0; i < currentListLength; i++)
        {
            int num = xScroll;
            int num2 = yScroll + i * ITEM_HEIGHT;
            int num3 = 24;
            int h = ITEM_HEIGHT - 1;
            int num4 = xScroll + num3;
            int num5 = yScroll + i * ITEM_HEIGHT;
            int num6 = wScroll - num3;
            int h2 = ITEM_HEIGHT - 1;
            g.setColor((i != selected) ? 15196114 : 16383818);
            g.fillRect(num4, num5, num6, h2);
            g.setColor((i != selected) ? 9993045 : 9541120);
            g.fillRect(num, num2, num3, h);
            InfoItem2 infoItem = (InfoItem2)vFriend.elementAt(i);
            if (infoItem.charInfo.headICON != -1)
            {
                SmallImage2.drawSmallImage(g, infoItem.charInfo.headICON, num, num2, 0, 0);
            }
            else
            {
                Part2 part = GameScr2.parts[infoItem.charInfo.head];
                SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[0][0][0]].id, num + part.pi[Char2.CharInfo[0][0][0]].dx, num2 + 3 + part.pi[Char2.CharInfo[0][0][0]].dy, 0, 0);
            }
            g.setClip(xScroll, yScroll + cmy, wScroll, hScroll);
            if (infoItem.isOnline)
            {
                mFont2.tahoma_7b_green.drawString(g, infoItem.charInfo.cName, num4 + 5, num5, 0);
                mFont2.tahoma_7_blue.drawString(g, infoItem.s, num4 + 5, num5 + 11, 0);
            }
            else
            {
                mFont2.tahoma_7_grey.drawString(g, infoItem.charInfo.cName, num4 + 5, num5, 0);
                mFont2.tahoma_7_grey.drawString(g, infoItem.s, num4 + 5, num5 + 11, 0);
            }
        }
        paintScrollArrow(g);
    }

    public void paintPlayerMenu(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        for (int i = 0; i < vPlayerMenu.size(); i++)
        {
            int x = xScroll;
            int num = yScroll + i * ITEM_HEIGHT;
            int num2 = wScroll - 1;
            int h = ITEM_HEIGHT - 1;
            if (num - cmy <= yScroll + hScroll && num - cmy >= yScroll - ITEM_HEIGHT)
            {
                Command2 command = (Command2)vPlayerMenu.elementAt(i);
                g.setColor((i != selected) ? 15196114 : 16383818);
                g.fillRect(x, num, num2, h);
                if (command.caption2.Equals(string.Empty))
                {
                    mFont2.tahoma_7b_dark.drawString(g, command.caption, xScroll + wScroll / 2, num + 6, mFont2.CENTER);
                    continue;
                }
                mFont2.tahoma_7b_dark.drawString(g, command.caption, xScroll + wScroll / 2, num + 1, mFont2.CENTER);
                mFont2.tahoma_7b_dark.drawString(g, command.caption2, xScroll + wScroll / 2, num + 11, mFont2.CENTER);
            }
        }
        paintScrollArrow(g);
    }

    private void paintClans(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(-cmx, -cmy);
        g.setColor(0);
        int num = xScroll + wScroll / 2 - clansOption.Length * TAB_W / 2;
        if (currentListLength == 2)
        {
            mFont2.tahoma_7_green2.drawString(g, clanReport, xScroll + wScroll / 2, yScroll + 24 + hScroll / 2 - mFont2.tahoma_7.getHeight() / 2, 2);
            if (isMessage && myMember.size() == 1)
            {
                for (int i = 0; i < mResources2.clanEmpty.Length; i++)
                {
                    mFont2.tahoma_7b_dark.drawString(g, mResources2.clanEmpty[i], xScroll + wScroll / 2, yScroll + 24 + hScroll / 2 - mResources2.clanEmpty.Length * 12 / 2 + i * 12, mFont2.CENTER);
                }
            }
        }
        if (isMessage)
        {
            currentListLength = ClanMessage2.vMessage.size() + 2;
        }
        for (int j = 0; j < currentListLength; j++)
        {
            int num2 = xScroll;
            int num3 = yScroll + j * ITEM_HEIGHT;
            int num4 = 24;
            int num5 = ITEM_HEIGHT - 1;
            int num6 = xScroll + num4;
            int num7 = yScroll + j * ITEM_HEIGHT;
            int num8 = wScroll - num4;
            int num9 = ITEM_HEIGHT - 1;
            if (num7 - cmy > yScroll + hScroll || num7 - cmy < yScroll - ITEM_HEIGHT)
            {
                continue;
            }
            switch (j)
            {
                case 0:
                    {
                        for (int k = 0; k < clansOption.Length; k++)
                        {
                            g.setColor((k != cSelected || j != selected) ? 15723751 : 16383818);
                            g.fillRect(num + k * TAB_W, num7, TAB_W - 1, 23);
                            for (int l = 0; l < clansOption[k].Length; l++)
                            {
                                mFont2.tahoma_7_grey.drawString(g, clansOption[k][l], num + k * TAB_W + TAB_W / 2, yScroll + l * 11, mFont2.CENTER);
                            }
                        }
                        continue;
                    }
                case 1:
                    g.setColor((j != selected) ? 15196114 : 16383818);
                    g.fillRect(xScroll, num7, wScroll, num9);
                    if (clanInfo != null)
                    {
                        mFont2.tahoma_7b_dark.drawString(g, clanInfo, xScroll + wScroll / 2, num7 + 6, mFont2.CENTER);
                    }
                    continue;
            }
            if (isSearchClan)
            {
                if (clans == null || clans.Length == 0)
                {
                    continue;
                }
                g.setColor((j != selected) ? 15196114 : 16383818);
                g.fillRect(num6, num7, num8, num9);
                g.setColor((j != selected) ? 9993045 : 9541120);
                g.fillRect(num2, num3, num4, num5);
                if (ClanImage2.isExistClanImage(clans[j - 2].imgID))
                {
                    if (ClanImage2.getClanImage((short)clans[j - 2].imgID).idImage != null)
                    {
                        SmallImage2.drawSmallImage(g, ClanImage2.getClanImage((short)clans[j - 2].imgID).idImage[0], num2 + num4 / 2, num3 + num5 / 2, 0, StaticObj2.VCENTER_HCENTER);
                    }
                }
                else
                {
                    ClanImage2 clanImage = new ClanImage2();
                    clanImage.ID = clans[j - 2].imgID;
                    if (!ClanImage2.isExistClanImage(clanImage.ID))
                    {
                        ClanImage2.addClanImage(clanImage);
                    }
                }
                string st = ((clans[j - 2].name.Length <= 23) ? clans[j - 2].name : (clans[j - 2].name.Substring(0, 23) + "..."));
                mFont2.tahoma_7b_green2.drawString(g, st, num6 + 5, num7, 0);
                g.setClip(num6, num7, num8 - 10, num9);
                mFont2.tahoma_7_blue.drawString(g, clans[j - 2].slogan, num6 + 5, num7 + 11, 0);
                g.setClip(xScroll, yScroll + cmy, wScroll, hScroll);
                mFont2.tahoma_7_green2.drawString(g, clans[j - 2].currMember + "/" + clans[j - 2].maxMember, num6 + num8 - 5, num7, mFont2.RIGHT);
                continue;
            }
            if (isViewMember)
            {
                g.setColor((j != selected) ? 15196114 : 16383818);
                g.fillRect(num6, num7, num8, num9);
                g.setColor((j != selected) ? 9993045 : 9541120);
                g.fillRect(num2, num3, num4, num5);
                Member2 member = ((this.member == null) ? ((Member2)myMember.elementAt(j - 2)) : ((Member2)this.member.elementAt(j - 2)));
                if (member.headICON != -1)
                {
                    SmallImage2.drawSmallImage(g, member.headICON, num2, num3, 0, 0);
                }
                else
                {
                    Part2 part = GameScr2.parts[member.head];
                    SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[0][0][0]].id, num2 + part.pi[Char2.CharInfo[0][0][0]].dx, num3 + 3 + part.pi[Char2.CharInfo[0][0][0]].dy, 0, 0);
                }
                g.setClip(xScroll, yScroll + cmy, wScroll, hScroll);
                mFont2 mFont2 = mFont2.tahoma_7b_dark;
                if (member.role == 0)
                {
                    mFont2 = mFont2.tahoma_7b_red;
                }
                else if (member.role == 1)
                {
                    mFont2 = mFont2.tahoma_7b_green;
                }
                else if (member.role == 2)
                {
                    mFont2 = mFont2.tahoma_7b_green2;
                }
                mFont2.drawString(g, member.name, num6 + 5, num7, 0);
                mFont2.tahoma_7_blue.drawString(g, mResources2.power + ": " + member.powerPoint, num6 + 5, num7 + 11, 0);
                SmallImage2.drawSmallImage(g, 7223, num6 + num8 - 7, num7 + 12, 0, 3);
                mFont2.tahoma_7_blue.drawString(g, string.Empty + member.clanPoint, num6 + num8 - 15, num7 + 6, mFont2.RIGHT);
                continue;
            }
            if (!isMessage || ClanMessage2.vMessage.size() == 0)
            {
                continue;
            }
            ClanMessage2 clanMessage = (ClanMessage2)ClanMessage2.vMessage.elementAt(j - 2);
            g.setColor((j != selected || clanMessage.option != null) ? 15196114 : 16383818);
            g.fillRect(num2, num3, num8 + num4, num9);
            clanMessage.paint(g, num2, num3);
            if (clanMessage.option == null)
            {
                continue;
            }
            int num10 = xScroll + wScroll - 2 - clanMessage.option.Length * 40;
            for (int m = 0; m < clanMessage.option.Length; m++)
            {
                if (m == cSelected && j == selected)
                {
                    g.drawImage(GameScr2.imgLbtnFocus2, num10 + m * 40 + 20, num7 + num9 / 2, StaticObj2.VCENTER_HCENTER);
                    mFont2.tahoma_7b_green2.drawString(g, clanMessage.option[m], num10 + m * 40 + 20, num7 + 6, mFont2.CENTER);
                }
                else
                {
                    g.drawImage(GameScr2.imgLbtn2, num10 + m * 40 + 20, num7 + num9 / 2, StaticObj2.VCENTER_HCENTER);
                    mFont2.tahoma_7b_dark.drawString(g, clanMessage.option[m], num10 + m * 40 + 20, num7 + 6, mFont2.CENTER);
                }
            }
        }
        paintScrollArrow(g);
    }

    private void paintArchivement(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        g.setColor(0);
        if (currentListLength == 0)
        {
            mFont2.tahoma_7_green2.drawString(g, mResources2.no_mission, xScroll + wScroll / 2, yScroll + hScroll / 2 - mFont2.tahoma_7.getHeight() / 2, 2);
        }
        else
        {
            if (Char2.myCharz().arrArchive == null || Char2.myCharz().arrArchive.Length != currentListLength)
            {
                return;
            }
            for (int i = 0; i < currentListLength; i++)
            {
                int num = xScroll;
                int num2 = yScroll + i * ITEM_HEIGHT;
                int num3 = wScroll;
                int num4 = ITEM_HEIGHT - 1;
                Archivement2 archivement = Char2.myCharz().arrArchive[i];
                g.setColor(i != selected ? 15196114 : 16383818);
                g.fillRect(num, num2, num3, num4);
                if (archivement == null)
                {
                    continue;
                }
                if (!archivement.isFinish)
                {
                    mFont2.tahoma_7.drawString(g, archivement.info1, num + 5, num2, 0);
                    mFont2.tahoma_7_red.drawString(g, archivement.info2, num + 5, num2 + 11, 0);
                    mFont2.tahoma_7_green.drawString(g, archivement.money + " " + mResources2.RUBY, num + num3 - 5, num2, mFont2.RIGHT);
                }
                else if (archivement.isFinish && !archivement.isRecieve)
                {
                    mFont2.tahoma_7.drawString(g, archivement.info1, num + 5, num2, 0);
                    mFont2.tahoma_7_blue.drawString(g, mResources2.reward_mission + archivement.money + " " + mResources2.RUBY, num + 5, num2 + 11, 0);
                    g.drawImage(i == selected ? GameScr2.imgLbtnFocus2 : GameScr2.imgLbtn2, num + num3 - 20, num2 + num4 / 2, StaticObj2.VCENTER_HCENTER);
                    mFont2.tahoma_7b_dark.drawString(g, mResources2.receive_upper, num + num3 - 20, num2 + 6, mFont2.CENTER);
                }
                else if (archivement.isFinish && archivement.isRecieve)
                {
                    mFont2.tahoma_7.drawString(g, archivement.info1, num + 5, num2, 0);
                    mFont2.tahoma_7_red.drawString(g, archivement.info2, num + 5, num2 + 11, 0);
                    mFont2.tahoma_7_green.drawString(g, mResources2.received, num + num3 - 5, num2, mFont2.RIGHT);
                }
            }
            paintScrollArrow(g);
        }
    }

    private void paintCombine(mGraphics2 g)
    {
        g.setColor(16711680);
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        if (vItemCombine.size() == 0)
        {
            if (combineInfo != null)
            {
                for (int i = 0; i < combineInfo.Length; i++)
                {
                    mFont2.tahoma_7b_dark.drawString(g, combineInfo[i], xScroll + wScroll / 2, yScroll + hScroll / 2 - combineInfo.Length * 14 / 2 + i * 14 + 5, 2);
                }
            }
            return;
        }
        for (int j = 0; j < vItemCombine.size() + 1; j++)
        {
            int num = xScroll + 36;
            int num2 = yScroll + j * ITEM_HEIGHT;
            int num3 = wScroll - 36;
            int num4 = ITEM_HEIGHT - 1;
            int num5 = xScroll;
            int num6 = yScroll + j * ITEM_HEIGHT;
            int num7 = 34;
            int num8 = ITEM_HEIGHT - 1;
            if (num2 - cmy > yScroll + hScroll || num2 - cmy < yScroll - ITEM_HEIGHT)
            {
                continue;
            }
            if (j == vItemCombine.size())
            {
                if (vItemCombine.size() > 0)
                {
                    if (!GameCanvas2.isTouch && j == selected)
                    {
                        g.setColor(16383818);
                        g.fillRect(num5, num2, wScroll, num4 + 2);
                    }
                    if ((j == selected && keyTouchCombine == 1) || (!GameCanvas2.isTouch && j == selected))
                    {
                        g.drawImage(GameScr2.imgLbtnFocus, xScroll + wScroll / 2, num2 + num4 / 2 + 1, StaticObj2.VCENTER_HCENTER);
                        global::mFont2.tahoma_7b_green2.drawString(g, mResources2.UPGRADE, xScroll + wScroll / 2, num2 + num4 / 2 - 4, global::mFont2.CENTER);
                    }
                    else
                    {
                        g.drawImage(GameScr2.imgLbtn, xScroll + wScroll / 2, num2 + num4 / 2 + 1, StaticObj2.VCENTER_HCENTER);
                        global::mFont2.tahoma_7b_dark.drawString(g, mResources2.UPGRADE, xScroll + wScroll / 2, num2 + num4 / 2 - 4, global::mFont2.CENTER);
                    }
                }
                continue;
            }
            g.setColor((j != selected) ? 15196114 : 16383818);
            g.fillRect(num, num2, num3, num4);
            g.setColor((j != selected) ? 9993045 : 9541120);
            Item2 item = (Item2)vItemCombine.elementAt(j);
            if (item != null)
            {
                for (int k = 0; k < item.itemOption.Length; k++)
                {
                    if (item.itemOption[k].optionTemplate.id == 72 && item.itemOption[k].param > 0)
                    {
                        sbyte color_Item_Upgrade = GetColor_Item_Upgrade(item.itemOption[k].param);
                        int color_ItemBg = GetColor_ItemBg(color_Item_Upgrade);
                        if (color_ItemBg != -1)
                        {
                            g.setColor((j != selected) ? GetColor_ItemBg(color_Item_Upgrade) : GetColor_ItemBg(color_Item_Upgrade));
                        }
                    }
                }
            }
            g.fillRect(num5, num6, num7, num8);
            if (item == null)
            {
                continue;
            }
            string text = string.Empty;
            mFont2 mFont2 = mFont2.tahoma_7_green2;
            if (item.itemOption != null)
            {
                for (int l = 0; l < item.itemOption.Length; l++)
                {
                    if (item.itemOption[l].optionTemplate.id == 72)
                    {
                        text = " [+" + item.itemOption[l].param + "]";
                    }
                    if (item.itemOption[l].optionTemplate.id == 41)
                    {
                        if (item.itemOption[l].param == 1)
                        {
                            mFont2 = GetFont(0);
                        }
                        else if (item.itemOption[l].param == 2)
                        {
                            mFont2 = GetFont(2);
                        }
                        else if (item.itemOption[l].param == 3)
                        {
                            mFont2 = GetFont(8);
                        }
                        else if (item.itemOption[l].param == 4)
                        {
                            mFont2 = GetFont(7);
                        }
                    }
                }
            }
            mFont2.drawString(g, "[" + item.template.id + "] " + item.template.name + text, num + 5, num2 + 1, 0);
            string text2 = string.Empty;
            if (item.itemOption != null)
            {
                if (item.itemOption.Length > 0 && item.itemOption[0] != null && item.itemOption[0].optionTemplate.id != 102 && item.itemOption[0].optionTemplate.id != 107)
                {
                    text2 += item.itemOption[0].getOptionString();
                }
                mFont2 mFont3 = mFont2.tahoma_7_blue;
                if (item.compare < 0 && item.template.type != 5)
                {
                    mFont3 = mFont2.tahoma_7_red;
                }
                if (item.itemOption.Length > 1)
                {
                    for (int m = 1; m < item.itemOption.Length; m++)
                    {
                        if (item.itemOption[m] != null && item.itemOption[m].optionTemplate.id != 102 && item.itemOption[m].optionTemplate.id != 107)
                        {
                            text2 = text2 + "," + item.itemOption[m].getOptionString();
                        }
                    }
                }
                mFont3.drawString(g, text2, num + 5, num2 + 11, mFont2.LEFT);
            }
            SmallImage2.drawSmallImage(g, item.template.iconID, num5 + num7 / 2, num6 + num8 / 2, 0, 3);
            if (item.itemOption != null)
            {
                for (int n = 0; n < item.itemOption.Length; n++)
                {
                    paintOptItem(g, item.itemOption[n].optionTemplate.id, item.itemOption[n].param, num5, num6, num7, num8);
                }
                for (int num9 = 0; num9 < item.itemOption.Length; num9++)
                {
                    paintOptSlotItem(g, item.itemOption[num9].optionTemplate.id, item.itemOption[num9].param, num5, num6, num7, num8);
                }
            }
            if (item.quantity > 1)
            {
                mFont2.tahoma_7_yellow.drawString(g, string.Empty + item.quantity, num5 + num7, num6 + num8 - mFont2.tahoma_7_yellow.getHeight(), 1);
            }
        }
        paintScrollArrow(g);
    }

    private void paintInventory(mGraphics2 g)
    {
        bool flag = true;
        if (flag && isnewInventory)
        {
            Item2[] arrItemBody = Char2.myCharz().arrItemBody;
            Item2[] arrItemBag = Char2.myCharz().arrItemBag;
            g.setColor(16711680);
            int num = arrItemBody.Length + arrItemBag.Length;
            int num2 = num / 20 + ((num % 20 > 0) ? 1 : 0) + 1;
            int num3 = 0;
            TAB_W_NEW = wScroll / num2;
            for (int i = num3; i < num2; i++)
            {
                int num4 = ((i == newSelected && selected == 0) ? ((GameCanvas2.gameTick % 10 < 7) ? (-1) : 0) : 0);
                g.setColor((i != newSelected) ? 15723751 : 16383818);
                g.fillRect(xScroll + i * TAB_W_NEW, 89 + num4 - 10, TAB_W_NEW - 1, 21);
                if (i == newSelected)
                {
                    g.setColor(13524492);
                    int x = xScroll + i * TAB_W_NEW;
                    int num5 = 89 + num4 - 10 + 21;
                    g.fillRect(x, num5 - 3, TAB_W_NEW - 1, 3);
                }
                mFont2.tahoma_7_grey.drawString(g, string.Empty + (i + 1), xScroll + i * TAB_W_NEW + TAB_W_NEW / 2, 91 + num4 - 10, mFont2.CENTER);
            }
            num3 = 1;
            int num6 = xScroll;
            int num7 = yScroll + num3 * ITEM_HEIGHT;
            int num8 = 34;
            int num9 = ITEM_HEIGHT - 1;
            for (int j = 0; j < 4; j++)
            {
                num6 = xScroll;
                num7 = yScroll + (j + num3) * ITEM_HEIGHT;
                bool flag2 = true;
                for (int k = 0; k < 5; k++)
                {
                    Item2 item = null;
                    int num10 = 0;
                    if (newSelected > 0)
                    {
                        num10 = (newSelected - 1) * 20;
                        if (j * 5 + k + num10 < arrItemBag.Length)
                        {
                            item = arrItemBag[j * 5 + k + num10];
                            num6 = xScroll + num8 * k;
                            int num11 = sellectInventory % 5;
                            int num12 = sellectInventory / 5;
                            if (newSelected > 0)
                            {
                                g.setColor(15196114);
                            }
                            else
                            {
                                g.setColor(9993045);
                            }
                            g.drawRect(num6, num7, num8, num9);
                            if (j == num12 && k == num11 && selected > 0)
                            {
                                g.setColor(16383818);
                                itemInvenNew = item;
                            }
                            g.fillRect(num6 + 2, num7 + 2, num8 - 3, num9 - 3);
                            if (item != null)
                            {
                                int x2 = num6 + imgNew.getWidth() / 2;
                                int y = num7;
                                int num13 = 34;
                                int h = ITEM_HEIGHT - 1;
                                SmallImage2.drawSmallImage(g, item.template.iconID, num6 + num8 / 2, num7 + num9 / 2, 0, 3);
                                if (item.quantity > 1)
                                {
                                    mFont2.tahoma_7_yellow.drawString(g, string.Empty + item.quantity, num6, num7 - mFont2.tahoma_7_yellow.getHeight(), 1);
                                }
                                if (item.newItem && GameCanvas2.gameTick % 10 > 5)
                                {
                                    g.drawImage(imgNew, x2, y, 3);
                                }
                                for (int l = 0; l < item.itemOption.Length; l++)
                                {
                                    paintOptSlotItem(g, item.itemOption[l].optionTemplate.id, item.itemOption[l].param, x2, y, num13, h);
                                }
                            }
                            if (!flag2)
                            {
                                break;
                            }
                            continue;
                        }
                        flag2 = false;
                        break;
                    }
                    if (j * 5 + k < arrItemBody.Length)
                    {
                        item = arrItemBody[j * 5 + k];
                        flag2 = false;
                    }
                    else
                    {
                        flag2 = false;
                    }
                    break;
                }
            }
            num3 = ((newSelected != 0) ? 5 : 3);
            int num14 = yScroll + num3 * ITEM_HEIGHT + 5;
            int num15 = 2;
            if (newSelected == 0)
            {
                num15 = 4;
            }
            num6 = xScroll;
            num7 = yScroll + num3 * ITEM_HEIGHT;
            num8 = 34;
            num9 = ITEM_HEIGHT - 1;
            if (newSelected == 0)
            {
                g.setColor(15196114);
                num3 = 1;
                nTableItem = 10;
                int num16 = 5;
                if (eBanner != null)
                {
                    eBanner.paint(g);
                    eBanner.x = num6 + 34 + 34;
                    eBanner.y = num7 + num9 - 25;
                }
                for (int m = 0; m < 10; m++)
                {
                    Item2 item2 = null;
                    item2 = arrItemBody[m];
                    if (m < 5)
                    {
                        num16 = 0;
                        num6 = xScroll;
                        num7 = yScroll + (m + num3) * ITEM_HEIGHT;
                    }
                    else
                    {
                        num16 = 5;
                        num6 = xScroll + 4 * num8;
                        num7 = yScroll + (m - num16 + num3) * ITEM_HEIGHT;
                    }
                    g.setColor(15196114);
                    g.drawRect(num6, num7, num8, num9);
                    if (sellectInventory == m)
                    {
                        itemInvenNew = item2;
                        g.setColor(16383818);
                    }
                    else
                    {
                        g.setColor(9993045);
                    }
                    g.fillRect(num6 + 2, num7 + 2, num8 - 3, num9 - 3);
                    if (item2 == null)
                    {
                        screenTab6.drawFrame(m, num6 + num8 / 2 - 8, num7 + num9 / 2 - 8, 0, mGraphics2.TOP | mGraphics2.LEFT, g);
                    }
                    if (item2 != null)
                    {
                        SmallImage2.drawSmallImage(g, item2.template.iconID, num6 + num8 / 2, num7 + num9 / 2, 0, 3);
                        if (item2.quantity > 1)
                        {
                            mFont2.tahoma_7_yellow.drawString(g, string.Empty + item2.quantity, num6 + 4 * num8, num7 - mFont2.tahoma_7_yellow.getHeight(), 1);
                        }
                    }
                }
                num3 = 1;
                num6 = xScroll + 34;
                num7 = yScroll + num3 * ITEM_HEIGHT;
                num8 = 102;
                num9 = 4 * (ITEM_HEIGHT - 1);
                Char2.myCharz().paintCharBody(g, num6 + 34 + 17, num7 + num9 - 25, 1, 0, isPaintBag: true);
                num3 = 3;
                num15 = 2;
                num6 = xScroll + 34;
                num7 = yScroll + (1 + num3) * ITEM_HEIGHT - 1;
                num8 = 102;
                num9 = ITEM_HEIGHT * num15;
                g.setColor(15196114);
                g.drawRect(num6, num7, num8, num9);
                g.setColor(9993045);
                g.fillRect(num6 + 1, num7 + 1, num8 - 2, num9 - 2);
                paintItemBodyBagInfo(g, num6 + 3, num7 - 2);
                num3 = ((newSelected != 0) ? 5 : 6);
                num14 = yScroll + num3 * ITEM_HEIGHT;
                g.setColor(15196114);
                if (newSelected == 0)
                {
                    num15 = 1;
                }
                g.drawRect(xScroll, num14, wScroll, ITEM_HEIGHT * num15);
                g.setColor(16777215);
                g.fillRect(xScroll + 1, num14 + 1, wScroll - 2, ITEM_HEIGHT * num15 - 2);
            }
            if (itemInvenNew != null && itemInvenNew.itemOption != null)
            {
                string text = string.Empty;
                mFont2 mFont2 = mFont2.tahoma_7_green2;
                if (itemInvenNew.itemOption != null)
                {
                    for (int n = 0; n < itemInvenNew.itemOption.Length; n++)
                    {
                        if (itemInvenNew.itemOption[n].optionTemplate.id == 72)
                        {
                            text = " [+" + itemInvenNew.itemOption[n].param + "]";
                        }
                        if (itemInvenNew.itemOption[n].optionTemplate.id == 41)
                        {
                            if (itemInvenNew.itemOption[n].param == 1)
                            {
                                mFont2 = GetFont(0);
                            }
                            else if (itemInvenNew.itemOption[n].param == 2)
                            {
                                mFont2 = GetFont(2);
                            }
                            else if (itemInvenNew.itemOption[n].param == 3)
                            {
                                mFont2 = GetFont(8);
                            }
                            else if (itemInvenNew.itemOption[n].param == 4)
                            {
                                mFont2 = GetFont(7);
                            }
                        }
                    }
                }
                mFont2.drawString(g, "[" + itemInvenNew.template.id + "] " + itemInvenNew.template.name + text, xScroll + 5, num14 + 1, 0);
                string text2 = string.Empty;
                if (itemInvenNew.itemOption != null)
                {
                    if (itemInvenNew.itemOption.Length > 0 && itemInvenNew.itemOption[0] != null && itemInvenNew.itemOption[0].optionTemplate.id != 102 && itemInvenNew.itemOption[0].optionTemplate.id != 107)
                    {
                        text2 += itemInvenNew.itemOption[0].getOptionString();
                    }
                    mFont2 mFont3 = mFont2.tahoma_7_blue;
                    if (itemInvenNew.compare < 0 && itemInvenNew.template.type != 5)
                    {
                        mFont3 = mFont2.tahoma_7_red;
                    }
                    if (itemInvenNew.itemOption.Length > 1)
                    {
                        for (int num17 = 1; num17 < 2; num17++)
                        {
                            if (itemInvenNew.itemOption[num17] != null && itemInvenNew.itemOption[num17].optionTemplate.id != 102 && itemInvenNew.itemOption[num17].optionTemplate.id != 107)
                            {
                                text2 = text2 + "," + itemInvenNew.itemOption[num17].getOptionString();
                            }
                        }
                    }
                    try
                    {
                        if (mFont3.getWidth(text2) > wScroll)
                        {
                            text2 = mFont3.splitFontArray(text2, wScroll)[0];
                        }
                    }
                    catch (Exception)
                    {
                    }
                    mFont3.drawString(g, text2, xScroll + 5, num14 + 11, mFont2.LEFT);
                }
            }
        }
        if (flag && isnewInventory)
        {
            return;
        }
        g.setColor(16711680);
        Item2[] arrItemBody2 = Char2.myCharz().arrItemBody;
        Item2[] arrItemBag2 = Char2.myCharz().arrItemBag;
        currentListLength = checkCurrentListLength(arrItemBody2.Length + arrItemBag2.Length);
        int num18 = (arrItemBody2.Length + arrItemBag2.Length) / 20 + (((arrItemBody2.Length + arrItemBag2.Length) % 20 > 0) ? 1 : 0);
        TAB_W_NEW = wScroll / num18;
        for (int num19 = 0; num19 < num18; num19++)
        {
            int num20 = ((num19 == newSelected && selected == 0) ? ((GameCanvas2.gameTick % 10 < 7) ? (-1) : 0) : 0);
            g.setColor((num19 != newSelected) ? 15723751 : 16383818);
            g.fillRect(xScroll + num19 * TAB_W_NEW, 89 + num20 - 10, TAB_W_NEW - 1, 21);
            if (num19 == newSelected)
            {
                g.setColor(13524492);
                int x3 = xScroll + num19 * TAB_W_NEW;
                int num21 = 89 + num20 - 10 + 21;
                g.fillRect(x3, num21 - 3, TAB_W_NEW - 1, 3);
            }
            mFont2.tahoma_7_grey.drawString(g, string.Empty + (num19 + 1), xScroll + num19 * TAB_W_NEW + TAB_W_NEW / 2, 91 + num20 - 10, mFont2.CENTER);
        }
        g.setClip(xScroll, yScroll + 21, wScroll, hScroll - 21);
        g.translate(0, -cmy);
        try
        {
            for (int num22 = 1; num22 < currentListLength; num22++)
            {
                int num23 = xScroll + 36;
                int num24 = yScroll + num22 * ITEM_HEIGHT;
                int num25 = wScroll - 36;
                int h2 = ITEM_HEIGHT - 1;
                int num26 = xScroll;
                int num27 = yScroll + num22 * ITEM_HEIGHT;
                int num28 = 34;
                int num29 = ITEM_HEIGHT - 1;
                if (num24 - cmy > yScroll + hScroll || num24 - cmy < yScroll - ITEM_HEIGHT)
                {
                    continue;
                }
                bool inventorySelect_isbody = GetInventorySelect_isbody(num22, newSelected, Char2.myCharz().arrItemBody);
                int inventorySelect_body = GetInventorySelect_body(num22, newSelected);
                int inventorySelect_bag = GetInventorySelect_bag(num22, newSelected, Char2.myCharz().arrItemBody);
                g.setColor((num22 == selected) ? 16383818 : ((!inventorySelect_isbody) ? 15723751 : 15196114));
                g.fillRect(num23, num24, num25, h2);
                g.setColor((num22 == selected) ? 9541120 : ((!inventorySelect_isbody) ? 11837316 : 9993045));
                Item2 item3 = ((!inventorySelect_isbody) ? arrItemBag2[inventorySelect_bag] : arrItemBody2[inventorySelect_body]);
                if (item3 != null)
                {
                    for (int num30 = 0; num30 < item3.itemOption.Length; num30++)
                    {
                        if (item3.itemOption[num30].optionTemplate.id == 72 && item3.itemOption[num30].param > 0)
                        {
                            byte id = (byte)GetColor_Item_Upgrade(item3.itemOption[num30].param);
                            int color_ItemBg = GetColor_ItemBg(id);
                            if (color_ItemBg != -1)
                            {
                                g.setColor((num22 != selected) ? GetColor_ItemBg(id) : GetColor_ItemBg(id));
                            }
                        }
                    }
                    foreach (ItemAuto itemAuto in MainMod2.listItemAuto)
                    {
                        if (item3.template.id == itemAuto.id && item3.template.iconID == itemAuto.iconID)
                        {
                            g.setColor((num22 != selected) ? color1[1] : color2[1]);
                        }
                    }
                }
                g.fillRect(num26, num27, num28, num29);
                if (item3 != null && item3.isSelect && GameCanvas2.panel.type == 12)
                {
                    g.setColor((num22 != selected) ? 6047789 : 7040779);
                    g.fillRect(num26, num27, num28, num29);
                }
                if (item3 == null)
                {
                    continue;
                }
                string text3 = string.Empty;
                mFont2 mFont4 = mFont2.tahoma_7_green2;
                if (item3.itemOption != null)
                {
                    for (int num31 = 0; num31 < item3.itemOption.Length; num31++)
                    {
                        if (item3.itemOption[num31].optionTemplate.id == 72)
                        {
                            text3 = " [+" + item3.itemOption[num31].param + "]";
                        }
                        if (item3.itemOption[num31].optionTemplate.id == 41)
                        {
                            if (item3.itemOption[num31].param == 1)
                            {
                                mFont4 = GetFont(0);
                            }
                            else if (item3.itemOption[num31].param == 2)
                            {
                                mFont4 = GetFont(2);
                            }
                            else if (item3.itemOption[num31].param == 3)
                            {
                                mFont4 = GetFont(8);
                            }
                            else if (item3.itemOption[num31].param == 4)
                            {
                                mFont4 = GetFont(7);
                            }
                        }
                    }
                }
                mFont4.drawString(g, "[" + item3.template.id + "] " + item3.template.name + text3, num23 + 5, num24 + 1, 0);
                string text4 = string.Empty;
                if (item3.itemOption != null)
                {
                    if (item3.itemOption.Length > 0 && item3.itemOption[0] != null && item3.itemOption[0].optionTemplate.id != 102 && item3.itemOption[0].optionTemplate.id != 107)
                    {
                        text4 += item3.itemOption[0].getOptionString();
                    }
                    mFont2 mFont5 = mFont2.tahoma_7_blue;
                    if (item3.compare < 0 && item3.template.type != 5)
                    {
                        mFont5 = mFont2.tahoma_7_red;
                    }
                    if (item3.itemOption.Length > 1)
                    {
                        for (int num32 = 1; num32 < 2; num32++)
                        {
                            if (item3.itemOption[num32] != null && item3.itemOption[num32].optionTemplate.id != 102 && item3.itemOption[num32].optionTemplate.id != 107)
                            {
                                text4 = text4 + "," + item3.itemOption[num32].getOptionString();
                            }
                        }
                    }
                    mFont5.drawString(g, text4, num23 + 5, num24 + 11, mFont2.LEFT);
                }
                SmallImage2.drawSmallImage(g, item3.template.iconID, num26 + num28 / 2, num27 + num29 / 2, 0, 3);
                if (item3.itemOption != null)
                {
                    for (int num33 = 0; num33 < item3.itemOption.Length; num33++)
                    {
                        paintOptItem(g, item3.itemOption[num33].optionTemplate.id, item3.itemOption[num33].param, num26, num27, num28, num29);
                    }
                    for (int num34 = 0; num34 < item3.itemOption.Length; num34++)
                    {
                        paintOptSlotItem(g, item3.itemOption[num34].optionTemplate.id, item3.itemOption[num34].param, num26, num27, num28, num29);
                    }
                }
                if (item3.quantity > 1)
                {
                    mFont2.tahoma_7_yellow.drawString(g, string.Empty + item3.quantity, num26 + num28, num27 + num29 - mFont2.tahoma_7_yellow.getHeight(), 1);
                }
            }
        }
        catch (Exception)
        {
        }
        paintScrollArrow(g);
    }

    private void paintTab(mGraphics2 g)
    {
        if (type == 27)
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, MainMod2.strPlayerInfo, xScroll + wScroll / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 23 || type == 24)
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.gameInfo, xScroll + wScroll / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 20)
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.account, xScroll + wScroll / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 22)
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.autoFunction, xScroll + wScroll / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 19 || type == 26)
        {
            string s = type == 19 ? mResources2.option : type == 26 ? MainMod2.strModFunc : MainMod2.strPlayerInfo;
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, s, xScroll + wScroll / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 18)
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.change_flag, xScroll + wScroll / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 13 && Equals(GameCanvas2.panel2))
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.item_receive2, xScroll + wScroll / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 12 && GameCanvas2.panel2 != null)
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.UPGRADE, xScroll + wScroll / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 11)
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.friend, xScroll + wScroll / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 16)
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.enemy, xScroll + wScroll / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 15)
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, topName, xScroll + wScroll / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 2 && GameCanvas2.panel2 != null)
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.chest, xScroll + wScroll / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 9)
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.achievement_mission, xScroll + wScroll / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 3)
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.select_zone, startTabPos + TAB_W / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 14)
        {
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.select_map, startTabPos + TAB_W / 2, 59, mFont2.CENTER);
            return;
        }
        if (type == 4)
        {
            mFont2.tahoma_7b_dark.drawString(g, mResources2.map, startTabPos + TAB_W / 2, 59, mFont2.CENTER);
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            return;
        }
        if (type == 7)
        {
            mFont2.tahoma_7b_dark.drawString(g, mResources2.trangbi, startTabPos + TAB_W / 2, 59, mFont2.CENTER);
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            return;
        }
        if (type == 17)
        {
            mFont2.tahoma_7b_dark.drawString(g, mResources2.kigui, startTabPos + TAB_W / 2, 59, mFont2.CENTER);
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            return;
        }
        if (type == 8)
        {
            mFont2.tahoma_7b_dark.drawString(g, mResources2.msg + MainMod2.strClickToChat, startTabPos + TAB_W / 2, 59, mFont2.CENTER);
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);
            return;
        }
        if (type == 10)
        {
            mFont2.tahoma_7b_dark.drawString(g, mResources2.wat_do_u_want, startTabPos + TAB_W / 2, 59, mFont2.CENTER);
            g.setColor(13524492);
            g.fillRect(X + 1, 78, W - 2, 1);

            return;
        }
        if (currentTabIndex == 3 && mainTabName.Length != 4)
        {
            g.translate(-cmx, 0);
        }
        for (int i = 0; i < currentTabName.Length; i++)
        {
            g.setColor((i != currentTabIndex) ? 16773296 : 6805896);
            PopUp2.paintPopUp(g, startTabPos + i * TAB_W, 52, TAB_W - 1, 25, (i == currentTabIndex) ? 1 : 0, isButton: true);
            if (i == keyTouchTab)
            {
                g.drawImage(ItemMap2.imageFlare, startTabPos + i * TAB_W + TAB_W / 2, 62, 3);
            }
            mFont2 mFont2 = ((i != currentTabIndex) ? mFont2.tahoma_7_grey : mFont2.tahoma_7_green2);
            if (!currentTabName[i][1].Equals(string.Empty))
            {
                mFont2.drawString(g, currentTabName[i][0], startTabPos + i * TAB_W + TAB_W / 2, 53, mFont2.CENTER);
                mFont2.drawString(g, currentTabName[i][1], startTabPos + i * TAB_W + TAB_W / 2, 64, mFont2.CENTER);
            }
            else
            {
                mFont2.drawString(g, currentTabName[i][0], startTabPos + i * TAB_W + TAB_W / 2, 59, mFont2.CENTER);
            }
            if (type == 0 && currentTabName.Length == 5 && GameScr2.isNewClanMessage && GameCanvas2.gameTick % 4 == 0)
            {
                g.drawImage(ItemMap2.imageFlare, startTabPos + 3 * TAB_W + TAB_W / 2, 77, mGraphics2.BOTTOM | mGraphics2.HCENTER);
            }
        }
        g.setColor(13524492);
        g.fillRect(1, 78, W - 2, 1);
    }

    private void paintBottomMoneyInfo(mGraphics2 g)
    {
        if (type != 13 || (currentTabIndex != 2 && !Equals(GameCanvas2.panel2)))
        {
            g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
            g.setColor(11837316);
            g.fillRect(X + 1, H - 15, W - 2, 14);
            g.setColor(13524492);
            g.fillRect(X + 1, H - 15, W - 2, 1);
            g.drawImage(imgXu, X + 11, H - 7, 3);
            g.drawImage(imgLuong, X + 75, H - 8, 3);
            mFont2.tahoma_7_yellow.drawString(g, Char2.myCharz().xuStr + string.Empty, X + 24, H - 13, mFont2.LEFT, mFont2.tahoma_7_grey);
            mFont2.tahoma_7_yellow.drawString(g, Char2.myCharz().luongStr + string.Empty, X + 85, H - 13, mFont2.LEFT, mFont2.tahoma_7_grey);
            g.drawImage(imgLuongKhoa, X + 130, H - 8, 3);
            mFont2.tahoma_7_yellow.drawString(g, Char2.myCharz().luongKhoaStr + string.Empty, X + 140, H - 13, mFont2.LEFT, mFont2.tahoma_7_grey);
        }
    }

    private void paintClanInfo(mGraphics2 g)
    {
        if (Char2.myCharz().clan == null)
        {
            SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), 25, 50, 0, 33);
            mFont2.tahoma_7b_white.drawString(g, mResources2.not_join_clan, (wScroll - 50) / 2 + 50, 20, mFont2.CENTER);
        }
        else if (!isViewMember)
        {
            Clan2 clan = Char2.myCharz().clan;
            if (clan != null)
            {
                SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), 25, 50, 0, 33);
                mFont2.tahoma_7b_white.drawString(g, clan.name, 60, 4, mFont2.LEFT, mFont2.tahoma_7b_dark);
                mFont2.tahoma_7_yellow.drawString(g, mResources2.achievement_point + ": " + clan.powerPoint, 60, 16, mFont2.LEFT, mFont2.tahoma_7_grey);
                mFont2.tahoma_7_yellow.drawString(g, mResources2.clan_point + ": " + clan.clanPoint, 60, 27, mFont2.LEFT, mFont2.tahoma_7_grey);
                mFont2.tahoma_7_yellow.drawString(g, mResources2.level + ": " + clan.level, 60, 38, mFont2.LEFT, mFont2.tahoma_7_grey);
                TextInfo2.paint(g, clan.slogan, 60, 38, wScroll - 70, ITEM_HEIGHT, mFont2.tahoma_7_yellow);
            }
        }
        else
        {
            Clan2 clan2 = ((currClan == null) ? Char2.myCharz().clan : currClan);
            SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), 25, 50, 0, 33);
            mFont2.tahoma_7b_white.drawString(g, clan2.name, 60, 4, mFont2.LEFT, mFont2.tahoma_7b_dark);
            mFont2.tahoma_7_yellow.drawString(g, mResources2.member + ": " + clan2.currMember + "/" + clan2.maxMember, 60, 16, mFont2.LEFT, mFont2.tahoma_7_grey);
            mFont2.tahoma_7_yellow.drawString(g, mResources2.clan_leader + ": " + clan2.leaderName, 60, 27, mFont2.LEFT, mFont2.tahoma_7_grey);
            TextInfo2.paint(g, clan2.slogan, 60, 38, wScroll - 70, ITEM_HEIGHT, mFont2.tahoma_7_yellow);
        }
    }

    private void paintToolInfo(mGraphics2 g)
    {
        mFont2.tahoma_7b_white.drawString(g, mResources2.dragon_ball + " " + GameMidlet2.VERSION, 60, 4, mFont2.LEFT, mFont2.tahoma_7b_dark);
        mFont2.tahoma_7_yellow.drawString(g, (Char2.myCharz().isTichDo ? "      " : Char2.myCharz().isTichXanh ? "     " : string.Empty) + Char2.myCharz().cName, 60, 16, mFont2.LEFT, mFont2.tahoma_7_grey);
        if (Char2.myCharz().isTichDo)
        {
            MainMod2.PaintTicks(g, false, 58, 17);
        }
        else if (Char2.myCharz().isTichXanh)
        {
            MainMod2.PaintTicks(g, true, 58, 17);
        }
        string text = (!GameCanvas2.loginScr.tfUser.getText().Equals(string.Empty)) ? GameCanvas2.loginScr.tfUser.getText() : mResources2.not_register_yet;
        mFont2.tahoma_7_yellow.drawString(g, mResources2.account_server + " " + ServerListScreen2.nameServer[ServerListScreen2.ipSelect] + ": " + text, 60, 27, mFont2.LEFT, mFont2.tahoma_7_grey);
    }

    private void paintGiaoDichInfo(mGraphics2 g)
    {
        mFont2.tahoma_7_yellow.drawString(g, mResources2.select_item, 60, 4, mFont2.LEFT, mFont2.tahoma_7_grey);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.lock_trade, 60, 16, mFont2.LEFT, mFont2.tahoma_7_grey);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.wait_opp_lock_trade, 60, 27, mFont2.LEFT, mFont2.tahoma_7_grey);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.press_done, 60, 38, mFont2.LEFT, mFont2.tahoma_7_grey);
    }

    private void paintMyInfo(mGraphics2 g)
    {
        paintCharInfo(g, Char2.myCharz());
    }

    private void paintPetInfo(mGraphics2 g, bool isPet2)
    {
        Char2 pet = isPet2 ? Char2.MyPet2z() : Char2.myPetz();
        mFont2.tahoma_7_yellow.drawString(g, mResources2.power + ": " + NinjaUtil2.getMoneys(pet.cPower), X + 60, 4, mFont2.LEFT, mFont2.tahoma_7_grey);
        if (pet.cPower > 0)
        {
            mFont2.tahoma_7_yellow.drawString(g, (!pet.me) ? pet.currStrLevel : pet.getStrLevel(), X + 60, 16, mFont2.LEFT, mFont2.tahoma_7_grey);
        }
        if (pet.cDamFull > 0)
        {
            mFont2.tahoma_7_yellow.drawString(g, mResources2.hit_point + ": " + pet.cDamFull, X + 60, 27, mFont2.LEFT, mFont2.tahoma_7_grey);
        }
        if (pet.cMaxStamina > 0)
        {
            mFont2.tahoma_7_yellow.drawString(g, mResources2.vitality, X + 60, 38, mFont2.LEFT, mFont2.tahoma_7_grey);
            g.drawImage(GameScr2.imgMPLost, X + 100, 41, 0);
            int num = pet.cStamina * mGraphics2.getImageWidth(GameScr2.imgMP) / pet.cMaxStamina;
            g.setClip(100, X + 41, num, 20);
            g.drawImage(GameScr2.imgMP, X + 100, 41, 0);
        }
        g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
    }

    private void paintPetSkillInfo(mGraphics2 g, bool isPet2)
    {
        Char2 pet = isPet2 ? Char2.MyPet2z() : Char2.myPetz();
        mFont2.tahoma_7b_white.drawString(g, "HP: " + pet.cHP + "/" + pet.cHPFull, X + 60, 4, mFont2.LEFT, mFont2.tahoma_7b_dark);
        mFont2.tahoma_7b_white.drawString(g, "MP: " + pet.cMP + "/" + pet.cMPFull, X + 60, 16, mFont2.LEFT, mFont2.tahoma_7b_dark);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.critical + ": " + pet.cCriticalFull + "   " + mResources2.armor + ": " + pet.cDefull, X + 60, 27, mFont2.LEFT, mFont2.tahoma_7_grey);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.potential2 + ": " + NinjaUtil2.getMoneys(pet.cTiemNang), X + 60, 38, mFont2.LEFT, mFont2.tahoma_7_grey);
    }

    private void paintCharInfo(mGraphics2 g, Char2 c)
    {
        mFont2.tahoma_7b_white.drawString(g, (c.isTichDo ? "      " : c.isTichXanh ? "      " : string.Empty) + c.cName, X + 60, 4, mFont2.LEFT, mFont2.tahoma_7b_dark);
        if (c.isTichDo)
        {
            MainMod2.PaintTicks(g, false, X + 60 - 1, 5 - 1);
        }
        else if (c.isTichXanh)
        {
            MainMod2.PaintTicks(g, true, X + 60, 5 - 1);
        }
        if (c.cMaxStamina > 0)
        {
            mFont2.tahoma_7_yellow.drawString(g, mResources2.vitality, X + 60, 16, mFont2.LEFT, mFont2.tahoma_7_grey);
            g.drawImage(GameScr2.imgMPLost, X + 95, 19, 0);
            int num = c.cStamina * mGraphics2.getImageWidth(GameScr2.imgMP) / c.cMaxStamina;
            g.setClip(95, X + 19, num, 20);
            g.drawImage(GameScr2.imgMP, X + 95, 19, 0);
        }
        g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
        if (c.cPower > 0)
        {
            mFont2.tahoma_7_yellow.drawString(g, (!c.me) ? c.currStrLevel : c.getStrLevel(), X + 60, 27, mFont2.LEFT, mFont2.tahoma_7_grey);
        }
        mFont2.tahoma_7_yellow.drawString(g, mResources2.power + ": " + NinjaUtil2.getMoneys(c.cPower), X + 60, 38, mFont2.LEFT, mFont2.tahoma_7_grey);
    }

    private void paintZoneInfo(mGraphics2 g)
    {
        mFont2.tahoma_7b_white.drawString(g, mResources2.zone + " " + TileMap2.zoneID, 60, 4, mFont2.LEFT, mFont2.tahoma_7b_dark);
        mFont2.tahoma_7_yellow.drawString(g, TileMap2.mapName, 60, 16, mFont2.LEFT, mFont2.tahoma_7_grey);
        mFont2.tahoma_7b_white.drawString(g, TileMap2.zoneID + string.Empty, 25, 27, mFont2.CENTER);
    }

    public int getCompare(Item2 item)
    {
        if (item == null)
        {
            return -1;
        }
        if (item.isTypeBody())
        {
            if (item.itemOption == null)
            {
                return -1;
            }
            ItemOption2 itemOption = item.itemOption[0];
            if (itemOption.optionTemplate.id == 22)
            {
                itemOption.optionTemplate = GameScr2.gI().iOptionTemplates[6];
                itemOption.param *= 1000;
            }
            if (itemOption.optionTemplate.id == 23)
            {
                itemOption.optionTemplate = GameScr2.gI().iOptionTemplates[7];
                itemOption.param *= 1000;
            }
            Item2 item2 = null;
            for (int i = 0; i < Char2.myCharz().arrItemBody.Length; i++)
            {
                Item2 item3 = Char2.myCharz().arrItemBody[i];
                if (itemOption.optionTemplate.id == 22)
                {
                    itemOption.optionTemplate = GameScr2.gI().iOptionTemplates[6];
                    itemOption.param *= 1000;
                }
                if (itemOption.optionTemplate.id == 23)
                {
                    itemOption.optionTemplate = GameScr2.gI().iOptionTemplates[7];
                    itemOption.param *= 1000;
                }
                if (item3 != null && item3.itemOption != null && item3.template.type == item.template.type)
                {
                    item2 = item3;
                    break;
                }
            }
            if (item2 == null)
            {
                return itemOption.param;
            }
            int num = 0;
            num = ((item2 == null || item2.itemOption == null) ? itemOption.param : (itemOption.param - item2.itemOption[0].param));
            if (num < 0)
            {
            }
            else
            {
            }
            return num;
        }
        return 0;
    }

    private void paintMapInfo(mGraphics2 g)
    {
        mFont2.tahoma_7b_white.drawString(g, mResources2.MENUGENDER[TileMap2.planetID], 60, 4, mFont2.LEFT);
        string text = string.Empty;
        if (TileMap2.mapID >= 135 && TileMap2.mapID <= 138)
        {
            text = " " + mResources2.tang + TileMap2.zoneID;
        }
        mFont2.tahoma_7_yellow.drawString(g, TileMap2.mapName + text, 60, 16, mFont2.LEFT);
        mFont2.tahoma_7b_white.drawString(g, mResources2.quest_place + ": ", 60, 27, mFont2.LEFT);
        if (GameScr2.getTaskMapId() >= 0 && GameScr2.getTaskMapId() <= TileMap2.mapNames.Length - 1)
        {
            mFont2.tahoma_7_yellow.drawString(g, TileMap2.mapNames[GameScr2.getTaskMapId()], 60, 38, mFont2.LEFT);
        }
        else
        {
            mFont2.tahoma_7_yellow.drawString(g, mResources2.random, 60, 38, mFont2.LEFT);
        }
    }

    private void paintShopInfo(mGraphics2 g)
    {
        if (currentTabIndex == currentTabName.Length - 1 && GameCanvas2.panel2 == null)
        {
            paintMyInfo(g);
        }
        else if (selected < 0)
        {
            if (typeShop != 2)
            {
                mFont2.tahoma_7_white.drawString(g, mResources2.say_hello, X + 60, 14, 0);
                mFont2.tahoma_7_white.drawString(g, strWantToBuy, X + 60, 26, 0);
                return;
            }
            mFont2.tahoma_7_white.drawString(g, mResources2.say_hello, X + 60, 5, 0);
            mFont2.tahoma_7_white.drawString(g, strWantToBuy, X + 60, 17, 0);
            mFont2.tahoma_7_white.drawString(g, mResources2.page + " " + (currPageShop[currentTabIndex] + 1) + "/" + maxPageShop[currentTabIndex], X + 60, 29, 0);
        }
        else
        {
            if (currentTabIndex < 0 || currentTabIndex > Char2.myCharz().arrItemShop.Length - 1 || selected < 0 || selected > Char2.myCharz().arrItemShop[currentTabIndex].Length - 1)
            {
                return;
            }
            Item2 item = Char2.myCharz().arrItemShop[currentTabIndex][selected];
            if (item != null)
            {
                if (Equals(GameCanvas2.panel) && currentTabIndex <= 3 && typeShop == 2)
                {
                    mFont2.tahoma_7b_white.drawString(g, mResources2.page + " " + (currPageShop[currentTabIndex] + 1) + "/" + maxPageShop[currentTabIndex], X + 55, 4, 0);
                }
                mFont2.tahoma_7b_white.drawString(g, item.template.name, X + 55, 24, 0);
                string st = mResources2.pow_request + " " + Res2.formatNumber(item.template.strRequire);
                if (item.template.strRequire > Char2.myCharz().cPower)
                {
                    mFont2.tahoma_7_yellow.drawString(g, st, X + 55, 35, 0);
                }
                else
                {
                    mFont2.tahoma_7_green.drawString(g, st, X + 55, 35, 0);
                }
            }
        }
    }

    private void paintItemBoxInfo(mGraphics2 g)
    {
        string st = mResources2.used + ": " + hasUse + "/" + Char2.myCharz().arrItemBox.Length + " " + mResources2.place;
        mFont2.tahoma_7b_white.drawString(g, mResources2.chest, 60, 4, 0);
        mFont2.tahoma_7_yellow.drawString(g, st, 60, 16, 0);
    }

    private void paintSkillInfo(mGraphics2 g)
    {
        mFont2.tahoma_7_white.drawString(g, "Top " + Char2.myCharz().rank, X + 45 + (W - 50) / 2, 2, mFont2.CENTER);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.potential_point, X + 45 + (W - 50) / 2, 14, mFont2.CENTER);
        mFont2.tahoma_7_white.drawString(g, string.Empty + NinjaUtil2.getMoneys(Char2.myCharz().cTiemNang), X + ((GameCanvas2.gameTick % 20 > 10) ? (GameCanvas2.gameTick % 4 / 2) : 0) + 45 + (W - 50) / 2, 26, mFont2.CENTER);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.active_point + ": " + NinjaUtil2.getMoneys(Char2.myCharz().cNangdong), X + ((GameCanvas2.gameTick % 20 > 10) ? (GameCanvas2.gameTick % 4 / 2) : 0) + 45 + (W - 50) / 2, 38, mFont2.CENTER);
    }

    private void paintItemBodyBagInfo(mGraphics2 g)
    {
        mFont2.tahoma_7_yellow.drawString(g, mResources2.HP + ": " + Char2.myCharz().cHP + " / " + Char2.myCharz().cHPFull, X + 60, 2, mFont2.LEFT, mFont2.tahoma_7_grey);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.KI + ": " + Char2.myCharz().cMP + " / " + Char2.myCharz().cMPFull, X + 60, 14, mFont2.LEFT, mFont2.tahoma_7_grey);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.hit_point + ": " + Char2.myCharz().cDamFull, X + 60, 26, mFont2.LEFT, mFont2.tahoma_7_grey);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.armor + ": " + Char2.myCharz().cDefull + ", " + mResources2.critical + ": " + Char2.myCharz().cCriticalFull + "%", X + 60, 38, mFont2.LEFT, mFont2.tahoma_7_grey);
    }

    private void paintItemBodyBagInfo(mGraphics2 g, int x, int y)
    {
        mFont2.tahoma_7_yellow.drawString(g, mResources2.HP + ": " + Char2.myCharz().cHP + " / " + Char2.myCharz().cHPFull, x, y + 2, mFont2.LEFT, mFont2.tahoma_7_grey);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.KI + ": " + Char2.myCharz().cMP + " / " + Char2.myCharz().cMPFull, x, y + 14, mFont2.LEFT, mFont2.tahoma_7_grey);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.hit_point + ": " + Char2.myCharz().cDamFull, x, y + 26, mFont2.LEFT, mFont2.tahoma_7_grey);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.armor + ": " + Char2.myCharz().cDefull + ", " + mResources2.critical + ": " + Char2.myCharz().cCriticalFull + "%", x, y + 38, mFont2.LEFT, mFont2.tahoma_7_grey);
    }

    private void paintTopInfo(mGraphics2 g)
    {
        g.setClip(X + 1, Y, W - 2, yScroll - 2);
        g.setColor(9993045);
        g.fillRect(X, Y, W - 2, 50);
        switch (type)
        {
            case 13:
                if (currentTabIndex == 0 || currentTabIndex == 1)
                {
                    if (Equals(GameCanvas2.panel))
                    {
                        SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                        paintGiaoDichInfo(g);
                    }
                    if (Equals(GameCanvas2.panel2) && charMenu != null)
                    {
                        SmallImage2.drawSmallImage(g, charMenu.avatarz(), X + 25, 50, 0, 33);
                        paintCharInfo(g, charMenu);
                    }
                }
                if (currentTabIndex == 2 && charMenu != null)
                {
                    SmallImage2.drawSmallImage(g, charMenu.avatarz(), X + 25, 50, 0, 33);
                    paintCharInfo(g, charMenu);
                }
                break;
            case 12:
                if (currentTabIndex == 0)
                {
                    int id = 1410;
                    for (int i = 0; i < GameScr2.vNpc.size(); i++)
                    {
                        Npc2 npc = (Npc2)GameScr2.vNpc.elementAt(i);
                        if (npc.template.npcTemplateId == idNPC)
                        {
                            id = npc.avatar;
                        }
                    }
                    SmallImage2.drawSmallImage(g, id, X + 25, 50, 0, 33);
                    paintCombineInfo(g);
                }
                if (currentTabIndex == 1)
                {
                    SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                    paintMyInfo(g);
                }
                break;
            case 11:
            case 16:
            case 23:
            case 24:
            case 27:
                SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                paintMyInfo(g);
                break;
            case 15:
                SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                paintMyInfo(g);
                break;
            case 9:
                SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                paintMyInfo(g);
                break;
            case 21:
            case 28:
                Char2 pet = type == 28 ? Char2.MyPet2z() : Char2.myPetz();
                if (currentTabIndex == 0)
                {
                    SmallImage2.drawSmallImage(g, pet.avatarz(), X + 25, 50, 0, 33);
                    paintPetInfo(g, type == 28);
                }
                else if (currentTabIndex == 1)
                {
                    SmallImage2.drawSmallImage(g, pet.avatarz(), X + 25, 50, 0, 33);
                    paintPetSkillInfo(g, type == 28);
                }
                else if (currentTabIndex == 2)
                {
                    SmallImage2.drawSmallImage(g, pet.avatarz(), X + 25, 50, 0, 33);
                    paintPetStatusInfo(g, type == 28);
                }
                else if (currentTabIndex == 3)
                {
                    SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                    paintItemBodyBagInfo(g);
                }
                break;
            case 0:
                if (currentTabIndex == 0)
                {
                    SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                    paintMyInfo(g);
                }
                if (currentTabIndex == 1)
                {
                    SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                    if (isnewInventory)
                    {
                        paintCharInfo(g, Char2.myCharz());
                    }
                    else
                    {
                        paintItemBodyBagInfo(g);
                    }
                }
                if (currentTabIndex == 2)
                {
                    SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                    paintSkillInfo(g);
                }
                if (currentTabIndex == 3)
                {
                    if (mainTabName.Length == 5)
                    {
                        paintClanInfo(g);
                    }
                    else
                    {
                        SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                        paintToolInfo(g);
                    }
                }
                if (currentTabIndex == 4)
                {
                    SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                    paintToolInfo(g);
                }
                break;
            case 25:
                SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                paintMyInfo(g);
                break;
            case 2:
                if (currentTabIndex == 0)
                {
                    SmallImage2.drawSmallImage(g, 526, X + 25, 50, 0, 33);
                    paintItemBoxInfo(g);
                }
                if (currentTabIndex == 1)
                {
                    SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                    paintItemBodyBagInfo(g);
                }
                break;
            case 3:
                SmallImage2.drawSmallImage(g, 561, X + 25, 50, 0, 33);
                paintZoneInfo(g);
                break;
            case 1:
                if (currentTabIndex == currentTabName.Length - 1 && GameCanvas2.panel2 == null)
                {
                    SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                }
                else if (Char2.myCharz().npcFocus != null)
                {
                    SmallImage2.drawSmallImage(g, Char2.myCharz().npcFocus.avatar, X + 25, 50, 0, 33);
                }
                paintShopInfo(g);
                break;
            case 4:
                SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                paintMapInfo(g);
                break;
            case 7:
            case 17:
                SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                paintMyInfo(g);
                break;
            case 8:
                SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                paintMyInfo(g);
                break;
            case 10:
                if (charMenu != null)
                {
                    SmallImage2.drawSmallImage(g, charMenu.avatarz(), X + 25, 50, 0, 33);
                    paintCharInfo(g, charMenu);
                }
                break;
            case 14:
                SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                paintMapInfo(g);
                break;
            case 18:
                SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                paintMyInfo(g);
                break;
            case 19:
            case 26:
                SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                paintToolInfo(g);
                break;
            case 20:
                SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                paintToolInfo(g);
                break;
            case 22:
                SmallImage2.drawSmallImage(g, Char2.myCharz().avatarz(), X + 25, 50, 0, 33);
                paintToolInfo(g);
                break;
            case 5:
            case 6:
                break;
        }
    }

    private void paintChatManager(mGraphics2 g)
    {
    }

    private void paintChatPlayer(mGraphics2 g)
    {
    }

    private string getStatus(int status)
    {
        return status switch
        {
            0 => mResources2.follow,
            1 => mResources2.defend,
            2 => mResources2.attack,
            3 => mResources2.gohome,
            _ => "aaa",
        };
    }

    private void paintPetStatusInfo(mGraphics2 g, bool isPet2)
    {
        Char2 pet = isPet2 ? Char2.MyPet2z() : Char2.myPetz();
        mFont2.tahoma_7b_white.drawString(g, "HP: " + pet.cHP + "/" + pet.cHPFull, X + 60, 4, mFont2.LEFT, mFont2.tahoma_7b_dark);
        mFont2.tahoma_7b_white.drawString(g, "MP: " + pet.cMP + "/" + pet.cMPFull, X + 60, 16, mFont2.LEFT, mFont2.tahoma_7b_dark);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.critical + ": " + pet.cCriticalFull + "   " + mResources2.armor + ": " + pet.cDefull, X + 60, 27, mFont2.LEFT, mFont2.tahoma_7_grey);
        mFont2.tahoma_7_yellow.drawString(g, mResources2.status + ": " + strStatus[pet.petStatus], X + 60, 38, mFont2.LEFT, mFont2.tahoma_7_grey);
    }

    private void paintCombineInfo(mGraphics2 g)
    {
        if (combineTopInfo != null)
        {
            for (int i = 0; i < combineTopInfo.Length; i++)
            {
                mFont2.tahoma_7_white.drawString(g, combineTopInfo[i], X + 45 + (W - 50) / 2, 5 + i * 14, mFont2.CENTER);
            }
        }
    }

    private void paintInfomation(mGraphics2 g)
    {
    }

    public void paintMap(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(-cmxMap, -cmyMap);
        g.drawImage(imgMap, xScroll, yScroll, 0);
        int head = Char2.myCharz().head;
        Part2 part = GameScr2.parts[head];
        SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[0][0][0]].id, xMap, yMap + 5, 0, 3);
        int align = mFont2.CENTER;
        if (xMap <= 40)
        {
            align = mFont2.LEFT;
        }
        if (xMap >= 220)
        {
            align = mFont2.RIGHT;
        }
        mFont2.tahoma_7b_yellow.drawString(g, TileMap2.mapName, xMap, yMap - 12, align, mFont2.tahoma_7_grey);
        int num = -1;
        if (GameScr2.getTaskMapId() != -1)
        {
            for (int i = 0; i < mapId[TileMap2.planetID].Length; i++)
            {
                if (mapId[TileMap2.planetID][i] == GameScr2.getTaskMapId())
                {
                    num = i;
                    break;
                }
                num = 4;
            }
            if (GameCanvas2.gameTick % 4 > 0)
            {
                g.drawImage(ItemMap2.imageFlare, xScroll + mapX[TileMap2.planetID][num], yScroll + mapY[TileMap2.planetID][num], 3);
            }
        }
        if (!GameCanvas2.isTouch)
        {
            g.drawImage(imgBantay, xMove, yMove, StaticObj2.TOP_RIGHT);
            for (int j = 0; j < mapX[TileMap2.planetID].Length; j++)
            {
                int num2 = mapX[TileMap2.planetID][j] + xScroll;
                int num3 = mapY[TileMap2.planetID][j] + yScroll;
                if (Res2.inRect(num2 - 15, num3 - 15, 30, 30, xMove, yMove))
                {
                    align = mFont2.CENTER;
                    if (num2 <= 20)
                    {
                        align = mFont2.LEFT;
                    }
                    if (num2 >= 220)
                    {
                        align = mFont2.RIGHT;
                    }
                    mFont2.tahoma_7b_yellow.drawString(g, TileMap2.mapNames[mapId[TileMap2.planetID][j]], num2, num3 - 12, align, mFont2.tahoma_7_grey);
                    break;
                }
            }
        }
        else if (!trans)
        {
            for (int k = 0; k < mapX[TileMap2.planetID].Length; k++)
            {
                int num4 = mapX[TileMap2.planetID][k] + xScroll;
                int num5 = mapY[TileMap2.planetID][k] + yScroll;
                if (Res2.inRect(num4 - 15, num5 - 15, 30, 30, pX, pY))
                {
                    align = mFont2.CENTER;
                    if (num4 <= 30)
                    {
                        align = mFont2.LEFT;
                    }
                    if (num4 >= 220)
                    {
                        align = mFont2.RIGHT;
                    }
                    g.drawImage(imgBantay, num4, num5, StaticObj2.TOP_RIGHT);
                    mFont2.tahoma_7b_yellow.drawString(g, TileMap2.mapNames[mapId[TileMap2.planetID][k]], num4, num5 - 12, align, mFont2.tahoma_7_grey);
                    break;
                }
            }
        }
        g.translate(-g.getTranslateX(), -g.getTranslateY());
        if (num != -1)
        {
            if (mapX[TileMap2.planetID][num] + xScroll < cmxMap)
            {
                g.drawRegion(Mob2.imgHP, 0, 0, 9, 6, 5, xScroll + 5, yScroll + hScroll / 2 - 4, 0);
            }
            if (cmxMap + wScroll < mapX[TileMap2.planetID][num] + xScroll)
            {
                g.drawRegion(Mob2.imgHP, 0, 0, 9, 6, 6, xScroll + wScroll - 5, yScroll + hScroll / 2 - 4, StaticObj2.TOP_RIGHT);
            }
            if (mapY[TileMap2.planetID][num] < cmyMap)
            {
                g.drawRegion(Mob2.imgHP, 0, 0, 9, 6, 1, xScroll + wScroll / 2, yScroll + 5, StaticObj2.TOP_CENTER);
            }
            if (mapY[TileMap2.planetID][num] > cmyMap + hScroll)
            {
                g.drawRegion(Mob2.imgHP, 0, 0, 9, 6, 0, xScroll + wScroll / 2, yScroll + hScroll - 5, StaticObj2.BOTTOM_HCENTER);
            }
        }
    }

    public void paintTask(mGraphics2 g)
    {
        int num = ((GameCanvas2.h <= 300) ? 15 : 20);
        if (isPaintMap && !GameScr2.gI().isMapDocNhan() && !GameScr2.gI().isMapFize())
        {
            g.drawImage((keyTouchMapButton != 1) ? GameScr2.imgLbtn : GameScr2.imgLbtnFocus, xScroll + wScroll / 2, yScroll + hScroll - num, 3);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.map, xScroll + wScroll / 2, yScroll + hScroll - (num + 5), mFont2.CENTER);
        }
        xstart = xScroll + 5;
        ystart = yScroll + 14;
        yPaint = ystart;
        g.setClip(xScroll, yScroll, wScroll, hScroll - 35);
        if (scroll != null)
        {
            if (scroll.cmy > 0)
            {
                g.drawRegion(Mob2.imgHP, 0, 0, 9, 6, 1, xScroll + wScroll - 12, yScroll + 3, 0);
            }
            if (scroll.cmy < scroll.cmyLim)
            {
                g.drawRegion(Mob2.imgHP, 0, 0, 9, 6, 0, xScroll + wScroll - 12, yScroll + hScroll - 45, 0);
            }
            g.translate(0, -scroll.cmy);
        }
        indexRowMax = 0;
        if (indexMenu == 0)
        {
            bool flag = false;
            if (Char2.myCharz().taskMaint != null)
            {
                for (int i = 0; i < Char2.myCharz().taskMaint.names.Length; i++)
                {
                    mFont2.tahoma_7_grey.drawString(g, Char2.myCharz().taskMaint.names[i], xScroll + wScroll / 2, yPaint - 5 + i * 12, mFont2.CENTER);
                    indexRowMax++;
                }
                yPaint += (Char2.myCharz().taskMaint.names.Length - 1) * 12;
                int num2 = 0;
                string empty = string.Empty;
                for (int j = 0; j < Char2.myCharz().taskMaint.subNames.Length; j++)
                {
                    if (Char2.myCharz().taskMaint.subNames[j] != null)
                    {
                        num2 = j;
                        empty = "- " + Char2.myCharz().taskMaint.subNames[j];
                        if (Char2.myCharz().taskMaint.counts[j] != -1)
                        {
                            if (Char2.myCharz().taskMaint.index == j)
                            {
                                if (Char2.myCharz().taskMaint.counts[j] != 1)
                                {
                                    string text = empty;
                                    empty = text + " (" + Char2.myCharz().taskMaint.count + "/" + Char2.myCharz().taskMaint.counts[j] + ")";
                                }
                                if (Char2.myCharz().taskMaint.count == Char2.myCharz().taskMaint.counts[j])
                                {
                                    mFont2.tahoma_7.drawString(g, empty, xstart + 5, yPaint += 12, 0);
                                }
                                else
                                {
                                    mFont2 tahoma_7_grey = mFont2.tahoma_7_grey;
                                    if (!flag)
                                    {
                                        flag = true;
                                        tahoma_7_grey = mFont2.tahoma_7_blue;
                                        tahoma_7_grey.drawString(g, empty, xstart + 5 + ((tahoma_7_grey == mFont2.tahoma_7_blue && GameCanvas2.gameTick % 20 > 10) ? (GameCanvas2.gameTick % 4 / 2) : 0), yPaint += 12, 0);
                                    }
                                    else
                                    {
                                        tahoma_7_grey.drawString(g, "- ...", xstart + 5 + ((tahoma_7_grey == mFont2.tahoma_7_blue && GameCanvas2.gameTick % 20 > 10) ? (GameCanvas2.gameTick % 4 / 2) : 0), yPaint += 12, 0);
                                    }
                                }
                            }
                            else if (Char2.myCharz().taskMaint.index > j)
                            {
                                if (Char2.myCharz().taskMaint.counts[j] != 1)
                                {
                                    string text = empty;
                                    empty = text + " (" + Char2.myCharz().taskMaint.counts[j] + "/" + Char2.myCharz().taskMaint.counts[j] + ")";
                                }
                                mFont2.tahoma_7_white.drawString(g, empty, xstart + 5, yPaint += 12, 0);
                            }
                            else
                            {
                                if (Char2.myCharz().taskMaint.counts[j] != 1)
                                {
                                    empty = empty + " 0/" + Char2.myCharz().taskMaint.counts[j];
                                }
                                mFont2 tahoma_7_grey2 = mFont2.tahoma_7_grey;
                                if (!flag)
                                {
                                    flag = true;
                                    tahoma_7_grey2 = mFont2.tahoma_7_blue;
                                    tahoma_7_grey2.drawString(g, empty, xstart + 5 + ((tahoma_7_grey2 == mFont2.tahoma_7_blue && GameCanvas2.gameTick % 20 > 10) ? (GameCanvas2.gameTick % 4 / 2) : 0), yPaint += 12, 0);
                                }
                                else
                                {
                                    tahoma_7_grey2.drawString(g, "- ...", xstart + 5 + ((tahoma_7_grey2 == mFont2.tahoma_7_blue && GameCanvas2.gameTick % 20 > 10) ? (GameCanvas2.gameTick % 4 / 2) : 0), yPaint += 12, 0);
                                }
                            }
                        }
                        else if (Char2.myCharz().taskMaint.index > j)
                        {
                            mFont2.tahoma_7_white.drawString(g, empty, xstart + 5, yPaint += 12, 0);
                        }
                        else
                        {
                            mFont2 tahoma_7_grey3 = mFont2.tahoma_7_grey;
                            if (!flag)
                            {
                                flag = true;
                                tahoma_7_grey3 = mFont2.tahoma_7_blue;
                                tahoma_7_grey3.drawString(g, empty, xstart + 5 + ((tahoma_7_grey3 == mFont2.tahoma_7_blue && GameCanvas2.gameTick % 20 > 10) ? (GameCanvas2.gameTick % 4 / 2) : 0), yPaint += 12, 0);
                            }
                            else
                            {
                                tahoma_7_grey3.drawString(g, "- ...", xstart + 5 + ((tahoma_7_grey3 == mFont2.tahoma_7_blue && GameCanvas2.gameTick % 20 > 10) ? (GameCanvas2.gameTick % 4 / 2) : 0), yPaint += 12, 0);
                            }
                        }
                        indexRowMax++;
                    }
                    else if (Char2.myCharz().taskMaint.index <= j)
                    {
                        empty = "- " + Char2.myCharz().taskMaint.subNames[num2];
                        mFont2 mFont2 = mFont2.tahoma_7_grey;
                        if (!flag)
                        {
                            flag = true;
                            mFont2 = mFont2.tahoma_7_blue;
                        }
                        mFont2.drawString(g, empty, xstart + 5 + ((mFont2 == mFont2.tahoma_7_blue && GameCanvas2.gameTick % 20 > 10) ? (GameCanvas2.gameTick % 4 / 2) : 0), yPaint += 12, 0);
                    }
                }
                yPaint += 5;
                for (int k = 0; k < Char2.myCharz().taskMaint.details.Length; k++)
                {
                    mFont2.tahoma_7_green2.drawString(g, Char2.myCharz().taskMaint.details[k], xstart + 5, yPaint += 12, 0);
                    indexRowMax++;
                }
            }
            else
            {
                int taskMapId = GameScr2.getTaskMapId();
                sbyte taskNpcId = GameScr2.getTaskNpcId();
                string empty2 = string.Empty;
                if (taskMapId == -3 || taskNpcId == -3)
                {
                    empty2 = mResources2.DES_TASK[3];
                }
                else if (Char2.myCharz().taskMaint == null && Char2.myCharz().ctaskId == 9 && Char2.myCharz().nClass.classId == 0)
                {
                    empty2 = mResources2.TASK_INPUT_CLASS;
                }
                else
                {
                    if (taskNpcId < 0 || taskMapId < 0)
                    {
                        return;
                    }
                    empty2 = mResources2.DES_TASK[0] + Npc2.arrNpcTemplate[taskNpcId].name + mResources2.DES_TASK[1] + TileMap2.mapNames[taskMapId] + mResources2.DES_TASK[2];
                }
                string[] array = mFont2.tahoma_7_white.splitFontArray(empty2, 150);
                for (int l = 0; l < array.Length; l++)
                {
                    if (l == 0)
                    {
                        mFont2.tahoma_7_white.drawString(g, array[l], xstart + 5, yPaint = ystart, 0);
                    }
                    else
                    {
                        mFont2.tahoma_7_white.drawString(g, array[l], xstart + 5, yPaint += 12, 0);
                    }
                }
            }
        }
        else if (indexMenu == 1)
        {
            yPaint = ystart - 12;
            for (int m = 0; m < Char2.myCharz().taskOrders.size(); m++)
            {
                TaskOrder2 taskOrder = (TaskOrder2)Char2.myCharz().taskOrders.elementAt(m);
                mFont2.tahoma_7_white.drawString(g, taskOrder.name, xstart + 5, yPaint += 12, 0);
                if (taskOrder.count == taskOrder.maxCount)
                {
                    mFont2.tahoma_7_white.drawString(g, ((taskOrder.taskId != 0) ? mResources2.KILLBOSS : mResources2.KILL) + " " + Mob2.arrMobTemplate[taskOrder.killId].name + " (" + taskOrder.count + "/" + taskOrder.maxCount + ")", xstart + 5, yPaint += 12, 0);
                }
                else
                {
                    mFont2.tahoma_7_blue.drawString(g, ((taskOrder.taskId != 0) ? mResources2.KILLBOSS : mResources2.KILL) + " " + Mob2.arrMobTemplate[taskOrder.killId].name + " (" + taskOrder.count + "/" + taskOrder.maxCount + ")", xstart + 5, yPaint += 12, 0);
                }
                indexRowMax += 3;
                inforW = popupW - 25;
                paintMultiLine(g, mFont2.tahoma_7_grey, taskOrder.description, xstart + 5, yPaint += 12, 0);
                yPaint += 12;
            }
        }
        if (scroll == null)
        {
            scroll = new Scroll2();
            scroll.setStyle(indexRowMax, 12, xScroll, yScroll, wScroll, hScroll - num - 40, styleUPDOWN: true, 1);
        }
    }

    public void paintMultiLine(mGraphics2 g, mFont2 f, string[] arr, string str, int x, int y, int align)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            string text = arr[i];
            if (text.StartsWith("c"))
            {
                if (text.StartsWith("c0"))
                {
                    text = text.Substring(2);
                    f = mFont2.tahoma_7b_dark;
                }
                else if (text.StartsWith("c1"))
                {
                    text = text.Substring(2);
                    f = mFont2.tahoma_7b_yellow;
                }
                else if (text.StartsWith("c2"))
                {
                    text = text.Substring(2);
                    f = mFont2.tahoma_7b_green;
                }
            }
            if (i == 0)
            {
                f.drawString(g, text, x, y, align);
                continue;
            }
            if (i < indexRow + 30 && i > indexRow - 30)
            {
                f.drawString(g, text, x, y += 12, align);
            }
            else
            {
                y += 12;
            }
            yPaint += 12;
            indexRowMax++;
        }
    }

    public void paintMultiLine(mGraphics2 g, mFont2 f, string str, int x, int y, int align)
    {
        int num = ((!GameCanvas2.isTouch || GameCanvas2.w < 320) ? 10 : 20);
        string[] array = f.splitFontArray(str, inforW - num);
        for (int i = 0; i < array.Length; i++)
        {
            if (i == 0)
            {
                f.drawString(g, array[i], x, y, align);
                continue;
            }
            if (i < indexRow + 15 && i > indexRow - 15)
            {
                f.drawString(g, array[i], x, y += 12, align);
            }
            else
            {
                y += 12;
            }
            yPaint += 12;
            indexRowMax++;
        }
    }

    public void cleanCombine()
    {
        for (int i = 0; i < vItemCombine.size(); i++)
        {
            ((Item2)vItemCombine.elementAt(i)).isSelect = false;
        }
        vItemCombine.removeAllElements();
    }

    public void hideNow()
    {
        if (timeShow > 0)
        {
            isClose = false;
            return;
        }
        if (isTypeShop())
        {
            Char2.myCharz().resetPartTemp();
        }
        if (chatTField != null && type == 13 && chatTField.isShow)
        {
            chatTField = null;
        }
        if (type == 13 && !isAccept)
        {
            Service2.gI().giaodich(3, -1, -1, -1);
        }
        SoundMn2.gI().buttonClose();
        GameScr2.isPaint = true;
        TileMap2.lastPlanetId = -1;
        imgMap = null;
        mSystem2.gcc();
        isClanOption = false;
        isClose = true;
        cleanCombine();
        Hint2.clickNpc();
        GameCanvas2.panel2 = null;
        GameCanvas2.clearAllPointerEvent();
        GameCanvas2.clearKeyPressed();
        pointerDownTime = (pointerDownFirstX = 0);
        pointerIsDowning = false;
        isShow = false;
        if ((Char2.myCharz().cHP <= 0 || Char2.myCharz().statusMe == 14 || Char2.myCharz().statusMe == 5) && Char2.myCharz().meDead)
        {
            Command2 center = new Command2(mResources2.DIES[0], 11038, GameScr2.gI());
            GameScr2.gI().center = center;
            Char2.myCharz().cHP = 0;
        }
    }

    public void hide()
    {
        if (timeShow > 0)
        {
            isClose = false;
            return;
        }
        if (isTypeShop())
        {
            Char2.myCharz().resetPartTemp();
        }
        if (chatTField != null && type == 13 && chatTField.isShow)
        {
            chatTField = null;
        }
        if (type == 13 && !isAccept)
        {
            Service2.gI().giaodich(3, -1, -1, -1);
        }
        if (type == 15)
        {
            Service2.gI().sendThachDau(-1);
        }
        SoundMn2.gI().buttonClose();
        GameScr2.isPaint = true;
        TileMap2.lastPlanetId = -1;
        if (imgMap != null)
        {
            imgMap.texture = null;
            imgMap = null;
        }
        mSystem2.gcc();
        isClanOption = false;
        if (type != 4)
        {
            if (type == 24)
            {
                setTypeGameInfo();
            }
            else if (type == 23)
            {
                setTypeMain();
            }
            else if (type == 3 || type == 14)
            {
                if (isChangeZone)
                {
                    isClose = true;
                }
                else
                {
                    setTypeMain();
                    cmx = cmtoX = 0;
                }
            }
            else if (type == 18 || type == 19 || type == 20 || type == 21 || type == 26 || type == 27 || type == 28)
            {
                setTypeMain();
                cmx = cmtoX = 0;
            }
            else if (type == 8 || type == 11 || type == 16)
            {
                setTypeAccount();
                cmx = (cmtoX = 0);
            }
            else
            {
                isClose = true;
            }
        }
        else
        {
            setTypeMain();
            cmx = (cmtoX = 0);
        }
        Hint2.clickNpc();
        GameCanvas2.panel2 = null;
        GameCanvas2.clearAllPointerEvent();
        GameCanvas2.clearKeyPressed();
        GameCanvas2.isFocusPanel2 = false;
        pointerDownTime = (pointerDownFirstX = 0);
        pointerIsDowning = false;
        if ((Char2.myCharz().cHP <= 0 || Char2.myCharz().statusMe == 14 || Char2.myCharz().statusMe == 5) && Char2.myCharz().meDead)
        {
            Command2 center = new Command2(mResources2.DIES[0], 11038, GameScr2.gI());
            GameScr2.gI().center = center;
            Char2.myCharz().cHP = 0;
        }
    }

    public void update()
    {
        if (chatTField != null && chatTField.isShow)
        {
            chatTField.update();
            return;
        }
        if (isKiguiXu)
        {
            delayKigui++;
            if (delayKigui == 10)
            {
                delayKigui = 0;
                isKiguiXu = false;
                chatTField.tfChat.setText(string.Empty);
                chatTField.strChat = mResources2.kiguiXuchat + " ";
                chatTField.tfChat.name = mResources2.input_money;
                chatTField.to = string.Empty;
                chatTField.isShow = true;
                chatTField.tfChat.setIputType(TField2.INPUT_TYPE_NUMERIC);
                chatTField.tfChat.setMaxTextLenght(9);
                if (GameCanvas2.isTouch)
                {
                    chatTField.tfChat.doChangeToTextBox();
                }
                if (Main2.isWindowsPhone)
                {
                    chatTField.tfChat.strInfo = chatTField.strChat;
                }
                if (Main2.isIPhone)
                {
                    chatTField.startChat(this, string.Empty);
                }
            }
            return;
        }
        if (isKiguiLuong)
        {
            delayKigui++;
            if (delayKigui == 10)
            {
                delayKigui = 0;
                isKiguiLuong = false;
                chatTField.tfChat.setText(string.Empty);
                chatTField.strChat = mResources2.kiguiLuongchat + "  ";
                chatTField.tfChat.name = mResources2.input_money;
                chatTField.to = string.Empty;
                chatTField.isShow = true;
                chatTField.tfChat.setIputType(TField2.INPUT_TYPE_NUMERIC);
                chatTField.tfChat.setMaxTextLenght(9);
                if (GameCanvas2.isTouch)
                {
                    chatTField.tfChat.doChangeToTextBox();
                }
                if (Main2.isWindowsPhone)
                {
                    chatTField.tfChat.strInfo = chatTField.strChat;
                }
                if (Main2.isIPhone)
                {
                    chatTField.startChat(this, string.Empty);
                }
            }
            return;
        }
        if (scroll != null)
        {
            scroll.updatecm();
        }
        if (tabIcon != null && tabIcon.isShow)
        {
            tabIcon.update();
            return;
        }
        moveCamera();
        if (isTabInven() && isnewInventory)
        {
            if (eBanner == null)
            {
                eBanner = new Effect2_(205, 0, 0, 3, 10, -1);
                eBanner.typeEff = 2;
            }
            if (eBanner != null)
            {
                eBanner.update();
            }
        }
        if (waitToPerform > 0)
        {
            waitToPerform--;
            if (waitToPerform == 0)
            {
                lastSelect[currentTabIndex] = selected;
                switch (type)
                {
                    case 23:
                        doFireGameInfo();
                        break;
                    case 21:
                        doFirePetMain();
                        break;
                    case 28:
                        DoFirePet2Main();
                        break;
                    case 0:
                        doFireMain();
                        break;
                    case 2:
                        doFireBox();
                        break;
                    case 3:
                        doFireZone();
                        break;
                    case 1:
                    case 17:
                        doFireShop();
                        break;
                    case 25:
                        doSpeacialSkill();
                        break;
                    case 4:
                        doFireMap();
                        break;
                    case 14:
                        doFireMapTrans();
                        break;
                    case 7:
                        if (Equals(GameCanvas2.panel2) && GameCanvas2.panel.type == 2)
                        {
                            doFireBox();
                            return;
                        }
                        doFireInventory();
                        break;
                    case 8:
                        doFireLogMessage();
                        break;
                    case 9:
                        doFireArchivement();
                        break;
                    case 10:
                        doFirePlayerMenu();
                        break;
                    case 11:
                        doFireFriend();
                        break;
                    case 16:
                        doFireEnemy();
                        break;
                    case 15:
                        doFireTop();
                        break;
                    case 12:
                        doFireCombine();
                        break;
                    case 13:
                        doFireGiaoDich();
                        break;
                    case 18:
                        doFireChangeFlag();
                        break;
                    case 19:
                        doFireOption();
                        break;
                    case 20:
                        doFireAccount();
                        break;
                    case 22:
                        doFireAuto();
                        break;
                    case 26:
                        DoFireModFunc();
                        break;
                }
            }
        }
        for (int i = 0; i < ClanMessage2.vMessage.size(); i++)
        {
            ((ClanMessage2)ClanMessage2.vMessage.elementAt(i)).update();
        }
        updateCombineEff();
    }

    private void doSpeacialSkill()
    {
        string info = Char2.myCharz().infoSpeacialSkill[0][selected];
        GameScr2.info1.addInfo(info, 0);
        MyVector2 myVector8 = new();
        myVector8.addElement(new Command2(MainMod2.strChooseIntrinsic, this, 8011, info));
        GameCanvas2.menu.startAt(myVector8, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
    }

    private void doFireGameInfo()
    {
        if (selected != -1)
        {
            infoSelect = selected;
            ((GameInfo2)vGameInfo.elementAt(infoSelect)).hasRead = true;
            Rms2.saveRMSInt(((GameInfo2)vGameInfo.elementAt(infoSelect)).id + string.Empty, 1);
            setTypeGameSubInfo();
        }
    }

    private void doFireAuto()
    {
    }

    private void DoFirePet2Main()
    {
        if (currentTabIndex == 0)
        {
            if (selected == -1 || selected > Char2.MyPet2z().arrItemBody.Length - 1)
            {
                return;
            }
            MyVector2 myVector = new(string.Empty);
            Item2 item = Char2.MyPet2z().arrItemBody[selected];
            currItem = item;
            if (currItem != null)
            {
                myVector.addElement(new Command2(mResources2.MOVEOUT, this, 2008, currItem));
                GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                addItemDetail(currItem);
            }
            else
            {
                cp = null;
            }
        }
        else if (currentTabIndex == 1)
        {
            DoFirePetSkill();
        }
        else if (currentTabIndex == 2)
        {
            doFirePetStatus();
        }
        else if (currentTabIndex == 3)
        {
            doFireInventory();
        }
    }

    private void doFirePetMain()
    {
        if (currentTabIndex == 0)
        {
            if (selected == -1 || selected > Char2.myPetz().arrItemBody.Length - 1)
            {
                return;
            }
            MyVector2 myVector = new MyVector2(string.Empty);
            Item2 item = Char2.myPetz().arrItemBody[selected];
            currItem = item;
            if (currItem != null)
            {
                myVector.addElement(new Command2(mResources2.MOVEOUT, this, 2006, currItem));
                GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                addItemDetail(currItem);
            }
            else
            {
                cp = null;
            }
        }
        else if (currentTabIndex == 1)
        {
            DoFirePetSkill();
        }
        else if (currentTabIndex == 2)
        {
            doFirePetStatus();
        }
        else if (currentTabIndex == 3)
        {
            doFireInventory();
        }
    }

    private void doFirePetStatus()
    {
        if (selected == -1)
        {
            return;
        }
        if (selected == 5)
        {
            GameCanvas2.startYesNoDlg(mResources2.sure_fusion, new Command2(mResources2.YES, type == 28 ? 888352 : 888351), new Command2(mResources2.NO, 2001));
            return;
        }
        if (type == 28)
        {
            Service2.gI().pet2Status((sbyte)selected);
            if (selected < 4)
            {
                Char2.MyPet2z().petStatus = (sbyte)selected;
            }
        }
        else
        {
            Service2.gI().petStatus((sbyte)selected);
            if (selected < 4)
            {
                Char2.myPetz().petStatus = (sbyte)selected;
            }
        }
    }

    private void doFireTop()
    {
        if (selected >= -1)
        {
            if (isThachDau)
            {
                Service2.gI().sendTop(topName, (sbyte)selected);
                return;
            }
            MyVector2 myVector = new(string.Empty);
            myVector.addElement(new Command2(mResources2.CHAR_ORDER[0], this, 9999, (TopInfo2)vTop.elementAt(selected)));
            GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
            addThachDauDetail((TopInfo2)vTop.elementAt(selected));
        }
    }

    private void doFireMapTrans()
    {
        doFireZone();
    }

    private void doFireGiaoDich()
    {
        if (currentTabIndex == 0 && Equals(GameCanvas2.panel))
        {
            doFireInventory();
            return;
        }
        if ((currentTabIndex == 0 && Equals(GameCanvas2.panel2)) || currentTabIndex == 2)
        {
            if (Equals(GameCanvas2.panel2))
            {
                currItem = (Item2)GameCanvas2.panel2.vFriendGD.elementAt(selected);
            }
            else
            {
                currItem = (Item2)GameCanvas2.panel.vFriendGD.elementAt(selected);
            }
            Res2.outz2("toi day select= " + selected);
            MyVector2 myVector = new MyVector2();
            myVector.addElement(new Command2(mResources2.CLOSE, this, 8000, currItem));
            if (currItem != null)
            {
                GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                addItemDetail(currItem);
            }
            else
            {
                cp = null;
            }
        }
        if (currentTabIndex == 1)
        {
            if (selected == currentListLength - 3)
            {
                if (isLock)
                {
                    return;
                }
                putMoney();
            }
            else if (selected == currentListLength - 2)
            {
                if (!isAccept)
                {
                    isLock = !isLock;
                    if (isLock)
                    {
                        Service2.gI().giaodich(5, -1, -1, -1);
                    }
                    else
                    {
                        hide();
                        InfoDlg2.showWait();
                        Service2.gI().giaodich(3, -1, -1, -1);
                    }
                }
                else
                {
                    isAccept = false;
                }
            }
            else if (selected == currentListLength - 1)
            {
                if (isLock && !isAccept && isFriendLock)
                {
                    GameCanvas2.startYesNoDlg(mResources2.do_u_sure_to_trade, new Command2(mResources2.YES, this, 7002, null), new Command2(mResources2.NO, this, 4005, null));
                }
            }
            else
            {
                if (isLock)
                {
                    return;
                }
                currItem = (Item2)GameCanvas2.panel.vMyGD.elementAt(selected);
                MyVector2 myVector2 = new MyVector2();
                myVector2.addElement(new Command2(mResources2.CLOSE, this, 8000, currItem));
                if (currItem != null)
                {
                    GameCanvas2.menu.startAt(myVector2, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                    addItemDetail(currItem);
                }
                else
                {
                    cp = null;
                }
            }
        }
        if (GameCanvas2.isTouch)
        {
            selected = -1;
        }
    }

    private void doFireCombine()
    {
        if (currentTabIndex == 0)
        {
            if (selected == -1 || vItemCombine.size() == 0)
            {
                return;
            }
            if (selected == vItemCombine.size())
            {
                keyTouchCombine = -1;
                selected = (GameCanvas2.isTouch ? (-1) : 0);
                InfoDlg2.showWait();
                Service2.gI().combine(1, vItemCombine);
                return;
            }
            if (selected > vItemCombine.size() - 1)
            {
                return;
            }
            currItem = (Item2)GameCanvas2.panel.vItemCombine.elementAt(selected);
            MyVector2 myVector = new MyVector2();
            myVector.addElement(new Command2(mResources2.GETOUT, this, 6001, currItem));
            if (MainMod2.isAutoPhaLe)
            {
                myVector.addElement(new Command2("Nhập số sao", this, 8010, this.currItem));
            }
            if (currItem != null)
            {
                GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                addItemDetail(currItem);
            }
            else
            {
                cp = null;
            }
        }
        if (currentTabIndex == 1)
        {
            doFireInventory();
        }
    }

    private void doFirePlayerMenu()
    {
        if (selected != -1)
        {
            isSelectPlayerMenu = true;
            hide();
        }
    }

    private void doFireShop()
    {
        currItem = null;
        if (selected < 0)
        {
            return;
        }
        MyVector2 myVector = new MyVector2();
        if (currentTabIndex < currentTabName.Length - ((GameCanvas2.panel2 == null) ? 1 : 0) && type != 17)
        {
            currItem = Char2.myCharz().arrItemShop[currentTabIndex][selected];
            if (currItem != null)
            {
                if (currItem.isBuySpec)
                {
                    if (currItem.buySpec > 0)
                    {
                        myVector.addElement(new Command2(mResources2.buy_with + "\n" + Res2.formatNumber2(currItem.buySpec), this, 3005, currItem));
                        myVector.addElement(new Command2(MainMod2.strAutoBuy, this, 3006, currItem));
                    }
                }
                else if (typeShop == 4)
                {
                    myVector.addElement(new Command2(mResources2.receive_upper, this, 30001, currItem));
                    myVector.addElement(new Command2(mResources2.DELETE, this, 30002, currItem));
                    myVector.addElement(new Command2(mResources2.receive_all, this, 30003, currItem));
                }
                else if (currItem.buyCoin == 0 && currItem.buyGold == 0)
                {
                    if (currItem.powerRequire != 0)
                    {
                        myVector.addElement(new Command2(mResources2.learn_with + "\n" + Res2.formatNumber(currItem.powerRequire) + " \n" + mResources2.potential, this, 3004, currItem));
                    }
                    else
                    {
                        myVector.addElement(new Command2(mResources2.receive_upper + "\n" + mResources2.free, this, 3000, currItem));
                    }
                }
                else if (typeShop == 8)
                {
                    if (currItem.buyCoin > 0)
                    {
                        myVector.addElement(new Command2(mResources2.buy_with + "\n" + Res2.formatNumber2(currItem.buyCoin) + "\n" + mResources2.XU, this, 30001, currItem));
                    }
                    if (currItem.buyGold > 0)
                    {
                        myVector.addElement(new Command2(mResources2.buy_with + "\n" + Res2.formatNumber2(currItem.buyGold) + "\n" + mResources2.LUONG, this, 30002, currItem));
                    }
                }
                else if (typeShop != 2)
                {
                    if (currItem.buyCoin > 0)
                    {
                        myVector.addElement(new Command2(mResources2.buy_with + "\n" + Res2.formatNumber2(currItem.buyCoin) + "\n" + mResources2.XU, this, 3000, currItem));
                    }
                    if (currItem.buyGold > 0)
                    {
                        myVector.addElement(new Command2(mResources2.buy_with + "\n" + Res2.formatNumber2(currItem.buyGold) + "\n" + mResources2.LUONG, this, 3001, currItem));
                    }
                    myVector.addElement(new Command2(MainMod2.strAutoBuy, this, 3006, currItem));
                }
                else // type 2
                {
                    if (currItem.buyCoin != -1)
                    {
                        myVector.addElement(new Command2(mResources2.buy_with + "\n" + Res2.formatNumber2(currItem.buyCoin) + "\n" + mResources2.XU, this, 10016, currItem));
                    }
                    if (currItem.buyGold != -1)
                    {
                        myVector.addElement(new Command2(mResources2.buy_with + "\n" + Res2.formatNumber2(currItem.buyGold) + "\n" + mResources2.LUONG, this, 10017, currItem));
                    }
                }
            }
        }
        else if (typeShop == 0)
        {
            if (selected == 0)
            {
                setNewSelected(Char2.myCharz().arrItemBody.Length + Char2.myCharz().arrItemBag.Length, resetSelect: false);
            }
            else
            {
                currItem = null;
                if (!GetInventorySelect_isbody(selected, newSelected, Char2.myCharz().arrItemBody))
                {
                    Item2 item = Char2.myCharz().arrItemBag[GetInventorySelect_bag(selected, newSelected, Char2.myCharz().arrItemBody)];
                    if (item != null)
                    {
                        currItem = item;
                    }
                }
                else
                {
                    Item2 item2 = Char2.myCharz().arrItemBody[GetInventorySelect_body(selected, newSelected)];
                    if (item2 != null)
                    {
                        currItem = item2;
                    }
                }
                if (currItem != null)
                {
                    myVector.addElement(new Command2(mResources2.SALE, this, 3002, currItem));
                }
            }
        }
        else
        {
            if (type == 17)
            {
                currItem = Char2.myCharz().arrItemShop[4][selected];
            }
            else
            {
                currItem = Char2.myCharz().arrItemShop[currentTabIndex][selected];
            }
            if (currItem.buyType == 0)
            {
                if (currItem.isHaveOption(87))
                {
                    myVector.addElement(new Command2(mResources2.kiguiLuong, this, 10013, currItem));
                }
                else
                {
                    myVector.addElement(new Command2(mResources2.kiguiXu, this, 10012, currItem));
                }
            }
            else if (currItem.buyType == 1)
            {
                myVector.addElement(new Command2(mResources2.huykigui, this, 10014, currItem));
                myVector.addElement(new Command2(mResources2.upTop, this, 10018, currItem));
            }
            else if (currItem.buyType == 2)
            {
                myVector.addElement(new Command2(mResources2.nhantien, this, 10015, currItem));
            }
        }
        if (currItem != null)
        {
            Char2.myCharz().setPartTemp(currItem.headTemp, currItem.bodyTemp, currItem.legTemp, currItem.bagTemp);
            GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
            addItemDetail(currItem);
        }
        else
        {
            cp = null;
        }
    }

    private void doFireArchivement()
    {
        if (selected >= 0 && Char2.myCharz().arrArchive[selected].isFinish && !Char2.myCharz().arrArchive[selected].isRecieve)
        {
            if (!GameCanvas2.isTouch)
            {
                Service2.gI().getArchivemnt(selected);
            }
            else if (GameCanvas2.px > xScroll + wScroll - 40)
            {
                Service2.gI().getArchivemnt(selected);
            }
        }
    }

    private void doFireInventory()
    {
        if (Char2.myCharz().statusMe == 14)
        {
            GameCanvas2.startOKDlg(mResources2.can_not_do_when_die);
        }
        else
        {
            if (selected == -1)
            {
                return;
            }
            if (selected == 0)
            {
                setNewSelected(Char2.myCharz().arrItemBody.Length + Char2.myCharz().arrItemBag.Length, resetSelect: false);
                return;
            }
            currItem = null;
            MyVector2 myVector = new MyVector2();
            if (isnewInventory && isnewInventory)
            {
                currItem = itemInvenNew;
                if (newSelected == 0)
                {
                    myVector.addElement(new Command2(mResources2.GETOUT, this, 2002, currItem));
                }
                else if (GameCanvas2.panel.type == 12)
                {
                    myVector.addElement(new Command2(mResources2.use_for_combine, this, 6000, currItem));
                }
                else if (GameCanvas2.panel.type == 13)
                {
                    myVector.addElement(new Command2(mResources2.use_for_trade, this, 7000, currItem));
                }
                else if (currItem.isTypeBody())
                {
                    myVector.addElement(new Command2(mResources2.USE, this, 2000, currItem));
                    if (Char2.myCharz().havePet)
                    {
                        myVector.addElement(new Command2(mResources2.MOVEFORPET, this, 2005, currItem));
                    }
                    if (Char2.myCharz().havePet2)
                    {
                        myVector.addElement(new Command2(MainMod2.strUseForPet2, this, 2007, currItem));
                    }
                }
                else
                {
                    myVector.addElement(new Command2(mResources2.USE, this, 2001, currItem));
                    if (Char2.myCharz().havePet)
                    {
                        myVector.addElement(new Command2(mResources2.MOVEFORPET, this, 2005, currItem));
                    }
                    if (Char2.myCharz().havePet2)
                    {
                        myVector.addElement(new Command2(MainMod2.strUseForPet2, this, 2007, currItem));
                    }
                }
            }
            else if (!GetInventorySelect_isbody(selected, newSelected, Char2.myCharz().arrItemBody))
            {
                Item2 item = Char2.myCharz().arrItemBag[GetInventorySelect_bag(selected, newSelected, Char2.myCharz().arrItemBody)];
                if (item != null)
                {
                    currItem = item;
                    if (GameCanvas2.panel.type == 12)
                    {
                        myVector.addElement(new Command2(mResources2.use_for_combine, this, 6000, currItem));
                    }
                    else if (GameCanvas2.panel.type == 13)
                    {
                        myVector.addElement(new Command2(mResources2.use_for_trade, this, 7000, currItem));
                    }
                    else if (item.isTypeBody())
                    {
                        myVector.addElement(new Command2(mResources2.USE, this, 2000, currItem));
                        if (Char2.myCharz().havePet)
                        {
                            myVector.addElement(new Command2(mResources2.MOVEFORPET, this, 2005, currItem));
                        }
                        if (Char2.myCharz().havePet2)
                        {
                            myVector.addElement(new Command2(MainMod2.strUseForPet2, this, 2007, currItem));
                        }
                    }
                    else
                    {
                        myVector.addElement(new Command2(mResources2.USE, this, 2001, currItem));
                        if (Char2.myCharz().havePet)
                        {
                            myVector.addElement(new Command2(mResources2.MOVEFORPET, this, 2005, currItem));
                        }
                        if (Char2.myCharz().havePet2)
                        {
                            myVector.addElement(new Command2(MainMod2.strUseForPet2, this, 2007, currItem));
                        }
                    }
                }
            }
            else
            {
                Item2 item2 = Char2.myCharz().arrItemBody[GetInventorySelect_body(selected, newSelected)];
                if (item2 != null)
                {
                    currItem = item2;
                    myVector.addElement(new Command2(mResources2.GETOUT, this, 2002, currItem));
                }
            }
            if (currItem != null)
            {
                Char2.myCharz().setPartTemp(currItem.headTemp, currItem.bodyTemp, currItem.legTemp, currItem.bagTemp);
                if (GameCanvas2.panel.type != 12 && GameCanvas2.panel.type != 13)
                {
                    if (position == 0)
                    {
                        myVector.addElement(new Command2(mResources2.MOVEOUT, this, 2003, currItem));
                        if (this.currItem.template.type == 29 || this.currItem.template.type == 33 || this.currItem.template.id == 380 || this.currItem.quantity >= 2)
                        {
                            if (MainMod2.listItemAuto.Exists(i => i.id == currItem.template.id))
                            {
                                myVector.addElement(new Command2(MainMod2.strRemoveAutoItem, MainMod2.GI(), 501, currItem));
                            }
                            else
                            {
                                myVector.addElement(new Command2(MainMod2.strAddAutoItem, MainMod2.GI(), 500, currItem));
                            }
                        }
                    }
                    if (position == 1)
                    {
                        myVector.addElement(new Command2(mResources2.SALE, this, 3002, currItem));
                    }
                }
                GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                addItemDetail(currItem);
            }
            else
            {
                cp = null;
            }
        }
    }

    private void doRada()
    {
        hide();
        if (RadarScr2.list == null || RadarScr2.list.size() == 0)
        {
            Service2.gI().SendRada(0, -1);
            RadarScr2.gI().switchToMe();
        }
        else
        {
            RadarScr2.gI().switchToMe();
        }
    }

    private void doFireTool()
    {
        if (selected < 0)
        {
            return;
        }
        if (SoundMn2.IsDelAcc && selected == strTool.Length - 1)
        {
            Service2.gI().sendDelAcc();
            return;
        }
        if (!Char2.myCharz().havePet && !Char2.myCharz().havePet2)
        {
            switch (selected)
            {
                case 0:
                    setTypeGameInfo();
                    break;
                case 1:
                    SetTypeModFunc();
                    break;
                case 2:
                    SetTypePlayerInfo();
                    break;
                case 3:
                    hide();
                    doRada();
                    break;
                case 4:
                    Service2.gI().getFlag(0, -1);
                    InfoDlg2.showWait();
                    break;
                case 5:
                    if (Char2.myCharz().statusMe == 14)
                    {
                        GameCanvas2.startOKDlg(mResources2.can_not_do_when_die);
                    }
                    else
                    {
                        MainMod2.GI().userOpenZones = true;
                        Service2.gI().openUIZone();
                    }
                    break;
                case 6:
                    MainMod2.DoChatGlobal();
                    break;
                case 7:
                    setTypeAccount();
                    break;
                case 8:
                    setTypeOption();
                    break;
                case 9:
                    GameCanvas2.loginScr.backToRegister();
                    break;
                case 10:
                    if (GameCanvas2.loginScr.isLogin2)
                    {
                        SoundMn2.gI().backToRegister();
                    }
                    break;
            }
            return;
        }
        if (Char2.myCharz().havePet && Char2.myCharz().havePet2)
        {
            switch (selected)
            {
                case 0:
                    setTypeGameInfo();
                    break;
                case 1:
                    SetTypeModFunc();
                    break;
                case 2:
                    SetTypePlayerInfo();
                    break;
                case 3:
                    hide();
                    doRada();
                    break;
                case 4:
                    doFirePet();
                    break;
                case 5:
                    doFirePet2();
                    break;
                case 6:
                    Service2.gI().getFlag(0, -1);
                    InfoDlg2.showWait();
                    break;
                case 7:
                    if (Char2.myCharz().statusMe == 14)
                    {
                        GameCanvas2.startOKDlg(mResources2.can_not_do_when_die);
                    }
                    else
                    {
                        MainMod2.GI().userOpenZones = true;
                        Service2.gI().openUIZone();
                    }
                    break;
                case 8:
                    MainMod2.DoChatGlobal();
                    break;
                case 9:
                    setTypeAccount();
                    break;
                case 10:
                    setTypeOption();
                    break;
                case 11:
                    GameCanvas2.loginScr.backToRegister();
                    break;
                case 12:
                    if (GameCanvas2.loginScr.isLogin2)
                    {
                        SoundMn2.gI().backToRegister();
                    }
                    break;
            }
            return;
        }
        switch (selected)
        {
            case 0:
                setTypeGameInfo();
                break;
            case 1:
                SetTypeModFunc();
                break;
            case 2:
                SetTypePlayerInfo();
                break;
            case 3:
                hide();
                doRada();
                break;
            case 4:
                if (Char2.myCharz().havePet)
                {
                    doFirePet();
                }
                else
                {
                    doFirePet2();
                }
                break;
            case 5:
                Service2.gI().getFlag(0, -1);
                InfoDlg2.showWait();
                break;
            case 6:
                if (Char2.myCharz().statusMe == 14)
                {
                    GameCanvas2.startOKDlg(mResources2.can_not_do_when_die);
                }
                else
                {
                    MainMod2.GI().userOpenZones = true;
                    Service2.gI().openUIZone();
                }
                break;
            case 7:
                MainMod2.DoChatGlobal();
                break;
            case 8:
                setTypeAccount();
                break;
            case 9:
                setTypeOption();
                break;
            case 10:
                GameCanvas2.loginScr.backToRegister();
                break;
            case 11:
                if (GameCanvas2.loginScr.isLogin2)
                {
                    SoundMn2.gI().backToRegister();
                }
                break;
        }
    }

    private void setTypeGameSubInfo()
    {
        string content = ((GameInfo2)vGameInfo.elementAt(infoSelect)).content;
        contenInfo = mFont2.tahoma_7_grey.splitFontArray(content, wScroll - 40);
        currentListLength = contenInfo.Length;
        ITEM_HEIGHT = 16;
        selected = (GameCanvas2.isTouch ? (-1) : 0);
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        type = 24;
        setType(0);
    }

    private void SetTypePlayerInfo()
    {
        string content = "Tộc: " + (Char2.myCharz().cgender == 0 ? "Trái Đất" : Char2.myCharz().cgender == 1 ? "Namek" : "Xayda") + "\n" +
            "HP: " + NinjaUtil2.getMoneys(Char2.myCharz().cHP) + " / " + NinjaUtil2.getMoneys(Char2.myCharz().cHPFull) + "\n" +
            "KI: " + NinjaUtil2.getMoneys(Char2.myCharz().cMP) + " / " + NinjaUtil2.getMoneys(Char2.myCharz().cMPFull) + "\n" +
            "SĐ: " + NinjaUtil2.getMoneys(Char2.myCharz().cDamFull) + "\n" +
            "Chí mạng: " + Char2.myCharz().cCriticalFull + "%\n" +
            "Giảm sát thương: " + Char2.myCharz().tlDef + "%\n" +
            "Phản sát thương: " + Char2.myCharz().tlPst + "%\n" +
            "Né đòn: " + Char2.myCharz().tlNeDon + "%\n" +
            "Hút HP: " + Char2.myCharz().tlHutHp + "%\n" +
            "Hút KI: " + Char2.myCharz().tlHutMp + "%\n" +

            "Giảm TDHS: " + Char2.myCharz().tileGiamTDHS + "%\n" +
            "Giảm TDHS: " + Char2.myCharz().timeGiamTDHS + " giây\n" +
            "Kháng TDHS: " + (Char2.myCharz().khangTDHS ? "Có" : "Không") + "\n" +
            "Kháng lạnh: " + (Char2.myCharz().isKhongLanh ? "Có" : "Không") + "\n" +
            "Vô hình: " + (Char2.myCharz().wearingVoHinh ? "Có" : "Không") + "\n" +
            "Dịch chuyển: " + (Char2.myCharz().teleport ? "Có" : "Không") + "\n";
        contenInfo = mFont2.tahoma_7_grey.splitFontArray(content, wScroll - 40);
        currentListLength = contenInfo.Length;
        ITEM_HEIGHT = 16;
        selected = GameCanvas2.isTouch ? (-1) : 0;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        if (cmy < 0)
        {
            cmy = cmtoY = 0;
        }
        if (cmy > cmyLim)
        {
            cmy = cmtoY = cmyLim;
        }
        type = 27;
        setType(0);
    }

    private void setTypeGameInfo()
    {
        currentListLength = vGameInfo.size();
        ITEM_HEIGHT = 24;
        selected = (GameCanvas2.isTouch ? (-1) : 0);
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        type = 23;
        setType(0);
    }

    private void doFirePet()
    {
        InfoDlg2.showWait();
        Service2.gI().petInfo();
        timeShow = 20;
        MainMod2.userOpenPet = true;
    }

    private void doFirePet2()
    {
        InfoDlg2.showWait();
        Service2.gI().PetInfo2();
        timeShow = 20;
        MainMod2.userOpenPet = true;
    }

    private void searchClan()
    {
        chatTField.strChat = mResources2.input_clan_name;
        chatTField.tfChat.name = mResources2.clan_name;
        chatTField.to = string.Empty;
        chatTField.isShow = true;
        chatTField.tfChat.isFocus = true;
        chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
        if (Main2.isWindowsPhone)
        {
            chatTField.tfChat.strInfo = chatTField.strChat;
        }
        if (Main2.isIPhone)
        {
            chatTField.startChat(this, string.Empty);
        }
    }

    private void chatClan()
    {
        chatTField.strChat = mResources2.chat_clan;
        chatTField.tfChat.name = mResources2.CHAT;
        chatTField.to = string.Empty;
        chatTField.isShow = true;
        chatTField.tfChat.isFocus = true;
        chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
        if (Main2.isWindowsPhone)
        {
            chatTField.tfChat.strInfo = chatTField.strChat;
        }
        if (Main2.isIPhone)
        {
            chatTField.startChat(this, string.Empty);
        }
    }

    public void creatClan()
    {
        chatTField.strChat = mResources2.input_clan_name_to_create;
        chatTField.tfChat.name = mResources2.input_clan_name;
        chatTField.to = string.Empty;
        chatTField.isShow = true;
        chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
        if (Main2.isWindowsPhone)
        {
            chatTField.tfChat.strInfo = chatTField.strChat;
        }
        if (Main2.isIPhone)
        {
            chatTField.startChat(this, string.Empty);
        }
    }

    public void putMoney()
    {
        if (chatTField == null)
        {
            chatTField = new ChatTextField2();
            chatTField.tfChat.y = GameCanvas2.h - 35 - global::ChatTextField2.gI().tfChat.height;
            chatTField.initChatTextField();
            chatTField.parentScreen = GameCanvas2.panel;
        }
        chatTField.strChat = mResources2.input_money_to_trade;
        chatTField.tfChat.name = mResources2.input_money;
        chatTField.to = string.Empty;
        chatTField.isShow = true;
        chatTField.tfChat.setIputType(TField2.INPUT_TYPE_NUMERIC);
        chatTField.tfChat.setMaxTextLenght(9);
        if (GameCanvas2.isTouch)
        {
            chatTField.tfChat.doChangeToTextBox();
        }
        if (Main2.isWindowsPhone)
        {
            chatTField.tfChat.strInfo = chatTField.strChat;
        }
        if (Main2.isIPhone)
        {
            chatTField.startChat(this, string.Empty);
        }
    }

    public void putQuantily()
    {
        if (chatTField == null)
        {
            chatTField = new ChatTextField2();
            chatTField.tfChat.y = GameCanvas2.h - 35 - global::ChatTextField2.gI().tfChat.height;
            chatTField.initChatTextField();
            chatTField.parentScreen = GameCanvas2.panel;
        }
        chatTField.strChat = mResources2.input_quantity_to_trade;
        chatTField.tfChat.name = mResources2.input_quantity;
        chatTField.to = string.Empty;
        chatTField.isShow = true;
        chatTField.tfChat.setIputType(TField2.INPUT_TYPE_NUMERIC);
        if (GameCanvas2.isTouch)
        {
            chatTField.tfChat.doChangeToTextBox();
        }
        if (Main2.isWindowsPhone)
        {
            chatTField.tfChat.strInfo = chatTField.strChat;
        }
        if (Main2.isIPhone)
        {
            chatTField.startChat(this, string.Empty);
        }
    }

    public void chagenSlogan()
    {
        chatTField.strChat = mResources2.input_clan_slogan;
        chatTField.tfChat.name = mResources2.input_clan_slogan;
        chatTField.to = string.Empty;
        chatTField.isShow = true;
        chatTField.tfChat.isFocus = true;
        chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
        if (Main2.isWindowsPhone)
        {
            chatTField.tfChat.strInfo = chatTField.strChat;
        }
        if (Main2.isIPhone)
        {
            chatTField.startChat(this, string.Empty);
        }
    }

    public void changeIcon()
    {
        if (tabIcon == null)
        {
            tabIcon = new TabClanIcon2();
        }
        tabIcon.text = chatTField.tfChat.getText();
        tabIcon.show(isGetName: false);
        chatTField.isShow = false;
    }

    private void addFriend(InfoItem2 info)
    {
        string text = "|0|1|" + info.charInfo.cName;
        text += "\n";
        text = ((!info.isOnline) ? (text + "|3|1|" + mResources2.is_offline) : (text + "|4|1|" + mResources2.is_online));
        text += "\n--";
        string text2 = text;
        text = text2 + "\n|5|" + mResources2.power + ": " + info.s;
        cp = new ChatPopup2();
        popUpDetailInit(cp, text);
        charInfo = info.charInfo;
        currItem = null;
    }

    private void doFireEnemy()
    {
        if (selected >= 0 && vEnemy.size() != 0)
        {
            MyVector2 myVector = new MyVector2();
            currInfoItem = selected;
            myVector.addElement(new Command2(mResources2.REVENGE, this, 10000, (InfoItem2)vEnemy.elementAt(currInfoItem)));
            myVector.addElement(new Command2(mResources2.DELETE, this, 10001, (InfoItem2)vEnemy.elementAt(currInfoItem)));
            GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
            addFriend((InfoItem2)vEnemy.elementAt(selected));
        }
    }

    private void doFireFriend()
    {
        if (selected >= 0 && vFriend.size() != 0)
        {
            MyVector2 myVector = new MyVector2();
            currInfoItem = selected;
            InfoItem2 infoItem = (InfoItem2)vFriend.elementAt(currInfoItem);
            myVector.addElement(new Command2(mResources2.CHAT, this, 8001, infoItem));
            myVector.addElement(new Command2(mResources2.DELETE, this, 8002, infoItem));
            myVector.addElement(new Command2(mResources2.den, this, 8004, infoItem.charInfo.charID));
            GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
            addFriend((InfoItem2)vFriend.elementAt(selected));
        }
    }

    private void doFireChangeFlag()
    {
        if (selected >= 0)
        {
            MyVector2 myVector = new MyVector2();
            currInfoItem = selected;
            myVector.addElement(new Command2(mResources2.change_flag, this, 10030, null));
            myVector.addElement(new Command2(mResources2.BACK, this, 10031, null));
            GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
        }
    }

    private void doFireLogMessage()
    {
        if (selected == 0)
        {
            isViewChatServer = !isViewChatServer;
            Rms2.saveRMSInt("viewchat", isViewChatServer ? 1 : 0);
            if (GameCanvas2.isTouch)
            {
                selected = -1;
            }
        }
        else if (selected >= 0 && logChat.size() != 0)
        {
            MyVector2 myVector = new MyVector2();
            currInfoItem = selected - 1;
            InfoItem2 infoItem = (InfoItem2)logChat.elementAt(currInfoItem);
            myVector.addElement(new Command2(mResources2.CHAT, this, 8001, infoItem));
            myVector.addElement(new Command2(mResources2.make_friend, this, 8003, infoItem));
            myVector.addElement(new Command2(MainMod2.strTeleportTo, this, 8004, infoItem.charInfo.charID));
            GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
            addLogMessage((InfoItem2)logChat.elementAt(selected - 1));
        }
    }

    private void doFireClanOption()
    {
        try
        {
            partID = null;
            charInfo = null;
            if (selected < 0)
            {
                cSelected = -1;
                return;
            }
            if (Char2.myCharz().clan == null)
            {
                if (selected == 0)
                {
                    if (cSelected == 0)
                    {
                        searchClan();
                    }
                    else if (cSelected == 1)
                    {
                        InfoDlg2.showWait();
                        creatClan();
                        Service2.gI().getClan(1, -1, null);
                    }
                }
                else if (selected != -1)
                {
                    if (selected == 1)
                    {
                        if (isSearchClan)
                        {
                            Service2.gI().searchClan(string.Empty);
                        }
                        else if (isViewMember && currClan != null)
                        {
                            GameCanvas2.startYesNoDlg(mResources2.do_u_want_join_clan + currClan.name, new Command2(mResources2.YES, this, 4000, currClan), new Command2(mResources2.NO, this, 4005, currClan));
                        }
                    }
                    else if (isSearchClan)
                    {
                        currClan = getCurrClan();
                        if (currClan != null)
                        {
                            MyVector2 myVector = new MyVector2();
                            myVector.addElement(new Command2(mResources2.request_join_clan, this, 4000, currClan));
                            myVector.addElement(new Command2(mResources2.view_clan_member, this, 4001, currClan));
                            GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                            addClanDetail(getCurrClan());
                        }
                    }
                    else if (isViewMember)
                    {
                        currMem = getCurrMember();
                        if (currMem != null)
                        {
                            MyVector2 myVector2 = new MyVector2();
                            myVector2.addElement(new Command2(mResources2.CLOSE, this, 8000, currClan));
                            GameCanvas2.menu.startAt(myVector2, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                            GameCanvas2.menu.startAt(myVector2, 0, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                            addClanMemberDetail(currMem);
                        }
                    }
                }
            }
            else if (selected == 0)
            {
                if (isMessage)
                {
                    if (cSelected == 0)
                    {
                        if (myMember.size() > 1)
                        {
                            chatClan();
                        }
                        else
                        {
                            member = null;
                            isSearchClan = false;
                            isViewMember = true;
                            isMessage = false;
                            currentListLength = myMember.size() + 2;
                            initTabClans();
                        }
                    }
                    if (cSelected == 1)
                    {
                        Service2.gI().clanMessage(1, null, -1);
                    }
                    if (cSelected == 2)
                    {
                        member = null;
                        isSearchClan = false;
                        isViewMember = true;
                        isMessage = false;
                        currentListLength = myMember.size() + 2;
                        initTabClans();
                        getCurrClanOtion();
                    }
                }
                else if (isViewMember)
                {
                    if (cSelected == 0)
                    {
                        isSearchClan = false;
                        isViewMember = false;
                        isMessage = true;
                        currentListLength = ClanMessage2.vMessage.size() + 2;
                        initTabClans();
                    }
                    if (cSelected == 1)
                    {
                        if (myMember.size() > 1)
                        {
                            Service2.gI().leaveClan();
                        }
                        else
                        {
                            chagenSlogan();
                        }
                    }
                    if (cSelected == 2)
                    {
                        if (myMember.size() > 1)
                        {
                            chagenSlogan();
                        }
                        else
                        {
                            Service2.gI().getClan(3, -1, null);
                        }
                    }
                    if (cSelected == 3)
                    {
                        Service2.gI().getClan(3, -1, null);
                    }
                }
            }
            else if (selected == 1)
            {
                if (isSearchClan)
                {
                    Service2.gI().searchClan(string.Empty);
                }
            }
            else if (isSearchClan)
            {
                currClan = getCurrClan();
                if (currClan != null)
                {
                    MyVector2 myVector3 = new MyVector2();
                    myVector3.addElement(new Command2(mResources2.view_clan_member, this, 4001, currClan));
                    GameCanvas2.menu.startAt(myVector3, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                    addClanDetail(getCurrClan());
                }
            }
            else if (isViewMember)
            {
                currMem = getCurrMember();
                if (currMem != null)
                {
                    MyVector2 myVector4 = new MyVector2();
                    if (member != null)
                    {
                        myVector4.addElement(new Command2(mResources2.CLOSE, this, 8000, null));
                    }
                    else if (myMember != null)
                    {
                        if (Char2.myCharz().charID == currMem.ID || Char2.myCharz().role == 2)
                        {
                            myVector4.addElement(new Command2(mResources2.CLOSE, this, 8000, currMem));
                        }
                        if (Char2.myCharz().role < 2 && Char2.myCharz().charID != currMem.ID)
                        {
                            if (currMem.role == 0 || currMem.role == 1)
                            {
                                myVector4.addElement(new Command2(mResources2.CLOSE, this, 8000, currMem));
                            }
                            if (currMem.role == 2)
                            {
                                myVector4.addElement(new Command2(mResources2.create_clan_co_leader, this, 5002, currMem));
                            }
                            if (Char2.myCharz().role == 0)
                            {
                                myVector4.addElement(new Command2(mResources2.create_clan_leader, this, 5001, currMem));
                                if (currMem.role == 1)
                                {
                                    myVector4.addElement(new Command2(mResources2.disable_clan_mastership, this, 5003, currMem));
                                }
                            }
                        }
                        if (Char2.myCharz().role < currMem.role)
                        {
                            myVector4.addElement(new Command2(mResources2.kick_clan_mem, this, 5004, currMem));
                        }
                    }
                    myVector4.addElement(new Command2(MainMod2.strTeleportTo, this, 8004, currMem.ID));
                    GameCanvas2.menu.startAt(myVector4, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                    addClanMemberDetail(currMem);
                }
            }
            else if (isMessage)
            {
                currMess = getCurrMessage();
                if (currMess != null)
                {
                    if (currMess.type == 0)
                    {
                        MyVector2 myVector5 = new MyVector2();
                        myVector5.addElement(new Command2(mResources2.CLOSE, this, 8000, currMess));
                        GameCanvas2.menu.startAt(myVector5, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                        addMessageDetail(currMess);
                    }
                    else if (currMess.type == 1)
                    {
                        if (currMess.playerId != Char2.myCharz().charID && cSelected != -1)
                        {
                            Service2.gI().clanDonate(currMess.id);
                        }
                    }
                    else if (currMess.type == 2 && currMess.option != null)
                    {
                        if (cSelected == 0)
                        {
                            Service2.gI().joinClan(currMess.id, 1);
                        }
                        else if (cSelected == 1)
                        {
                            Service2.gI().joinClan(currMess.id, 0);
                        }
                    }
                }
            }
            if (GameCanvas2.isTouch)
            {
                cSelected = -1;
                selected = -1;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void doFireMain()
    {
        try
        {
            if (currentTabIndex == 0)
            {
                setTypeMap();
            }
            if (currentTabIndex == 1)
            {
                doFireInventory();
            }
            if (currentTabIndex == 2)
            {
                doFireSkill();
            }
            if (currentTabIndex == 3)
            {
                if (mainTabName.Length == 4)
                {
                    doFireTool();
                }
                else
                {
                    doFireClanOption();
                }
            }
            if (currentTabIndex == 4)
            {
                doFireTool();
            }
        }
        catch (Exception ex)
        {
            Res2.outz("Throw ex " + ex.StackTrace);
        }
    }

    private void doFireSkill()
    {
        if (selected < 0)
        {
            return;
        }
        if (Char2.myCharz().statusMe == 14)
        {
            GameCanvas2.startOKDlg(mResources2.can_not_do_when_die);
            return;
        }
        if (selected == 0 || selected == 1 || selected == 2 || selected == 3 || selected == 4 || selected == 5)
        {
            long cTiemNang = Char2.myCharz().cTiemNang;
            long cHPGoc = Char2.myCharz().cHPGoc;
            long cMPGoc = Char2.myCharz().cMPGoc;
            long cDamGoc = Char2.myCharz().cDamGoc;
            long cDefGoc = Char2.myCharz().cDefGoc;
            _ = Char2.myCharz().cCriticalGoc;
            int num2 = 1000;
            if (selected == 0)
            {
                if (cTiemNang < Char2.myCharz().cHPGoc + num2)
                {
                    GameCanvas2.startOKDlg(mResources2.not_enough_potential_point1 + Char2.myCharz().cTiemNang + mResources2.not_enough_potential_point2 + (Char2.myCharz().cHPGoc + num2), isError: false);
                    return;
                }
                if (cTiemNang > cHPGoc && cTiemNang < 10 * (2 * (cHPGoc + num2) + 180) / 2)
                {
                    GameCanvas2.startYesNoDlg(mResources2.use_potential_point_for1 + (cHPGoc + num2) + mResources2.use_potential_point_for2 + Char2.myCharz().hpFrom1000TiemNang + mResources2.for_HP, new Command2(mResources2.increase_upper, this, 9000, null), new Command2(mResources2.CANCEL, this, 4007, null));
                    return;
                }
                MyVector2 myVector = new(string.Empty);
                if (cTiemNang >= 10 * (2 * (cHPGoc + num2) + 180) / 2 && cTiemNang < 100 * (2 * (cHPGoc + num2) + 1980) / 2)
                {
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + Char2.myCharz().hpFrom1000TiemNang + mResources2.HP + "\n-" + Res2.formatNumber2(cHPGoc + num2), this, 9000, null));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 10 * Char2.myCharz().hpFrom1000TiemNang + mResources2.HP + "\n-" + Res2.formatNumber2(10 * (2 * (cHPGoc + num2) + 180) / 2), this, 9006, null));
                }
                else if (cTiemNang >= 100 * (2 * (cHPGoc + num2) + 1980) / 2)
                {
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + Char2.myCharz().hpFrom1000TiemNang + mResources2.HP + "\n-" + Res2.formatNumber2(cHPGoc + num2), this, 9000, null));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 10 * Char2.myCharz().hpFrom1000TiemNang + mResources2.HP + "\n-" + Res2.formatNumber2(10 * (2 * (cHPGoc + num2) + 180) / 2), this, 9006, null));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 100 * Char2.myCharz().hpFrom1000TiemNang + mResources2.HP + "\n-" + Res2.formatNumber2(100 * (2 * (cHPGoc + num2) + 1980) / 2), this, 9007, null));

                }
                myVector.addElement(new Command2(MainMod2.strInCrease, MainMod2.GI(), 100, selected + "-" + 16));
                GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                addSkillDetail2(selected, false);
            }
            if (selected == 1)
            {
                if (Char2.myCharz().cTiemNang < Char2.myCharz().cMPGoc + num2)
                {
                    GameCanvas2.startOKDlg(mResources2.not_enough_potential_point1 + Char2.myCharz().cTiemNang + mResources2.not_enough_potential_point2 + (Char2.myCharz().cMPGoc + num2));
                    return;
                }
                if (cTiemNang > cMPGoc && cTiemNang < 10 * (2 * (cMPGoc + num2) + 180) / 2)
                {
                    GameCanvas2.startYesNoDlg(mResources2.use_potential_point_for1 + (cMPGoc + num2) + mResources2.use_potential_point_for2 + Char2.myCharz().mpFrom1000TiemNang + mResources2.for_KI, new Command2(mResources2.increase_upper, this, 9000, null), new Command2(mResources2.CANCEL, this, 4007, null));
                    return;
                }
                MyVector2 myVector = new(string.Empty);
                if (cTiemNang >= 10 * (2 * (cMPGoc + num2) + 180) / 2 && cTiemNang < 100 * (2 * (cMPGoc + num2) + 1980) / 2)
                {
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + Char2.myCharz().mpFrom1000TiemNang + mResources2.KI + "\n-" + Res2.formatNumber2(cHPGoc + num2), this, 9000, null));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 10 * Char2.myCharz().mpFrom1000TiemNang + mResources2.KI + "\n-" + Res2.formatNumber2(10 * (2 * (cHPGoc + num2) + 180) / 2), this, 9006, null));
                }
                else if (cTiemNang >= 100 * (2 * (cMPGoc + num2) + 1980) / 2)
                {
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + Char2.myCharz().mpFrom1000TiemNang + mResources2.KI + "\n-" + Res2.formatNumber2(cMPGoc + num2), this, 9000, null));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 10 * Char2.myCharz().mpFrom1000TiemNang + mResources2.KI + "\n-" + Res2.formatNumber2(10 * (2 * (cMPGoc + num2) + 180) / 2), this, 9006, null));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 100 * Char2.myCharz().mpFrom1000TiemNang + mResources2.KI + "\n-" + Res2.formatNumber2(100 * (2 * (cMPGoc + num2) + 1980) / 2), this, 9007, null));
                }
                myVector.addElement(new Command2(MainMod2.strInCrease, MainMod2.GI(), 100, selected + "-" + 16));
                GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                addSkillDetail2(selected, false);
            }
            if (selected == 2)
            {
                if (Char2.myCharz().cTiemNang < Char2.myCharz().cDamGoc * Char2.myCharz().expForOneAdd)
                {
                    GameCanvas2.startOKDlg(mResources2.not_enough_potential_point1 + Char2.myCharz().cTiemNang + mResources2.not_enough_potential_point2 + cDamGoc * 100);
                    return;
                }
                if (cTiemNang > cDamGoc && cTiemNang < 10 * (2 * cDamGoc + 9) / 2 * Char2.myCharz().expForOneAdd)
                {
                    GameCanvas2.startYesNoDlg(mResources2.use_potential_point_for1 + cDamGoc * 100 + mResources2.use_potential_point_for2 + Char2.myCharz().damFrom1000TiemNang + mResources2.for_hit_point, new Command2(mResources2.increase_upper, this, 9000, null), new Command2(mResources2.CANCEL, this, 4007, null));
                    return;
                }
                MyVector2 myVector = new(string.Empty);
                if (cTiemNang >= 10 * (2 * cDamGoc + 9) / 2 * Char2.myCharz().expForOneAdd && cTiemNang < 100 * (2 * cDamGoc + 99) / 2 * Char2.myCharz().expForOneAdd)
                {
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + Char2.myCharz().damFrom1000TiemNang + "\n" + mResources2.hit_point + "\n-" + Res2.formatNumber2(cDamGoc * 100), this, 9000, null));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 10 * Char2.myCharz().damFrom1000TiemNang + "\n" + mResources2.hit_point + "\n-" + Res2.formatNumber2(10 * (2 * cDamGoc + 9) / 2 * Char2.myCharz().expForOneAdd), this, 9006, null));
                }
                else if (cTiemNang >= 100 * (2 * cDamGoc + 99) / 2 * Char2.myCharz().expForOneAdd)
                {
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + Char2.myCharz().damFrom1000TiemNang + "\n" + mResources2.hit_point + "\n-" + Res2.formatNumber2(cDamGoc * 100), this, 9000, null));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 10 * Char2.myCharz().damFrom1000TiemNang + "\n" + mResources2.hit_point + "\n-" + Res2.formatNumber2(10 * (2 * cDamGoc + 9) / 2 * Char2.myCharz().expForOneAdd), this, 9006, null));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 100 * Char2.myCharz().damFrom1000TiemNang + "\n" + mResources2.hit_point + "\n-" + Res2.formatNumber2(100 * (2 * cDamGoc + 99) / 2 * Char2.myCharz().expForOneAdd), this, 9007, null));
                }
                myVector.addElement(new Command2(MainMod2.strInCrease, MainMod2.GI(), 100, selected + "-" + 16));
                GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                addSkillDetail2(selected, false);
            }
            if (selected == 3)
            {
                if (Char2.myCharz().cTiemNang < 50000 + Char2.myCharz().cDefGoc * 1000)
                {
                    GameCanvas2.startOKDlg(mResources2.not_enough_potential_point1 + NinjaUtil2.getMoneys(Char2.myCharz().cTiemNang) + mResources2.not_enough_potential_point2 + NinjaUtil2.getMoneys(50000 + Char2.myCharz().cDefGoc * 1000));
                    return;
                }
                long number = 2 * (cDefGoc + 5) / 2L * 100000;
                long number2 = 10L * (2 * (cDefGoc + 5) + 9) / 2 * 100000;
                long number3 = 100L * (2 * (cDefGoc + 5) + 99) / 2 * 100000;
                MyVector2 myVector = new(string.Empty);
                myVector.addElement(new Command2(mResources2.increase_upper + "\n1 " + mResources2.armor + "\n" + Res2.formatNumber2(number), this, 9000, null));
                myVector.addElement(new Command2(mResources2.increase_upper + "\n10 " + mResources2.armor + "\n" + Res2.formatNumber2(number2), this, 9006, null));
                myVector.addElement(new Command2(mResources2.increase_upper + "\n100 " + mResources2.armor + "\n" + Res2.formatNumber2(number3), this, 9007, null));
                myVector.addElement(new Command2(MainMod2.strInCrease, MainMod2.GI(), 100, selected + "-" + 16));
                GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                addSkillDetail2(selected, false);
            }
            else if (selected == 4)
            {
                int num4 = Char2.myCharz().cCriticalGoc;
                if (num4 > t_tiemnang.Length - 1)
                {
                    num4 = t_tiemnang.Length - 1;
                }
                long num3 = t_tiemnang[num4];
                if (Char2.myCharz().cTiemNang < num3)
                {
                    GameCanvas2.startOKDlg(mResources2.not_enough_potential_point1 + Res2.formatNumber2(Char2.myCharz().cTiemNang) + mResources2.not_enough_potential_point2 + Res2.formatNumber2(num3));
                    return;
                }
                GameCanvas2.startYesNoDlg(mResources2.use_potential_point_for1 + Res2.formatNumber(num3) + mResources2.use_potential_point_for2 + Char2.myCharz().criticalFrom1000Tiemnang + mResources2.for_crit, new Command2(mResources2.increase_upper, this, 9000, null), new Command2(mResources2.CANCEL, this, 4007, null));
            }
            else if (selected == 5)
            {
                Service2.gI().speacialSkill(0);
            }
            return;
        }
        int index = selected - 6;
        SkillTemplate2 skillTemplate = Char2.myCharz().nClass.skillTemplates[index];
        Skill2 skill = Char2.myCharz().getSkill(skillTemplate);
        Skill2 skill2 = null;
        MyVector2 myVector8 = new(string.Empty);
        if (skill != null)
        {
            if (skill.point == skillTemplate.maxPoint)
            {
                myVector8.addElement(new Command2(mResources2.make_shortcut, this, 9003, skill.template));
                myVector8.addElement(new Command2(mResources2.CLOSE, 2));
            }
            else
            {
                skill2 = skillTemplate.skills[skill.point];
                myVector8.addElement(new Command2(mResources2.UPGRADE, this, 9002, skill2));
                myVector8.addElement(new Command2(mResources2.make_shortcut, this, 9003, skill.template));
            }
        }
        else
        {
            skill2 = skillTemplate.skills[0];
            myVector8.addElement(new Command2(mResources2.learn, this, 9004, skill2));
        }
        GameCanvas2.menu.startAt(myVector8, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
        addSkillDetail(skillTemplate, skill, skill2);
    }

    private void DoFirePetSkill()
    {
        if (selected < 0)
        {
            return;
        }
        Char2 @char = type == 28 ? Char2.MyPet2z() : Char2.myPetz();
        int typeChar = type == 28 ? 20 : 18;
        if (selected == 0 || selected == 1 || selected == 2 || selected == 3 || selected == 4)
        {
            long cTiemNang = Char2.myPetz().cTiemNang;
            long cHPGoc = Char2.myPetz().cHPGoc;
            long cMPGoc = Char2.myPetz().cMPGoc;
            long cDamGoc = Char2.myPetz().cDamGoc;
            int cDefGoc = Char2.myPetz().cDefGoc;
            int cCriticalGoc = Char2.myPetz().cCriticalGoc;

            int num2 = 1000;
            if (selected == 0)
            {
                if (cTiemNang < cHPGoc + num2)
                {
                    GameCanvas2.startOKDlg(mResources2.not_enough_potential_point1 + cTiemNang + mResources2.not_enough_potential_point2 + (cHPGoc + num2), isError: false);
                    return;
                }
                if (cTiemNang > cHPGoc && cTiemNang < 10 * (2 * (cHPGoc + num2) + 180) / 2)
                {
                    GameCanvas2.startYesNoDlg(mResources2.use_potential_point_for1 + (cHPGoc + num2) + mResources2.use_potential_point_for2 + Char2.myCharz().hpFrom1000TiemNang + mResources2.for_HP, new Command2(mResources2.increase_upper, this, 9000, typeChar), new Command2(mResources2.CANCEL, this, 4007, null));
                    return;
                }
                MyVector2 myVector = new(string.Empty);
                if (cTiemNang >= 10 * (2 * (cHPGoc + num2) + 180) / 2 && cTiemNang < 100 * (2 * (cHPGoc + num2) + 1980) / 2)
                {
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + Char2.myCharz().hpFrom1000TiemNang + mResources2.HP + "\n-" + Res2.formatNumber2(cHPGoc + num2), this, 9000, typeChar));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 10 * Char2.myCharz().hpFrom1000TiemNang + mResources2.HP + "\n-" + Res2.formatNumber2(10 * (2 * (cHPGoc + num2) + 180) / 2), this, 9006, typeChar));
                }
                else if (cTiemNang >= 100 * (2 * (cHPGoc + num2) + 1980) / 2)
                {
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + Char2.myCharz().hpFrom1000TiemNang + mResources2.HP + "\n-" + Res2.formatNumber2(cHPGoc + num2), this, 9000, typeChar));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 10 * Char2.myCharz().hpFrom1000TiemNang + mResources2.HP + "\n-" + Res2.formatNumber2(10 * (2 * (cHPGoc + num2) + 180) / 2), this, 9006, typeChar));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 100 * Char2.myCharz().hpFrom1000TiemNang + mResources2.HP + "\n-" + Res2.formatNumber2(100 * (2 * (cHPGoc + num2) + 1980) / 2), this, 9007, typeChar));

                }
                myVector.addElement(new Command2(MainMod2.strInCrease, MainMod2.GI(), 100, selected + "-" + typeChar));
                GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                addSkillDetail2(selected, false);
            }
            if (selected == 1)
            {
                if (cTiemNang < cMPGoc + num2)
                {
                    GameCanvas2.startOKDlg(mResources2.not_enough_potential_point1 + cTiemNang + mResources2.not_enough_potential_point2 + (cMPGoc + num2), isError: false);
                    return;
                }
                if (cTiemNang > cMPGoc && cTiemNang < 10 * (2 * (cMPGoc + num2) + 180) / 2)
                {
                    GameCanvas2.startYesNoDlg(mResources2.use_potential_point_for1 + (cMPGoc + num2) + mResources2.use_potential_point_for2 + Char2.myCharz().mpFrom1000TiemNang + mResources2.for_KI, new Command2(mResources2.increase_upper, this, 9000, typeChar), new Command2(mResources2.CANCEL, this, 4007, null));
                    return;
                }
                MyVector2 myVector = new(string.Empty);
                if (cTiemNang >= 10 * (2 * (cMPGoc + num2) + 180) / 2 && cTiemNang < 100 * (2 * (cMPGoc + num2) + 1980) / 2)
                {
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + Char2.myCharz().mpFrom1000TiemNang + mResources2.KI + "\n-" + Res2.formatNumber2(cHPGoc + num2), this, 9000, typeChar));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 10 * Char2.myCharz().mpFrom1000TiemNang + mResources2.KI + "\n-" + Res2.formatNumber2(10 * (2 * (cHPGoc + num2) + 180) / 2), this, 9006, typeChar));
                }
                else if (cTiemNang >= 100 * (2 * (cMPGoc + num2) + 1980) / 2)
                {
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + Char2.myCharz().mpFrom1000TiemNang + mResources2.KI + "\n-" + Res2.formatNumber2(cMPGoc + num2), this, 9000, typeChar));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 10 * Char2.myCharz().mpFrom1000TiemNang + mResources2.KI + "\n-" + Res2.formatNumber2(10 * (2 * (cMPGoc + num2) + 180) / 2), this, 9006, typeChar));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 100 * Char2.myCharz().mpFrom1000TiemNang + mResources2.KI + "\n-" + Res2.formatNumber2(100 * (2 * (cMPGoc + num2) + 1980) / 2), this, 9007, typeChar));
                }
                myVector.addElement(new Command2(MainMod2.strInCrease, MainMod2.GI(), 100, selected + "-" + typeChar));
                GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                addSkillDetail2(selected, false);
            }
            if (selected == 2)
            {
                if (cTiemNang < cDamGoc * Char2.myCharz().expForOneAdd)
                {
                    GameCanvas2.startOKDlg(mResources2.not_enough_potential_point1 + cTiemNang + mResources2.not_enough_potential_point2 + cDamGoc * 100, isError: false);
                    return;
                }
                if (cTiemNang > cDamGoc && cTiemNang < 10 * (2 * cDamGoc + 9) / 2 * Char2.myCharz().expForOneAdd)
                {
                    GameCanvas2.startYesNoDlg(mResources2.use_potential_point_for1 + cDamGoc * 100 + mResources2.use_potential_point_for2 + Char2.myCharz().damFrom1000TiemNang + mResources2.for_hit_point, new Command2(mResources2.increase_upper, this, 9000, typeChar), new Command2(mResources2.CANCEL, this, 4007, null));
                    return;
                }
                MyVector2 myVector = new(string.Empty);
                if (cTiemNang >= 10 * (2 * cDamGoc + 9) / 2 * Char2.myCharz().expForOneAdd && cTiemNang < 100 * (2 * cDamGoc + 99) / 2 * Char2.myCharz().expForOneAdd)
                {
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + Char2.myCharz().damFrom1000TiemNang + "\n" + mResources2.hit_point + "\n-" + Res2.formatNumber2(cDamGoc * 100), this, 9000, typeChar));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 10 * Char2.myCharz().damFrom1000TiemNang + "\n" + mResources2.hit_point + "\n-" + Res2.formatNumber2(10 * (2 * cDamGoc + 9) / 2 * Char2.myCharz().expForOneAdd), this, 9006, typeChar));
                }
                else if (cTiemNang >= 100 * (2 * cDamGoc + 99) / 2 * Char2.myCharz().expForOneAdd)
                {
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + Char2.myCharz().damFrom1000TiemNang + "\n" + mResources2.hit_point + "\n-" + Res2.formatNumber2(cDamGoc * 100), this, 9000, typeChar));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 10 * Char2.myCharz().damFrom1000TiemNang + "\n" + mResources2.hit_point + "\n-" + Res2.formatNumber2(10 * (2 * cDamGoc + 9) / 2 * Char2.myCharz().expForOneAdd), this, 9006, typeChar));
                    myVector.addElement(new Command2(mResources2.increase_upper + "\n" + 100 * Char2.myCharz().damFrom1000TiemNang + "\n" + mResources2.hit_point + "\n-" + Res2.formatNumber2(100 * (2 * cDamGoc + 99) / 2 * Char2.myCharz().expForOneAdd), this, 9007, typeChar));
                }
                myVector.addElement(new Command2(MainMod2.strInCrease, MainMod2.GI(), 100, selected + "-" + typeChar));
                GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                addSkillDetail2(selected, false);
            }
            if (selected == 3)
            {
                if (cTiemNang < 50000 + cDefGoc * 1000)
                {
                    GameCanvas2.startOKDlg(mResources2.not_enough_potential_point1 + NinjaUtil2.getMoneys(cTiemNang) + mResources2.not_enough_potential_point2 + NinjaUtil2.getMoneys(50000 + cDefGoc * 1000), isError: false);
                    return;
                }
                long number = 2 * (cDefGoc + 5) / 2L * 100000;
                long number2 = 10L * (2 * (cDefGoc + 5) + 9) / 2 * 100000;
                long number3 = 100L * (2 * (cDefGoc + 5) + 99) / 2 * 100000;
                MyVector2 myVector = new(string.Empty);
                myVector.addElement(new Command2(mResources2.increase_upper + "\n1 " + mResources2.armor + "\n" + Res2.formatNumber2(number), this, 9000, typeChar));
                myVector.addElement(new Command2(mResources2.increase_upper + "\n10 " + mResources2.armor + "\n" + Res2.formatNumber2(number2), this, 9006, typeChar));
                myVector.addElement(new Command2(mResources2.increase_upper + "\n100 " + mResources2.armor + "\n" + Res2.formatNumber2(number3), this, 9007, typeChar));
                myVector.addElement(new Command2(MainMod2.strInCrease, MainMod2.GI(), 100, selected + "-" + typeChar));
                GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
                addSkillDetail2(selected, false);
            }
            else if (selected == 4)
            {
                int crit = cCriticalGoc;
                if (crit > t_tiemnang.Length - 1)
                {
                    crit = t_tiemnang.Length - 1;
                }
                long num3 = t_tiemnang[crit];
                if (cTiemNang < num3)
                {
                    GameCanvas2.startOKDlg(mResources2.not_enough_potential_point1 + Res2.formatNumber2(cTiemNang) + mResources2.not_enough_potential_point2 + Res2.formatNumber2(num3), isError: false);
                    return;
                }
                GameCanvas2.startYesNoDlg(mResources2.use_potential_point_for1 + Res2.formatNumber(num3) + mResources2.use_potential_point_for2 + Char2.myCharz().criticalFrom1000Tiemnang + mResources2.for_crit, new Command2(mResources2.increase_upper, this, 9000, typeChar), new Command2(mResources2.CANCEL, this, 4007, null));
            }
            return;
        }

        //int index = selected - 6;
        //SkillTemplate skillTemplate = Char.myCharz().nClass.skillTemplates[index];
        //Skill skill = Char.myCharz().getSkill(skillTemplate);
        //Skill skill2 = null;
        //MyVector myVector8 = new(string.Empty);
        //if (skill != null)
        //{
        //    if (skill.point == skillTemplate.maxPoint)
        //    {
        //        myVector8.addElement(new Command(mResources.make_shortcut, this, 9003, skill.template));
        //        myVector8.addElement(new Command(mResources.CLOSE, 2));
        //    }
        //    else
        //    {
        //        skill2 = skillTemplate.skills[skill.point];
        //        myVector8.addElement(new Command(mResources.UPGRADE, this, 9002, skill2));
        //        myVector8.addElement(new Command(mResources.make_shortcut, this, 9003, skill.template));
        //    }
        //}
        //else
        //{
        //    skill2 = skillTemplate.skills[0];
        //    myVector8.addElement(new Command(mResources.learn, this, 9004, skill2));
        //}
        //GameCanvas.menu.startAt(myVector8, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
        //addSkillDetail(skillTemplate, skill, skill2);
    }

    private void addLogMessage(InfoItem2 info)
    {
        string text = "|0|1|" + info.charInfo.cName;
        text += "\n";
        text += "\n--";
        text = text + "\n|5|" + Res2.split(info.s, "|", 0)[2];
        cp = new ChatPopup2();
        popUpDetailInit(cp, text);
        charInfo = info.charInfo;
        currItem = null;
    }

    private void addSkillDetail2(int type, bool isPet)
    {
        string empty = string.Empty;
        long num = 0;
        Char2 @char = isPet ? Char2.myPetz() : Char2.myCharz();
        if (selected == 0)
        {
            num = @char.cHPGoc + 1000;
        }
        if (selected == 1)
        {
            num = @char.cMPGoc + 1000;
        }
        if (selected == 2)
        {
            num = @char.cDamGoc * @char.expForOneAdd;
        }
        if (selected == 3)
        {
            num = 500000 + @char.cDefGoc * 100000;
        }
        string text = empty;
        empty = text + "|5|2|" + mResources2.USE + " " + num + " " + mResources2.potential;
        if (type == 0)
        {
            empty = empty + "\n|5|2|" + mResources2.to_gain_20hp;
        }
        if (type == 1)
        {
            empty = empty + "\n|5|2|" + mResources2.to_gain_20mp;
        }
        if (type == 2)
        {
            empty = empty + "\n|5|2|" + mResources2.to_gain_1pow;
        }
        if (type == 3)
        {
            empty = empty + "\n|5|2|" + mResources2.to_gain_1pow;
        }
        currItem = null;
        partID = null;
        charInfo = null;
        idIcon = -1;
        cp = new ChatPopup2();
        popUpDetailInit(cp, empty);
    }

    private void doFireClanIcon()
    {
    }

    private void doFireMap()
    {
        if (imgMap != null)
        {
            imgMap.texture = null;
            imgMap = null;
        }
        TileMap2.lastPlanetId = -1;
        mSystem2.gcc();
        SmallImage2.loadBigRMS();
        setTypeMain();
        cmx = (cmtoX = 0);
    }

    private void doFireZone()
    {
        if (selected != -1)
        {
            Res2.outz("FIRE ZONE");
            isChangeZone = true;
            GameCanvas2.panel.hide();
        }
    }

    public void updateRequest(int recieve, int maxCap)
    {
        cp.says[cp.says.Length - 1] = mResources2.received + " " + recieve + "/" + maxCap;
    }

    private void doFireBox()
    {
        if (selected < 0)
        {
            return;
        }
        currItem = null;
        MyVector2 myVector = new MyVector2();
        if (currentTabIndex == 0 && !Equals(GameCanvas2.panel2))
        {
            if (selected == 0)
            {
                setNewSelected(Char2.myCharz().arrItemBox.Length, resetSelect: false);
            }
            else
            {
                sbyte b = (sbyte)GetInventorySelect_body(selected, newSelected);
                Item2 item = Char2.myCharz().arrItemBox[b];
                if (item != null)
                {
                    if (isBoxClan)
                    {
                        myVector.addElement(new Command2(mResources2.GETOUT, this, 1000, item));
                        myVector.addElement(new Command2(mResources2.USE, this, 2010, item));
                    }
                    else if (item.isTypeBody())
                    {
                        myVector.addElement(new Command2(mResources2.GETOUT, this, 1000, item));
                    }
                    else
                    {
                        myVector.addElement(new Command2(mResources2.GETOUT, this, 1000, item));
                    }
                    currItem = item;
                }
            }
        }
        if (currentTabIndex == 1 || Equals(GameCanvas2.panel2))
        {
            if (selected == 0)
            {
                setNewSelected(Char2.myCharz().arrItemBody.Length + Char2.myCharz().arrItemBag.Length, resetSelect: true);
            }
            else
            {
                Item2[] arrItemBody = Char2.myCharz().arrItemBody;
                if (!GetInventorySelect_isbody(selected, newSelected, arrItemBody))
                {
                    sbyte b2 = (sbyte)GetInventorySelect_bag(selected, newSelected, arrItemBody);
                    Item2 item2 = Char2.myCharz().arrItemBag[b2];
                    if (item2 != null)
                    {
                        myVector.addElement(new Command2(mResources2.move_to_chest, this, 1001, item2));
                        if (item2.isTypeBody())
                        {
                            myVector.addElement(new Command2(mResources2.USE, this, 2000, item2));
                        }
                        else
                        {
                            myVector.addElement(new Command2(mResources2.USE, this, 2001, item2));
                        }
                        currItem = item2;
                    }
                }
                else
                {
                    Item2 item3 = Char2.myCharz().arrItemBody[GetInventorySelect_body(selected, newSelected)];
                    if (item3 != null)
                    {
                        myVector.addElement(new Command2(mResources2.move_to_chest2, this, 1002, item3));
                        currItem = item3;
                    }
                }
            }
        }
        if (currItem != null)
        {
            Char2.myCharz().setPartTemp(currItem.headTemp, currItem.bodyTemp, currItem.legTemp, currItem.bagTemp);
            if (isBoxClan)
            {
                myVector.addElement(new Command2(mResources2.MOVEOUT, this, 2011, currItem));
            }
            GameCanvas2.menu.startAt(myVector, X, (selected + 1) * ITEM_HEIGHT - cmy + yScroll);
            addItemDetail(currItem);
        }
        else
        {
            cp = null;
        }
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
    }

    public void itemRequest(sbyte itemAction, string info, sbyte where, sbyte index)
    {
        GameCanvas2.endDlg();
        ItemObject2 itemObject = new ItemObject2();
        itemObject.type = itemAction;
        itemObject.id = index;
        itemObject.where = where;
        GameCanvas2.startYesNoDlg(info, new Command2(mResources2.YES, this, 2004, itemObject), new Command2(mResources2.NO, this, 4005, null));
    }

    public void saleRequest(sbyte type, string info, short id)
    {
        ItemObject2 itemObject = new ItemObject2();
        itemObject.type = type;
        itemObject.id = id;
        GameCanvas2.startYesNoDlg(info, new Command2(mResources2.YES, this, 3003, itemObject), new Command2(mResources2.NO, this, 4005, null));
    }

    public void perform(int idAction, object p)
    {
        if (idAction == 8010)
        {
            if (chatTField == null)
            {
                chatTField = new ChatTextField2();
                chatTField.tfChat.y = GameCanvas2.h - 35 - ChatTextField2.gI().tfChat.height;
                chatTField.initChatTextField();
                chatTField.parentScreen = this;
            }
            chatTField.parentScreen ??= this;
            MainMod2.GI().MyChatTextField(chatTField, "Nhập số sao cần đập", "Chỉ được nhập số");
        }
        else if (idAction == 8011)
        {
            if (chatTField == null)
            {
                chatTField = new ChatTextField2();
                chatTField.tfChat.y = GameCanvas2.h - 35 - ChatTextField2.gI().tfChat.height;
                chatTField.initChatTextField();
                chatTField.parentScreen = this;
            }
            string infoIntrinsic = (string)p;
            MainMod2.curSelectIntrinsic = infoIntrinsic;
            MainMod2.GI().MyChatTextField(chatTField, "Nhập chỉ số mong muốn", "Chỉ nhập số");
        }
        if (idAction == 9999)
        {
            TopInfo2 topInfo = (TopInfo2)p;
            Service2.gI().sendThachDau(topInfo.pId);
        }
        if (idAction == 170391)
        {
            Rms2.clearAll();
            if (mGraphics2.zoomLevel > 1)
            {
                Rms2.saveRMSInt("levelScreenKN", 1);
            }
            else
            {
                Rms2.saveRMSInt("levelScreenKN", 0);
            }
            GameMidlet2.instance.exit();
        }
        if (idAction == 6001)
        {
            Item2 item = (Item2)p;
            item.isSelect = false;
            GameCanvas2.panel.vItemCombine.removeElement(item);
            if (GameCanvas2.panel.currentTabIndex == 0)
            {
                GameCanvas2.panel.setTabCombine();
            }
            if (MainMod2.isAutoPhaLe)
            {
                MainMod2.itemPhale = null;
                MainMod2.maxPhale = -1;
                MainMod2.currPhale = -1;
            }
        }
        if (idAction == 6000)
        {
            Item2 item2 = (Item2)p;
            for (int i = 0; i < GameCanvas2.panel.vItemCombine.size(); i++)
            {
                Item2 item3 = (Item2)GameCanvas2.panel.vItemCombine.elementAt(i);
                if (item3.template.id == item2.template.id)
                {
                    GameCanvas2.startOKDlg(mResources2.already_has_item);
                    return;
                }
            }
            item2.isSelect = true;
            GameCanvas2.panel.vItemCombine.addElement(item2);
            if (GameCanvas2.panel.currentTabIndex == 0)
            {
                GameCanvas2.panel.setTabCombine();
            }
            if (MainMod2.isAutoPhaLe)
            {
                MainMod2.itemPhale = item2;
            }
        }
        if (idAction == 7000)
        {
            if (isLock)
            {
                GameCanvas2.startOKDlg(mResources2.unlock_item_to_trade);
                return;
            }
            Item2 item4 = (Item2)p;
            for (int j = 0; j < GameCanvas2.panel.vMyGD.size(); j++)
            {
                Item2 item5 = (Item2)GameCanvas2.panel.vMyGD.elementAt(j);
                if (item5.indexUI == item4.indexUI)
                {
                    GameCanvas2.startOKDlg(mResources2.already_has_item);
                    return;
                }
            }
            if (item4.quantity > 1)
            {
                putQuantily();
                return;
            }
            item4.isSelect = true;
            Item2 item6 = new Item2();
            item6.template = item4.template;
            item6.itemOption = item4.itemOption;
            item6.indexUI = item4.indexUI;
            GameCanvas2.panel.vMyGD.addElement(item6);
            Service2.gI().giaodich(2, -1, (sbyte)item6.indexUI, item6.quantity);
        }
        if (idAction == 7001)
        {
            Item2 item7 = (Item2)p;
            item7.isSelect = false;
            GameCanvas2.panel.vMyGD.removeElement(item7);
            if (GameCanvas2.panel.currentTabIndex == 1)
            {
                GameCanvas2.panel.setTabGiaoDich(isMe: true);
            }
            Service2.gI().giaodich(4, -1, (sbyte)item7.indexUI, -1);
        }
        if (idAction == 7002)
        {
            isAccept = true;
            GameCanvas2.endDlg();
            Service2.gI().giaodich(7, -1, -1, -1);
            hide();
        }
        if (idAction == 8003)
        {
            InfoItem2 infoItem = (InfoItem2)p;
            Service2.gI().friend(1, infoItem.charInfo.charID);
            if (type != 8)
            {
            }
        }
        if (idAction == 8002)
        {
            InfoItem2 infoItem2 = (InfoItem2)p;
            Service2.gI().friend(2, infoItem2.charInfo.charID);
        }
        if (idAction == 8004)
        {
            int charID = (int)p;
            MainMod2.GI().TeleportToPlayer(charID);
        }
        if (idAction == 8001)
        {
            InfoItem2 infoItem4 = (InfoItem2)p;
            if (chatTField == null)
            {
                chatTField = new ChatTextField2();
                chatTField.tfChat.y = GameCanvas2.h - 35 - global::ChatTextField2.gI().tfChat.height;
                chatTField.initChatTextField();
                chatTField.parentScreen = GameCanvas2.panel;
            }
            chatTField.strChat = mResources2.chat_player;
            chatTField.tfChat.name = mResources2.chat_with + " " + infoItem4.charInfo.cName;
            chatTField.to = string.Empty;
            chatTField.isShow = true;
            chatTField.tfChat.isFocus = true;
            chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
            if (Main2.isWindowsPhone)
            {
                chatTField.tfChat.strInfo = chatTField.strChat;
            }
            if (Main2.isIPhone)
            {
                chatTField.startChat(this, string.Empty);
            }
        }
        if (idAction == 1000)
        {
            Service2.gI().getItem(BOX_BAG, (sbyte)GetInventorySelect_body(selected, newSelected));
        }
        if (idAction == 1001)
        {
            sbyte id = (sbyte)GetInventorySelect_bag(selected, newSelected, Char2.myCharz().arrItemBody);
            Service2.gI().getItem(BAG_BOX, id);
        }
        if (idAction == 1003)
        {
            hide();
        }
        if (idAction == 1002)
        {
            Service2.gI().getItem(BODY_BOX, (sbyte)GetInventorySelect_body(selected, newSelected));
        }
        if (idAction == 2011)
        {
            Service2.gI().useItem(1, 2, (sbyte)GetInventorySelect_body(selected, newSelected), -1);
        }
        if (idAction == 2010)
        {
            Service2.gI().useItem(0, 2, (sbyte)GetInventorySelect_body(selected, newSelected), -1);
            Item2 item8 = (Item2)p;
            if (item8 != null && (item8.template.id == 193 || item8.template.id == 194))
            {
                GameCanvas2.panel.hide();
            }
        }
        if (idAction == 2000)
        {
            Item2[] arrItemBody = Char2.myCharz().arrItemBody;
            sbyte id2 = (sbyte)GetInventorySelect_bag(selected, newSelected, arrItemBody);
            if (isnewInventory)
            {
                id2 = (sbyte)currItem.indexUI;
            }
            Service2.gI().getItem(BAG_BODY, id2);
        }
        if (idAction == 2001)
        {
            Res2.outz("use item");
            Item2 item9 = (Item2)p;
            bool inventorySelect_isbody = GetInventorySelect_isbody(selected, newSelected, Char2.myCharz().arrItemBody);
            sbyte b = 0;
            b = (inventorySelect_isbody ? ((sbyte)GetInventorySelect_body(selected, newSelected)) : ((sbyte)GetInventorySelect_bag(selected, newSelected, Char2.myCharz().arrItemBody)));
            if (isnewInventory)
            {
                b = (sbyte)currItem.indexUI;
                sbyte where = 0;
                if (newSelected != 0)
                {
                    where = 1;
                }
                Service2.gI().useItem(0, where, b, -1);
            }
            else
            {
                Service2.gI().useItem(0, (sbyte)((!inventorySelect_isbody) ? 1 : 0), b, -1);
            }
            if (item9.template.id == 193 || item9.template.id == 194)
            {
                GameCanvas2.panel.hide();
            }
        }
        if (idAction == 2002)
        {
            if (isnewInventory)
            {
                Service2.gI().getItem(BODY_BAG, (sbyte)sellectInventory);
            }
            else
            {
                Service2.gI().getItem(BODY_BAG, (sbyte)GetInventorySelect_body(selected, newSelected));
            }
        }
        if (idAction == 2003)
        {
            Res2.outz("remove item");
            bool inventorySelect_isbody2 = GetInventorySelect_isbody(selected, newSelected, Char2.myCharz().arrItemBody);
            sbyte b2 = 0;
            b2 = (inventorySelect_isbody2 ? ((sbyte)GetInventorySelect_body(selected, newSelected)) : ((sbyte)GetInventorySelect_bag(selected, newSelected, Char2.myCharz().arrItemBody)));
            Service2.gI().useItem(1, (sbyte)((!inventorySelect_isbody2) ? 1 : 0), b2, -1);
        }
        if (idAction == 2004)
        {
            GameCanvas2.endDlg();
            ItemObject2 itemObject = (ItemObject2)p;
            sbyte where2 = (sbyte)itemObject.where;
            sbyte index = (sbyte)itemObject.id;
            Service2.gI().useItem((sbyte)((itemObject.type != 0) ? 2 : 3), where2, index, -1);
        }
        if (idAction == 2005)
        {
            sbyte id3 = (sbyte)GetInventorySelect_bag(selected, newSelected, Char2.myCharz().arrItemBody);
            Service2.gI().getItem(BAG_PET, id3);
        }
        if (idAction == 2006)
        {
            sbyte id4 = (sbyte)selected;
            Service2.gI().getItem(PET_BAG, id4);
        }
        if (idAction == 2007)
        {
            sbyte id3 = (sbyte)GetInventorySelect_bag(selected, newSelected, Char2.myCharz().arrItemBody);
            Service2.gI().getItem(BAG_PET2, id3);
        }
        if (idAction == 2008)
        {
            sbyte id4 = (sbyte)selected;
            Service2.gI().getItem(PET2_BAG, id4);
        }
        if (idAction == 30001)
        {
            Res2.outz("nhan do");
            Service2.gI().buyItem(0, selected, 0);
        }
        if (idAction == 30002)
        {
            Res2.outz("xoa do");
            Service2.gI().buyItem(1, selected, 0);
        }
        if (idAction == 30003)
        {
            Res2.outz("nhan tat");
            Service2.gI().buyItem(2, selected, 0);
        }
        if (idAction == 3000)
        {
            Res2.outz("mua do");
            Item2 item10 = (Item2)p;
            Service2.gI().buyItem(0, item10.template.id, 0);
        }
        if (idAction == 3001)
        {
            Item2 item11 = (Item2)p;
            GameCanvas2.msgdlg.pleasewait();
            Service2.gI().buyItem(1, item11.template.id, 0);
        }
        if (idAction == 3002)
        {
            GameCanvas2.endDlg();
            bool inventorySelect_isbody3 = GetInventorySelect_isbody(selected, newSelected, Char2.myCharz().arrItemBody);
            sbyte b3 = 0;
            b3 = (inventorySelect_isbody3 ? ((sbyte)GetInventorySelect_body(selected, newSelected)) : ((sbyte)GetInventorySelect_bag(selected, newSelected, Char2.myCharz().arrItemBody)));
            Service2.gI().saleItem(0, (sbyte)((!inventorySelect_isbody3) ? 1 : 0), b3);
        }
        if (idAction == 3003)
        {
            GameCanvas2.endDlg();
            ItemObject2 itemObject2 = (ItemObject2)p;
            Service2.gI().saleItem(1, (sbyte)itemObject2.type, (short)itemObject2.id);
        }
        if (idAction == 3004)
        {
            Item2 item12 = (Item2)p;
            Service2.gI().buyItem(3, item12.template.id, 0);
        }
        if (idAction == 3005)
        {
            // Mua do
            Item2 item13 = (Item2)p;
            Service2.gI().buyItem(3, item13.template.id, 0);
        }
        if (idAction == 3006)
        {
            MainMod2.itemBuy = (Item2)p;
        }
        if (idAction == 4000)
        {
            Clan2 clan = (Clan2)p;
            if (clan != null)
            {
                GameCanvas2.endDlg();
                Service2.gI().clanMessage(2, null, clan.ID);
            }
        }
        if (idAction == 4001)
        {
            Clan2 clan2 = (Clan2)p;
            if (clan2 != null)
            {
                InfoDlg2.showWait();
                clanReport = mResources2.PLEASEWAIT;
                Service2.gI().clanMember(clan2.ID);
            }
        }
        if (idAction == 4005)
        {
            GameCanvas2.endDlg();
        }
        if (idAction == 4007)
        {
            GameCanvas2.endDlg();
        }
        if (idAction == 4006)
        {
            ClanMessage2 clanMessage = (ClanMessage2)p;
            Service2.gI().clanDonate(clanMessage.id);
        }
        if (idAction == 5001)
        {
            Member2 member = (Member2)p;
            Service2.gI().clanRemote(member.ID, 0);
        }
        if (idAction == 5002)
        {
            Member2 member2 = (Member2)p;
            Service2.gI().clanRemote(member2.ID, 1);
        }
        if (idAction == 5003)
        {
            Member2 member3 = (Member2)p;
            Service2.gI().clanRemote(member3.ID, 2);
        }
        if (idAction == 5004)
        {
            Member2 member4 = (Member2)p;
            Service2.gI().clanRemote(member4.ID, -1);
        }
        if (idAction == 9000)
        {
            int typeChar;
            try
            {
                typeChar = (int)p;
            }
            catch (Exception)
            {
                typeChar = 16;
            }
            Service2.gI().upPotential(typeChar, selected, 1);
            GameCanvas2.endDlg();
            InfoDlg2.showWait();
        }
        if (idAction == 9006)
        {
            int typeChar;
            try
            {
                typeChar = (int)p;
            }
            catch (Exception)
            {
                typeChar = 16;
            }
            Service2.gI().upPotential(typeChar, selected, 10);
            GameCanvas2.endDlg();
            InfoDlg2.showWait();
        }
        if (idAction == 9007)
        {
            int typeChar;
            try
            {
                typeChar = (int)p;
            }
            catch (Exception)
            {
                typeChar = 16;
            }
            Service2.gI().upPotential(typeChar, selected, 100);
            GameCanvas2.endDlg();
            InfoDlg2.showWait();
        }
        if (idAction == 9002)
        {
            Skill2 skill = (Skill2)p;
            if (skill.template.isSkillSpec())
            {
                GameCanvas2.startOKDlg(mResources2.updSkill);
            }
            else
            {
                GameCanvas2.startOKDlg(mResources2.can_buy_from_Uron1 + skill.powRequire + mResources2.can_buy_from_Uron2 + skill.moreInfo + mResources2.can_buy_from_Uron3);
            }
        }
        if (idAction == 9003)
        {
            if (GameCanvas2.isTouch && !Main2.isPC)
            {
                GameScr2.gI().doSetOnScreenSkill((SkillTemplate2)p);
            }
            else
            {
                GameScr2.gI().doSetKeySkill((SkillTemplate2)p);
            }
        }
        if (idAction == 9004)
        {
            Skill2 skill2 = (Skill2)p;
            if (skill2.template.isSkillSpec())
            {
                GameCanvas2.startOKDlg(mResources2.learnSkill);
            }
            else
            {
                GameCanvas2.startOKDlg(mResources2.can_buy_from_Uron1 + skill2.powRequire + mResources2.can_buy_from_Uron2 + skill2.moreInfo + mResources2.can_buy_from_Uron3);
            }
        }
        if (idAction == 10000)
        {
            InfoItem2 infoItem5 = (InfoItem2)p;
            Service2.gI().enemy(1, infoItem5.charInfo.charID);
            GameCanvas2.panel.hideNow();
        }
        if (idAction == 10001)
        {
            InfoItem2 infoItem6 = (InfoItem2)p;
            Service2.gI().enemy(2, infoItem6.charInfo.charID);
            InfoDlg2.showWait();
        }
        if (idAction == 10021)
        {
        }
        if (idAction == 10012)
        {
            if (chatTField == null)
            {
                chatTField = new ChatTextField2();
                chatTField.tfChat.y = GameCanvas2.h - 35 - global::ChatTextField2.gI().tfChat.height;
                chatTField.initChatTextField();
                chatTField.parentScreen = ((GameCanvas2.panel2 != null) ? GameCanvas2.panel2 : GameCanvas2.panel);
            }
            chatTField.tfChat.setIputType(TField2.INPUT_TYPE_NUMERIC);
            chatTField.tfChat.setText(string.Empty);
            if (currItem.quantity == 1)
            {
                chatTField.strChat = mResources2.kiguiXuchat;
                chatTField.tfChat.name = mResources2.input_money;
            }
            else
            {
                chatTField.strChat = mResources2.input_quantity + " ";
                chatTField.tfChat.name = mResources2.input_quantity;
            }
            chatTField.tfChat.setMaxTextLenght(9);
            chatTField.to = string.Empty;
            chatTField.isShow = true;
            chatTField.tfChat.setIputType(TField2.INPUT_TYPE_NUMERIC);
            if (GameCanvas2.isTouch)
            {
                chatTField.tfChat.doChangeToTextBox();
            }
            if (Main2.isWindowsPhone)
            {
                chatTField.tfChat.strInfo = chatTField.strChat;
            }
            if (Main2.isIPhone)
            {
                chatTField.startChat(this, string.Empty);
            }
        }
        if (idAction == 10013)
        {
            if (chatTField == null)
            {
                chatTField = new ChatTextField2();
                chatTField.tfChat.y = GameCanvas2.h - 35 - global::ChatTextField2.gI().tfChat.height;
                chatTField.initChatTextField();
                chatTField.parentScreen = ((GameCanvas2.panel2 != null) ? GameCanvas2.panel2 : GameCanvas2.panel);
            }
            chatTField.tfChat.setIputType(TField2.INPUT_TYPE_NUMERIC);
            chatTField.tfChat.setText(string.Empty);
            if (currItem.quantity == 1)
            {
                chatTField.strChat = mResources2.kiguiLuongchat;
                chatTField.tfChat.name = mResources2.input_money;
            }
            else
            {
                chatTField.strChat = mResources2.input_quantity + "  ";
                chatTField.tfChat.name = mResources2.input_quantity;
            }
            chatTField.to = string.Empty;
            chatTField.isShow = true;
            chatTField.tfChat.setIputType(TField2.INPUT_TYPE_NUMERIC);
            if (GameCanvas2.isTouch)
            {
                chatTField.tfChat.doChangeToTextBox();
            }
            if (Main2.isWindowsPhone)
            {
                chatTField.tfChat.strInfo = chatTField.strChat;
            }
            if (Main2.isIPhone)
            {
                chatTField.startChat(this, string.Empty);
            }
        }
        if (idAction == 10014)
        {
            Item2 item14 = (Item2)p;
            Service2.gI().kigui(1, item14.itemId, -1, -1, -1);
            InfoDlg2.showWait();
        }
        if (idAction == 10015)
        {
            Item2 item15 = (Item2)p;
            Service2.gI().kigui(2, item15.itemId, -1, -1, -1);
            InfoDlg2.showWait();
        }
        if (idAction == 10016)
        {
            Item2 item16 = (Item2)p;
            Service2.gI().kigui(3, item16.itemId, 0, item16.buyCoin, -1);
            InfoDlg2.showWait();
        }
        if (idAction == 10017)
        {
            Item2 item17 = (Item2)p;
            Service2.gI().kigui(3, item17.itemId, 1, item17.buyGold, -1);
            InfoDlg2.showWait();
        }
        if (idAction == 10018)
        {
            Item2 item18 = (Item2)p;
            Service2.gI().kigui(5, item18.itemId, -1, -1, -1);
            InfoDlg2.showWait();
        }
        if (idAction == 10019)
        {
            Session_ME2_.gI().close();
            Rms2.saveRMSString("acc", string.Empty);
            Rms2.saveRMSString("pass", string.Empty);
            GameCanvas2.loginScr.tfPass.setText(string.Empty);
            GameCanvas2.loginScr.tfUser.setText(string.Empty);
            GameCanvas2.loginScr.isLogin2 = false;
            GameCanvas2.loginScr.switchToMe();
            GameCanvas2.endDlg();
            hide();
        }
        if (idAction == 10020)
        {
            GameCanvas2.endDlg();
        }
        if (idAction == 10030)
        {
            Service2.gI().getFlag(1, (sbyte)selected);
            GameCanvas2.panel.hideNow();
        }
        if (idAction == 10031)
        {
            Session_ME2_.gI().close();
        }
        if (idAction == 11000)
        {
            Service2.gI().kigui(0, currItem.itemId, 1, currItem.buyRuby, 1);
            GameCanvas2.endDlg();
        }
        if (idAction == 11001)
        {
            Service2.gI().kigui(0, currItem.itemId, 1, currItem.buyRuby, currItem.quantilyToBuy);
            GameCanvas2.endDlg();
        }
        if (idAction == 11002)
        {
            chatTField.isShow = false;
            GameCanvas2.endDlg();
        }
    }

    public void onChatFromMe(string text, string to)
    {
        if (chatTField.strChat == "Nhập chỉ số mong muốn")
        {
            if (chatTField.tfChat.getText() != string.Empty)
            {
                int param;
                bool success = int.TryParse(text, out param);
                if (success)
                {
                    MainMod2.GI().SetAutoIntrinsic(param);
                }
                else
                {
                    GameScr2.info1.addInfo("Chỉ số đã nhập không hợp lệ", 0);
                }
                chatTField.isShow = false;
            }
        }
        else if (chatTField.strChat == "Nhập số sao cần đập")
        {
            if (chatTField.tfChat.getText() != string.Empty)
            {
                int maxPhale;
                bool success = int.TryParse(text, out maxPhale);
                if (success && maxPhale > 0)
                {
                    GameScr2.info1.addInfo(string.Concat(new object[]
                    {
                    "Đập ",
                    MainMod2.itemPhale.template.name,
                    " đến ",
                    maxPhale,
                    " sao"
                    }), 0);
                    MainMod2.maxPhale = maxPhale;
                }
                else
                {
                    GameScr2.info1.addInfo("Số sao đã nhập không đúng", 0);
                }
                chatTField.isShow = false;
            }
        }
        if (chatTField.tfChat.getText() == null || chatTField.tfChat.getText().Equals(string.Empty) || text.Equals(string.Empty) || text == null)
        {
            chatTField.isShow = false;
            return;
        }
        if (chatTField.strChat.Equals(mResources2.input_clan_name))
        {
            InfoDlg2.showWait();
            chatTField.isShow = false;
            Service2.gI().searchClan(text);
            return;
        }
        if (chatTField.strChat.Equals(mResources2.chat_clan))
        {
            InfoDlg2.showWait();
            chatTField.isShow = false;
            Service2.gI().clanMessage(0, text, -1);
            return;
        }
        if (chatTField.strChat.Equals(mResources2.input_clan_name_to_create))
        {
            if (chatTField.tfChat.getText() == string.Empty)
            {
                GameScr2.info1.addInfo(mResources2.clan_name_blank, 0);
                return;
            }
            if (tabIcon == null)
            {
                tabIcon = new TabClanIcon2();
            }
            tabIcon.text = chatTField.tfChat.getText();
            tabIcon.show(isGetName: false);
            chatTField.isShow = false;
            return;
        }
        if (chatTField.strChat.Equals(mResources2.input_clan_slogan))
        {
            if (chatTField.tfChat.getText() == string.Empty)
            {
                GameScr2.info1.addInfo(mResources2.clan_slogan_blank, 0);
                return;
            }
            Service2.gI().getClan(4, (sbyte)Char2.myCharz().clan.imgID, chatTField.tfChat.getText());
            chatTField.isShow = false;
            return;
        }
        if (chatTField.strChat.Equals(mResources2.input_Inventory_Pass))
        {
            try
            {
                int lockInventory = int.Parse(chatTField.tfChat.getText());
                chatTField.isShow = false;
                chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
                hide();
                if (chatTField.tfChat.getText().Length != 6 || chatTField.tfChat.getText().Equals(string.Empty))
                {
                    GameCanvas2.startOKDlg(mResources2.input_Inventory_Pass_wrong);
                }
                else
                {
                    Service2.gI().setLockInventory(lockInventory);
                    chatTField.isShow = false;
                    chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
                    hide();
                }
                return;
            }
            catch (Exception)
            {
                GameCanvas2.startOKDlg(mResources2.ALERT_PRIVATE_PASS_2);
                return;
            }
        }
        if (chatTField.strChat.Equals(mResources2.world_channel_5_luong))
        {
            if (!chatTField.tfChat.getText().Equals(string.Empty))
            {
                Service2.gI().chatGlobal(chatTField.tfChat.getText());
                chatTField.isShow = false;
            }
        }
        else if (chatTField.strChat.Equals(mResources2.chat_player))
        {
            chatTField.isShow = false;
            InfoItem2 infoItem = null;
            if (type == 8)
            {
                infoItem = (InfoItem2)logChat.elementAt(currInfoItem);
            }
            else if (type == 11)
            {
                infoItem = (InfoItem2)vFriend.elementAt(currInfoItem);
            }
            if (infoItem.charInfo.charID != Char2.myCharz().charID)
            {
                Service2.gI().chatPlayer(text, infoItem.charInfo.charID);
            }
        }
        else if (chatTField.strChat.Equals(mResources2.input_quantity_to_trade))
        {
            int num = 0;
            try
            {
                num = int.Parse(chatTField.tfChat.getText());
            }
            catch (Exception)
            {
                GameCanvas2.startOKDlg(mResources2.input_quantity_wrong);
                chatTField.isShow = false;
                chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
                return;
            }
            if (num <= 0 || num > currItem.quantity)
            {
                GameCanvas2.startOKDlg(mResources2.input_quantity_wrong);
                chatTField.isShow = false;
                chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
                return;
            }
            currItem.isSelect = true;
            Item2 item = new()
            {
                template = currItem.template,
                quantity = num,
                indexUI = currItem.indexUI,
                itemOption = currItem.itemOption
            };
            GameCanvas2.panel.vMyGD.addElement(item);
            Service2.gI().giaodich(2, -1, (sbyte)item.indexUI, item.quantity);
            chatTField.isShow = false;
            chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
        }
        else if (chatTField.strChat == mResources2.input_money_to_trade)
        {
            int num2;
            try
            {
                num2 = int.Parse(chatTField.tfChat.getText());
            }
            catch (Exception)
            {
                GameCanvas2.startOKDlg(mResources2.input_money_wrong);
                chatTField.isShow = false;
                chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
                return;
            }
            if (num2 > Char2.myCharz().xu)
            {
                GameCanvas2.startOKDlg(mResources2.not_enough_money);
                chatTField.isShow = false;
                chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
            }
            else
            {
                moneyGD = num2;
                Service2.gI().giaodich(2, -1, -1, num2);
                chatTField.isShow = false;
                chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
            }
        }
        else if (chatTField.strChat.Equals(mResources2.kiguiXuchat))
        {
            try
            {
                Service2.gI().kigui(0, currItem.itemId, 0, int.Parse(chatTField.tfChat.getText()), 1);
            }
            catch (Exception)
            {
                GameCanvas2.startOKDlg(mResources2.input_money_wrong);
            }
            chatTField.isShow = false;
        }
        else if (chatTField.strChat.Equals(mResources2.kiguiXuchat + " "))
        {
            try
            {
                Service2.gI().kigui(0, currItem.itemId, 0, int.Parse(chatTField.tfChat.getText()), currItem.quantilyToBuy);
            }
            catch (Exception)
            {
                GameCanvas2.startOKDlg(mResources2.input_money_wrong);
            }
            chatTField.isShow = false;
        }
        else if (chatTField.strChat.Equals(mResources2.kiguiLuongchat))
        {
            doNotiRuby(0);
            chatTField.isShow = false;
        }
        else if (chatTField.strChat.Equals(mResources2.kiguiLuongchat + "  "))
        {
            doNotiRuby(1);
            chatTField.isShow = false;
        }
        else if (chatTField.strChat.Equals(mResources2.input_quantity + " "))
        {
            currItem.quantilyToBuy = int.Parse(chatTField.tfChat.getText());
            if (currItem.quantilyToBuy > currItem.quantity)
            {
                GameCanvas2.startOKDlg(mResources2.input_quantity_wrong);
                return;
            }
            isKiguiXu = true;
            chatTField.isShow = false;
        }
        else if (chatTField.strChat.Equals(mResources2.input_quantity + "  "))
        {
            currItem.quantilyToBuy = int.Parse(chatTField.tfChat.getText());
            if (currItem.quantilyToBuy > currItem.quantity)
            {
                GameCanvas2.startOKDlg(mResources2.input_quantity_wrong);
                return;
            }
            isKiguiLuong = true;
            chatTField.isShow = false;
        }
    }

    public void onCancelChat()
    {
        chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
    }

    public void setCombineEff(int type)
    {
        typeCombine = type;
        rS = 90;
        if (typeCombine == 0)
        {
            iDotS = 5;
            angleS = (angleO = 90);
            time = 2;
            for (int i = 0; i < vItemCombine.size(); i++)
            {
                Item2 item = (Item2)vItemCombine.elementAt(i);
                if (item != null)
                {
                    if (item.template.type == 14)
                    {
                        iconID2 = item.template.iconID;
                    }
                    else
                    {
                        iconID1 = item.template.iconID;
                    }
                }
            }
        }
        else if (typeCombine == 1)
        {
            iDotS = 2;
            angleS = (angleO = 0);
            time = 1;
            for (int j = 0; j < vItemCombine.size(); j++)
            {
                Item2 item2 = (Item2)vItemCombine.elementAt(j);
                if (item2 != null)
                {
                    if (j == 0)
                    {
                        iconID1 = item2.template.iconID;
                    }
                    else
                    {
                        iconID2 = item2.template.iconID;
                    }
                }
            }
        }
        else if (typeCombine == 2)
        {
            iDotS = 7;
            angleS = (angleO = 25);
            time = 1;
            for (int k = 0; k < vItemCombine.size(); k++)
            {
                Item2 item3 = (Item2)vItemCombine.elementAt(k);
                if (item3 != null)
                {
                    iconID1 = item3.template.iconID;
                }
            }
        }
        else if (typeCombine == 3)
        {
            xS = GameCanvas2.hw;
            yS = GameCanvas2.hh;
            iDotS = 1;
            angleS = (angleO = 1);
            time = 4;
            for (int l = 0; l < vItemCombine.size(); l++)
            {
                Item2 item4 = (Item2)vItemCombine.elementAt(l);
                if (item4 != null)
                {
                    iconID1 = item4.template.iconID;
                }
            }
        }
        else if (typeCombine == 4)
        {
            iDotS = vItemCombine.size();
            iconID = new short[iDotS];
            angleS = (angleO = 25);
            time = 1;
            for (int m = 0; m < vItemCombine.size(); m++)
            {
                Item2 item5 = (Item2)vItemCombine.elementAt(m);
                if (item5 != null)
                {
                    iconID[m] = item5.template.iconID;
                }
            }
        }
        speed = 1;
        isSpeedCombine = true;
        isDoneCombine = false;
        isCompleteEffCombine = false;
        iAngleS = 360 / iDotS;
        xArgS = new int[iDotS];
        yArgS = new int[iDotS];
        xDotS = new int[iDotS];
        yDotS = new int[iDotS];
        setDotStar();
        isPaintCombine = true;
        countUpdate = 10;
        countR = 30;
        countWait = 10;
        addTextCombineNPC(idNPC, mResources2.combineSpell);
    }

    private void updateCombineEff()
    {
        countUpdate--;
        if (countUpdate < 0)
        {
            countUpdate = 0;
        }
        countR--;
        if (countR < 0)
        {
            countR = 0;
        }
        if (countUpdate != 0)
        {
            return;
        }
        if (!isCompleteEffCombine)
        {
            if (time > 0)
            {
                if (combineSuccess != -1)
                {
                    if (typeCombine == 3)
                    {
                        if (GameCanvas2.gameTick % 10 == 0)
                        {
                            Effect2_ me = new Effect2_(21, xS - 10, yS + 25, 4, 1, 1);
                            EffecMn2.addEff(me);
                            time--;
                        }
                    }
                    else
                    {
                        if (GameCanvas2.gameTick % 2 == 0)
                        {
                            if (isSpeedCombine)
                            {
                                if (speed < 40)
                                {
                                    speed += 2;
                                }
                            }
                            else if (speed > 10)
                            {
                                speed -= 2;
                            }
                        }
                        if (countR == 0)
                        {
                            if (isSpeedCombine)
                            {
                                if (rS > 0)
                                {
                                    rS -= 5;
                                }
                                else if (GameCanvas2.gameTick % 10 == 0)
                                {
                                    isSpeedCombine = false;
                                    time--;
                                    countR = 5;
                                    countWait = 10;
                                }
                            }
                            else if (rS < 90)
                            {
                                rS += 5;
                            }
                            else if (GameCanvas2.gameTick % 10 == 0)
                            {
                                isSpeedCombine = true;
                                countR = 10;
                            }
                        }
                        angleS = angleO;
                        angleS -= speed;
                        if (angleS >= 360)
                        {
                            angleS -= 360;
                        }
                        if (angleS < 0)
                        {
                            angleS = 360 + angleS;
                        }
                        angleO = angleS;
                        setDotStar();
                    }
                }
            }
            else if (GameCanvas2.gameTick % 20 == 0)
            {
                isCompleteEffCombine = true;
            }
            if (GameCanvas2.gameTick % 20 == 0)
            {
                if (typeCombine != 3)
                {
                    EffectPanel2.addServerEffect(132, xS, yS, 2);
                }
                EffectPanel2.addServerEffect(114, xS, yS + 20, 2);
            }
        }
        else
        {
            if (!isCompleteEffCombine)
            {
                return;
            }
            if (combineSuccess == 1)
            {
                if (countWait == 10)
                {
                    Effect2_ me2 = new Effect2_(22, xS - 3, yS + 25, 4, 1, 1);
                    EffecMn2.addEff(me2);
                }
                countWait--;
                if (countWait < 0)
                {
                    countWait = 0;
                }
                if (rS < 300)
                {
                    rS = Res2.abs(rS + 10);
                    if (rS == 20)
                    {
                        addTextCombineNPC(idNPC, mResources2.combineFail);
                    }
                }
                else if (GameCanvas2.gameTick % 20 == 0)
                {
                    if (GameCanvas2.w > 2 * WIDTH_PANEL)
                    {
                        GameCanvas2.panel2 = new Panel2();
                        GameCanvas2.panel2.tabName[7] = new string[1][] { new string[1] { string.Empty } };
                        GameCanvas2.panel2.setTypeBodyOnly();
                        GameCanvas2.panel2.show();
                    }
                    combineSuccess = -1;
                    isDoneCombine = true;
                    if (typeCombine == 4)
                    {
                        GameCanvas2.panel.hideNow();
                    }
                }
                setDotStar();
            }
            else
            {
                if (combineSuccess != 0)
                {
                    return;
                }
                if (countWait == 10)
                {
                    if (typeCombine == 2)
                    {
                        Effect2_ me3 = new Effect2_(20, xS - 3, yS + 15, 4, 2, 1);
                        EffecMn2.addEff(me3);
                    }
                    else
                    {
                        Effect2_ me4 = new Effect2_(21, xS - 10, yS + 25, 4, 1, 1);
                        EffecMn2.addEff(me4);
                    }
                    addTextCombineNPC(idNPC, mResources2.combineSuccess);
                    isPaintCombine = false;
                }
                if (isPaintCombine)
                {
                    return;
                }
                countWait--;
                if (countWait < -50)
                {
                    countWait = -50;
                    if (typeCombine < 3 && GameCanvas2.w > 2 * WIDTH_PANEL)
                    {
                        GameCanvas2.panel2 = new Panel2();
                        GameCanvas2.panel2.tabName[7] = new string[1][] { new string[1] { string.Empty } };
                        GameCanvas2.panel2.setTypeBodyOnly();
                        GameCanvas2.panel2.show();
                    }
                    combineSuccess = -1;
                    isDoneCombine = true;
                    if (typeCombine == 4)
                    {
                        GameCanvas2.panel.hideNow();
                    }
                }
            }
        }
    }

    public void paintCombineEff(mGraphics2 g)
    {
        GameScr2.gI().paintBlackSky(g);
        paintCombineNPC(g);
        if (GameCanvas2.gameTick % 4 == 0)
        {
            g.drawImage(ItemMap2.imageFlare, xS, yS + 15, mGraphics2.BOTTOM | mGraphics2.HCENTER);
        }
        if (typeCombine == 0)
        {
            for (int i = 0; i < yArgS.Length; i++)
            {
                SmallImage2.drawSmallImage(g, iconID1, xS, yS, 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
                if (isPaintCombine)
                {
                    SmallImage2.drawSmallImage(g, iconID2, xDotS[i], yDotS[i], 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
                }
            }
        }
        else if (typeCombine == 1)
        {
            if (!isPaintCombine)
            {
                SmallImage2.drawSmallImage(g, iconID3, xS, yS, 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
                return;
            }
            for (int j = 0; j < yArgS.Length; j++)
            {
                SmallImage2.drawSmallImage(g, iconID1, xDotS[0], yDotS[0], 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
                SmallImage2.drawSmallImage(g, iconID2, xDotS[1], yDotS[1], 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
            }
        }
        else if (typeCombine == 2)
        {
            if (!isPaintCombine)
            {
                SmallImage2.drawSmallImage(g, iconID3, xS, yS, 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
                return;
            }
            for (int k = 0; k < yArgS.Length; k++)
            {
                SmallImage2.drawSmallImage(g, iconID1, xDotS[k], yDotS[k], 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
            }
        }
        else if (typeCombine == 3)
        {
            if (!isPaintCombine)
            {
                SmallImage2.drawSmallImage(g, iconID3, xS, yS, 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
            }
            else
            {
                SmallImage2.drawSmallImage(g, iconID1, xS, yS, 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
            }
        }
        else
        {
            if (typeCombine != 4)
            {
                return;
            }
            if (!isPaintCombine)
            {
                if (iconID3 != -1)
                {
                    SmallImage2.drawSmallImage(g, iconID3, xS, yS, 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
                }
            }
            else
            {
                for (int l = 0; l < iconID.Length; l++)
                {
                    SmallImage2.drawSmallImage(g, iconID[l], xDotS[l], yDotS[l], 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
                }
            }
        }
    }

    private void setDotStar()
    {
        for (int i = 0; i < yArgS.Length; i++)
        {
            if (angleS >= 360)
            {
                angleS -= 360;
            }
            if (angleS < 0)
            {
                angleS = 360 + angleS;
            }
            yArgS[i] = Res2.abs(rS * Res2.sin(angleS) / 1024);
            xArgS[i] = Res2.abs(rS * Res2.cos(angleS) / 1024);
            if (angleS < 90)
            {
                xDotS[i] = xS + xArgS[i];
                yDotS[i] = yS - yArgS[i];
            }
            else if (angleS >= 90 && angleS < 180)
            {
                xDotS[i] = xS - xArgS[i];
                yDotS[i] = yS - yArgS[i];
            }
            else if (angleS >= 180 && angleS < 270)
            {
                xDotS[i] = xS - xArgS[i];
                yDotS[i] = yS + yArgS[i];
            }
            else
            {
                xDotS[i] = xS + xArgS[i];
                yDotS[i] = yS + yArgS[i];
            }
            angleS -= iAngleS;
        }
    }

    public void paintCombineNPC(mGraphics2 g)
    {
        g.translate(-GameScr2.cmx, -GameScr2.cmy);
        if (typeCombine < 3)
        {
            for (int i = 0; i < GameScr2.vNpc.size(); i++)
            {
                Npc2 npc = (Npc2)GameScr2.vNpc.elementAt(i);
                if (npc.template.npcTemplateId == idNPC)
                {
                    npc.paint(g);
                    if (npc.chatInfo != null)
                    {
                        npc.chatInfo.paint(g, npc.cx, npc.cy - npc.ch - GameCanvas2.transY, npc.cdir);
                    }
                }
            }
        }
        GameCanvas2.resetTrans(g);
        if (GameCanvas2.gameTick % 4 == 0)
        {
            g.drawImage(ItemMap2.imageFlare, xS - 5, yS + 15, mGraphics2.BOTTOM | mGraphics2.HCENTER);
            g.drawImage(ItemMap2.imageFlare, xS + 5, yS + 15, mGraphics2.BOTTOM | mGraphics2.HCENTER);
            g.drawImage(ItemMap2.imageFlare, xS, yS + 15, mGraphics2.BOTTOM | mGraphics2.HCENTER);
        }
        for (int j = 0; j < Effect2_2.vEffect3.size(); j++)
        {
            Effect2_2 effect = (Effect2_2)Effect2_2.vEffect3.elementAt(j);
            effect.paint(g);
        }
    }

    public void addTextCombineNPC(int idNPC, string text)
    {
        if (typeCombine >= 3)
        {
            return;
        }
        for (int i = 0; i < GameScr2.vNpc.size(); i++)
        {
            Npc2 npc = (Npc2)GameScr2.vNpc.elementAt(i);
            if (npc.template.npcTemplateId == idNPC)
            {
                npc.addInfo(text);
            }
        }
    }

    public void setTypeOption()
    {
        type = 19;
        setType(0);
        setTabOption();
        cmx = (cmtoX = 0);
    }

    public void SetTypeModFunc()
    {
        type = 26;
        setType(0);
        SetTabModFunc();
        cmx = cmtoX = 0;
    }

    private void SetTabModFunc()
    {
        SoundMn2.gI().GetStrModFunc();
        currentListLength = strModFunc.Length;
        ITEM_HEIGHT = 24;
        selected = GameCanvas2.isTouch ? (-1) : 0;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = cmtoY = cmyLast[currentTabIndex];
        if (cmy < 0)
        {
            cmy = cmtoY = 0;
        }
        if (cmy > cmyLim)
        {
            cmy = cmtoY = cmyLim;
        }
    }

    private void setTabOption()
    {
        SoundMn2.gI().getStrOption();
        currentListLength = strCauhinh.Length;
        ITEM_HEIGHT = 24;
        selected = (GameCanvas2.isTouch ? (-1) : 0);
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
    }

    private void paintOption(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        for (int i = 0; i < strCauhinh.Length; i++)
        {
            int x = xScroll;
            int num = yScroll + i * ITEM_HEIGHT;
            int num2 = wScroll - 1;
            int h = ITEM_HEIGHT - 1;
            if (num - cmy <= yScroll + hScroll && num - cmy >= yScroll - ITEM_HEIGHT)
            {
                g.setColor((i != selected) ? 15196114 : 16383818);
                g.fillRect(x, num, num2, h);
                mFont2.tahoma_7b_dark.drawString(g, strCauhinh[i], xScroll + 10, num + 6, mFont2.LEFT);
            }
        }
        paintScrollArrow(g);
    }

    private void PaintModFunc(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        for (int i = 0; i < strModFunc.Length; i++)
        {
            int x = xScroll;
            int num = yScroll + i * ITEM_HEIGHT;
            int num2 = wScroll - 1;
            int h = ITEM_HEIGHT - 1;
            if (num - cmy <= yScroll + hScroll && num - cmy >= yScroll - ITEM_HEIGHT)
            {
                g.setColor((i != selected) ? 15196114 : 16383818);
                g.fillRect(x, num, num2, h);
                mFont2.tahoma_7b_dark.drawString(g, strModFunc[i], xScroll + 10, num + 6, mFont2.LEFT);
            }
        }
        paintScrollArrow(g);
    }

    private void doFireOption()
    {
        if (selected < 0)
        {
            return;
        }
        switch (selected)
        {
            case 0:
                SoundMn2.gI().AuraToolOption();
                break;
            case 1:
                SoundMn2.gI().AuraToolOption2();
                break;
            case 2:
                SoundMn2.gI().soundToolOption();
                break;
            case 3:
                if (!Main2.isIPhone)
                {
                    GameCanvas2.startYesNoDlg(mResources2.changeSizeScreen, new Command2(mResources2.YES, this, 170391, null), new Command2(mResources2.NO, this, 4005, null));
                }
                else
                {
                    SoundMn2.gI().CaseSizeScr();
                }
                break;
            case 4:
                if (!Main2.isIPhone)
                {
                    GameCanvas2.startYesNoDlg(mResources2.changeSizeScreen, new Command2(mResources2.YES, this, 170391, null), new Command2(mResources2.NO, this, 4005, null));
                }
                else
                {
                    SoundMn2.gI().CaseAnalog();
                }
                break;
            case 5:
                SoundMn2.gI().CaseAnalog();
                break;
        }
    }

    private void DoFireModFunc()
    {
        if (selected < 0)
        {
            return;
        }
        switch (selected)
        {
            case 0:
                MainMod2.isHighFps = !MainMod2.isHighFps;
                MainMod2.GI().ChangeFPSTarget();
                break;
            case 1:
                MainMod2.GI().isUpdateZones = !MainMod2.GI().isUpdateZones;
                break;
            case 2:
                MainMod2.showCharsInMap = !MainMod2.showCharsInMap;
                MainMod2.SaveSettings();
                break;
            case 3:
                MainMod2.showInfoPet = !MainMod2.showInfoPet;
                break;
            case 4:
                MainMod2.isAutoPhaLe = !MainMod2.isAutoPhaLe;
                if (MainMod2.isAutoPhaLe)
                {
                    new Thread(new ThreadStart(MainMod2.AutoPhaLe)).Start();
                }
                break;
            case 5:
                if (!MainMod2.isAutoVQMM)
                {
                    hideNow();
                }
                MainMod2.isAutoVQMM = !MainMod2.isAutoVQMM;
                break;
            case 6:
                MainMod2.GI().autoWakeUp = !MainMod2.GI().autoWakeUp;
                break;
            case 7:
                if (MainMod2.isAutoLogin)
                {
                    MainMod2.isAutoLogin = false;
                    MainMod2.autoLogin = null;
                }
                else
                {
                    MainMod2.isAutoLogin = true;
                    MainMod2.autoLogin = new AutoLogin
                    {
                        accAutoLogin = GameCanvas2.loginScr.tfUser.getText()
                    };
                }
                break;
            case 8:
                MainMod2.isShowQuickButton = !MainMod2.isShowQuickButton;
                MainMod2.SaveSettings();
                break;
            case 9:
                MainMod2.isShowXMAPButton = !MainMod2.isShowXMAPButton;
                MainMod2.SaveSettings();
                break;
        }
        SoundMn2.gI().GetStrModFunc();
    }

    public void setTypeAccount()
    {
        type = 20;
        setType(0);
        setTabAccount();
        cmx = (cmtoX = 0);
    }

    private void setTabAccount()
    {
        if (Main2.isIPhone)
        {
            strAccount = new string[4]
            {
                mResources2.inventory_Pass,
                mResources2.friend,
                mResources2.enemy,
                mResources2.msg
            };
            if (GameScr2.canAutoPlay)
            {
                strAccount = new string[5]
                {
                    mResources2.inventory_Pass,
                    mResources2.friend,
                    mResources2.enemy,
                    mResources2.msg,
                    mResources2.autoFunction
                };
            }
        }
        else
        {
            strAccount = new string[5]
            {
                mResources2.inventory_Pass,
                mResources2.friend,
                mResources2.enemy,
                mResources2.msg,
                mResources2.charger
            };
            if (GameScr2.canAutoPlay)
            {
                strAccount = new string[6]
                {
                    mResources2.inventory_Pass,
                    mResources2.friend,
                    mResources2.enemy,
                    mResources2.msg,
                    mResources2.charger,
                    mResources2.autoFunction
                };
            }
            if ((mSystem2.clientType == 2 || mSystem2.clientType == 7) && mResources2.language != 2)
            {
                strAccount = new string[5]
                {
                    mResources2.inventory_Pass,
                    mResources2.friend,
                    mResources2.enemy,
                    mResources2.msg,
                    mResources2.charger
                };
                if (GameScr2.canAutoPlay)
                {
                    strAccount = new string[6]
                    {
                        mResources2.inventory_Pass,
                        mResources2.friend,
                        mResources2.enemy,
                        mResources2.msg,
                        mResources2.charger,
                        mResources2.autoFunction
                    };
                }
            }
        }
        currentListLength = strAccount.Length;
        ITEM_HEIGHT = 24;
        selected = (GameCanvas2.isTouch ? (-1) : 0);
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
    }

    private void paintAccount(mGraphics2 g)
    {
        g.setClip(xScroll, yScroll, wScroll, hScroll);
        g.translate(0, -cmy);
        for (int i = 0; i < strAccount.Length; i++)
        {
            int x = xScroll;
            int num = yScroll + i * ITEM_HEIGHT;
            int num2 = wScroll - 1;
            int h = ITEM_HEIGHT - 1;
            if (num - cmy <= yScroll + hScroll && num - cmy >= yScroll - ITEM_HEIGHT)
            {
                g.setColor((i != selected) ? 15196114 : 16383818);
                g.fillRect(x, num, num2, h);
                mFont2.tahoma_7b_dark.drawString(g, strAccount[i], xScroll + wScroll / 2, num + 6, mFont2.CENTER);
            }
        }
        paintScrollArrow(g);
    }

    private void doFireAccount()
    {
        if (selected < 0)
        {
            return;
        }
        switch (selected)
        {
            case 0:
                GameCanvas2.endDlg();
                if (chatTField == null)
                {
                    chatTField = new ChatTextField2();
                    chatTField.tfChat.y = GameCanvas2.h - 35 - global::ChatTextField2.gI().tfChat.height;
                    chatTField.initChatTextField();
                    chatTField.parentScreen = GameCanvas2.panel;
                }
                chatTField.tfChat.setText(string.Empty);
                chatTField.strChat = mResources2.input_Inventory_Pass;
                chatTField.tfChat.name = mResources2.input_Inventory_Pass;
                chatTField.to = string.Empty;
                chatTField.isShow = true;
                chatTField.tfChat.isFocus = true;
                chatTField.tfChat.setIputType(TField2.INPUT_TYPE_NUMERIC);
                if (GameCanvas2.isTouch)
                {
                    chatTField.tfChat.doChangeToTextBox();
                }
                if (Main2.isIPhone)
                {
                    chatTField.startChat(this, string.Empty);
                }
                if (Main2.isWindowsPhone)
                {
                    chatTField.tfChat.strInfo = chatTField.strChat;
                }
                break;
            case 1:
                Service2.gI().friend(0, -1);
                InfoDlg2.showWait();
                break;
            case 2:
                Service2.gI().enemy(0, -1);
                InfoDlg2.showWait();
                break;
            case 3:
                setTypeMessage();
                if (chatTField == null)
                {
                    chatTField = new ChatTextField2();
                    chatTField.tfChat.y = GameCanvas2.h - 35 - global::ChatTextField2.gI().tfChat.height;
                    chatTField.initChatTextField();
                    chatTField.parentScreen = GameCanvas2.panel;
                }
                break;
            case 4:
                if (mResources2.language == 2)
                {
                    string url = "http://dragonball.indonaga.com/coda/?username=" + GameCanvas2.loginScr.tfUser.getText();
                    hideNow();
                    try
                    {
                        GameMidlet2.instance.platformRequest(url);
                        break;
                    }
                    catch (Exception ex)
                    {
                        ex.StackTrace.ToString();
                        break;
                    }
                }
                hideNow();
                if (Char2.myCharz().taskMaint.taskId <= 10)
                {
                    GameCanvas2.startOKDlg(mResources2.finishBomong);
                }
                else
                {
                    MoneyCharge2.gI().switchToMe();
                }
                break;
            case 5:
                setTypeAuto();
                break;
        }
    }

    private void updateKeyOption()
    {
        updateKeyScrollView();
    }

    public void setTypeSpeacialSkill()
    {
        type = 25;
        setType(0);
        setTabSpeacialSkill();
        currentTabIndex = 0;
    }

    private void setTabSpeacialSkill()
    {
        ITEM_HEIGHT = 24;
        currentListLength = Char2.myCharz().infoSpeacialSkill[currentTabIndex].Length;
        cmyLim = currentListLength * ITEM_HEIGHT - hScroll;
        if (cmyLim < 0)
        {
            cmyLim = 0;
        }
        cmy = (cmtoY = cmyLast[currentTabIndex]);
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        selected = (GameCanvas2.isTouch ? (-1) : 0);
    }

    public bool isTypeShop()
    {
        if (type == 1)
        {
            return true;
        }
        return false;
    }

    private void doNotiRuby(int type)
    {
        try
        {
            currItem.buyRuby = int.Parse(chatTField.tfChat.getText());
        }
        catch (Exception)
        {
            GameCanvas2.startOKDlg(mResources2.input_money_wrong);
            chatTField.isShow = false;
            return;
        }
        Command2 cmdYes = new Command2(mResources2.YES, this, (type != 0) ? 11001 : 11000, null);
        Command2 cmdNo = new Command2(mResources2.NO, this, 11002, null);
        GameCanvas2.startYesNoDlg(mResources2.notiRuby, cmdYes, cmdNo);
    }

    public static void paintUpgradeEffect(int x, int y, int wItem, int hItem, int nline, int cl, mGraphics2 g)
    {
        try
        {
            int num = (wItem << 1) + (hItem << 1);
            int num2 = num / nline;
            nsize = sizeUpgradeEff.Length;
            if (nline > 4)
            {
                nsize = 2;
            }
            for (int i = 0; i < nline; i++)
            {
                for (int j = 0; j < nsize; j++)
                {
                    int wSize = ((sizeUpgradeEff[j] <= 1) ? 1 : ((sizeUpgradeEff[j] >> 1) + 1));
                    int x2 = x + upgradeEffectX(num2 * i, GameCanvas2.gameTick - j * 4, wItem, hItem, wSize);
                    int y2 = y + upgradeEffectY(num2 * i, GameCanvas2.gameTick - j * 4, wItem, hItem, wSize);
                    g.setColor(colorUpgradeEffect[cl][j]);
                    g.fillRect(x2, y2, sizeUpgradeEff[j], sizeUpgradeEff[j]);
                }
            }
        }
        catch (Exception)
        {
        }
    }

    private static int upgradeEffectX(int dk, int tick, int wItem, int hitem, int wSize)
    {
        int num = (tick + dk) % ((wItem << 1) + (hitem << 1));
        if (0 <= num && num < wItem)
        {
            return num % wItem;
        }
        if (wItem <= num && num < wItem + hitem)
        {
            return wItem - wSize;
        }
        if (wItem + hitem <= num && num < (wItem << 1) + hitem)
        {
            return wItem - (num - hitem) % wItem - wSize;
        }
        return 0;
    }

    private static int upgradeEffectY(int dk, int tick, int wItem, int hitem, int wSize)
    {
        int num = (tick + dk) % ((wItem << 1) + (hitem << 1));
        if (0 <= num && num < wItem)
        {
            return 0;
        }
        if (wItem <= num && num < wItem + hitem)
        {
            return num % wItem;
        }
        if (wItem + hitem <= num && num < (wItem << 1) + hitem)
        {
            return hitem - wSize;
        }
        return hitem - (num - (wItem << 1)) % hitem - wSize;
    }

    public static int GetColor_ItemBg(int id)
    {
        return id switch
        {
            4 => 1269146,
            1 => 2786816,
            5 => 13279744,
            3 => 12537346,
            2 => 7078041,
            6 => 11599872,
            _ => -1,
        };
    }

    public static sbyte GetColor_Item_Upgrade(int lv)
    {
        if (lv < 0)
        {
            return 0;
        }
        switch (lv)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
                return 0;
            case 9:
                return 4;
            case 10:
                return 1;
            case 11:
                return 5;
            case 12:
                return 3;
            case 13:
                return 2;
            default:
                return 6;
        }
    }

    public static mFont2 GetFont(int color)
    {
        mFont2 result = mFont2.tahoma_7;
        switch (color)
        {
            case -1:
                result = mFont2.tahoma_7;
                break;
            case 0:
                result = mFont2.tahoma_7b_dark;
                break;
            case 1:
                result = mFont2.tahoma_7b_green;
                break;
            case 2:
                result = mFont2.tahoma_7b_blue;
                break;
            case 3:
                result = mFont2.tahoma_7_red;
                break;
            case 4:
                result = mFont2.tahoma_7_green;
                break;
            case 5:
                result = mFont2.tahoma_7_blue;
                break;
            case 7:
                result = mFont2.tahoma_7b_red;
                break;
            case 8:
                result = mFont2.tahoma_7b_yellow;
                break;
        }
        return result;
    }

    public void paintOptItem(mGraphics2 g, int idOpt, int param, int x, int y, int w, int h)
    {
        switch (idOpt)
        {
            case 34:
                if (imgo_0 != null)
                {
                    g.drawImage(imgo_0, x, y + h - imgo_0.getHeight());
                }
                else
                {
                    imgo_0 = mSystem2.loadImage("/mainImage/o_0.png");
                }
                if (imgo_1 != null)
                {
                    g.drawImage(imgo_1, x, y + h - imgo_1.getHeight());
                }
                else
                {
                    imgo_1 = mSystem2.loadImage("/mainImage/o_1.png");
                }
                break;
            case 35:
                if (imgo_0 != null)
                {
                    g.drawImage(imgo_0, x, y + h - imgo_0.getHeight());
                }
                else
                {
                    imgo_0 = mSystem2.loadImage("/mainImage/o_0.png");
                }
                if (imgo_2 != null)
                {
                    g.drawImage(imgo_2, x, y + h - imgo_2.getHeight());
                }
                else
                {
                    imgo_2 = mSystem2.loadImage("/mainImage/o_2.png");
                }
                break;
            case 36:
                if (imgo_0 != null)
                {
                    g.drawImage(imgo_0, x, y + h - imgo_0.getHeight());
                }
                else
                {
                    imgo_0 = mSystem2.loadImage("/mainImage/o_0.png");
                }
                if (imgo_3 != null)
                {
                    g.drawImage(imgo_3, x, y + h - imgo_3.getHeight());
                }
                else
                {
                    imgo_3 = mSystem2.loadImage("/mainImage/o_3.png");
                }
                break;
        }
    }

    public void paintOptSlotItem(mGraphics2 g, int idOpt, int param, int x, int y, int w, int h)
    {
        if (idOpt == 102 && param > ChatPopup2.numSlot)
        {
            sbyte color_Item_Upgrade = GetColor_Item_Upgrade(param);
            int nline = param - ChatPopup2.numSlot;
            paintUpgradeEffect(x, y, w, h, nline, color_Item_Upgrade, g);
        }
    }

    public static mFont2 setTextColor(int id, int type)
    {
        if (type == 0)
        {
            return id switch
            {
                0 => mFont2.bigNumber_While,
                1 => mFont2.bigNumber_green,
                3 => mFont2.bigNumber_orange,
                4 => mFont2.bigNumber_blue,
                5 => mFont2.bigNumber_yellow,
                6 => mFont2.bigNumber_red,
                _ => mFont2.bigNumber_While,
            };
        }
        return id switch
        {
            0 => mFont2.tahoma_7b_white,
            1 => mFont2.tahoma_7b_green,
            3 => mFont2.tahoma_7b_yellowSmall2,
            4 => mFont2.tahoma_7b_blue,
            5 => mFont2.tahoma_7b_yellow,
            6 => mFont2.tahoma_7b_red,
            7 => mFont2.tahoma_7b_dark,
            _ => mFont2.tahoma_7b_white,
        };
    }

    private bool GetInventorySelect_isbody(int select, int subSelect, Item2[] arrItem)
    {
        int num = select - 1 + subSelect * 20;
        return subSelect == 0 && num < arrItem.Length;
    }

    private int GetInventorySelect_body(int select, int subSelect)
    {
        return select - 1 + subSelect * 20;
    }

    private int GetInventorySelect_bag(int select, int subSelect, Item2[] arrItem)
    {
        int num = select - 1 + subSelect * 20;
        return num - arrItem.Length;
    }

    private bool isTabInven()
    {
        if ((type == 0 && currentTabIndex == 1) || (type == 7 && currentTabIndex == 0))
        {
            return true;
        }
        return false;
    }

    private void updateKeyInvenTab()
    {
        if (selected < 0)
        {
            return;
        }
        if (GameCanvas2.keyPressed[(!Main2.isPC) ? 4 : 23])
        {
            newSelected--;
            if (isnewInventory)
            {
                currentListLength = 5;
            }
            if (newSelected < 0)
            {
                newSelected = 0;
                if (GameCanvas2.isFocusPanel2)
                {
                    GameCanvas2.isFocusPanel2 = false;
                    GameCanvas2.panel.selected = 0;
                }
            }
        }
        else
        {
            if (!GameCanvas2.keyPressed[(!Main2.isPC) ? 6 : 24])
            {
                return;
            }
            newSelected++;
            if (isnewInventory)
            {
                currentListLength = 5;
            }
            if (newSelected > size_tab - 1)
            {
                newSelected = size_tab - 1;
                if (GameCanvas2.panel2 != null)
                {
                    GameCanvas2.isFocusPanel2 = true;
                    GameCanvas2.panel2.selected = 0;
                }
            }
        }
    }

    private void updateKeyInventory()
    {
        updateKeyScrollView();
        if (selected == 0)
        {
            updateKeyInvenTab();
        }
    }

    private bool IsTabOption()
    {
        if (size_tab > 0)
        {
            if (currentTabName.Length > 1)
            {
                if (selected == 0)
                {
                    return true;
                }
            }
            else if (selected >= 0)
            {
                return true;
            }
        }
        return false;
    }

    private int checkCurrentListLength(int arrLength)
    {
        int num = 20;
        int num2 = arrLength / 20 + ((arrLength % 20 > 0) ? 1 : 0);
        size_tab = (sbyte)num2;
        if (newSelected > num2 - 1)
        {
            newSelected = num2 - 1;
        }
        if (arrLength % 20 > 0 && newSelected == num2 - 1)
        {
            num = arrLength % 20;
        }
        return num + 1;
    }

    private void setNewSelected(int arrLength, bool resetSelect)
    {
        int num = arrLength / 20 + ((arrLength % 20 > 0) ? 1 : 0);
        int num2 = xScroll;
        newSelected = (GameCanvas2.px - num2) / TAB_W_NEW;
        if (newSelected > num - 1)
        {
            newSelected = num - 1;
        }
        if (GameCanvas2.px < num2)
        {
            newSelected = 0;
        }
        if (type != 2)
        {
            setTabInventory(resetSelect);
        }
    }
}
