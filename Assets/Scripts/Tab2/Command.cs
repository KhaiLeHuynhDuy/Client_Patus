public class Command2
{
    public bool isDisplay;

    public ActionChat2 actionChat;

    public string caption;

    public string[] subCaption;

    public IActionListener2 actionListener;

    public int idAction;

    public bool isPlaySoundButton = true;

    public Image2 img;

    public Image2 imgFocus;

    public int x;

    public int y;

    public int w = mScreen2.cmdW;

    public int h = mScreen2.cmdH;

    public int hw;

    private int lenCaption;

    public bool isFocus;

    public object p;

    public int type;

    public string caption2 = string.Empty;

    public static Image2 btn0left;

    public static Image2 btn0mid;

    public static Image2 btn0right;

    public static Image2 btn1left;

    public static Image2 btn1mid;

    public static Image2 btn1right;

    public bool cmdClosePanel;

    public Command2(string caption, IActionListener2 actionListener, int action, object p, int x, int y)
    {
        this.caption = caption;
        idAction = action;
        this.actionListener = actionListener;
        this.p = p;
        this.x = x;
        this.y = y;
    }

    public Command2()
    {
    }

    public Command2(string caption, IActionListener2 actionListener, int action, object p)
    {
        this.caption = caption;
        idAction = action;
        this.actionListener = actionListener;
        this.p = p;
    }

    public Command2(string caption, int action, object p)
    {
        this.caption = caption;
        idAction = action;
        this.p = p;
    }

    public Command2(string caption, int action)
    {
        this.caption = caption;
        idAction = action;
    }

    public Command2(string caption, int action, int x, int y)
    {
        this.caption = caption;
        idAction = action;
        this.x = x;
        this.y = y;
    }

    public void perform(string str)
    {
        if (actionChat != null)
        {
            actionChat(str);
        }
    }

    public void performAction()
    {
        GameCanvas2.clearAllPointerEvent();
        if (isPlaySoundButton && ((caption != null && !caption.Equals(string.Empty) && !caption.Equals(mResources2.saying)) || img != null))
        {
            SoundMn2.gI().buttonClick();
        }
        if (idAction > 0)
        {
            if (actionListener != null)
            {
                actionListener.perform(idAction, p);
            }
            else
            {
                GameScr2.gI().actionPerform(idAction, p);
            }
        }
    }

    public void setType()
    {
        type = 1;
        w = 160;
        hw = 80;
    }

    public void setTypeDelete()
    {
        type = 2;
        w = 50;
        hw = 28;
    }

    public void paint(mGraphics2 g)
    {
        if (img != null)
        {
            g.drawImage(img, x, y + mGraphics2.addYWhenOpenKeyBoard, 0);
            if (isFocus)
            {
                if (imgFocus == null)
                {
                    if (cmdClosePanel)
                    {
                        g.drawImage(ItemMap2.imageFlare, x + 8, y + mGraphics2.addYWhenOpenKeyBoard + 8, 3);
                    }
                    else
                    {
                        g.drawImage(ItemMap2.imageFlare, x - (img.Equals(GameScr2.imgMenu) ? 10 : 0), y + mGraphics2.addYWhenOpenKeyBoard, 0);
                    }
                }
                else
                {
                    g.drawImage(imgFocus, x, y + mGraphics2.addYWhenOpenKeyBoard, 0);
                }
            }
            if (caption != "menu" && caption != null)
            {
                if (!isFocus)
                {
                    mFont2.tahoma_7b_dark.drawString(g, caption, x + mGraphics2.getImageWidth(img) / 2, y + mGraphics2.getImageHeight(img) / 2 - 5, 2);
                }
                else
                {
                    mFont2.tahoma_7b_green2.drawString(g, caption, x + mGraphics2.getImageWidth(img) / 2, y + mGraphics2.getImageHeight(img) / 2 - 5, 2);
                }
            }
            return;
        }
        if (caption != string.Empty)
        {
            if (type == 1)
            {
                if (!isFocus)
                {
                    paintOngMau(btn0left, btn0mid, btn0right, x, y, 160, g);
                }
                else
                {
                    paintOngMau(btn1left, btn1mid, btn1right, x, y, 160, g);
                }
            }
            else if (type == 2)
            {
                if (!isFocus)
                {
                    paintOngMau(btn0left, btn0mid, btn0right, x, y, w, g);
                }
                else
                {
                    paintOngMau(btn1left, btn1mid, btn1right, x, y, w, g);
                }
            }
            else if (!isFocus)
            {
                paintOngMau(btn0left, btn0mid, btn0right, x, y, 76, g);
            }
            else
            {
                paintOngMau(btn1left, btn1mid, btn1right, x, y, 76, g);
            }
        }
        int num = (type != 1 && type != 2) ? (x + 38) : (x + hw);
        if (!isFocus)
        {
            mFont2.tahoma_7b_dark.drawString(g, caption, num, y + 7, 2);
        }
        else
        {
            mFont2.tahoma_7b_green2.drawString(g, caption, num, y + 7, 2);
        }
    }

    public static void paintOngMau(Image2 img0, Image2 img1, Image2 img2, int x, int y, int size, mGraphics2 g)
    {
        for (int i = 10; i <= size - 20; i += 10)
        {
            g.drawImage(img1, x + i, y, 0);
        }
        int num = size % 10;
        if (num > 0)
        {
            g.drawRegion(img1, 0, 0, num, 24, 0, x + size - 10 - num, y, 0);
        }
        g.drawImage(img0, x, y, 0);
        g.drawImage(img2, x + size - 10, y, 0);
    }

    public bool isPointerPressInside()
    {
        isFocus = false;
        if (GameCanvas2.isPointerHoldIn(x, y, w, h))
        {
            if (GameCanvas2.isPointerDown)
            {
                isFocus = true;
            }
            if (GameCanvas2.isPointerJustRelease && GameCanvas2.isPointerClick)
            {
                return true;
            }
        }
        return false;
    }

    public bool isPointerPressInsideCamera(int cmx, int cmy)
    {
        isFocus = false;
        if (GameCanvas2.isPointerHoldIn(x - cmx, y - cmy, w, h))
        {
            if (GameCanvas2.isPointerDown)
            {
                isFocus = true;
            }
            if (GameCanvas2.isPointerJustRelease && GameCanvas2.isPointerClick)
            {
                return true;
            }
        }
        return false;
    }
}
