public class ChatTextField2 : IActionListener2
{
    private static ChatTextField2 instance;

    public TField2 tfChat;

    public bool isShow;

    public IChatable2 parentScreen;

    private long lastChatTime;

    public Command2 left;

    public Command2 cmdChat;

    public Command2 right;

    public Command2 center;

    private int x;

    private int y;

    private int w;

    private int h;

    public Command2 cmdChat2;

    public int yBegin;

    public int yUp;

    public int KC;

    public string to;

    public string strChat = "Chat ";

    public ChatTextField2()
    {
        tfChat = new TField2();
        if (Main2.isWindowsPhone)
        {
            tfChat.showSubTextField = false;
        }
        if (Main2.isIPhone)
        {
            tfChat.isPaintMouse = false;
        }
        tfChat.name = "chat";
        if (Main2.isWindowsPhone)
        {
            tfChat.strInfo = tfChat.name;
        }
        tfChat.width = GameCanvas2.w - 6;
        if (Main2.isPC && tfChat.width > 250)
        {
            tfChat.width = 250;
        }
        tfChat.height = mScreen2.ITEM_HEIGHT + 2;
        tfChat.x = GameCanvas2.w / 2 - tfChat.width / 2;
        tfChat.isFocus = true;
        tfChat.setMaxTextLenght(80);
    }

    public void initChatTextField()
    {
        left = new Command2(mResources2.OK, this, 8000, null, 1, GameCanvas2.h - mScreen2.cmdH + 1);
        right = new Command2(mResources2.DELETE, this, 8001, null, GameCanvas2.w - 70, GameCanvas2.h - mScreen2.cmdH + 1);
        center = null;
        w = tfChat.width + 20;
        h = tfChat.height + 26;
        x = GameCanvas2.w / 2 - w / 2;
        y = tfChat.y - 18;
        if (Main2.isPC && w > 320)
        {
            w = 320;
        }
        left.x = x;
        right.x = x + w - 68;
        if (GameCanvas2.isTouch)
        {
            tfChat.y -= 5;
            y -= 20;
            h += 30;
            left.x = GameCanvas2.w / 2 - 68 - 5;
            right.x = GameCanvas2.w / 2 + 5;
            left.y = GameCanvas2.h - 30;
            right.y = GameCanvas2.h - 30;
        }
        cmdChat = new Command2();
        void actionChat(string str)
        {
            tfChat.justReturnFromTextBox = false;
            tfChat.setText(str);
            parentScreen.onChatFromMe(str, to);
            tfChat.setText(string.Empty);
            right.caption = mResources2.CLOSE;
        }
        cmdChat.actionChat = actionChat;
        cmdChat2 = new Command2
        {
            actionChat = delegate (string str)
            {
                tfChat.justReturnFromTextBox = false;
                if (parentScreen != null)
                {
                    tfChat.setText(str);
                    parentScreen.onChatFromMe(str, to);
                    tfChat.setText(string.Empty);
                    tfChat.clearKb();
                    if (right != null)
                    {
                        right.performAction();
                    }
                }
                isShow = false;
            }
        };
        yBegin = tfChat.y;
        yUp = GameCanvas2.h / 2 - 2 * tfChat.height;
        if (Main2.isWindowsPhone)
        {
            tfChat.showSubTextField = false;
        }
        if (Main2.isIPhone)
        {
            tfChat.isPaintMouse = false;
        }
    }

    public void updateWhenKeyBoardVisible()
    {
    }

    public void keyPressed(int keyCode)
    {
        if (isShow)
        {
            tfChat.keyPressed(keyCode);
        }
        if (tfChat.getText().Equals(string.Empty))
        {
            right.caption = mResources2.CLOSE;
        }
        else
        {
            right.caption = mResources2.DELETE;
        }
    }

    public static ChatTextField2 gI()
    {
        return instance ??= new ChatTextField2();
    }

    public void startChat(int firstCharacter, IChatable2 parentScreen, string to)
    {
        right.caption = mResources2.CLOSE;
        this.to = to;
        if (Main2.isWindowsPhone)
        {
            tfChat.showSubTextField = false;
        }
        if (Main2.isIPhone)
        {
            tfChat.isPaintMouse = false;
        }
        tfChat.keyPressed(firstCharacter);
        if (!tfChat.getText().Equals(string.Empty) && GameCanvas2.currentDialog == null)
        {
            this.parentScreen = parentScreen;
            isShow = true;
        }
    }

    public void startChat(IChatable2 parentScreen, string to)
    {
        right.caption = mResources2.CLOSE;
        this.to = to;
        this.parentScreen = parentScreen;
        if (Main2.isIPhone)
        {
            tfChat.isPaintMouse = false;
        }
        if (GameCanvas2.currentDialog == null)
        {
            isShow = true;
            tfChat.isFocus = true;
            if (Main2.isIPhone)
            {
                tfChat.setFocusWithKb(isFocus: true);
            }
        }
        tfChat.setText(string.Empty);
        tfChat.clearAll();
    }

    //public void startChat2(IChatable parentScreen, string to)
    //{
    //	tfChat.setFocusWithKb(isFocus: true);
    //	this.to = to;
    //	this.parentScreen = parentScreen;
    //	if (Main.isIPhone)
    //	{
    //		tfChat.isPaintMouse = false;
    //	}
    //	if (GameCanvas.currentDialog == null)
    //	{
    //		isShow = true;
    //		if (!Main.isPC)
    //		{
    //			ipKeyboard.openKeyBoard(strChat, ipKeyboard.TEXT, string.Empty, cmdChat2);
    //			tfChat.setFocusWithKb(isFocus: true);
    //		}
    //	}
    //	tfChat.setText(string.Empty);
    //	tfChat.clearAll();
    //	isPublic = false;
    //}

    public void update()
    {
        if (!isShow)
        {
            return;
        }
        tfChat.update();
        if (Main2.isWindowsPhone)
        {
            updateWhenKeyBoardVisible();
        }
        if (tfChat.justReturnFromTextBox)
        {
            tfChat.justReturnFromTextBox = false;
            parentScreen.onChatFromMe(tfChat.getText(), to);
            tfChat.setText(string.Empty);
            right.caption = mResources2.CLOSE;
        }
        if (!Main2.isPC)
        {
            return;
        }
        if (GameCanvas2.keyPressed[15])
        {
            if (left != null && tfChat.getText() != string.Empty)
            {
                left.performAction();
            }
            GameCanvas2.keyPressed[15] = false;
            GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
        }
        if (GameCanvas2.keyPressed[14])
        {
            if (right != null)
            {
                right.performAction();
            }
            GameCanvas2.keyPressed[14] = false;
        }
    }

    public void close()
    {
        tfChat.setText(string.Empty);
        isShow = false;
    }

    public void paint(mGraphics2 g)
    {
        if (isShow)
        {
            int num = (!Main2.isWindowsPhone) ? (y - KC) : (tfChat.y - 5);
            int num2 = (!Main2.isWindowsPhone) ? x : 0;
            int num3 = (!Main2.isWindowsPhone) ? w : GameCanvas2.w;
            PopUp2.paintPopUp(g, num2, num, num3, h, -1, isButton: true);
            if (Main2.isPC)
            {
                mFont2.tahoma_7b_green2.drawString(g, strChat + to, tfChat.x, tfChat.y - ((!GameCanvas2.isTouch) ? 12 : 17), 0);
                GameCanvas2.paintz.paintCmdBar(g, left, center, right);
            }
            tfChat.paint(g);
        }
    }

    public void perform(int idAction, object p)
    {
        switch (idAction)
        {
            case 8000:
                if (parentScreen != null)
                {
                    long num = mSystem2.currentTimeMillis();
                    if (num - lastChatTime >= 1000)
                    {
                        lastChatTime = num;
                        parentScreen.onChatFromMe(tfChat.getText(), to);
                        tfChat.setText(string.Empty);
                        right.caption = mResources2.CLOSE;
                        tfChat.clearKb();
                    }
                }
                break;
            case 8001:
                if (tfChat.getText().Equals(string.Empty))
                {
                    isShow = false;
                    if (strChat == "Nhập tốc độ game" || strChat == "Tăng đến mức" || strChat == "% HP" || strChat == "% MP")
                    {
                        strChat = "Chat";
                        tfChat.name = "chat";
                        tfChat.setIputType(TField2.INPUT_TYPE_ANY);
                    }
                    parentScreen.onCancelChat();
                }
                tfChat.clear();
                break;
            case 8002:
                break;
        }
    }
}
