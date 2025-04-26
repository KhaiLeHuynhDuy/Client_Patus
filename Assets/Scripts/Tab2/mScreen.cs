public class mScreen2
{
	public Command2 left;

	public Command2 center;

	public Command2 right;

	public Command2 cmdClose;

	public static int ITEM_HEIGHT;

	public static int yOpenKeyBoard = 100;

	public static int cmdW = 68;

	public static int cmdH = 26;

	public static int keyTouch = -1;

	public static int keyMouse = -1;

	public virtual void switchToMe()
	{
		GameCanvas2.clearKeyPressed();
		GameCanvas2.clearKeyHold();
		if (GameCanvas2.currentScreen != null)
		{
			GameCanvas2.currentScreen.unLoad();
		}
		GameCanvas2.currentScreen = this;
	}

	public virtual void unLoad()
	{
	}

	public static void initPos()
	{
	}

	public virtual void keyPress(int keyCode)
	{
	}

	public virtual void update()
	{
	}

	public virtual void updateKey()
	{
		if (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] || getCmdPointerLast(GameCanvas2.currentScreen.center))
		{
			GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
			keyTouch = -1;
			GameCanvas2.isPointerJustRelease = false;
			if (center != null)
			{
				center.performAction();
			}
		}
		if (GameCanvas2.keyPressed[12] || getCmdPointerLast(GameCanvas2.currentScreen.left))
		{
			GameCanvas2.keyPressed[12] = false;
			keyTouch = -1;
			GameCanvas2.isPointerJustRelease = false;
			if (ChatTextField2.gI().isShow)
			{
				if (ChatTextField2.gI().left != null)
				{
					ChatTextField2.gI().left.performAction();
				}
			}
			else if (left != null)
			{
				left.performAction();
			}
		}
		if (!GameCanvas2.keyPressed[13] && !getCmdPointerLast(GameCanvas2.currentScreen.right))
		{
			return;
		}
		GameCanvas2.keyPressed[13] = false;
		keyTouch = -1;
		GameCanvas2.isPointerJustRelease = false;
		if (ChatTextField2.gI().isShow)
		{
			if (ChatTextField2.gI().right != null)
			{
				ChatTextField2.gI().right.performAction();
			}
		}
		else if (right != null)
		{
			right.performAction();
		}
	}

	public static bool getCmdPointerLast(Command2 cmd)
	{
		if (cmd == null)
		{
			return false;
		}
		if (cmd.x >= 0 && cmd.y != 0)
		{
			return cmd.isPointerPressInside();
		}
		if (GameCanvas2.currentDialog != null)
		{
			if (GameCanvas2.currentDialog.center != null && GameCanvas2.isPointerHoldIn(GameCanvas2.w - cmdW >> 1, GameCanvas2.h - cmdH - 5, cmdW, cmdH + 10))
			{
				keyTouch = 1;
				if (cmd == GameCanvas2.currentDialog.center && GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
				{
					return true;
				}
			}
			if (GameCanvas2.currentDialog.left != null && GameCanvas2.isPointerHoldIn(0, GameCanvas2.h - cmdH - 5, cmdW, cmdH + 10))
			{
				keyTouch = 0;
				if (cmd == GameCanvas2.currentDialog.left && GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
				{
					return true;
				}
			}
			if (GameCanvas2.currentDialog.right != null && GameCanvas2.isPointerHoldIn(GameCanvas2.w - cmdW, GameCanvas2.h - cmdH - 5, cmdW, cmdH + 10))
			{
				keyTouch = 2;
				if ((cmd == GameCanvas2.currentDialog.right || cmd == ChatTextField2.gI().right) && GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
				{
					return true;
				}
			}
		}
		else
		{
			if (cmd == GameCanvas2.currentScreen.left && GameCanvas2.isPointerHoldIn(0, GameCanvas2.h - cmdH - 5, cmdW, cmdH + 10))
			{
				keyTouch = 0;
				if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
				{
					return true;
				}
			}
			if (cmd == GameCanvas2.currentScreen.right && GameCanvas2.isPointerHoldIn(GameCanvas2.w - cmdW, GameCanvas2.h - cmdH - 5, cmdW, cmdH + 10))
			{
				keyTouch = 2;
				if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
				{
					return true;
				}
			}
			if ((cmd == GameCanvas2.currentScreen.center || ChatPopup2.currChatPopup != null) && GameCanvas2.isPointerHoldIn(GameCanvas2.w - cmdW >> 1, GameCanvas2.h - cmdH - 5, cmdW, cmdH + 10))
			{
				keyTouch = 1;
				if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
				{
					return true;
				}
			}
		}
		return false;
	}

	public virtual void paint(mGraphics2 g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h + 1);
		if ((!ChatTextField2.gI().isShow || !Main2.isPC) && GameCanvas2.currentDialog == null && !GameCanvas2.menu.showMenu)
		{
			GameCanvas2.paintz.paintCmdBar(g, left, center, right);
		}
	}
}
