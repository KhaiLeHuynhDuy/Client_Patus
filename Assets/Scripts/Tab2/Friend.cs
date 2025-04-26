public class Friend2
{
	public string friendName;

	public sbyte type;

	public Friend2(string friendName, sbyte type)
	{
		this.friendName = friendName;
		this.type = type;
	}

	public Friend2(string friendName)
	{
		this.friendName = friendName;
		type = 2;
	}
}
