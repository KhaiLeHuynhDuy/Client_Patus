public class MovePoint2
{
	public int xEnd;

	public int yEnd;

	public int dir;

	public int cvx;

	public int cvy;

	public int status;

	public MovePoint2(int xEnd, int yEnd, int act, int dir)
	{
		this.xEnd = xEnd;
		this.yEnd = yEnd;
		this.dir = dir;
		status = act;
	}

	public MovePoint2(int xEnd, int yEnd)
	{
		this.xEnd = xEnd;
		this.yEnd = yEnd;
	}
}
