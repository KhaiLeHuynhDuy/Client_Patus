public class ClientInput2 : mScreen2, IActionListener2
{
    public static ClientInput2 instance;

    public TField2[] tf;

    private int x;

    private int y;

    private int w;

    private int h;

    private string[] strPaint;

    private int focus;

    private int nTf;

    private void init(string t)
    {
        w = GameCanvas2.w - 20;
        if (w > 320)
        {
            w = 320;
        }
        strPaint = mFont2.tahoma_7b_dark.splitFontArray(t, w - 20);
        x = (GameCanvas2.w - w) / 2;
        tf = new TField2[nTf];
        h = tf.Length * 35 + (strPaint.Length - 1) * 20 + 40;
        y = GameCanvas2.h - h - 40 - (strPaint.Length - 1) * 20;
        for (int i = 0; i < tf.Length; i++)
        {
            tf[i] = new TField2();
            tf[i].name = string.Empty;
            tf[i].x = x + 10;
            tf[i].y = y + 35 + (strPaint.Length - 1) * 20 + i * 35;
            tf[i].width = w - 20;
            tf[i].height = mScreen2.ITEM_HEIGHT + 2;
            if (GameCanvas2.isTouch)
            {
                tf[0].isFocus = false;
            }
            else
            {
                tf[0].isFocus = true;
            }
            if (!GameCanvas2.isTouch)
            {
                right = tf[0].cmdClear;
            }
        }
        left = new Command2(mResources2.CLOSE, this, 1, null);
        center = new Command2(mResources2.OK, this, 2, null);
        if (GameCanvas2.isTouch)
        {
            center.x = GameCanvas2.w / 2 + 18;
            left.x = GameCanvas2.w / 2 - 85;
            center.y = (left.y = y + h + 5);
        }
    }

    public static ClientInput2 gI()
    {
        if (instance == null)
        {
            instance = new ClientInput2();
        }
        return instance;
    }

    public override void switchToMe()
    {
        focus = 0;
        base.switchToMe();
    }

    public void setInput(int type, string title)
    {
        nTf = type;
        init(title);
        switchToMe();
    }

    public override void paint(mGraphics2 g)
    {
        GameScr2.gI().paint(g);
        PopUp2.paintPopUp(g, x, y, w, h, -1, isButton: true);
        for (int i = 0; i < strPaint.Length; i++)
        {
            mFont2.tahoma_7b_green2.drawString(g, strPaint[i], GameCanvas2.w / 2, y + 15 + i * 20, mFont2.CENTER);
        }
        for (int j = 0; j < tf.Length; j++)
        {
            tf[j].paint(g);
        }
        base.paint(g);
    }

    public override void update()
    {
        GameScr2.gI().update();
        for (int i = 0; i < tf.Length; i++)
        {
            tf[i].update();
        }
    }

    public override void keyPress(int keyCode)
    {
        for (int i = 0; i < tf.Length; i++)
        {
            if (tf[i].isFocus)
            {
                tf[i].keyPressed(keyCode);
                break;
            }
        }
        base.keyPress(keyCode);
    }

    public override void updateKey()
    {
        if (GameCanvas2.keyPressed[2])
        {
            focus--;
            if (focus < 0)
            {
                focus = tf.Length - 1;
            }
        }
        else if (GameCanvas2.keyPressed[8])
        {
            focus++;
            if (focus > tf.Length - 1)
            {
                focus = 0;
            }
        }
        if (GameCanvas2.keyPressed[2] || GameCanvas2.keyPressed[8])
        {
            GameCanvas2.clearKeyPressed();
            for (int i = 0; i < tf.Length; i++)
            {
                if (focus == i)
                {
                    tf[i].isFocus = true;
                    if (!GameCanvas2.isTouch)
                    {
                        right = tf[i].cmdClear;
                    }
                }
                else
                {
                    tf[i].isFocus = false;
                }
                if (GameCanvas2.isPointerJustRelease && GameCanvas2.isPointerHoldIn(tf[i].x, tf[i].y, tf[i].width, tf[i].height))
                {
                    focus = i;
                    break;
                }
            }
        }
        base.updateKey();
        GameCanvas2.clearKeyPressed();
    }

    public void clearScreen()
    {
        instance = null;
    }

    public void perform(int idAction, object p)
    {
        if (idAction == 1)
        {
            GameScr2.instance.switchToMe();
            clearScreen();
        }
        if (idAction != 2)
        {
            return;
        }
        for (int i = 0; i < tf.Length; i++)
        {
            if (tf[i].getText() == null || tf[i].getText().Equals(string.Empty))
            {
                GameCanvas2.startOKDlg(mResources2.vuilongnhapduthongtin);
                return;
            }
        }
        Service2.gI().sendClientInput(tf);
        GameScr2.instance.switchToMe();
    }
}

