using System;

public class EffectData2
{
	public Image2 img;

	public ImageInfo2[] imgInfo;

	public Frame2[] frame;

	public short[] arrFrame;

	public short[][] anim_data = new short[16][];

	public int ID;

	public int typeData;

	public int width;

	public int height;

	public ImageInfo2 getImageInfo(sbyte id)
	{
		for (int i = 0; i < imgInfo.Length; i++)
		{
			if (imgInfo[i].ID == id)
			{
				return imgInfo[i];
			}
		}
		return null;
	}

	public short[] get()
	{
		return arrFrame;
	}

	public short[] get(int index)
	{
		if (index >= anim_data.Length)
		{
			index = 0;
		}
		if (anim_data[index] == null)
		{
			return new short[1];
		}
		return anim_data[index];
	}

	public void readData(string patch)
	{
		DataInputStream2 dataInputStream = null;
		try
		{
			dataInputStream = MyStream2.readFile(patch);
		}
		catch (Exception)
		{
			return;
		}
		readData(dataInputStream.r);
	}

	public void readData2(string patch)
	{
		DataInputStream2 dataInputStream = null;
		try
		{
			dataInputStream = MyStream2.readFile(patch);
		}
		catch (Exception)
		{
			return;
		}
		readEffect(dataInputStream.r);
	}

	public void readEffect(myReader2 msg)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		try
		{
			sbyte b = msg.readByte();
			Res2.outz("size IMG==========" + b);
			imgInfo = new ImageInfo2[b];
			for (int i = 0; i < b; i++)
			{
				imgInfo[i] = new ImageInfo2();
				imgInfo[i].ID = msg.readByte();
				imgInfo[i].x0 = msg.readUnsignedByte();
				imgInfo[i].y0 = msg.readUnsignedByte();
				imgInfo[i].w = msg.readUnsignedByte();
				imgInfo[i].h = msg.readUnsignedByte();
			}
			short num5 = msg.readShort();
			frame = new Frame2[num5];
			for (int j = 0; j < frame.Length; j++)
			{
				frame[j] = new Frame2();
				sbyte b2 = msg.readByte();
				frame[j].dx = new short[b2];
				frame[j].dy = new short[b2];
				frame[j].idImg = new sbyte[b2];
				for (int k = 0; k < b2; k++)
				{
					frame[j].dx[k] = msg.readShort();
					frame[j].dy[k] = msg.readShort();
					frame[j].idImg[k] = msg.readByte();
					if (j == 0)
					{
						if (num > frame[j].dx[k])
						{
							num = frame[j].dx[k];
						}
						if (num2 > frame[j].dy[k])
						{
							num2 = frame[j].dy[k];
						}
						if (num3 < frame[j].dx[k] + imgInfo[frame[j].idImg[k]].w)
						{
							num3 = frame[j].dx[k] + imgInfo[frame[j].idImg[k]].w;
						}
						if (num4 < frame[j].dy[k] + imgInfo[frame[j].idImg[k]].h)
						{
							num4 = frame[j].dy[k] + imgInfo[frame[j].idImg[k]].h;
						}
						width = num3 - num;
						height = num4 - num2;
					}
				}
			}
			arrFrame = new short[msg.readShort()];
			for (int l = 0; l < arrFrame.Length; l++)
			{
				arrFrame[l] = msg.readShort();
			}
		}
		catch (Exception ex)
		{
			ex.StackTrace.ToString();
			Res2.outz("1");
		}
	}

	public void readData(myReader2 iss)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		try
		{
			sbyte b = iss.readByte();
			imgInfo = new ImageInfo2[b];
			for (int i = 0; i < b; i++)
			{
				imgInfo[i] = new ImageInfo2();
				imgInfo[i].ID = iss.readByte();
				imgInfo[i].x0 = iss.readUnsignedByte();
				imgInfo[i].y0 = iss.readUnsignedByte();
				imgInfo[i].w = iss.readUnsignedByte();
				imgInfo[i].h = iss.readUnsignedByte();
			}
			short num5 = iss.readShort();
			frame = new Frame2[num5];
			for (int j = 0; j < num5; j++)
			{
				frame[j] = new Frame2();
				sbyte b2 = iss.readByte();
				frame[j].dx = new short[b2];
				frame[j].dy = new short[b2];
				frame[j].idImg = new sbyte[b2];
				for (int k = 0; k < b2; k++)
				{
					frame[j].dx[k] = iss.readShort();
					frame[j].dy[k] = iss.readShort();
					frame[j].idImg[k] = iss.readByte();
					if (j == 0)
					{
						if (num > frame[j].dx[k])
						{
							num = frame[j].dx[k];
						}
						if (num2 > frame[j].dy[k])
						{
							num2 = frame[j].dy[k];
						}
						if (num3 < frame[j].dx[k] + imgInfo[frame[j].idImg[k]].w)
						{
							num3 = frame[j].dx[k] + imgInfo[frame[j].idImg[k]].w;
						}
						if (num4 < frame[j].dy[k] + imgInfo[frame[j].idImg[k]].h)
						{
							num4 = frame[j].dy[k] + imgInfo[frame[j].idImg[k]].h;
						}
						width = num3 - num;
						height = num4 - num2;
					}
				}
			}
			short num6 = 0;
			num6 = iss.readShort();
			arrFrame = new short[num6];
			if (ID >= 201)
			{
				short num7 = 0;
				short[] array = new short[num6];
				int num8 = 0;
				string text = string.Empty;
				bool flag = false;
				for (int l = 0; l < num6; l++)
				{
					short num9 = iss.readShort();
					text = text + num9 + ",";
					arrFrame[l] = num9;
					if (num9 + 500 >= 500)
					{
						array[num8++] = num9;
						flag = true;
						continue;
					}
					num7 = (short)Res2.abs(num9 + 500);
					anim_data[num7] = new short[num8];
					Array.Copy(array, 0, anim_data[num7], 0, num8);
					num8 = 0;
				}
				if (!flag)
				{
					anim_data[0] = new short[num8];
					Array.Copy(array, 0, anim_data[num7], 0, num8);
					return;
				}
				for (int m = 0; m < 16; m++)
				{
					if (anim_data[m] == null)
					{
						anim_data[m] = anim_data[2];
					}
				}
			}
			else
			{
				for (int n = 0; n < num6; n++)
				{
					arrFrame[n] = iss.readShort();
				}
			}
		}
		catch (Exception)
        {
		}
	}

	public void readData(sbyte[] data)
	{
		myReader2 iss = new(data);
		readData(iss);
	}

	public void readDataNewBoss(sbyte[] data, sbyte typeread)
	{
		myReader2 msg = new myReader2(data);
		readMobNew(msg, typeread);
	}

	public void paintFrame(mGraphics2 g, int f, int x, int y, int trans, int layer)
	{
		if (this.frame == null || this.frame.Length == 0)
		{
			return;
		}
		Frame2 frame = this.frame[f];
		for (int i = 0; i < frame.dx.Length; i++)
		{
			ImageInfo2 imageInfo = getImageInfo(frame.idImg[i]);
			try
			{
				switch (trans)
				{
				case -1:
					g.drawRegion(img, imageInfo.x0, imageInfo.y0, imageInfo.w, imageInfo.h, 0, x + frame.dx[i], y + frame.dy[i], 0);
					break;
				case 0:
					g.drawRegion(img, imageInfo.x0, imageInfo.y0, imageInfo.w, imageInfo.h, 0, x + frame.dx[i], y + frame.dy[i] - ((layer < 4 && layer > 0) ? GameCanvas2.transY : 0), 0);
					break;
				case 1:
					g.drawRegion(img, imageInfo.x0, imageInfo.y0, imageInfo.w, imageInfo.h, 2, x - frame.dx[i], y + frame.dy[i] - ((layer < 4 && layer > 0) ? GameCanvas2.transY : 0), StaticObj2.TOP_RIGHT);
					break;
				case 2:
					g.drawRegion(img, imageInfo.x0, imageInfo.y0, imageInfo.w, imageInfo.h, 7, x - frame.dx[i], y + frame.dy[i] - ((layer < 4 && layer > 0) ? GameCanvas2.transY : 0), StaticObj2.VCENTER_HCENTER);
					break;
				}
			}
			catch (Exception)
			{
			}
		}
	}

	public void readMobNew(myReader2 msg, sbyte typeread)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		try
		{
			sbyte b = msg.readByte();
			imgInfo = new ImageInfo2[b];
			for (int i = 0; i < b; i++)
			{
				imgInfo[i] = new ImageInfo2();
				imgInfo[i].ID = msg.readByte();
				if (typeread == 1)
				{
					imgInfo[i].x0 = msg.readUnsignedByte();
					imgInfo[i].y0 = msg.readUnsignedByte();
				}
				else
				{
					imgInfo[i].x0 = msg.readShort();
					imgInfo[i].y0 = msg.readShort();
				}
				imgInfo[i].w = msg.readUnsignedByte();
				imgInfo[i].h = msg.readUnsignedByte();
			}
			short num5 = msg.readShort();
			frame = new Frame2[num5];
			for (int j = 0; j < frame.Length; j++)
			{
				frame[j] = new Frame2();
				sbyte b2 = msg.readByte();
				frame[j].dx = new short[b2];
				frame[j].dy = new short[b2];
				frame[j].idImg = new sbyte[b2];
				for (int k = 0; k < b2; k++)
				{
					frame[j].dx[k] = msg.readShort();
					frame[j].dy[k] = msg.readShort();
					frame[j].idImg[k] = msg.readByte();
					if (j == 0)
					{
						if (num > frame[j].dx[k])
						{
							num = frame[j].dx[k];
						}
						if (num2 > frame[j].dy[k])
						{
							num2 = frame[j].dy[k];
						}
						if (num3 < frame[j].dx[k] + imgInfo[frame[j].idImg[k]].w)
						{
							num3 = frame[j].dx[k] + imgInfo[frame[j].idImg[k]].w;
						}
						if (num4 < frame[j].dy[k] + imgInfo[frame[j].idImg[k]].h)
						{
							num4 = frame[j].dy[k] + imgInfo[frame[j].idImg[k]].h;
						}
						width = num3 - num;
						height = num4 - num2;
					}
				}
			}
			arrFrame = new short[msg.readShort()];
			for (int l = 0; l < arrFrame.Length; l++)
			{
				arrFrame[l] = msg.readShort();
			}
		}
		catch (Exception)
		{
		}
	}
}
