public class Waypoint2 : IActionListener2
{
	public short minX;

	public short minY;

	public short maxX;

	public short maxY;

	public bool isEnter;

	public bool isOffline;

	public PopUp2 popup;

	public Waypoint2(short minX, short minY, short maxX, short maxY, bool isEnter, bool isOffline, string name)
	{
		this.minX = minX;
		this.minY = minY;
		this.maxX = maxX;
		this.maxY = maxY;
		name = Res2.changeString(name);
		this.isEnter = isEnter;
		this.isOffline = isOffline;
		if (((TileMap2.mapID == 21 || TileMap2.mapID == 22 || TileMap2.mapID == 23) && this.minX >= 0 && this.minX <= 24) || (((TileMap2.mapID == 0 && Char2.myCharz().cgender != 0) || (TileMap2.mapID == 7 && Char2.myCharz().cgender != 1) || (TileMap2.mapID == 14 && Char2.myCharz().cgender != 2)) && isOffline))
		{
			return;
		}
		if (TileMap2.isInAirMap() || TileMap2.mapID == 47)
		{
			if (minY <= 150 || !TileMap2.isInAirMap())
			{
				popup = new PopUp2(name, minX + (maxX - minX) / 2, maxY - ((minX <= 100) ? 48 : 24));
				popup.command = new Command2(null, this, 1, this);
				popup.isWayPoint = true;
				popup.isPaint = false;
				PopUp2.addPopUp(popup);
				TileMap2.vGo.addElement(this);
			}
			return;
		}
		if (!isEnter && !isOffline)
		{
			popup = new PopUp2(name, minX, minY - 24);
			popup.command = new Command2(null, this, 1, this);
			popup.isWayPoint = true;
			popup.isPaint = false;
			PopUp2.addPopUp(popup);
		}
		else
		{
			if (TileMap2.isTrainingMap())
			{
				popup = new PopUp2(name, minX, minY - 16);
			}
			else
			{
				int x = minX + (maxX - minX) / 2;
				popup = new PopUp2(name, x, minY - ((minY == 0) ? (-32) : 16));
			}
			popup.command = new Command2(null, this, 2, this);
			popup.isWayPoint = true;
			popup.isPaint = false;
			PopUp2.addPopUp(popup);
		}
		TileMap2.vGo.addElement(this);
	}

	public void perform(int idAction, object p)
	{
		switch (idAction)
		{
		case 1:
		{
			int xEnd2 = (minX + maxX) / 2;
			int yEnd2 = maxY;
			if (maxY > minY + 24)
			{
				yEnd2 = (minY + maxY) / 2;
			}
			GameScr2.gI().auto = 0;
			Char2.myCharz().currentMovePoint = new MovePoint2(xEnd2, yEnd2);
			Char2.myCharz().cdir = ((Char2.myCharz().cx - Char2.myCharz().currentMovePoint.xEnd <= 0) ? 1 : (-1));
			Service2.gI().charMove();
			break;
		}
		case 2:
			GameScr2.gI().auto = 0;
			if (Char2.myCharz().isInEnterOfflinePoint() != null)
			{
				Service2.gI().charMove();
				InfoDlg2.showWait();
				Service2.gI().getMapOffline();
				Char2.ischangingMap = true;
			}
			else if (Char2.myCharz().isInEnterOnlinePoint() != null)
			{
				Service2.gI().charMove();
				Service2.gI().requestChangeMap();
				Char2.isLockKey = true;
				Char2.ischangingMap = true;
				GameCanvas2.clearKeyHold();
				GameCanvas2.clearKeyPressed();
				InfoDlg2.showWait();
			}
			else
			{
				int xEnd = (minX + maxX) / 2;
				int yEnd = maxY;
				Char2.myCharz().currentMovePoint = new MovePoint2(xEnd, yEnd);
				Char2.myCharz().cdir = ((Char2.myCharz().cx - Char2.myCharz().currentMovePoint.xEnd <= 0) ? 1 : (-1));
				Char2.myCharz().endMovePointCommand = new Command2(null, this, 2, null);
			}
			break;
		}
	}
}
