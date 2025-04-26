using System;
using System.Threading;
using UnityEngine;

public class Image2
{
	private const int INTERVAL = 5;

	private const int MAXTIME = 500;

	public Texture2D texture = new Texture2D(1, 1);

	public static Image2 imgTemp;

	public static string filenametemp;

	public static byte[] datatemp;

	public static Image2 imgSrcTemp;

	public static int xtemp;

	public static int ytemp;

	public static int wtemp;

	public static int htemp;

	public static int transformtemp;

	public int w;

	public int h;

	public static int status;

	public Color colorBlend = Color.black;

	public static Image2 createEmptyImage()
	{
		return __createEmptyImage();
	}

	public static Image2 createImage(string filename)
	{
		return __createImage(filename);
	}

	public static Image2 CreateImageResize(string filename)
	{
		Image2 image = new();
		Texture2D texture2D = Resources.Load(filename) as Texture2D;
		if (texture2D == null)
		{
			throw new Exception("NULL POINTER EXCEPTION AT Image __createImage " + filename);
		}

		Texture2D resizedTexture;

		if (mGraphics2.zoomLevel != 4 && !filename.Contains("/tx1/"))
		{
			int targetWidth = texture2D.width / 4 * mGraphics2.zoomLevel;
			int targetHeight = texture2D.height / 4 * mGraphics2.zoomLevel;

			resizedTexture = ResizeTexture(texture2D, targetWidth, targetHeight);
		}
		else
		{
			resizedTexture = texture2D;
		}

		image.texture = resizedTexture;
		image.w = image.texture.width;
		image.h = image.texture.height;

		setTextureQuality(image);
		return image;
	}

	private static Texture2D ResizeTexture(Texture2D source, int targetWidth, int targetHeight)
	{
		RenderTexture rt = RenderTexture.GetTemporary(targetWidth, targetHeight);
		RenderTexture.active = rt;
		Graphics.Blit(source, rt);
		Texture2D result = new(targetWidth, targetHeight);
		result.ReadPixels(new Rect(0, 0, targetWidth, targetHeight), 0, 0);
		result.Apply();
		RenderTexture.active = null;
		RenderTexture.ReleaseTemporary(rt);
		return result;
	}

	public static Image2 createImage(byte[] imageData)
	{
		return __createImage(imageData);
	}

	public static Image2 createImage(Image2 src, int x, int y, int w, int h, int transform)
	{
		return __createImage(src, x, y, w, h, transform);
	}

	public static Image2 createImage(int w, int h)
	{
		return __createImage(w, h);
	}

	public static Image2 createImage(Image2 img)
	{
		Image2 image = createImage(img.w, img.h);
		image.texture = img.texture;
		image.texture.Apply();
		return image;
	}

	public static Image2 createImage(sbyte[] imageData, int offset, int lenght)
	{
		if (offset + lenght > imageData.Length)
		{
			return null;
		}
		byte[] array = new byte[lenght];
		for (int i = 0; i < lenght; i++)
		{
			array[i] = convertSbyteToByte(imageData[i + offset]);
		}
		return createImage(array);
	}

	public static byte convertSbyteToByte(sbyte var)
	{
		if (var > 0)
		{
			return (byte)var;
		}
		return (byte)(var + 256);
	}

	public static byte[] convertArrSbyteToArrByte(sbyte[] var)
	{
		byte[] array = new byte[var.Length];
		for (int i = 0; i < var.Length; i++)
		{
			if (var[i] > 0)
			{
				array[i] = (byte)var[i];
			}
			else
			{
				array[i] = (byte)(var[i] + 256);
			}
		}
		return array;
	}

	public static Image2 createRGBImage(int[] rbg, int w, int h, bool bl)
	{
		Image2 image = createImage(w, h);
		Color[] array = new Color[rbg.Length];
		for (int i = 0; i < array.Length; i++)
		{
			ref Color reference = ref array[i];
			reference = setColorFromRBG(rbg[i]);
		}
		image.texture.SetPixels(0, 0, w, h, array);
		image.texture.Apply();
		return image;
	}

	public static Color setColorFromRBG(int rgb)
	{
		int num = rgb & 0xFF;
		int num2 = (rgb >> 8) & 0xFF;
		int num3 = (rgb >> 16) & 0xFF;
		float b = (float)num / 256f;
		float g = (float)num2 / 256f;
		float r = (float)num3 / 256f;
		return new Color(r, g, b);
	}

	public static void update()
	{
		if (status == 2)
		{
			status = 1;
			imgTemp = __createEmptyImage();
			status = 0;
		}
		else if (status == 3)
		{
			status = 1;
			imgTemp = __createImage(filenametemp);
			status = 0;
		}
		else if (status == 4)
		{
			status = 1;
			imgTemp = __createImage(datatemp);
			status = 0;
		}
		else if (status == 5)
		{
			status = 1;
			imgTemp = __createImage(imgSrcTemp, xtemp, ytemp, wtemp, htemp, transformtemp);
			status = 0;
		}
		else if (status == 6)
		{
			status = 1;
			imgTemp = __createImage(wtemp, htemp);
			status = 0;
		}
	}

	private static Image2 _createEmptyImage()
	{
		if (status != 0)
		{
			Cout2.LogError("CANNOT CREATE EMPTY IMAGE WHEN CREATING OTHER IMAGE");
			return null;
		}
		imgTemp = null;
		status = 2;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Cout2.LogError("TOO LONG FOR CREATE EMPTY IMAGE");
			status = 0;
		}
		return imgTemp;
	}

	private static Image2 _createImage(string filename)
	{
		if (status != 0)
		{
			Cout2.LogError("CANNOT CREATE IMAGE " + filename + " WHEN CREATING OTHER IMAGE");
			return null;
		}
		imgTemp = null;
		filenametemp = filename;
		status = 3;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Cout2.LogError("TOO LONG FOR CREATE IMAGE " + filename);
			status = 0;
		}
		return imgTemp;
	}

	private static Image2 _createImage(byte[] imageData)
	{
		if (status != 0)
		{
			Cout2.LogError("CANNOT CREATE IMAGE(FromArray) WHEN CREATING OTHER IMAGE");
			return null;
		}
		imgTemp = null;
		datatemp = imageData;
		status = 4;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Cout2.LogError("TOO LONG FOR CREATE IMAGE(FromArray)");
			status = 0;
		}
		return imgTemp;
	}

	private static Image2 _createImage(Image2 src, int x, int y, int w, int h, int transform)
	{
		if (status != 0)
		{
			Cout2.LogError("CANNOT CREATE IMAGE(FromSrcPart) WHEN CREATING OTHER IMAGE");
			return null;
		}
		imgTemp = null;
		imgSrcTemp = src;
		xtemp = x;
		ytemp = y;
		wtemp = w;
		htemp = h;
		transformtemp = transform;
		status = 5;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Cout2.LogError("TOO LONG FOR CREATE IMAGE(FromSrcPart)");
			status = 0;
		}
		return imgTemp;
	}

	private static Image2 _createImage(int w, int h)
	{
		if (status != 0)
		{
			Cout2.LogError("CANNOT CREATE IMAGE(w,h) WHEN CREATING OTHER IMAGE");
			return null;
		}
		imgTemp = null;
		wtemp = w;
		htemp = h;
		status = 6;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Cout2.LogError("TOO LONG FOR CREATE IMAGE(w,h)");
			status = 0;
		}
		return imgTemp;
	}

	public static byte[] loadData(string filename)
	{
		Image2 image = new Image2();
		TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
		if (textAsset == null || textAsset.bytes == null || textAsset.bytes.Length == 0)
		{
			throw new Exception("NULL POINTER EXCEPTION AT Image __createImage " + filename);
		}
		sbyte[] array = ArrayCast2.cast(textAsset.bytes);
		Debug.LogError("CHIEU DAI MANG BYTE IMAGE CREAT = " + array.Length);
		return textAsset.bytes;
	}

	private static Image2 __createImage(string filename)
	{
		Image2 image = new Image2();
		Texture2D texture2D = Resources.Load(filename) as Texture2D;
		if (texture2D == null)
		{
			throw new Exception("NULL POINTER EXCEPTION AT Image __createImage " + filename);
		}
		image.texture = texture2D;
		image.w = image.texture.width;
		image.h = image.texture.height;
		setTextureQuality(image);
		return image;
	}

	private static Image2 __createImage(byte[] imageData)
	{
		if (imageData == null || imageData.Length == 0)
		{
			Cout2.LogError("Create Image from byte array fail");
			return null;
		}
		Image2 image = new Image2();
		try
		{
			image.texture.LoadImage(imageData);
			image.w = image.texture.width;
			image.h = image.texture.height;
			setTextureQuality(image);
		}
		catch (Exception)
		{
			Cout2.LogError("CREAT IMAGE FROM ARRAY FAIL \n" + Environment.StackTrace);
		}
		return image;
	}

	private static Image2 __createImage(Image2 src, int x, int y, int w, int h, int transform)
	{
		Image2 image = new Image2();
		image.texture = new Texture2D(w, h);
		y = src.texture.height - y - h;
		for (int i = 0; i < w; i++)
		{
			for (int j = 0; j < h; j++)
			{
				int num = i;
				if (transform == 2)
				{
					num = w - i;
				}
				int num2 = j;
				image.texture.SetPixel(i, j, src.texture.GetPixel(x + num, y + num2));
			}
		}
		image.texture.Apply();
		image.w = image.texture.width;
		image.h = image.texture.height;
		setTextureQuality(image);
		return image;
	}

	private static Image2 __createEmptyImage()
	{
		return new Image2();
	}

	public static Image2 __createImage(int w, int h)
	{
		Image2 image = new Image2();
		image.texture = new Texture2D(w, h, TextureFormat.RGBA32, mipChain: false);
		setTextureQuality(image);
		image.w = w;
		image.h = h;
		image.texture.Apply();
		return image;
	}

	public static int getImageWidth(Image2 image)
	{
		return image.getWidth();
	}

	public static int getImageHeight(Image2 image)
	{
		return image.getHeight();
	}

	public int getWidth()
	{
		return w / mGraphics2.zoomLevel;
	}

	public int getHeight()
	{
		return h / mGraphics2.zoomLevel;
	}

	private static void setTextureQuality(Image2 img)
	{
		setTextureQuality(img.texture);
	}

	public static void setTextureQuality(Texture2D texture)
	{
		texture.anisoLevel = 0;
		texture.filterMode = FilterMode.Point;
		texture.mipMapBias = 0f;
		texture.wrapMode = TextureWrapMode.Clamp;
	}

	public Color[] getColor()
	{
		return texture.GetPixels();
	}

	public int getRealImageWidth()
	{
		return w;
	}

	public int getRealImageHeight()
	{
		return h;
	}

	public void getRGB(ref int[] data, int x1, int x2, int x, int y, int w, int h)
	{
		Color[] pixels = texture.GetPixels(x, this.h - 1 - y, w, h);
		for (int i = 0; i < pixels.Length; i++)
		{
			data[i] = mGraphics2.getIntByColor(pixels[i]);
		}
	}
}
