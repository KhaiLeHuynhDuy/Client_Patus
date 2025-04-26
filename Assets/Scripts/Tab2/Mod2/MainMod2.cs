using Mod;
using Mod2;
using Mod2.XMAP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine;

public class MainMod2 : IActionListener2
{
    private static MainMod2 Instance;

    public bool canUpdate = false;

    private long lastAutoAttack = 0;

    private readonly List<Skill2> listSkillsAuto = new();

    public static List<ItemAuto> listItemAuto = new();

    public static bool notifBoss = true;

    private bool lineToBoss;

    private bool focusBoss = false;

    private long lastFocusBoss;

    public static MyVector2 bossNotif = new();

    private long lastUpdateZones = 0;

    public bool isUpdateZones = false;

    public bool userOpenZones = false;

    public static bool showCharsInMap = true;

    public MyVector2 charsInMap = new();

    public static bool showInfoPet = false;

    private long lastUpdateInfoMe = 0;

    public bool autoAttack = false;

    public bool autoWakeUp = false;

    public long lastAutoWakeUp = 0;

    // --- START: Auto pha le hoa

    public static bool isAutoPhaLe = false;

    public static Item2 itemPhale;

    public static int maxPhale = -1;

    public static int currPhale = -1;

    private static byte statusPhale = 0; // 0 : cần đến Đảo Kame, 1: đang pha lê, 2: đã xong, 3: đang bán vàng

    // --- END: Auto pha le hoa

    public static bool isAutoLogin = false;

    // --- START: Auto quay thuong de

    public static bool isAutoVQMM = false;

    public static bool fullChestVQMM = false;

    public static long lastVQMM;

    public static long lastDoMenu;

    public static int stepMenuVQMM = 0;

    // --- END: Auto quay thuong de

    // --- START: Auto buy item

    private static int QUAN_BUY = 20;

    public static Item2 itemBuy = null;

    private static int quanBuy = QUAN_BUY;

    private static long lastTimeAutoBuy = 0;

    // --- END: Auto buy item

    public static bool isShowQuickButton = true;

    public static bool isShowXMAPButton = true;

    // public bool isIntroOff = false;

    public static bool isHighFps = true;

    // --- START: Auto Intrinsic

    private static int paramIntrinsic = -1;

    public static string curSelectIntrinsic = "";

    private static byte stepMenuIntrinsic = 0;

    private static long lastAutoIntrinsic = 0;

    // --- END: Auto Intrinsic

    public static string strAddAutoItem = "Thêm vào\nAutoItem";

    public static string strRemoveAutoItem = "Xoá khỏi\nAutoItem";

    public static string strTeleportTo = "Dịch\nchuyển tới";

    public static string strAutoBuy = "Mua 20 lần";

    public static string strChooseIntrinsic = "Chọn chỉ số";

    public static string strInCrease = "Tăng\ntới\nmức";

    public static string[] strPointTypes = { "HP", "MP", "Sức Đánh", "Giáp", "Chí mạng" };

    public static string strAccManager = "Q.L.T.K";

    public static string strModFunc = "Chức Năng MOD";

    public static string strUpdateZones = "Cập Nhật Khu";

    public static string strCharsInMap = "Nhân Vật Trong Khu";

    public static string strInfoPet = "Thông Tin Đệ Tử";

    public static string strAutoPhaLe = "Tự Động Pha Lê Hóa";

    public static string strAutoVQMM = "Tự Động VQMM";

    public static string strAutoWakeUp = "Tự Động Hồi Sinh";

    public static string strAutoLogin = "Tự Động Đăng Nhập";

    public static string strQuickButton = "Phím Tắt";

    public static string strXMAPButton = "Phím XMAP";

    // public static string strIntroOff = "Tắt Intro";

    public static string strHighFps = "FPS Cao";

    public static string strClickToChat = " [Ấn để chat]";

    public static string strPlayerInfo = "Thông tin player";

    public static string strPet2 = "Người iuu";

    public static string strUseForPet2 = "Sử dụng\ncho\nNg.iuu";

    public static string strBossNotif = "Thông báo Boss";

    public MyVector2 listNotifTichXanh = new();

    private bool startChat = false;

    private int xNotif;

    private long lastUpdateNotif;

    // Start: Auto Bean

    public static bool isAutoBean = false;

    public static int percentBeanHP = 20;

    public static int percentBeanMP = 20;

    public static bool isAutoBeanPet = false;

    private static long lastAutoBean = 0;

    // End: Auto Bean

    private long lastActiveGoback = 0;

    // --- START: Auto Point

    public static int indexAutoPoint = -1;

    public static int pointIncrease = 0;

    public static int typePointForPet = 16;

    public static long lastAutoPoint = 0;

    // --- END: Auto Point

    private static int modKeyPosX;

    private static int modKeyPosY;

    public static Command2 cmdAccManager;

    public static bool isOpenAccMAnager = false;

    public static List<Account> accounts = new();

    public List<Command2> cmdsChooseAcc = new();

    public List<Command2> cmdsDelAcc = new();

    public static Command2 cmdCloseAccManager;

    public static bool startAutoItem = false;

    private static bool isAutoChat = false;

    private static string textAutoChat = string.Empty;

    private static bool isAutoChatTG = false;

    private static string textAutoChatTG = string.Empty;

    private long lastAutoChat = 0;

    private long lastAutoChatTG = 0;

    public static string ipServer = "Đổi IP";

    public static bool userOpenPet = false;

    public static bool isLockFocus = false;

    //private long lastUpdateFPS;

    //private static int lastFps;

    public static Image2[] redTicks = new Image2[20];

    public static Image2[] blueTicks = new Image2[20];

    private static readonly Image2[] logos = new Image2[30];

    public static Image2 imgLogoBig = null;

    public static Image2 imgBg = null;

    public static Image2 imgCapsule = null;

    public static Image2 imgCapsuleF = null;

    public static Image2 imgPorata = null;

    public static Image2 imgPorataF = null;

    public static Image2 imgZone = null;

    public static Image2 imgZoneF = null;

    public static Image2 imgNextMap = null;

    public static Image2 imgNextMapF = null;

    public static Image2 imgPreMap = null;

    public static Image2 imgPreMapF = null;

    public static Image2 imgMidMap = null;

    public static Image2 imgMidMapF = null;

    public static int IMAGE_SIZE = 1;

    public static string pasteText = "";

    public static string sceneName = "Main2";

    public static int logoW;

    public static int logoH;

    public static AutoLogin autoLogin;

    public MainMod2()
    {
        LoadSettings();
    }

    private static void LoadSettings()
    {
        try
        {
            // FPS ; CharsInMap ; QuickButton ; XMAPButton ; %HP ; %MP ; notifBoss
            string strSettings = Rms2.loadRMSString("ModSettings");
            if (strSettings != null && strSettings.Length > 0)
            {
                string[] settings = strSettings.Split(new char[] { ';' });
                if (settings.Length == 7)
                {
                    isHighFps = settings[0] == "1";
                    showCharsInMap = settings[1] == "1";
                    isShowQuickButton = settings[2] == "1";
                    isShowXMAPButton = settings[3] == "1";
                    percentBeanHP = int.TryParse(settings[4], out int pHP) ? pHP : 20;
                    percentBeanMP = int.TryParse(settings[5], out int pMP) ? pMP : 20;
                    notifBoss = settings[6] == "1";
                }
            }
            textAutoChat = Rms2.loadRMSString("ModAutoChat");
            textAutoChatTG = Rms2.loadRMSString("ModAutoChatTG");
            return;
        }
        catch
        {
        }

        isHighFps = true;
        showCharsInMap = true;
        isShowQuickButton = true;
        isShowXMAPButton = true;
        percentBeanHP = 20;
        percentBeanMP = 20;
        notifBoss = true;
        textAutoChat = "Client được cung cấp bởi PATUS";
        textAutoChatTG = "Client được cung cấp bởi PATUS";
    }

    public static void SaveSettings()
    {
        string settings = (isHighFps ? "1" : "0") + ";"
            + (showCharsInMap ? "1" : "0") + ";"
            + (isShowQuickButton ? "1" : "0") + ";"
            + (isShowXMAPButton ? "1" : "0") + ";"
            + percentBeanHP + ";"
            + percentBeanMP + ";"
            + (notifBoss ? "1" : "0");
        Rms2.saveRMSString("ModSettings", settings);
    }

    public static MainMod2 GI()
    {
        Instance ??= new MainMod2();
        return Instance;
    }

    public void OpenMenu()
    {
        MyVector2 myVector = new();
        myVector.addElement(new Command2("Bản đồ", 883));
        myVector.addElement(new Command2("Luyện tập", 45));
        myVector.addElement(new Command2("Nhặt đồ", 89));
        myVector.addElement(new Command2("Đậu thần", 3));
        myVector.addElement(new Command2("BOSS", 32));
        myVector.addElement(new Command2("Khác", 53));
        GameCanvas2.menu.startAt(myVector, 4);
    }

    public bool UpdateKey(int key)
    {
        switch (key)
        {
            case 'a':
                // LEFT
                MoveTo(Char2.myCharz().cx - 100, Char2.myCharz().cy);
                break;
            case 'w':
                // UP
                MoveTo(Char2.myCharz().cx, Char2.myCharz().cy - 100);
                break;
            case 's':
                // DOWN
                MoveTo(Char2.myCharz().cx, Char2.myCharz().cy + 100);
                break;
            case 'd':
                // RIGHT
                MoveTo(Char2.myCharz().cx + 100, Char2.myCharz().cy);
                break;
            case 'e':
                // Friend
                Service2.gI().friend(0, -1);
                InfoDlg2.showWait();
                break;
            case 'h':
                // Update khu
                GameScr2.gI().onChatFromMe("ukhu", string.Empty);
                break;
            case 'u':
                // Auto attack
                perform(42, null);
                break;
            case 'x':
                OpenMenu();
                break;
            case 'f':
                UsePorata();
                break;
            case 'c':
                UseItem(194);
                break;
            case 'm':
                userOpenZones = true;
                Service2.gI().openUIZone();
                break;
            case 't':
                UseItem(521);
                break;
            case 'n':
                PickMob2.IsAutoPickItems = !PickMob2.IsAutoPickItems;
                GameScr2.info1.addInfo("Tự động nhặt: " + (PickMob2.IsAutoPickItems ? "Bật" : "Tắt"), 0);
                break;
            case 'j':
                ManualXmap2.GI().LoadMapLeft();
                break;
            case 'k':
                ManualXmap2.GI().LoadMapCenter();
                break;
            case 'l':
                ManualXmap2.GI().LoadMapRight();
                break;
            case 'g':
                if (Char2.myCharz().charFocus != null)
                {
                    Service2.gI().giaodich(0, Char2.myCharz().charFocus.charID, -1, -1);
                    GameScr2.info1.addInfo("Đã gửi lời mời giao dịch đến " + Char2.myCharz().charFocus.cName, 0);
                }
                break;
            default:
                return false;
        }
        return true;
    }

    public void LoadGame()
    {
        Time.timeScale = 1.5f;
        listSkillsAuto.Clear();
        listItemAuto.Clear();
        ChangeFPSTarget();
    }

    public static void MoveTo(int x, int y)
    {
        Char2.myCharz().cx = x;
        Char2.myCharz().cy = y;
        Service2.gI().charMove();
        Char2.myCharz().cx = x;
        Char2.myCharz().cy = y + 1;
        Service2.gI().charMove();
        Char2.myCharz().cx = x;
        Char2.myCharz().cy = y;
        Service2.gI().charMove();
    }

    public static void GotoNpc(int npcID)
    {
        for (int i = 0; i < GameScr2.vNpc.size(); i++)
        {
            Npc2 npc = (Npc2)GameScr2.vNpc.elementAt(i);
            if (npc.template.npcTemplateId == npcID && Math2.abs(npc.cx - Char2.myCharz().cx) >= 50)
            {
                MoveTo(npc.cx, npc.cy - 1);
                Char2.myCharz().FocusManualTo(npc);
                return;
            }
        }
    }

    public static int FindItemIndex(int idItem)
    {
        if (Char2.myCharz().arrItemBag == null)
        {
            return -1;
        }
        for (int i = 0; i < Char2.myCharz().arrItemBag.Length; i++)
        {
            if (Char2.myCharz().arrItemBag[i] != null && Char2.myCharz().arrItemBag[i].template.id == idItem)
            {
                return Char2.myCharz().arrItemBag[i].indexUI;
            }
        }
        return -1;
    }

    private void AttackChar()
    {
        try
        {
            MyVector2 myVector = new();
            myVector.addElement(Char2.myCharz().charFocus);
            Service2.gI().sendPlayerAttack(new MyVector2(), myVector, 2);
        }
        catch
        {
        }
    }

    public void AttackMob(Mob2 mob)
    {
        try
        {
            MyVector2 myVector = new();
            myVector.addElement(mob);
            Service2.gI().sendPlayerAttack(myVector, new MyVector2(), 1);
        }
        catch
        {
        }
    }

    public void AutoAttack()
    {
        Char2 @char = Char2.myCharz();
        if (!Char2.isLoadingMap
            && !@char.stone
            && !@char.meDead
            && @char.statusMe != 14
            && @char.statusMe != 5
            && @char.myskill.template.type == 1
            && @char.myskill.template.id != 10
            && @char.myskill.template.id != 11
            && PickMobController2.CanUseSkill(@char.myskill))
        {
            if (mSystem2.currentTimeMillis() - lastAutoAttack > 500)
            {
                if (GameScr2.gI().isMeCanAttackMob(@char.mobFocus) && Res2.abs(@char.mobFocus.xFirst - @char.cx) < @char.myskill.dx * 2)
                {
                    AttackMob(@char.mobFocus);
                    SetUsedSkill(@char.myskill);
                }
                else if (@char.isMeCanAttackOtherPlayer(@char.charFocus) && Res2.abs(@char.charFocus.cx - @char.cx) < @char.myskill.dx * 2)
                {
                    AttackChar();
                    SetUsedSkill(@char.myskill);
                }
                lastAutoAttack = mSystem2.currentTimeMillis();
            }
        }
    }

    public void SetUsedSkill(Skill2 skill)
    {
        skill.paintCanNotUseSkill = true;
        skill.lastTimeUseThisSkill = mSystem2.currentTimeMillis();
    }

    public void UsePorata()
    {
        int[] ids = new int[] { 454, 921, 1172, 1177, 1344 };
        foreach (int num in ids)
        {
            int index = FindItemIndex(num);
            if (index != -1)
            {
                Service2.gI().useItem(0, 1, (sbyte)index, -1);
                Service2.gI().petStatus(3);
                return;
            }
        }
        GameScr2.info1.addInfo("Bạn không có bông tai", 0);
    }

    public void AutoFocusBoss()
    {
        for (int i = 0; i < GameScr2.vCharInMap.size(); i++)
        {
            Char2 @char = (Char2)GameScr2.vCharInMap.elementAt(i);
            if (@char != null && @char.charID < 0 && @char.cTypePk == 5 && !@char.cName.StartsWith("Đ"))
            {
                Char2.myCharz().FocusManualTo(@char);
                return;
            }
        }
    }

    public int GetMapID(string mapName)
    {
        int result = -1;
        for (int i = 0; i < XmapController2.mapNames.Length; i++)
        {
            if (XmapController2.mapNames[i].Trim().ToLower().Equals(mapName.Trim().ToLower()))
            {
                result = i;
            }
        }
        return result;
    }

    private string CharGender(Char2 @char)
    {
        string result;
        if (@char.cTypePk == 5)
        {
            result = "BOSS";
        }
        else if (@char.cgender == 0)
        {
            result = "TĐ";
        }
        else if (@char.cgender == 1)
        {
            result = "NM";
        }
        else if (@char.cgender == 2)
        {
            result = "XD";
        }
        else
        {
            result = "";
        }
        return result;
    }

    public void UseItem(int itemId)
    {
        int index = FindItemIndex(itemId);
        if (index != -1)
        {
            Service2.gI().useItem(0, 1, (sbyte)index, -1);
            return;
        }
        GameScr2.info1.addInfo("Không tìm thấy vật phẩm", 0);
    }

    public void UseItemAuto()
    {
        if (!startAutoItem)
        {
            System.Threading.Tasks.Task.Delay(10000).ContinueWith(t => startAutoItem = true);
            return;
        }
        if (listItemAuto.Count > 0 && startAutoItem)
        {
            for (int i = 0; i < Char2.myCharz().arrItemBag.Length; i++)
            {
                Item2 item = Char2.myCharz().arrItemBag[i];
                foreach (ItemAuto itemAuto in listItemAuto)
                {
                    if (item != null && item.template.iconID == itemAuto.iconID && item.template.id == itemAuto.id && !ItemTime2.isExistItem(item.template.iconID))
                    {
                        Service2.gI().useItem(0, 1, (sbyte)FindItemIndex(item.template.id), -1);
                        break;
                    }
                }
            }
        }
    }

    private void AutoHoiSinh()
    {
        if (Char2.myCharz().cHP <= 0 || Char2.myCharz().meDead || Char2.myCharz().statusMe == 14)
        {
            Service2.gI().wakeUpFromDead();
        }
    }

    public static bool AutoLogin()
    {
        if (autoLogin == null)
        {
            return false;
        }

        if (autoLogin.waitToNextLogin)
        {
            return true;
        }

        if (!Util.CanDoWithTime(autoLogin.lastTimeWait, 1000))
        {
            return false;
        }

        if (ServerListScreen2.testConnect != 2)
        {
            GameCanvas2.serverScreen ??= new ServerListScreen2();
            GameCanvas2.serverScreen.switchToMe();
            autoLogin.lastTimeWait = mSystem2.currentTimeMillis();
            return false;
        }

        if (GameCanvas2.currentScreen != GameCanvas2.loginScr)
        {
            GameCanvas2.loginScr ??= new LoginScr2();
            GameCanvas2.loginScr.switchToMe();
            autoLogin.lastTimeWait = mSystem2.currentTimeMillis();
            return false;
        }

        if (!autoLogin.hasSetUserPass)
        {
            Account account = autoLogin.GetAccWithUsername(accounts);
            if (account.getUsername().Length > 0)
            {
                Rms2.saveRMSString("acc", account.getUsername());
                Rms2.saveRMSString("pass", account.getPassword());
                if (GameCanvas2.currentScreen == GameCanvas2.loginScr)
                {
                    GameCanvas2.loginScr.setUserPass();
                }
                autoLogin.hasSetUserPass = true;
            }
            autoLogin.lastTimeWait = mSystem2.currentTimeMillis();
        }

        GameCanvas2.loginScr.doLogin();
        autoLogin.waitToNextLogin = true;
        return true;
    }

    public static int GetCurrPhaLe(Item2 item)
    {
        for (int i = 0; i < item.itemOption.Length; i++)
        {
            if (item.itemOption[i].optionTemplate.id == 107)
            {
                return item.itemOption[i].param;
            }
        }
        return 0;
    }

    public static void AutoPhaLe()
    {
        while (isAutoPhaLe)
        {
            if (TileMap2.mapID == 5)
            {
                if (currPhale >= maxPhale && itemPhale != null && currPhale >= 0 && maxPhale > 0)
                {
                    statusPhale = 2;
                    maxPhale = -1;
                    itemPhale = null;
                }
                else if (Char2.myCharz().xu > 1_000_000_000L)
                {
                    GotoNpc(21);
                    if (itemPhale != null && maxPhale > 0)
                    {
                        statusPhale = 1;
                        while (!GameCanvas2.menu.showMenu)
                        {
                            Service2.gI().combine(1, GameCanvas2.panel.vItemCombine);
                            Thread.Sleep(100);
                        }
                        GameCanvas2.menu.menuSelectedItem = 0;
                        GameCanvas2.menu.performSelect();
                        GameCanvas2.menu.doCloseMenu();
                    }
                }
                else if (itemPhale != null)
                {
                    statusPhale = 3;
                    BanVang();
                }
            }
            else
            {
                statusPhale = 0;
            }
            Thread.Sleep(400);
        }
    }

    private static void BanVang()
    {
        while (Char2.myCharz().xu <= 60_000_000_000L)
        {
            if (FindItemIndex(457) == -1)
            {
                isAutoPhaLe = false;
            }
            else
            {
                Service2.gI().useItem(0, 1, (sbyte)FindItemIndex(457), -1);
            }
            Thread.Sleep(200);
        }
    }

    public static Item2 FindItemBagWithIndexUI(int index)
    {
        foreach (Item2 item in Char2.myCharz().arrItemBag)
        {
            if (item != null && item.indexUI == index)
            {
                return item;
            }
        }
        return null;
    }

    private byte IndexMenuVQMM()
    {
        byte index = 0;
        for (byte i = 0; i < GameCanvas2.menu.menuItems.size(); i++)
        {
            try
            {
                string caption;
                Command2 command = (Command2)GameCanvas2.menu.menuItems.elementAt(i);
                if (command.subCaption.Length > 0)
                {
                    caption = string.Join(" ", command.subCaption);
                }
                else
                {
                    caption = command.caption;
                }
                if (caption.ToLower().Contains("rương") && caption.ToLower().Contains("món"))
                {
                    index = i;
                    break;
                }
                if (caption.ToLower().Contains("quay số")
                || caption.ToLower().Contains("vòng quay")
                || caption.ToLower().Contains("may mắn"))
                {
                    index = i;
                    break;
                }
            }
            catch
            {
                break;
            }
        }
        return index;
    }

    public void CollectChestVQMM()
    {
        switch (stepMenuVQMM)
        {
            case 0:
                Service2.gI().openMenu(19);
                stepMenuVQMM = 1;
                break;
            case 1:
                GameCanvas2.menu.menuSelectedItem = IndexMenuVQMM();
                GameCanvas2.menu.performSelect();
                GameCanvas2.menu.doCloseMenu();
                stepMenuVQMM = 2;
                break;
            case 2:
                GameCanvas2.menu.menuSelectedItem = IndexMenuVQMM();
                GameCanvas2.menu.performSelect();
                GameCanvas2.menu.doCloseMenu();
                stepMenuVQMM = -1;
                break;
            default:
                break;
        }
        if (stepMenuVQMM == -1)
        {
            Service2.gI().buyItem(2, 0, 0);
            GameCanvas2.menu.doCloseMenu();
            stepMenuVQMM = 0;
        }
        lastDoMenu = mSystem2.currentTimeMillis();
    }

    private void OpenMenuVQMM()
    {
        switch (stepMenuVQMM)
        {
            case 0:
                Service2.gI().openMenu(19);
                stepMenuVQMM = 1;
                break;
            case 1:
                GameCanvas2.menu.menuSelectedItem = IndexMenuVQMM();
                GameCanvas2.menu.performSelect();
                GameCanvas2.menu.doCloseMenu();
                stepMenuVQMM = 2;
                break;
            case 2:
                GameCanvas2.menu.menuSelectedItem = 0;
                GameCanvas2.menu.performSelect();
                GameCanvas2.menu.doCloseMenu();
                stepMenuVQMM = -1;
                break;
            default:
                break;
        }
        if (stepMenuVQMM == -1)
        {
            GameCanvas2.menu.doCloseMenu();
            stepMenuVQMM = 0;
        }
        lastDoMenu = mSystem2.currentTimeMillis();
    }

    public void AutoVQMM()
    {
        if (TileMap2.mapID != 45)
        {
            return;
        }
        if (Char2.myCharz().cx != 450)
        {
            MoveTo(450, 408);
            return;
        }
        if (!Util.CanDoWithTime(lastDoMenu, 500))
        {
            return;
        }
        if (fullChestVQMM)
        {
            CollectChestVQMM();
            fullChestVQMM = false;
            return;
        }
        if (GameCanvas2.currentScreen is not CrackBallScr2)
        {
            OpenMenuVQMM();
            return;
        }
        // if (Input.GetKey(KeyCode.Q) || Char2.myCharz().xu <= 200000000L)
        if (Char2.myCharz().xu <= 200000000L)
        {
            GameScr2.info1.addInfo("Đã tắt Auto VQMM (2)", 0);
            isAutoVQMM = false;
            return;
        }
        if (InfoDlg2.isShow || GameCanvas2.panel.isShow)
        {
            InfoDlg2.hide();
            GameCanvas2.panel.hide();
        }
        Service2.gI().SendCrackBall(2, 7);
    }

    public bool Chat(string text)
    {
        if (text == "loadskill")
        {
            perform(57, null);
            return true;
        }
        if (text == "ak")
        {
            perform(42, null);
            return true;
        }
        if (text == "ts")
        {
            perform(44, null);
            return true;
        }
        if (text == "tsnguoi")
        {
            perform(48, null);
            return true;
        }
        if (text == "vqmm")
        {
            isAutoVQMM = !isAutoVQMM;
            GameScr2.info1.addInfo("Auto VQMM: " + (isAutoVQMM ? "Bật" : "Tắt"), 0);
            if (!isAutoVQMM)
            {
                isAutoVQMM = false;
                fullChestVQMM = false;
                lastVQMM = 0;
                lastDoMenu = 0;
                stepMenuVQMM = 0;
            }
            return true;
        }
        if (text == "ukhu")
        {
            isUpdateZones = !isUpdateZones;
            GameScr2.info1.addInfo("Tự động cập nhật khu: " + (isUpdateZones ? "Bật" : "Tắt"), 0);
            return true;
        }
        // Start With
        if (text.StartsWith("k "))
        {
            bool success = int.TryParse(text.Replace("k ", ""), out int khu);
            if (success && khu >= 0)
            {
                Service2.gI().requestChangeZone(khu, -1);
            }
            return true;
        }
        if (text.StartsWith("s "))
        {
            ChangeGameSpeed(text.Replace("s ", ""));
            return true;
        }
        if (text.StartsWith("atc "))
        {
            textAutoChat = text.Replace("atc ", "");
            try
            {
                Rms2.saveRMSString("ModAutoChat", textAutoChat);
            }
            catch
            {
            }
            return true;
        }
        if (text.StartsWith("atctg "))
        {
            textAutoChatTG = text.Replace("atctg ", "");
            try
            {
                Rms2.saveRMSString("ModAutoChatTG", textAutoChat);
            }
            catch
            {
            }
            return true;
        }

        //if (text == "attnl")
        //{
        //    Mod.isAutoTTNL = !Mod.isAutoTTNL;
        //    GameScr.info1.addInfo("Auto TTNL: " + (Mod.isAutoTTNL ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text == "abfdt")
        //{
        //    Mod.aDauDeTu = !Mod.aDauDeTu;
        //    GameScr.info1.addInfo("Auto buff đậu theo chỉ số đệ tử: " + (Mod.aDauDeTu ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text.StartsWith("bhpdt "))
        //{
        //    Mod.csHPDeTu = int.Parse(text.Split(new char[]
        //    {
        //        ' '
        //    })[1]);
        //    GameScr.info1.addInfo("HP buff đậu đệ tử: " + NinjaUtil.getMoneys((long)Mod.csHPDeTu), 0);
        //    text = "";
        //}
        //if (text.StartsWith("bkidt "))
        //{
        //    Mod.csKIDeTu = int.Parse(text.Split(new char[]
        //    {
        //        ' '
        //    })[1]);
        //    GameScr.info1.addInfo("KI buff đậu đệ tử: " + NinjaUtil.getMoneys((long)Mod.csKIDeTu), 0);
        //    text = "";
        //}
        //if (text == "abf")
        //{
        //    Mod.aBuffDau = !Mod.aBuffDau;
        //    GameScr.info1.addInfo("Auto buff đậu theo chỉ số: " + (Mod.aBuffDau ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text.StartsWith("bhp "))
        //{
        //    Mod.csHP = int.Parse(text.Split(new char[]
        //    {
        //        ' '
        //    })[1]);
        //    GameScr.info1.addInfo("HP buff đậu: " + NinjaUtil.getMoneys((long)Mod.csHP), 0);
        //    text = "";
        //}
        //if (text.StartsWith("bki "))
        //{
        //    Mod.csKI = int.Parse(text.Split(new char[]
        //    {
        //        ' '
        //    })[1]);
        //    GameScr.info1.addInfo("KI buff đậu: " + NinjaUtil.getMoneys((long)Mod.csKI), 0);
        //    text = "";
        //}
        //if (text == "akhu")
        //{
        //    Mod.isAutoVeKhu = !Mod.isAutoVeKhu;
        //    GameScr.info1.addInfo((Mod.isAutoVeKhu ? "Auto về khu cũ khi Login: Bật" : "Auto về khu cũ khi Login: Tắt") ?? "", 0);
        //    text = "";
        //}
        //if (text == "kk")
        //{
        //    Mod.khoakhu = !Mod.khoakhu;
        //    GameScr.info1.addInfo("Khóa chuyển khu: " + (Mod.khoakhu ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text == "kmap")
        //{
        //    Mod.khoamap = !Mod.khoamap;
        //    GameScr.info1.addInfo("Khóa map: " + (Mod.khoamap ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text == "nmt")
        //{
        //    if (Mod.getX(0) > 0 && Mod.getY(0) > 0)
        //    {
        //        Mod.GotoXY(Mod.getX(0), Mod.getY(0));
        //    }
        //    else
        //    {
        //        Mod.GotoXY(30, PickMobController.GetYsd(30));
        //    }
        //    text = "";
        //}
        //if (text == "nmp")
        //{
        //    if (Mod.getX(2) > 0 && Mod.getY(2) > 0)
        //    {
        //        Mod.GotoXY(Mod.getX(2), Mod.getY(2));
        //    }
        //    else
        //    {
        //        Mod.GotoXY(TileMap.pxw - 30, PickMobController.GetYsd(TileMap.pxw - 30));
        //    }
        //    text = "";
        //}
        //if (text == "nmg")
        //{
        //    if (Mod.getX(1) > 0 && Mod.getY(1) > 0)
        //    {
        //        Mod.GotoXY(Mod.getX(1), Mod.getY(1));
        //        Service.gI().getMapOffline();
        //        Service.gI().requestChangeMap();
        //    }
        //    else
        //    {
        //        Mod.GotoXY(TileMap.pxw / 2, PickMobController.GetYsd(TileMap.pxw / 2));
        //    }
        //    text = "";
        //}
        //if (text == "nmtr")
        //{
        //    if (Mod.getX(3) > 0 && Mod.getY(3) > 0)
        //    {
        //        Mod.GotoXY(Mod.getX(3), Mod.getY(3));
        //    }
        //    text = "";
        //}
        //if (text.StartsWith("do "))
        //{
        //    Mod.bossCanDo = text.Replace("do ", "");
        //    GameScr.info1.addInfo("Boss cần dò: " + Mod.bossCanDo, 0);
        //    text = "";
        //}
        //if (text.StartsWith("dk "))
        //{
        //    Mod.zoneMacDinh = int.Parse(text.Replace("dk ", ""));
        //    GameScr.info1.addInfo("Dò boss từ khu " + Mod.zoneMacDinh, 0);
        //    text = "";
        //}
        //if (text == "clrz")
        //{
        //    Mod.zoneMacDinh = 0;
        //    GameScr.info1.addInfo("Reset khu dò boss xuống", 0);
        //    text = "";
        //}
        //if (text == "doall")
        //{
        //    Mod.doBoss = !Mod.doBoss;
        //    GameScr.info1.addInfo("Dò boss: " + (Mod.doBoss ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text == "ksbs5")
        //{
        //    Mod.isKSBoss = false;
        //    Mod.isKSBossBangSkill5 = !Mod.isKSBossBangSkill5;
        //    GameScr.info1.addInfo((Mod.isKSBossBangSkill5 ? "KS Boss Bằng Skill 5: Bật" : "KS Boss Bằng Skill 5: Tắt") ?? "", 0);
        //    text = "";
        //}
        //if (text == "ksb")
        //{
        //    Mod.isKSBossBangSkill5 = false;
        //    Mod.isKSBoss = !Mod.isKSBoss;
        //    GameScr.info1.addInfo((Mod.isKSBoss ? "KS Boss bằng đấm thường: Bật" : "KS Boss bằng đấm thường: Tắt") ?? "", 0);
        //    text = "";
        //}
        //if (text.StartsWith("hpboss "))
        //{
        //    Mod.HPKSBoss = int.Parse(text.Replace("hpboss ", ""));
        //    GameScr.info1.addInfo("HP Boss khi đạt " + NinjaUtil.getMoneys((long)Mod.HPKSBoss) + " sẽ oánh bỏ con mẹ boss", 0);
        //    text = "";
        //}
        //if (text == "ttsp")
        //{
        //    Mod.isThongTinSuPhu = !Mod.isThongTinSuPhu;
        //    GameScr.info1.addInfo("Thông Tin Sư Phụ: " + (Mod.isThongTinSuPhu ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text == "ttdt")
        //{
        //    Mod.isThongTinDeTu = !Mod.isThongTinDeTu;
        //    GameScr.info1.addInfo("Thông Tin Đệ Tử: " + (Mod.isThongTinDeTu ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text == "xtb")
        //{
        //    Mod.xoaTauBay = !Mod.xoaTauBay;
        //    GameScr.info1.addInfo("Xóa tàu bay: " + (Mod.xoaTauBay ? "Tắt" : "Bật"), 0);
        //    text = "";
        //}
        //if (text == "xht")
        //{
        //    Mod.xoaHieuUngHopThe = !Mod.xoaHieuUngHopThe;
        //    GameScr.info1.addInfo("Hiệu ứng hợp thể: " + (Mod.xoaHieuUngHopThe ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text == "kvt")
        //{
        //    Mod.ghimX = Char.myCharz().cx;
        //    Mod.ghimY = Char.myCharz().cy;
        //    Mod.isKhoaViTri = !Mod.isKhoaViTri;
        //    GameScr.info1.addInfo("Khóa vị trí: " + (Mod.isKhoaViTri ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text == "ttnv")
        //{
        //    Mod.isBossM = false;
        //    Mod.isPKM = false;
        //    Mod.trangThai = !Mod.trangThai;
        //    GameScr.info1.addInfo("Trạng thái nhân vật đang trỏ: " + (Mod.trangThai ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}

        //if (text == "pkm")
        //{
        //    Mod.isPKM = !Mod.isPKM;
        //    Mod.isBossM = false;
        //    Mod.trangThai = false;
        //    GameScr.info1.addInfo("Bọn đấm nhau được trong khu: " + (Mod.isPKM ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text == "gdl")
        //{
        //    Mod.giamDungLuong = !Mod.giamDungLuong;
        //    GameScr.info1.addInfo("Giảm dung lượng: " + (Mod.giamDungLuong ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text == "xoamap")
        //{
        //    Mod.xoamap = !Mod.xoamap;
        //    GameScr.info1.addInfo("Xóa map: " + (Mod.xoamap ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text == "gmt")
        //{
        //    Mod.isGMT = false;
        //    text = "";
        //}
        //if (text.StartsWith("gmt "))
        //{
        //    int num = int.Parse(text.Remove(0, 4));
        //    if (num < GameScr.vCharInMap.size())
        //    {
        //        Mod.isGMT = true;
        //        Mod.charMT = (Char)GameScr.vCharInMap.elementAt(num);
        //    }
        //    text = "";
        //}
        //if (text == "abt")
        //{
        //    Mod.isAutoBT = !Mod.isAutoBT;
        //    GameScr.info1.addInfo("Auto bông tai: " + (Mod.isAutoBT ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text.StartsWith("bt "))
        //{
        //    Mod.timeBT = int.Parse(text.Replace("bt ", ""));
        //    GameScr.info1.addInfo("Delay auto bông tai: " + Mod.timeBT + "s", 0);
        //    text = "";
        //}
        //if (text == "anz")
        //{
        //    Mod.isAutoNhatXa = !Mod.isAutoNhatXa;
        //    if (Mod.isAutoNhatXa)
        //    {
        //        Mod.xNhatXa = Char.myCharz().cx;
        //        Mod.yNhatXa = Char.myCharz().cy;
        //        GameScr.info1.addInfo(string.Concat(new object[]
        //        {
        //            "Tọa Độ : ",
        //            Char.myCharz().cx,
        //            "|",
        //            Char.myCharz().cy
        //        }), 0);
        //    }
        //    GameScr.info1.addInfo("Auto Nhặt Xa : " + (Mod.isAutoNhatXa ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text.StartsWith("ndc "))
        //{
        //    Mod.textAutoChat = text.Replace("ndc ", "");
        //    GameScr.info1.addInfo("Nội dung auto chat : " + Mod.textAutoChat, 0);
        //    text = "";
        //}
        //if (text.StartsWith("ndctg "))
        //{
        //    Mod.textAutoChatTG = text.Replace("ndc ", "");
        //    GameScr.info1.addInfo("Nội dung auto chat thế giới : " + Mod.textAutoChatTG, 0);
        //    text = "";
        //}
        //if (text == "atchattg")
        //{
        //    Mod.isAutoCTG = !Mod.isAutoCTG;
        //    GameScr.info1.addInfo("Auto Chat Thế Giới: " + (Mod.isAutoCTG ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text == "atc")
        //{
        //    Mod.achat = !Mod.achat;
        //    GameScr.info1.addInfo("Auto chat : " + (Mod.achat ? "Bật" : "Tắt"), 0);
        //    text = string.Empty;
        //}
        //if (text.StartsWith("go "))
        //{
        //    int num2 = int.Parse(text.Remove(0, 3));
        //    if (num2 < GameScr.vCharInMap.size())
        //    {
        //        Char @char = (Char)GameScr.vCharInMap.elementAt(num2);
        //        Mod.GotoXY(@char.cx, @char.cy);
        //        Char.myCharz().focusManualTo(@char);
        //    }
        //    text = "";
        //}
        //if (text == "showhp")
        //{
        //    Mod.nvat = !Mod.nvat;
        //    GameScr.info1.addInfo("Thông tin người chơi trong map: " + (Mod.nvat ? "Bật" : "Tắt"), 0);
        //    text = "";
        //}
        //if (text.StartsWith("tdc "))
        //{
        //    Mod.tocdochay = int.Parse(text.Replace("tdc ", ""));
        //    GameScr.info1.addInfo("Tốc độ phóng: " + Mod.tocdochay, 0);
        //    text = "";
        //}
        return false;
    }

    private void UpdateTouch()
    {
         if (GameScr.gI().isNotPaintTouchControl())
        {
            return;
        }
        // menu mod
        if (GameCanvas2.isPointerHoldIn(GameScr2.imgPanel.getWidth() - 15, 3, GameScr2.imgModFunc.getWidth() + 30, GameScr2.imgModFunc.getHeight() + 30))
        {
            if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
            {
                OpenMenu();
                SoundMn2.gI().buttonClick();
                GameCanvas2.clearAllPointerEvent();
            }
            return;
        }
        if (!Main2.isIPhone || GameScr2.gI().isNotPaintTouchControl())
        {
            return;
        }

        if (MainMod.is2Tabs && GameCanvas2.isPointerHoldIn((GameCanvas2.w - logoW) / 2, 5, logoW, logoH)
        && GameCanvas2.currentScreen is GameScr2)
        {
            if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
            {
                OpenMenu();
                SoundMn2.gI().buttonClick();
                GameCanvas2.clearAllPointerEvent();
            }
            return;
        }

        // Open Menu Mod
        if (!MainMod.is2Tabs && GameCanvas2.isPointerHoldIn(GameScr2.imgPanel.getWidth() + 8, 3, GameScr2.imgModFunc.getWidth() + 2, GameScr2.imgModFunc.getHeight() + 2))
        {
            if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
            {
                OpenMenu();
                SoundMn2.gI().buttonClick();
                GameCanvas2.clearAllPointerEvent();
            }
            return;
        }

        if (isShowQuickButton)
        {
            // C button
            if (GameCanvas2.isPointerHoldIn(modKeyPosX - 46 - IMAGE_SIZE / 2, modKeyPosY + 38 - IMAGE_SIZE / 2, IMAGE_SIZE, IMAGE_SIZE))
            {
                if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
                {
                    UseItem(194);
                    GameCanvas2.clearAllPointerEvent();
                }
            }
            // F button
            else if (GameCanvas2.isPointerHoldIn(modKeyPosX - 21 - IMAGE_SIZE / 2, modKeyPosY + 20 - IMAGE_SIZE / 2, IMAGE_SIZE, IMAGE_SIZE))
            {
                if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
                {
                    UsePorata();
                    GameCanvas2.clearAllPointerEvent();
                }
            }
            // M button
            else if (GameCanvas2.isPointerHoldIn(modKeyPosX - 64 - IMAGE_SIZE / 2, modKeyPosY + 64 - IMAGE_SIZE / 2, IMAGE_SIZE, IMAGE_SIZE))
            {
                if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
                {
                    userOpenZones = true;
                    Service2.gI().openUIZone();
                    GameCanvas2.clearAllPointerEvent();
                }
            }
        }

        if (isShowXMAPButton)
        {
            // XMAP buttons
            if (GameCanvas2.isPointerHoldIn(modKeyPosX - 19 - IMAGE_SIZE - IMAGE_SIZE / 2, modKeyPosY + 22 - IMAGE_SIZE - IMAGE_SIZE / 2, IMAGE_SIZE, IMAGE_SIZE))
            {
                if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
                {
                    ManualXmap2.GI().LoadMapRight();
                    GameCanvas2.clearAllPointerEvent();
                }
            }
            else if (GameCanvas2.isPointerHoldIn(modKeyPosX - 44 - IMAGE_SIZE - IMAGE_SIZE / 2, modKeyPosY + 40 - IMAGE_SIZE - IMAGE_SIZE / 2, IMAGE_SIZE, IMAGE_SIZE))
            {
                if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
                {
                    ManualXmap2.GI().LoadMapCenter();
                    GameCanvas2.clearAllPointerEvent();
                }
            }
            else if (GameCanvas2.isPointerHoldIn(modKeyPosX - 62 - IMAGE_SIZE - IMAGE_SIZE / 2, modKeyPosY + 66 - IMAGE_SIZE - IMAGE_SIZE / 2, IMAGE_SIZE, IMAGE_SIZE))
            {
                if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
                {
                    ManualXmap2.GI().LoadMapLeft();
                    GameCanvas2.clearAllPointerEvent();
                }
            }
        }
    }

    public void Update()
    {
        UpdateTouch();

        // Auto intrinsic
        if (paramIntrinsic != -1 && Util.CanDoWithTime(lastAutoIntrinsic, 500))
        {
            DoMenuIntrinsic();
        }

        // Auto buy item
        if (itemBuy != null && Util.CanDoWithTime(lastTimeAutoBuy, 200))
        {
            if (quanBuy > 0)
            {
                Service2.gI().buyItem(3, itemBuy.template.id, 0);
                lastTimeAutoBuy = mSystem2.currentTimeMillis();
                quanBuy--;
            }
            else
            {
                GameScr2.info1.addInfo("Đã tự động mua xong " + QUAN_BUY + " " + itemBuy.template.name, 0);
                itemBuy = null;
                quanBuy = QUAN_BUY;
            }
        }

        // Auto Point
        if (indexAutoPoint != -1 && pointIncrease > 0 && mSystem2.currentTimeMillis() - lastAutoPoint >= 1000)
        {
            Char2 @char = typePointForPet == 16 ? Char2.myCharz() : typePointForPet == 18 ? Char2.myPetz() : Char2.MyPet2z();
            var currentPoint = indexAutoPoint switch
            {
                0 => @char.cHPGoc,
                1 => @char.cMPGoc,
                2 => @char.cDamGoc,
                3 => @char.cDefGoc,
                4 => @char.cCriticalGoc,
                _ => 0,
            };
            if (currentPoint >= pointIncrease)
            {
                indexAutoPoint = -1;
                pointIncrease = 0;
                GameScr2.info1.addInfo("Đã đạt chỉ số yêu cầu", 0);
            }
            Service2.gI().upPotential(typePointForPet, indexAutoPoint, 100);
            lastAutoPoint = mSystem2.currentTimeMillis();
        }

        // Goback
        if (PickMob2.mapGoback != -1
            && PickMob2.zoneGoback != -1
            && mSystem2.currentTimeMillis() - lastActiveGoback >= 3000
            && (Char2.myCharz().cHP <= 0 || Char2.myCharz().statusMe == 14))
        {
            lastActiveGoback = mSystem2.currentTimeMillis();
            XmapController2.FinishXmap();
            Service2.gI().returnTownFromDead();
            new Thread(new ThreadStart(PickMob2.GoBack)).Start();
        }

        // Auto Bean
        if (isAutoBean && mSystem2.currentTimeMillis() - lastAutoBean >= 1000L)
        {
            Char2 myChar = Char2.myCharz();
            if (!myChar.isDie && (myChar.cHP < myChar.cHPFull * percentBeanHP / 100
                || myChar.cMP < myChar.cMPFull * percentBeanMP / 100))
            {
                GameScr2.gI().doUseHP();
                lastAutoBean = mSystem2.currentTimeMillis();
            }
        }

        // Auto Bean Pet
        if (isAutoBeanPet && mSystem2.currentTimeMillis() - lastAutoBean >= 3000L)
        {
            if (Char2.myCharz().havePet)
            {
                if (!showInfoPet)
                {
                    Service2.gI().petInfo();
                }
                Char2 pet = Char2.myPetz();
                if (!pet.isDie && (pet.cStamina <= pet.cMaxStamina * 30 / 100
                    || pet.cHP < pet.cHPFull * 30 / 100
                    || pet.cMP < pet.cMPFull * 30 / 100))
                {
                    GameScr2.gI().doUseHP();
                    lastAutoBean = mSystem2.currentTimeMillis();
                }
            }
            else
            {
                isAutoBeanPet = false;
                GameScr2.info1.addInfo("Bạn không có đệ tử", 0);
            }
        }

        //if (Input.GetKey("q") && SpecialSkill.gI().isnoitai)
        //{
        //    SpecialSkill.gI().isnoitai = false;
        //    GameScr.info1.addInfo("Đã Dừng", 0);
        //    if (isPaintCrackBall)
        //    {
        //        isThuongDeVip = false;
        //        isThuongDeVip = false;
        //        isThuongDeThuong = false;
        //        GameScr.info1.addInfo("Đã Dừng", 0);
        //    }
        //}

        if (isAutoPhaLe && itemPhale != null)
        {
            currPhale = GetCurrPhaLe(FindItemBagWithIndexUI(itemPhale.indexUI));
        }
        else
        {
            currPhale = -1;
        }

        if (isAutoChat && mSystem2.currentTimeMillis() - lastAutoChat >= 4000L)
        {
            AutoChat();
            lastAutoChat = mSystem2.currentTimeMillis();
        }

        if (isAutoChatTG && mSystem2.currentTimeMillis() - lastAutoChatTG >= 30000L)
        {
            AutoChatTG();
            lastAutoChatTG = mSystem2.currentTimeMillis();
        }

        //if (Mod.doBoss && mSystem.currentTimeMillis() - Mod.currDoBoss >= 1000L)
        //{
        //    Mod.DoBoss();
        //    Mod.currDoBoss = mSystem.currentTimeMillis();
        //}

        if (!TileMap2.isOfflineMap() && mSystem2.currentTimeMillis() - lastUpdateZones >= 1000L)
        {
            UseItemAuto();
            if (isUpdateZones)
            {
                Service2.gI().openUIZone();
            }
            lastUpdateZones = mSystem2.currentTimeMillis();
        }

        if (isAutoVQMM && Util.CanDoWithTime(lastVQMM, 1000L))
        {
            AutoVQMM();
            lastVQMM = mSystem2.currentTimeMillis();
        }

        //Mod.AutoTTNL();

        if (autoWakeUp && mSystem2.currentTimeMillis() - lastAutoWakeUp >= 1000)
        {
            AutoHoiSinh();
            lastAutoWakeUp = mSystem2.currentTimeMillis();
        }

        //Mod.xd();
        //Mod.cd();
        //Mod.UseSkillAuto();

        if (focusBoss && mSystem2.currentTimeMillis() - lastFocusBoss >= 500L)
        {
            AutoFocusBoss();
            lastFocusBoss = mSystem2.currentTimeMillis();
        }

        //Mod.KSBoss();
        //Mod.KSBossBangSkill5();
        //Mod.khoaViTri();
        //Mod.gmt();
        //Mod.AutoBT();
        //Mod.AutoCTG();
        //Mod.AutoNhatXa();

        //if (Mod.isAutoVeKhu && mSystem.currentTimeMillis() - Mod.currVeKhuCu >= 20000L)
        //{
        //    Mod.currVeKhuCu = mSystem.currentTimeMillis();
        //    Mod.khuVeLai = TileMap.zoneID;
        //}

        //if (Mod.isAutoAnNho && Char.myCharz().cStamina <= 5 && mSystem.currentTimeMillis() - Mod.currAnNho >= 1000L)
        //{
        //    Mod.AnNho();
        //    Mod.currAnNho = mSystem.currentTimeMillis();
        //}

        if (autoAttack)
        {
            AutoAttack();
        }

        //if (Mod.isPKM && !Mod.isGMT && (Char.myCharz().charFocus == null || (Char.myCharz().charFocus != null && !Char.myCharz().isMeCanAttackOtherPlayer(Char.myCharz().charFocus))))
        //{
        //    for (int i = 0; i < GameScr.vCharInMap.size(); i++)
        //    {
        //        Char @char = (Char)GameScr.vCharInMap.elementAt(i);
        //        if (@char != null && Char.myCharz().isMeCanAttackOtherPlayer(@char) && !@char.isPet && !@char.isMiniPet && !@char.cName.StartsWith("$") && !@char.cName.StartsWith("#") && @char.charID >= 0)
        //        {
        //            Char.myCharz().focusManualTo(@char);
        //            return;
        //        }
        //    }
        //}

        //if (Mod.thudau && mSystem.currentTimeMillis() - Mod.currThuDau >= 500L)
        //{
        //    Mod.td();
        //    Mod.currThuDau = mSystem.currentTimeMillis();
        //}

        //if (Mod.isAutoNeBoss && mSystem.currentTimeMillis() - Mod.currNeBoss >= 5000L)
        //{
        //    Mod.NeBoss();
        //    Mod.currNeBoss = mSystem.currentTimeMillis();
        //}

        UpdateNotifTichXanh();
    }

    public void PaintButton(mGraphics2 g, int xAnchor, int yAnchor)
    {
        if (!Main2.isIPhone
        || GameCanvas2.currentDialog != null
        || ChatPopup2.currChatPopup != null
        || GameCanvas2.menu.showMenu
        || GameScr2.gI().isPaintPopup()
        || GameCanvas2.panel.isShow
        || Char2.myCharz().taskMaint.taskId == 0
        || ChatTextField2.gI().isShow
        || GameCanvas2.currentScreen == MoneyCharge2.instance)
        {
            return;
        }

        if (isShowQuickButton || isShowXMAPButton)
        {
            modKeyPosX = xAnchor;
            modKeyPosY = yAnchor;
        }

        if (isShowQuickButton)
        {
            // C button
            if (GameCanvas2.isPointerHoldIn(xAnchor - 46 - IMAGE_SIZE / 2, yAnchor + 38 - IMAGE_SIZE / 2, IMAGE_SIZE, IMAGE_SIZE))
            {
                g.drawImage(imgCapsuleF, xAnchor - 46, yAnchor + 38, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }
            else
            {
                g.drawImage(imgCapsule, xAnchor - 46, yAnchor + 38, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }

            // F button
            if (GameCanvas2.isPointerHoldIn(xAnchor - 21 - IMAGE_SIZE / 2, yAnchor + 20 - IMAGE_SIZE / 2, IMAGE_SIZE, IMAGE_SIZE))
            {
                g.drawImage(imgPorataF, xAnchor - 21, yAnchor + 20, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }
            else
            {
                g.drawImage(imgPorata, xAnchor - 21, yAnchor + 20, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }

            // M button
            if (GameCanvas2.isPointerHoldIn(xAnchor - 64 - IMAGE_SIZE / 2, yAnchor + 64 - IMAGE_SIZE / 2, IMAGE_SIZE, IMAGE_SIZE))
            {
                g.drawImage(imgZoneF, xAnchor - 64, yAnchor + 64, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }
            else
            {
                g.drawImage(imgZone, xAnchor - 64, yAnchor + 64, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }
        }
        if (isShowXMAPButton)
        {
            // XMAP buttons
            if (GameCanvas2.isPointerHoldIn(xAnchor - 19 - IMAGE_SIZE - IMAGE_SIZE / 2, yAnchor + 22 - IMAGE_SIZE - IMAGE_SIZE / 2, IMAGE_SIZE, IMAGE_SIZE))
            {
                g.drawImage(imgNextMapF, xAnchor - 19 - IMAGE_SIZE, yAnchor + 22 - IMAGE_SIZE, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }
            else
            {
                g.drawImage(imgNextMap, xAnchor - 19 - IMAGE_SIZE, yAnchor + 22 - IMAGE_SIZE, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }

            if (GameCanvas2.isPointerHoldIn(xAnchor - 44 - IMAGE_SIZE - IMAGE_SIZE / 2, yAnchor + 40 - IMAGE_SIZE - IMAGE_SIZE / 2, IMAGE_SIZE, IMAGE_SIZE))
            {
                g.drawImage(imgMidMapF, xAnchor - 44 - IMAGE_SIZE, yAnchor + 40 - IMAGE_SIZE, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }
            else
            {
                g.drawImage(imgMidMap, xAnchor - 44 - IMAGE_SIZE, yAnchor + 40 - IMAGE_SIZE, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }

            if (GameCanvas2.isPointerHoldIn(xAnchor - 62 - IMAGE_SIZE - IMAGE_SIZE / 2, yAnchor + 66 - IMAGE_SIZE - IMAGE_SIZE / 2, IMAGE_SIZE, IMAGE_SIZE))
            {
                g.drawImage(imgPreMapF, xAnchor - 62 - IMAGE_SIZE, yAnchor + 66 - IMAGE_SIZE, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }
            else
            {
                g.drawImage(imgPreMap, xAnchor - 62 - IMAGE_SIZE, yAnchor + 66 - IMAGE_SIZE, mGraphics2.HCENTER | mGraphics2.VCENTER);
            }
        }
    }

    public void Paint(mGraphics2 g)
    {
        int imgHPWidth = mGraphics2.getImageWidth(GameScr2.imgHP);
        int imgMPWidth = mGraphics2.getImageWidth(GameScr2.imgMP);

        // FPS
        mFont2.tahoma_7_red.drawString(g, "" + (int)(1f / Time.unscaledDeltaTime), 6, 34, mFont2.LEFT);

        if (!ChatTextField2.gI().isShow)
        {
            mFont2.tahoma_7_red.drawStringBorder(g, NinjaUtil2.NumberTostring(Char2.myCharz().cHP.ToString()), 84 + imgHPWidth / 2, 4, mFont2.CENTER, mFont2.tahoma_7_grey);
            mFont2.tahoma_7_blue1.drawStringBorder(g, NinjaUtil2.NumberTostring(Char2.myCharz().cMP.ToString()), 84 + imgMPWidth / 2, 17, mFont2.CENTER, mFont2.tahoma_7_grey);
            mFont2.tahoma_7_white.drawStringBorder(g, TileMap2.mapName + " - K" + TileMap2.zoneID, 84, 28, mFont2.LEFT, mFont2.tahoma_7_grey);
        }

        if (isAutoPhaLe)
        {
            string text = statusPhale switch
            {
                0 => "Cần đến Đảo Kame để sử dụng Tự động pha lê hóa",
                1 => "Đang pha lê hóa",
                2 => "Sẵn sàng pha lê hóa",
                3 => "Đang bán vàng",
                _ => "...",
            };
            mFont2.tahoma_7b_red.drawString(g, "Trạng thái: " + text, GameCanvas2.w / 2, 72, mFont2.CENTER);
            mFont2.tahoma_7b_red.drawString(g, (itemPhale != null) ? itemPhale.template.name : "Chưa có", GameCanvas2.w / 2, 82, mFont2.CENTER);
            mFont2.tahoma_7b_red.drawString(g, "Số sao: " + (itemPhale != null ? currPhale : -1), GameCanvas2.w / 2, 92, mFont2.CENTER);
            mFont2.tahoma_7b_red.drawString(g, "Số sao cần đập: " + maxPhale + " sao", GameCanvas2.w / 2, 102, mFont2.CENTER);
        }

        if (isAutoPhaLe || isAutoVQMM)
        {
            Item2 tv = FindItemBagWithIndexUI(FindItemIndex(457));
            mFont2.tahoma_7b_red.drawString(g, "Ngọc xanh: " + NinjaUtil2.getMoneys(Char2.myCharz().luong) + " - Hồng ngọc: " + NinjaUtil2.getMoneys(Char2.myCharz().luongKhoa), GameCanvas2.w / 2, 112, mFont2.CENTER);
            mFont2.tahoma_7b_red.drawString(g, string.Concat(new object[]
            {
                "Vàng: ",
                NinjaUtil2.getMoneys(Char2.myCharz().xu),
                " - Thỏi vàng : ",
                tv == null ? 0 : tv.quantity
            }), GameCanvas2.w / 2, 122, mFont2.CENTER);
        }

        if (showInfoPet)
        {
            if (mSystem2.currentTimeMillis() - lastUpdateInfoMe > 2000L)
            {
                Service2.gI().petInfo();
                lastUpdateInfoMe = mSystem2.currentTimeMillis();
            }

            int xText = 10;
            int yText = GameScr2.gI().cmdMenu.y + 40;
            int num = 10;

            mFont2.tahoma_7b_yellow.drawStringBorder(g, "Đệ tử :", xText, yText, mFont2.LEFT, mFont2.tahoma_7_grey);
            mFont2.tahoma_7_white.drawStringBorder(g, "SM: " + NinjaUtil2.getMoneys(Char2.myPetz().cPower), xText, yText + num, mFont2.LEFT, mFont2.tahoma_7_grey);
            mFont2.tahoma_7_white.drawStringBorder(g, "TN: " + NinjaUtil2.getMoneys(Char2.myPetz().cTiemNang), xText, yText + 2 * num, mFont2.LEFT, mFont2.tahoma_7_grey);
            mFont2.tahoma_7_white.drawStringBorder(g, "SĐ: " + NinjaUtil2.getMoneys(Char2.myPetz().cDamFull), xText, yText + 3 * num, mFont2.LEFT, mFont2.tahoma_7_grey);
            mFont2.tahoma_7_white.drawStringBorder(g, "HP : " + NinjaUtil2.getMoneys(Char2.myPetz().cHP), xText, yText + 4 * num, mFont2.LEFT, mFont2.tahoma_7_grey);
            mFont2.tahoma_7_white.drawStringBorder(g, "MP : " + NinjaUtil2.getMoneys(Char2.myPetz().cMP), xText, yText + 5 * num, mFont2.LEFT, mFont2.tahoma_7_grey);
            mFont2.tahoma_7_white.drawStringBorder(g, "Giáp: " + NinjaUtil2.getMoneys(Char2.myPetz().cDefull), xText, yText + 6 * num, mFont2.LEFT, mFont2.tahoma_7_grey);
        }

        int numY = 52;
        if (notifBoss)
        {
            int maxL = 0;
            for (int i = 0; i < bossNotif.size(); i++)
            {
                ShowBoss showBoss = (ShowBoss)bossNotif.elementAt(i);
                showBoss.PaintBoss2(g, GameCanvas2.w - 5, numY);
                if (showBoss.stringLength > maxL)
                {
                    maxL = showBoss.stringLength;
                }
                numY += 10;
            }
            if (maxL != 0)
            {
                int strLength = mFont2.tahoma_7_white.getWidthExactOf(strBossNotif);
                g.drawRegion(Mob2.imgHP, 0, 18, 9, 6, 4, GameCanvas2.w - 12 - strLength, 46, mGraphics2.VCENTER | mGraphics2.HCENTER);

                g.setColor(Color.yellow);
                g.DrawLine(GameCanvas2.w - 16 - strLength, 46, GameCanvas2.w - maxL - 11, 46, 3);
                g.DrawLine(GameCanvas2.w - maxL - 10, 45, GameCanvas2.w - maxL - 10, numY + 6, 3);
                g.DrawLine(GameCanvas2.w - maxL - 11, numY + 5, GameCanvas2.w, numY + 5, 3);
                g.DrawLine(GameCanvas2.w, 46, GameCanvas2.w - 5, 46, 3);

                g.FillRect(GameCanvas2.w - 8 - strLength, 42, strLength + 2, mFont2.tahoma_7_white.getHeight() - 2, 0, 0.8f);
                mFont2.tahoma_7_white.drawString(g, strBossNotif, GameCanvas2.w - 5, 40, mFont2.RIGHT);
            }
            numY += 20;
        }

        if (showCharsInMap)
        {
            int titleX = numY - 12;
            int maxL = 0;
            int numX = GameCanvas2.w - 2;
            charsInMap.removeAllElements();
            int strLength;
            for (int i = 0; i < GameScr2.vCharInMap.size(); i++)
            {
                Char2 char6 = (Char2)GameScr2.vCharInMap.elementAt(i);
                if (char6.Equals(Char2.myCharz()))
                {
                    continue;
                }
                if (numY > GameScr2.yHP - 40)
                {
                    mFont2.tahoma_7_white.drawStringBorder(g, "...", numX, numY, mFont2.RIGHT, mFont2.tahoma_7_grey);
                    numY += 10;
                    break;
                }
                if (char6 != null && char6.cName != null && char6.cName.Length > 0
                    && !char6.isPet // Pet
                    && !char6.isMiniPet // Minipet
                    && char6.cName.ToLower() != "trọng tài")
                {
                    string str = char6.cName
                    + " ["
                    + NinjaUtil2.NumberTostring2(char6.cHP).ToString()
                    + "/"
                    + NinjaUtil2.NumberTostring2(char6.cHPFull).ToString()
                    + "] - "
                    + CharGender(char6);
                    // Player focus
                    if (char6 == Char2.myCharz().charFocus)
                    {
                        mFont2.tahoma_7_yellow.drawStringBorder(g, str, numX, numY, mFont2.RIGHT, mFont2.tahoma_7_grey);
                        strLength = mFont2.tahoma_7_yellow.getWidthExactOf(str);
                    }
                    // Boss
                    else if (char6.charID < 0 && char6.charID > -1000 && char6.charID != -114)
                    {
                        mFont2.tahoma_7_red.drawStringBorder(g, str, numX, numY, mFont2.RIGHT, mFont2.tahoma_7_grey);
                        strLength = mFont2.tahoma_7_red.getWidthExactOf(str);
                    }
                    // Same clan
                    else if (Char2.myCharz().clan != null && char6.clanID == Char2.myCharz().clan.ID)
                    {
                        mFont2.tahoma_7_green.drawStringBorder(g, str, numX, numY, mFont2.RIGHT, mFont2.tahoma_7_grey);
                        strLength = mFont2.tahoma_7_green.getWidthExactOf(str);
                    }
                    // Others
                    else
                    {
                        mFont2.tahoma_7_white.drawStringBorder(g, str, numX, numY, mFont2.RIGHT, mFont2.tahoma_7_grey);
                        strLength = mFont2.tahoma_7_white.getWidthExactOf(str);
                    }
                    if (strLength > maxL)
                    {
                        maxL = strLength;
                    }
                    g.FillRect(numX - strLength - 3, numY + 1, strLength + 2, 10, 0, 0.2f);
                    charsInMap.addElement(char6);
                    numY += 10;
                }
            }
            string text = TileMap2.mapName + " - K" + TileMap2.zoneID;
            strLength = mFont2.tahoma_7_white.getWidthExactOf(text);
            g.drawRegion(Mob2.imgHP, 0, 18, 9, 6, 4, GameCanvas2.w - 12 - strLength, titleX + 6, mGraphics2.VCENTER | mGraphics2.HCENTER);
            g.FillRect(GameCanvas2.w - 8 - strLength, titleX + 2, strLength + 2, mFont2.tahoma_7_white.getHeight() - 2, 0, 0.8f);
            mFont2.tahoma_7_white.drawString(g, text, GameCanvas2.w - 5, titleX, mFont2.RIGHT);
            if (maxL != 0)
            {
                g.setColor(Color.yellow);
                g.DrawLine(GameCanvas2.w - 16 - strLength, titleX + 6, GameCanvas2.w - maxL - 11, titleX + 6, 3);
                g.DrawLine(GameCanvas2.w - maxL - 10, titleX + 5, GameCanvas2.w - maxL - 10, numY + 6, 3);
                g.DrawLine(GameCanvas2.w - maxL - 11, numY + 5, GameCanvas2.w, numY + 5, 3);
                g.DrawLine(GameCanvas2.w, titleX + 6, GameCanvas2.w - 5, titleX + 6, 3);
            }
        }

        int num4 = 70;
        Char2 charFocus = Char2.myCharz().charFocus;
        if (charFocus != null && Char2.myCharz().isMeCanAttackOtherPlayer(charFocus))
        {
            mFont2.tahoma_7b_red.drawStringBorder(g,
            charFocus.cName
            + " ["
            + NinjaUtil2.getMoneys(charFocus.cHP)
            + " / "
            + NinjaUtil2.getMoneys(charFocus.cHPFull)
            + "]", GameCanvas2.w / 2, num4, mFont2.CENTER, mFont2.tahoma_7_grey);
            num4 += 10;
            if (charFocus.protectEff)
            {
                mFont2.tahoma_7b_red.drawString(g, "Khiên năng lượng", GameCanvas2.w / 2, num4, mFont2.CENTER);
                num4 += 10;
            }
            if (charFocus.isMonkey == 1)
            {
                mFont2.tahoma_7b_red.drawString(g, "Biến khỉ", GameCanvas2.w / 2, num4, mFont2.CENTER);
                num4 += 10;
            }
            if (charFocus.sleepEff)
            {
                mFont2.tahoma_7b_red.drawString(g, "Bị thôi miên", GameCanvas2.w / 2, num4, mFont2.CENTER);
                num4 += 10;
            }
            if (charFocus.holdEffID != 0)
            {
                mFont2.tahoma_7b_red.drawString(g, "Bị trói", GameCanvas2.w / 2, num4, mFont2.CENTER);
                num4 += 10;
            }
            if (charFocus.isFreez)
            {
                mFont2.tahoma_7b_red.drawString(g, "Bị TDHS: " + charFocus.freezSeconds.ToString(), GameCanvas2.w / 2, num4, mFont2.CENTER);
                num4 += 10;
            }
            if (charFocus.blindEff)
            {
                mFont2.tahoma_7b_red.drawString(g, "Bị choáng", GameCanvas2.w / 2, num4, mFont2.CENTER);
            }
        }

        if (lineToBoss)
        {
            for (int i = 0; i < GameScr2.vCharInMap.size(); i++)
            {
                Char2 @char = (Char2)GameScr2.vCharInMap.elementAt(i);
                if (@char != null && @char.cTypePk == 5 && !@char.cName.StartsWith("Đ"))
                {
                    g.setColor(Color.red);
                    g.drawLine(Char2.myCharz().cx - GameScr2.cmx, Char2.myCharz().cy - GameScr2.cmy, @char.cx - GameScr2.cmx, @char.cy - GameScr2.cmy);
                }
            }
        }

        if (TileMap2.mapID != 51 && TileMap2.mapID != 52 && TileMap2.mapID != 113 && TileMap2.mapID != 129 && TileMap2.mapID != 165)
        {
            int id;
            if (MainMod.numLogo == 1)
            {
                id = 0;
            }
            else
            {
                id = GameCanvas2.gameTick / 4 % MainMod.numLogo;
            }
            if (logos[id] != null)
            {
                int imgW = logos[id].getWidth() * mGraphics2.zoomLevel / 4;
                int imgH = logos[id].getHeight() * mGraphics2.zoomLevel / 4;
                g.drawImageScale(logos[id], (GameCanvas2.w - imgW) / 2, 5, imgW, imgH);
            }
        }

        if (!MainMod.is2Tabs && Main2.isIPhone)
        {
            g.drawImage(GameScr2.imgModFunc, GameScr2.imgPanel.getWidth() + 20, 15, 3);
        }
        g.drawImage(GameScr2.imgModFunc, GameScr2.imgPanel.getWidth() + 15, 15, 3);

        PaintPlayerTichXanh(g);
    }

    public void perform(int idAction, object p)
    {
        switch (idAction)
        {
            case 1:
                string notif;
                bool success = int.TryParse((string)p, out int mapId);
                if (success)
                {
                    XmapController2.StartRunToMapId(mapId);
                    notif = "Di chuyển đến boss ở MAP " + mapId;
                }
                else
                {
                    notif = "Địa điểm không hợp lệ!";
                }
                GameScr2.info1.addInfo(notif, 0);
                break;
            case 2:
                GameScr2.info1.addInfo("Đã huỷ di chuyển đến Boss", 0);
                break;
            case 3:
                MyVector2 menuBean = new();
                menuBean.addElement(new Command2("Tự động ăn đậu " + (isAutoBean ? "[Bật]" : "[Tắt]"), 4));
                menuBean.addElement(new Command2("Ăn đậu dưới " + percentBeanHP + "% HP", 5));
                menuBean.addElement(new Command2("Ăn đậu dưới " + percentBeanMP + "% MP", 6));
                menuBean.addElement(new Command2("Buff đậu cho đệ " + (isAutoBeanPet ? "[Bật]" : "[Tắt]"), 7));
                GameCanvas2.menu.startAt(menuBean, 4);
                break;
            case 4:
                isAutoBean = !isAutoBean;
                GameScr2.info1.addInfo("Tự động ăn đậu " + (isAutoBean ? "[Bật]" : "[Tắt]"), 0);
                break;
            case 5:
                MyChatTextField(ChatTextField2.gI(), "% HP", "VD: 20");
                break;
            case 6:
                MyChatTextField(ChatTextField2.gI(), "% MP", "VD: 20");
                break;
            case 7:
                isAutoBeanPet = !isAutoBeanPet;
                GameScr2.info1.addInfo("Buff đậu cho đệ " + (isAutoBeanPet ? "[Bật]" : "[Tắt]"), 0);
                break;
            case 8:
                string input = (string)p;
                string[] strs = input.Split('|');
                if (strs[1] == "ixxc")
                {
                    string ip = strs[0].Replace(',', ':');
                    string fullIp = "IP:" + ip + ":0,0,0";
                    ServerListScreen2.SaveIPNew(fullIp);
                }
                GameCanvas2.startOK(mResources2.pls_restart_game_error, 8885, null);
                break;
            case 32:
                MyVector2 myVector1 = new();
                myVector1.addElement(new Command2(notifBoss ? "Thông báo BOSS [Bật]" : "Thông báo BOSS [Tắt]", 46));
                myVector1.addElement(new Command2(lineToBoss ? "Kẻ đường tới BOSS [Bật]" : "Đường kẻ tới BOSS [Tắt]", 47));
                myVector1.addElement(new Command2(focusBoss ? "Focus BOSS [Bật]" : "Focus BOSS [Tắt]", 52));
                GameCanvas2.menu.startAt(myVector1, 4);
                break;
            // Goback
            case 38:
                PickMob2.mapGoback = TileMap2.mapID;
                PickMob2.zoneGoback = TileMap2.zoneID;
                PickMob2.xGoback = Char2.myCharz().cx;
                PickMob2.yGoback = Char2.myCharz().cy;

                PickMob2.isGoBack = !PickMob2.isGoBack;
                if (PickMob2.isGoBack)
                {
                    GameScr2.info1.addInfo(string.Concat(new object[]
                    {
                        "Map Goback: ",
                        TileMap2.mapName,
                        " | Khu: ",
                        TileMap2.zoneID
                    }), 0);
                    GameScr2.info1.addInfo(string.Concat(new object[]
                    {
                        "Tọa độ X: ",
                        PickMob2.xGoback,
                        " | Y: ",
                        PickMob2.yGoback
                    }), 0);
                }
                GameScr2.info1.addInfo("Goback tọa độ " + (PickMob2.isGoBack ? "[Bật]" : "[Tắt]"), 0);
                break;
            case 42:
                autoAttack = !autoAttack;
                GameScr2.info1.addInfo("Tự đánh " + (autoAttack ? "[Bật]" : "[Tắt]"), 0);
                break;
            // Ne sieu quai
            case 43:
                PickMob2.neSieuQuai = !PickMob2.neSieuQuai;
                GameScr2.info1.addInfo("Né siêu quái " + (PickMob2.neSieuQuai ? "[Bật]" : "[Tắt]"), 0);
                break;
            // Tan sat
            case 44:
                PickMob2.tsPlayer = false;
                PickMob2.tanSat = p != null ? (bool)p : !PickMob2.tanSat;
                GameScr2.info1.addInfo("Tàn sát " + (PickMob2.tanSat ? "[Bật]" : "[Tắt]"), 0);
                break;
            // Menu train
            case 45:
                MyVector2 myVector = new();
                MyVector2 mobIds = new MyVector2();
                for (int i = 0; i < GameScr2.vMob.size(); i++)
                {
                    Mob2 mob = (Mob2)GameScr2.vMob.elementAt(i);
                    if (GameScr2.gI().isMeCanAttackMob(mob) && !mobIds.contains(mob.templateId) && !PickMob2.TypeMobsTanSat.Contains(mob.templateId))
                    {
                        mobIds.addElement(mob.templateId);
                        myVector.addElement(new Command2("Tàn sát " + mob.getTemplate().name, 49, mob));
                    }
                }
                myVector.addElement(new Command2(PickMob2.tanSat ? "Tàn sát [Bật]" : "Tàn sát [Tắt]", 44));
                myVector.addElement(new Command2(PickMob2.tsPlayer ? "Tàn sát\nngười [Bật]" : "Tàn sát\nngười [Tắt]", 48));
                myVector.addElement(new Command2(autoAttack ? "Tự đánh [Bật]" : "Tự đánh [Tắt]", 42));
                myVector.addElement(new Command2(PickMob2.neSieuQuai ? "Né siêu quái [Bật]" : "Né siêu quái [Tắt]", 43));
                myVector.addElement(new Command2(PickMob2.vuotDiaHinh ? "Vượt địa hình [Bật]" : "Vượt địa hình [Tắt]", 76));
                myVector.addElement(new Command2(PickMob2.telePem ? "Dịch chuyển\n[Bật]" : "Dịch chuyển\n[Tắt]", 80));
                myVector.addElement(new Command2(PickMob2.isGoBack ? "Goback Tọa Độ [Bật]" : "Goback Tọa Độ [Tắt]", 38));
                myVector.addElement(new Command2("Xoá danh sách tàn sát", 51));
                GameCanvas2.menu.startAt(myVector, 4);
                break;
            case 46:
                notifBoss = !notifBoss;
                GameScr2.info1.addInfo("Thông báo BOSS " + (notifBoss ? "[Bật]" : "[Tắt]"), 0);
                SaveSettings();
                break;
            case 47:
                lineToBoss = !lineToBoss;
                GameScr2.info1.addInfo("Kẻ đường tới BOSS " + (lineToBoss ? "[Bật]" : "[Tắt]"), 0);
                break;
            // Tan sat nguoi
            case 48:
                PickMob2.tanSat = false;
                PickMob2.tsPlayer = p != null ? (bool)p : !PickMob2.tsPlayer;
                GameScr2.info1.addInfo("Tàn sát người " + (PickMob2.tsPlayer ? "[Bật]" : "[Tắt]"), 0);
                break;
            case 49:
                Mob2 mobType = (Mob2)p;
                if (!PickMob2.TypeMobsTanSat.Contains(mobType.templateId))
                {
                    PickMob2.TypeMobsTanSat.Add(mobType.templateId);
                }
                GameScr2.info1.addInfo("Tàn sát " + mobType.getTemplate().name, 0);
                perform(44, true);
                break;
            case 51:
                PickMob2.TypeMobsTanSat.Clear();
                GameScr2.info1.addInfo("Đã xoá danh sách quái tàn sát!", 0);
                break;
            case 52:
                focusBoss = !focusBoss;
                GameScr2.info1.addInfo("Focus BOSS " + (focusBoss ? "[Bật]" : "[Tắt]"), 0);
                break;
            case 53:
                MyVector2 menuOthers = new();
                if (MainMod.is2Tabs)
                {
                    menuOthers.addElement(new Command2("Chuyển Tab", 60));
                }
                menuOthers.addElement(new Command2("Tốc độ\nGame", 54));
                menuOthers.addElement(new Command2("Tự động\nChat " + (isAutoChat ? "[Bật]" : "[Tắt]"), 55));
                menuOthers.addElement(new Command2("Tự động\nChat Thế\nGiới " + (isAutoChatTG ? "[Bật]" : "[Tắt]"), 56));
                menuOthers.addElement(new Command2("Load ô\nskill", 57));
                menuOthers.addElement(new Command2("Lưu\ncài đặt", 58));
                menuOthers.addElement(new Command2("Xoá\ncài đặt", 59));
                GameCanvas2.menu.startAt(menuOthers, 4);
                break;
            case 54:
                MyChatTextField(ChatTextField2.gI(), "Nhập tốc độ game", "1 đến 10");
                break;
            case 55:
                isAutoChat = !isAutoChat;
                GameScr2.info1.addInfo("Tự động chat " + (isAutoChat ? "[Bật]" : "[Tắt]"), 0);
                break;
            case 56:
                isAutoChatTG = !isAutoChatTG;
                GameScr2.info1.addInfo("Tự động chat thế giới " + (isAutoChatTG ? "[Bật]" : "[Tắt]"), 0);
                break;
            case 57:
                LoadSkillToScreen();
                GameScr2.info1.addInfo("Đã load ô skill", 0);
                break;
            case 58:

                GameScr2.info1.addInfo("Đã lưu toàn bộ cài đặt", 0);
                break;
            case 59:

                GameScr2.info1.addInfo("Đã xoá toàn bộ cài đặt", 0);
                break;
            case 60:
                SceneSwitcher.SwitchBackToOldScene();
                SoundFunc.stopAllz();
                break;
            // Vuot dia hinh
            case 76:
                PickMob2.vuotDiaHinh = !PickMob2.vuotDiaHinh;
                GameScr2.info1.addInfo("Vượt địa hình " + (PickMob2.vuotDiaHinh ? "[Bật]" : "[Tắt]"), 0);
                break;
            // Dich chuyen danh quai
            case 80:
                PickMob2.telePem = !PickMob2.telePem;
                GameScr2.info1.addInfo("Dịch chuyển đến quái\n" + (PickMob2.telePem ? "[Bật]" : "[Tắt]"), 0);
                break;
            case 89:
                MyVector2 menuAutoPick = new();
                menuAutoPick.addElement(new Command2("Tự động nhặt " + (PickMob2.IsAutoPickItems ? "[Bật]" : "[Tắt]"), 90));
                menuAutoPick.addElement(new Command2("Nhặt tất cả " + (PickMob2.IsPickItemsAll ? "[Bật]" : "[Tắt]"), 91));
                menuAutoPick.addElement(new Command2("Nhặt xa\n" + (PickMob2.IsPickItemsDis ? "[Bật]" : "[Tắt]"), 92));
                GameCanvas2.menu.startAt(menuAutoPick, 4);
                break;
            case 90:
                PickMob2.IsAutoPickItems = !PickMob2.IsAutoPickItems;
                GameScr2.info1.addInfo("Tự động nhặt " + (PickMob2.IsAutoPickItems ? "[Bật]" : "[Tắt]"), 0);
                break;
            case 91:
                PickMob2.IsPickItemsAll = !PickMob2.IsPickItemsAll;
                GameScr2.info1.addInfo("Nhặt tất cả " + (PickMob2.IsPickItemsAll ? "[Bật]" : "[Tắt]"), 0);
                break;
            case 92:
                PickMob2.IsPickItemsDis = !PickMob2.IsPickItemsDis;
                GameScr2.info1.addInfo("Nhặt xa " + (PickMob2.IsPickItemsDis ? "[Bật]" : "[Tắt]"), 0);
                break;
            case 100:
                string str = (string)p;
                int.TryParse(str.Split("-")[0], out indexAutoPoint);
                int.TryParse(str.Split("-")[1], out typePointForPet);
                GameCanvas2.panel.hideNow();
                MyChatTextField(ChatTextField2.gI(), "Tăng đến mức", "VD: 220000");
                break;
            case 101:
                isOpenAccMAnager = true;
                break;
            case 102:
                Account account = (Account)p;
                Rms2.saveRMSString("acc", account.getUsername());
                Rms2.saveRMSString("pass", account.getPassword());
                if (GameCanvas2.loginScr != null && GameCanvas2.currentScreen == GameCanvas2.loginScr)
                {
                    GameCanvas2.loginScr.setUserPass();
                }
                isOpenAccMAnager = false;
                break;
            case 103:
                int index = accounts.IndexOf((Account)p);
                accounts.RemoveAt(index);
                cmdsChooseAcc.RemoveAt(index);
                cmdsDelAcc.RemoveAt(index);
                SaveAcc();
                break;
            case 104:
                isOpenAccMAnager = false;
                break;
            case 500:
            case 501:
                AddOrRemoveAutoItem((Item2)p, idAction == 500);
                break;
            // Menu XMAP
            case 883:
                XmapController2.ShowXmapMenu();
                break;
        }
    }

    private void AddOrRemoveAutoItem(Item2 item, bool isAdd)
    {
        if (isAdd)
        {
            listItemAuto.Add(new ItemAuto(item.template.iconID, item.template.id));
            GameScr2.info1.addInfo("Đã thêm " + item.template.name + " vào Auto Item", 0);
        }
        else
        {
            foreach (ItemAuto itemAuto in listItemAuto)
            {
                if (itemAuto.iconID == item.template.iconID && itemAuto.id == item.template.id)
                {
                    listItemAuto.Remove(itemAuto);
                    GameScr2.info1.addInfo("Đã xóa " + item.template.name + " khỏi Auto Item", 0);
                    break;
                }
            }
        }
    }

    public void DoDoubleClickToObj(IMapObject2 obj)
    {
        if ((obj.Equals(Char2.myCharz().npcFocus) || GameScr2.gI().mobCapcha == null) && !GameScr2.gI().checkClickToBotton(obj))
        {
            GameScr2.gI().checkEffToObj(obj, false);
            Char2.myCharz().cancelAttack();
            Char2.myCharz().currentMovePoint = null;
            Char2.myCharz().cvx = (Char2.myCharz().cvy = 0);
            obj.stopMoving();
            GameScr2.gI().auto = 10;
            GameScr2.gI().doFire(isFireByShortCut: false, skipWaypoint: true);
            GameScr2.gI().clickToX = obj.getX();
            GameScr2.gI().clickToY = obj.getY();
            GameScr2.gI().clickOnTileTop = false;
            GameScr2.gI().clickMoving = true;
            GameScr2.gI().clickMovingRed = true;
            GameScr2.gI().clickMovingTimeOut = 20;
            GameScr2.gI().clickMovingP1 = 30;
        }
    }

    public void MyChatTextField(ChatTextField2 chatTField, string strChat, string strName)
    {
        chatTField.strChat = strChat;
        chatTField.tfChat.name = strName;
        chatTField.to = string.Empty;
        chatTField.isShow = true;
        chatTField.tfChat.isFocus = true;
        chatTField.tfChat.setIputType(TField2.INPUT_TYPE_NUMERIC);
        chatTField.tfChat.setMaxTextLenght(10);
        if (Main2.isIPhone)
        {
            chatTField.startChat(chatTField.parentScreen, string.Empty);
        }
        else if (GameCanvas2.isTouch)
        {
            chatTField.tfChat.doChangeToTextBox();
        }
    }

    public void ChangeGameSpeed(string strSpeed)
    {
        bool success = int.TryParse(strSpeed, out int speed);
        if (success && speed > 0 && speed <= 10)
        {
            Time.timeScale = speed;
            GameScr2.info1.addInfo("Tốc độ game: " + speed, 0);
        }
        else
        {
            GameScr2.info1.addInfo("Chỉ nhập số từ 1 đến 10", 0);
        }
    }

    public void TeleportToPlayer(int charID)
    {
        Service2.gI().gotoPlayer(charID);
    }

    public void AddNotifTichXanh(string notif)
    {
        listNotifTichXanh.addElement(notif);
        if (!startChat)
        {
            int halfW = GameCanvas2.w / 2;
            startChat = true;
            xNotif = halfW + halfW / 2;
            lastUpdateNotif = mSystem2.currentTimeMillis();
        }
    }

    private void PaintPlayerTichXanh(mGraphics2 g)
    {
        if (listNotifTichXanh.size() != 0)
        {
            string st = (string)listNotifTichXanh.elementAt(0);
            int halfW = GameCanvas2.w / 2;
            g.setClip(halfW - halfW / 3, 50, halfW / 3 * 2, 12);
            g.fillRect(halfW - halfW / 3, 50, halfW / 3 * 2, 12, 0, 60);
            mFont2.tahoma_7_yellow.drawStringBorder(g, st, xNotif, 50, 0, mFont2.tahoma_7_grey);
            PaintTicks(g, true, xNotif - 12, 51);
        }
    }

    private void UpdateNotifTichXanh()
    {
        if (!startChat || mSystem2.currentTimeMillis() - lastUpdateNotif < 10)
        {
            return;
        }
        xNotif -= 1;
        string strChat = (string)listNotifTichXanh.elementAt(0);
        lastUpdateNotif = mSystem2.currentTimeMillis();
        if (xNotif < GameCanvas2.w / 2 - 100 - mFont2.tahoma_7_yellow.getWidth(strChat))
        {
            xNotif = GameCanvas2.w / 2 + 100;
            listNotifTichXanh.removeElementAt(0);
            if (listNotifTichXanh.size() == 0)
            {
                startChat = false;
            }
        }
    }

    public void SetAutoIntrinsic(int param)
    {
        if (curSelectIntrinsic.Length > 0)
        {
            bool success = int.TryParse(curSelectIntrinsic.Split("đến ")[1].Split("%")[0], out int maxParam);
            if (success && param > 0 && param <= maxParam)
            {
                paramIntrinsic = param;
                if (curSelectIntrinsic.Contains("+"))
                {
                    curSelectIntrinsic = curSelectIntrinsic.Split("+")[0].Trim();
                }
                else if (curSelectIntrinsic.Contains("dưới"))
                {
                    curSelectIntrinsic = curSelectIntrinsic.Split("dưới ")[0].Trim();
                }
                else
                {
                    paramIntrinsic = -1;
                    curSelectIntrinsic = "";
                    GameScr2.info1.addInfo("Có lỗi xảy ra, vui lòng liên hệ ADMIN!", 0);
                    return;
                }
            }
            else
            {
                GameScr2.info1.addInfo("Chỉ số đã chọn không đúng! (0)", 0);
            }
        }
        else
        {
            GameScr2.info1.addInfo("Chỉ số đã chọn không đúng! (1)", 0);
        }
    }

    private void DoMenuIntrinsic()
    {
        switch (stepMenuIntrinsic)
        {
            case 0:
                Service2.gI().speacialSkill(0);
                stepMenuIntrinsic = 1;
                break;
            case 1:
                // Service2.gI().confirmMenu(5, 2);
                GameCanvas2.menu.menuSelectedItem = 2;
                GameCanvas2.menu.performSelect();
                GameCanvas2.menu.doCloseMenu();
                stepMenuIntrinsic = 2;
                break;
            case 2:
                // Service2.gI().confirmMenu(5, 0);
                GameCanvas2.menu.menuSelectedItem = 0;
                GameCanvas2.menu.performSelect();
                GameCanvas2.menu.doCloseMenu();
                stepMenuIntrinsic = 0;
                break;
            default:
                break;
        }
        lastAutoIntrinsic = mSystem2.currentTimeMillis();
    }

    public void CheckAutoIntrinsic(string info)
    {
        if (info.Contains("+"))
        {
            string[] recvInfo = info.Split("+");
            string recvName = recvInfo[0].Trim();
            if (int.TryParse(recvInfo[1].Split("%")[0], out int recvParam))
            {
                if (curSelectIntrinsic == recvName && recvParam >= paramIntrinsic)
                {
                    GameScr2.info1.addInfo("Mở nội tại " + curSelectIntrinsic + " " + paramIntrinsic + "% thành công!", 0);
                    paramIntrinsic = -1;
                    curSelectIntrinsic = "";
                    GameCanvas2.menu.menuSelectedItem = GameCanvas2.menu.menuItems.size() - 1;
                    GameCanvas2.menu.performSelect();
                    GameCanvas2.menu.doCloseMenu();
                }
            }
        }
        else if (info.Contains("dưới"))
        {
            string[] recvInfo = info.Split("dưới ");
            string recvName = recvInfo[0].Trim();
            int recvParam;
            if (int.TryParse(recvInfo[1].Split("%")[0], out recvParam))
            {
                if (curSelectIntrinsic == recvName && recvParam >= paramIntrinsic)
                {
                    GameScr2.info1.addInfo("Mở nội tại " + curSelectIntrinsic + " " + paramIntrinsic + "% thành công!", 0);
                    paramIntrinsic = -1;
                    curSelectIntrinsic = "";
                    GameCanvas2.menu.menuSelectedItem = GameCanvas2.menu.menuItems.size() - 1;
                    GameCanvas2.menu.performSelect();
                    GameCanvas2.menu.doCloseMenu();
                }
            }
        }
        else
        {
            paramIntrinsic = -1;
            curSelectIntrinsic = "";
            GameCanvas2.menu.doCloseMenu();
        }
    }

    public void SetIncreasePoint(string strPoint)
    {
        bool success = int.TryParse(strPoint, out int point);
        if (success && indexAutoPoint != -1 && point > 0)
        {
            pointIncrease = point;
            GameScr2.info1.addInfo("Tự động tăng " + strPointTypes[indexAutoPoint] + " đến " + point, 0);
        }
        else
        {
            GameScr2.info1.addInfo("Có lỗi xảy ra (100)", 0);
        }
    }

    public void LoadAcc()
    {
        string text = Rms2.loadRMSString("accManager");
        if (text == null || text.Trim('|') == string.Empty) return;

        accounts.Clear();
        cmdsChooseAcc.Clear();
        cmdsDelAcc.Clear();

        string[] accs = text.Trim('|').Split('|');
        for (int i = 0; i < accs.Length; i++)
        {
            string[] acc = accs[i].Split('$');

            Account account = new(acc[0], acc[1]);
            accounts.Add(account);

            Command2 cmd = new(account.getUsername(), this, 102, account);
            cmd.setType();
            cmdsChooseAcc.Add(cmd);

            Command2 cmdDel = new("Xoá", this, 103, account);
            cmdDel.setTypeDelete();
            cmdsDelAcc.Add(cmdDel);
        }
    }

    public void AddAccount(string user, string pass)
    {
        Account account = new(user, pass);

        int index = accounts.IndexOf(account);
        if (index != -1)
        {
            accounts.RemoveAt(index);
        }
        accounts.Insert(0, account);

        for (int i = 5; i < accounts.Count; i++)
        {
            accounts.RemoveAt(i);
        }
        SaveAcc();
    }

    private void SaveAcc()
    {
        string text = "";
        foreach (Account acc in accounts)
        {
            text += string.Join('$', acc.getUsername(), acc.getPassword());
            text += "|";
        }
        Rms2.saveRMSString("accManager", text.Trim('|'));
    }

    private static Account FindAccWithUsername(string username)
    {
        foreach (Account acc in accounts)
        {
            if (acc.getUsername().Equals(username))
            {
                return acc;
            }
        }

        return new Account("", "");
    }

    private void AutoChat()
    {
        if (string.IsNullOrEmpty(textAutoChat))
        {
            GameScr2.info1.addInfo("Chưa cài nội dung tự động chat", 0);
        }
        else
        {
            Service2.gI().chat(textAutoChat);
        }
    }

    private void AutoChatTG()
    {
        if (string.IsNullOrEmpty(textAutoChatTG))
        {
            GameScr2.info1.addInfo("Chưa cài nội dung tự động chat thế giới", 0);
        }
        else
        {
            Service2.gI().chatGlobal(textAutoChatTG);
        }
    }

    public static string EncodeStringToByteArrayString(string inputString, string key)
    {
        byte[] encodedBytes = EncodeToBytes(inputString, key);
        string byteArrayString = BitConverter.ToString(encodedBytes).Replace("-", "");

        return string.Join("-", SplitByLength(byteArrayString, 2));
    }

    static byte[] EncodeToBytes(string inputString, string key)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] encodedBytes = new byte[inputBytes.Length];

        for (int i = 0; i < inputBytes.Length; i++)
        {
            encodedBytes[i] = (byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);
        }

        return encodedBytes;
    }

    static string[] SplitByLength(string str, int length)
    {
        int strLength = str.Length;
        int numSegments = (strLength + length - 1) / length;
        string[] segments = new string[numSegments];

        for (int i = 0; i < numSegments; i++)
        {
            int startIndex = i * length;
            int segmentLength = Math2.min(length, strLength - startIndex);
            segments[i] = str.Substring(startIndex, segmentLength);
        }

        return segments;
    }

    public static string DecodeByteArrayString(string byteArrayString, string key)
    {
        try
        {

            string[] hexValues = byteArrayString.Split('-');
            string concatenatedHex = string.Join("", hexValues);
            byte[] encodedBytes = new byte[concatenatedHex.Length / 2];

            for (int i = 0; i < encodedBytes.Length; i++)
            {
                encodedBytes[i] = Convert.ToByte(concatenatedHex.Substring(i * 2, 2), 16);
            }

            string decodedString = DecodeToString(encodedBytes, key);
            return decodedString;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    static string DecodeToString(byte[] encodedBytes, string key)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] decodedBytes = new byte[encodedBytes.Length];

        for (int i = 0; i < encodedBytes.Length; i++)
        {
            decodedBytes[i] = (byte)(encodedBytes[i] ^ keyBytes[i % keyBytes.Length]);
        }

        return Encoding.UTF8.GetString(decodedBytes);
    }

    public static void Log(string text)
    {
        if (!MainMod.isDebug)
        {
            return;
        }
        Debug.Log(text);
    }

    public static void WriteLog(string message)
    {
        if (!MainMod.isDebug)
        {
            return;
        }
        try
        {
            string logFileName = "log_" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt";

            FileStream fileStream = new(logFileName, FileMode.OpenOrCreate);
            // 
            StreamWriter streamWriter = new(fileStream);
            streamWriter.WriteLine(DateTime.Today.ToString("HH:mm:ss") + ": " + message);
            streamWriter.Flush();
            streamWriter.Close();
        }
        catch (Exception e)
        {
            Log(e.Message);
        }
    }

    private void LoadSkillToScreen()
    {
        for (int i = 0; i < Char2.myCharz().vSkill.size(); i++)
        {
            Skill2 skill = (Skill2)Char2.myCharz().vSkill.elementAt(i);

            if (GameCanvas2.isTouch && !Main2.isPC)
            {
                for (int j = 0; j < GameScr2.onScreenSkill.Length; j++)
                {
                    if (GameScr2.onScreenSkill[j] == skill)
                    {
                        GameScr2.onScreenSkill[j] = null;
                    }
                }
                GameScr2.onScreenSkill[i] = skill;
                GameScr2.gI().saveonScreenSkillToRMS();
            }
            else
            {
                for (int k = 0; k < GameScr2.keySkill.Length; k++)
                {
                    if (GameScr2.keySkill[k] == skill)
                    {
                        GameScr2.keySkill[k] = null;
                    }
                }
                GameScr2.keySkill[i] = skill;
                GameScr2.gI().saveKeySkillToRMS();
            }
        }
    }

    public static void DoChatGlobal()
    {
        GameCanvas2.endDlg();
        if (Char2.myCharz().checkLuong() < 5)
        {
            GameCanvas2.startOKDlg(mResources2.not_enough_luong_world_channel);
            return;
        }
        if (GameCanvas2.panel.chatTField == null)
        {
            GameCanvas2.panel.chatTField = new ChatTextField2();
            GameCanvas2.panel.chatTField.tfChat.y = GameCanvas2.h - 35 - ChatTextField2.gI().tfChat.height;
            GameCanvas2.panel.chatTField.initChatTextField();
            GameCanvas2.panel.chatTField.parentScreen = GameCanvas2.panel;
        }
        GameCanvas2.panel.chatTField.strChat = mResources2.world_channel_5_luong;
        GameCanvas2.panel.chatTField.tfChat.name = mResources2.CHAT;
        GameCanvas2.panel.chatTField.to = string.Empty;
        GameCanvas2.panel.chatTField.isShow = true;
        GameCanvas2.panel.chatTField.tfChat.isFocus = true;
        GameCanvas2.panel.chatTField.tfChat.setIputType(TField2.INPUT_TYPE_ANY);
        if (Main2.isIPhone)
        {
            GameCanvas2.panel.chatTField.startChat(GameCanvas2.panel, string.Empty);
        }
        else if (GameCanvas2.isTouch)
        {
            GameCanvas2.panel.chatTField.tfChat.doChangeToTextBox();
        }
    }

    public void GoToBoss(int mapId)
    {
        MyVector2 myVector = new();
        myVector.addElement(new Command2("Đi tới\nMAP " + mapId, this, 1, mapId.ToString()));
        myVector.addElement(new Command2("Huỷ", this, 2, null));

        GameCanvas2.menu.startAt(myVector, 4);
    }

    public void ChangeFPSTarget()
    {
        if (isHighFps)
        {
            Application.targetFrameRate = 60;
        }
        else
        {
            Application.targetFrameRate = 30;
        }
        SaveSettings();
    }

    public static Npc2 GetNpcByTempId(int tempId)
    {
        for (int i = 0; i < GameScr2.vNpc.size(); i++)
        {
            Npc2 npc = (Npc2)GameScr2.vNpc.elementAt(i);
            if (npc.template.npcTemplateId == tempId)
            {
                return npc;
            }
        }
        return null;
    }

    public static void LoadImages()
    {
        for (int i = 0; i < MainMod.numLogo; i++)
        {
            logos[i] = GameCanvas2.LoadImageFromRoot("/logo/" + i);
            if (i == 0 && logos[i] != null)
            {
                logoW = logos[i].getWidth() * mGraphics2.zoomLevel / 4;
                logoH = logos[i].getHeight() * mGraphics2.zoomLevel / 4;
            }
        }

        int bgId = 0;
        imgBg = GameCanvas2.LoadImageFromRoot("/logo/bg-" + bgId + ".png");
        imgLogoBig = GameCanvas2.LoadImageFromRoot("/logo/logo.png");

        imgCapsule = GameCanvas2.loadImage("/mainimage/btnCapsule.png");
        imgCapsuleF = GameCanvas2.loadImage("/mainimage/btnCapsuleF.png");

        imgPorata = GameCanvas2.loadImage("/mainimage/btnPorata.png");
        imgPorataF = GameCanvas2.loadImage("/mainimage/btnPorataF.png");

        imgZone = GameCanvas2.loadImage("/mainimage/btnZone.png");
        imgZoneF = GameCanvas2.loadImage("/mainimage/btnZoneF.png");

        imgNextMap = GameCanvas2.loadImage("/mainimage/btnNextMap.png");
        imgNextMapF = GameCanvas2.loadImage("/mainimage/btnNextMapF.png");

        imgPreMap = GameCanvas2.loadImage("/mainimage/btnPreMap.png");
        imgPreMapF = GameCanvas2.loadImage("/mainimage/btnPreMapF.png");

        imgMidMap = GameCanvas2.loadImage("/mainimage/btnMidMap.png");
        imgMidMapF = GameCanvas2.loadImage("/mainimage/btnMidMapF.png");

        IMAGE_SIZE = imgCapsule.getWidth();
    }

    public static void LoadTickImages()
    {
        for (int i = 0; i < 20; i++)
        {
            blueTicks[i] = GameCanvas2.loadImage("/blue_ticks/tick_" + i);
            redTicks[i] = GameCanvas2.loadImage("/red_ticks/tick_" + i);
        }
    }

    public static void PaintTicks(mGraphics2 g, bool isBlueTick, int x, int y)
    {
        int id = GameCanvas2.gameTick / 4 % 20;
        if (isBlueTick)
        {
            if (blueTicks[id] != null)
            {
                g.drawImage(blueTicks[id], x, y);
            }
        }
        else
        {
            if (redTicks[id] != null)
            {
                g.drawImage(redTicks[id], x, y);
            }
        }
    }

    public static sbyte[] DecryptBytes(sbyte[] data)
    {
        if (!MainMod.resEncrypted)
        {
            return data;
        }

        try
        {
            int length = data.Length;

            for (int i = length / 6; i < length; i++)
            {
                if (data[i] % 2 == 0)
                {
                    data[i] = (sbyte)(data[i] + 1);
                }
                else
                {
                    data[i] = (sbyte)(data[i] - 1);
                }
            }

            return data;
        }
        catch
        {
            return data;
        }
    }

    public static void SetPercentBean(string text, byte type)
    {
        bool success = int.TryParse(text, out int percent);
        if (success && percent > 0 && percent <= 100)
        {
            if (type == 0)
            {
                percentBeanHP = percent;
            }
            else
            {
                percentBeanMP = percent;
            }
            GameScr2.info1.addInfo("Ăn đậu khi " + (type == 0 ? "HP" : "MP") + " dưới " + percent + "%", 0);
            SaveSettings();
        }
        else
        {
            GameScr2.info1.addInfo("Chỉ nhập số từ 1 đến 100", 0);
        }
    }
}