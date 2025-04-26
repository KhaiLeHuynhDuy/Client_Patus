public class Part2
{
	public int type;

	public PartImage2[] pi;

	public Part2(int type)
	{
		this.type = type;
		if (type == 0)
		{
			pi = new PartImage2[3];
		}
		if (type == 1)
		{
			pi = new PartImage2[17];
		}
		if (type == 2)
		{
			pi = new PartImage2[14];
		}
		if (type == 3)
		{
			pi = new PartImage2[2];
		}
	}
}
