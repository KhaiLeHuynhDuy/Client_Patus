public class PlayerData2
{
	public int playerID;

	public string name;

	public short head;

	public short body;

	public short leg;

	public long powpoint;

	public PlayerData2(int playerID, string name, short head, short body, short leg, long ppoint)
	{
		this.playerID = playerID;
		this.name = name;
		this.head = head;
		this.body = body;
		this.leg = leg;
		powpoint = ppoint;
	}

	public string getInfo()
	{
		return name + "\n" + mResources2.power_point + " " + powpoint;
	}
}
