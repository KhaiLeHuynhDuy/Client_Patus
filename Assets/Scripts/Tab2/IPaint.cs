public abstract class IPaint2
{
	public abstract void paintDefaultBg(mGraphics2 g);

	public abstract void paintfillDefaultBg(mGraphics2 g);

	public abstract void repaintCircleBg();

	public abstract void paintSolidBg(mGraphics2 g);

	public abstract void paintDefaultPopup(mGraphics2 g, int x, int y, int w, int h);

	public abstract void paintWhitePopup(mGraphics2 g, int y, int x, int width, int height);

	public abstract void paintDefaultPopupH(mGraphics2 g, int h);

	public abstract void paintCmdBar(mGraphics2 g, Command2 left, Command2 center, Command2 right);

	public abstract void paintSelect(mGraphics2 g, int x, int y, int w, int h);

	public abstract void paintLogo(mGraphics2 g, int x, int y);

	public abstract void paintHotline(mGraphics2 g, string num);

	public abstract void paintInputTf(mGraphics2 g, bool iss, int x, int y, int w, int h, int xText, int yText, string text);

	public abstract void paintTabSoft(mGraphics2 g);

	public abstract void paintBackMenu(mGraphics2 g, int x, int y, int w, int h, bool iss);

	public abstract void paintMsgBG(mGraphics2 g, int x, int y, int w, int h, string title, string subTitle, string check);

	public abstract void paintDefaultScrLisst(mGraphics2 g, string title, string subTitle, string check);

	public abstract void paintCheck(mGraphics2 g, int x, int y, int index);

	public abstract void paintImgMsg(mGraphics2 g, int x, int y, int index);

	public abstract void paintTitleBoard(mGraphics2 g, int roomID);

	public abstract void paintCheckPass(mGraphics2 g, int x, int y, bool check, bool focus);

	public abstract void paintInputDlg(mGraphics2 g, int x, int y, int w, int h, string[] str);

	public abstract void paintIconMainMenu(mGraphics2 g, int x, int y, bool iss, bool issSe, int i, int wStr);

	public abstract void paintLineRoom(mGraphics2 g, int x, int y, int xTo, int yTo);

	public abstract void paintCellContaint(mGraphics2 g, int x, int y, int w, int h, bool iss);

	public abstract void paintScroll(mGraphics2 g, int x, int y, int h);

	public abstract int[] getColorMsg();

	public abstract void paintLogo(mGraphics2 g);

	public abstract void paintTextLogin(mGraphics2 g, bool issRes);

	public abstract void paintSellectBoard(mGraphics2 g, int x, int y, int w, int h);

	public abstract int issRegissterUsingWAP();

	public abstract string getCard();

	public abstract void paintSellectedShop(mGraphics2 g, int x, int y, int w, int h);

	public abstract string getUrlUpdateGame();

	public string getFAQLink()
	{
		return "http://wap.teamobi.com/faqs.php?provider=";
	}

	public abstract void doSelect(int focus);
}
