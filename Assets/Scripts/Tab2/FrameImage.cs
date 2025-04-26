using System;

public class FrameImage2
{
	public int frameWidth;

	public int frameHeight;

	public int nFrame;

	public Image2 imgFrame;

	public int Id = -1;

	public int numWidth;

	public int numHeight;

	public FrameImage2(int ID)
	{
		Id = ID;
		Image2 image = Effect_End2.getImage(ID);
		if (image != null)
		{
			imgFrame = image;
			frameWidth = Effect_End2.arrInfoEff[ID][0];
			frameHeight = Effect_End2.arrInfoEff[ID][1] / Effect_End2.arrInfoEff[ID][2];
			nFrame = Effect_End2.arrInfoEff[ID][2];
		}
	}

	public FrameImage2(Image2 img, int width, int height)
	{
		if (img != null)
		{
			imgFrame = img;
			frameWidth = width;
			frameHeight = height;
			nFrame = img.getHeight() / height;
			if (nFrame < 1)
			{
				nFrame = 1;
			}
		}
	}

	public FrameImage2(Image2 img, int numW, int numH, int numNull)
	{
		if (img != null)
		{
			imgFrame = img;
			numWidth = numW;
			numHeight = numH;
			frameWidth = imgFrame.getWidth() / numW;
			frameHeight = imgFrame.getHeight() / numH;
			nFrame = numW * numH - numNull;
		}
	}

	public void drawFrame(int idx, int x, int y, int trans, int anchor, mGraphics2 g)
	{
		try
		{
			if (imgFrame != null)
			{
				if (idx > nFrame)
				{
					idx = nFrame;
				}
				int num = idx * frameHeight;
				if (num > frameHeight * (nFrame - 1) || num < 0)
				{
					num = frameHeight * (nFrame - 1);
				}
				g.drawRegion(imgFrame, 0, num, frameWidth, frameHeight, trans, x, y, anchor);
			}
		}
		catch (Exception)
		{
		}
	}
}
