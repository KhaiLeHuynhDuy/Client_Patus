using System;
using System.Collections;
using UnityEngine;

public class ImgByName2
{
	public static MyHashTable2 hashImagePath = new MyHashTable2();

	public static void SetImage(string name, Image2 img, sbyte nFrame)
	{
		hashImagePath.put(string.Empty + name, new MainImage2(img, nFrame));
	}

	public static MainImage2 getImagePath(string nameImg, MyHashTable2 hash)
	{
		MainImage2 mainImage = (MainImage2)hash.get(string.Empty + nameImg);
		if (mainImage == null)
		{
			mainImage = new MainImage2();
			MainImage2 fromRms = getFromRms(nameImg);
			if (fromRms != null)
			{
				mainImage.img = fromRms.img;
				mainImage.nFrame = fromRms.nFrame;
			}
			hash.put(string.Empty + nameImg, mainImage);
		}
		mainImage.count = GameCanvas2.timeNow / 1000;
		if (mainImage.img == null)
		{
			mainImage.timeImageNull--;
			if (mainImage.timeImageNull <= 0)
			{
				Service2.gI().getImgByName(nameImg);
				mainImage.timeImageNull = 200;
			}
		}
		return mainImage;
	}

	public static MainImage2 getFromRms(string nameImg)
	{
		string text = mGraphics2.zoomLevel + "ImgByName_" + nameImg;
		MainImage2 result = null;
		sbyte[] array = null;
		array = Rms2.loadRMS(text);
		if (array == null)
		{
			return result;
		}
		try
		{
			result = new MainImage2();
			result.nFrame = array[0];
			sbyte[] newArr = MainMod2.DecryptBytes(array[1..]);
			result.img = Image2.createImage(array, 1, array.Length - 1);
			if (result.img != null)
			{
			}
		}
		catch (Exception)
		{
			return null;
		}
		return result;
	}

	public static void saveRMS(string nameImg, sbyte nFrame, sbyte[] data)
	{
		string text = mGraphics2.zoomLevel + "ImgByName_" + nameImg;
		DataOutputStream2 dataOutputStream = new DataOutputStream2(data.Length + 1);
		int i = 0;
		try
		{
			dataOutputStream.writeByte(nFrame);
			for (i = 0; i < data.Length; i++)
			{
				dataOutputStream.writeByte(data[i]);
			}
			Rms2.saveRMS(text, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
			Debug.LogError(i + ">>Errr save rms: " + text + "  " + ex.ToString());
		}
	}

	public static void checkDelHash(MyHashTable2 hash, int minute, bool isTrue)
	{
		MyVector2 myVector = new MyVector2("checkDelHash");
		if (isTrue)
		{
			hash.clear();
			return;
		}
		IDictionaryEnumerator enumerator = hash.GetEnumerator();
		while (enumerator.MoveNext())
		{
			MainImage2 mainImage = (MainImage2)enumerator.Value;
			if (GameCanvas2.timeNow / 1000 - mainImage.count > minute * 60)
			{
				string o = (string)enumerator.Key;
				myVector.addElement(o);
			}
		}
		for (int i = 0; i < myVector.size(); i++)
		{
			hash.remove((string)myVector.elementAt(i));
		}
	}
}
