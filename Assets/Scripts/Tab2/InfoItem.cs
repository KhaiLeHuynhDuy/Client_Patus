public class InfoItem2
{
	public string s;

	private mFont2 f;

	public int speed = 70;

	public Char2 charInfo;

	public bool isChatServer;

	public bool isOnline;

	public int timeCount;

	public int maxTime;

	public long last;

	public long curr;

	public InfoItem2(string s)
	{
		f = mFont2.tahoma_7_green2;
		this.s = s;
		speed = 20;
	}

	public InfoItem2(string s, mFont2 f, int speed)
	{
		this.f = f;
		this.s = s;
		this.speed = speed;
	}
}
