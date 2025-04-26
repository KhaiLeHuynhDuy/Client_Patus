public abstract class Dialog2
{
	public Command2 left;

	public Command2 center;

	public Command2 right;

	private int lenCaption;

	public virtual void paint(mGraphics2 g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
		GameCanvas2.paintz.paintTabSoft(g);
		GameCanvas2.paintz.paintCmdBar(g, left, center, right);
	}

	public virtual void keyPress(int keyCode)
	{
		switch (keyCode)
		{
		case -38:
		case -1:
			GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21] = true;
			GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21] = true;
			break;
		case -39:
		case -2:
			GameCanvas2.keyHold[(!Main2.isPC) ? 8 : 22] = true;
			GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22] = true;
			break;
		case -21:
		case -6:
			GameCanvas2.keyHold[12] = true;
			GameCanvas2.keyPressed[12] = true;
			break;
		case -22:
		case -7:
			GameCanvas2.keyHold[13] = true;
			GameCanvas2.keyPressed[13] = true;
			break;
		case -5:
		case 10:
			GameCanvas2.keyHold[(!Main2.isPC) ? 5 : 25] = true;
			GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = true;
			break;
		}
	}

	public virtual void update()
	{
		if (center != null && (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] || mScreen2.getCmdPointerLast(center)))
		{
			GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
			GameCanvas2.isPointerClick = false;
			mScreen2.keyTouch = -1;
			GameCanvas2.isPointerJustRelease = false;
			if (center != null)
			{
				center.performAction();
			}
			mScreen2.keyTouch = -1;
		}
		if (left != null && (GameCanvas2.keyPressed[12] || mScreen2.getCmdPointerLast(left)))
		{
			GameCanvas2.keyPressed[12] = false;
			GameCanvas2.isPointerClick = false;
			mScreen2.keyTouch = -1;
			GameCanvas2.isPointerJustRelease = false;
			if (left != null)
			{
				left.performAction();
			}
			mScreen2.keyTouch = -1;
		}
		if (right != null && (GameCanvas2.keyPressed[13] || mScreen2.getCmdPointerLast(right)))
		{
			GameCanvas2.keyPressed[13] = false;
			GameCanvas2.isPointerClick = false;
			GameCanvas2.isPointerJustRelease = false;
			mScreen2.keyTouch = -1;
			if (right != null)
			{
				right.performAction();
			}
			mScreen2.keyTouch = -1;
		}
		GameCanvas2.clearKeyPressed();
		GameCanvas2.clearKeyHold();
	}

	public virtual void show()
	{
	}
}
