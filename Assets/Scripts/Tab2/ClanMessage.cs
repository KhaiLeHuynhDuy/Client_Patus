public class ClanMessage2 : IActionListener2
{
	public int id;

	public int type;

	public int playerId;

	public string playerName;

	public long time;

	public int headId;

	public string[] chat;

	public sbyte color;

	public sbyte role;

	private int timeAgo;

	public int recieve;

	public int maxCap;

	public string[] option;

	public static MyVector2 vMessage = new MyVector2();

	public static void addMessage(ClanMessage2 cm, int index, bool upToTop)
	{
		for (int i = 0; i < vMessage.size(); i++)
		{
			ClanMessage2 clanMessage = (ClanMessage2)vMessage.elementAt(i);
			if (clanMessage.id == cm.id)
			{
				vMessage.removeElement(clanMessage);
				if (!upToTop)
				{
					vMessage.insertElementAt(cm, i);
				}
				else
				{
					vMessage.insertElementAt(cm, 0);
				}
				return;
			}
			if (clanMessage.maxCap != 0 && clanMessage.recieve == clanMessage.maxCap)
			{
				vMessage.removeElement(clanMessage);
			}
		}
		if (index == -1)
		{
			vMessage.addElement(cm);
		}
		else
		{
			vMessage.insertElementAt(cm, 0);
		}
		if (vMessage.size() > 20)
		{
			vMessage.removeElementAt(vMessage.size() - 1);
		}
	}

	public void paint(mGraphics2 g, int x, int y)
	{
		mFont2 mFont2 = mFont2.tahoma_7b_dark;
		if (role == 0)
		{
			mFont2 = mFont2.tahoma_7b_red;
		}
		else if (role == 1)
		{
			mFont2 = mFont2.tahoma_7b_green;
		}
		else if (role == 2)
		{
			mFont2 = mFont2.tahoma_7b_green2;
		}
		if (type == 0)
		{
			mFont2.drawString(g, playerName, x + 3, y + 1, 0);
			if (color == 0)
			{
				mFont2.tahoma_7_grey.drawString(g, chat[0] + ((chat.Length <= 1) ? string.Empty : "..."), x + 3, y + 11, 0);
			}
			else
			{
				mFont2.tahoma_7_red.drawString(g, chat[0] + ((chat.Length <= 1) ? string.Empty : "..."), x + 3, y + 11, 0);
			}
			mFont2.tahoma_7_grey.drawString(g, NinjaUtil2.getTimeAgo(timeAgo) + " " + mResources2.ago, x + GameCanvas2.panel.wScroll - 3, y + 1, mFont2.RIGHT);
		}
		if (type == 1)
		{
			mFont2.drawString(g, playerName + " (" + recieve + "/" + maxCap + ")", x + 3, y + 1, 0);
			mFont2.tahoma_7_blue.drawString(g, mResources2.request_pea + " " + NinjaUtil2.getTimeAgo(timeAgo) + " " + mResources2.ago, x + 3, y + 11, 0);
		}
		if (type == 2)
		{
			mFont2.drawString(g, playerName, x + 3, y + 1, 0);
			mFont2.tahoma_7_blue.drawString(g, mResources2.request_join_clan, x + 3, y + 11, 0);
		}
	}

	public void perform(int idAction, object p)
	{
	}

	public void update()
	{
		if (time != 0)
		{
			timeAgo = (int)(mSystem2.currentTimeMillis() / 1000 - time);
		}
	}
}
