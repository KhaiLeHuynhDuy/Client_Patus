public class RegisterScreen2 : mScreen2, IActionListener2
{
    public TField2 tfPassword;

    public TField2 tfUsername;

    public TField2 tfMaGioiThieu;

    private int focus;

    private readonly Command2 cmdExit;

    private readonly Command2 cmdOK;

    public static string serverName;

    public static Image2 imgTitle;

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

    private int xLog;

    private int yLog;

    private readonly int v = 2;

    private int g;

    private int ylogo = -40;

    private int dir = 1;

    public RegisterScreen2()
    {
        yLog = 130;
        TileMap2.bgID = (sbyte)(mSystem2.currentTimeMillis() % 9);
        if (TileMap2.bgID == 5 || TileMap2.bgID == 6)
        {
            TileMap2.bgID = 4;
        }
        GameScr2.loadCamera(fullmScreen: true, -1, -1);
        GameScr2.cmx = 100;
        GameScr2.cmy = 200;

        tfUsername = new TField2
        {
            width = 220,
            height = ITEM_HEIGHT + 2,
            name = "Tên tài khoản",
            isFocus = true
        };

        tfPassword = new TField2
        {
            width = 220,
            height = ITEM_HEIGHT + 2,
            name = "Mật khẩu"
        };
        tfPassword.setIputType(TField2.INPUT_TYPE_PASSWORD);

        tfMaGioiThieu = new TField2
        {
            width = 220,
            height = ITEM_HEIGHT + 2,
            name = "Mã giới thiệu"
        };

        focus = 0;
        int num = 4;
        int num2 = num * 32 + 23 + 33;
        if (num2 >= GameCanvas2.w)
        {
            num--;
            num2 = num * 32 + 23 + 33;
        }
        xLog = GameCanvas2.w / 2 - num2 / 2;
        yLog = 5;
        lY = ((GameCanvas2.w < 200) ? (tfPassword.y - 30) : (yLog - 30));
        tfPassword.x = xLog + 10;
        tfPassword.y = yLog + 20;
        cmdOK = new Command2(mResources2.OK, this, 2008, null)
        {
            x = GameCanvas2.w / 2 - 40,
            y = GameCanvas2.h - 70
        };
        cmdExit = new Command2("Thoát", this, 1003, null)
        {
            x = GameCanvas2.w / 2 - 40,
            y = GameCanvas2.h - 40
        };
        if (GameCanvas2.w < 250)
        {
            cmdOK.x = GameCanvas2.w / 2 - 80;
            cmdExit.x = GameCanvas2.w / 2 + 10;
            cmdExit.y = (cmdOK.y = GameCanvas2.h - 25);
        }
        center = cmdOK;
        left = cmdExit;
        // imgTitle = MainMod2.imgLogoBig;
    }

    public new void switchToMe()
    {
        SoundMn2.gI().stopAll();
        focus = 0;
        if (GameCanvas2.isTouch)
        {
            tfUsername.isFocus = false;
            focus = -1;
        }
        base.switchToMe();
    }

    protected int loadIndexServer()
    {
        return Rms2.loadRMSInt("indServer");
    }

    public override void update()
    {
        tfPassword.update();
        tfUsername.update();
        tfMaGioiThieu.update();

        for (int i = 0; i < Effect2_2.vEffect2.size(); i++)
        {
            Effect2_2 effect = (Effect2_2)Effect2_2.vEffect2.elementAt(i);
            effect.update();
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
    }

    public override void keyPress(int keyCode)
    {
        if (tfPassword.isFocus)
        {
            tfPassword.keyPressed(keyCode);
        }
        else if (tfUsername.isFocus)
        {
            tfUsername.keyPressed(keyCode);
        }
        else if (tfMaGioiThieu.isFocus)
        {
            tfMaGioiThieu.keyPressed(keyCode);
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
        if (ChatPopup2.currChatPopup != null || ChatPopup2.serverChatPopUp != null)
        {
            return;
        }
        if (GameCanvas2.currentDialog == null)
        {
            xLog = (GameCanvas2.w - tfUsername.width) / 2 - 10;
            int num2 = tfUsername.height * 3 + 50;
            if (GameCanvas2.w < 260)
            {
                xLog = (GameCanvas2.w - 240) / 2;
            }
            yLog = (GameCanvas2.h - num2) / 2;

            PopUp2.paintPopUp(g, xLog, yLog, 240, num2, -1, isButton: true);
            if (GameCanvas2.h > 160 && imgTitle != null)
            {
                g.drawImage(imgTitle, GameCanvas2.hw, tfUsername.y - 40, 3);
            }

            tfUsername.x = xLog + 10;
            tfUsername.y = yLog + 15;
            tfPassword.x = tfUsername.x;
            tfPassword.y = tfUsername.y + 30;
            tfMaGioiThieu.x = tfPassword.x;
            tfMaGioiThieu.y = tfPassword.y + 30;

            tfPassword.paint(g);
            tfUsername.paint(g);
            tfMaGioiThieu.paint(g);

            if (GameCanvas2.w < 176)
            {
                mFont2.tahoma_7b_green2.drawString(g, mResources2.acc + ":", tfUsername.x - 35, tfUsername.y + 7, 0);
                mFont2.tahoma_7b_green2.drawString(g, mResources2.pwd + ":", tfPassword.x - 35, tfPassword.y + 7, 0);
                mFont2.tahoma_7b_green2.drawString(g, mResources2.server + ": " + serverName, GameCanvas2.w / 2, tfPassword.y + 32, 2);
            }
        }
        g.setColor(GameCanvas2.skyColor);
        g.fillRect(GameCanvas2.w - 40, 4, 36, 11);
        GameCanvas2.resetTrans(g);
        base.paint(g);
    }

    private void turnOffFocus()
    {
        tfPassword.isFocus = false;
        tfUsername.isFocus = false;
        tfMaGioiThieu.isFocus = false;
    }

    private void processFocus()
    {
        turnOffFocus();
        switch (focus)
        {
            case 0:
                tfUsername.isFocus = true;
                break;
            case 1:
                tfPassword.isFocus = true;
                break;
            case 2:
                tfMaGioiThieu.isFocus = true;
                break;
        }
    }

    public override void updateKey()
    {
        if (!GameCanvas2.isTouch)
        {
            if (tfPassword.isFocus)
            {
                right = tfPassword.cmdClear;
            }
            else if (tfUsername.isFocus)
            {
                right = tfUsername.cmdClear;
            }
            else if (tfMaGioiThieu.isFocus)
            {
                right = tfMaGioiThieu.cmdClear;
            }
        }
        if (GameCanvas2.keyPressed[21])
        {
            focus--;
            if (focus < 0)
            {
                focus = 2;
            }
            processFocus();
        }
        else if (GameCanvas2.keyPressed[22])
        {
            focus++;
            if (focus > 2)
            {
                focus = 0;
            }
            processFocus();
        }
        if (GameCanvas2.keyPressed[21] || GameCanvas2.keyPressed[22])
        {
            GameCanvas2.clearKeyPressed();
            if (focus == 1)
            {
                tfUsername.isFocus = false;
                tfPassword.isFocus = true;
            }
            else if (focus == 0)
            {
                tfUsername.isFocus = true;
                tfPassword.isFocus = false;
            }
            else
            {
                tfUsername.isFocus = false;
                tfPassword.isFocus = false;
            }
        }
        if (GameCanvas2.isPointerJustRelease)
        {
            if (GameCanvas2.isPointerHoldIn(tfPassword.x, tfPassword.y, tfPassword.width, tfPassword.height))
            {
                focus = 1;
                processFocus();
            }
            else if (GameCanvas2.isPointerHoldIn(tfUsername.x, tfUsername.y, tfUsername.width, tfUsername.height))
            {
                focus = 0;
                processFocus();
            }
            else if (GameCanvas2.isPointerHoldIn(tfMaGioiThieu.x, tfMaGioiThieu.y, tfMaGioiThieu.width, tfMaGioiThieu.height))
            {
                focus = 2;
                processFocus();
            }
        }
        base.updateKey();
        GameCanvas2.clearKeyPressed();
    }

    public void perform(int idAction, object p)
    {
        switch (idAction)
        {
            case 1003:
                GameCanvas2.serverScreen.switchToMe();
                break;
            case 2008:
                if (tfUsername.getText().Equals(string.Empty) || tfPassword.getText().Equals(string.Empty))
                {
                    GameCanvas2.startOKDlg("Vui lòng điền đầy đủ thông tin");
                    break;
                }
                GameCanvas2.startOKDlg(mResources2.PLEASEWAIT);
                Service2.gI().charInfo("1", "1", "1", "1", "1", "1", tfMaGioiThieu.getText().Length > 0 ? tfMaGioiThieu.getText() : "-1", tfUsername.getText(), tfPassword.getText());
                break;
        }
    }
}