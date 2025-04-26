using System;

public class ServerListScreen2 : mScreen2, IActionListener2
{
    public static string[] nameServer;

    public static string[] address;

    public static sbyte serverPriority;

    public static bool[] hasConnected;

    public static short[] port;

    public static int selected;

    public static bool isWait;

    public static Command2 cmdUpdateServer;

    public static sbyte[] language;

    private Command2[] cmd;

    private int nCmdPlay;

    public static Command2 cmdDeleteRMS;

    public static string linkDefault = MainMod.DecodeByteArrayString(MainMod.ipString, "6");

    // public const sbyte languageVersion = 2;

    // public new int keyTouch = -1;

    public static bool stopDownload;

    public static string linkweb = MainMod.homeUrl;

    public static int countDieConnect;

    public static bool waitToLogin;

    public static int tWaitToLogin;

    public static int[] lengthServer = new int[3];

    public static int ipSelect;

    public static int flagServer;

    public static bool bigOk;

    public static int percent;

    public static string strWait;

    public static int nBig;

    public static int nBg;

    public static int demPercent;

    public static int maxBg;

    public static bool isGetData = false;

    public static Command2 cmdDownload;

    private Command2 cmdStart;

    public string dataSize;

    public static int p;

    public static int testConnect = -1;

    public static bool loadScreen;

    public static bool isAutoConect = true;

    public ServerListScreen2()
    {
        int num = 4;
        int num2 = num * 32 + 23 + 33;
        if (num2 >= GameCanvas2.w)
        {
            num--;
            num2 = num * 32 + 23 + 33;
        }
        initCommand();
        if (!GameCanvas2.isTouch)
        {
            selected = 0;
            processInput();
        }
        GameScr2.loadCamera(fullmScreen: true, -1, -1);
        GameScr2.cmx = 100;
        GameScr2.cmy = 200;
        cmdUpdateServer = new Command2
        {
            actionChat = delegate (string str)
        {
            string text = str;
            string text2 = str;
            if (text == null)
            {
                text = linkDefault;
            }
            else
            {
                if (text == null && text2 != null)
                {
                    if (text2.Equals(string.Empty) || text2.Length < 20)
                    {
                        text2 = linkDefault;
                    }
                    GetServerList(text2);
                }
                if (text != null && text2 == null)
                {
                    if (text.Equals(string.Empty) || text.Length < 20)
                    {
                        text = linkDefault;
                    }
                    GetServerList(text);
                }
                if (text != null && text2 != null)
                {
                    if (text.Length > text2.Length)
                    {
                        GetServerList(text);
                    }
                    else
                    {
                        GetServerList(text2);
                    }
                }
            }
        }
        };
    }

    public static void createDeleteRMS()
    {
        if (cmdDeleteRMS == null)
        {
            if (GameCanvas2.serverScreen == null)
            {
                GameCanvas2.serverScreen = new ServerListScreen2();
            }
            cmdDeleteRMS = new Command2(string.Empty, GameCanvas2.serverScreen, 14, null);
            cmdDeleteRMS.x = GameCanvas2.w - 78;
            cmdDeleteRMS.y = GameCanvas2.h - 26;
        }
    }

    private void initCommand()
    {
        nCmdPlay = 0;
        string text = Rms2.loadRMSString("acc");
        string text2 = Rms2.loadRMSString("pass");
        if (text == null)
        {
            if (Rms2.loadRMS("userAo" + ipSelect) != null)
            {
                nCmdPlay = 1;
            }
        }
        else if (text.Equals(string.Empty))
        {
            if (Rms2.loadRMS("userAo" + ipSelect) != null)
            {
                nCmdPlay = 1;
            }
        }
        else
        {
            nCmdPlay = 1;
        }
        cmd = new Command2[3 + nCmdPlay];
        int num = GameCanvas2.hh - 15 * cmd.Length + 28;
        for (int i = 0; i < cmd.Length; i++)
        {
            switch (i)
            {
                case 0:
                    cmd[0] = new Command2(string.Empty, this, 3, null);
                    if (text == null)
                    {
                        cmd[0].caption = mResources2.playNew;
                        if (Rms2.loadRMS("userAo" + ipSelect) != null)
                        {
                            cmd[0].caption = mResources2.choitiep;
                        }
                        break;
                    }
                    if (text.Equals(string.Empty))
                    {
                        cmd[0].caption = mResources2.playNew;
                        if (Rms2.loadRMS("userAo" + ipSelect) != null)
                        {
                            cmd[0].caption = mResources2.choitiep;
                        }
                        break;
                    }
                    cmd[0].caption = mResources2.playAcc + ": " + (!text.Contains(',') ? text : "");
                    if (cmd[0].caption.Length > 23)
                    {
                        cmd[0].caption = cmd[0].caption.Substring(0, 23);
                        cmd[0].caption += "...";
                    }
                    break;
                case 1:
                    if (nCmdPlay == 1)
                    {
                        cmd[1] = new Command2(string.Empty, this, 10100, null)
                        {
                            caption = mResources2.playNew
                        };
                    }
                    else
                    {
                        cmd[1] = new Command2(mResources2.change_account, this, 7, null);
                    }
                    break;
                case 2:
                    if (nCmdPlay == 1)
                    {
                        cmd[2] = new Command2(mResources2.change_account, this, 7, null);
                    }
                    else
                    {
                        cmd[2] = new Command2(string.Empty, this, 17, null);
                    }
                    break;
                case 3:
                    cmd[3] = new Command2(string.Empty, this, 17, null);
                    break;
            }
            cmd[i].y = num;
            cmd[i].setType();
            cmd[i].x = (GameCanvas2.w - cmd[i].w) / 2;
            num += 30;
        }
    }

    public static void doUpdateServer()
    {
        if (cmdUpdateServer == null && GameCanvas2.serverScreen == null)
        {
            GameCanvas2.serverScreen = new ServerListScreen2();
        }
        Net2.connectHTTP2(linkDefault, cmdUpdateServer);
    }

    public static void GetServerList(string str)
    {
        lengthServer = new int[3];
        string[] array = Res2.split(str.Trim(), ",", 0);
        mResources2.loadLanguague(sbyte.Parse(array[array.Length - 2]));
        nameServer = new string[array.Length - 2];
        address = new string[array.Length - 2];
        port = new short[array.Length - 2];
        language = new sbyte[array.Length - 2];
        hasConnected = new bool[2];
        for (int i = 0; i < array.Length - 2; i++)
        {
            string[] array2 = Res2.split(array[i].Trim(), ":", 0);
            nameServer[i] = array2[0];
            address[i] = array2[1];
            port[i] = short.Parse(array2[2]);
            language[i] = sbyte.Parse(array2[3].Trim());
            lengthServer[language[i]]++;
        }
        serverPriority = sbyte.Parse(array[^1]);
        SaveIP();
    }

    public override void paint(mGraphics2 g)
    {
        if (!loadScreen)
        {
            g.setColor(0);
            g.fillRect(0, 0, GameCanvas2.w, GameCanvas2.h);
        }
        else
        {
            GameCanvas2.paintBGGameScr(g);
        }
        int num2 = 2;
        mFont2.tahoma_7_white.drawStringBorder(g, "v" + GameMidlet2.VERSION + " (x" + mGraphics2.zoomLevel + ")", GameCanvas2.w - 2, num2 + 15, 1, mFont2.tahoma_7_grey);
        string empty = string.Empty;
        empty = (testConnect != 0) ? (empty + nameServer[ipSelect] + " connected") : (empty + nameServer[ipSelect] + " disconnect");
        if (mSystem2.isTest)
        {
            mFont2.tahoma_7_white.drawString(g, empty, GameCanvas2.w - 2, num2 + 15 + 15, 1, mFont2.tahoma_7_grey);
        }
        if (!isGetData || loadScreen)
        {
            if (mSystem2.clientType == 1 && !GameCanvas2.isTouch)
            {
                mFont2.tahoma_7_white.drawStringBorder(g, linkweb, GameCanvas2.w - 2, GameCanvas2.h - 15, 1, mFont2.tahoma_7_grey);
            }
            else
            {
                mFont2.tahoma_7_white.drawStringBorder(g, linkweb, GameCanvas2.w - 2, num2, 1, mFont2.tahoma_7_grey);
            }
        }
        else
        {
            mFont2.tahoma_7_white.drawStringBorder(g, linkweb, GameCanvas2.w - 2, num2, 1, mFont2.tahoma_7_grey);
        }

        _ = (GameCanvas2.w < 200) ? 160 : 180;
        if (cmdDeleteRMS != null)
        {
            mFont2.tahoma_7_white.drawStringBorder(g, mResources2.xoadulieu, GameCanvas2.w - 2, GameCanvas2.h - 15, 1, mFont2.tahoma_7_grey);
        }
        if (GameCanvas2.currentDialog == null)
        {
            if (!loadScreen)
            {
                if (!bigOk)
                {
                    g.drawImageScale(MainMod2.imgBg, 0, 0, GameCanvas2.w, GameCanvas2.h, 0);
                    //g.drawImage(SplashScr.imgLogo, GameCanvas.hw, GameCanvas.hh - 32, 3);

                    int imgW = MainMod2.imgLogoBig.getWidth() * mGraphics2.zoomLevel / 4;
                    int imgH = MainMod2.imgLogoBig.getHeight() * mGraphics2.zoomLevel / 4;
                    g.drawImageScale(MainMod2.imgLogoBig, GameCanvas2.hw - (imgW / 2), GameCanvas2.hh - (imgH / 2) - 32, imgW, imgH);

                    if (!isGetData)
                    {
                        mFont2.tahoma_7b_white.drawString(g, mResources2.taidulieudechoi, GameCanvas2.hw, GameCanvas2.hh + 24, 2);
                        cmdDownload?.paint(g);
                    }
                    else
                    {
                        cmdDownload?.paint(g);
                        mFont2.tahoma_7b_white.drawString(g, mResources.downloading_data + "..." + percent + "%", GameCanvas.w / 2, GameCanvas.hh + 24, 2);
                        GameScr2.paintOngMauPercent(GameScr2.frBarPow20, GameScr2.frBarPow21, GameScr2.frBarPow22, GameCanvas2.w / 2 - 50, GameCanvas2.hh + 45, 100, 100f, g);
                        GameScr2.paintOngMauPercent(GameScr2.frBarPow0, GameScr2.frBarPow1, GameScr2.frBarPow2, GameCanvas2.w / 2 - 50, GameCanvas2.hh + 45, 100, percent, g);
                    }
                }
            }
            else
            {
                int num4 = GameCanvas2.hh - 15 * cmd.Length - 15;
                if (num4 < 25)
                {
                    num4 = 25;
                }
                if (MainMod2.imgLogoBig != null)
                {
                    //g.drawImage(SplashScr.imgLogo, GameCanvas.hw, num4, 3);

                    int imgW = MainMod2.imgLogoBig.getWidth() * mGraphics2.zoomLevel / 4;
                    int imgH = MainMod2.imgLogoBig.getHeight() * mGraphics2.zoomLevel / 4;
                    g.drawImageScale(MainMod2.imgLogoBig, GameCanvas2.hw - (imgW / 2), num4 - (imgH / 2), imgW, imgH);
                }
                for (int i = 0; i < cmd.Length; i++)
                {
                    cmd[i].paint(g);
                }
                g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
                if (testConnect == -1)
                {
                    if (GameCanvas2.gameTick % 20 > 10)
                    {
                        g.drawRegion(GameScr2.imgRoomStat, 0, 14, 7, 7, 0, (GameCanvas2.w - mFont2.tahoma_7b_dark.getWidth(cmd[2 + nCmdPlay].caption) >> 1) - 10, cmd[2 + nCmdPlay].y + 10, 0);
                    }
                }
                else
                {
                    g.drawRegion(GameScr2.imgRoomStat, 0, testConnect * 7, 7, 7, 0, (GameCanvas2.w - mFont2.tahoma_7b_dark.getWidth(cmd[2 + nCmdPlay].caption) >> 1) - 10, cmd[2 + nCmdPlay].y + 9, 0);
                }
            }
        }
        base.paint(g);
    }

    public void selectServer()
    {
        flagServer = MainMod2.isAutoLogin ? 120 : 30;
        GameCanvas2.startWaitDlg(mResources2.PLEASEWAIT);
        Session_ME2_.gI().close();
        GameMidlet2.IP = address[ipSelect];
        GameMidlet2.PORT = port[ipSelect];
        GameMidlet2.LANGUAGE = language[ipSelect];
        Rms2.saveRMSInt("svselect", ipSelect);
        if (language[ipSelect] != mResources2.language)
        {
            mResources2.loadLanguague(language[ipSelect]);
        }
        LoginScr2.serverName = nameServer[ipSelect];
        initCommand();
        loadScreen = true;
        countDieConnect = 0;
        testConnect = -1;
        isAutoConect = true;
    }

    public override void update()
    {
        if (MainMod2.AutoLogin())
        {
            return;
        }
        if (waitToLogin)
        {
            tWaitToLogin++;
            if (tWaitToLogin == 50)
            {
                GameCanvas2.serverScreen.selectServer();
            }
            if (tWaitToLogin == 100)
            {
                GameCanvas2.loginScr ??= new LoginScr2();
                GameCanvas2.loginScr.doLogin();
                Service2.gI().finishUpdate();
                waitToLogin = false;
            }
        }
        if (flagServer > 0)
        {
            flagServer--;
            if (flagServer == 0)
            {
                GameCanvas2.endDlg();
            }
            if (testConnect == 2)
            {
                flagServer = 0;
                GameCanvas2.endDlg();
            }
        }
        if (flagServer <= 0 && isAutoConect)
        {
            countDieConnect++;
            if (countDieConnect > 100000)
            {
                countDieConnect = 0;
            }
        }
        for (int i = 0; i < cmd.Length; i++)
        {
            if (i == selected)
            {
                cmd[i].isFocus = true;
            }
            else
            {
                cmd[i].isFocus = false;
            }
        }
        GameScr2.cmx++;
        if (!loadScreen && (bigOk || percent == 100))
        {
            cmdDownload = null;
        }
        base.update();
        if (Char2.isLoadingMap || !loadScreen || !isAutoConect || GameCanvas2.currentScreen != this || testConnect == 2)
        {
            return;
        }
        if (MainMod2.isAutoLogin || countDieConnect < 5)
        {
            if (flagServer <= 0)
            {
                flagServer = MainMod2.isAutoLogin ? 120 : 30;
                GameCanvas2.startWaitDlg(mResources2.PLEASEWAIT);
                GameCanvas2.connect();
            }
        }
        else if (!Session_ME2_.gI().isConnected())
        {
            if (flagServer <= 0)
            {
                Command2 cmdYes = new(mResources2.YES, GameCanvas2.serverScreen, 18, null);
                Command2 cmdNo = new(mResources2.NO, GameCanvas2.serverScreen, 19, null);
                GameCanvas2.startYesNoDlg(mResources2.maychutathoacmatsong + ". " + mResources2.confirmChangeServer, cmdYes, cmdNo);
                flagServer = MainMod2.isAutoLogin ? 120 : 30;
            }
        }
        else if (flagServer <= 0)
        {
            countDieConnect = 0;
        }
    }

    private void processInput()
    {
        if (loadScreen)
        {
            center = new Command2(string.Empty, this, cmd[selected].idAction, null);
        }
        else
        {
            center = cmdDownload;
        }
    }

    public static void updateDeleteData()
    {
        if (cmdDeleteRMS != null && cmdDeleteRMS.isPointerPressInside())
        {
            cmdDeleteRMS.performAction();
        }
    }

    public override void updateKey()
    {
        if (GameCanvas2.isTouch)
        {
            updateDeleteData();
            if (!loadScreen)
            {
                if (cmdDownload != null && cmdDownload.isPointerPressInside())
                {
                    cmdDownload.performAction();
                }
                base.updateKey();
                return;
            }
            for (int i = 0; i < cmd.Length; i++)
            {
                if (cmd[i] == null || !cmd[i].isPointerPressInside())
                {
                    continue;
                }
                if (testConnect == -1 || testConnect == 0)
                {
                    if (cmd[i].caption.IndexOf(mResources2.server) != -1)
                    {
                        cmd[i].performAction();
                    }
                }
                else
                {
                    cmd[i].performAction();
                }
            }
        }
        else if (loadScreen)
        {
            if (GameCanvas2.keyPressed[8])
            {
                int num = ((mGraphics2.zoomLevel <= 1) ? 4 : 2);
                GameCanvas2.keyPressed[8] = false;
                selected++;
                if (selected > num)
                {
                    selected = 0;
                }
                processInput();
            }
            if (GameCanvas2.keyPressed[2])
            {
                int num2 = ((mGraphics2.zoomLevel <= 1) ? 4 : 2);
                GameCanvas2.keyPressed[2] = false;
                selected--;
                if (selected < 0)
                {
                    selected = num2;
                }
                processInput();
            }
        }
        if (!isWait)
        {
            base.updateKey();
        }
    }

    public static void SaveIP()
    {
        try
        {
            Rms2.saveRMSString("NRlink2", MainMod2.EncodeStringToByteArrayString(linkDefault, "6"));
            SplashScr2.loadIP();
        }
        catch (Exception)
        {
        }
    }

    public static void SaveIPNew(string ip)
    {
        try
        {
            Rms2.saveRMSString("NRlink2", MainMod2.EncodeStringToByteArrayString(ip, "6"));
            SplashScr2.loadIP();
        }
        catch (Exception)
        {
        }
    }

    public static bool allServerConnected()
    {
        for (int i = 0; i < 2; i++)
        {
            if (!hasConnected[i])
            {
                return false;
            }
        }
        return true;
    }

    public static void LoadIP()
    {
        string load = Rms2.loadRMSString("NRlink2");
        if (load == null || load.Length == 0)
        {
            GetServerList(linkDefault);
            return;
        }
        string ip = MainMod2.DecodeByteArrayString(load, "6");
        if (ip == null || ip.Length == 0)
        {
            GetServerList(linkDefault);
            return;
        }
        try
        {
            lengthServer = new int[3];
            mResources2.loadLanguague(mResources2.VIETNAM);
            string[] serverList = ip.Split(":0");
            int serverLength = serverList.Length - 1;

            nameServer = new string[serverLength];
            address = new string[serverLength];
            port = new short[serverLength];
            language = new sbyte[serverLength];

            for (int i = 0; i < serverLength; i++)
            {
                string[] comps = serverList[i].Trim(':').Trim(',').Split(':');

                nameServer[i] = comps[0];
                address[i] = comps[1];
                port[i] = short.Parse(comps[2]);
                language[i] = mResources2.VIETNAM;
                lengthServer[language[i]]++;
            }
            serverPriority = 0;
            SplashScr2.loadIP();
        }
        catch (Exception)
        {
            Rms2.saveRMSString("NRlink2", MainMod2.EncodeStringToByteArrayString(linkDefault, "6"));
        }
    }

    public override void switchToMe()
    {
        EffectManager2.remove();
        GameScr2.cmy = 0;
        GameScr2.cmx = 0;
        initCommand();
        isWait = false;
        GameCanvas2.loginScr = null;
        string text = Rms2.loadRMSString("ResVersion");
        int num = (text == null || !(text != string.Empty)) ? (-1) : int.Parse(text);
        if (num > 0)
        {
            loadScreen = true;
            GameCanvas2.loadBG(2);
        }
        bigOk = true;
        cmd[2 + nCmdPlay].caption = mResources2.server + ": " + nameServer[ipSelect];
        center = new Command2(string.Empty, this, cmd[selected].idAction, null);
        cmd[1 + nCmdPlay].caption = mResources2.change_account;
        if (cmd.Length == 5 + nCmdPlay)
        {
            cmd[4 + nCmdPlay].caption = mResources2.option;
        }
        Char2.isLoadingMap = false;
        MainMod2.startAutoItem = false;
        mSystem2.resetCurInapp();
        base.switchToMe();
    }

    public void switchToMe2()
    {
        GameScr2.cmy = 0;
        GameScr2.cmx = 0;
        initCommand();
        isWait = false;
        GameCanvas2.loginScr = null;
        string text = Rms2.loadRMSString("ResVersion");
        int num = (text == null || !(text != string.Empty)) ? (-1) : int.Parse(text);
        if (num > 0)
        {
            loadScreen = true;
            GameCanvas2.loadBG(2);
        }
        bigOk = true;
        cmd[2 + nCmdPlay].caption = mResources2.server + ": " + nameServer[ipSelect];
        center = new Command2(string.Empty, this, cmd[selected].idAction, null);
        cmd[1 + nCmdPlay].caption = mResources2.change_account;
        if (cmd.Length == 5 + nCmdPlay)
        {
            cmd[4 + nCmdPlay].caption = mResources2.option;
        }
        mSystem2.resetCurInapp();
        base.switchToMe();
    }

    public void connectOk()
    {
    }

    public void cancel()
    {
        if (GameCanvas2.serverScreen == null)
        {
            GameCanvas2.serverScreen = new ServerListScreen2();
        }
        demPercent = 0;
        percent = 0;
        stopDownload = true;
        GameCanvas2.serverScreen.show2();
        isGetData = false;
        cmdDownload.isFocus = true;
        center = new Command2(string.Empty, this, 2, null);
    }

    public void perform(int idAction, object p)
    {
        if (idAction == 1000)
        {
            GameCanvas2.connect();
        }
        else if (idAction == 1 || idAction == 4)
        {
            Session_ME2_.gI().close();
            isAutoConect = false;
            countDieConnect = 0;
            loadScreen = true;
            testConnect = 0;
            isGetData = false;
            Rms2.clearAll();
            switchToMe();
        }
        else if (idAction == 2)
        {
            stopDownload = false;
            cmdDownload = new Command2(mResources2.huy, this, 4, null);
            cmdDownload.x = GameCanvas2.w / 2 - mScreen2.cmdW / 2;
            cmdDownload.y = GameCanvas2.hh + 65;
            right = null;
            if (!GameCanvas2.isTouch)
            {
                cmdDownload.x = GameCanvas2.w / 2 - mScreen2.cmdW / 2;
                cmdDownload.y = GameCanvas2.h - mScreen2.cmdH - 1;
            }
            center = new Command2(string.Empty, this, 4, null);
            if (!isGetData)
            {
                Service2.gI().updateData();
                Service2.gI().getResource(1, null);
                if (!GameCanvas2.isTouch)
                {
                    cmdDownload.isFocus = true;
                    center = new Command2(string.Empty, this, 4, null);
                }
                isGetData = true;
            }
        }
        else if (idAction == 3)
        {
            GameCanvas2.loginScr ??= new LoginScr2();
            GameCanvas2.loginScr.switchToMe();
            bool flag = Rms2.loadRMSString("acc") != null && ((!Rms2.loadRMSString("acc").Equals(string.Empty)) ? true : false);
            bool flag2 = Rms2.loadRMSString("userAo" + ipSelect) != null && ((!Rms2.loadRMSString("userAo" + ipSelect).Equals(string.Empty)) ? true : false);
            if (!flag && !flag2)
            {
                GameCanvas2.connect();
                string text = Rms2.loadRMSString("userAo" + ipSelect);
                if (text == null || text.Equals(string.Empty))
                {
                    Service2.gI().login2(string.Empty);
                }
                else
                {
                    GameCanvas2.loginScr.isLogin2 = true;
                    GameCanvas2.connect();
                    Service2.gI().setClientType();
                    Service2.gI().login(text, string.Empty, GameMidlet2.VERSION, 1);
                }
                if (Session_ME2_.connected)
                {
                    GameCanvas2.startWaitDlg();
                }
                else
                {
                    GameCanvas2.startOKDlg(mResources2.maychutathoacmatsong);
                }
            }
            else
            {
                GameCanvas2.loginScr.doLogin();
            }
            LoginScr2.serverName = nameServer[ipSelect];
        }
        else if (idAction == 10100)
        {
            if (GameCanvas2.loginScr == null)
            {
                GameCanvas2.loginScr = new LoginScr2();
            }
            GameCanvas2.loginScr.switchToMe();
            GameCanvas2.connect();
            Service2.gI().login2(string.Empty);
            GameCanvas2.startWaitDlg();
            LoginScr2.serverName = nameServer[ipSelect];
        }
        else if (idAction == 5)
        {
            doUpdateServer();
            if (nameServer.Length == 1)
            {
                return;
            }
            MyVector2 myVector = new MyVector2(string.Empty);
            for (int i = 0; i < nameServer.Length; i++)
            {
                myVector.addElement(new Command2(nameServer[i], this, 6, null));
            }
            GameCanvas2.menu.startAt(myVector, 0);
            if (!GameCanvas2.isTouch)
            {
                GameCanvas2.menu.menuSelectedItem = ipSelect;
            }
        }
        else if (idAction == 6)
        {
            ipSelect = GameCanvas2.menu.menuSelectedItem;
            selectServer();
        }
        else if (idAction == 7)
        {
            if (GameCanvas2.loginScr == null)
            {
                GameCanvas2.loginScr = new LoginScr2();
            }
            GameCanvas2.loginScr.switchToMe();
        }
        else if (idAction == 8)
        {
            bool lowGraphic = Rms2.loadRMSInt("lowGraphic") == 1;
            MyVector2 myVector2 = new MyVector2("cau hinh");
            myVector2.addElement(new Command2(mResources2.cauhinhthap, this, 9, null));
            myVector2.addElement(new Command2(mResources2.cauhinhcao, this, 10, null));
            GameCanvas2.menu.startAt(myVector2, 0);
            if (lowGraphic)
            {
                GameCanvas2.menu.menuSelectedItem = 0;
            }
            else
            {
                GameCanvas2.menu.menuSelectedItem = 1;
            }
        }
        else if (idAction == 9)
        {
            Rms2.saveRMSInt("lowGraphic", 1);
            GameCanvas2.startOK(mResources2.plsRestartGame, 8885, null);
        }
        else if (idAction == 10)
        {
            Rms2.saveRMSInt("lowGraphic", 0);
            GameCanvas2.startOK(mResources2.plsRestartGame, 8885, null);
        }
        else if (idAction == 11)
        {
            if (GameCanvas2.loginScr == null)
            {
                GameCanvas2.loginScr = new LoginScr2();
            }
            GameCanvas2.loginScr.switchToMe();
            string text2 = Rms2.loadRMSString("userAo" + ipSelect);
            if (text2 == null || text2.Equals(string.Empty))
            {
                Service2.gI().login2(string.Empty);
            }
            else
            {
                GameCanvas2.loginScr.isLogin2 = true;
                GameCanvas2.connect();
                Service2.gI().setClientType();
                Service2.gI().login(text2, string.Empty, GameMidlet2.VERSION, 1);
            }
            GameCanvas2.startWaitDlg(mResources2.PLEASEWAIT);
        }
        else if (idAction == 12)
        {
            GameMidlet2.instance.exit();
        }
        else if (idAction == 13 && (!isGetData || loadScreen))
        {
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
            }
        }
        else if (idAction == 14)
        {
            Command2 cmdYes = new Command2(mResources2.YES, GameCanvas2.serverScreen, 15, null);
            Command2 cmdNo = new Command2(mResources2.NO, GameCanvas2.serverScreen, 16, null);
            GameCanvas2.startYesNoDlg(mResources2.deletaDataNote, cmdYes, cmdNo);
        }
        else if (idAction == 15)
        {
            Rms2.clearAll();
            GameCanvas2.startOK(mResources2.plsRestartGame, 8885, null);
        }
        else if (idAction == 16)
        {
            InfoDlg2.hide();
            GameCanvas2.currentDialog = null;
        }
        else if (idAction == 17)
        {
            if (GameCanvas2.serverScr == null)
            {
                GameCanvas2.serverScr = new ServerScr2();
            }
            GameCanvas2.serverScr.switchToMe();
        }
        else if (idAction == 18)
        {
            GameCanvas2.endDlg();
            InfoDlg2.hide();
            if (GameCanvas2.serverScr == null)
            {
                GameCanvas2.serverScr = new ServerScr2();
            }
            GameCanvas2.serverScr.switchToMe();
        }
        else if (idAction == 19)
        {
            if (mSystem2.clientType == 1)
            {
                InfoDlg2.hide();
                GameCanvas2.currentDialog = null;
            }
            else
            {
                countDieConnect = 0;
                testConnect = 0;
                isAutoConect = true;
            }
        }
    }

    public void init()
    {
        if (!loadScreen)
        {
            cmdDownload = new Command2(mResources2.taidulieu, this, 2, null);
            cmdDownload.isFocus = true;
            cmdDownload.x = GameCanvas2.w / 2 - cmdW / 2;
            cmdDownload.y = GameCanvas2.hh + 45;
            if (cmdDownload.y > GameCanvas2.h - 26)
            {
                cmdDownload.y = GameCanvas2.h - 26;
            }
            cmdDownload.performAction();
        }
        if (!GameCanvas2.isTouch)
        {
            selected = 0;
            processInput();
        }
    }

    public void show2()
    {
        GameScr2.cmx = 0;
        GameScr2.cmy = 0;
        initCommand();
        loadScreen = false;
        percent = 0;
        bigOk = false;
        isGetData = false;
        p = 0;
        demPercent = 0;
        strWait = mResources2.PLEASEWAIT;
        Char2.isLoadingMap = false;
        init();
        base.switchToMe();
    }
}
