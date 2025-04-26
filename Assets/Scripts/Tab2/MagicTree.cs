using System;

public class MagicTree2 : Npc2, IActionListener2
{
	public static Image2 imgMagicTree;

	public static Image2 pea = GameCanvas2.loadImage("/mainImage/myTexture2dhatdau.png");

	public int id;

	public int level;

	public int x;

	public int y;

	public int currPeas;

	public int remainPeas;

	public int maxPeas;

	public new string strInfo;

	public string name;

	public int timeToRecieve;

	public bool isUpdate;

	public int[] peaPostionX;

	public int[] peaPostionY;

	private int num;

	public PopUp2 p;

	public bool isUpdateTree;

	public new static bool isPaint = true;

	public bool isPeasEffect;

	public new int seconds;

	public new long last;

	public new long cur;

	private int wPopUp;

	private bool waitToUpdate;

	private int delay;

	public MagicTree2(int npcId, int status, int cx, int cy, int templateId, int iconId)
		: base(npcId, status, cx, cy, templateId, iconId)
	{
		p = new PopUp2(string.Empty, 0, 0);
		p.command = new Command2(null, this, 1, null);
		PopUp2.addPopUp(p);
	}

	public override void paint(mGraphics2 g)
	{
		if (id == 0)
		{
			return;
		}
		SmallImage2.drawSmallImage(g, id, cx, cy, 0, StaticObj2.BOTTOM_HCENTER);
		if (Char2.myCharz().npcFocus != null && Char2.myCharz().npcFocus.Equals(this))
		{
			g.drawRegion(Mob2.imgHP, 0, 0, 9, 6, 0, cx, cy - SmallImage2.smallImg[id][4] - 1, mGraphics2.BOTTOM | mGraphics2.HCENTER);
			if (name != null)
			{
				mFont2.tahoma_7b_white.drawString(g, name, cx, cy - SmallImage2.smallImg[id][4] - 20, mFont2.CENTER, mFont2.tahoma_7_grey);
			}
		}
		else if (name != null)
		{
			mFont2.tahoma_7b_white.drawString(g, name, cx, cy - SmallImage2.smallImg[id][4] - 17, mFont2.CENTER, mFont2.tahoma_7_grey);
		}
		try
		{
			for (int i = 0; i < currPeas; i++)
			{
				g.drawImage(pea, cx + peaPostionX[i] - SmallImage2.smallImg[id][3] / 2, cy + peaPostionY[i] - SmallImage2.smallImg[id][4], 0);
			}
		}
		catch (Exception)
		{
		}
		if (indexEffTask < 0 || effTask == null || cTypePk != 0)
		{
			return;
		}
		SmallImage2.drawSmallImage(g, effTask.arrEfInfo[indexEffTask].idImg, cx + effTask.arrEfInfo[indexEffTask].dx + SmallImage2.smallImg[id][3] / 2 + 5, cy - 15 + effTask.arrEfInfo[indexEffTask].dy, 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
		if (GameCanvas2.gameTick % 2 == 0)
		{
			indexEffTask++;
			if (indexEffTask >= effTask.arrEfInfo.Length)
			{
				indexEffTask = 0;
			}
		}
	}

	public override void update()
	{
		p.isPaint = isPaint;
		cur = mSystem2.currentTimeMillis();
		if (cur - last >= 1000)
		{
			seconds--;
			last = cur;
			if (seconds < 0)
			{
				seconds = 0;
			}
		}
		if (!isUpdate)
		{
			if (currPeas < maxPeas && seconds == 0)
			{
				waitToUpdate = true;
			}
		}
		else if (seconds == 0)
		{
			isUpdate = false;
			waitToUpdate = true;
		}
		if (waitToUpdate)
		{
			delay++;
			if (delay == 20)
			{
				delay = 0;
				waitToUpdate = false;
				Service2.gI().getMagicTree(2);
			}
		}
		num = ((peaPostionX != null) ? (peaPostionX.Length * currPeas / maxPeas) : 0);
		if (isUpdateTree)
		{
			isUpdateTree = false;
			if ((seconds >= 0 && currPeas < maxPeas) || (seconds >= 0 && isUpdate) || isPeasEffect)
			{
				p.updateXYWH(new string[2]
				{
					isUpdate ? mResources2.UPGRADING : (currPeas + "/" + maxPeas),
					NinjaUtil2.getTime(seconds)
				}, cx, cy - 20 - SmallImage2.smallImg[id][4]);
			}
			else if (currPeas == maxPeas && !isUpdate)
			{
				p.updateXYWH(new string[2]
				{
					mResources2.can_harvest,
					currPeas + "/" + maxPeas
				}, cx, cy - 20 - SmallImage2.smallImg[id][4]);
			}
		}
		if ((seconds >= 0 && currPeas < maxPeas) || (seconds >= 0 && isUpdate))
		{
			p.says[p.says.Length - 1] = NinjaUtil2.getTime(seconds);
		}
		if (isPeasEffect)
		{
			p.isPaint = false;
			ServerEffect2.addServerEffect(98, cx + peaPostionX[currPeas - 1] - SmallImage2.smallImg[id][3] / 2, cy + peaPostionY[currPeas - 1] - SmallImage2.smallImg[id][4], 1);
			currPeas--;
			if (GameCanvas2.gameTick % 2 == 0)
			{
				SoundMn2.gI().HP_MPup();
			}
			if (currPeas == remainPeas)
			{
				p.isPaint = true;
				isUpdateTree = true;
				isPeasEffect = false;
			}
		}
		base.update();
	}

	public void perform(int idAction, object p)
	{
		if (idAction == 1)
		{
			Service2.gI().magicTree(1);
		}
	}
}
