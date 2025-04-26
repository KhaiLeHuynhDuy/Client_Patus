public class MainImage2
{
	public Image2 img;

	public long count = -1L;

	public int timeImageNull;

	public int idImage;

	public long timerequest;

	public sbyte nFrame = 1;

	public long timeUse = mSystem2.currentTimeMillis();

	public MainImage2()
	{
	}

	public MainImage2(Image2 im, sbyte nFrame)
	{
		img = im;
		count = 0L;
		this.nFrame = nFrame;
	}
}
