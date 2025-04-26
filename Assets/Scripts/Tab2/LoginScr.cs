using System;
using UnityEngine;

public class LoginScr2 : mScreen2, IActionListener2
{
    public TField2 tfUser;

    public TField2 tfPass;

    public static bool isContinueToLogin = false;

    private int focus;

    private int wC;

    private int yL;

    private int defYL;

    public bool isCheck;

    public bool isRes;

    public Command2 cmdLogin;

    public Command2 cmdCheck;

    public Command2 cmdRes;

    public Command2 cmdMenu;

    public Command2 cmdBackFromRegister;

    public string listFAQ = string.Empty;

    public string titleFAQ;

    public string subtitleFAQ;

    private string numSupport = string.Empty;

    public static bool isLocal = false;

    public static bool isUpdateAll;

    public static bool isUpdateData;

    public static bool isUpdateMap;

    public static bool isUpdateSkill;

    public static bool isUpdateItem;

    public static string serverName;

    public int plX;

    public int plY;

    public int lY;

    public int lX;

    public int logoDes;

    public int lineX;

    public int lineY;

    public static int[] bgId = new int[5] { 0, 8, 2, 6, 9 };

    public static bool isTryGetIPFromWap;

    public static short timeLogin;

    public static long lastTimeLogin;

    public static long currTimeLogin;

    private int yt;

    private Command2 cmdSelect;

    private Command2 cmdOK;

    private int xLog;

    private int yLog;

    public static GameMidlet2 m;

    private int yy = GameCanvas2.hh - mScreen2.ITEM_HEIGHT - 5;

    private int freeAreaHeight;

    private int xP;

    private int yP;

    private int wP;

    private int hP;

    private int t = 20;

    private bool isRegistering;

    private string passRe = string.Empty;

    public bool isFAQ;

    private int tipid = -1;

    public bool isLogin2;

    private int v = 2;

    private int g;

    private int ylogo = -40;

    private int dir = 1;

    public static bool isLoggingIn;

    public LoginScr2()
    {
        yLog = GameCanvas2.hh - 30;
        TileMap2.bgID = (sbyte)(mSystem2.currentTimeMillis() % 9);
        if (TileMap2.bgID == 5 || TileMap2.bgID == 6)
        {
            TileMap2.bgID = 4;
        }
        GameScr2.loadCamera(fullmScreen: true, -1, -1);
        GameScr2.cmx = 100;
        GameScr2.cmy = 200;
        Main2.closeKeyBoard();
        if (GameCanvas2.h > 200)
        {
            defYL = GameCanvas2.hh - 80;
        }
        else
        {
            defYL = GameCanvas2.hh - 65;
        }
        resetLogo();
        wC = ((GameCanvas2.w < 200) ? 140 : 160);
        yt = GameCanvas2.hh - mScreen2.ITEM_HEIGHT - 5;
        if (GameCanvas2.h <= 160)
        {
            yt = 20;
        }
        tfUser = new TField2();
        tfUser.y = GameCanvas2.hh - mScreen2.ITEM_HEIGHT - 9;
        tfUser.width = wC;
        tfUser.height = mScreen2.ITEM_HEIGHT + 2;
        tfUser.isFocus = true;
        tfUser.setIputType(TField2.INPUT_TYPE_ANY);
        tfUser.name = mResources2.phone;
        tfPass = new TField2();
        tfPass.y = GameCanvas2.hh - 4;
        tfPass.setIputType(TField2.INPUT_TYPE_PASSWORD);
        tfPass.width = wC;
        tfPass.height = mScreen2.ITEM_HEIGHT + 2;
        yt += 35;
        isCheck = true;
        switch (Rms2.loadRMSInt("check"))
        {
            case 1:
                isCheck = true;
                break;
            case 2:
                isCheck = false;
                break;
        }
        tfUser.setText(Rms2.loadRMSString("acc"));
        tfPass.setText(Rms2.loadRMSString("pass"));
        focus = 0;
        cmdLogin = new Command2((GameCanvas2.w <= 200) ? mResources2.login2 : mResources2.login, GameCanvas2.instance, 888393, null);
        cmdCheck = new Command2(mResources2.remember, this, 2001, null);
        cmdRes = new Command2(mResources2.register, this, 2002, null);
        cmdBackFromRegister = new Command2(mResources2.CANCEL, this, 10021, null);
        left = (cmdMenu = new Command2(mResources2.MENU, this, 2003, null));
        freeAreaHeight = tfUser.y - 2 * tfUser.height;
        if (GameCanvas2.isTouch)
        {
            cmdLogin.x = GameCanvas2.w / 2 + 8;
            cmdMenu.x = GameCanvas2.w / 2 - mScreen2.cmdW - 8;
            if (GameCanvas2.h >= 200)
            {
                cmdLogin.y = yLog + 110;
                cmdMenu.y = yLog + 110;
            }
            cmdBackFromRegister.x = GameCanvas2.w / 2 + 3;
            cmdBackFromRegister.y = yLog + 110;
            cmdRes.x = GameCanvas2.w / 2 - 84;
            cmdRes.y = cmdMenu.y;
        }
        wP = 170;
        hP = ((!isRes) ? 100 : 110);
        xP = GameCanvas2.hw - wP / 2;
        yP = tfUser.y - 15;
        int num2 = 4;
        int num3 = num2 * 32 + 23 + 33;
        if (num3 >= GameCanvas2.w)
        {
            num2--;
            num3 = num2 * 32 + 23 + 33;
        }
        xLog = GameCanvas2.w / 2 - num3 / 2;
        yLog = GameCanvas2.hh - 30;
        lY = ((GameCanvas2.w < 200) ? (tfUser.y - 30) : (yLog - 30));
        tfUser.x = xLog + 10;
        tfUser.y = yLog + 20;
        cmdOK = new(mResources2.OK, this, 2008, null);
        cmdOK.x = GameCanvas2.w / 2 - 84;
        cmdOK.y = cmdLogin.y;
        MainMod2.cmdAccManager = new(MainMod2.strAccManager, MainMod2.GI(), 101, null);
        MainMod2.cmdAccManager.x = GameCanvas2.w / 2 + 3;
        MainMod2.cmdAccManager.y = cmdLogin.y;

        center = cmdOK;
        left = MainMod2.cmdAccManager;

        MainMod2.cmdCloseAccManager = new(mResources2.CLOSE, MainMod2.GI(), 104, null);

        MainMod2.GI().LoadAcc();
    }

    public override void switchToMe()
    {
        isRegistering = false;
        SoundMn2.gI().stopAll();
        tfUser.isFocus = true;
        tfPass.isFocus = false;
        if (GameCanvas2.isTouch)
        {
            tfUser.isFocus = false;
        }
        GameCanvas2.loadBG(12);
        base.switchToMe();
    }

    public void setUserPass()
    {
        string text = Rms2.loadRMSString("acc");
        if (text != null && !text.Equals(string.Empty))
        {
            tfUser.setText(text);
        }
        string text2 = Rms2.loadRMSString("pass");
        if (text2 != null && !text2.Equals(string.Empty))
        {
            tfPass.setText(text2);
        }
    }

    public void updateTfWhenOpenKb()
    {
    }

    protected void doMenu()
    {
        MyVector2 myVector = new MyVector2();
        myVector.addElement(new Command2(mResources2.registerNewAcc, this, 2004, null));
        if (!isLogin2)
        {
            myVector.addElement(new Command2(mResources2.selectServer, this, 1004, null));
        }
        myVector.addElement(new Command2(mResources2.forgetPass, this, 1003, null));
        myVector.addElement(new Command2(mResources2.website, this, 1005, null));
        if (Main2.isPC)
        {
            myVector.addElement(new Command2(mResources2.EXIT, GameCanvas2.instance, 8885, null));
        }
        GameCanvas2.menu.startAt(myVector, 0);
    }

    protected void doRegister()
    {
        if (tfUser.getText().Equals(string.Empty))
        {
            GameCanvas2.startOKDlg(mResources2.userBlank);
            return;
        }
        char[] array = tfUser.getText().ToCharArray();
        if (tfPass.getText().Equals(string.Empty))
        {
            GameCanvas2.startOKDlg(mResources2.passwordBlank);
            return;
        }
        if (tfUser.getText().Length < 5)
        {
            GameCanvas2.startOKDlg(mResources2.accTooShort);
            return;
        }
        int num = 0;
        string text = null;
        if (mResources2.language == 2)
        {
            if (tfUser.getText().IndexOf("@") == -1 || tfUser.getText().IndexOf(".") == -1)
            {
                text = mResources2.emailInvalid;
            }
            num = 0;
        }
        else
        {
            try
            {
                long num2 = long.Parse(tfUser.getText());
                if (tfUser.getText().Length < 8 || tfUser.getText().Length > 12 || (!tfUser.getText().StartsWith("0") && !tfUser.getText().StartsWith("84")))
                {
                    text = mResources2.phoneInvalid;
                }
                num = 1;
            }
            catch (Exception)
            {
                if (tfUser.getText().IndexOf("@") == -1 || tfUser.getText().IndexOf(".") == -1)
                {
                    text = mResources2.emailInvalid;
                }
                num = 0;
            }
        }
        if (text != null)
        {
            GameCanvas2.startOKDlg(text);
        }
        else
        {
            GameCanvas2.msgdlg.setInfo(mResources2.plsCheckAcc + ((num != 1) ? (mResources2.email + ": ") : (mResources2.phone + ": ")) + tfUser.getText() + "\n" + mResources2.password + ": " + tfPass.getText(), new Command2(mResources2.ACCEPT, this, 4000, null), null, new Command2(mResources2.NO, GameCanvas2.instance, 8882, null));
        }
        GameCanvas2.currentDialog = GameCanvas2.msgdlg;
    }

    protected void doRegister(string user)
    {
        isFAQ = false;
        GameCanvas2.startWaitDlg(mResources2.CONNECTING);
        GameCanvas2.connect();
        GameCanvas2.startWaitDlg(mResources2.REGISTERING);
        passRe = tfPass.getText();
        Service2.gI().requestRegister(user, tfPass.getText(), Rms2.loadRMSString("userAo" + ServerListScreen2.ipSelect), Rms2.loadRMSString("passAo" + ServerListScreen2.ipSelect), GameMidlet2.VERSION);
        Rms2.saveRMSString("acc", user);
        Rms2.saveRMSString("pass", tfPass.getText());
        t = 20;
        isRegistering = true;
    }

    public void doViewFAQ()
    {
        if (!listFAQ.Equals(string.Empty) || !listFAQ.Equals(string.Empty))
        {
        }
        if (!Session_ME2_.connected)
        {
            isFAQ = true;
            GameCanvas2.connect();
        }
        GameCanvas2.startWaitDlg();
    }

    protected void saveIndexServer(int index)
    {
        Rms2.saveRMSInt("indServer", index);
    }

    protected int loadIndexServer()
    {
        return Rms2.loadRMSInt("indServer");
    }

    public void doLogin()
    {
        string text = Rms2.loadRMSString("acc");
        string text2 = Rms2.loadRMSString("pass");
        if (text != null && !text.Equals(string.Empty))
        {
            isLogin2 = false;
        }
        else if (Rms2.loadRMSString("userAo" + ServerListScreen2.ipSelect) != null && !Rms2.loadRMSString("userAo" + ServerListScreen2.ipSelect).Equals(string.Empty))
        {
            isLogin2 = true;
        }
        else
        {
            isLogin2 = false;
        }
        if ((text == null || text.Equals(string.Empty)) && isLogin2)
        {
            text = Rms2.loadRMSString("userAo" + ServerListScreen2.ipSelect);
            text2 = "a";
        }
        if (text == null || text2 == null || GameMidlet2.VERSION == null || text.Equals(string.Empty))
        {
            return;
        }
        if (text2.Equals(string.Empty))
        {
            focus = 1;
            tfUser.isFocus = false;
            tfPass.isFocus = true;
            if (!GameCanvas2.isTouch)
            {
                right = tfPass.cmdClear;
            }
            return;
        }
        if (!Session_ME2_.gI().isConnected())
        {
            GameCanvas2.connect();
        }
        Service2.gI().login(text, text2, GameMidlet2.VERSION, (sbyte)(isLogin2 ? 1 : 0));
        if (Session_ME2_.connected)
        {
            GameCanvas2.startWaitDlg();
        }
        else
        {
            GameCanvas2.startOKDlg(mResources2.maychutathoacmatsong);
        }
        focus = 0;
        if (!isLogin2)
        {
            actRegisterLeft();
        }
        GameCanvas2.timeBreakLoading = mSystem2.currentTimeMillis() + 30000;
    }

    public void savePass()
    {
        if (isCheck)
        {
            Rms2.saveRMSInt("check", 1);
            Rms2.saveRMSString("acc", tfUser.getText().ToLower().Trim());
            Rms2.saveRMSString("pass", tfPass.getText().ToLower().Trim());
        }
        else
        {
            Rms2.saveRMSInt("check", 2);
            Rms2.saveRMSString("acc", string.Empty);
            Rms2.saveRMSString("pass", string.Empty);
        }
    }

    public override void update()
    {
        if (MainMod2.AutoLogin())
        {
            return;
        }
        if (Main2.isWindowsPhone && isRegistering)
        {
            if (t < 0)
            {
                GameCanvas2.endDlg();
                Session_ME2_.gI().close();
                GameCanvas2.serverScreen.switchToMe();
                isRegistering = false;
            }
            else
            {
                t--;
            }
        }
        if (timeLogin > 0)
        {
            GameCanvas2.startWaitDlg();
            currTimeLogin = mSystem2.currentTimeMillis();
            if (currTimeLogin - lastTimeLogin >= 1000)
            {
                timeLogin--;
                if (timeLogin == 0)
                {
                    GameCanvas2.loginScr.doLogin();
                }
                lastTimeLogin = currTimeLogin;
            }
        }
        if (isLogin2 && !isRes)
        {
            tfUser.name = mResources2.phone;
            tfPass.name = mResources2.password;
            tfUser.isPaintCarret = false;
            tfPass.isPaintCarret = false;
            tfUser.update();
            tfPass.update();
        }
        else
        {
            tfUser.name = mResources2.phone;
            tfPass.name = mResources2.password;
            tfUser.update();
            tfPass.update();
        }
        if (TouchScreenKeyboard.visible)
        {
            mGraphics2.addYWhenOpenKeyBoard = 50;
        }
        for (int i = 0; i < Effect2_2.vEffect2.size(); i++)
        {
            Effect2_2 effect = (Effect2_2)Effect2_2.vEffect2.elementAt(i);
            effect.update();
        }
        if (isUpdateAll && !isUpdateData && !isUpdateItem && !isUpdateMap && !isUpdateSkill)
        {
            isUpdateAll = false;
            mSystem2.gcc();
            Service2.gI().finishUpdate();
        }
        GameScr2.cmx++;
        if (GameScr2.cmx > GameCanvas2.w * 3 + 100)
        {
            GameScr2.cmx = 100;
        }
        if (ChatPopup2.currChatPopup != null)
        {
            return;
        }
        updateLogo();
        if (g >= 0)
        {
            ylogo += dir * g;
            g += dir * v;
            if (g <= 0)
            {
                dir *= -1;
            }
            if (ylogo > 0)
            {
                dir *= -1;
                g -= 2 * v;
            }
        }
        if (tipid >= 0 && GameCanvas2.gameTick % 100 == 0)
        {
            doChangeTip();
        }
        if (isLogin2 && !isRes)
        {
            tfUser.isPaintCarret = false;
            tfPass.isPaintCarret = false;
            tfUser.update();
            tfPass.update();
        }
        else
        {
            tfUser.name = mResources2.phone;
            tfPass.name = mResources2.password;
            tfUser.update();
            tfPass.update();
        }
        if (GameCanvas2.isTouch)
        {
            if (isRes)
            {
                center = cmdRes;
                left = cmdBackFromRegister;
            }
            else
            {
                center = cmdOK;
                left = MainMod2.cmdAccManager;
            }
        }
        else if (isRes)
        {
            center = cmdRes;
            left = cmdBackFromRegister;
        }
        else
        {
            center = cmdOK;
            left = MainMod2.cmdAccManager;
        }
        if (!Main2.isPC && !TouchScreenKeyboard.visible && !Main2.isMiniApp && !Main2.isWindowsPhone)
        {
            string text = tfUser.getText().ToLower().Trim();
            string text2 = tfPass.getText().ToLower().Trim();
            if (!text.Equals(string.Empty) && !text2.Equals(string.Empty))
            {
                doLogin();
            }
            Main2.isMiniApp = true;
        }
        updateTfWhenOpenKb();
    }

    private void doChangeTip()
    {
        tipid++;
        if (tipid >= mResources2.tips.Length)
        {
            tipid = 0;
        }
        if (GameCanvas2.currentDialog == GameCanvas2.msgdlg && GameCanvas2.msgdlg.isWait)
        {
            GameCanvas2.msgdlg.setInfo(mResources2.tips[tipid]);
        }
    }

    public void updateLogo()
    {
        if (defYL != yL)
        {
            yL += defYL - yL >> 1;
        }
    }

    public override void keyPress(int keyCode)
    {
        if (tfUser.isFocus)
        {
            tfUser.keyPressed(keyCode);
        }
        else if (tfPass.isFocus)
        {
            tfPass.keyPressed(keyCode);
        }
        base.keyPress(keyCode);
    }

    public override void unLoad()
    {
        base.unLoad();
    }

    public override void paint(mGraphics2 g)
    {
        GameCanvas2.paintBGGameScr(g);
        int num = tfUser.y - 50;
        if (GameCanvas2.h <= 220)
        {
            num += 5;
        }
        mFont2.tahoma_7_white.drawStringBorder(g, "v" + GameMidlet2.VERSION, GameCanvas2.w - 2, 17, 1, mFont2.tahoma_7_grey);
        if (mSystem2.clientType == 1 && !GameCanvas2.isTouch)
        {
            mFont2.tahoma_7_white.drawStringBorder(g, ServerListScreen2.linkweb, GameCanvas2.w - 2, GameCanvas2.h - 15, 1, mFont2.tahoma_7_grey);
        }
        else
        {
            mFont2.tahoma_7_white.drawStringBorder(g, ServerListScreen2.linkweb, GameCanvas2.w - 2, 2, 1, mFont2.tahoma_7_grey);
        }
        if (ChatPopup2.currChatPopup != null || ChatPopup2.serverChatPopUp != null)
        {
            return;
        }
        if (GameCanvas2.currentDialog == null)
        {
            if (MainMod2.isOpenAccMAnager)
            {
                int h = 180;
                int w = (GameCanvas2.w < 200) ? 160 : 260;

                int xPop = (GameCanvas2.w - w) / 2;
                int yPop = (GameCanvas2.h - h) / 2;

                PopUp2.paintPopUp(g, xPop, yPop, w, h, -1, isButton: true);
                left = null;
                center = null;

                int yStart = yPop + 20;

                for (int i = 0; i < MainMod2.GI().cmdsChooseAcc.Count; i++)
                {
                    MainMod2.GI().cmdsChooseAcc[i].x = xPop + 20;
                    MainMod2.GI().cmdsChooseAcc[i].y = yStart;
                    MainMod2.GI().cmdsChooseAcc[i].paint(g);

                    MainMod2.GI().cmdsDelAcc[i].x = xPop + 190;
                    MainMod2.GI().cmdsDelAcc[i].y = yStart;
                    MainMod2.GI().cmdsDelAcc[i].paint(g);

                    yStart += 30;
                }

                MainMod2.cmdCloseAccManager.x = (GameCanvas2.w - MainMod2.cmdCloseAccManager.w) / 2;
                MainMod2.cmdCloseAccManager.y = yPop + h + 10;
                MainMod2.cmdCloseAccManager.paint(g);

                if (GameCanvas2.h > 160 && MainMod2.imgLogoBig != null)
                {
                    //g.drawImage(SplashScr.imgLogo, GameCanvas.hw, yPop - 20, 3);

                    int imgW = MainMod2.imgLogoBig.getWidth() * mGraphics2.zoomLevel / 4;
                    int imgH = MainMod2.imgLogoBig.getHeight() * mGraphics2.zoomLevel / 4;
                    g.drawImageScale(MainMod2.imgLogoBig, GameCanvas2.hw - (imgW / 2), yPop - (imgH / 2) - 20, imgW, imgH);
                }
            }
            else
            {
                int h = 105;
                int w = (GameCanvas2.w < 200) ? 160 : 180;
                PopUp2.paintPopUp(g, xLog, yLog - 10, w, h, -1, isButton: true);
                if (GameCanvas2.h > 160 && MainMod2.imgLogoBig != null)
                {
                    //g.drawImage(SplashScr.imgLogo, GameCanvas.hw, num, 3);

                    int imgW = MainMod2.imgLogoBig.getWidth() * mGraphics2.zoomLevel / 4;
                    int imgH = MainMod2.imgLogoBig.getHeight() * mGraphics2.zoomLevel / 4;
                    g.drawImageScale(MainMod2.imgLogoBig, GameCanvas2.hw - (imgW / 2), num - (imgH / 2) - 15, imgW, imgH);
                }
                int num2 = 4;
                int num3 = num2 * 32 + 23 + 33;
                if (num3 >= GameCanvas2.w)
                {
                    num2--;
                    num3 = num2 * 32 + 23 + 33;
                }
                xLog = GameCanvas2.w / 2 - num3 / 2;
                tfUser.x = xLog + 10;
                tfUser.y = yLog + 20;
                tfPass.x = xLog + 10;
                tfPass.y = yLog + 55;
                tfUser.paint(g);
                tfPass.paint(g);
                if (GameCanvas2.w < 176)
                {
                    mFont2.tahoma_7b_green2.drawString(g, mResources2.acc + ":", tfUser.x - 35, tfUser.y + 7, 0);
                    mFont2.tahoma_7b_green2.drawString(g, mResources2.pwd + ":", tfPass.x - 35, tfPass.y + 7, 0);
                    mFont2.tahoma_7b_green2.drawString(g, mResources2.server + ":" + serverName, GameCanvas2.w / 2, tfPass.y + 32, 2);
                }
            }
        }
        base.paint(g);
    }

    public override void updateKey()
    {
        if (isContinueToLogin)
        {
            return;
        }
        if (!GameCanvas2.isTouch)
        {
            if (tfUser.isFocus)
            {
                right = tfUser.cmdClear;
            }
            else
            {
                right = tfPass.cmdClear;
            }
        }
        if (GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21])
        {
            focus--;
            if (focus < 0)
            {
                focus = 1;
            }
        }
        else if (GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22] || GameCanvas2.keyPressed[16])
        {
            focus++;
            if (focus > 1)
            {
                focus = 0;
            }
        }
        if (GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21] || GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22] || GameCanvas2.keyPressed[16])
        {
            GameCanvas2.clearKeyPressed();
            if (!isLogin2 || isRes)
            {
                if (focus == 1)
                {
                    tfUser.isFocus = false;
                    tfPass.isFocus = true;
                }
                else if (focus == 0)
                {
                    tfUser.isFocus = true;
                    tfPass.isFocus = false;
                }
                else
                {
                    tfUser.isFocus = false;
                    tfPass.isFocus = false;
                }
            }
        }
        if (GameCanvas2.isTouch)
        {
            if (isRes)
            {
                center = cmdRes;
                left = cmdBackFromRegister;
            }
            else
            {
                center = cmdOK;
                left = MainMod2.cmdAccManager;
            }
        }
        else if (isRes)
        {
            center = cmdRes;
            left = cmdBackFromRegister;
        }
        else
        {
            center = cmdOK;
            left = MainMod2.cmdAccManager;
        }
        if (GameCanvas2.isPointerJustRelease && (!isLogin2 || isRes) && !MainMod2.isOpenAccMAnager)
        {
            if (GameCanvas2.isPointerHoldIn(tfUser.x, tfUser.y, tfUser.width, tfUser.height))
            {
                focus = 0;
            }
            else if (GameCanvas2.isPointerHoldIn(tfPass.x, tfPass.y, tfPass.width, tfPass.height))
            {
                focus = 1;
            }
        }
        if (Main2.isPC && GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] && right != null)
        {
            right.performAction();
        }
        if (MainMod2.isOpenAccMAnager)
        {
            foreach (Command2 cmd in MainMod2.GI().cmdsChooseAcc)
            {
                if (cmd.isPointerPressInside())
                {
                    cmd.performAction();
                }
            }
            foreach (Command2 cmd in MainMod2.GI().cmdsDelAcc)
            {
                if (cmd.isPointerPressInside())
                {
                    cmd.performAction();
                }
            }
            if (MainMod2.cmdCloseAccManager.isPointerPressInside())
            {
                MainMod2.cmdCloseAccManager.performAction();
            }
        }
        base.updateKey();
        GameCanvas2.clearKeyPressed();
    }

    public void resetLogo()
    {
        yL = -50;
    }

    public void perform(int idAction, object p)
    {
        switch (idAction)
        {
            case 13:
                switch (mSystem2.clientType)
                {
                    case 1:
                        mSystem2.callHotlineJava();
                        break;
                    case 3:
                    case 5:
                        mSystem2.callHotlineIphone();
                        break;
                    case 6:
                        mSystem2.callHotlineWindowsPhone();
                        break;
                    case 4:
                        mSystem2.callHotlinePC();
                        break;
                    case 2:
                        break;
                }
                break;
            case 1000:
                try
                {
                    GameMidlet2.instance.platformRequest((string)p);
                }
                catch (Exception)
                {
                }
                GameCanvas2.endDlg();
                break;
            case 1001:
                GameCanvas2.endDlg();
                isRes = false;
                break;
            case 1002:
                {
                    GameCanvas2.startWaitDlg();
                    string text = Rms2.loadRMSString("userAo" + ServerListScreen2.ipSelect);
                    if (text == null || text.Equals(string.Empty))
                    {
                        Service2.gI().login2(string.Empty);
                        break;
                    }
                    GameCanvas2.loginScr.isLogin2 = true;
                    GameCanvas2.connect();
                    Service2.gI().setClientType();
                    Service2.gI().login(text, string.Empty, GameMidlet2.VERSION, 1);
                    break;
                }
            case 1004:
                ServerListScreen2.doUpdateServer();
                GameCanvas2.serverScreen.switchToMe();
                break;
            case 10021:
                actRegisterLeft();
                break;
            case 1003:
                GameCanvas2.startOKDlg(mResources2.goToWebForPassword);
                break;
            case 1005:
                try
                {
                    GameMidlet2.instance.platformRequest(ServerListScreen2.linkweb);
                    break;
                }
                catch (Exception)
                {
                    break;
                }
            case 10041:
                Rms2.saveRMSInt("lowGraphic", 0);
                GameCanvas2.startOK(mResources2.plsRestartGame, 8885, null);
                break;
            case 10042:
                Rms2.saveRMSInt("lowGraphic", 1);
                GameCanvas2.startOK(mResources2.plsRestartGame, 8885, null);
                break;
            case 2001:
                if (isCheck)
                {
                    isCheck = false;
                }
                else
                {
                    isCheck = true;
                }
                break;
            case 2002:
                doRegister();
                break;
            case 2003:
                doMenu();
                break;
            case 2004:
                actRegister();
                break;
            case 2008:
                string user = tfUser.getText().Trim();
                string pass = tfPass.getText().Trim();
                MainMod2.GI().AddAccount(user, pass);
                Rms2.saveRMSString("acc", user);
                Rms2.saveRMSString("pass", pass);
                if (ServerListScreen2.loadScreen)
                {
                    GameCanvas2.serverScreen.switchToMe();
                }
                else
                {
                    GameCanvas2.serverScreen.show2();
                }
                break;
            case 4000:
                doRegister(tfUser.getText());
                break;
        }
    }

    public void actRegisterLeft()
    {
        if (isLogin2)
        {
            doLogin();
            return;
        }
        isRes = false;
        tfPass.isFocus = false;
        tfUser.isFocus = true;
        left = cmdMenu;
    }

    public void actRegister()
    {
        GameCanvas2.endDlg();
        isRes = true;
        tfPass.isFocus = false;
        tfUser.isFocus = true;
    }

    public void backToRegister()
    {
        GameCanvas2.timeBreakLoading = mSystem2.currentTimeMillis() + 30000;
        ServerListScreen2.countDieConnect = 0;
        if (GameCanvas2.loginScr.isLogin2)
        {
            GameCanvas2.startYesNoDlg(mResources2.note, new Command2(mResources2.YES, GameCanvas2.panel, 10019, null), new Command2(mResources2.NO, GameCanvas2.panel, 10020, null));
            return;
        }
        if (Main2.isWindowsPhone)
        {
            GameMidlet2.isBackWindowsPhone = true;
        }
        GameCanvas2.instance.resetToLoginScr = false;
        GameCanvas2.instance.doResetToLoginScr(GameCanvas2.loginScr);
    }
}
