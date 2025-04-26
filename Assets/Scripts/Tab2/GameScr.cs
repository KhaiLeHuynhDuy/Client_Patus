using System;
using System.Threading;
using Mod;
using Mod2.XMAP;

public class GameScr2 : mScreen2, IChatable2
{
    public bool isWaitingDoubleClick;

    public long timeStartDblClick;

    public long timeEndDblClick;

    public static bool isPaintOther = false;

    public static MyVector2 textTime = new MyVector2(string.Empty);

    public static bool isLoadAllData = false;

    public static GameScr2 instance;

    public static int gW;

    public static int gH;

    public static int gW2;

    public static int gssw;

    public static int gssh;

    public static int gH34;

    public static int gW3;

    public static int gH3;

    public static int gH23;

    public static int gW23;

    public static int gH2;

    public static int csPadMaxH;

    public static int cmdBarH;

    public static int gW34;

    public static int gW6;

    public static int gH6;

    public static int cmx;

    public static int cmy;

    public static int cmdx;

    public static int cmdy;

    public static int cmvx;

    public static int cmvy;

    public static int cmtoX;

    public static int cmtoY;

    public static int cmxLim;

    public static int cmyLim;

    public static int gssx;

    public static int gssy;

    public static int gssxe;

    public static int gssye;

    public Command2 cmdback;

    public Command2 cmdBag;

    public Command2 cmdSkill;

    public Command2 cmdTiemnang;

    public Command2 cmdtrangbi;

    public Command2 cmdInfo;

    public Command2 cmdFocus;

    public Command2 cmdFire;

    public static int d;

    public static int hpPotion;

    public static SkillPaint2[] sks;

    public static Arrowpaint2[] arrs;

    public static DartInfo2[] darts;

    public static Part2[] parts;

    public static EffectCharPaint2[] efs;

    public static int lockTick;

    private int moveUp;

    private int moveDow;

    private int idTypeTask;

    private bool isstarOpen;

    private bool isChangeSkill;

    public static MyVector2 vClan = new MyVector2();

    public static MyVector2 vPtMap = new MyVector2();

    public static MyVector2 vFriend = new MyVector2();

    public static MyVector2 vEnemies = new MyVector2();

    public static MyVector2 vCharInMap = new MyVector2();

    public static MyVector2 vItemMap = new MyVector2();

    public static MyVector2 vMobAttack = new MyVector2();

    public static MyVector2 vSet = new MyVector2();

    public static MyVector2 vMob = new MyVector2();

    public static MyVector2 vNpc = new MyVector2();

    public static MyVector2 vFlag = new MyVector2();

    public static NClass2[] nClasss;

    public static int indexSize = 28;

    public static int indexTitle = 0;

    public static int indexSelect = 0;

    public static int indexRow = -1;

    public static int indexRowMax;

    public static int indexMenu = 0;

    public Item2 itemFocus;

    public ItemOptionTemplate2[] iOptionTemplates;

    public SkillOptionTemplate2[] sOptionTemplates;

    private static Scroll2 scrInfo = new Scroll2();

    public static Scroll2 scrMain = new Scroll2();

    public static MyVector2 vItemUpGrade = new MyVector2();

    public static bool isTypeXu;

    public static bool isViewNext;

    public static bool isViewClanMemOnline = false;

    public static bool isViewClanInvite = true;

    public static bool isChop;

    public static string titleInputText = string.Empty;

    public static int tickMove;

    public static bool isPaintAlert = false;

    public static bool isPaintTask = false;

    public static bool isPaintTeam = false;

    public static bool isPaintFindTeam = false;

    public static bool isPaintFriend = false;

    public static bool isPaintEnemies = false;

    public static bool isPaintItemInfo = false;

    public static bool isHaveSelectSkill = false;

    public static bool isPaintSkill = false;

    public static bool isPaintInfoMe = false;

    public static bool isPaintStore = false;

    public static bool isPaintNonNam = false;

    public static bool isPaintNonNu = false;

    public static bool isPaintAoNam = false;

    public static bool isPaintAoNu = false;

    public static bool isPaintGangTayNam = false;

    public static bool isPaintGangTayNu = false;

    public static bool isPaintQuanNam = false;

    public static bool isPaintQuanNu = false;

    public static bool isPaintGiayNam = false;

    public static bool isPaintGiayNu = false;

    public static bool isPaintLien = false;

    public static bool isPaintNhan = false;

    public static bool isPaintNgocBoi = false;

    public static bool isPaintPhu = false;

    public static bool isPaintWeapon = false;

    public static bool isPaintStack = false;

    public static bool isPaintStackLock = false;

    public static bool isPaintGrocery = false;

    public static bool isPaintGroceryLock = false;

    public static bool isPaintUpGrade = false;

    public static bool isPaintConvert = false;

    public static bool isPaintUpGradeGold = false;

    public static bool isPaintUpPearl = false;

    public static bool isPaintBox = false;

    public static bool isPaintSplit = false;

    public static bool isPaintCharInMap = false;

    public static bool isPaintTrade = false;

    public static bool isPaintZone = false;

    public static bool isPaintMessage = false;

    public static bool isPaintClan = false;

    public static bool isRequestMember = false;

    public static Char2 currentCharViewInfo;

    public static long[] exps;

    public static int[] crystals;

    public static int[] upClothe;

    public static int[] upAdorn;

    public static int[] upWeapon;

    public static int[] coinUpCrystals;

    public static int[] coinUpClothes;

    public static int[] coinUpAdorns;

    public static int[] coinUpWeapons;

    public static int[] maxPercents;

    public static int[] goldUps;

    public int tMenuDelay;

    public int zoneCol = 6;

    public int[] zones;

    public int[] pts;

    public int[] numPlayer;

    public int[] maxPlayer;

    public int[] rank1;

    public int[] rank2;

    public string[] rankName1;

    public string[] rankName2;

    public int typeTrade;

    public int typeTradeOrder;

    public int coinTrade;

    public int coinTradeOrder;

    public int timeTrade;

    public int indexItemUse = -1;

    public int cLastFocusID = -1;

    public int cPreFocusID = -1;

    public bool isLockKey;

    public static int[] tasks;

    public static int[] mapTasks;

    public static Image2 imgRoomStat;

    public static Image2 frBarPow0;

    public static Image2 frBarPow1;

    public static Image2 frBarPow2;

    public static Image2 frBarPow20;

    public static Image2 frBarPow21;

    public static Image2 frBarPow22;

    public MyVector2 texts;

    public string textsTitle;

    public static sbyte vcData;

    public static sbyte vcMap;

    public static sbyte vcSkill;

    public static sbyte vcItem;

    public static sbyte vsData;

    public static sbyte vsMap;

    public static sbyte vsSkill;

    public static sbyte vsItem;

    public static sbyte vcTask;

    public static Image2 imgArrow;

    public static Image2 imgArrow2;

    public static Image2 imgChat;

    public static Image2 imgChat2;

    public static Image2 imgMenu;

    public static Image2 imgFocus;

    public static Image2 imgFocus2;

    public static Image2 imgSkill;

    public static Image2 imgSkill2;

    public static Image2 imgHP1;

    public static Image2 imgHP2;

    public static Image2 imgHP3;

    public static Image2 imgHP4;

    public static Image2 imgFire0;

    public static Image2 imgFire1;

    public static Image2 imgModFunc;

    public static Image2 imgLbtn;

    public static Image2 imgLbtnFocus;

    public static Image2 imgLbtn2;

    public static Image2 imgLbtnFocus2;

    public static Image2 imgAnalog1;

    public static Image2 imgAnalog2;

    public string tradeName = string.Empty;

    public string tradeItemName = string.Empty;

    public int timeLengthMap;

    public int timeStartMap;

    public static sbyte typeViewInfo = 0;

    public static sbyte typeActive = 0;

    public static InfoMe2 info1 = new InfoMe2();

    public static InfoMe2 info2 = new InfoMe2();

    public static Image2 imgPanel;

    public static Image2 imgPanel2;

    public static Image2 imgHP;

    public static Image2 imgMP;

    public static Image2 imgSP;

    public static Image2 imgHPLost;

    public static Image2 imgMPLost;

    public static Image2 imgHP_tm_do;

    public static Image2 imgHP_tm_vang;

    public static Image2 imgHP_tm_xam;

    public static Image2 imgHP_tm_xanh;

    public Mob2 mobCapcha;

    public MagicTree2 magicTree;

    private short l;

    public static int countEff;

    public static GamePad2 gamePad = new GamePad2();

    public static int isAnalog = 0;

    public static bool isUseTouch;

    public const int numSkill = 10;

    public const int numSkill_2 = 5;

    public static Skill2[] keySkill = new Skill2[10];

    public static Skill2[] onScreenSkill = new Skill2[10];

    public Command2 cmdMenu;

    public static int firstY;

    public static int wSkill;

    public static long deltaTime;

    public bool isPointerDowning;

    public bool isChangingCameraMode;

    private int ptLastDownX;

    private int ptLastDownY;

    private int ptFirstDownX;

    private int ptFirstDownY;

    private int ptDownTime;

    private bool disableSingleClick;

    public long lastSingleClick;

    public bool clickMoving;

    public bool clickOnTileTop;

    public bool clickMovingRed;

    public int clickToX;

    public int clickToY;

    private int lastClickCMX;

    private int lastClickCMY;

    public int clickMovingP1;

    public int clickMovingTimeOut;

    private long lastMove;

    public static bool isNewClanMessage;

    private long lastFire;

    private long lastUsePotion;

    public int auto;

    public int dem;

    private string strTam = string.Empty;

    private int a;

    public bool isFreez;

    public bool isUseFreez;

    public static Image2 imgTrans;

    public bool isRongThanXuatHien;

    public bool isRongNamek;

    public bool isSuperPower;

    public int tPower;

    public int xPower;

    public int yPower;

    public int dxPower;

    public bool activeRongThan;

    public bool isMeCallRongThan;

    public int mautroi;

    public int mapRID;

    public int zoneRID;

    public int bgRID = -1;

    public static int tam = 0;

    public static bool isAutoPlay;

    public static bool canAutoPlay;

    public static bool isChangeZone;

    private int timeSkill;

    private int nSkill;

    private int selectedIndexSkill = -1;

    private Skill2 lastSkill;

    private bool doSeleckSkillFlag;

    public string strCapcha;

    private long longPress;

    private int move;

    public bool flareFindFocus;

    private int flareTime;

    public int keyTouchSkill = -1;

    private long lastSendUpdatePostion;

    public static long lastTick;

    public static long currTick;

    private int timeAuto;

    public static long lastXS;

    public static long currXS;

    public static int secondXS;

    public int runArrow;

    public static int isPaintRada;

    public static Image2 imgNut;

    public static Image2 imgNutF;

    public int[] keyCapcha;

    public static Image2 imgCapcha;

    public string keyInput;

    public static int disXC;

    public static bool isPaint = true;

    public static int shock_scr;

    private static int[] shock_x = new int[4] { 1, -1, 1, -1 };

    private static int[] shock_y = new int[4] { 1, -1, -1, 1 };

    private int tDoubleDelay;

    public static Image2 arrow;

    private static int yTouchBar;

    private static int xC;

    private static int yC;

    private static int xL;

    private static int yL;

    public int xR;

    public int yR;

    private static int xU;

    private static int yU;

    private static int xF;

    private static int yF;

    public static int xHP;

    public static int yHP;

    private static int xTG;

    private static int yTG;

    public static int[] xS;

    public static int[] yS;

    public static int xSkill;

    public static int ySkill;

    public static int padSkill;

    public long dMP;

    public int twMp;

    public bool isInjureMp;

    public long dHP;

    public int twHp;

    public bool isInjureHp;

    private long curr;

    private long last;

    private int secondVS;

    private int[] idVS = new int[2] { -1, -1 };

    public static string[] flyTextString;

    public static int[] flyTextX;

    public static int[] flyTextY;

    public static int[] flyTextYTo;

    public static int[] flyTextDx;

    public static int[] flyTextDy;

    public static int[] flyTextState;

    public static int[] flyTextColor;

    public static int[] flyTime;

    public static int[] splashX;

    public static int[] splashY;

    public static int[] splashState;

    public static int[] splashF;

    public static int[] splashDir;

    public static Image2[] imgSplash;

    public static int cmdBarX;

    public static int cmdBarY;

    public static int cmdBarW;

    public static int cmdBarLeftW;

    public static int cmdBarRightW;

    public static int cmdBarCenterW;

    public static int hpBarX;

    public static int hpBarY;

    public static int spBarW;

    public static int mpBarW;

    public static int expBarW;

    public static int lvPosX;

    public static int moneyPosX;

    public static int hpBarH;

    public static int girlHPBarY;

    public static long hpBarW;

    public static Image2[] imgCmdBar;

    private int imgScrW;

    public static int popupY;

    public static int popupX;

    public static int isborderIndex;

    public static int isselectedRow;

    private static Image2 imgNolearn;

    public int cmxp;

    public int cmvxp;

    public int cmdxp;

    public int cmxLimp;

    public int cmyLimp;

    public int cmyp;

    public int cmvyp;

    public int cmdyp;

    private int indexTiemNang;

    private string alertURL;

    private string fnick;

    public static int xstart;

    public static int ystart;

    public static int popupW = 140;

    public static int popupH = 160;

    public static int cmySK;

    public static int cmtoYSK;

    public static int cmdySK;

    public static int cmvySK;

    public static int cmyLimSK;

    public static int columns = 6;

    public static int rows;

    private int totalRowInfo;

    private int ypaintKill;

    private int ylimUp;

    private int ylimDow;

    private int yPaint;

    public static int indexEff = 0;

    public static EffectCharPaint2 effUpok;

    public static int inforX;

    public static int inforY;

    public static int inforW;

    public static int inforH;

    public Command2 cmdDead;

    public static bool notPaint = false;

    public static bool isPing = false;

    public static int INFO = 0;

    public static int STORE = 1;

    public static int ZONE = 2;

    public static int UPGRADE = 3;

    private int isTranKyNang;

    private bool isTran;

    private int cmY_Old;

    private int cmX_Old;

    public PopUpYesNo2 popUpYesNo;

    public static MyVector2 vChatVip = new MyVector2();

    public static int vBig;

    public bool isFireWorks;

    public int[] winnumber;

    public int[] randomNumber;

    public int[] tMove;

    public int[] moveCount;

    public int[] delayMove;

    public int moveIndex;

    private bool isWin;

    private string strFinish;

    private int tShow;

    private int xChatVip;

    private int currChatWidth;

    private bool startChat;

    public sbyte percentMabu;

    public bool mabuEff;

    public int tMabuEff;

    public static bool isPaintChatVip;

    public static sbyte mabuPercent;

    public static sbyte isNewMember;

    private string yourNumber = string.Empty;

    private string[] strPaint;

    public static Image2 imgHP_NEW;

    public static InfoPhuBan2 phuban_Info;

    public static FrameImage2 fra_PVE_Bar_0;

    public static FrameImage2 fra_PVE_Bar_1;

    public static Image2 imgVS;

    public static Image2 imgBall;

    public static Image2 imgKhung;

    public int countFrameSkill;

    public static Image2 imgBgIOS;

    public GameScr2()
    {
        if (GameCanvas2.w == 128 || GameCanvas2.h <= 208)
        {
            indexSize = 20;
        }
        cmdback = new Command2(string.Empty, 11021);
        cmdMenu = new Command2("menu", 11000);
        cmdFocus = new Command2(string.Empty, 11001);
        cmdMenu.img = imgMenu;
        cmdMenu.w = mGraphics2.getImageWidth(cmdMenu.img) + 20;
        cmdMenu.isPlaySoundButton = false;
        cmdFocus.img = imgFocus;
        if (GameCanvas2.isTouch)
        {
            cmdMenu.x = 0;
            cmdMenu.y = 50;
            cmdFocus = null;
        }
        else
        {
            cmdMenu.x = 0;
            cmdMenu.y = gH - 30;
            cmdFocus.x = gW - 32;
            cmdFocus.y = gH - 32;
        }
        right = cmdFocus;
        isPaintRada = 1;
        if (GameCanvas2.isTouch)
        {
            isHaveSelectSkill = true;
        }
    }

    public static void loadBg()
    {
        fra_PVE_Bar_0 = new FrameImage2(mSystem2.loadImage("/mainImage/i_pve_bar_0.png"), 6, 15);
        fra_PVE_Bar_1 = new FrameImage2(mSystem2.loadImage("/mainImage/i_pve_bar_1.png"), 38, 21);
        imgVS = mSystem2.loadImage("/mainImage/i_vs.png");
        imgBall = mSystem2.loadImage("/mainImage/i_charlife.png");
        imgHP_NEW = mSystem2.loadImage("/mainImage/i_hp.png");
        imgKhung = mSystem2.loadImage("/mainImage/i_khung.png");
        imgLbtn = GameCanvas2.loadImage("/mainImage/myTexture2dbtnl.png");
        imgLbtnFocus = GameCanvas2.loadImage("/mainImage/myTexture2dbtnlf.png");
        imgLbtn2 = GameCanvas2.loadImage("/mainImage/myTexture2dbtnl2.png");
        imgLbtnFocus2 = GameCanvas2.loadImage("/mainImage/myTexture2dbtnlf2.png");
        imgPanel = GameCanvas2.loadImage("/mainImage/myTexture2dpanel.png");
        imgPanel2 = GameCanvas2.loadImage("/mainImage/panel2.png");
        imgHP = GameCanvas2.loadImage("/mainImage/myTexture2dHP.png");
        imgSP = GameCanvas2.loadImage("/mainImage/SP.png");
        imgHPLost = GameCanvas2.loadImage("/mainImage/myTexture2dhpLost.png");
        imgMPLost = GameCanvas2.loadImage("/mainImage/myTexture2dmpLost.png");
        imgMP = GameCanvas2.loadImage("/mainImage/myTexture2dMP.png");
        imgSkill = GameCanvas2.loadImage("/mainImage/myTexture2dskill.png");
        imgSkill2 = GameCanvas2.loadImage("/mainImage/myTexture2dskill2.png");
        imgMenu = GameCanvas2.loadImage("/mainImage/myTexture2dmenu.png");
        imgFocus = GameCanvas2.loadImage("/mainImage/myTexture2dfocus.png");
        imgHP_tm_do = GameCanvas2.loadImage("/mainImage/tm-do.png");
        imgHP_tm_vang = GameCanvas2.loadImage("/mainImage/tm-vang.png");
        imgHP_tm_xam = GameCanvas2.loadImage("/mainImage/tm-xam.png");
        imgHP_tm_xanh = GameCanvas2.loadImage("/mainImage/tm-xanh.png");
        if (GameCanvas2.isTouch)
        {
            imgArrow = GameCanvas2.loadImage("/mainImage/myTexture2darrow.png");
            imgArrow2 = GameCanvas2.loadImage("/mainImage/myTexture2darrow2.png");
            imgChat = GameCanvas2.loadImage("/mainImage/myTexture2dchat.png");
            imgChat2 = GameCanvas2.loadImage("/mainImage/myTexture2dchat2.png");
            imgFocus2 = GameCanvas2.loadImage("/mainImage/myTexture2dfocus2.png");
            imgHP1 = GameCanvas2.loadImage("/mainImage/myTexture2dPea0.png");
            imgHP2 = GameCanvas2.loadImage("/mainImage/myTexture2dPea1.png");
            imgAnalog1 = GameCanvas2.loadImage("/mainImage/myTexture2danalog1.png");
            imgAnalog2 = GameCanvas2.loadImage("/mainImage/myTexture2danalog2.png");
            imgHP3 = GameCanvas2.loadImage("/mainImage/myTexture2dPea2.png");
            imgHP4 = GameCanvas2.loadImage("/mainImage/myTexture2dPea3.png");
            imgFire0 = GameCanvas2.loadImage("/mainImage/myTexture2dfirebtn0.png");
            imgFire1 = GameCanvas2.loadImage("/mainImage/myTexture2dfirebtn1.png");
            imgModFunc = GameCanvas2.loadImage("/mainImage/imgModFuc.png");
        }
        flyTextX = new int[5];
        flyTextY = new int[5];
        flyTextDx = new int[5];
        flyTextDy = new int[5];
        flyTextState = new int[5];
        flyTextString = new string[5];
        flyTextYTo = new int[5];
        flyTime = new int[5];
        flyTextColor = new int[8];
        for (int i = 0; i < 5; i++)
        {
            flyTextState[i] = -1;
        }
        sbyte[] array = Rms2.loadRMS("NRdataVersion");
        sbyte[] array2 = Rms2.loadRMS("NRmapVersion");
        sbyte[] array3 = Rms2.loadRMS("NRskillVersion");
        sbyte[] array4 = Rms2.loadRMS("NRitemVersion");
        if (array != null)
        {
            vcData = array[0];
        }
        if (array2 != null)
        {
            vcMap = array2[0];
        }
        if (array3 != null)
        {
            vcSkill = array3[0];
        }
        if (array4 != null)
        {
            vcItem = array4[0];
        }
        imgNut = GameCanvas2.loadImage("/mainImage/myTexture2dnut.png");
        imgNutF = GameCanvas2.loadImage("/mainImage/myTexture2dnutF.png");
        MobCapcha2.init();
        isAnalog = ((Rms2.loadRMSInt("analog") == 0) ? 0 : Main2.isIPhone ? 1 : 0);
        gamePad = new GamePad2();
        arrow = GameCanvas2.loadImage("/mainImage/myTexture2darrow3.png");
        imgTrans = GameCanvas2.loadImage("/bg/trans.png");
        imgRoomStat = GameCanvas2.loadImage("/mainImage/myTexture2dstat.png");
        frBarPow0 = GameCanvas2.loadImage("/mainImage/myTexture2dlineColor00.png");
        frBarPow1 = GameCanvas2.loadImage("/mainImage/myTexture2dlineColor01.png");
        frBarPow2 = GameCanvas2.loadImage("/mainImage/myTexture2dlineColor02.png");
        frBarPow20 = GameCanvas2.loadImage("/mainImage/myTexture2dlineColor20.png");
        frBarPow21 = GameCanvas2.loadImage("/mainImage/myTexture2dlineColor21.png");
        frBarPow22 = GameCanvas2.loadImage("/mainImage/myTexture2dlineColor22.png");
    }

    public void initSelectChar()
    {
        readPart();
        SmallImage2.init();
    }

    public static void paintOngMauPercent(Image2 img0, Image2 img1, Image2 img2, float x, float y, int size, float pixelPercent, mGraphics2 g)
    {
        int clipX = g.getClipX();
        int clipY = g.getClipY();
        int clipWidth = g.getClipWidth();
        int clipHeight = g.getClipHeight();
        g.setClip((int)x, (int)y, (int)pixelPercent, 13);
        int num = size / 15 - 2;
        for (int i = 0; i < num; i++)
        {
            g.drawImage(img1, x + (float)((i + 1) * 15), y, 0);
        }
        g.drawImage(img0, x, y, 0);
        g.drawImage(img1, x + (float)size - 30f, y, 0);
        g.drawImage(img2, x + (float)size - 15f, y, 0);
        g.setClip(clipX, clipY, clipWidth, clipHeight);
    }

    public void initTraining()
    {
        if (CreateCharScr2.isCreateChar)
        {
            CreateCharScr2.isCreateChar = false;
            right = null;
        }
    }

    public bool isMapDocNhan()
    {
        if (TileMap2.mapID >= 53 && TileMap2.mapID <= 62)
        {
            return true;
        }
        return false;
    }

    public bool isMapFize()
    {
        if (TileMap2.mapID >= 63)
        {
            return true;
        }
        return false;
    }

    public override void switchToMe()
    {
        if (MainMod2.autoLogin != null)
        {
            MainMod2.autoLogin.waitToNextLogin = false;
        }
        vChatVip.removeAllElements();
        ServerListScreen2.isWait = false;
        if (BackgroudEffect2.isHaveRain())
        {
            SoundMn2.gI().rain();
        }
        LoginScr2.isContinueToLogin = false;
        Char2.isLoadingMap = false;
        if (!isPaintOther)
        {
            Service2.gI().finishLoadMap();
        }
        if (TileMap2.isTrainingMap())
        {
            initTraining();
        }
        info1.isUpdate = true;
        info2.isUpdate = true;
        resetButton();
        isLoadAllData = true;
        isPaintOther = false;
        base.switchToMe();
    }

    public static int getMaxExp(int level)
    {
        int num = 0;
        for (int i = 0; i <= level; i++)
        {
            num += (int)exps[i];
        }
        return num;
    }

    public static void resetAllvector()
    {
        vCharInMap.removeAllElements();
        Teleport2.vTeleport.removeAllElements();
        vItemMap.removeAllElements();
        Effect2_2.vEffect2.removeAllElements();
        Effect2_2.vAnimateEffect.removeAllElements();
        Effect2_2.vEffect2Outside.removeAllElements();
        Effect2_2.vEffectFeet.removeAllElements();
        Effect2_2.vEffect3.removeAllElements();
        vMobAttack.removeAllElements();
        vMob.removeAllElements();
        vNpc.removeAllElements();
        Char2.myCharz().vMovePoints.removeAllElements();
    }

    public void loadSkillShortcut()
    {
    }

    public void onOSkill(sbyte[] oSkillID)
    {
        Cout2.println("GET onScreenSkill!");
        onScreenSkill = new Skill2[10];
        if (oSkillID == null)
        {
            loadDefaultonScreenSkill();
            return;
        }
        for (int i = 0; i < oSkillID.Length; i++)
        {
            for (int j = 0; j < Char2.myCharz().vSkillFight.size(); j++)
            {
                Skill2 skill = (Skill2)Char2.myCharz().vSkillFight.elementAt(j);
                if (skill.template.id == oSkillID[i])
                {
                    onScreenSkill[i] = skill;
                    break;
                }
            }
        }
    }

    public void onKSkill(sbyte[] kSkillID)
    {
        Cout2.println("GET KEYSKILL!");
        keySkill = new Skill2[10];
        if (kSkillID == null)
        {
            loadDefaultKeySkill();
            return;
        }
        for (int i = 0; i < kSkillID.Length; i++)
        {
            for (int j = 0; j < Char2.myCharz().vSkillFight.size(); j++)
            {
                Skill2 skill = (Skill2)Char2.myCharz().vSkillFight.elementAt(j);
                if (skill.template.id == kSkillID[i])
                {
                    keySkill[i] = skill;
                    break;
                }
            }
        }
    }

    public void onCSkill(sbyte[] cSkillID)
    {
        Cout2.println("GET CURRENTSKILL!");
        if (cSkillID == null || cSkillID.Length == 0)
        {
            if (Char2.myCharz().vSkillFight.size() > 0)
            {
                Char2.myCharz().myskill = (Skill2)Char2.myCharz().vSkillFight.elementAt(0);
            }
        }
        else
        {
            for (int i = 0; i < Char2.myCharz().vSkillFight.size(); i++)
            {
                Skill2 skill = (Skill2)Char2.myCharz().vSkillFight.elementAt(i);
                if (skill.template.id == cSkillID[0])
                {
                    Char2.myCharz().myskill = skill;
                    break;
                }
            }
        }
        if (Char2.myCharz().myskill != null)
        {
            Service2.gI().selectSkill(Char2.myCharz().myskill.template.id);
            saveRMSCurrentSkill(Char2.myCharz().myskill.template.id);
        }
    }

    private void loadDefaultonScreenSkill()
    {
        Cout2.println("LOAD DEFAULT ONmScreen SKILL");
        for (int i = 0; i < onScreenSkill.Length && i < Char2.myCharz().vSkillFight.size(); i++)
        {
            Skill2 skill = (Skill2)Char2.myCharz().vSkillFight.elementAt(i);
            onScreenSkill[i] = skill;
        }
        saveonScreenSkillToRMS();
    }

    private void loadDefaultKeySkill()
    {
        Cout2.println("LOAD DEFAULT KEY SKILL");
        for (int i = 0; i < keySkill.Length && i < Char2.myCharz().vSkillFight.size(); i++)
        {
            Skill2 skill = (Skill2)Char2.myCharz().vSkillFight.elementAt(i);
            keySkill[i] = skill;
        }
        saveKeySkillToRMS();
    }

    public void doSetOnScreenSkill(SkillTemplate2 skillTemplate)
    {
        Skill2 skill = Char2.myCharz().getSkill(skillTemplate);
        MyVector2 myVector = new MyVector2();
        for (int i = 0; i < 10; i++)
        {
            Command2 command = new(p: new object[2]
            {
                skill,
                i + string.Empty
            }, caption: mResources2.into_place + (i + 1), action: 11120);
            Skill2 skill2 = onScreenSkill[i];
            if (skill2 != null)
            {
                command.isDisplay = true;
            }
            myVector.addElement(command);
        }
        GameCanvas2.menu.startAt(myVector, 0);
    }

    public void doSetKeySkill(SkillTemplate2 skillTemplate)
    {
        Skill2 skill = Char2.myCharz().getSkill(skillTemplate);
        string[] array = ((!TField2.isQwerty) ? mResources2.key_skill : mResources2.key_skill_qwerty);
        MyVector2 myVector = new();
        for (int i = 0; i < 10; i++)
        {
            myVector.addElement(new Command2(p: new object[2]
            {
                skill,
                i + string.Empty
            }, caption: array[i], action: 11121));
        }
        GameCanvas2.menu.startAt(myVector, 0);
    }

    public void saveonScreenSkillToRMS()
    {
        sbyte[] array = new sbyte[onScreenSkill.Length];
        for (int i = 0; i < onScreenSkill.Length; i++)
        {
            if (onScreenSkill[i] == null)
            {
                array[i] = -1;
            }
            else
            {
                array[i] = onScreenSkill[i].template.id;
            }
        }
        Service2.gI().changeOnKeyScr(array);
    }

    public void saveKeySkillToRMS()
    {
        sbyte[] array = new sbyte[keySkill.Length];
        for (int i = 0; i < keySkill.Length; i++)
        {
            if (keySkill[i] == null)
            {
                array[i] = -1;
            }
            else
            {
                array[i] = keySkill[i].template.id;
            }
        }
        Service2.gI().changeOnKeyScr(array);
    }

    public void saveRMSCurrentSkill(sbyte id)
    {
    }

    public void addSkillShortcut(Skill2 skill)
    {
        Cout2.println("ADD SKILL SHORTCUT TO SKILL " + skill.template.id);
        for (int i = 0; i < onScreenSkill.Length; i++)
        {
            if (onScreenSkill[i] == null)
            {
                onScreenSkill[i] = skill;
                break;
            }
        }
        for (int j = 0; j < keySkill.Length; j++)
        {
            if (keySkill[j] == null)
            {
                keySkill[j] = skill;
                break;
            }
        }
        if (Char2.myCharz().myskill == null)
        {
            Char2.myCharz().myskill = skill;
        }
        saveKeySkillToRMS();
        saveonScreenSkillToRMS();
    }

    public bool isBagFull()
    {
        for (int num = Char2.myCharz().arrItemBag.Length - 1; num >= 0; num--)
        {
            if (Char2.myCharz().arrItemBag[num] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void createConfirm(string[] menu, Npc2 npc)
    {
        resetButton();
        isLockKey = true;
        left = new Command2(menu[0], 130011, npc);
        right = new Command2(menu[1], 130012, npc);
    }

    public void createMenu(string[] menu, Npc2 npc)
    {
        MyVector2 myVector = new MyVector2();
        for (int i = 0; i < menu.Length; i++)
        {
            myVector.addElement(new Command2(menu[i], 11057, npc));
        }
        GameCanvas2.menu.startAt(myVector, 2);
    }

    public void readPart()
    {
        DataInputStream2 dataInputStream = null;
        try
        {
            dataInputStream = new DataInputStream2(Rms2.loadRMS("NR_part"));
            int partSize = dataInputStream.readShort();
            parts = new Part2[partSize];
            for (int i = 0; i < partSize; i++)
            {
                int type = dataInputStream.readByte();
                parts[i] = new Part2(type);
                for (int j = 0; j < parts[i].pi.Length; j++)
                {
                    parts[i].pi[j] = new PartImage2
                    {
                        id = dataInputStream.readShort(),
                        dx = dataInputStream.readByte(),
                        dy = dataInputStream.readByte()
                    };
                }
            }
        }
        catch (Exception ex)
        {
            Cout2.LogError("LOI TAI readPart " + ex.ToString());
        }
        finally
        {
            try
            {
                dataInputStream.close();
            }
            catch (Exception ex2)
            {
                Res2.outz2("LOI TAI readPart 2" + ex2.StackTrace);
            }
        }
    }

    public void readEfect()
    {
        DataInputStream2 dataInputStream = null;
        try
        {
            dataInputStream = new DataInputStream2(Rms2.loadRMS("NR_effect"));
            int num = dataInputStream.readShort();
            efs = new EffectCharPaint2[num];
            for (int i = 0; i < num; i++)
            {
                efs[i] = new EffectCharPaint2();
                efs[i].idEf = dataInputStream.readShort();
                efs[i].arrEfInfo = new EffectInfoPaint2[dataInputStream.readByte()];
                for (int j = 0; j < efs[i].arrEfInfo.Length; j++)
                {
                    efs[i].arrEfInfo[j] = new EffectInfoPaint2();
                    efs[i].arrEfInfo[j].idImg = dataInputStream.readShort();
                    efs[i].arrEfInfo[j].dx = dataInputStream.readByte();
                    efs[i].arrEfInfo[j].dy = dataInputStream.readByte();
                }
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            try
            {
                dataInputStream.close();
            }
            catch (Exception ex2)
            {
                Cout2.LogError("Loi ham Eff: " + ex2.ToString());
            }
        }
    }

    public void readArrow()
    {
        DataInputStream2 dataInputStream = null;
        try
        {
            dataInputStream = new DataInputStream2(Rms2.loadRMS("NR_arrow"));
            int num = dataInputStream.readShort();
            arrs = new Arrowpaint2[num];
            for (int i = 0; i < num; i++)
            {
                arrs[i] = new Arrowpaint2();
                arrs[i].id = dataInputStream.readShort();
                arrs[i].imgId[0] = dataInputStream.readShort();
                arrs[i].imgId[1] = dataInputStream.readShort();
                arrs[i].imgId[2] = dataInputStream.readShort();
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            try
            {
                dataInputStream.close();
            }
            catch (Exception ex2)
            {
                Cout2.LogError("Loi ham readArrow: " + ex2.ToString());
            }
        }
    }

    public void readDart()
    {
        DataInputStream2 dataInputStream = null;
        try
        {
            dataInputStream = new DataInputStream2(Rms2.loadRMS("NR_dart"));
            int num = dataInputStream.readShort();
            darts = new DartInfo2[num];
            for (int i = 0; i < num; i++)
            {
                darts[i] = new DartInfo2();
                darts[i].id = dataInputStream.readShort();
                darts[i].nUpdate = dataInputStream.readShort();
                darts[i].va = dataInputStream.readShort() * 256;
                darts[i].xdPercent = dataInputStream.readShort();
                int num2 = dataInputStream.readShort();
                darts[i].tail = new short[num2];
                for (int j = 0; j < num2; j++)
                {
                    darts[i].tail[j] = dataInputStream.readShort();
                }
                num2 = dataInputStream.readShort();
                darts[i].tailBorder = new short[num2];
                for (int k = 0; k < num2; k++)
                {
                    darts[i].tailBorder[k] = dataInputStream.readShort();
                }
                num2 = dataInputStream.readShort();
                darts[i].xd1 = new short[num2];
                for (int l = 0; l < num2; l++)
                {
                    darts[i].xd1[l] = dataInputStream.readShort();
                }
                num2 = dataInputStream.readShort();
                darts[i].xd2 = new short[num2];
                for (int m = 0; m < num2; m++)
                {
                    darts[i].xd2[m] = dataInputStream.readShort();
                }
                num2 = dataInputStream.readShort();
                darts[i].head = new short[num2][];
                for (int n = 0; n < num2; n++)
                {
                    short num3 = dataInputStream.readShort();
                    darts[i].head[n] = new short[num3];
                    for (int num4 = 0; num4 < num3; num4++)
                    {
                        darts[i].head[n][num4] = dataInputStream.readShort();
                    }
                }
                num2 = dataInputStream.readShort();
                darts[i].headBorder = new short[num2][];
                for (int num5 = 0; num5 < num2; num5++)
                {
                    short num6 = dataInputStream.readShort();
                    darts[i].headBorder[num5] = new short[num6];
                    for (int num7 = 0; num7 < num6; num7++)
                    {
                        darts[i].headBorder[num5][num7] = dataInputStream.readShort();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Cout2.LogError("Loi ham ReadDart: " + ex.ToString());
        }
        finally
        {
            try
            {
                dataInputStream.close();
            }
            catch (Exception ex2)
            {
                Cout2.LogError("Loi ham reaaDart: " + ex2.ToString());
            }
        }
    }

    public void readSkill()
    {
        DataInputStream2 dataInputStream = null;
        try
        {
            dataInputStream = new DataInputStream2(Rms2.loadRMS("NR_skill"));
            int dataSkillSz = dataInputStream.readShort();
            int skillSz = Skills2.skills.size();

            sks = new SkillPaint2[skillSz];
            for (int i = 0; i < dataSkillSz; i++)
            {
                short levelId = dataInputStream.readShort();
                if (levelId == 1111)
                {
                    levelId = (short)(dataSkillSz - 1);
                }
                sks[levelId] = new SkillPaint2
                {
                    id = levelId,
                    effectHappenOnMob = dataInputStream.readShort()
                };
                if (sks[levelId].effectHappenOnMob <= 0)
                {
                    sks[levelId].effectHappenOnMob = 80;
                }
                sks[levelId].numEff = dataInputStream.readByte();
                sks[levelId].skillStand = new SkillInfoPaint2[dataInputStream.readByte()];
                for (int j = 0; j < sks[levelId].skillStand.Length; j++)
                {
                    sks[levelId].skillStand[j] = new SkillInfoPaint2
                    {
                        status = dataInputStream.readByte(),
                        effS0Id = dataInputStream.readShort(),
                        e0dx = dataInputStream.readShort(),
                        e0dy = dataInputStream.readShort(),
                        effS1Id = dataInputStream.readShort(),
                        e1dx = dataInputStream.readShort(),
                        e1dy = dataInputStream.readShort(),
                        effS2Id = dataInputStream.readShort(),
                        e2dx = dataInputStream.readShort(),
                        e2dy = dataInputStream.readShort(),
                        arrowId = dataInputStream.readShort(),
                        adx = dataInputStream.readShort(),
                        ady = dataInputStream.readShort()
                    };
                }
                sks[levelId].skillfly = new SkillInfoPaint2[dataInputStream.readByte()];
                for (int k = 0; k < sks[levelId].skillfly.Length; k++)
                {
                    sks[levelId].skillfly[k] = new SkillInfoPaint2
                    {
                        status = dataInputStream.readByte(),
                        effS0Id = dataInputStream.readShort(),
                        e0dx = dataInputStream.readShort(),
                        e0dy = dataInputStream.readShort(),
                        effS1Id = dataInputStream.readShort(),
                        e1dx = dataInputStream.readShort(),
                        e1dy = dataInputStream.readShort(),
                        effS2Id = dataInputStream.readShort(),
                        e2dx = dataInputStream.readShort(),
                        e2dy = dataInputStream.readShort(),
                        arrowId = dataInputStream.readShort(),
                        adx = dataInputStream.readShort(),
                        ady = dataInputStream.readShort()
                    };
                }
            }
        }
        catch (Exception ex)
        {
            MainMod2.Log("Loi ham readSkill: " + ex.ToString());
        }
        finally
        {
            try
            {
                dataInputStream.close();
            }
            catch (Exception ex2)
            {
                MainMod2.Log("Loi ham readskill 1: " + ex2.ToString());
            }
        }
    }

    public static GameScr2 gI()
    {
        if (instance == null)
        {
            instance = new GameScr2();
        }
        return instance;
    }

    public static void clearGameScr()
    {
        instance = null;
    }

    public void loadGameScr()
    {
        loadSplash();
        Res2.init();
        loadInforBar();
    }

    public void doMenuInforMe()
    {
        scrMain.clear();
        scrInfo.clear();
        isViewNext = false;
        cmdBag = new Command2(mResources2.MENUME[0], 1100011);
        cmdSkill = new Command2(mResources2.MENUME[1], 1100012);
        cmdTiemnang = new Command2(mResources2.MENUME[2], 1100013);
        cmdInfo = new Command2(mResources2.MENUME[3], 1100014);
        cmdtrangbi = new Command2(mResources2.MENUME[4], 1100015);
        MyVector2 myVector = new MyVector2();
        myVector.addElement(cmdBag);
        myVector.addElement(cmdSkill);
        myVector.addElement(cmdTiemnang);
        myVector.addElement(cmdInfo);
        myVector.addElement(cmdtrangbi);
        GameCanvas2.menu.startAt(myVector, 3);
    }

    public void doMenusynthesis()
    {
        MyVector2 myVector = new MyVector2();
        myVector.addElement(new Command2(mResources2.SYNTHESIS[0], 110002));
        myVector.addElement(new Command2(mResources2.SYNTHESIS[1], 1100032));
        myVector.addElement(new Command2(mResources2.SYNTHESIS[2], 1100033));
        GameCanvas2.menu.startAt(myVector, 3);
    }

    public static void loadCamera(bool fullmScreen, int cx, int cy)
    {
        gW = GameCanvas2.w;
        cmdBarH = 39;
        gH = GameCanvas2.h;
        cmdBarW = gW;
        cmdBarX = 0;
        cmdBarY = GameCanvas2.h - Paint2.hTab - cmdBarH;
        girlHPBarY = 0;
        csPadMaxH = GameCanvas2.h / 6;
        if (csPadMaxH < 48)
        {
            csPadMaxH = 48;
        }
        gW2 = gW >> 1;
        gH2 = gH >> 1;
        gW3 = gW / 3;
        gH3 = gH / 3;
        gW23 = gH - 120;
        gH23 = gH * 2 / 3;
        gW34 = 3 * gW / 4;
        gH34 = 3 * gH / 4;
        gW6 = gW / 6;
        gH6 = gH / 6;
        gssw = gW / TileMap2.size + 2;
        gssh = gH / TileMap2.size + 2;
        if (gW % 24 != 0)
        {
            gssw++;
        }
        cmxLim = (TileMap2.tmw - 1) * TileMap2.size - gW;
        cmyLim = (TileMap2.tmh - 1) * TileMap2.size - gH;
        if (cx == -1 && cy == -1)
        {
            cmx = (cmtoX = Char2.myCharz().cx - gW2 + gW6 * Char2.myCharz().cdir);
            cmy = (cmtoY = Char2.myCharz().cy - gH23);
        }
        else
        {
            cmx = (cmtoX = cx - gW23 + gW6 * Char2.myCharz().cdir);
            cmy = (cmtoY = cy - gH23);
        }
        firstY = cmy;
        if (cmx < 24)
        {
            cmx = (cmtoX = 24);
        }
        if (cmx > cmxLim)
        {
            cmx = (cmtoX = cmxLim);
        }
        if (cmy < 0)
        {
            cmy = (cmtoY = 0);
        }
        if (cmy > cmyLim)
        {
            cmy = (cmtoY = cmyLim);
        }
        gssx = cmx / TileMap2.size - 1;
        if (gssx < 0)
        {
            gssx = 0;
        }
        gssy = cmy / TileMap2.size;
        gssxe = gssx + gssw;
        gssye = gssy + gssh;
        if (gssy < 0)
        {
            gssy = 0;
        }
        if (gssye > TileMap2.tmh - 1)
        {
            gssye = TileMap2.tmh - 1;
        }
        TileMap2.countx = (gssxe - gssx) * 4;
        if (TileMap2.countx > TileMap2.tmw)
        {
            TileMap2.countx = TileMap2.tmw;
        }
        TileMap2.county = (gssye - gssy) * 4;
        if (TileMap2.county > TileMap2.tmh)
        {
            TileMap2.county = TileMap2.tmh;
        }
        TileMap2.gssx = (Char2.myCharz().cx - 2 * gW) / TileMap2.size;
        if (TileMap2.gssx < 0)
        {
            TileMap2.gssx = 0;
        }
        TileMap2.gssxe = TileMap2.gssx + TileMap2.countx;
        if (TileMap2.gssxe > TileMap2.tmw)
        {
            TileMap2.gssxe = TileMap2.tmw;
        }
        TileMap2.gssy = (Char2.myCharz().cy - 2 * gH) / TileMap2.size;
        if (TileMap2.gssy < 0)
        {
            TileMap2.gssy = 0;
        }
        TileMap2.gssye = TileMap2.gssy + TileMap2.county;
        if (TileMap2.gssye > TileMap2.tmh)
        {
            TileMap2.gssye = TileMap2.tmh;
        }
        ChatTextField2.gI().parentScreen = instance;
        ChatTextField2.gI().tfChat.y = GameCanvas2.h - 35 - ChatTextField2.gI().tfChat.height;
        ChatTextField2.gI().initChatTextField();
        if (GameCanvas2.isTouch)
        {
            yTouchBar = gH - 88;
            xC = gW - 40;
            yC = 2;
            if (GameCanvas2.w <= 240)
            {
                xC = gW - 35;
                yC = 5;
            }
            xF = gW - 55;
            yF = yTouchBar + 35;
            xTG = gW - 37;
            yTG = yTouchBar - 1;
            if (GameCanvas2.w >= 450)
            {
                yTG -= 12;
                yHP -= 7;
                xF -= 10;
                yF -= 5;
                xTG -= 10;
            }
        }
        setSkillBarPosition();
        disXC = ((GameCanvas2.w <= 200) ? 30 : 40);
        if (Rms2.loadRMSInt("viewchat") == -1)
        {
            GameCanvas2.panel.isViewChatServer = true;
        }
        else
        {
            GameCanvas2.panel.isViewChatServer = Rms2.loadRMSInt("viewchat") == 1;
        }
    }

    public static void setSkillBarPosition()
    {
        Skill2[] array = ((!GameCanvas2.isTouch) ? keySkill : onScreenSkill);
        xS = new int[array.Length];
        yS = new int[array.Length];
        if (GameCanvas2.isTouchControlSmallScreen && isUseTouch)
        {
            xSkill = 23;
            ySkill = 52;
            padSkill = 5;
            for (int i = 0; i < xS.Length; i++)
            {
                xS[i] = i * (25 + padSkill);
                yS[i] = ySkill;
                if (xS.Length > 5 && i >= xS.Length / 2)
                {
                    xS[i] = (i - xS.Length / 2) * (25 + padSkill);
                    yS[i] = ySkill - 32;
                }
            }
            xHP = array.Length * (25 + padSkill);
            yHP = ySkill;
        }
        else
        {
            wSkill = 30;
            if (GameCanvas2.w <= 320)
            {
                ySkill = gH - wSkill - 6;
                xSkill = gW2 - array.Length * wSkill / 2 - 25;
            }
            else
            {
                wSkill = 40;
                xSkill = 10;
                ySkill = GameCanvas2.h - wSkill + 7;
            }
            for (int j = 0; j < xS.Length; j++)
            {
                xS[j] = j * wSkill;
                yS[j] = ySkill;
                if (xS.Length > 5 && j >= xS.Length / 2)
                {
                    xS[j] = (j - xS.Length / 2) * wSkill;
                    yS[j] = ySkill - 32;
                }
            }
            xHP = array.Length * wSkill;
            yHP = ySkill;
        }
        if (!GameCanvas2.isTouch)
        {
            return;
        }
        xSkill = 17;
        ySkill = GameCanvas2.h - 40;
        if (gamePad.isSmallGamePad && isAnalog == 1)
        {
            xHP = array.Length * wSkill;
            yHP = ySkill;
        }
        else
        {
            xHP = GameCanvas2.w - 45;
            yHP = GameCanvas2.h - 45;
        }
        setTouchBtn();
        for (int k = 0; k < xS.Length; k++)
        {
            xS[k] = k * wSkill;
            yS[k] = ySkill;
            if (xS.Length > 5 && k >= xS.Length / 2)
            {
                xS[k] = (k - xS.Length / 2) * wSkill;
                yS[k] = ySkill - 32;
            }
        }
    }

    private static void updateCamera()
    {
        if (isPaintOther)
        {
            return;
        }
        if (cmx != cmtoX || cmy != cmtoY)
        {
            cmvx = cmtoX - cmx << 2;
            cmvy = cmtoY - cmy << 2;
            cmdx += cmvx;
            cmx += cmdx >> 4;
            cmdx &= 15;
            cmdy += cmvy;
            cmy += cmdy >> 4;
            cmdy &= 15;
            if (cmx < 24)
            {
                cmx = 24;
            }
            if (cmx > cmxLim)
            {
                cmx = cmxLim;
            }
            if (cmy < 0)
            {
                cmy = 0;
            }
            if (cmy > cmyLim)
            {
                cmy = cmyLim;
            }
        }
        gssx = cmx / TileMap2.size - 1;
        if (gssx < 0)
        {
            gssx = 0;
        }
        gssy = cmy / TileMap2.size;
        gssxe = gssx + gssw;
        gssye = gssy + gssh;
        if (gssy < 0)
        {
            gssy = 0;
        }
        if (gssye > TileMap2.tmh - 1)
        {
            gssye = TileMap2.tmh - 1;
        }
        TileMap2.gssx = (Char2.myCharz().cx - 2 * gW) / TileMap2.size;
        if (TileMap2.gssx < 0)
        {
            TileMap2.gssx = 0;
        }
        TileMap2.gssxe = TileMap2.gssx + TileMap2.countx;
        if (TileMap2.gssxe > TileMap2.tmw)
        {
            TileMap2.gssxe = TileMap2.tmw;
            TileMap2.gssx = TileMap2.gssxe - TileMap2.countx;
        }
        TileMap2.gssy = (Char2.myCharz().cy - 2 * gH) / TileMap2.size;
        if (TileMap2.gssy < 0)
        {
            TileMap2.gssy = 0;
        }
        TileMap2.gssye = TileMap2.gssy + TileMap2.county;
        if (TileMap2.gssye > TileMap2.tmh)
        {
            TileMap2.gssye = TileMap2.tmh;
            TileMap2.gssy = TileMap2.gssye - TileMap2.county;
        }
        scrMain.updatecm();
        scrInfo.updatecm();
    }

    public bool testAct()
    {
        for (sbyte b = 2; b < 9; b += 2)
        {
            if (GameCanvas2.keyHold[b])
            {
                return false;
            }
        }
        return true;
    }

    public void clanInvite(string strInvite, int clanID, int code)
    {
        ClanObject2 clanObject = new ClanObject2();
        clanObject.code = code;
        clanObject.clanID = clanID;
        startYesNoPopUp(strInvite, new Command2(mResources2.YES, 12002, clanObject), new Command2(mResources2.NO, 12003, clanObject));
    }

    public void playerMenu(Char2 c)
    {
        auto = 0;
        GameCanvas2.clearKeyHold();
        if (Char2.myCharz().charFocus.charID < 0 || Char2.myCharz().charID < 0)
        {
            return;
        }
        MyVector2 vPlayerMenu = GameCanvas2.panel.vPlayerMenu;
        if (vPlayerMenu.size() > 0)
        {
            return;
        }
        if (Char2.myCharz().taskMaint != null && Char2.myCharz().taskMaint.taskId > 1)
        {
            vPlayerMenu.addElement(new Command2(mResources2.make_friend, 11112, Char2.myCharz().charFocus));
            vPlayerMenu.addElement(new Command2(mResources2.trade, 11113, Char2.myCharz().charFocus));
        }
        if (Char2.myCharz().clan != null && Char2.myCharz().role < 2 && Char2.myCharz().charFocus.clanID == -1)
        {
            vPlayerMenu.addElement(new Command2(mResources2.CHAR_ORDER[4], 110391));
        }
        if (Char2.myCharz().charFocus.statusMe != 14 && Char2.myCharz().charFocus.statusMe != 5)
        {
            if (Char2.myCharz().taskMaint != null && Char2.myCharz().taskMaint.taskId >= 14)
            {
                vPlayerMenu.addElement(new Command2(mResources2.CHAR_ORDER[0], 2003));
            }
        }
        else if (Char2.myCharz().myskill.template.type != 4)
        {
        }
        if (Char2.myCharz().clan != null && Char2.myCharz().clan.ID == Char2.myCharz().charFocus.clanID && Char2.myCharz().charFocus.statusMe != 14 && Char2.myCharz().taskMaint != null && Char2.myCharz().taskMaint.taskId >= 14)
        {
            vPlayerMenu.addElement(new Command2(mResources2.CHAR_ORDER[1], 2004));
        }
        int num = Char2.myCharz().nClass.skillTemplates.Length;
        for (int i = 0; i < num; i++)
        {
            SkillTemplate2 skillTemplate = Char2.myCharz().nClass.skillTemplates[i];
            Skill2 skill = Char2.myCharz().getSkill(skillTemplate);
            if (skill != null && skillTemplate.isBuffToPlayer() && skill.point >= 1)
            {
                vPlayerMenu.addElement(new Command2(skillTemplate.name, 12004, skill));
            }
        }
    }

    public bool isAttack()
    {
        if (checkClickToBotton(Char2.myCharz().charFocus))
        {
            return false;
        }
        if (checkClickToBotton(Char2.myCharz().mobFocus))
        {
            return false;
        }
        if (checkClickToBotton(Char2.myCharz().npcFocus))
        {
            return false;
        }
        if (ChatTextField2.gI().isShow)
        {
            return false;
        }
        if (InfoDlg2.isLock || Char2.myCharz().isLockAttack || Char2.isLockKey)
        {
            return false;
        }
        if (Char2.myCharz().myskill != null && Char2.myCharz().myskill.template.id == 6 && Char2.myCharz().itemFocus != null)
        {
            pickItem();
            return false;
        }
        if (Char2.myCharz().myskill != null && Char2.myCharz().myskill.template.type == 2 && Char2.myCharz().npcFocus == null && Char2.myCharz().myskill.template.id != 6)
        {
            if (!checkSkillValid())
            {
                return false;
            }
            return true;
        }
        if (Char2.myCharz().skillPaint != null || (Char2.myCharz().mobFocus == null && Char2.myCharz().npcFocus == null && Char2.myCharz().charFocus == null && Char2.myCharz().itemFocus == null))
        {
            return false;
        }
        if (Char2.myCharz().mobFocus != null)
        {
            if (Char2.myCharz().mobFocus.isBigBoss() && Char2.myCharz().mobFocus.status == 4)
            {
                Char2.myCharz().mobFocus = null;
                Char2.myCharz().currentMovePoint = null;
            }
            isAutoPlay = true;
            if (!isMeCanAttackMob(Char2.myCharz().mobFocus))
            {
                return false;
            }
            if (mobCapcha != null)
            {
                return false;
            }
            if (Char2.myCharz().myskill == null)
            {
                return false;
            }
            if (Char2.myCharz().isSelectingSkillUseAlone())
            {
                return false;
            }
            int num = -1;
            int num2 = Res2.abs(Char2.myCharz().cx - cmx) * mGraphics2.zoomLevel;
            if (Char2.myCharz().charFocus != null)
            {
                num = Res2.abs(Char2.myCharz().cx - Char2.myCharz().charFocus.cx) * mGraphics2.zoomLevel;
            }
            else if (Char2.myCharz().mobFocus != null)
            {
                num = Res2.abs(Char2.myCharz().cx - Char2.myCharz().mobFocus.x) * mGraphics2.zoomLevel;
            }
            if (Char2.myCharz().mobFocus.status == 1 || Char2.myCharz().mobFocus.status == 0 || Char2.myCharz().myskill.template.type == 4 || num == -1 || num > num2)
            {
                if (Char2.myCharz().myskill.template.type == 4)
                {
                    if (Char2.myCharz().mobFocus.x < Char2.myCharz().cx)
                    {
                        Char2.myCharz().cdir = -1;
                    }
                    else
                    {
                        Char2.myCharz().cdir = 1;
                    }
                    doSelectSkill(Char2.myCharz().myskill, isShortcut: true);
                }
                return false;
            }
            if (!checkSkillValid())
            {
                return false;
            }
            if (Char2.myCharz().cx < Char2.myCharz().mobFocus.getX())
            {
                Char2.myCharz().cdir = 1;
            }
            else
            {
                Char2.myCharz().cdir = -1;
            }
            int num3 = Math2.abs(Char2.myCharz().cx - Char2.myCharz().mobFocus.getX());
            int num4 = Math2.abs(Char2.myCharz().cy - Char2.myCharz().mobFocus.getY());
            Char2.myCharz().cvx = 0;
            if (num3 <= Char2.myCharz().myskill.dx && num4 <= Char2.myCharz().myskill.dy)
            {
                if (Char2.myCharz().myskill.template.id == 20)
                {
                    return true;
                }
                if (num4 > num3 && Res2.abs(Char2.myCharz().cy - Char2.myCharz().mobFocus.getY()) > 30 && Char2.myCharz().mobFocus.getTemplate().type == 4)
                {
                    Char2.myCharz().currentMovePoint = new MovePoint2(Char2.myCharz().cx + Char2.myCharz().cdir, Char2.myCharz().mobFocus.getY());
                    Char2.myCharz().endMovePointCommand = new Command2(null, null, 8002, null);
                    GameCanvas2.clearKeyHold();
                    GameCanvas2.clearKeyPressed();
                    return false;
                }
                int num5 = 20;
                bool flag = false;
                if (Char2.myCharz().mobFocus is BigBoss2_ || Char2.myCharz().mobFocus is BigBoss2_2)
                {
                    flag = true;
                }
                if (Char2.myCharz().myskill.dx > 100)
                {
                    num5 = 60;
                    if (num3 < 20)
                    {
                        Char2.myCharz().createShadow(Char2.myCharz().cx, Char2.myCharz().cy, 10);
                    }
                }
                bool flag2 = false;
                if ((TileMap2.tileTypeAtPixel(Char2.myCharz().cx, Char2.myCharz().cy + 3) & 2) == 2)
                {
                    int num6 = ((Char2.myCharz().cx > Char2.myCharz().mobFocus.getX()) ? 1 : (-1));
                    if ((TileMap2.tileTypeAtPixel(Char2.myCharz().mobFocus.getX() + num5 * num6, Char2.myCharz().cy + 3) & 2) != 2)
                    {
                        flag2 = true;
                    }
                }
                if (num3 <= num5 && !flag2)
                {
                    if (Char2.myCharz().cx > Char2.myCharz().mobFocus.getX())
                    {
                        Char2.myCharz().cx = Char2.myCharz().mobFocus.getX() + num5 + (flag ? 30 : 0);
                        Char2.myCharz().cdir = -1;
                    }
                    else
                    {
                        Char2.myCharz().cx = Char2.myCharz().mobFocus.getX() - num5 - (flag ? 30 : 0);
                        Char2.myCharz().cdir = 1;
                    }
                    Service2.gI().charMove();
                }
                GameCanvas2.clearKeyHold();
                GameCanvas2.clearKeyPressed();
                return true;
            }
            bool flag3 = false;
            if (Char2.myCharz().mobFocus is BigBoss2_ || Char2.myCharz().mobFocus is BigBoss2_2)
            {
                flag3 = true;
            }
            int num7 = (Char2.myCharz().myskill.dx - ((!flag3) ? 20 : 50)) * ((Char2.myCharz().cx > Char2.myCharz().mobFocus.getX()) ? 1 : (-1));
            if (num3 <= Char2.myCharz().myskill.dx)
            {
                num7 = 0;
            }
            Char2.myCharz().currentMovePoint = new MovePoint2(Char2.myCharz().mobFocus.getX() + num7, Char2.myCharz().mobFocus.getY());
            Char2.myCharz().endMovePointCommand = new Command2(null, null, 8002, null);
            GameCanvas2.clearKeyHold();
            GameCanvas2.clearKeyPressed();
            return false;
        }
        if (Char2.myCharz().npcFocus != null)
        {
            if (Char2.myCharz().npcFocus.isHide)
            {
                return false;
            }
            if (Char2.myCharz().cx < Char2.myCharz().npcFocus.cx)
            {
                Char2.myCharz().cdir = 1;
            }
            else
            {
                Char2.myCharz().cdir = -1;
            }
            if (Char2.myCharz().cx < Char2.myCharz().npcFocus.cx)
            {
                Char2.myCharz().npcFocus.cdir = -1;
            }
            else
            {
                Char2.myCharz().npcFocus.cdir = 1;
            }
            int num8 = Math2.abs(Char2.myCharz().cx - Char2.myCharz().npcFocus.cx);
            int num9 = Math2.abs(Char2.myCharz().cy - Char2.myCharz().npcFocus.cy);
            if (num9 > 40)
            {
                Char2.myCharz().cy = Char2.myCharz().npcFocus.cy - 40;
            }
            if (num8 < 60)
            {
                GameCanvas2.clearKeyHold();
                GameCanvas2.clearKeyPressed();
                if (tMenuDelay == 0)
                {
                    if (Char2.myCharz().taskMaint != null && Char2.myCharz().taskMaint.taskId == 0)
                    {
                        if (Char2.myCharz().taskMaint.index < 4 && Char2.myCharz().npcFocus.template.npcTemplateId == 4)
                        {
                            return false;
                        }
                        if (Char2.myCharz().taskMaint.index < 3 && Char2.myCharz().npcFocus.template.npcTemplateId == 3)
                        {
                            return false;
                        }
                    }
                    tMenuDelay = 50;
                    InfoDlg2.showWait();
                    Service2.gI().charMove();
                    Service2.gI().openMenu(Char2.myCharz().npcFocus.template.npcTemplateId);
                }
            }
            else
            {
                int num10 = (20 + Res2.r.nextInt(20)) * ((Char2.myCharz().cx > Char2.myCharz().npcFocus.cx) ? 1 : (-1));
                Char2.myCharz().currentMovePoint = new MovePoint2(Char2.myCharz().npcFocus.cx + num10, Char2.myCharz().cy);
                Char2.myCharz().endMovePointCommand = new Command2(null, null, 8002, null);
                GameCanvas2.clearKeyHold();
                GameCanvas2.clearKeyPressed();
            }
            return false;
        }
        if (Char2.myCharz().charFocus != null)
        {
            if (mobCapcha != null)
            {
                return false;
            }
            if (Char2.myCharz().cx < Char2.myCharz().charFocus.cx)
            {
                Char2.myCharz().cdir = 1;
            }
            else
            {
                Char2.myCharz().cdir = -1;
            }
            int num11 = Math2.abs(Char2.myCharz().cx - Char2.myCharz().charFocus.cx);
            int num12 = Math2.abs(Char2.myCharz().cy - Char2.myCharz().charFocus.cy);
            if (Char2.myCharz().isMeCanAttackOtherPlayer(Char2.myCharz().charFocus) || Char2.myCharz().isSelectingSkillBuffToPlayer())
            {
                if (Char2.myCharz().myskill == null)
                {
                    return false;
                }
                if (!checkSkillValid())
                {
                    return false;
                }
                if (Char2.myCharz().cx < Char2.myCharz().charFocus.cx)
                {
                    Char2.myCharz().cdir = 1;
                }
                else
                {
                    Char2.myCharz().cdir = -1;
                }
                Char2.myCharz().cvx = 0;
                if (num11 <= Char2.myCharz().myskill.dx && num12 <= Char2.myCharz().myskill.dy)
                {
                    if (Char2.myCharz().myskill.template.id == 20)
                    {
                        return true;
                    }
                    int num13 = 20;
                    if (Char2.myCharz().myskill.dx > 60)
                    {
                        num13 = 60;
                        if (num11 < 20)
                        {
                            Char2.myCharz().createShadow(Char2.myCharz().cx, Char2.myCharz().cy, 10);
                        }
                    }
                    bool flag4 = false;
                    if ((TileMap2.tileTypeAtPixel(Char2.myCharz().cx, Char2.myCharz().cy + 3) & 2) == 2)
                    {
                        int num14 = ((Char2.myCharz().cx > Char2.myCharz().charFocus.cx) ? 1 : (-1));
                        if ((TileMap2.tileTypeAtPixel(Char2.myCharz().charFocus.cx + num13 * num14, Char2.myCharz().cy + 3) & 2) != 2)
                        {
                            flag4 = true;
                        }
                    }
                    if (num11 <= num13 && !flag4)
                    {
                        if (Char2.myCharz().cx > Char2.myCharz().charFocus.cx)
                        {
                            Char2.myCharz().cx = Char2.myCharz().charFocus.cx + num13;
                            Char2.myCharz().cdir = -1;
                        }
                        else
                        {
                            Char2.myCharz().cx = Char2.myCharz().charFocus.cx - num13;
                            Char2.myCharz().cdir = 1;
                        }
                        Service2.gI().charMove();
                    }
                    GameCanvas2.clearKeyHold();
                    GameCanvas2.clearKeyPressed();
                    return true;
                }
                int num15 = (Char2.myCharz().myskill.dx - 20) * ((Char2.myCharz().cx > Char2.myCharz().charFocus.cx) ? 1 : (-1));
                if (num11 <= Char2.myCharz().myskill.dx)
                {
                    num15 = 0;
                }
                Char2.myCharz().currentMovePoint = new MovePoint2(Char2.myCharz().charFocus.cx + num15, Char2.myCharz().charFocus.cy);
                Char2.myCharz().endMovePointCommand = new Command2(null, null, 8002, null);
                GameCanvas2.clearKeyHold();
                GameCanvas2.clearKeyPressed();
                return false;
            }
            if (num11 < 60 && num12 < 40)
            {
                playerMenu(Char2.myCharz().charFocus);
                if (!GameCanvas2.isTouch && Char2.myCharz().charFocus.charID >= 0 && TileMap2.mapID != 51 && TileMap2.mapID != 52 && popUpYesNo == null)
                {
                    GameCanvas2.panel.setTypePlayerMenu(Char2.myCharz().charFocus);
                    GameCanvas2.panel.show();
                    Service2.gI().getPlayerMenu(Char2.myCharz().charFocus.charID);
                    Service2.gI().messagePlayerMenu(Char2.myCharz().charFocus.charID);
                }
            }
            else
            {
                int num16 = (20 + Res2.r.nextInt(20)) * ((Char2.myCharz().cx > Char2.myCharz().charFocus.cx) ? 1 : (-1));
                Char2.myCharz().currentMovePoint = new MovePoint2(Char2.myCharz().charFocus.cx + num16, Char2.myCharz().charFocus.cy);
                Char2.myCharz().endMovePointCommand = new Command2(null, null, 8002, null);
                GameCanvas2.clearKeyHold();
                GameCanvas2.clearKeyPressed();
            }
            return false;
        }
        if (Char2.myCharz().itemFocus != null)
        {
            pickItem();
            return false;
        }
        return true;
    }

    public bool isMeCanAttackMob(Mob2 m)
    {
        if (m == null)
        {
            return false;
        }
        if (Char2.myCharz().cTypePk == 5)
        {
            return true;
        }
        if (Char2.myCharz().isAttacPlayerStatus() && !m.isMobMe)
        {
            return false;
        }
        if (Char2.myCharz().mobMe != null && m.Equals(Char2.myCharz().mobMe))
        {
            return false;
        }
        Char2 @char = findCharInMap(m.mobId);
        if (@char == null)
        {
            return true;
        }
        if (@char.cTypePk == 5)
        {
            return true;
        }
        if (Char2.myCharz().isMeCanAttackOtherPlayer(@char))
        {
            return true;
        }
        return false;
    }

    private bool checkSkillValid()
    {
        if (Char2.myCharz().myskill != null && ((Char2.myCharz().myskill.template.manaUseType != 1 && Char2.myCharz().cMP < Char2.myCharz().myskill.manaUse) || (Char2.myCharz().myskill.template.manaUseType == 1 && Char2.myCharz().cMP < Char2.myCharz().cMPFull * Char2.myCharz().myskill.manaUse / 100)))
        {
            info1.addInfo(mResources2.NOT_ENOUGH_MP, 0);
            auto = 0;
            return false;
        }
        if (Char2.myCharz().myskill == null || (Char2.myCharz().myskill.template.maxPoint > 0 && Char2.myCharz().myskill.point == 0))
        {
            GameCanvas2.startOKDlg(mResources2.SKILL_FAIL);
            return false;
        }
        return true;
    }

    private bool checkSkillValid2()
    {
        if (Char2.myCharz().myskill != null && ((Char2.myCharz().myskill.template.manaUseType != 1 && Char2.myCharz().cMP < Char2.myCharz().myskill.manaUse) || (Char2.myCharz().myskill.template.manaUseType == 1 && Char2.myCharz().cMP < Char2.myCharz().cMPFull * Char2.myCharz().myskill.manaUse / 100)))
        {
            return false;
        }
        if (Char2.myCharz().myskill == null || (Char2.myCharz().myskill.template.maxPoint > 0 && Char2.myCharz().myskill.point == 0))
        {
            return false;
        }
        return true;
    }

    public void resetButton()
    {
        GameCanvas2.menu.showMenu = false;
        ChatTextField2.gI().close();
        ChatTextField2.gI().center = null;
        isLockKey = false;
        typeTrade = 0;
        indexMenu = 0;
        indexSelect = 0;
        indexItemUse = -1;
        indexRow = -1;
        indexRowMax = 0;
        indexTitle = 0;
        typeTrade = (typeTradeOrder = 0);
        mSystem2.endKey();
        if (Char2.myCharz().cHP <= 0 || Char2.myCharz().statusMe == 14 || Char2.myCharz().statusMe == 5)
        {
            if (Char2.myCharz().meDead)
            {
                cmdDead = new Command2(mResources2.DIES[0], 11038);
                center = cmdDead;
                Char2.myCharz().cHP = 0;
            }
            isHaveSelectSkill = false;
        }
        else
        {
            isHaveSelectSkill = true;
        }
        scrMain.clear();
    }

    public override void keyPress(int keyCode)
    {
        base.keyPress(keyCode);
    }

    public override void updateKey()
    {
        if (Controller2_.isStopReadMessage || Char2.myCharz().isTeleport || Char2.myCharz().isPaintNewSkill || InfoDlg2.isLock)
        {
            return;
        }
        if (GameCanvas2.isTouch && !ChatTextField2.gI().isShow && !GameCanvas2.menu.showMenu)
        {
            UpdateKeyTouchControl();
        }
        checkAuto();
        GameCanvas2.debug("F2", 0);
        if (ChatPopup2.currChatPopup != null)
        {
            Command2 cmdNextLine = ChatPopup2.currChatPopup.cmdNextLine;
            if ((GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] || getCmdPointerLast(cmdNextLine)) && cmdNextLine != null)
            {
                GameCanvas2.isPointerJustRelease = false;
                GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
                keyTouch = -1;
                cmdNextLine?.performAction();
            }
        }
        else if (!ChatTextField2.gI().isShow)
        {
            if ((GameCanvas2.keyPressed[12] || getCmdPointerLast(GameCanvas2.currentScreen.left)) && left != null)
            {
                GameCanvas2.isPointerJustRelease = false;
                GameCanvas2.isPointerClick = false;
                GameCanvas2.keyPressed[12] = false;
                keyTouch = -1;
                if (left != null)
                {
                    left.performAction();
                }
            }
            if ((GameCanvas2.keyPressed[13] || getCmdPointerLast(GameCanvas2.currentScreen.right)) && right != null)
            {
                GameCanvas2.isPointerJustRelease = false;
                GameCanvas2.isPointerClick = false;
                GameCanvas2.keyPressed[13] = false;
                keyTouch = -1;
                if (right != null)
                {
                    right.performAction();
                }
            }
            if ((GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] || getCmdPointerLast(GameCanvas2.currentScreen.center)) && center != null)
            {
                GameCanvas2.isPointerJustRelease = false;
                GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
                keyTouch = -1;
                if (center != null)
                {
                    center.performAction();
                }
            }
        }
        else
        {
            if (ChatTextField2.gI().left != null && (GameCanvas2.keyPressed[12] || getCmdPointerLast(ChatTextField2.gI().left)) && ChatTextField2.gI().left != null)
            {
                ChatTextField2.gI().left.performAction();
            }
            if (ChatTextField2.gI().right != null && (GameCanvas2.keyPressed[13] || getCmdPointerLast(ChatTextField2.gI().right)) && ChatTextField2.gI().right != null)
            {
                ChatTextField2.gI().right.performAction();
            }
            if (ChatTextField2.gI().center != null && (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] || getCmdPointerLast(ChatTextField2.gI().center)) && ChatTextField2.gI().center != null)
            {
                ChatTextField2.gI().center.performAction();
            }
        }
        GameCanvas2.debug("F6", 0);
        updateKeyAlert();
        GameCanvas2.debug("F7", 0);
        if (Char2.myCharz().currentMovePoint != null)
        {
            for (int i = 0; i < GameCanvas2.keyPressed.Length; i++)
            {
                if (GameCanvas2.keyPressed[i])
                {
                    Char2.myCharz().currentMovePoint = null;
                    break;
                }
            }
        }
        GameCanvas2.debug("F8", 0);
        if (ChatTextField2.gI().isShow && GameCanvas2.keyAsciiPress != 0)
        {
            ChatTextField2.gI().keyPressed(GameCanvas2.keyAsciiPress);
            GameCanvas2.keyAsciiPress = 0;
        }
        else if (isLockKey)
        {
            GameCanvas2.clearKeyHold();
            GameCanvas2.clearKeyPressed();
        }
        else
        {
            if (GameCanvas2.menu.showMenu || isOpenUI() || Char2.isLockKey)
            {
                return;
            }
            if (GameCanvas2.keyPressed[10])
            {
                GameCanvas2.keyPressed[10] = false;
                doUseHP();
                GameCanvas2.clearKeyPressed();
            }
            if (GameCanvas2.keyPressed[11] && mobCapcha == null)
            {
                if (popUpYesNo != null)
                {
                    popUpYesNo.cmdYes.performAction();
                }
                else if (info2.info.info != null && info2.info.info.charInfo != null)
                {
                    GameCanvas2.panel.setTypeMessage();
                    GameCanvas2.panel.show();
                }
                GameCanvas2.keyPressed[11] = false;
                GameCanvas2.clearKeyPressed();
            }
            if (GameCanvas2.keyAsciiPress != 0 && TField2.isQwerty && GameCanvas2.keyAsciiPress == 32)
            {
                doUseHP();
                GameCanvas2.keyAsciiPress = 0;
                GameCanvas2.clearKeyPressed();
            }
            if (GameCanvas2.keyAsciiPress != 0 && mobCapcha == null && TField2.isQwerty && GameCanvas2.keyAsciiPress == 121)
            {
                if (popUpYesNo != null)
                {
                    popUpYesNo.cmdYes.performAction();
                    GameCanvas2.keyAsciiPress = 0;
                    GameCanvas2.clearKeyPressed();
                }
                else if (info2.info.info != null && info2.info.info.charInfo != null)
                {
                    GameCanvas2.panel.setTypeMessage();
                    GameCanvas2.panel.show();
                    GameCanvas2.keyAsciiPress = 0;
                    GameCanvas2.clearKeyPressed();
                }
            }
            if (GameCanvas2.keyPressed[10] && mobCapcha == null)
            {
                GameCanvas2.keyPressed[10] = false;
                info2.doClick(10);
                GameCanvas2.clearKeyPressed();
            }
            checkDrag();
            if (!Char2.myCharz().isFlyAndCharge)
            {
                checkClick();
            }
            if (Char2.myCharz().cmdMenu != null && Char2.myCharz().cmdMenu.isPointerPressInside())
            {
                Char2.myCharz().cmdMenu.performAction();
            }
            if (Char2.myCharz().skillPaint != null)
            {
                return;
            }
            if (GameCanvas2.keyAsciiPress != 0)
            {
                if (mobCapcha == null)
                {
                    if (TField2.isQwerty)
                    {
                        if (GameCanvas2.keyPressed[1])
                        {
                            if (keySkill[0] != null)
                            {
                                doSelectSkill(keySkill[0], isShortcut: true);
                            }
                        }
                        else if (GameCanvas2.keyPressed[2])
                        {
                            if (keySkill[1] != null)
                            {
                                doSelectSkill(keySkill[1], isShortcut: true);
                            }
                        }
                        else if (GameCanvas2.keyPressed[3])
                        {
                            if (keySkill[2] != null)
                            {
                                doSelectSkill(keySkill[2], isShortcut: true);
                            }
                        }
                        else if (GameCanvas2.keyPressed[4])
                        {
                            if (keySkill[3] != null)
                            {
                                doSelectSkill(keySkill[3], isShortcut: true);
                            }
                        }
                        else if (GameCanvas2.keyPressed[5])
                        {
                            if (keySkill[4] != null)
                            {
                                doSelectSkill(keySkill[4], isShortcut: true);
                            }
                        }
                        else if (GameCanvas2.keyPressed[6])
                        {
                            if (keySkill[5] != null)
                            {
                                doSelectSkill(keySkill[5], isShortcut: true);
                            }
                        }
                        else if (GameCanvas2.keyPressed[7])
                        {
                            if (keySkill[6] != null)
                            {
                                doSelectSkill(keySkill[6], isShortcut: true);
                            }
                        }
                        else if (GameCanvas2.keyPressed[8])
                        {
                            if (keySkill[7] != null)
                            {
                                doSelectSkill(keySkill[7], isShortcut: true);
                            }
                        }
                        else if (GameCanvas2.keyPressed[9])
                        {
                            if (keySkill[8] != null)
                            {
                                doSelectSkill(keySkill[8], isShortcut: true);
                            }
                        }
                        else if (GameCanvas2.keyPressed[0])
                        {
                            if (keySkill[9] != null)
                            {
                                doSelectSkill(keySkill[9], isShortcut: true);
                            }
                        }
                        else if (GameCanvas2.keyAsciiPress == 114)
                        {
                            ChatTextField2.gI().startChat(this, string.Empty);
                        }
                        else if (MainMod2.GI().UpdateKey(GameCanvas2.keyAsciiPress))
                        {

                        }
                    }
                    else if (!GameCanvas2.isMoveNumberPad)
                    {
                        ChatTextField2.gI().startChat(GameCanvas2.keyAsciiPress, this, string.Empty);
                    }
                    else if (GameCanvas2.keyAsciiPress == 55)
                    {
                        if (keySkill[0] != null)
                        {
                            doSelectSkill(keySkill[0], isShortcut: true);
                        }
                    }
                    else if (GameCanvas2.keyAsciiPress == 56)
                    {
                        if (keySkill[1] != null)
                        {
                            doSelectSkill(keySkill[1], isShortcut: true);
                        }
                    }
                    else if (GameCanvas2.keyAsciiPress == 57)
                    {
                        if (keySkill[(!Main2.isPC) ? 2 : 21] != null)
                        {
                            doSelectSkill(keySkill[2], isShortcut: true);
                        }
                    }
                    else if (GameCanvas2.keyAsciiPress == 48)
                    {
                        ChatTextField2.gI().startChat(this, string.Empty);
                    }
                }
                else
                {
                    char[] array = keyInput.ToCharArray();
                    MyVector2 myVector = new MyVector2();
                    for (int j = 0; j < array.Length; j++)
                    {
                        myVector.addElement(array[j] + string.Empty);
                    }
                    myVector.removeElementAt(0);
                    string text = (char)GameCanvas2.keyAsciiPress + string.Empty;
                    if (text.Equals(string.Empty) || text == null || text.Equals("\n"))
                    {
                        text = "-";
                    }
                    myVector.insertElementAt(text, myVector.size());
                    keyInput = string.Empty;
                    for (int k = 0; k < myVector.size(); k++)
                    {
                        keyInput += ((string)myVector.elementAt(k)).ToUpper();
                    }
                    Service2.gI().mobCapcha((char)GameCanvas2.keyAsciiPress);
                }
                GameCanvas2.keyAsciiPress = 0;
            }
            if (Char2.myCharz().statusMe == 1)
            {
                GameCanvas2.debug("F10", 0);
                if (!doSeleckSkillFlag)
                {
                    if (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25])
                    {
                        GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
                        doFire(isFireByShortCut: false, skipWaypoint: false);
                    }
                    else if (GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21])
                    {
                        if (!Char2.myCharz().isLockMove)
                        {
                            setCharJump(0);
                        }
                    }
                    else if (GameCanvas2.keyHold[1] && mobCapcha == null)
                    {
                        if (!Main2.isPC)
                        {
                            Char2.myCharz().cdir = -1;
                            if (!Char2.myCharz().isLockMove)
                            {
                                setCharJump(-4);
                            }
                        }
                    }
                    else if (GameCanvas2.keyHold[(!Main2.isPC) ? 5 : 25] && mobCapcha == null)
                    {
                        if (!Main2.isPC)
                        {
                            Char2.myCharz().cdir = 1;
                            if (!Char2.myCharz().isLockMove)
                            {
                                setCharJump(4);
                            }
                        }
                    }
                    else if (GameCanvas2.keyHold[(!Main2.isPC) ? 4 : 23])
                    {
                        isAutoPlay = false;
                        Char2.myCharz().isAttack = false;
                        if (Char2.myCharz().cdir == 1)
                        {
                            Char2.myCharz().cdir = -1;
                        }
                        else if (!Char2.myCharz().isLockMove)
                        {
                            if (Char2.myCharz().cx - Char2.myCharz().cxSend != 0)
                            {
                                Service2.gI().charMove();
                            }
                            Char2.myCharz().statusMe = 2;
                            Char2.myCharz().cvx = -Char2.myCharz().cspeed;
                        }
                        Char2.myCharz().holder = false;
                    }
                    else if (GameCanvas2.keyHold[(!Main2.isPC) ? 6 : 24])
                    {
                        isAutoPlay = false;
                        Char2.myCharz().isAttack = false;
                        if (Char2.myCharz().cdir == -1)
                        {
                            Char2.myCharz().cdir = 1;
                        }
                        else if (!Char2.myCharz().isLockMove)
                        {
                            if (Char2.myCharz().cx - Char2.myCharz().cxSend != 0)
                            {
                                Service2.gI().charMove();
                            }
                            Char2.myCharz().statusMe = 2;
                            Char2.myCharz().cvx = Char2.myCharz().cspeed;
                        }
                        Char2.myCharz().holder = false;
                    }
                }
            }
            else if (Char2.myCharz().statusMe == 2)
            {
                if (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25])
                {
                    GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
                    doFire(isFireByShortCut: false, skipWaypoint: true);
                }
                else if (GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21])
                {
                    if (Char2.myCharz().cx - Char2.myCharz().cxSend != 0 || Char2.myCharz().cy - Char2.myCharz().cySend != 0)
                    {
                        Service2.gI().charMove();
                    }
                    Char2.myCharz().cvy = -10;
                    Char2.myCharz().statusMe = 3;
                    Char2.myCharz().cp1 = 0;
                }
                else if (GameCanvas2.keyHold[1] && mobCapcha == null)
                {
                    if (Main2.isPC)
                    {
                        if (Char2.myCharz().cx - Char2.myCharz().cxSend != 0 || Char2.myCharz().cy - Char2.myCharz().cySend != 0)
                        {
                            Service2.gI().charMove();
                        }
                        Char2.myCharz().cdir = -1;
                        Char2.myCharz().cvy = -10;
                        Char2.myCharz().cvx = -4;
                        Char2.myCharz().statusMe = 3;
                        Char2.myCharz().cp1 = 0;
                    }
                }
                else if (GameCanvas2.keyHold[3] && mobCapcha == null)
                {
                    if (!Main2.isPC)
                    {
                        if (Char2.myCharz().cx - Char2.myCharz().cxSend != 0 || Char2.myCharz().cy - Char2.myCharz().cySend != 0)
                        {
                            Service2.gI().charMove();
                        }
                        Char2.myCharz().cdir = 1;
                        Char2.myCharz().cvy = -10;
                        Char2.myCharz().cvx = 4;
                        Char2.myCharz().statusMe = 3;
                        Char2.myCharz().cp1 = 0;
                    }
                }
                else if (GameCanvas2.keyHold[(!Main2.isPC) ? 4 : 23])
                {
                    isAutoPlay = false;
                    if (Char2.myCharz().cdir == 1)
                    {
                        Char2.myCharz().cdir = -1;
                    }
                    else
                    {
                        Char2.myCharz().cvx = -Char2.myCharz().cspeed + Char2.myCharz().cBonusSpeed;
                    }
                }
                else if (GameCanvas2.keyHold[(!Main2.isPC) ? 6 : 24])
                {
                    isAutoPlay = false;
                    if (Char2.myCharz().cdir == -1)
                    {
                        Char2.myCharz().cdir = 1;
                    }
                    else
                    {
                        Char2.myCharz().cvx = Char2.myCharz().cspeed + Char2.myCharz().cBonusSpeed;
                    }
                }
            }
            else if (Char2.myCharz().statusMe == 3)
            {
                isAutoPlay = false;
                GameCanvas2.debug("F12", 0);
                if (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25])
                {
                    GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
                    doFire(isFireByShortCut: false, skipWaypoint: true);
                }
                if (GameCanvas2.keyHold[(!Main2.isPC) ? 4 : 23] || (GameCanvas2.keyHold[1] && mobCapcha == null))
                {
                    if (Char2.myCharz().cdir == 1)
                    {
                        Char2.myCharz().cdir = -1;
                    }
                    else
                    {
                        Char2.myCharz().cvx = -Char2.myCharz().cspeed;
                    }
                }
                else if (GameCanvas2.keyHold[(!Main2.isPC) ? 6 : 24] || (GameCanvas2.keyHold[3] && mobCapcha == null))
                {
                    if (Char2.myCharz().cdir == -1)
                    {
                        Char2.myCharz().cdir = 1;
                    }
                    else
                    {
                        Char2.myCharz().cvx = Char2.myCharz().cspeed;
                    }
                }
                if ((GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21] || ((GameCanvas2.keyHold[1] || GameCanvas2.keyHold[3]) && mobCapcha == null)) && Char2.myCharz().canFly && Char2.myCharz().cMP > 0 && Char2.myCharz().cp1 < 8 && Char2.myCharz().cvy > -4)
                {
                    Char2.myCharz().cp1++;
                    Char2.myCharz().cvy = -7;
                }
            }
            else if (Char2.myCharz().statusMe == 4)
            {
                GameCanvas2.debug("F13", 0);
                if (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25])
                {
                    GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
                    doFire(isFireByShortCut: false, skipWaypoint: true);
                }
                if (GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21] && Char2.myCharz().cMP > 0 && Char2.myCharz().canFly)
                {
                    isAutoPlay = false;
                    if ((Char2.myCharz().cx - Char2.myCharz().cxSend != 0 || Char2.myCharz().cy - Char2.myCharz().cySend != 0) && (Res2.abs(Char2.myCharz().cx - Char2.myCharz().cxSend) > 96 || Res2.abs(Char2.myCharz().cy - Char2.myCharz().cySend) > 24))
                    {
                        Service2.gI().charMove();
                    }
                    Char2.myCharz().cvy = -10;
                    Char2.myCharz().statusMe = 3;
                    Char2.myCharz().cp1 = 0;
                }
                if (GameCanvas2.keyHold[(!Main2.isPC) ? 4 : 23])
                {
                    isAutoPlay = false;
                    if (Char2.myCharz().cdir == 1)
                    {
                        Char2.myCharz().cdir = -1;
                    }
                    else
                    {
                        Char2.myCharz().cp1++;
                        Char2.myCharz().cvx = -Char2.myCharz().cspeed;
                        if (Char2.myCharz().cp1 > 5 && Char2.myCharz().cvy > 6)
                        {
                            Char2.myCharz().statusMe = 10;
                            Char2.myCharz().cp1 = 0;
                            Char2.myCharz().cvy = 0;
                        }
                    }
                }
                else if (GameCanvas2.keyHold[(!Main2.isPC) ? 6 : 24])
                {
                    isAutoPlay = false;
                    if (Char2.myCharz().cdir == -1)
                    {
                        Char2.myCharz().cdir = 1;
                    }
                    else
                    {
                        Char2.myCharz().cp1++;
                        Char2.myCharz().cvx = Char2.myCharz().cspeed;
                        if (Char2.myCharz().cp1 > 5 && Char2.myCharz().cvy > 6)
                        {
                            Char2.myCharz().statusMe = 10;
                            Char2.myCharz().cp1 = 0;
                            Char2.myCharz().cvy = 0;
                        }
                    }
                }
            }
            else if (Char2.myCharz().statusMe == 10)
            {
                GameCanvas2.debug("F14", 0);
                if (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25])
                {
                    GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
                    doFire(isFireByShortCut: false, skipWaypoint: true);
                }
                if (Char2.myCharz().canFly && Char2.myCharz().cMP > 0)
                {
                    if (GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21])
                    {
                        isAutoPlay = false;
                        if ((Char2.myCharz().cx - Char2.myCharz().cxSend != 0 || Char2.myCharz().cy - Char2.myCharz().cySend != 0) && (Res2.abs(Char2.myCharz().cx - Char2.myCharz().cxSend) > 96 || Res2.abs(Char2.myCharz().cy - Char2.myCharz().cySend) > 24))
                        {
                            Service2.gI().charMove();
                        }
                        Char2.myCharz().cvy = -10;
                        Char2.myCharz().statusMe = 3;
                        Char2.myCharz().cp1 = 0;
                    }
                    else if (GameCanvas2.keyHold[(!Main2.isPC) ? 4 : 23])
                    {
                        isAutoPlay = false;
                        if (Char2.myCharz().cdir == 1)
                        {
                            Char2.myCharz().cdir = -1;
                        }
                        else
                        {
                            Char2.myCharz().cvx = -(Char2.myCharz().cspeed + 1);
                        }
                    }
                    else if (GameCanvas2.keyHold[(!Main2.isPC) ? 6 : 24])
                    {
                        if (Char2.myCharz().cdir == -1)
                        {
                            Char2.myCharz().cdir = 1;
                        }
                        else
                        {
                            Char2.myCharz().cvx = Char2.myCharz().cspeed + 1;
                        }
                    }
                }
            }
            else if (Char2.myCharz().statusMe == 7)
            {
                GameCanvas2.debug("F15", 0);
                if (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25])
                {
                    GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
                }
                if (GameCanvas2.keyHold[(!Main2.isPC) ? 4 : 23])
                {
                    isAutoPlay = false;
                    if (Char2.myCharz().cdir == 1)
                    {
                        Char2.myCharz().cdir = -1;
                    }
                    else
                    {
                        Char2.myCharz().cvx = -Char2.myCharz().cspeed + 2;
                    }
                }
                else if (GameCanvas2.keyHold[(!Main2.isPC) ? 6 : 24])
                {
                    isAutoPlay = false;
                    if (Char2.myCharz().cdir == -1)
                    {
                        Char2.myCharz().cdir = 1;
                    }
                    else
                    {
                        Char2.myCharz().cvx = Char2.myCharz().cspeed - 2;
                    }
                }
            }
            GameCanvas2.debug("F17", 0);
            if (GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22] && GameCanvas2.keyAsciiPress != 56)
            {
                GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22] = false;
                Char2.myCharz().delayFall = 0;
            }
            if (GameCanvas2.keyPressed[10])
            {
                GameCanvas2.keyPressed[10] = false;
                doUseHP();
            }
            GameCanvas2.debug("F20", 0);
            GameCanvas2.clearKeyPressed();
            GameCanvas2.debug("F23", 0);
            doSeleckSkillFlag = false;
        }
    }

    public bool isVsMap()
    {
        return true;
    }

    private void checkDrag()
    {
        if (isAnalog == 1 || gamePad.disableCheckDrag())
        {
            return;
        }
        Char2.myCharz().cmtoChar = true;
        if (isUseTouch)
        {
            return;
        }
        if (GameCanvas2.isPointerJustDown)
        {
            GameCanvas2.isPointerJustDown = false;
            isPointerDowning = true;
            ptDownTime = 0;
            ptLastDownX = (ptFirstDownX = GameCanvas2.px);
            ptLastDownY = (ptFirstDownY = GameCanvas2.py);
        }
        if (isPointerDowning)
        {
            int num = GameCanvas2.px - ptLastDownX;
            int num2 = GameCanvas2.py - ptLastDownY;
            if (!isChangingCameraMode && (Res2.abs(GameCanvas2.px - ptFirstDownX) > 15 || Res2.abs(GameCanvas2.py - ptFirstDownY) > 15))
            {
                isChangingCameraMode = true;
            }
            ptLastDownX = GameCanvas2.px;
            ptLastDownY = GameCanvas2.py;
            ptDownTime++;
            if (isChangingCameraMode)
            {
                Char2.myCharz().cmtoChar = false;
                cmx -= num;
                cmy -= num2;
                if (cmx < 24)
                {
                    int num3 = (24 - cmx) / 3;
                    if (num3 != 0)
                    {
                        cmx += num - num / num3;
                    }
                }
                if (cmx < (isVsMap() ? 24 : 0))
                {
                    cmx = (isVsMap() ? 24 : 0);
                }
                if (cmx > cmxLim)
                {
                    int num4 = (cmx - cmxLim) / 3;
                    if (num4 != 0)
                    {
                        cmx += num - num / num4;
                    }
                }
                if (cmx > cmxLim + ((!isVsMap()) ? 24 : 0))
                {
                    cmx = cmxLim + ((!isVsMap()) ? 24 : 0);
                }
                if (cmy < 0)
                {
                    int num5 = -cmy / 3;
                    if (num5 != 0)
                    {
                        cmy += num2 - num2 / num5;
                    }
                }
                if (cmy < -((!isVsMap()) ? 24 : 0))
                {
                    cmy = -((!isVsMap()) ? 24 : 0);
                }
                if (cmy > cmyLim)
                {
                    cmy = cmyLim;
                }
                cmtoX = cmx;
                cmtoY = cmy;
            }
        }
        if (isPointerDowning && GameCanvas2.isPointerJustRelease)
        {
            isPointerDowning = false;
            isChangingCameraMode = false;
            if (Res2.abs(GameCanvas2.px - ptFirstDownX) > 15 || Res2.abs(GameCanvas2.py - ptFirstDownY) > 15)
            {
                GameCanvas2.isPointerJustRelease = false;
            }
        }
    }

    private void checkClick()
    {
        if (isCharging())
        {
            return;
        }
        if (popUpYesNo != null && popUpYesNo.cmdYes != null && popUpYesNo.cmdYes.isPointerPressInside())
        {
            popUpYesNo.cmdYes.performAction();
        }
        else
        {
            if (checkClickToCapcha())
            {
                return;
            }
            long num = mSystem2.currentTimeMillis();
            if (lastSingleClick != 0)
            {
                lastSingleClick = 0L;
                GameCanvas2.isPointerJustDown = false;
                if (!disableSingleClick)
                {
                    checkSingleClick();
                    GameCanvas2.isPointerJustRelease = false;
                    isWaitingDoubleClick = true;
                    timeStartDblClick = mSystem2.currentTimeMillis();
                }
            }
            if (isWaitingDoubleClick)
            {
                timeEndDblClick = mSystem2.currentTimeMillis();
                if (timeEndDblClick - timeStartDblClick < 300 && GameCanvas2.isPointerJustRelease)
                {
                    isWaitingDoubleClick = false;
                    checkDoubleClick();
                }
            }
            if (GameCanvas2.isPointerJustRelease)
            {
                disableSingleClick = checkSingleClickEarly();
                lastSingleClick = num;
                lastClickCMX = cmx;
                lastClickCMY = cmy;
                GameCanvas2.isPointerJustRelease = false;
            }
        }
    }

    private IMapObject2 findClickToItem(int px, int py)
    {
        IMapObject2 mapObject = null;
        int num = 0;
        int num2 = 30;
        MyVector2[] array = new MyVector2[4] { vMob, vNpc, vItemMap, vCharInMap };
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].size(); j++)
            {
                IMapObject2 mapObject2 = (IMapObject2)array[i].elementAt(j);
                if (mapObject2.isInvisible())
                {
                    continue;
                }
                if (mapObject2 is Mob2)
                {
                    Mob2 mob = (Mob2)mapObject2;
                    if (mob.isMobMe && mob.Equals(Char2.myCharz().mobMe))
                    {
                        continue;
                    }
                }
                int x = mapObject2.getX();
                int y = mapObject2.getY();
                int w = mapObject2.getW();
                int h = mapObject2.getH();
                if (!inRectangle(px, py, x - w / 2 - num2, y - h - num2, w + num2 * 2, h + num2 * 2))
                {
                    continue;
                }
                if (mapObject == null)
                {
                    mapObject = mapObject2;
                    num = Res2.abs(px - x) + Res2.abs(py - y);
                    if (i == 1)
                    {
                        return mapObject;
                    }
                }
                else
                {
                    int num3 = Res2.abs(px - x) + Res2.abs(py - y);
                    if (num3 < num)
                    {
                        mapObject = mapObject2;
                        num = num3;
                    }
                }
            }
        }
        return mapObject;
    }

    private Mob2 findClickToMOB(int px, int py)
    {
        int num = 30;
        Mob2 mob = null;
        int num2 = 0;
        for (int i = 0; i < vMob.size(); i++)
        {
            Mob2 mob2 = (Mob2)vMob.elementAt(i);
            if (mob2.isInvisible())
            {
                continue;
            }
            if (mob2 != null)
            {
                Mob2 mob3 = mob2;
                if (mob3.isMobMe && mob3.Equals(Char2.myCharz().mobMe))
                {
                    continue;
                }
            }
            int x = mob2.getX();
            int y = mob2.getY();
            int w = mob2.getW();
            int h = mob2.getH();
            if (!inRectangle(px, py, x - w / 2 - num, y - h - num, w + num * 2, h + num * 2))
            {
                continue;
            }
            if (mob == null)
            {
                mob = mob2;
                num2 = Res2.abs(px - x) + Res2.abs(py - y);
                continue;
            }
            int num3 = Res2.abs(px - x) + Res2.abs(py - y);
            if (num3 < num2)
            {
                mob = mob2;
                num2 = num3;
            }
        }
        return mob;
    }

    private bool inRectangle(int xClick, int yClick, int x, int y, int w, int h)
    {
        return xClick >= x && xClick <= x + w && yClick >= y && yClick <= y + h;
    }

    private bool checkSingleClickEarly()
    {
        int num = GameCanvas2.px + cmx;
        int num2 = GameCanvas2.py + cmy;
        Char2.myCharz().cancelAttack();
        IMapObject2 mapObject = findClickToItem(num, num2);
        if (mapObject != null)
        {
            if (Char2.myCharz().isAttacPlayerStatus() && Char2.myCharz().charFocus != null && !mapObject.Equals(Char2.myCharz().charFocus) && !mapObject.Equals(Char2.myCharz().charFocus.mobMe) && mapObject is Char2)
            {
                Char2 @char = (Char2)mapObject;
                if (@char.cTypePk != 5 && !@char.isAttacPlayerStatus())
                {
                    checkClickMoveTo(num, num2, 2);
                    return false;
                }
            }
            if (Char2.myCharz().mobFocus == mapObject || Char2.myCharz().itemFocus == mapObject)
            {
                doDoubleClickToObj(mapObject);
                return true;
            }
            if (TileMap2.mapID == 51 && mapObject.Equals(Char2.myCharz().npcFocus))
            {
                checkClickMoveTo(num, num2, 3);
                return false;
            }
            if (Char2.myCharz().skillPaint != null || Char2.myCharz().arr != null || Char2.myCharz().dart != null || Char2.myCharz().skillInfoPaint() != null)
            {
                return false;
            }
            Char2.myCharz().FocusManualTo(mapObject);
            mapObject.stopMoving();
            return false;
        }
        return false;
    }

    private void checkDoubleClick()
    {
        int num = GameCanvas2.px + lastClickCMX;
        int num2 = GameCanvas2.py + lastClickCMY;
        int cy = Char2.myCharz().cy;
        if (isLockKey)
        {
            return;
        }
        IMapObject2 mapObject = findClickToItem(num, num2);
        if (mapObject != null)
        {
            if (mapObject is Mob2 && !isMeCanAttackMob((Mob2)mapObject))
            {
                checkClickMoveTo(num, num2, 4);
            }
            else
            {
                if (checkClickToBotton(mapObject) || (!mapObject.Equals(Char2.myCharz().npcFocus) && mobCapcha != null))
                {
                    return;
                }
                if (Char2.myCharz().isAttacPlayerStatus() && Char2.myCharz().charFocus != null && !mapObject.Equals(Char2.myCharz().charFocus) && !mapObject.Equals(Char2.myCharz().charFocus.mobMe) && mapObject is Char2)
                {
                    Char2 @char = (Char2)mapObject;
                    if (@char.cTypePk != 5 && !@char.isAttacPlayerStatus())
                    {
                        checkClickMoveTo(num, num2, 5);
                        return;
                    }
                }
                if (TileMap2.mapID == 51 && mapObject.Equals(Char2.myCharz().npcFocus))
                {
                    checkClickMoveTo(num, num2, 6);
                }
                else
                {
                    doDoubleClickToObj(mapObject);
                }
            }
        }
        else if (!checkClickToPopup(num, num2) && !checkClipTopChatPopUp(num, num2) && !Main2.isPC)
        {
            checkClickMoveTo(num, num2, 7);
        }
    }

    public bool checkClickToBotton(IMapObject2 Object)
    {
        if (Object == null)
        {
            return false;
        }
        int y = Object.getY();
        int num = Char2.myCharz().cy;
        if (y < num)
        {
            while (y < num)
            {
                num -= 5;
                if (TileMap2.tileTypeAt(Char2.myCharz().cx, num, 8192))
                {
                    auto = 0;
                    Char2.myCharz().cancelAttack();
                    Char2.myCharz().currentMovePoint = null;
                    return true;
                }
            }
        }
        return false;
    }

    private void doDoubleClickToObj(IMapObject2 obj)
    {
        if (obj.Equals(Char2.myCharz().mobFocus) && PickMob2.tanSat && PickMob2.TypeMobsTanSat.Count != 0 && !PickMob2.TypeMobsTanSat.Contains(((Mob2)obj).templateId))
        {
            info1.addInfo("Quái đang đánh không có trong danh sách tàn sát", 0);
        }
        if ((obj.Equals(Char2.myCharz().npcFocus) || mobCapcha == null) && !checkClickToBotton(obj))
        {
            checkEffToObj(obj, isnew: false);
            Char2.myCharz().cancelAttack();
            Char2.myCharz().currentMovePoint = null;
            Char2.myCharz().cvx = (Char2.myCharz().cvy = 0);
            obj.stopMoving();
            auto = 10;
            doFire(isFireByShortCut: false, skipWaypoint: true);
            clickToX = obj.getX();
            clickToY = obj.getY();
            clickOnTileTop = false;
            clickMoving = true;
            clickMovingRed = true;
            clickMovingTimeOut = 20;
            clickMovingP1 = 30;
        }
    }

    private void checkSingleClick()
    {
        int xClick = GameCanvas2.px + lastClickCMX;
        int yClick = GameCanvas2.py + lastClickCMY;
        if (!isLockKey && !checkClickToPopup(xClick, yClick) && !checkClipTopChatPopUp(xClick, yClick))
        {
            checkClickMoveTo(xClick, yClick, 0);
        }
    }

    private bool checkClipTopChatPopUp(int xClick, int yClick)
    {
        if (Equals(info2) && gI().popUpYesNo != null)
        {
            return false;
        }
        if (info2.info.info != null && info2.info.info.charInfo != null)
        {
            int num = 0;
            int num2 = 0;
            num = Res2.abs(info2.cmx) + info2.info.X - 40;
            num2 = Res2.abs(info2.cmy) + info2.info.Y;
            if (inRectangle(xClick - cmx, yClick - cmy, num, num2, 200, info2.info.H))
            {
                info2.doClick(10);
                return true;
            }
        }
        return false;
    }

    private bool checkClickToPopup(int xClick, int yClick)
    {
        for (int i = 0; i < PopUp2.vPopups.size(); i++)
        {
            PopUp2 popUp = (PopUp2)PopUp2.vPopups.elementAt(i);
            if (inRectangle(xClick, yClick, popUp.cx, popUp.cy, popUp.cw, popUp.ch))
            {
                if (popUp.cy <= 24 && TileMap2.isInAirMap() && Char2.myCharz().cTypePk != 0)
                {
                    return false;
                }
                if (popUp.isPaint)
                {
                    popUp.doClick(10);
                    return true;
                }
            }
        }
        return false;
    }

    private void checkClickMoveTo(int xClick, int yClick, int index)
    {
        if (gamePad.disableClickMove() || ChatTextField2.gI().isShow)
        {
            return;
        }
        Char2.myCharz().cancelAttack();
        if (xClick < TileMap2.pxw && xClick > TileMap2.pxw - 32)
        {
            Char2.myCharz().currentMovePoint = new MovePoint2(TileMap2.pxw, yClick);
            return;
        }
        if (xClick < 32 && xClick > 0)
        {
            Char2.myCharz().currentMovePoint = new MovePoint2(0, yClick);
            return;
        }
        if (xClick < TileMap2.pxw && xClick > TileMap2.pxw - 48)
        {
            Char2.myCharz().currentMovePoint = new MovePoint2(TileMap2.pxw, yClick);
            return;
        }
        if (xClick < 48 && xClick > 0)
        {
            Char2.myCharz().currentMovePoint = new MovePoint2(0, yClick);
            return;
        }
        clickToX = xClick;
        clickToY = yClick;
        clickOnTileTop = false;
        Char2.myCharz().delayFall = 0;
        int num = ((!Char2.myCharz().canFly || Char2.myCharz().cMP <= 0) ? 1000 : 0);
        if (clickToY > Char2.myCharz().cy && Res2.abs(clickToX - Char2.myCharz().cx) < 12)
        {
            return;
        }
        for (int i = 0; i < 60 + num && clickToY + i < TileMap2.pxh - 24; i += 24)
        {
            if (TileMap2.tileTypeAt(clickToX, clickToY + i, 2))
            {
                clickToY = TileMap2.tileYofPixel(clickToY + i);
                clickOnTileTop = true;
                break;
            }
        }
        for (int j = 0; j < 40 + num; j += 24)
        {
            if (TileMap2.tileTypeAt(clickToX, clickToY - j, 2))
            {
                clickToY = TileMap2.tileYofPixel(clickToY - j);
                clickOnTileTop = true;
                break;
            }
        }
        clickMoving = true;
        clickMovingRed = false;
        clickMovingP1 = ((!clickOnTileTop) ? 30 : ((yClick >= clickToY) ? clickToY : yClick));
        Char2.myCharz().delayFall = 0;
        if (!clickOnTileTop && clickToY < Char2.myCharz().cy - 50)
        {
            Char2.myCharz().delayFall = 20;
        }
        clickMovingTimeOut = 30;
        auto = 0;
        if (Char2.myCharz().holder)
        {
            Char2.myCharz().removeHoleEff();
        }
        Char2.myCharz().currentMovePoint = new MovePoint2(clickToX, clickToY);
        Char2.myCharz().cdir = ((Char2.myCharz().cx - Char2.myCharz().currentMovePoint.xEnd <= 0) ? 1 : (-1));
        Char2.myCharz().endMovePointCommand = null;
        isAutoPlay = false;
    }

    private void checkAuto()
    {
        long num = mSystem2.currentTimeMillis();
        if (GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21] || GameCanvas2.keyPressed[(!Main2.isPC) ? 4 : 23] || GameCanvas2.keyPressed[(!Main2.isPC) ? 6 : 24] || GameCanvas2.keyPressed[1] || GameCanvas2.keyPressed[3])
        {
            auto = 0;
            isAutoPlay = false;
        }
        if (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] && !isPaintPopup())
        {
            if (auto == 0)
            {
                if (num - lastFire < 800 && checkSkillValid2() && (Char2.myCharz().mobFocus != null || (Char2.myCharz().charFocus != null && Char2.myCharz().isMeCanAttackOtherPlayer(Char2.myCharz().charFocus))))
                {
                    Res2.outz("toi day");
                    auto = 10;
                    GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
                }
            }
            else
            {
                auto = 0;
                GameCanvas2.keyPressed[(!Main2.isPC) ? 4 : 23] = (GameCanvas2.keyPressed[(!Main2.isPC) ? 6 : 24] = false);
            }
            lastFire = num;
        }
        if (GameCanvas2.gameTick % 5 == 0 && auto > 0 && Char2.myCharz().currentMovePoint == null)
        {
            if (Char2.myCharz().myskill != null && (Char2.myCharz().myskill.template.isUseAlone() || Char2.myCharz().myskill.paintCanNotUseSkill))
            {
                return;
            }
            if ((Char2.myCharz().mobFocus != null && Char2.myCharz().mobFocus.status != 1 && Char2.myCharz().mobFocus.status != 0 && Char2.myCharz().charFocus == null) || (Char2.myCharz().charFocus != null && Char2.myCharz().isMeCanAttackOtherPlayer(Char2.myCharz().charFocus)))
            {
                if (Char2.myCharz().myskill.paintCanNotUseSkill)
                {
                    return;
                }
                doFire(isFireByShortCut: false, skipWaypoint: true);
            }
        }
        if (auto > 1)
        {
            auto--;
        }
    }

    public void doUseHP()
    {
        if (Char2.myCharz().stone || Char2.myCharz().blindEff || Char2.myCharz().holdEffID > 0)
        {
            return;
        }
        long num = mSystem2.currentTimeMillis();
        if (num - lastUsePotion >= 10000)
        {
            if (!Char2.myCharz().doUsePotion())
            {
                info1.addInfo(mResources2.HP_EMPTY, 0);
                return;
            }
            ServerEffect2.addServerEffect(11, Char2.myCharz(), 5);
            ServerEffect2.addServerEffect(104, Char2.myCharz(), 4);
            lastUsePotion = num;
            SoundMn2.gI().eatPeans();
        }
    }

    public void activeSuperPower(int x, int y)
    {
        if (!isSuperPower)
        {
            SoundMn2.gI().bigeExlode();
            isSuperPower = true;
            tPower = 0;
            dxPower = 0;
            xPower = x - cmx;
            yPower = y - cmy;
        }
    }

    public void activeRongThanEff(bool isMe)
    {
        activeRongThan = true;
        isUseFreez = true;
        isMeCallRongThan = true;
        if (isMe)
        {
            Effect2_ me = new Effect2_(20, Char2.myCharz().cx, Char2.myCharz().cy - 77, 2, 8, 1);
            EffecMn2.addEff(me);
        }
    }

    public void hideRongThanEff()
    {
        activeRongThan = false;
        isUseFreez = true;
        isMeCallRongThan = false;
    }

    public void doiMauTroi()
    {
        isRongThanXuatHien = true;
        mautroi = mGraphics2.blendColor(0.4f, 0, GameCanvas2.colorTop[GameCanvas2.colorTop.Length - 1]);
    }

    public void callRongThan(int x, int y)
    {
        Res2.outz("VE RONG THAN O VI TRI x= " + x + " y=" + y);
        doiMauTroi();
        Effect2_ me = new Effect2_((!isRongNamek) ? 17 : 25, x, y - 77, 2, -1, 1);
        EffecMn2.addEff(me);
    }

    public void hideRongThan()
    {
        isRongThanXuatHien = false;
        EffecMn2.removeEff(17);
        if (isRongNamek)
        {
            isRongNamek = false;
            EffecMn2.removeEff(25);
        }
    }

    private void autoPlay()
    {
        if (timeSkill > 0)
        {
            timeSkill--;
        }
        if (!canAutoPlay || isChangeZone || Char2.myCharz().statusMe == 14 || Char2.myCharz().statusMe == 5 || Char2.myCharz().isCharge || Char2.myCharz().isFlyAndCharge || Char2.myCharz().isUseChargeSkill())
        {
            return;
        }
        bool flag = false;
        for (int i = 0; i < vMob.size(); i++)
        {
            Mob2 mob = (Mob2)vMob.elementAt(i);
            if (mob.status != 0 && mob.status != 1)
            {
                flag = true;
            }
        }
        if (!flag)
        {
            return;
        }
        bool flag2 = false;
        for (int j = 0; j < Char2.myCharz().arrItemBag.Length; j++)
        {
            Item2 item = Char2.myCharz().arrItemBag[j];
            if (item != null && item.template.type == 6)
            {
                flag2 = true;
                break;
            }
        }
        if (!flag2 && GameCanvas2.gameTick % 150 == 0)
        {
            Service2.gI().requestPean();
        }
        if (Char2.myCharz().cHP <= Char2.myCharz().cHPFull * 20 / 100 || Char2.myCharz().cMP <= Char2.myCharz().cMPFull * 20 / 100)
        {
            doUseHP();
        }
        if (Char2.myCharz().mobFocus == null || (Char2.myCharz().mobFocus != null && Char2.myCharz().mobFocus.isMobMe))
        {
            for (int k = 0; k < vMob.size(); k++)
            {
                Mob2 mob2 = (Mob2)vMob.elementAt(k);
                if (mob2.status != 0 && mob2.status != 1 && mob2.hp > 0 && !mob2.isMobMe)
                {
                    Char2.myCharz().cx = mob2.x;
                    Char2.myCharz().cy = mob2.y;
                    Char2.myCharz().mobFocus = mob2;
                    Service2.gI().charMove();
                    break;
                }
            }
        }
        else if (Char2.myCharz().mobFocus.hp <= 0 || Char2.myCharz().mobFocus.status == 1 || Char2.myCharz().mobFocus.status == 0)
        {
            Char2.myCharz().mobFocus = null;
        }
        if (Char2.myCharz().mobFocus == null || timeSkill != 0 || (Char2.myCharz().skillInfoPaint() != null && Char2.myCharz().indexSkill < Char2.myCharz().skillInfoPaint().Length && Char2.myCharz().dart != null && Char2.myCharz().arr != null))
        {
            return;
        }
        Skill2 skill = null;
        if (GameCanvas2.isTouch)
        {
            for (int l = 0; l < onScreenSkill.Length; l++)
            {
                if (onScreenSkill[l] == null || onScreenSkill[l].paintCanNotUseSkill || onScreenSkill[l].template.id == 10 || onScreenSkill[l].template.id == 11 || onScreenSkill[l].template.id == 14 || onScreenSkill[l].template.id == 23 || onScreenSkill[l].template.id == 7 || Char2.myCharz().skillInfoPaint() != null || onScreenSkill[l].template.isSkillSpec())
                {
                    continue;
                }
                long num = ((onScreenSkill[l].template.manaUseType == 2) ? 1 : ((onScreenSkill[l].template.manaUseType == 1) ? (onScreenSkill[l].manaUse * Char2.myCharz().cMPFull / 100) : onScreenSkill[l].manaUse));
                if (Char2.myCharz().cMP >= num)
                {
                    if (skill == null)
                    {
                        skill = onScreenSkill[l];
                    }
                    else if (skill.coolDown < onScreenSkill[l].coolDown)
                    {
                        skill = onScreenSkill[l];
                    }
                }
            }
            if (skill != null)
            {
                doSelectSkill(skill, isShortcut: true);
                doDoubleClickToObj(Char2.myCharz().mobFocus);
            }
            return;
        }
        for (int m = 0; m < keySkill.Length; m++)
        {
            if (keySkill[m] == null || keySkill[m].paintCanNotUseSkill || keySkill[m].template.id == 10 || keySkill[m].template.id == 11 || keySkill[m].template.id == 14 || keySkill[m].template.id == 23 || keySkill[m].template.id == 7 || Char2.myCharz().skillInfoPaint() != null)
            {
                continue;
            }
            long num2 = (keySkill[m].template.manaUseType == 2) ? 1 : ((keySkill[m].template.manaUseType == 1) ? (keySkill[m].manaUse * Char2.myCharz().cMPFull / 100) : keySkill[m].manaUse);
            if (Char2.myCharz().cMP >= num2)
            {
                if (skill == null)
                {
                    skill = keySkill[m];
                }
                else if (skill.coolDown < keySkill[m].coolDown)
                {
                    skill = keySkill[m];
                }
            }
        }
        if (skill != null)
        {
            doSelectSkill(skill, isShortcut: true);
            doDoubleClickToObj(Char2.myCharz().mobFocus);
        }
    }

    public void doFire(bool isFireByShortCut, bool skipWaypoint)
    {
        tam++;
        Waypoint2 waypoint = Char2.myCharz().isInEnterOfflinePoint();
        Waypoint2 waypoint2 = Char2.myCharz().isInEnterOnlinePoint();
        if (!skipWaypoint && waypoint != null && (Char2.myCharz().mobFocus == null || (Char2.myCharz().mobFocus != null && Char2.myCharz().mobFocus.templateId == 0)))
        {
            waypoint.popup.command.performAction();
        }
        else if (!skipWaypoint && waypoint2 != null && (Char2.myCharz().mobFocus == null || (Char2.myCharz().mobFocus != null && Char2.myCharz().mobFocus.templateId == 0)))
        {
            waypoint2.popup.command.performAction();
        }
        else
        {
            if ((TileMap2.mapID == 51 && Char2.myCharz().npcFocus != null) || Char2.myCharz().statusMe == 14)
            {
                return;
            }
            Char2.myCharz().cvx = (Char2.myCharz().cvy = 0);
            if (Char2.myCharz().isSelectingSkillUseAlone() && Char2.myCharz().focusToAttack())
            {
                if (checkSkillValid())
                {
                    Char2.myCharz().currentFireByShortcut = isFireByShortCut;
                    Char2.myCharz().useSkillNotFocus();
                }
            }
            else if (isAttack())
            {
                if (Char2.myCharz().isUseChargeSkill() && Char2.myCharz().focusToAttack())
                {
                    if (checkSkillValid())
                    {
                        Char2.myCharz().currentFireByShortcut = isFireByShortCut;
                        Char2.myCharz().sendUseChargeSkill();
                    }
                    else
                    {
                        Char2.myCharz().stopUseChargeSkill();
                    }
                }
                else
                {
                    bool flag = TileMap2.tileTypeAt(Char2.myCharz().cx, Char2.myCharz().cy, 2);
                    Char2.myCharz().setSkillPaint(sks[Char2.myCharz().myskill.skillId], (!flag) ? 1 : 0);
                    if (flag)
                    {
                        Char2.myCharz().delayFall = 20;
                    }
                    Char2.myCharz().currentFireByShortcut = isFireByShortCut;
                }
            }
            if (Char2.myCharz().isSelectingSkillBuffToPlayer())
            {
                auto = 0;
            }
        }
    }

    private void askToPick()
    {
        Npc2 npc = new Npc2(5, 0, -100, 100, 5, info1.charId[Char2.myCharz().cgender][2]);
        string nhatvatpham = mResources2.nhatvatpham;
        string[] menu = new string[2]
        {
            mResources2.YES,
            mResources2.NO
        };
        npc.idItem = 673;
        gI().createMenu(menu, npc);
        ChatPopup2.addChatPopupWithIcon(nhatvatpham, 100000, npc, 5820);
    }

    private void pickItem()
    {
        if (Char2.myCharz().itemFocus == null)
        {
            return;
        }
        if (Char2.myCharz().cx < Char2.myCharz().itemFocus.x)
        {
            Char2.myCharz().cdir = 1;
        }
        else
        {
            Char2.myCharz().cdir = -1;
        }
        int num = Math2.abs(Char2.myCharz().cx - Char2.myCharz().itemFocus.x);
        int num2 = Math2.abs(Char2.myCharz().cy - Char2.myCharz().itemFocus.y);
        if (num <= 40 && num2 < 40)
        {
            GameCanvas2.clearKeyHold();
            GameCanvas2.clearKeyPressed();
            if (Char2.myCharz().itemFocus.template.id != 673)
            {
                Service2.gI().pickItem(Char2.myCharz().itemFocus.itemMapID);
            }
            else
            {
                askToPick();
            }
        }
        else
        {
            Char2.myCharz().currentMovePoint = new MovePoint2(Char2.myCharz().itemFocus.x, Char2.myCharz().itemFocus.y);
            Char2.myCharz().endMovePointCommand = new Command2(null, null, 8002, null);
            GameCanvas2.clearKeyHold();
            GameCanvas2.clearKeyPressed();
        }
    }

    public bool isCharging()
    {
        if (Char2.myCharz().isFlyAndCharge || Char2.myCharz().isUseSkillAfterCharge || Char2.myCharz().isStandAndCharge || Char2.myCharz().isWaitMonkey || isSuperPower || Char2.myCharz().isFreez)
        {
            return true;
        }
        return false;
    }

    public void doSelectSkill(Skill2 skill, bool isShortcut)
    {
        if (Char2.myCharz().isCreateDark || isCharging() || Char2.myCharz().taskMaint.taskId <= 1)
        {
            return;
        }
        // if (Char2.myCharz().myskill != skill && (Char2.myCharz().dart != null || Char2.myCharz().arr != null || Char2.myCharz().skillInfoPaint() != null))
        // {
        //     return;
        // }
        Char2.myCharz().myskill = skill;
        if (lastSkill != skill && lastSkill != null)
        {
            Service2.gI().selectSkill(skill.template.id);
            saveRMSCurrentSkill(skill.template.id);
            lastSkill = skill;
            selectedIndexSkill = -1;
            gI().auto = 0;
            return;
        }
        if (Char2.myCharz().isUseSkillSpec())
        {
            Char2.myCharz().sendNewAttack(skill.template.id);
            saveRMSCurrentSkill(skill.template.id);
            lastSkill = skill;
            selectedIndexSkill = -1;
            gI().auto = 0;
            return;
        }
        if (Char2.myCharz().isSelectingSkillUseAlone())
        {
            doUseSkillNotFocus(skill);
            lastSkill = skill;
            return;
        }
        selectedIndexSkill = -1;
        if (skill == null)
        {
            return;
        }
        if (lastSkill != skill)
        {
            Service2.gI().selectSkill(skill.template.id);
            saveRMSCurrentSkill(skill.template.id);
        }
        if (Char2.myCharz().charFocus != null || !Char2.myCharz().isSelectingSkillBuffToPlayer())
        {
            if (Char2.myCharz().focusToAttack())
            {
                doFire(isShortcut, skipWaypoint: true);
                doSeleckSkillFlag = true;
            }
            lastSkill = skill;
        }
    }

    public void doUseSkill(Skill2 skill, bool isShortcut)
    {
        if ((TileMap2.mapID == 112 || TileMap2.mapID == 113) && Char2.myCharz().cTypePk == 0)
        {
            return;
        }
        if (Char2.myCharz().isSelectingSkillUseAlone())
        {
            doUseSkillNotFocus(skill);
            return;
        }
        selectedIndexSkill = -1;
        if (skill != null)
        {
            Service2.gI().selectSkill(skill.template.id);
            saveRMSCurrentSkill(skill.template.id);
            resetButton();
            Char2.myCharz().myskill = skill;
            doFire(isShortcut, skipWaypoint: true);
        }
    }

    public void doUseSkillNotFocus(Skill2 skill)
    {
        if (((TileMap2.mapID != 112 && TileMap2.mapID != 113) || Char2.myCharz().cTypePk != 0) && checkSkillValid())
        {
            selectedIndexSkill = -1;
            if (skill != null)
            {
                Service2.gI().selectSkill(skill.template.id);
                saveRMSCurrentSkill(skill.template.id);
                resetButton();
                Char2.myCharz().myskill = skill;
                Char2.myCharz().useSkillNotFocus();
                Char2.myCharz().currentFireByShortcut = true;
                auto = 0;
            }
        }
    }

    public void sortSkill()
    {
        for (int i = 0; i < Char2.myCharz().vSkillFight.size() - 1; i++)
        {
            Skill2 skill = (Skill2)Char2.myCharz().vSkillFight.elementAt(i);
            for (int j = i + 1; j < Char2.myCharz().vSkillFight.size(); j++)
            {
                Skill2 skill2 = (Skill2)Char2.myCharz().vSkillFight.elementAt(j);
                if (skill2.template.id < skill.template.id)
                {
                    Skill2 skill3 = skill2;
                    skill2 = skill;
                    skill = skill3;
                    Char2.myCharz().vSkillFight.setElementAt(skill, i);
                    Char2.myCharz().vSkillFight.setElementAt(skill2, j);
                }
            }
        }
    }

    public void updateKeyTouchCapcha()
    {
        if (isNotPaintTouchControl())
        {
            return;
        }
        for (int i = 0; i < strCapcha.Length; i++)
        {
            keyCapcha[i] = -1;
            if (!GameCanvas2.isTouchControl)
            {
                continue;
            }
            int num = (GameCanvas2.w - strCapcha.Length * disXC) / 2;
            int w = strCapcha.Length * disXC;
            int y = GameCanvas2.h - 40;
            int h = disXC;
            if (!GameCanvas2.isPointerHoldIn(num, y, w, h))
            {
                continue;
            }
            int num2 = (GameCanvas2.px - num) / disXC;
            if (i == num2)
            {
                keyCapcha[i] = 1;
            }
            if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease && i == num2)
            {
                char[] array = keyInput.ToCharArray();
                MyVector2 myVector = new MyVector2();
                for (int j = 0; j < array.Length; j++)
                {
                    myVector.addElement(array[j] + string.Empty);
                }
                myVector.removeElementAt(0);
                myVector.insertElementAt(strCapcha[i] + string.Empty, myVector.size());
                keyInput = string.Empty;
                for (int k = 0; k < myVector.size(); k++)
                {
                    keyInput += ((string)myVector.elementAt(k)).ToUpper();
                }
                Service2.gI().mobCapcha(strCapcha[i]);
            }
        }
    }

    public bool checkClickToCapcha()
    {
        if (mobCapcha == null)
        {
            return false;
        }
        int x = (GameCanvas2.w - 5 * disXC) / 2;
        int w = 5 * disXC;
        int y = GameCanvas2.h - 40;
        int h = disXC;
        if (GameCanvas2.isPointerHoldIn(x, y, w, h))
        {
            return true;
        }
        return false;
    }

    public void checkMouseChat()
    {
        if (GameCanvas2.isMouseFocus(xC, yC, 34, 34))
        {
            if (!TileMap2.isOfflineMap())
            {
                keyMouse = 15;
            }
        }
        else if (GameCanvas2.isMouseFocus(xHP, yHP, 40, 40))
        {
            if (Char2.myCharz().statusMe != 14)
            {
                keyMouse = 10;
            }
        }
        else if (GameCanvas2.isMouseFocus(xF, yF, 40, 40))
        {
            if (Char2.myCharz().statusMe != 14)
            {
                keyMouse = 5;
            }
        }
        else if (cmdMenu != null && GameCanvas2.isMouseFocus(cmdMenu.x, cmdMenu.y, cmdMenu.w / 2, cmdMenu.h))
        {
            keyMouse = 1;
        }
        else
        {
            keyMouse = -1;
        }
    }

    private void UpdateKeyTouchControl()
    {
        if (isNotPaintTouchControl())
        {
            return;
        }
        keyTouch = -1;
        int numY = 52;
        if (MainMod2.notifBoss)
        {
            for (int i = 0; i < MainMod2.bossNotif.size(); i++)
            {
                ShowBoss showBoss = (ShowBoss)MainMod2.bossNotif.elementAt(i);
                if (showBoss == null)
                {
                    continue;
                }
                if (GameCanvas2.isPointerHoldIn(GameCanvas2.w - 5 - showBoss.stringLength, numY + 3, showBoss.stringLength, 10) && GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
                {
                    MainMod2.GI().GoToBoss(showBoss.mapID);
                    GameCanvas2.clearAllPointerEvent();
                    return;
                }
                numY += 10;
            }
            numY += 20;
        }
        if (MainMod2.showCharsInMap)
        {
            MyVector2 chars = MainMod2.GI().charsInMap;
            for (int i = 0; i < chars.size(); i++)
            {
                Char2 @char = (Char2)chars.elementAt(i);
                if (@char != null)
                {
                    if (GameCanvas2.isPointerHoldIn(GameCanvas2.w - 130, numY, 130, 10) && GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
                    {
                        if (Char2.myCharz().charFocus == @char)
                        {
                            MainMod2.MoveTo(@char.cx, @char.cy);
                        }
                        else
                        {
                            Char2.myCharz().FocusManualTo(@char);
                            MainMod2.isLockFocus = true;
                        }
                        Char2.myCharz().currentMovePoint = null;
                        GameCanvas2.clearAllPointerEvent();
                        return;
                    }
                    numY += 10;
                }
            }
        }
        if (GameCanvas2.isTouchControl)
        {
            if (GameCanvas2.isPointerHoldIn(0, 0, 60, 50) && GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
            {
                Char2.myCharz().cmdMenu?.performAction();
                Char2.myCharz().currentMovePoint = null;
                GameCanvas2.clearAllPointerEvent();
                flareFindFocus = true;
                flareTime = 5;
                return;
            }
            if (Main2.isPC)
            {
                checkMouseChat();
            }
            if (!TileMap2.isOfflineMap() && GameCanvas2.isPointerHoldIn(xC, yC, 34, 34))
            {
                keyTouch = 15;
                GameCanvas2.isPointerJustDown = false;
                isPointerDowning = false;
                if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
                {
                    ChatTextField2.gI().startChat(this, string.Empty);
                    SoundMn2.gI().buttonClick();
                    Char2.myCharz().currentMovePoint = null;
                    GameCanvas2.clearAllPointerEvent();
                    return;
                }
            }
            if (Char2.myCharz().cmdMenu != null && GameCanvas2.isPointerHoldIn(Char2.myCharz().cmdMenu.x - 17, Char2.myCharz().cmdMenu.y - 17, 34, 34))
            {
                keyTouch = 20;
                GameCanvas2.isPointerJustDown = false;
                isPointerDowning = false;
                if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
                {
                    GameCanvas2.clearAllPointerEvent();
                    Char2.myCharz().cmdMenu.performAction();
                    return;
                }
            }
            updateGamePad();
            if (((isAnalog != 0) ? GameCanvas2.isPointerHoldIn(xHP, yHP, 34, 34) : GameCanvas2.isPointerHoldIn(xHP, yHP, 40, 40)) && Char2.myCharz().statusMe != 14 && mobCapcha == null)
            {
                keyTouch = 10;
                GameCanvas2.isPointerJustDown = false;
                isPointerDowning = false;
                if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
                {
                    GameCanvas2.keyPressed[10] = true;
                    GameCanvas2.isPointerClick = (GameCanvas2.isPointerJustDown = (GameCanvas2.isPointerJustRelease = false));
                }
            }
        }
        if (mobCapcha != null)
        {
            updateKeyTouchCapcha();
        }
        else if (isHaveSelectSkill)
        {
            if (isCharging())
            {
                return;
            }
            keyTouchSkill = -1;
            bool flag = false;
            if (onScreenSkill.Length > 5 && (GameCanvas2.isPointerHoldIn(xSkill + xS[0] - wSkill / 2 + 12, yS[0] - wSkill / 2 + 12, 5 * wSkill, wSkill) || GameCanvas2.isPointerHoldIn(xSkill + xS[5] - wSkill / 2 + 12, yS[5] - wSkill / 2 + 12, 5 * wSkill, wSkill)))
            {
                flag = true;
            }
            if (flag || GameCanvas2.isPointerHoldIn(xSkill + xS[0] - wSkill / 2 + 12, yS[0] - wSkill / 2 + 12, 5 * wSkill, wSkill) || (!GameCanvas2.isTouchControl && GameCanvas2.isPointerHoldIn(xSkill + xS[0] - wSkill / 2 + 12, yS[0] - wSkill / 2 + 12, wSkill, onScreenSkill.Length * wSkill)))
            {
                GameCanvas2.isPointerJustDown = false;
                isPointerDowning = false;
                int num = (GameCanvas2.pxLast - (xSkill + xS[0] - wSkill / 2 + 12)) / wSkill;
                if (flag && GameCanvas2.pyLast < yS[0])
                {
                    num += 5;
                }
                keyTouchSkill = num;
                if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
                {
                    GameCanvas2.isPointerClick = (GameCanvas2.isPointerJustDown = (GameCanvas2.isPointerJustRelease = false));
                    selectedIndexSkill = num;
                    if (indexSelect < 0)
                    {
                        indexSelect = 0;
                    }
                    if (!Main2.isPC)
                    {
                        if (selectedIndexSkill > onScreenSkill.Length - 1)
                        {
                            selectedIndexSkill = onScreenSkill.Length - 1;
                        }
                    }
                    else if (selectedIndexSkill > keySkill.Length - 1)
                    {
                        selectedIndexSkill = keySkill.Length - 1;
                    }
                    Skill2 skill = null;
                    skill = (Main2.isPC ? keySkill[selectedIndexSkill] : onScreenSkill[selectedIndexSkill]);
                    if (skill != null)
                    {
                        doSelectSkill(skill, isShortcut: true);
                    }
                }
            }
        }
        if (GameCanvas2.isPointerJustRelease)
        {
            if (GameCanvas2.keyHold[1] || GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21] || GameCanvas2.keyHold[3] || GameCanvas2.keyHold[(!Main2.isPC) ? 4 : 23] || GameCanvas2.keyHold[(!Main2.isPC) ? 6 : 24])
            {
                GameCanvas2.isPointerJustRelease = false;
            }
            GameCanvas2.keyHold[1] = false;
            GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21] = false;
            GameCanvas2.keyHold[3] = false;
            GameCanvas2.keyHold[(!Main2.isPC) ? 4 : 23] = false;
            GameCanvas2.keyHold[(!Main2.isPC) ? 6 : 24] = false;
        }
    }

    public void setCharJumpAtt()
    {
        Char2.myCharz().cvy = -10;
        Char2.myCharz().statusMe = 3;
        Char2.myCharz().cp1 = 0;
    }

    public void setCharJump(int cvx)
    {
        if (Char2.myCharz().cx - Char2.myCharz().cxSend != 0 || Char2.myCharz().cy - Char2.myCharz().cySend != 0)
        {
            Service2.gI().charMove();
        }
        Char2.myCharz().cvy = -10;
        Char2.myCharz().cvx = cvx;
        Char2.myCharz().statusMe = 3;
        Char2.myCharz().cp1 = 0;
    }

    public void updateOpen()
    {
        if (isstarOpen)
        {
            if (moveUp > -3)
            {
                moveUp -= 4;
            }
            else
            {
                moveUp = -2;
            }
            if (moveDow < GameCanvas2.h + 3)
            {
                moveDow += 4;
            }
            else
            {
                moveDow = GameCanvas2.h + 2;
            }
            if (moveUp <= -2 && moveDow >= GameCanvas2.h + 2)
            {
                isstarOpen = false;
            }
        }
    }

    public void initCreateCommand()
    {
    }

    public void checkCharFocus()
    {
    }

    public void updateXoSo()
    {
        if (tShow == 0)
        {
            return;
        }
        currXS = mSystem2.currentTimeMillis();
        if (currXS - lastXS > 1000)
        {
            lastXS = mSystem2.currentTimeMillis();
            secondXS++;
        }
        if (secondXS > 20)
        {
            for (int i = 0; i < winnumber.Length; i++)
            {
                randomNumber[i] = winnumber[i];
            }
            tShow--;
            if (tShow == 0)
            {
                yourNumber = string.Empty;
                info1.addInfo(strFinish, 0);
                secondXS = 0;
            }
            return;
        }
        if (moveIndex > winnumber.Length - 1)
        {
            tShow--;
            if (tShow == 0)
            {
                yourNumber = string.Empty;
                info1.addInfo(strFinish, 0);
            }
            return;
        }
        if (moveIndex < randomNumber.Length)
        {
            if (tMove[moveIndex] == 15)
            {
                if (randomNumber[moveIndex] == winnumber[moveIndex] - 1)
                {
                    delayMove[moveIndex] = 10;
                }
                if (randomNumber[moveIndex] == winnumber[moveIndex])
                {
                    tMove[moveIndex] = -1;
                    moveIndex++;
                }
            }
            else if (GameCanvas2.gameTick % 5 == 0)
            {
                tMove[moveIndex]++;
            }
        }
        for (int j = 0; j < winnumber.Length; j++)
        {
            if (tMove[j] == -1)
            {
                continue;
            }
            moveCount[j]++;
            if (moveCount[j] > tMove[j] + delayMove[j])
            {
                moveCount[j] = 0;
                randomNumber[j]++;
                if (randomNumber[j] >= 10)
                {
                    randomNumber[j] = 0;
                }
            }
        }
    }

    public override void update()
    {
        if (MainMod2.GI().canUpdate)
        {
            AutoXmap2.Update();
            MainMod2.GI().Update();
        }
        if (!AutoXmap2.IsXmapRunning)
        {
            PickMob2.Update();
        }
        if (GameCanvas2.keyPressed[16])
        {
            GameCanvas2.keyPressed[16] = false;
            Char2.myCharz().findNextFocusByKey();
        }
        if (GameCanvas2.keyPressed[13] && !GameCanvas2.panel.isShow)
        {
            GameCanvas2.keyPressed[13] = false;
            Char2.myCharz().findNextFocusByKey();
        }
        if (GameCanvas2.keyPressed[17])
        {
            GameCanvas2.keyPressed[17] = false;
            Char2.myCharz().searchItem();
            if (Char2.myCharz().itemFocus != null)
            {
                pickItem();
            }
        }
        if (GameCanvas2.gameTick % 100 == 0 && TileMap2.mapID == 137)
        {
            shock_scr = 30;
        }
        if (!PickMob2.tanSat && isAutoPlay && GameCanvas2.gameTick % 20 == 0)
        {
            autoPlay();
        }
        updateXoSo();
        mSystem2.checkAdComlete();
        SmallImage2.update();
        try
        {
            if (LoginScr2.isContinueToLogin)
            {
                LoginScr2.isContinueToLogin = false;
            }
            if (tickMove == 1)
            {
                lastTick = mSystem2.currentTimeMillis();
            }
            if (tickMove == 100)
            {
                tickMove = 0;
                currTick = mSystem2.currentTimeMillis();
                int second = (int)(currTick - lastTick) / 1000;
                Service2.gI().checkMMove(second);
            }
            if (lockTick > 0)
            {
                lockTick--;
                if (lockTick == 0)
                {
                    Controller2_.isStopReadMessage = false;
                }
            }
            checkCharFocus();
            GameCanvas2.debug("E1", 0);
            updateCamera();
            GameCanvas2.debug("E2", 0);
            ChatTextField2.gI().update();
            GameCanvas2.debug("E3", 0);
            for (int i = 0; i < vCharInMap.size(); i++)
            {
                ((Char2)vCharInMap.elementAt(i)).update();
            }
            for (int i = 0; i < Teleport2.vTeleport.size(); i++)
            {
                ((Teleport2)Teleport2.vTeleport.elementAt(i)).update();
            }
            Char2.myCharz().update();
            if (Char2.myCharz().statusMe == 1)
            {
            }
            if (popUpYesNo != null)
            {
                popUpYesNo.update();
            }
            EffecMn2.update();
            GameCanvas2.debug("E5x", 0);
            for (int i = 0; i < vMob.size(); i++)
            {
                ((Mob2)vMob.elementAt(i)).update();
            }
            GameCanvas2.debug("E6", 0);
            for (int i = 0; i < vNpc.size(); i++)
            {
                ((Npc2)vNpc.elementAt(i)).update();
            }
            nSkill = onScreenSkill.Length;
            for (int i = onScreenSkill.Length - 1; i >= 0; i--)
            {
                Skill2 skill = onScreenSkill[i];
                if (skill != null)
                {
                    nSkill = i + 1;
                    break;
                }
                nSkill--;
            }
            if (nSkill == 1 && GameCanvas2.isTouch)
            {
                xSkill = -200;
            }
            else if (xSkill < 0)
            {
                setSkillBarPosition();
            }
            GameCanvas2.debug("E7", 0);
            GameCanvas2.gI().updateDust();
            GameCanvas2.debug("E8", 0);
            updateFlyText();
            PopUp2.updateAll();
            updateSplash();
            updateSS();
            GameCanvas2.updateBG();
            GameCanvas2.debug("E9", 0);
            updateClickToArrow();
            GameCanvas2.debug("E10", 0);
            for (int i = 0; i < vItemMap.size(); i++)
            {
                ((ItemMap2)vItemMap.elementAt(i)).update();
            }
            GameCanvas2.debug("E11", 0);
            GameCanvas2.debug("E13", 0);
            for (int i = Effect2_2.vRemoveEffect2.size() - 1; i >= 0; i--)
            {
                Effect2_2.vEffect2.removeElement(Effect2_2.vRemoveEffect2.elementAt(i));
                Effect2_2.vRemoveEffect2.removeElementAt(i);
            }
            for (int i = 0; i < Effect2_2.vEffect2.size(); i++)
            {
                Effect2_2 effect = (Effect2_2)Effect2_2.vEffect2.elementAt(i);
                effect.update();
            }
            for (int i = 0; i < Effect2_2.vEffect2Outside.size(); i++)
            {
                Effect2_2 effect2 = (Effect2_2)Effect2_2.vEffect2Outside.elementAt(i);
                effect2.update();
            }
            for (int i = 0; i < Effect2_2.vAnimateEffect.size(); i++)
            {
                Effect2_2 effect3 = (Effect2_2)Effect2_2.vAnimateEffect.elementAt(i);
                effect3.update();
            }
            for (int i = 0; i < Effect2_2.vEffectFeet.size(); i++)
            {
                Effect2_2 effect4 = (Effect2_2)Effect2_2.vEffectFeet.elementAt(i);
                effect4.update();
            }
            for (int i = 0; i < Effect2_2.vEffect3.size(); i++)
            {
                Effect2_2 effect5 = (Effect2_2)Effect2_2.vEffect3.elementAt(i);
                effect5.update();
            }
            BackgroudEffect2.updateEff();
            info1.update();
            info2.update();
            GameCanvas2.debug("E15", 0);
            if (currentCharViewInfo != null && !currentCharViewInfo.Equals(Char2.myCharz()))
            {
                currentCharViewInfo.update();
            }
            runArrow++;
            if (runArrow > 3)
            {
                runArrow = 0;
            }
            if (isInjureHp)
            {
                twHp++;
                if (twHp == 20)
                {
                    twHp = 0;
                    isInjureHp = false;
                }
            }
            else if (dHP > Char2.myCharz().cHP)
            {
                long num = dHP - Char2.myCharz().cHP >> 1;
                if (num < 1)
                {
                    num = 1;
                }
                dHP -= num;
            }
            else
            {
                dHP = Char2.myCharz().cHP;
            }
            if (isInjureMp)
            {
                twMp++;
                if (twMp == 20)
                {
                    twMp = 0;
                    isInjureMp = false;
                }
            }
            else if (dMP > Char2.myCharz().cMP)
            {
                long num2 = dMP - Char2.myCharz().cMP >> 1;
                if (num2 < 1)
                {
                    num2 = 1;
                }
                dMP -= num2;
            }
            else
            {
                dMP = Char2.myCharz().cMP;
            }
            if (tMenuDelay > 0)
            {
                tMenuDelay--;
            }
            if (isRongThanMenu())
            {
                int num3 = 100;
                while (yR - num3 < cmy)
                {
                    cmy--;
                }
            }
            for (int i = 0; i < Char2.vItemTime.size(); i++)
            {
                ((ItemTime2)Char2.vItemTime.elementAt(i)).update();
            }
            for (int i = 0; i < textTime.size(); i++)
            {
                ((ItemTime2)textTime.elementAt(i)).update();
            }
            updateChatVip();
        }
        catch (Exception)
        {
        }
        int num4 = GameCanvas2.gameTick % 4000;
        if (num4 == 1000)
        {
            checkRemoveImage();
        }
        EffectManager2.update();
    }

    public void updateKeyChatPopUp()
    {
    }

    public bool isRongThanMenu()
    {
        if (isMeCallRongThan)
        {
            return true;
        }
        return false;
    }

    public void paintEffect(mGraphics2 g)
    {
        for (int i = 0; i < Effect2_2.vEffect2.size(); i++)
        {
            Effect2_2 effect = (Effect2_2)Effect2_2.vEffect2.elementAt(i);
            if (effect != null && !(effect is ChatPopup2))
            {
                effect.paint(g);
            }
        }
        if (!GameCanvas2.lowGraphic)
        {
            for (int i = 0; i < Effect2_2.vAnimateEffect.size(); i++)
            {
                Effect2_2 effect2 = (Effect2_2)Effect2_2.vAnimateEffect.elementAt(i);
                effect2.paint(g);
            }
        }
        for (int i = 0; i < Effect2_2.vEffect2Outside.size(); i++)
        {
            Effect2_2 effect3 = (Effect2_2)Effect2_2.vEffect2Outside.elementAt(i);
            effect3.paint(g);
        }
    }

    public void paintBgItem(mGraphics2 g, int layer)
    {
        for (int i = 0; i < TileMap2.vCurrItem.size(); i++)
        {
            BgItem2 bgItem = (BgItem2)TileMap2.vCurrItem.elementAt(i);
            if (bgItem.idImage != -1 && bgItem.layer == layer)
            {
                bgItem.paint(g);
            }
        }
        if (TileMap2.mapID == 48 && layer == 3 && GameCanvas2.bgW != null && GameCanvas2.bgW[0] != 0)
        {
            for (int j = 0; j < TileMap2.pxw / GameCanvas2.bgW[0] + 1; j++)
            {
                g.drawImage(GameCanvas2.imgBG[0], j * GameCanvas2.bgW[0], TileMap2.pxh - GameCanvas2.bgH[0] - 70, 0);
            }
        }
    }

    public void paintBlackSky(mGraphics2 g)
    {
        if (!GameCanvas2.lowGraphic)
        {
            g.fillTrans(imgTrans, 0, 0, GameCanvas2.w, GameCanvas2.h);
        }
    }

    public void paintCapcha(mGraphics2 g)
    {
        MobCapcha2.paint(g, Char2.myCharz().cx, Char2.myCharz().cy);
        g.translate(-g.getTranslateX(), -g.getTranslateY());
        if (GameCanvas2.menu.showMenu || GameCanvas2.panel.isShow || ChatPopup2.currChatPopup != null || !GameCanvas2.isTouch)
        {
            return;
        }
        for (int i = 0; i < strCapcha.Length; i++)
        {
            int x = (GameCanvas2.w - strCapcha.Length * disXC) / 2 + i * disXC + disXC / 2;
            if (keyCapcha[i] == -1)
            {
                g.drawImage(imgNut, x, GameCanvas2.h - 25, 3);
                mFont2.tahoma_7b_dark.drawString(g, strCapcha[i] + string.Empty, x, GameCanvas2.h - 30, 2);
            }
            else
            {
                g.drawImage(imgNutF, x, GameCanvas2.h - 25, 3);
                mFont2.tahoma_7b_green2.drawString(g, strCapcha[i] + string.Empty, x, GameCanvas2.h - 30, 2);
            }
        }
    }

    public override void paint(mGraphics2 g)
    {
        countEff = 0;
        if (!isPaint)
        {
            Thread.Sleep(2);
            return;
        }
        if (isFreez || (isUseFreez && ChatPopup2.currChatPopup == null))
        {
            dem++;
            if ((dem < 30 && dem >= 0 && GameCanvas2.gameTick % 4 == 0) || (dem >= 30 && dem <= 50 && GameCanvas2.gameTick % 3 == 0) || dem > 50)
            {
                g.setColor(16777215);
                g.fillRect(0, 0, GameCanvas2.w, GameCanvas2.h);
                if (dem <= 50)
                {
                    return;
                }
                if (isUseFreez)
                {
                    isUseFreez = false;
                    dem = 0;
                    if (activeRongThan)
                    {
                        callRongThan(xR, yR);
                    }
                    else
                    {
                        hideRongThan();
                    }
                }
                paintInfoBar(g);
                g.translate(-cmx, -cmy);
                g.translate(0, GameCanvas2.transY);
                Char2.myCharz().paint(g);
                mSystem2.paintFlyText(g);
                resetTranslate(g);
                paintSelectedSkill(g);
                return;
            }
        }
        GameCanvas2.paintBGGameScr(g);
        paint_ios_bg(g);
        if ((isRongThanXuatHien || isFireWorks) && TileMap2.bgID != 3)
        {
            paintBlackSky(g);
        }
        GameCanvas2.debug("PA3", 1);
        if (shock_scr > 0)
        {
            g.translate(-cmx + shock_x[shock_scr % shock_x.Length], -cmy + shock_y[shock_scr % shock_y.Length]);
            shock_scr--;
        }
        else
        {
            g.translate(-cmx, -cmy);
        }
        if (isSuperPower)
        {
            int tx = ((GameCanvas2.gameTick % 3 != 0) ? (-3) : 3);
            g.translate(tx, 0);
        }
        BackgroudEffect2.paintBehindTileAll(g);
        EffecMn2.paintLayer1(g);
        TileMap2.paintTilemap(g);
        TileMap2.paintOutTilemap(g);
        for (int i = 0; i < vCharInMap.size(); i++)
        {
            Char2 @char = (Char2)vCharInMap.elementAt(i);
            if (@char.isMabuHold && TileMap2.mapID == 128)
            {
                @char.paintHeadWithXY(g, @char.cx, @char.cy, 0);
            }
        }
        if (Char2.myCharz().isMabuHold && TileMap2.mapID == 128)
        {
            Char2.myCharz().paintHeadWithXY(g, Char2.myCharz().cx, Char2.myCharz().cy, 0);
        }
        paintBgItem(g, 2);
        if (Char2.myCharz().cmdMenu != null && GameCanvas2.isTouch)
        {
            if (keyTouch == 20)
            {
                g.drawImage(imgChat2, Char2.myCharz().cmdMenu.x + cmx, Char2.myCharz().cmdMenu.y + cmy, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }
            else
            {
                g.drawImage(imgChat, Char2.myCharz().cmdMenu.x + cmx, Char2.myCharz().cmdMenu.y + cmy, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }
        }
        GameCanvas2.debug("PA4", 1);
        GameCanvas2.debug("PA5", 1);
        BackgroudEffect2.paintBackAll(g);
        EffectManager2.lowEffects.paintAll(g);
        for (int i = 0; i < Effect2_2.vEffectFeet.size(); i++)
        {
            Effect2_2 effect = (Effect2_2)Effect2_2.vEffectFeet.elementAt(i);
            effect.paint(g);
        }
        for (int i = 0; i < Teleport2.vTeleport.size(); i++)
        {
            ((Teleport2)Teleport2.vTeleport.elementAt(i)).paintHole(g);
        }
        for (int i = 0; i < vNpc.size(); i++)
        {
            Npc2 npc = (Npc2)vNpc.elementAt(i);
            if (npc.cHP > 0)
            {
                npc.paintShadow(g);
            }
        }
        for (int i = 0; i < vNpc.size(); i++)
        {
            ((Npc2)vNpc.elementAt(i)).paint(g);
        }
        g.translate(0, GameCanvas2.transY);
        GameCanvas2.debug("PA7", 1);
        GameCanvas2.debug("PA8", 1);
        for (int i = 0; i < vCharInMap.size(); i++)
        {
            Char2 char2 = null;
            try
            {
                char2 = (Char2)vCharInMap.elementAt(i);
            }
            catch (Exception ex)
            {
                Cout2.LogError("Loi ham paint char gamesc: " + ex.ToString());
            }
            if (char2 != null && (!GameCanvas2.panel.isShow || !GameCanvas2.panel.isTypeShop()) && char2.isShadown)
            {
                char2.paintShadow(g);
            }
        }
        Char2.myCharz().paintShadow(g);
        EffecMn2.paintLayer2(g);
        for (int i = 0; i < vMob.size(); i++)
        {
            ((Mob2)vMob.elementAt(i)).paint(g);
        }
        for (int i = 0; i < Teleport2.vTeleport.size(); i++)
        {
            ((Teleport2)Teleport2.vTeleport.elementAt(i)).paint(g);
        }
        for (int i = 0; i < vCharInMap.size(); i++)
        {
            Char2 char3 = null;
            try
            {
                char3 = (Char2)vCharInMap.elementAt(i);
            }
            catch (Exception)
            {
            }
            if (char3 != null && (!GameCanvas2.panel.isShow || !GameCanvas2.panel.isTypeShop()))
            {
                char3.paint(g);
            }
        }
        Char2.myCharz().paint(g);
        if (Char2.myCharz().skillPaint != null && Char2.myCharz().skillInfoPaint() != null && Char2.myCharz().indexSkill < Char2.myCharz().skillInfoPaint().Length)
        {
            Char2.myCharz().paintCharWithSkill(g);
            Char2.myCharz().paintMount2(g);
        }
        for (int i = 0; i < vCharInMap.size(); i++)
        {
            Char2 char4 = null;
            try
            {
                char4 = (Char2)vCharInMap.elementAt(i);
            }
            catch (Exception ex3)
            {
                Cout2.LogError("Loi ham paint char gamescr: " + ex3.ToString());
            }
            if (char4 != null && (!GameCanvas2.panel.isShow || !GameCanvas2.panel.isTypeShop()) && char4.skillPaint != null && char4.skillInfoPaint() != null && char4.indexSkill < char4.skillInfoPaint().Length)
            {
                char4.paintCharWithSkill(g);
                char4.paintMount2(g);
            }
        }
        for (int i = 0; i < vItemMap.size(); i++)
        {
            ((ItemMap2)vItemMap.elementAt(i)).paint(g);
        }
        g.translate(0, -GameCanvas2.transY);
        GameCanvas2.debug("PA9", 1);
        paintSplash(g);
        GameCanvas2.debug("PA10", 1);
        GameCanvas2.debug("PA11", 1);
        GameCanvas2.debug("PA13", 1);
        paintEffect(g);
        paintBgItem(g, 3);
        for (int i = 0; i < vNpc.size(); i++)
        {
            Npc2 npc2 = (Npc2)vNpc.elementAt(i);
            npc2.paintName(g);
        }
        EffecMn2.paintLayer3(g);
        for (int i = 0; i < vNpc.size(); i++)
        {
            Npc2 npc3 = (Npc2)vNpc.elementAt(i);
            if (npc3.chatInfo != null)
            {
                npc3?.chatInfo.paint(g, npc3.cx, npc3.cy - npc3.ch - GameCanvas2.transY, npc3.cdir);
            }
        }
        for (int i = 0; i < vCharInMap.size(); i++)
        {
            Char2 char5 = null;
            try
            {
                char5 = (Char2)vCharInMap.elementAt(i);
            }
            catch (Exception)
            {
            }
            if (char5 != null && char5.chatInfo != null)
            {
                char5.chatInfo.paint(g, char5.cx, char5.cy - char5.ch, char5.cdir);
            }
        }
        if (Char2.myCharz().chatInfo != null)
        {
            Char2.myCharz().chatInfo.paint(g, Char2.myCharz().cx, Char2.myCharz().cy - Char2.myCharz().ch, Char2.myCharz().cdir);
        }
        EffectManager2.mid_2Effects.paintAll(g);
        EffectManager2.midEffects.paintAll(g);
        BackgroudEffect2.paintFrontAll(g);
        for (int j = 0; j < TileMap2.vCurrItem.size(); j++)
        {
            BgItem2 bgItem = (BgItem2)TileMap2.vCurrItem.elementAt(j);
            if (bgItem.idImage != -1 && bgItem.layer > 3)
            {
                bgItem.paint(g);
            }
        }
        PopUp2.paintAll(g);
        if (TileMap2.mapID == 120)
        {
            if (percentMabu != 100)
            {
                int w = percentMabu * mGraphics2.getImageWidth(imgHPLost) / 100;
                int num = percentMabu;
                g.drawImage(imgHPLost, TileMap2.pxw / 2 - mGraphics2.getImageWidth(imgHPLost) / 2, 220, 0);
                g.setClip(TileMap2.pxw / 2 - mGraphics2.getImageWidth(imgHPLost) / 2, 220, w, 10);
                g.drawImage(imgHP, TileMap2.pxw / 2 - mGraphics2.getImageWidth(imgHPLost) / 2, 220, 0);
                g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
            }
            if (mabuEff)
            {
                tMabuEff++;
                if (GameCanvas2.gameTick % 3 == 0)
                {
                    Effect2_ me = new Effect2_(19, Res2.random(TileMap2.pxw / 2 - 50, TileMap2.pxw / 2 + 50), 340, 2, 1, -1);
                    EffecMn2.addEff(me);
                }
                if (GameCanvas2.gameTick % 15 == 0)
                {
                    Effect2_ me2 = new Effect2_(18, Res2.random(TileMap2.pxw / 2 - 5, TileMap2.pxw / 2 + 5), Res2.random(300, 320), 2, 1, -1);
                    EffecMn2.addEff(me2);
                }
                if (tMabuEff == 100)
                {
                    activeSuperPower(TileMap2.pxw / 2, 300);
                }
                if (tMabuEff == 110)
                {
                    tMabuEff = 0;
                    mabuEff = false;
                }
            }
        }
        BackgroudEffect2.paintFog(g);
        bool flag = true;
        for (int i = 0; i < BackgroudEffect2.vBgEffect.size(); i++)
        {
            BackgroudEffect2 backgroudEffect = (BackgroudEffect2)BackgroudEffect2.vBgEffect.elementAt(i);
            if (backgroudEffect.typeEff == 0)
            {
                flag = false;
                break;
            }
        }
        if (mGraphics2.zoomLevel <= 1 || Main2.isIpod || Main2.isIphone4)
        {
            flag = false;
        }
        if (flag && !isRongThanXuatHien)
        {
            int num2 = TileMap2.pxw / (mGraphics2.getImageWidth(TileMap2.imgLight) + 50);
            if (num2 <= 0)
            {
                num2 = 1;
            }
            if (TileMap2.tileID != 28)
            {
                for (int i = 0; i < num2; i++)
                {
                    int num3 = 100 + i * (mGraphics2.getImageWidth(TileMap2.imgLight) + 50) - cmx / 2;
                    int num4 = -20;
                    int imageWidth = mGraphics2.getImageWidth(TileMap2.imgLight);
                    if (num3 + imageWidth >= cmx && num3 <= cmx + GameCanvas2.w && num4 + mGraphics2.getImageHeight(TileMap2.imgLight) >= cmy && num4 <= cmy + GameCanvas2.h)
                    {
                        g.drawImage(TileMap2.imgLight, 100 + i * (mGraphics2.getImageWidth(TileMap2.imgLight) + 50) - cmx / 2, num4, 0);
                    }
                }
            }
        }
        mSystem2.paintFlyText(g);
        GameCanvas2.debug("PA14", 1);
        GameCanvas2.debug("PA15", 1);
        GameCanvas2.debug("PA16", 1);
        paintArrowPointToNPC(g);
        GameCanvas2.debug("PA17", 1);
        if (!isPaintOther && isPaintRada == 1 && !GameCanvas2.panel.isShow)
        {
            paintInfoBar(g);
        }
        resetTranslate(g);
        paint_xp_bar(g);
        if (!isPaintOther)
        {
            MainMod2.GI().Paint(g);
            g.translate(-g.getTranslateX(), -g.getTranslateY());
            if ((TileMap2.mapID == 128 || TileMap2.mapID == 127) && mabuPercent != 0)
            {
                int num5 = 30;
                int num6 = 200;
                g.setColor(0);
                g.fillRect(num5 - 27, num6 - 112, 54, 8);
                g.setColor(16711680);
                g.setClip(num5 - 25, num6 - 110, mabuPercent, 4);
                g.fillRect(num5 - 25, num6 - 110, 50, 4);
                g.setClip(0, 0, 3000, 3000);
                mFont2.tahoma_7b_white.drawString(g, "Mabu", num5, num6 - 112 + 10, 2, mFont2.tahoma_7b_dark);
            }
            if (Char2.myCharz().isFusion)
            {
                Char2.myCharz().tFusion++;
                if (GameCanvas2.gameTick % 3 == 0)
                {
                    g.setColor(16777215);
                    g.fillRect(0, 0, GameCanvas2.w, GameCanvas2.h);
                }
                if (Char2.myCharz().tFusion >= 100)
                {
                    Char2.myCharz().fusionComplete();
                }
            }
            for (int i = 0; i < vCharInMap.size(); i++)
            {
                Char2 char6 = null;
                try
                {
                    char6 = (Char2)vCharInMap.elementAt(i);
                }
                catch (Exception)
                {
                }
                if (char6 != null && char6.isFusion && Char2.isCharInScreen(char6))
                {
                    char6.tFusion++;
                    if (GameCanvas2.gameTick % 3 == 0)
                    {
                        g.setColor(16777215);
                        g.fillRect(0, 0, GameCanvas2.w, GameCanvas2.h);
                    }
                    if (char6.tFusion >= 100)
                    {
                        char6.fusionComplete();
                    }
                }
            }
            GameCanvas2.paintz.paintTabSoft(g);
            GameCanvas2.debug("PA19", 1);
            GameCanvas2.debug("PA20", 1);
            resetTranslate(g);
            paintSelectedSkill(g);
            GameCanvas2.debug("PA22", 1);
            resetTranslate(g);
            if (GameCanvas2.isTouch && GameCanvas2.isTouchControl)
            {
                paintTouchControl(g);
            }
            resetTranslate(g);
            paintChatVip(g);
            if (!GameCanvas2.panel.isShow && GameCanvas2.currentDialog == null && ChatPopup2.currChatPopup == null && ChatPopup2.serverChatPopUp == null && GameCanvas2.currentScreen.Equals(instance))
            {
                base.paint(g);
                if (keyMouse == 1 && cmdMenu != null)
                {
                    g.drawImage(ItemMap2.imageFlare, cmdMenu.x + 7, cmdMenu.y + 15, 3);
                }
            }
            resetTranslate(g);
            int num7 = 100 + ((Char2.vItemTime.size() != 0) ? (textTime.size() * 12) : 0);
            if (Char2.myCharz().clan != null)
            {
                int num8 = 0;
                int num9 = 0;
                int num10 = (GameCanvas2.h - 100 - 60) / 12;
                for (int i = 0; i < vCharInMap.size(); i++)
                {
                    Char2 char7 = (Char2)vCharInMap.elementAt(i);
                    if (char7.clanID == -1 || char7.clanID != Char2.myCharz().clan.ID)
                    {
                        continue;
                    }
                    if (char7.isOutX() && char7.cx < Char2.myCharz().cx)
                    {
                        int num11 = num10;
                        if (Char2.vItemTime.size() != 0)
                        {
                            num11 -= textTime.size();
                        }
                        if (num8 <= num11)
                        {
                            mFont2.tahoma_7_green.drawString(g, char7.cName, 20, num7 - 12 + num8 * 12, mFont2.LEFT, mFont2.tahoma_7_grey);
                            char7.paintHp(g, 10, num7 + num8 * 12 - 5);
                            num8++;
                        }
                    }
                    else if (char7.isOutX() && char7.cx > Char2.myCharz().cx && num9 <= num10)
                    {
                        mFont2.tahoma_7_green.drawString(g, char7.cName, GameCanvas2.w - 25, num7 - 12 + num9 * 12, mFont2.RIGHT, mFont2.tahoma_7_grey);
                        char7.paintHp(g, GameCanvas2.w - 15, num7 + num9 * 12 - 5);
                        num9++;
                    }
                }
            }
            ChatTextField2.gI().paint(g);
            if (isNewClanMessage && !GameCanvas2.panel.isShow && GameCanvas2.gameTick % 4 == 0)
            {
                g.drawImage(ItemMap2.imageFlare, cmdMenu.x + 15, cmdMenu.y + 30, mGraphics2.BOTTOM | mGraphics2.HCENTER);
            }
            if (isSuperPower)
            {
                dxPower += 5;
                if (tPower >= 0)
                {
                    tPower += dxPower;
                }
                Res2.outz("x power= " + xPower);
                if (tPower < 0)
                {
                    tPower--;
                    if (tPower == -20)
                    {
                        isSuperPower = false;
                        tPower = 0;
                        dxPower = 0;
                    }
                }
                else if ((xPower - tPower > 0 || tPower < TileMap2.pxw) && tPower > 0)
                {
                    g.setColor(16777215);
                    if (!GameCanvas2.lowGraphic)
                    {
                        g.fillArg(0, 0, GameCanvas2.w, GameCanvas2.h, 0, 0);
                    }
                    else
                    {
                        g.fillRect(0, 0, GameCanvas2.w, GameCanvas2.h);
                    }
                }
                else
                {
                    tPower = -1;
                }
            }
            for (int i = 0; i < Char2.vItemTime.size(); i++)
            {
                ((ItemTime2)Char2.vItemTime.elementAt(i)).paint(g, cmdMenu.x + 32 + i * 24, 55);
            }
            for (int i = 0; i < textTime.size(); i++)
            {
                ((ItemTime2)textTime.elementAt(i)).paintText(g, cmdMenu.x + ((Char2.vItemTime.size() == 0) ? 25 : 5), ((Char2.vItemTime.size() == 0) ? 45 : 90) + i * 12);
            }
            paintXoSo(g);
            if (mResources2.language == 1)
            {
                long second = mSystem2.currentTimeMillis() - deltaTime;
                mFont2.tahoma_7b_white.drawString(g, NinjaUtil2.getDate2(second), 10, GameCanvas2.h - 65, 0, mFont2.tahoma_7b_dark);
            }
            if (!yourNumber.Equals(string.Empty))
            {
                for (int i = 0; i < strPaint.Length; i++)
                {
                    mFont2.tahoma_7b_white.drawString(g, strPaint[i], 5, 85 + i * 18, 0, mFont2.tahoma_7b_dark);
                }
            }
        }
        int num12 = 0;
        int num13 = GameCanvas2.hw;
        if (num13 > 200)
        {
            num13 = 200;
        }
        paintPhuBanBar(g, num12 + GameCanvas2.w / 2, 0, num13);
        EffectManager2.hiEffects.paintAll(g);
    }

    private void paintXoSo(mGraphics2 g)
    {
        if (tShow != 0)
        {
            string text = string.Empty;
            for (int i = 0; i < winnumber.Length; i++)
            {
                text = text + randomNumber[i] + " ";
            }
            PopUp2.paintPopUp(g, 20, 45, 95, 35, 16777215, isButton: false);
            mFont2.tahoma_7b_dark.drawString(g, mResources2.kquaVongQuay, 68, 50, 2);
            mFont2.tahoma_7b_dark.drawString(g, text + string.Empty, 68, 65, 2);
        }
    }

    public void checkEffToObj(IMapObject2 obj, bool isnew)
    {
        if (obj == null || tDoubleDelay > 0)
        {
            return;
        }
        tDoubleDelay = 10;
        int x = obj.getX();
        int num = 1;
        int num2 = Res2.abs(Char2.myCharz().cx - x);
        num = ((num2 <= 80) ? 1 : ((num2 > 80 && num2 <= 200) ? 2 : ((num2 <= 200 || num2 > 400) ? 4 : 3)));
        if (!isnew)
        {
            if (obj.Equals(Char2.myCharz().mobFocus) || (obj.Equals(Char2.myCharz().charFocus) && Char2.myCharz().isMeCanAttackOtherPlayer(Char2.myCharz().charFocus)))
            {
                ServerEffect2.addServerEffect(135, obj.getX(), obj.getY(), num);
            }
            else if (obj.Equals(Char2.myCharz().npcFocus) || obj.Equals(Char2.myCharz().itemFocus) || obj.Equals(Char2.myCharz().charFocus))
            {
                ServerEffect2.addServerEffect(136, obj.getX(), obj.getY(), num);
            }
        }
        else
        {
            ServerEffect2.addServerEffect(136, obj.getX(), obj.getY(), num);
        }
    }

    private void updateClickToArrow()
    {
        if (tDoubleDelay > 0)
        {
            tDoubleDelay--;
        }
        if (clickMoving)
        {
            clickMoving = false;
            IMapObject2 mapObject = findClickToItem(clickToX, clickToY);
            if (mapObject == null || (mapObject != null && mapObject.Equals(Char2.myCharz().npcFocus) && TileMap2.mapID == 51))
            {
                ServerEffect2.addServerEffect(134, clickToX, clickToY + GameCanvas2.transY / 2, 3);
            }
        }
    }

    private void paintWaypointArrow(mGraphics2 g)
    {
        int num = 10;
        Task2 taskMaint = Char2.myCharz().taskMaint;
        if (taskMaint != null && taskMaint.taskId == 0 && ((taskMaint.index != 1 && taskMaint.index < 6) || taskMaint.index == 0))
        {
            return;
        }
        for (int i = 0; i < TileMap2.vGo.size(); i++)
        {
            Waypoint2 waypoint = (Waypoint2)TileMap2.vGo.elementAt(i);
            if (waypoint.minY == 0 || waypoint.maxY >= TileMap2.pxh - 24)
            {
                if (waypoint.maxY <= TileMap2.pxh / 2)
                {
                    int x = waypoint.minX + (waypoint.maxX - waypoint.minX) / 2;
                    int y = waypoint.minY + (waypoint.maxY - waypoint.minY) / 2 + runArrow;
                    if (GameCanvas2.isTouch)
                    {
                        y = waypoint.maxY + (waypoint.maxY - waypoint.minY) + runArrow + num;
                    }
                    g.drawRegion(arrow, 0, 0, 13, 16, 6, x, y, StaticObj2.VCENTER_HCENTER);
                }
                else if (waypoint.minY >= TileMap2.pxh / 2)
                {
                    g.drawRegion(arrow, 0, 0, 13, 16, 4, waypoint.minX + (waypoint.maxX - waypoint.minX) / 2, waypoint.minY - 12 - runArrow, StaticObj2.VCENTER_HCENTER);
                }
            }
            else if (waypoint.minX >= 0 && waypoint.minX < 24)
            {
                if (!GameCanvas2.isTouch)
                {
                    g.drawRegion(arrow, 0, 0, 13, 16, 2, waypoint.maxX + 12 + runArrow, waypoint.maxY - 12, StaticObj2.VCENTER_HCENTER);
                }
                else
                {
                    g.drawRegion(arrow, 0, 0, 13, 16, 2, waypoint.maxX + 12 + runArrow, waypoint.maxY - 32, StaticObj2.VCENTER_HCENTER);
                }
            }
            else if (waypoint.minX <= TileMap2.tmw * 24 && waypoint.minX >= TileMap2.tmw * 24 - 48)
            {
                if (!GameCanvas2.isTouch)
                {
                    g.drawRegion(arrow, 0, 0, 13, 16, 0, waypoint.minX - 12 - runArrow, waypoint.maxY - 12, StaticObj2.VCENTER_HCENTER);
                }
                else
                {
                    g.drawRegion(arrow, 0, 0, 13, 16, 0, waypoint.minX - 12 - runArrow, waypoint.maxY - 32, StaticObj2.VCENTER_HCENTER);
                }
            }
            else
            {
                g.drawRegion(arrow, 0, 0, 13, 16, 4, waypoint.minX + (waypoint.maxX - waypoint.minX) / 2, waypoint.maxY - 48 - runArrow, StaticObj2.VCENTER_HCENTER);
            }
        }
    }

    public static Npc2 findNPCInMap(short id)
    {
        for (int i = 0; i < vNpc.size(); i++)
        {
            Npc2 npc = (Npc2)vNpc.elementAt(i);
            if (npc.template.npcTemplateId == id)
            {
                return npc;
            }
        }
        return null;
    }

    public static Char2 findCharInMap(int charId)
    {
        for (int i = 0; i < vCharInMap.size(); i++)
        {
            Char2 @char = (Char2)vCharInMap.elementAt(i);
            if (@char.charID == charId)
            {
                return @char;
            }
        }
        return null;
    }

    public static Mob2 findMobInMap(sbyte mobIndex)
    {
        return (Mob2)vMob.elementAt(mobIndex);
    }

    public static Mob2 findMobInMap(int mobId)
    {
        for (int i = 0; i < vMob.size(); i++)
        {
            Mob2 mob = (Mob2)vMob.elementAt(i);
            if (mob.mobId == mobId)
            {
                return mob;
            }
        }
        return null;
    }

    public static Npc2 getNpcTask()
    {
        for (int i = 0; i < vNpc.size(); i++)
        {
            Npc2 npc = (Npc2)vNpc.elementAt(i);
            if (npc.template.npcTemplateId == getTaskNpcId())
            {
                return npc;
            }
        }
        return null;
    }

    private void paintArrowPointToNPC(mGraphics2 g)
    {
        try
        {
            if (ChatPopup2.currChatPopup != null)
            {
                return;
            }
            int num = getTaskNpcId();
            if (num == -1)
            {
                return;
            }
            Npc2 npc = null;
            for (int i = 0; i < vNpc.size(); i++)
            {
                Npc2 npc2 = (Npc2)vNpc.elementAt(i);
                if (npc2.template.npcTemplateId == num)
                {
                    if (npc == null)
                    {
                        npc = npc2;
                    }
                    else if (Res2.abs(npc2.cx - Char2.myCharz().cx) < Res2.abs(npc.cx - Char2.myCharz().cx))
                    {
                        npc = npc2;
                    }
                }
            }
            if (npc == null || npc.statusMe == 15 || (npc.cx > cmx && npc.cx < cmx + gW && npc.cy > cmy && npc.cy < cmy + gH) || GameCanvas2.gameTick % 10 < 5)
            {
                return;
            }
            int num2 = npc.cx - Char2.myCharz().cx;
            int num3 = npc.cy - Char2.myCharz().cy;
            int x = 0;
            int y = 0;
            int arg = 0;
            if (num2 > 0 && num3 >= 0)
            {
                if (Res2.abs(num2) >= Res2.abs(num3))
                {
                    x = gW - 10;
                    y = gH / 2 + 30;
                    if (GameCanvas2.isTouch)
                    {
                        y = gH / 2 + 10;
                    }
                    arg = 0;
                }
                else
                {
                    x = gW / 2;
                    y = gH - 10;
                    arg = 5;
                }
            }
            else if (num2 >= 0 && num3 < 0)
            {
                if (Res2.abs(num2) >= Res2.abs(num3))
                {
                    x = gW - 10;
                    y = gH / 2 + 30;
                    if (GameCanvas2.isTouch)
                    {
                        y = gH / 2 + 10;
                    }
                    arg = 0;
                }
                else
                {
                    x = gW / 2;
                    y = 10;
                    arg = 6;
                }
            }
            if (num2 < 0 && num3 >= 0)
            {
                if (Res2.abs(num2) >= Res2.abs(num3))
                {
                    x = 10;
                    y = gH / 2 + 30;
                    if (GameCanvas2.isTouch)
                    {
                        y = gH / 2 + 10;
                    }
                    arg = 3;
                }
                else
                {
                    x = gW / 2;
                    y = gH - 10;
                    arg = 5;
                }
            }
            else if (num2 <= 0 && num3 < 0)
            {
                if (Res2.abs(num2) >= Res2.abs(num3))
                {
                    x = 10;
                    y = gH / 2 + 30;
                    if (GameCanvas2.isTouch)
                    {
                        y = gH / 2 + 10;
                    }
                    arg = 3;
                }
                else
                {
                    x = gW / 2;
                    y = 10;
                    arg = 6;
                }
            }
            resetTranslate(g);
            g.drawRegion(arrow, 0, 0, 13, 16, arg, x, y, StaticObj2.VCENTER_HCENTER);
        }
        catch (Exception ex)
        {
            Cout2.LogError("Loi ham arrow to npc: " + ex.ToString());
        }
    }

    public static void resetTranslate(mGraphics2 g)
    {
        g.translate(-g.getTranslateX(), -g.getTranslateY());
        g.setClip(0, -200, GameCanvas2.w, 200 + GameCanvas2.h);
    }

    private void paintTouchControl(mGraphics2 g)
    {
        if (isNotPaintTouchControl())
        {
            return;
        }
        resetTranslate(g);
        if (!TileMap2.isOfflineMap() && !isVS())
        {
            if (keyTouch == 15 || keyMouse == 15)
            {
                g.drawImage(imgChat2, xC + 17, yC + 17 + mGraphics2.addYWhenOpenKeyBoard, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }
            else
            {
                g.drawImage(imgChat, xC + 17, yC + 17 + mGraphics2.addYWhenOpenKeyBoard, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }
        }
        if (isUseTouch)
        {
        }
    }

    public void paintImageBarRight(mGraphics2 g, Char2 c)
    {
        int num = (int)(c.cHP * hpBarW / c.cHPFull);
        int num2 = (int)c.cMP * mpBarW;
        int num3 = (int)(dHP * hpBarW / c.cHPFull);
        int num4 = (int)dMP * mpBarW;
        g.setClip(GameCanvas2.w / 2 + 58 - mGraphics2.getImageWidth(imgPanel), 0, 95, 100);
        g.drawRegion(imgPanel, 0, 0, mGraphics2.getImageWidth(imgPanel), mGraphics2.getImageHeight(imgPanel), 2, GameCanvas2.w / 2 + 60, 0, mGraphics2.RIGHT | mGraphics2.TOP);
        g.setClip((int)(GameCanvas2.w / 2 + 60 - 83 - hpBarW + hpBarW - num3), 5, num3, 10);
        g.drawImage(imgHPLost, GameCanvas2.w / 2 + 60 - 83, 5, mGraphics2.RIGHT | mGraphics2.TOP);
        g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
        g.setClip((int)(GameCanvas2.w / 2 + 60 - 83 - hpBarW + hpBarW - num), 5, num, 10);
        g.drawImage(imgHP, GameCanvas2.w / 2 + 60 - 83, 5, mGraphics2.RIGHT | mGraphics2.TOP);
        g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
        g.setClip((int)(GameCanvas2.w / 2 + 60 - 83 - mpBarW + hpBarW - num4), 20, num4, 6);
        g.drawImage(imgMPLost, GameCanvas2.w / 2 + 60 - 83, 20, mGraphics2.RIGHT | mGraphics2.TOP);
        g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
        g.setClip((int)(GameCanvas2.w / 2 + 60 - 83 - mpBarW + hpBarW - num2), 20, num2, 6);
        g.drawImage(imgMP, GameCanvas2.w / 2 + 60 - 83, 20, mGraphics2.RIGHT | mGraphics2.TOP);
        g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
    }

    private void paintImageBar(mGraphics2 g, bool isLeft, Char2 c)
    {
        if (c != null)
        {
            int num;
            int num4;
            int num3;
            int num2;
            if (c.charID == Char2.myCharz().charID)
            {
                num = (int)(dHP * hpBarW / c.cHPFull);
                num2 = (int)(dMP * mpBarW / c.cMPFull);
                num3 = (int)(c.cHP * hpBarW / c.cHPFull);
                num4 = (int)(c.cMP * mpBarW / c.cMPFull);
            }
            else
            {
                num = (int)(c.dHP * hpBarW / c.cHPFull);
                num2 = c.perCentMp * mpBarW / 100;
                num3 = (int)(c.cHP * hpBarW / c.cHPFull);
                num4 = c.perCentMp * mpBarW / 100;
            }
            if (Char2.myCharz().secondPower > 0)
            {
                int w = Char2.myCharz().powerPoint * spBarW / Char2.myCharz().maxPowerPoint;
                g.drawImage(imgPanel2, 58, 29, 0);
                g.setClip(83, 31, w, 10);
                g.drawImage(imgSP, 83, 31, 0);
                g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
                mFont2.tahoma_7_white.drawString(g, Char2.myCharz().strInfo + ":" + Char2.myCharz().powerPoint + "/" + Char2.myCharz().maxPowerPoint, 115, 29, 2);
            }
            if (c.charID != Char2.myCharz().charID)
            {
                g.setClip(mGraphics2.getImageWidth(imgPanel) - 95, 0, 95, 100);
            }
            g.drawImage(imgPanel, 0, 0, 0);
            if (isLeft)
            {
                g.setClip(83, 5, num, 10);
            }
            else
            {
                g.setClip((int)(83 + hpBarW - num), 5, num, 10);
            }
            g.drawImage(imgHPLost, 83, 5, 0);
            g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
            if (isLeft)
            {
                g.setClip(83, 5, num3, 10);
            }
            else
            {
                g.setClip((int)(83 + hpBarW - num3), 5, num3, 10);
            }
            g.drawImage(imgHP, 83, 5, 0);
            g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
            if (isLeft)
            {
                g.setClip(83, 20, num2, 6);
            }
            else
            {
                g.setClip(83 + mpBarW - num2, 20, num2, 6);
            }
            g.drawImage(imgMPLost, 83, 20, 0);
            g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
            if (isLeft)
            {
                g.setClip(83, 20, num2, 6);
            }
            else
            {
                g.setClip(83 + mpBarW - num4, 20, num4, 6);
            }
            g.drawImage(imgMP, 83, 20, 0);
            g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
            if (Char2.myCharz().cMP == 0 && GameCanvas2.gameTick % 10 > 5)
            {
                g.setClip(83, 20, 2, 6);
                g.drawImage(imgMPLost, 83, 20, 0);
                g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
            }
        }
    }

    public void getInjure()
    {
    }

    public void starVS()
    {
        curr = (last = mSystem2.currentTimeMillis());
        secondVS = 180;
    }

    private Char2 findCharVS1()
    {
        for (int i = 0; i < vCharInMap.size(); i++)
        {
            Char2 @char = (Char2)vCharInMap.elementAt(i);
            if (@char.cTypePk != 0)
            {
                return @char;
            }
        }
        return null;
    }

    private Char2 findCharVS2()
    {
        for (int i = 0; i < vCharInMap.size(); i++)
        {
            Char2 @char = (Char2)vCharInMap.elementAt(i);
            if (@char.cTypePk != 0 && @char != findCharVS1())
            {
                return @char;
            }
        }
        return null;
    }

    private void paintInfoBar(mGraphics2 g)
    {
        if (ChatTextField2.gI().isShow)
        {
            return;
        }
        resetTranslate(g);
        if (TileMap2.mapID == 130 && findCharVS1() != null && findCharVS2() != null)
        {
            g.translate(GameCanvas2.w / 2 - 62, 0);
            paintImageBar(g, isLeft: true, findCharVS1());
            g.translate(-(GameCanvas2.w / 2 - 65), 0);
            paintImageBarRight(g, findCharVS2());
            findCharVS1().paintHeadWithXY(g, 137, 25, 0);
            findCharVS2().paintHeadWithXY(g, GameCanvas2.w - 15 - 122, 25, 2);
        }
        else if (isVS() && Char2.myCharz().charFocus != null)
        {
            g.translate(GameCanvas2.w / 2 - 62, 0);
            paintImageBar(g, isLeft: true, Char2.myCharz().charFocus);
            g.translate(-(GameCanvas2.w / 2 - 65), 0);
            paintImageBarRight(g, Char2.myCharz());
            Char2.myCharz().paintHeadWithXY(g, 137, 25, 0);
            Char2.myCharz().charFocus.paintHeadWithXY(g, GameCanvas2.w - 15 - 122, 25, 2);
        }
        else if (ispaintPhubangBar() && isSmallScr())
        {
            paintHPBar_NEW(g, 1, 1, Char2.myCharz());
        }
        else
        {
            paintImageBar(g, isLeft: true, Char2.myCharz());
            if (Char2.myCharz().isInEnterOfflinePoint() != null || Char2.myCharz().isInEnterOnlinePoint() != null)
            {
                mFont2.tahoma_7_green2.drawString(g, mResources2.enter, imgScrW / 2, 8 + mGraphics2.addYWhenOpenKeyBoard, mFont2.CENTER);
            }
            else if (Char2.myCharz().mobFocus != null)
            {
                if (Char2.myCharz().mobFocus.getTemplate() != null)
                {
                    mFont2.tahoma_7b_green2.drawString(g, Char2.myCharz().mobFocus.getTemplate().name, imgScrW / 2, 9 + mGraphics2.addYWhenOpenKeyBoard, mFont2.CENTER);
                }
                if (Char2.myCharz().mobFocus.templateId != 0)
                {
                    mFont2.tahoma_7b_green2.drawString(g, NinjaUtil2.getMoneys(Char2.myCharz().mobFocus.hp) + string.Empty, imgScrW / 2, 22 + mGraphics2.addYWhenOpenKeyBoard, mFont2.CENTER);
                }
            }
            else if (Char2.myCharz().npcFocus != null)
            {
                mFont2.tahoma_7b_green2.drawString(g, Char2.myCharz().npcFocus.template.name, imgScrW / 2, 9 + mGraphics2.addYWhenOpenKeyBoard, mFont2.CENTER);
                if (Char2.myCharz().npcFocus.template.npcTemplateId == 4)
                {
                    mFont2.tahoma_7b_green2.drawString(g, gI().magicTree.currPeas + "/" + gI().magicTree.maxPeas, imgScrW / 2, 22 + mGraphics2.addYWhenOpenKeyBoard, mFont2.CENTER);
                }
            }
            else if (Char2.myCharz().charFocus != null)
            {
                mFont2.tahoma_7b_green2.drawString(g, Char2.myCharz().charFocus.cName, imgScrW / 2, 9 + mGraphics2.addYWhenOpenKeyBoard, mFont2.CENTER);
                mFont2.tahoma_7b_green2.drawString(g, NinjaUtil2.getMoneys(Char2.myCharz().charFocus.cHP) + string.Empty, imgScrW / 2, 22 + mGraphics2.addYWhenOpenKeyBoard, mFont2.CENTER);
            }
            else
            {
                mFont2.tahoma_7b_green2.drawString(g, Char2.myCharz().cName, imgScrW / 2, 9 + mGraphics2.addYWhenOpenKeyBoard, mFont2.CENTER);
                mFont2.tahoma_7b_green2.drawString(g, NinjaUtil2.getMoneys(Char2.myCharz().cPower) + string.Empty, imgScrW / 2, 22 + mGraphics2.addYWhenOpenKeyBoard, mFont2.CENTER);
            }
        }
        g.translate(-g.getTranslateX(), -g.getTranslateY());
        if (isVS() && secondVS > 0)
        {
            curr = mSystem2.currentTimeMillis();
            if (curr - last >= 1000)
            {
                last = mSystem2.currentTimeMillis();
                secondVS--;
            }
            mFont2.tahoma_7b_white.drawString(g, secondVS + string.Empty, GameCanvas2.w / 2, 13, 2, mFont2.tahoma_7b_dark);
        }
        if (flareFindFocus)
        {
            g.drawImage(ItemMap2.imageFlare, 40, 35, mGraphics2.BOTTOM | mGraphics2.HCENTER);
            flareTime--;
            if (flareTime < 0)
            {
                flareTime = 0;
                flareFindFocus = false;
            }
        }
    }

    public bool isVS()
    {
        if (TileMap2.isVoDaiMap() && (Char2.myCharz().cTypePk != 0 || (TileMap2.mapID == 130 && findCharVS1() != null && findCharVS2() != null)))
        {
            return true;
        }
        return false;
    }

    private void paintSelectedSkill(mGraphics2 g)
    {
        if (mobCapcha != null)
        {
            paintCapcha(g);
        }
        else
        {
            if (GameCanvas2.currentDialog != null || ChatPopup2.currChatPopup != null || GameCanvas2.menu.showMenu || isPaintPopup() || GameCanvas2.panel.isShow || Char2.myCharz().taskMaint.taskId == 0 || ChatTextField2.gI().isShow || GameCanvas2.currentScreen == MoneyCharge2.instance)
            {
                return;
            }
            long num = mSystem2.currentTimeMillis();
            long num2 = num - lastUsePotion;
            int num3 = 0;
            if (num2 < 10000)
            {
                num3 = (int)(num2 * 20 / 10000);
            }
            if (!GameCanvas2.isTouch)
            {
                g.drawImage((keyTouch != 10) ? imgSkill : imgSkill2, xSkill + xHP - 1, yHP - 1, 0);
                SmallImage2.drawSmallImage(g, 542, xSkill + xHP + 3, yHP + 3, 0, 0);
                mFont2.number_gray.drawString(g, string.Empty + hpPotion, xSkill + xHP + 22, yHP + 15, 1);
                if (num2 < 10000)
                {
                    g.setColor(2721889);
                    num3 = (int)(num2 * 20 / 10000);
                    g.fillRect(xSkill + xHP + 3, yHP + 3 + num3, 20, 20 - num3);
                }
            }
            else if (Char2.myCharz().statusMe != 14)
            {
                if (gamePad.isSmallGamePad)
                {
                    if (isAnalog != 1)
                    {
                        g.setColor(9670800);
                        g.fillRect(xHP + 9, yHP + 10, 22, 20);
                        g.setColor(16777215);
                        g.fillRect(xHP + 9, yHP + 10 + ((num3 != 0) ? (20 - num3) : 0), 22, (num3 == 0) ? 20 : num3);
                        g.drawImage((keyTouch != 10) ? imgHP1 : imgHP2, xHP, yHP, 0);
                        mFont2.tahoma_7_green2.drawString(g, string.Empty + hpPotion, xHP + 20, yHP + 15, 2);
                    }
                    else if (isAnalog == 1)
                    {
                        g.drawImage((keyTouch != 10) ? imgSkill : imgSkill2, xSkill + xHP - 1, yHP - 1, 0);
                        SmallImage2.drawSmallImage(g, 542, xSkill + xHP + 3, yHP + 3, 0, 0);
                        mFont2.number_gray.drawString(g, string.Empty + hpPotion, xSkill + xHP + 22, yHP + 13, 1);
                        if (num2 < 10000)
                        {
                            g.setColor(2721889);
                            num3 = (int)(num2 * 20 / 10000);
                            g.fillRect(xSkill + xHP + 3, yHP + 3 + num3, 20, 20 - num3);
                        }
                    }
                }
                else if (isAnalog != 1)
                {
                    g.setColor(9670800);
                    g.fillRect(xHP + 9, yHP + 10 - 6, 22, 20);
                    g.setColor(16777215);
                    g.fillRect(xHP + 9, yHP + 10 + ((num3 != 0) ? (20 - num3) : 0) - 6, 22, (num3 == 0) ? 20 : num3);
                    g.drawImage((keyTouch != 10) ? imgHP1 : imgHP2, xHP, yHP - 6, 0);
                    mFont2.tahoma_7_green2.drawString(g, string.Empty + hpPotion, xHP + 20, yHP + 15 - 6, 2);
                }
                else
                {
                    g.setColor(9670800);
                    g.fillRect(xHP + 10, yHP + 10, 20, 18);
                    g.setColor(16777215);
                    g.fillRect(xHP + 10, yHP + 16 + ((num3 != 0) ? (20 - num3) : 0) - 6, 20, (num3 == 0) ? 18 : num3);
                    g.drawImage((keyTouch != 10) ? imgHP3 : imgHP4, xHP + 20, yHP + 20 - 3, mGraphics2.HCENTER | mGraphics2.VCENTER);
                    mFont2.tahoma_7_green2.drawString(g, string.Empty + hpPotion, xHP + 20, yHP + 11, 2);
                }
            }
            if (isHaveSelectSkill)
            {
                Skill2[] array = Main2.isPC ? keySkill : ((!GameCanvas2.isTouch) ? keySkill : onScreenSkill);
                if (!GameCanvas2.isTouch)
                {
                    g.setColor(11152401);
                    g.fillRect(xSkill + xHP + 2, yHP - 10 + 6, 20, 10);
                    mFont2.tahoma_7_white.drawString(g, "*", xSkill + xHP + 12, yHP - 8 + 6, mFont2.CENTER);
                }
                int num4 = Main2.isPC ? array.Length : ((!GameCanvas2.isTouch) ? array.Length : nSkill);
                for (int i = 0; i < num4; i++)
                {
                    Skill2 skill = array[i];
                    if (skill == null)
                    {
                        continue;
                    }
                    if (skill != Char2.myCharz().myskill)
                    {
                        g.drawImage(imgSkill, xSkill + xS[i] - 1, yS[i] - 1, 0);
                    }
                    if (skill == Char2.myCharz().myskill)
                    {
                        g.drawImage(imgSkill2, xSkill + xS[i] - 1, yS[i] - 1, 0);
                        if (GameCanvas2.isTouch && !Main2.isPC)
                        {
                            g.drawRegion(Mob2.imgHP, 0, 12, 9, 6, 0, xSkill + xS[i] + 8, yS[i] - 7, 0);
                        }
                    }
                    skill.paint(xSkill + xS[i] + 13, yS[i] + 13, g);
                    if ((i == selectedIndexSkill && !isPaintUI() && GameCanvas2.gameTick % 10 > 5) || i == keyTouchSkill)
                    {
                        g.drawImage(ItemMap2.imageFlare, xSkill + xS[i] + 13, yS[i] + 14, 3);
                    }
                }
            }
            paintGamePad(g);
        }
    }

    public void paintOpen(mGraphics2 g)
    {
        if (isstarOpen)
        {
            g.translate(-g.getTranslateX(), -g.getTranslateY());
            g.fillRect(0, 0, GameCanvas2.w, moveUp);
            g.setColor(10275899);
            g.fillRect(0, moveUp - 1, GameCanvas2.w, 1);
            g.fillRect(0, moveDow + 1, GameCanvas2.w, 1);
        }
    }

    public static void startFlyText(string flyString, int x, int y, int dx, int dy, int color)
    {
        int num = -1;
        for (int i = 0; i < 5; i++)
        {
            if (flyTextState[i] == -1)
            {
                num = i;
                break;
            }
        }
        if (num == -1)
        {
            return;
        }
        flyTextColor[num] = color;
        flyTextString[num] = flyString;
        flyTextX[num] = x;
        flyTextY[num] = y;
        flyTextDx[num] = dx;
        flyTextDy[num] = ((dy >= 0) ? 5 : (-5));
        flyTextState[num] = 0;
        flyTime[num] = 0;
        flyTextYTo[num] = 10;
        for (int j = 0; j < 5; j++)
        {
            if (flyTextState[j] != -1 && num != j && flyTextDy[num] < 0 && Res2.abs(flyTextX[num] - flyTextX[j]) <= 20 && flyTextYTo[num] == flyTextYTo[j])
            {
                flyTextYTo[num] += 10;
            }
        }
    }

    public static void updateFlyText()
    {
        for (int i = 0; i < 5; i++)
        {
            if (flyTextState[i] == -1)
            {
                continue;
            }
            if (flyTextState[i] > flyTextYTo[i])
            {
                flyTime[i]++;
                if (flyTime[i] == 25)
                {
                    flyTime[i] = 0;
                    flyTextState[i] = -1;
                    flyTextYTo[i] = 0;
                    flyTextDx[i] = 0;
                    flyTextX[i] = 0;
                }
            }
            else
            {
                flyTextState[i] += Res2.abs(flyTextDy[i]);
                flyTextX[i] += flyTextDx[i];
                flyTextY[i] += flyTextDy[i];
            }
        }
    }

    public static void loadSplash()
    {
        if (imgSplash == null)
        {
            imgSplash = new Image2[3];
            for (int i = 0; i < 3; i++)
            {
                imgSplash[i] = GameCanvas2.loadImage("/e/sp" + i + ".png");
            }
        }
        splashX = new int[2];
        splashY = new int[2];
        splashState = new int[2];
        splashF = new int[2];
        splashDir = new int[2];
        splashState[0] = (splashState[1] = -1);
    }

    public static bool startSplash(int x, int y, int dir)
    {
        int num = ((splashState[0] != -1) ? 1 : 0);
        if (splashState[num] != -1)
        {
            return false;
        }
        splashState[num] = 0;
        splashDir[num] = dir;
        splashX[num] = x;
        splashY[num] = y;
        return true;
    }

    public static void updateSplash()
    {
        for (int i = 0; i < 2; i++)
        {
            if (splashState[i] != -1)
            {
                splashState[i]++;
                splashX[i] += splashDir[i] << 2;
                splashY[i]--;
                if (splashState[i] >= 6)
                {
                    splashState[i] = -1;
                }
                else
                {
                    splashF[i] = (splashState[i] >> 1) % 3;
                }
            }
        }
    }

    public static void paintSplash(mGraphics2 g)
    {
        for (int i = 0; i < 2; i++)
        {
            if (splashState[i] != -1)
            {
                if (splashDir[i] == 1)
                {
                    g.drawImage(imgSplash[splashF[i]], splashX[i], splashY[i], 3);
                }
                else
                {
                    g.drawRegion(imgSplash[splashF[i]], 0, 0, mGraphics2.getImageWidth(imgSplash[splashF[i]]), mGraphics2.getImageHeight(imgSplash[splashF[i]]), 2, splashX[i], splashY[i], 3);
                }
            }
        }
    }

    private void loadInforBar()
    {
        imgScrW = 84;
        hpBarW = 66L;
        mpBarW = 59;
        hpBarX = 52;
        hpBarY = 10;
        spBarW = 61;
        expBarW = gW - 61;
    }

    public void updateSS()
    {
        if (indexMenu != -1)
        {
            if (cmySK != cmtoYSK)
            {
                cmvySK = cmtoYSK - cmySK << 2;
                cmdySK += cmvySK;
                cmySK += cmdySK >> 4;
                cmdySK &= 15;
            }
            if (Math2.abs(cmtoYSK - cmySK) < 15 && cmySK < 0)
            {
                cmtoYSK = 0;
            }
            if (Math2.abs(cmtoYSK - cmySK) < 15 && cmySK > cmyLimSK)
            {
                cmtoYSK = cmyLimSK;
            }
        }
    }

    public void updateKeyAlert()
    {
        if (!isPaintAlert || GameCanvas2.currentDialog != null)
        {
            return;
        }
        bool flag = false;
        if (GameCanvas2.keyPressed[Key2.NUM8])
        {
            indexRow++;
            if (indexRow >= texts.size())
            {
                indexRow = 0;
            }
            flag = true;
        }
        else if (GameCanvas2.keyPressed[Key2.NUM2])
        {
            indexRow--;
            if (indexRow < 0)
            {
                indexRow = texts.size() - 1;
            }
            flag = true;
        }
        if (flag)
        {
            scrMain.moveTo(indexRow * scrMain.ITEM_SIZE);
            GameCanvas2.clearKeyHold();
            GameCanvas2.clearKeyPressed();
        }
        if (GameCanvas2.isTouch)
        {
            ScrollResult2 scrollResult = scrMain.updateKey();
            if (scrollResult.isDowning || scrollResult.isFinish)
            {
                indexRow = scrollResult.selected;
                flag = true;
            }
        }
        if (!flag || indexRow < 0 || indexRow >= texts.size())
        {
            return;
        }
        string text = (string)texts.elementAt(indexRow);
        int num = -1;
        fnick = null;
        alertURL = null;
        center = null;
        ChatTextField2.gI().center = null;
        if ((num = text.IndexOf("http://")) >= 0)
        {
            Cout2.println("currentLine: " + text);
            alertURL = text.Substring(num);
            center = new Command2(mResources2.open_link, 12000);
            if (!GameCanvas2.isTouch)
            {
                ChatTextField2.gI().center = new Command2(mResources2.open_link, null, 12000, null);
            }
        }
        else
        {
            if ((num = text.IndexOf("@")) < 0)
            {
                return;
            }
            string text2 = text.Substring(2);
            text2 = text2.Trim();
            num = text2.IndexOf("@");
            string text3 = text2.Substring(num);
            int num2 = -1;
            num2 = text3.IndexOf(" ");
            num2 = ((num2 > 0) ? (num2 + num) : (num + text3.Length));
            fnick = text2.Substring(num + 1, num2);
            if (!fnick.Equals(string.Empty) && !fnick.Equals(Char2.myCharz().cName))
            {
                center = new Command2(mResources2.SELECT, 12009, fnick);
                if (!GameCanvas2.isTouch)
                {
                    ChatTextField2.gI().center = new Command2(mResources2.SELECT, null, 12009, fnick);
                }
            }
            else
            {
                fnick = null;
                center = null;
            }
        }
    }

    public bool isPaintPopup()
    {
        if (isPaintItemInfo || isPaintInfoMe || isPaintStore || isPaintWeapon || isPaintNonNam || isPaintNonNu || isPaintAoNam || isPaintAoNu || isPaintGangTayNam || isPaintGangTayNu || isPaintQuanNam || isPaintQuanNu || isPaintGiayNam || isPaintGiayNu || isPaintLien || isPaintNhan || isPaintNgocBoi || isPaintPhu || isPaintStack || isPaintStackLock || isPaintGrocery || isPaintGroceryLock || isPaintUpGrade || isPaintConvert || isPaintSplit || isPaintUpPearl || isPaintBox || isPaintTrade || isPaintAlert || isPaintZone || isPaintTeam || isPaintClan || isPaintFindTeam || isPaintTask || isPaintFriend || isPaintEnemies || isPaintCharInMap || isPaintMessage)
        {
            return true;
        }
        return false;
    }

    public bool isNotPaintTouchControl()
    {
        if (!GameCanvas2.isTouchControl && GameCanvas2.currentScreen == gI())
        {
            return true;
        }
        if (!GameCanvas2.isTouch)
        {
            return true;
        }
        if (ChatTextField2.gI().isShow)
        {
            return true;
        }
        if (InfoDlg2.isShow)
        {
            return true;
        }
        if (GameCanvas2.currentDialog != null || ChatPopup2.currChatPopup != null || GameCanvas2.menu.showMenu || GameCanvas2.panel.isShow || isPaintPopup())
        {
            return true;
        }
        return false;
    }

    public bool isPaintUI()
    {
        if (isPaintStore || isPaintWeapon || isPaintNonNam || isPaintNonNu || isPaintAoNam || isPaintAoNu || isPaintGangTayNam || isPaintGangTayNu || isPaintQuanNam || isPaintQuanNu || isPaintGiayNam || isPaintGiayNu || isPaintLien || isPaintNhan || isPaintNgocBoi || isPaintPhu || isPaintStack || isPaintStackLock || isPaintGrocery || isPaintGroceryLock || isPaintUpGrade || isPaintConvert || isPaintSplit || isPaintUpPearl || isPaintBox || isPaintTrade)
        {
            return true;
        }
        return false;
    }

    public bool isOpenUI()
    {
        if (isPaintItemInfo || isPaintInfoMe || isPaintStore || isPaintNonNam || isPaintNonNu || isPaintAoNam || isPaintAoNu || isPaintGangTayNam || isPaintGangTayNu || isPaintQuanNam || isPaintQuanNu || isPaintGiayNam || isPaintGiayNu || isPaintLien || isPaintNhan || isPaintNgocBoi || isPaintPhu || isPaintWeapon || isPaintStack || isPaintStackLock || isPaintGrocery || isPaintGroceryLock || isPaintUpGrade || isPaintConvert || isPaintUpPearl || isPaintBox || isPaintSplit || isPaintTrade)
        {
            return true;
        }
        return false;
    }

    public static void setPopupSize(int w, int h)
    {
        if (GameCanvas2.w == 128 || GameCanvas2.h <= 208)
        {
            w = 126;
            h = 160;
        }
        indexTitle = 0;
        popupW = w;
        popupH = h;
        popupX = gW2 - w / 2;
        popupY = gH2 - h / 2;
        if (GameCanvas2.isTouch && !isPaintZone && !isPaintTeam && !isPaintClan && !isPaintCharInMap && !isPaintFindTeam && !isPaintFriend && !isPaintEnemies && !isPaintTask && !isPaintMessage)
        {
            if (GameCanvas2.h <= 240)
            {
                popupY -= 10;
            }
            if (GameCanvas2.isTouch && !GameCanvas2.isTouchControlSmallScreen && GameCanvas2.currentScreen is GameScr2)
            {
                popupW = 310;
                popupX = gW / 2 - popupW / 2;
                if (isPaintInfoMe && indexMenu > 0)
                {
                    popupW = w;
                    popupX = gW2 - w / 2;
                }
            }
        }
        if (popupY < -10)
        {
            popupY = -10;
        }
        if (GameCanvas2.h > 208 && popupY < 0)
        {
            popupY = 0;
        }
        if (GameCanvas2.h == 208 && popupY < 10)
        {
            popupY = 10;
        }
    }

    public static void loadImg()
    {
        TileMap2.loadTileImage();
    }

    public void paintTitle(mGraphics2 g, string title, bool arrow)
    {
        int num = 0;
        num = gW / 2;
        g.setColor(Paint2.COLORDARK);
        g.fillRoundRect(num - mFont2.tahoma_8b.getWidth(title) / 2 - 12, popupY + 4, mFont2.tahoma_8b.getWidth(title) + 22, 24, 6, 6);
        if ((indexTitle == 0 || GameCanvas2.isTouch) && arrow)
        {
            SmallImage2.drawSmallImage(g, 989, num - mFont2.tahoma_8b.getWidth(title) / 2 - 15 - 7 - ((GameCanvas2.gameTick % 8 <= 3) ? 2 : 0), popupY + 16, 2, StaticObj2.VCENTER_HCENTER);
            SmallImage2.drawSmallImage(g, 989, num + mFont2.tahoma_8b.getWidth(title) / 2 + 15 + 5 + ((GameCanvas2.gameTick % 8 <= 3) ? 2 : 0), popupY + 16, 0, StaticObj2.VCENTER_HCENTER);
        }
        if (indexTitle == 0)
        {
            g.setColor(Paint2.COLORFOCUS);
        }
        else
        {
            g.setColor(Paint2.COLORBORDER);
        }
        g.drawRoundRect(num - mFont2.tahoma_8b.getWidth(title) / 2 - 12, popupY + 4, mFont2.tahoma_8b.getWidth(title) + 22, 24, 6, 6);
        mFont2.tahoma_8b.drawString(g, title, num, popupY + 9, 2);
    }

    public static int getTaskMapId()
    {
        if (Char2.myCharz().taskMaint == null)
        {
            return -1;
        }
        return mapTasks[Char2.myCharz().taskMaint.index];
    }

    public static sbyte getTaskNpcId()
    {
        sbyte result = 0;
        if (Char2.myCharz().taskMaint == null)
        {
            result = -1;
        }
        else if (Char2.myCharz().taskMaint.index <= tasks.Length - 1)
        {
            result = (sbyte)tasks[Char2.myCharz().taskMaint.index];
        }
        return result;
    }

    public void refreshTeam()
    {
    }

    public void onChatFromMe(string text, string to)
    {
        if (!isPaintMessage || GameCanvas2.isTouch)
        {
            ChatTextField2.gI().isShow = false;
        }
        if (MainMod2.GI().Chat(text))
        {
            return;
        }
        if (to.Equals(mResources2.chat_player))
        {
            if (info2.playerID != Char2.myCharz().charID)
            {
                Service2.gI().chatPlayer(text, info2.playerID);
            }
        }
        else if (ChatTextField2.gI().strChat == "Nhập tốc độ game" && text != string.Empty)
        {
            MainMod2.GI().ChangeGameSpeed(text);
            ChatTextField2.gI().strChat = "Chat";
            ChatTextField2.gI().tfChat.name = "chat";
            ChatTextField2.gI().tfChat.setIputType(TField2.INPUT_TYPE_ANY);
            ChatTextField2.gI().isShow = false;
        }
        else if (ChatTextField2.gI().strChat == "Tăng đến mức" && text != string.Empty)
        {
            MainMod2.GI().SetIncreasePoint(text);
            ChatTextField2.gI().strChat = "Chat";
            ChatTextField2.gI().tfChat.name = "chat";
            ChatTextField2.gI().tfChat.setIputType(TField2.INPUT_TYPE_ANY);
            ChatTextField2.gI().isShow = false;
        }
        else if (ChatTextField2.gI().strChat == "% HP" && text != string.Empty)
        {
            MainMod2.SetPercentBean(text, 0);
            ChatTextField2.gI().strChat = "Chat";
            ChatTextField2.gI().tfChat.name = "chat";
            ChatTextField2.gI().tfChat.setIputType(TField2.INPUT_TYPE_ANY);
            ChatTextField2.gI().isShow = false;
        }
        else if (ChatTextField2.gI().strChat == "% MP" && text != string.Empty)
        {
            MainMod2.SetPercentBean(text, 1);
            ChatTextField2.gI().strChat = "Chat";
            ChatTextField2.gI().tfChat.name = "chat";
            ChatTextField2.gI().tfChat.setIputType(TField2.INPUT_TYPE_ANY);
            ChatTextField2.gI().isShow = false;
        }
        else if (!text.Equals(string.Empty))
        {
            Service2.gI().chat(text);
        }
    }

    public void onCancelChat()
    {
        if (isPaintMessage)
        {
            isPaintMessage = false;
            ChatTextField2.gI().center = null;
        }
    }

    public void openWeb(string strLeft, string strRight, string url, string title, string str)
    {
        isPaintAlert = true;
        isLockKey = true;
        indexRow = 0;
        setPopupSize(175, 200);
        textsTitle = title;
        texts = mFont2.tahoma_7.splitFontVector(str, popupW - 30);
        center = null;
        left = new Command2(strLeft, 11068, url);
        right = new Command2(strRight, 11069);
    }

    public void sendSms(string strLeft, string strRight, short port, string syntax, string title, string str)
    {
        isPaintAlert = true;
        isLockKey = true;
        indexRow = 0;
        setPopupSize(175, 200);
        textsTitle = title;
        texts = mFont2.tahoma_7.splitFontVector(str, popupW - 30);
        center = null;
        MyVector2 myVector = new MyVector2();
        myVector.addElement(string.Empty + port);
        myVector.addElement(syntax);
        left = new Command2(strLeft, 11074);
        right = new Command2(strRight, 11075);
    }

    public void actMenu()
    {
        GameCanvas2.panel.setTypeMain();
        GameCanvas2.panel.show();
    }

    public void openUIZone(Message2 message)
    {
        InfoDlg2.hide();
        try
        {
            zones = new int[message.reader().readByte()];
            pts = new int[zones.Length];
            numPlayer = new int[zones.Length];
            maxPlayer = new int[zones.Length];
            rank1 = new int[zones.Length];
            rankName1 = new string[zones.Length];
            rank2 = new int[zones.Length];
            rankName2 = new string[zones.Length];
            for (int i = 0; i < zones.Length; i++)
            {
                zones[i] = message.reader().readByte();
                pts[i] = message.reader().readByte();
                numPlayer[i] = message.reader().readByte();
                maxPlayer[i] = message.reader().readByte();
                sbyte b = message.reader().readByte();
                if (b == 1)
                {
                    rankName1[i] = message.reader().readUTF();
                    rank1[i] = message.reader().readInt();
                    rankName2[i] = message.reader().readUTF();
                    rank2[i] = message.reader().readInt();
                }
            }
        }
        catch (Exception ex)
        {
            Cout2.LogError("Loi ham OPEN UIZONE " + ex.ToString());
        }
        if (MainMod2.GI().userOpenZones)
        {
            GameCanvas2.panel.setTypeZone();
            GameCanvas2.panel.show();
            MainMod2.GI().userOpenZones = false;
        }
    }

    public void showViewInfo()
    {
        indexMenu = 3;
        isPaintInfoMe = true;
        setPopupSize(175, 200);
    }

    private void actDead()
    {
        MyVector2 myVector = new MyVector2();
        myVector.addElement(new Command2(mResources2.DIES[1], 110381));
        myVector.addElement(new Command2(mResources2.DIES[2], 110382));
        myVector.addElement(new Command2(mResources2.DIES[3], 110383));
        GameCanvas2.menu.startAt(myVector, 3);
    }

    public void startYesNoPopUp(string info, Command2 cmdYes, Command2 cmdNo)
    {
        popUpYesNo = new PopUpYesNo2();
        popUpYesNo.setPopUp(info, cmdYes, cmdNo);
    }

    public void player_vs_player(int playerId, int xu, string info, sbyte typePK)
    {
        Char2 @char = findCharInMap(playerId);
        if (@char != null)
        {
            if (typePK == 3)
            {
                startYesNoPopUp(info, new Command2(mResources2.OK, 2000, @char), new Command2(mResources2.CLOSE, 2009, @char));
            }
            if (typePK == 4)
            {
                startYesNoPopUp(info, new Command2(mResources2.OK, 2005, @char), new Command2(mResources2.CLOSE, 2009, @char));
            }
        }
    }

    public void giaodich(int playerID)
    {
        Char2 @char = findCharInMap(playerID);
        if (@char != null)
        {
            startYesNoPopUp(@char.cName + mResources2.want_to_trade, new Command2(mResources2.YES, 11114, @char), new Command2(mResources2.NO, 2009, @char));
        }
    }

    public void getFlagImage(int charID, sbyte cflag)
    {
        if (vFlag.size() == 0)
        {
            Service2.gI().getFlag(2, cflag);
            return;
        }
        if (charID == Char2.myCharz().charID)
        {
            if (Char2.myCharz().isGetFlagImage(cflag))
            {
                for (int i = 0; i < vFlag.size(); i++)
                {
                    PKFlag2 pKFlag = (PKFlag2)vFlag.elementAt(i);
                    if (pKFlag != null && pKFlag.cflag == cflag)
                    {
                        Char2.myCharz().flagImage = pKFlag.IDimageFlag;
                    }
                }
            }
            else if (!Char2.myCharz().isGetFlagImage(cflag))
            {
                Service2.gI().getFlag(2, cflag);
            }
            return;
        }
        if (findCharInMap(charID) == null)
        {
            return;
        }
        if (findCharInMap(charID).isGetFlagImage(cflag))
        {
            for (int j = 0; j < vFlag.size(); j++)
            {
                PKFlag2 pKFlag2 = (PKFlag2)vFlag.elementAt(j);
                if (pKFlag2 != null && pKFlag2.cflag == cflag)
                {
                    findCharInMap(charID).flagImage = pKFlag2.IDimageFlag;
                }
            }
        }
        else if (!findCharInMap(charID).isGetFlagImage(cflag))
        {
            Service2.gI().getFlag(2, cflag);
        }
    }

    public void actionPerform(int idAction, object p)
    {
        MainMod2.GI().perform(idAction, p);
        switch (idAction)
        {
            case 888351:
                Service2.gI().petStatus(5);
                GameCanvas2.endDlg();
                break;
            case 888352:
                Service2.gI().pet2Status(5);
                GameCanvas2.endDlg();
                break;
            case 11112:
                {
                    Char2 @char = (Char2)p;
                    Service2.gI().friend(1, @char.charID);
                    break;
                }
            case 11113:
                {
                    Char2 char2 = (Char2)p;
                    if (char2 != null)
                    {
                        Service2.gI().giaodich(0, char2.charID, -1, -1);
                    }
                    break;
                }
            case 11114:
                {
                    popUpYesNo = null;
                    GameCanvas2.endDlg();
                    Char2 char3 = (Char2)p;
                    if (char3 != null)
                    {
                        Service2.gI().giaodich(1, char3.charID, -1, -1);
                    }
                    break;
                }
            case 11111:
                if (Char2.myCharz().charFocus != null)
                {
                    InfoDlg2.showWait();
                    if (GameCanvas2.panel.vPlayerMenu.size() <= 0)
                    {
                        playerMenu(Char2.myCharz().charFocus);
                    }
                    GameCanvas2.panel.setTypePlayerMenu(Char2.myCharz().charFocus);
                    GameCanvas2.panel.show();
                    Service2.gI().getPlayerMenu(Char2.myCharz().charFocus.charID);
                    Service2.gI().messagePlayerMenu(Char2.myCharz().charFocus.charID);
                }
                break;
            case 11115:
                if (Char2.myCharz().charFocus != null)
                {
                    InfoDlg2.showWait();
                    Service2.gI().playerMenuAction(Char2.myCharz().charFocus.charID, (short)Char2.myCharz().charFocus.menuSelect);
                }
                break;
            case 2000:
                popUpYesNo = null;
                GameCanvas2.endDlg();
                if ((Char2)p == null)
                {
                    Service2.gI().player_vs_player(1, 3, -1);
                    break;
                }
                Service2.gI().player_vs_player(1, 3, ((Char2)p).charID);
                Service2.gI().charMove();
                break;
            case 2001:
                GameCanvas2.endDlg();
                break;
            case 2003:
                GameCanvas2.endDlg();
                InfoDlg2.showWait();
                Service2.gI().player_vs_player(0, 3, Char2.myCharz().charFocus.charID);
                break;
            case 2004:
                GameCanvas2.endDlg();
                Service2.gI().player_vs_player(0, 4, Char2.myCharz().charFocus.charID);
                break;
            case 2005:
                GameCanvas2.endDlg();
                popUpYesNo = null;
                if ((Char2)p == null)
                {
                    Service2.gI().player_vs_player(1, 4, -1);
                }
                else
                {
                    Service2.gI().player_vs_player(1, 4, ((Char2)p).charID);
                }
                break;
            case 2009:
                popUpYesNo = null;
                break;
            case 2006:
                GameCanvas2.endDlg();
                Service2.gI().player_vs_player(2, 4, Char2.myCharz().charFocus.charID);
                break;
            case 2007:
                GameCanvas2.endDlg();
                GameMidlet2.instance.exit();
                break;
            case 11038:
                actDead();
                break;
            case 110382:
                Service2.gI().returnTownFromDead();
                break;
            case 110383:
                Service2.gI().wakeUpFromDead();
                break;
            case 1:
                GameCanvas2.endDlg();
                break;
            case 2:
                GameCanvas2.menu.showMenu = false;
                break;
            case 8002:
                doFire(isFireByShortCut: false, skipWaypoint: true);
                GameCanvas2.clearKeyHold();
                GameCanvas2.clearKeyPressed();
                break;
            case 11057:
                {
                    Effect2_2.vEffect2Outside.removeAllElements();
                    Effect2_2.vEffect2.removeAllElements();
                    Npc2 npc = (Npc2)p;
                    if (npc.idItem == 0)
                    {
                        Service2.gI().confirmMenu((short)npc.template.npcTemplateId, (sbyte)GameCanvas2.menu.menuSelectedItem);
                    }
                    else if (GameCanvas2.menu.menuSelectedItem == 0)
                    {
                        Service2.gI().pickItem(npc.idItem);
                    }
                    break;
                }
            case 11000:
                actMenu();
                break;
            case 11001:
                Char2.myCharz().findNextFocusByKey();
                break;
            case 11002:
                GameCanvas2.panel.hide();
                break;
            case 11120:
                {
                    object[] array2 = (object[])p;
                    Skill2 skill4 = (Skill2)array2[0];
                    int num2 = int.Parse((string)array2[1]);
                    for (int j = 0; j < onScreenSkill.Length; j++)
                    {
                        if (onScreenSkill[j] == skill4)
                        {
                            onScreenSkill[j] = null;
                        }
                    }
                    onScreenSkill[num2] = skill4;
                    saveonScreenSkillToRMS();
                    break;
                }
            case 11121:
                {
                    object[] array = (object[])p;
                    Skill2 skill3 = (Skill2)array[0];
                    int num = int.Parse((string)array[1]);
                    for (int i = 0; i < keySkill.Length; i++)
                    {
                        if (keySkill[i] == skill3)
                        {
                            keySkill[i] = null;
                        }
                    }
                    keySkill[num] = skill3;
                    saveKeySkillToRMS();
                    break;
                }
            case 110001:
                GameCanvas2.panel.setTypeMain();
                GameCanvas2.panel.show();
                break;
            case 110004:
                GameCanvas2.menu.showMenu = false;
                break;
            case 11067:
                if (TileMap2.zoneID != indexSelect)
                {
                    Service2.gI().requestChangeZone(indexSelect, indexItemUse);
                    InfoDlg2.showWait();
                }
                else
                {
                    info1.addInfo(mResources2.ZONE_HERE, 0);
                }
                break;
            case 11059:
                {
                    Skill2 skill2 = onScreenSkill[selectedIndexSkill];
                    doUseSkill(skill2, isShortcut: false);
                    center = null;
                    break;
                }
            case 12000:
                Service2.gI().getClan(1, -1, null);
                break;
            case 12001:
                GameCanvas2.endDlg();
                break;
            case 12002:
                {
                    GameCanvas2.endDlg();
                    ClanObject2 clanObject = (ClanObject2)p;
                    Service2.gI().clanInvite(1, -1, clanObject.clanID, clanObject.code);
                    popUpYesNo = null;
                    break;
                }
            case 12003:
                {
                    ClanObject2 clanObject = (ClanObject2)p;
                    GameCanvas2.endDlg();
                    Service2.gI().clanInvite(2, -1, clanObject.clanID, clanObject.code);
                    popUpYesNo = null;
                    break;
                }
            case 12004:
                {
                    Skill2 skill = (Skill2)p;
                    doUseSkill(skill, isShortcut: true);
                    Char2.myCharz().saveLoadPreviousSkill();
                    break;
                }
            case 110391:
                Service2.gI().clanInvite(0, Char2.myCharz().charFocus.charID, -1, -1);
                break;
            case 12005:
                if (GameCanvas2.serverScr == null)
                {
                    GameCanvas2.serverScr = new ServerScr2();
                }
                GameCanvas2.serverScr.switchToMe();
                GameCanvas2.endDlg();
                break;
            case 12006:
                GameMidlet2.instance.exit();
                break;
        }
    }

    private static void setTouchBtn()
    {
        if (isAnalog != 0)
        {
            xTG = (xF = GameCanvas2.w - 45);
            if (gamePad.isLargeGamePad)
            {
                xSkill = gamePad.wZone + 20;
                wSkill = 35;
                xHP = xF - 45;
            }
            else if (gamePad.isMediumGamePad)
            {
                xHP = xF - 45;
            }
            yF = GameCanvas2.h - 45;
            yTG = yF - 45;
        }
    }

    private void updateGamePad()
    {
        if (isAnalog == 0 || Char2.myCharz().statusMe == 14)
        {
            return;
        }
        if (GameCanvas2.isPointerHoldIn(xF, yF, 40, 40))
        {
            keyTouch = 5;
            if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
            {
                GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = true;
                GameCanvas2.isPointerClick = (GameCanvas2.isPointerJustDown = (GameCanvas2.isPointerJustRelease = false));
            }
        }
        gamePad.update();
        if (GameCanvas2.isPointerHoldIn(xTG, yTG, 34, 34))
        {
            keyTouch = 13;
            GameCanvas2.isPointerJustDown = false;
            isPointerDowning = false;
            if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
            {
                Char2.myCharz().findNextFocusByKey();
                GameCanvas2.isPointerClick = (GameCanvas2.isPointerJustDown = (GameCanvas2.isPointerJustRelease = false));
            }
        }
    }

    private void paintGamePad(mGraphics2 g)
    {
        if (isAnalog != 0 && Char2.myCharz().statusMe != 14)
        {
            g.drawImage((keyTouch != 5 && keyMouse != 5) ? imgFire0 : imgFire1, xF + 20, yF + 14, mGraphics2.HCENTER | mGraphics2.VCENTER);
            gamePad.paint(g);
            g.drawImage((keyTouch != 13) ? imgFocus : imgFocus2, xTG + 20, yTG + 14, mGraphics2.HCENTER | mGraphics2.VCENTER);
            MainMod2.GI().PaintButton(g, xTG, yTG);
        }
    }

    public void showWinNumber(string num, string finish)
    {
        winnumber = new int[num.Length];
        randomNumber = new int[num.Length];
        tMove = new int[num.Length];
        moveCount = new int[num.Length];
        delayMove = new int[num.Length];
        try
        {
            for (int i = 0; i < num.Length; i++)
            {
                winnumber[i] = short.Parse(num[i].ToString());
                randomNumber[i] = Res2.random(0, 11);
                tMove[i] = 1;
                delayMove[i] = 0;
            }
        }
        catch (Exception)
        {
        }
        tShow = 100;
        moveIndex = 0;
        strFinish = finish;
        lastXS = (currXS = mSystem2.currentTimeMillis());
    }

    public void chatVip(string chatVip)
    {
        if (!startChat)
        {
            currChatWidth = mFont2.tahoma_7b_yellowSmall.getWidth(chatVip);
            xChatVip = GameCanvas2.w;
            startChat = true;
        }
        if (chatVip.StartsWith("!"))
        {
            chatVip = chatVip.Substring(1, chatVip.Length);
            isFireWorks = true;
        }
        vChatVip.addElement(chatVip);
        if (chatVip.Trim().ToLower().Contains("boss") && chatVip.Trim().ToLower().Contains("xuất hiện"))
        {
            MainMod2.bossNotif.addElement(new ShowBoss(chatVip));
            if (MainMod2.bossNotif.size() > 5)
            {
                MainMod2.bossNotif.removeElementAt(0);
            }
        }
    }

    public void clearChatVip()
    {
        vChatVip.removeAllElements();
        xChatVip = GameCanvas2.w;
        startChat = false;
    }

    public void paintChatVip(mGraphics2 g)
    {
        if (vChatVip.size() != 0 && isPaintChatVip)
        {
            g.setClip(0, GameCanvas2.h - 13, GameCanvas2.w, 15);
            g.fillRect(0, GameCanvas2.h - 13, GameCanvas2.w, 15, 0, 90);
            string st = (string)vChatVip.elementAt(0);
            mFont2.tahoma_7b_yellow.drawStringBorder(g, st, xChatVip, GameCanvas2.h - 13, 0, mFont2.tahoma_7b_dark);
        }
    }

    public void updateChatVip()
    {
        if (!startChat)
        {
            return;
        }
        xChatVip -= 2;
        if (xChatVip < -currChatWidth)
        {
            xChatVip = GameCanvas2.w;
            vChatVip.removeElementAt(0);
            if (vChatVip.size() == 0)
            {
                isFireWorks = false;
                startChat = false;
            }
            else
            {
                currChatWidth = mFont2.tahoma_7b_white.getWidth((string)vChatVip.elementAt(0));
            }
        }
    }

    public void showYourNumber(string strNum)
    {
        yourNumber = strNum;
        strPaint = mFont2.tahoma_7.splitFontArray(yourNumber, 500);
    }

    public static void checkRemoveImage()
    {
        ImgByName2.checkDelHash(ImgByName2.hashImagePath, 10, isTrue: false);
    }

    public static void StartServerPopUp(string strMsg)
    {
        GameCanvas2.endDlg();
        int avatar = 1139;
        Npc2 npc = new Npc2(-1, 0, 0, 0, 0, 0);
        npc.avatar = avatar;
        ChatPopup2.addBigMessage(strMsg, 100000, npc);
        ChatPopup2.serverChatPopUp.cmdMsg1 = new Command2(mResources2.CLOSE, ChatPopup2.serverChatPopUp, 1001, null);
        ChatPopup2.serverChatPopUp.cmdMsg1.x = GameCanvas2.w / 2 - 35;
        ChatPopup2.serverChatPopUp.cmdMsg1.y = GameCanvas2.h - 35;
    }

    public static bool ispaintPhubangBar()
    {
        if (TileMap2.mapPhuBang() && phuban_Info.type_PB == 0)
        {
            return true;
        }
        return false;
    }

    public void paintPhuBanBar(mGraphics2 g, int x, int y, int w)
    {
        if (phuban_Info == null || isPaintOther || isPaintRada != 1 || GameCanvas2.panel.isShow || !ispaintPhubangBar())
        {
            return;
        }
        if (w < fra_PVE_Bar_1.frameWidth + fra_PVE_Bar_0.frameWidth * 4)
        {
            w = fra_PVE_Bar_1.frameWidth + fra_PVE_Bar_0.frameWidth * 4;
        }
        if (x > GameCanvas2.w - w / 2)
        {
            x = GameCanvas2.w - w / 2;
        }
        if (x < mGraphics2.getImageWidth(imgKhung) + w / 2 + 10)
        {
            x = mGraphics2.getImageWidth(imgKhung) + w / 2 + 10;
        }
        int frameHeight = fra_PVE_Bar_0.frameHeight;
        int num = y + frameHeight + mGraphics2.getImageHeight(imgBall) / 2 + 2;
        int frameWidth = fra_PVE_Bar_1.frameWidth;
        int num2 = w / 2 - frameWidth / 2;
        int num3 = x - w / 2;
        int num4 = x + frameWidth / 2;
        int y2 = y + 3;
        int num5 = num2 - fra_PVE_Bar_0.frameWidth;
        int num6 = num5 / fra_PVE_Bar_0.frameWidth;
        if (num5 % fra_PVE_Bar_0.frameWidth > 0)
        {
            num6++;
        }
        for (int i = 0; i < num6; i++)
        {
            if (i < num6 - 1)
            {
                fra_PVE_Bar_0.drawFrame(1, num3 + fra_PVE_Bar_0.frameWidth + i * fra_PVE_Bar_0.frameWidth, y2, 0, 0, g);
            }
            else
            {
                fra_PVE_Bar_0.drawFrame(1, num3 + num5, y2, 0, 0, g);
            }
            if (i < num6 - 1)
            {
                fra_PVE_Bar_0.drawFrame(1, num4 + i * fra_PVE_Bar_0.frameWidth, y2, 0, 0, g);
            }
            else
            {
                fra_PVE_Bar_0.drawFrame(1, num4 + num5 - fra_PVE_Bar_0.frameWidth, y2, 0, 0, g);
            }
        }
        fra_PVE_Bar_0.drawFrame(0, num3, y2, 2, 0, g);
        fra_PVE_Bar_0.drawFrame(0, num4 + num5, y2, 0, 0, g);
        if (phuban_Info.pointTeam1 > 0)
        {
            int idx = 2;
            int idx2 = 3;
            if (phuban_Info.color_1 == 4)
            {
                idx = 4;
                idx2 = 5;
            }
            int num7 = phuban_Info.pointTeam1 * num2 / phuban_Info.maxPoint;
            if (num7 < 0)
            {
                num7 = 0;
            }
            if (num7 > num2)
            {
                num7 = num2;
            }
            g.setClip(num3 + num2 - num7, y2, num7, frameHeight);
            for (int j = 0; j < num6; j++)
            {
                if (j < num6 - 1)
                {
                    fra_PVE_Bar_0.drawFrame(idx2, num3 + fra_PVE_Bar_0.frameWidth + j * fra_PVE_Bar_0.frameWidth, y2, 0, 0, g);
                }
                else
                {
                    fra_PVE_Bar_0.drawFrame(idx2, num3 + num5, y2, 0, 0, g);
                }
            }
            fra_PVE_Bar_0.drawFrame(idx, num3, y2, 2, 0, g);
            GameCanvas2.resetTrans(g);
        }
        if (phuban_Info.pointTeam2 > 0)
        {
            int idx3 = 2;
            int idx4 = 3;
            if (phuban_Info.color_2 == 4)
            {
                idx3 = 4;
                idx4 = 5;
            }
            int num8 = phuban_Info.pointTeam2 * num2 / phuban_Info.maxPoint;
            if (num8 < 0)
            {
                num8 = 0;
            }
            if (num8 > num2)
            {
                num8 = num2;
            }
            g.setClip(num4, y2, num8, frameHeight);
            for (int k = 0; k < num6; k++)
            {
                if (k < num6 - 1)
                {
                    fra_PVE_Bar_0.drawFrame(idx4, num4 + k * fra_PVE_Bar_0.frameWidth, y2, 0, 0, g);
                }
                else
                {
                    fra_PVE_Bar_0.drawFrame(idx4, num4 + num5 - fra_PVE_Bar_0.frameWidth, y2, 0, 0, g);
                }
            }
            fra_PVE_Bar_0.drawFrame(idx3, num4 + num5, y2, 0, 0, g);
            GameCanvas2.resetTrans(g);
        }
        fra_PVE_Bar_1.drawFrame(0, x - frameWidth / 2, y, 0, 0, g);
        string timeCountDown = mSystem2.getTimeCountDown(phuban_Info.timeStart, phuban_Info.timeSecond, isOnlySecond: true, isShortText: false);
        mFont2.tahoma_7b_yellow.drawString(g, timeCountDown, x + 1, y + fra_PVE_Bar_1.frameHeight / 2 - mFont2.tahoma_7b_green2.getHeight() / 2, 2);
        Panel2.setTextColor(phuban_Info.color_1, 1).drawString(g, phuban_Info.nameTeam1, x - 5, num + 5, 1);
        Panel2.setTextColor(phuban_Info.color_2, 1).drawString(g, phuban_Info.nameTeam2, x + 5, num + 5, 0);
        if (phuban_Info.type_PB != 0)
        {
            int y3 = y + frameHeight / 2 - 2;
            mFont2.bigNumber_While.drawString(g, string.Empty + phuban_Info.pointTeam1, num3 + num2 / 2, y3, 2);
            mFont2.bigNumber_While.drawString(g, string.Empty + phuban_Info.pointTeam2, num4 + num2 / 2, y3, 2);
        }
        g.drawImage(imgVS, x, y + fra_PVE_Bar_1.frameHeight + 2, 3);
        if (phuban_Info.type_PB == 0)
        {
            paintChienTruong_Life(g, phuban_Info.maxLife, phuban_Info.color_1, phuban_Info.lifeTeam1, x - 13, phuban_Info.color_2, phuban_Info.lifeTeam2, x + 13, num);
        }
    }

    public static void paintChienTruong_Life(mGraphics2 g, int maxLife, int cl1, int lifeTeam1, int x1, int cl2, int lifeTeam2, int x2, int y)
    {
        if (imgBall == null)
        {
            return;
        }
        int num = mGraphics2.getImageHeight(imgBall) / 2;
        for (int i = 0; i < maxLife; i++)
        {
            int num2 = 0;
            if (i < lifeTeam1)
            {
                num2 = 1;
            }
            g.drawRegion(imgBall, 0, num2 * num, mGraphics2.getImageWidth(imgBall), num, 0, x1 - i * (num + 1), y, mGraphics2.VCENTER | mGraphics2.HCENTER);
        }
        for (int j = 0; j < maxLife; j++)
        {
            int num3 = 0;
            if (j < lifeTeam2)
            {
                num3 = 1;
            }
            g.drawRegion(imgBall, 0, num3 * num, mGraphics2.getImageWidth(imgBall), num, 0, x2 + j * (num + 1), y, mGraphics2.VCENTER | mGraphics2.HCENTER);
        }
    }

    public static void paintHPBar_NEW(mGraphics2 g, int x, int y, Char2 c)
    {
        g.drawImage(imgKhung, x, y, 0);
        int x2 = x + 3;
        int num = y + 19;
        int num2 = 0;
        int num3 = 0;
        int width = imgHP_NEW.getWidth();
        int num4 = imgHP_NEW.getHeight() / 2;
        num2 = (int)(c.cHP * width / c.cHPFull);
        if (num2 <= 0)
        {
            num2 = 1;
        }
        else if (num2 > width)
        {
            num2 = width;
        }
        g.drawRegion(imgHP_NEW, 0, num4, num2, num4, 0, x2, num, 0);
        num3 = (int)(c.cMP * width / c.cMPFull);
        if (num3 <= 0)
        {
            num3 = 1;
        }
        else if (num3 > width)
        {
            num3 = width;
        }
        g.drawRegion(imgHP_NEW, 0, 0, num3, num4, 0, x2, num + 6, 0);
        int x3 = x + imgKhung.getWidth() / 2 + 1;
        int y2 = num + 13;
        mFont2.tahoma_7_green2.drawString(g, c.cName, x3, y + 4, 2);
        if (c.mobFocus != null)
        {
            if (c.mobFocus.getTemplate() != null)
            {
                mFont2.tahoma_7_green2.drawString(g, c.mobFocus.getTemplate().name, x3, y2, 2);
            }
        }
        else if (c.npcFocus != null)
        {
            mFont2.tahoma_7_green2.drawString(g, c.npcFocus.template.name, x3, y2, 2);
        }
        else if (c.charFocus != null)
        {
            mFont2.tahoma_7_green2.drawString(g, c.charFocus.cName, x3, y2, 2);
        }
    }

    public static void addEffectEnd(int type, int subtype, int typePaint, int x, int y, int levelPaint, int dir, short timeRemove, Point2[] listObj)
    {
        Effect_End2 eff = new(type, subtype, typePaint, x, y, levelPaint, dir, timeRemove, listObj);
        addEffect2Vector(eff);
    }

    public static void addEffectEnd(int type, int subtype, int typePaint, int x, int y, int levelPaint, int dir, short timeRemove, Point2[] listObj, sbyte level)
    {
        Effect_End2 eff = new(type, subtype, typePaint, x, y, levelPaint, dir, timeRemove, listObj, level);
        addEffect2Vector(eff);
    }

    public static void addEffectEnd_Target(int type, int subtype, int typePaint, Char2 charUse, Point2 target, int levelPaint, short timeRemove, short range, sbyte level)
    {
        Effect_End2 eff = new(type, subtype, typePaint, charUse.clone(), target, levelPaint, timeRemove, range, level);
        addEffect2Vector(eff);
    }

    public static void addEffect2Vector(Effect_End2 eff)
    {
        if (eff.levelPaint == 0)
        {
            EffectManager2.addHiEffect(eff);
        }
        else if (eff.levelPaint == 1)
        {
            EffectManager2.addMidEffects(eff);
        }
        else if (eff.levelPaint == 2)
        {
            EffectManager2.addMid_2Effects(eff);
        }
        else
        {
            EffectManager2.addLowEffect(eff);
        }
    }

    public static bool setIsInScreen(int x, int y, int wOne, int hOne)
    {
        if (x < cmx - wOne || x > cmx + GameCanvas2.w + wOne || y < cmy - hOne || y > cmy + GameCanvas2.h + hOne * 3 / 2)
        {
            return false;
        }
        return true;
    }

    public static bool isSmallScr()
    {
        if (GameCanvas2.w <= 320)
        {
            return true;
        }
        return false;
    }

    private void paint_xp_bar(mGraphics2 g)
    {
        g.setColor(8421504);
        g.fillRect(0, GameCanvas2.h - 2, GameCanvas2.w, 2);
        int w = (int)(Char2.myCharz().cLevelPercent * GameCanvas2.w / 10000);
        g.setColor(16777215);
        g.fillRect(0, GameCanvas2.h - 2, w, 2);
        g.setColor(0);
        w = GameCanvas2.w / 10;
        for (int i = 1; i < 10; i++)
        {
            g.fillRect(i * w, GameCanvas2.h - 2, 1, 2);
        }
    }

    private void paint_ios_bg(mGraphics2 g)
    {
        if (mSystem2.clientType == 5)
        {
            if (imgBgIOS != null)
            {
                g.setColor(16777215);
                g.fillRect(0, 0, GameCanvas2.w, GameCanvas2.h);
                g.drawImage(imgBgIOS, GameCanvas2.w / 2, GameCanvas2.h / 2, mGraphics2.VCENTER | mGraphics2.HCENTER);
            }
            else
            {
                int num = ((TileMap2.bgID % 2 != 0) ? 1 : 2);
                imgBgIOS = GameCanvas2.loadImage("/bg/bg_ios_" + num + ".png");
            }
        }
    }
}
