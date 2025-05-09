using System;
using System.IO;
using System.Threading;
using UnityEngine;

public class Rms2
{
	public static int status;

	public static sbyte[] data;

	public static string filename;

	private const int INTERVAL = 5;

	private const int MAXTIME = 500;

	public static void saveRMS(string filename, sbyte[] data)
	{
		if (Thread.CurrentThread.Name == Main2.mainThreadName)
		{
			__saveRMS(filename, data);
		}
		else
		{
			_saveRMS(filename, data);
		}
	}

	public static sbyte[] loadRMS(string filename)
	{
		if (Thread.CurrentThread.Name == Main2.mainThreadName)
		{
			return __loadRMS(filename);
		}
		return _loadRMS(filename);
	}

	public static string loadRMSString(string fileName)
	{
		sbyte[] array = loadRMS(fileName);
		if (array == null)
		{
			return null;
		}
		DataInputStream2 dataInputStream = new DataInputStream2(array);
		try
		{
			string result = dataInputStream.readUTF();
			dataInputStream.close();
			return result;
		}
		catch (Exception ex)
		{
			Cout2.println(ex.StackTrace);
		}
		return null;
	}

	public static byte[] convertSbyteToByte(sbyte[] var)
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

	public static void saveRMSString(string filename, string data)
	{
		DataOutputStream2 dataOutputStream = new DataOutputStream2();
		try
		{
			dataOutputStream.writeUTF(data);
			saveRMS(filename, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
			Cout2.println(ex.StackTrace);
		}
	}

	private static void _saveRMS(string filename, sbyte[] data)
	{
		if (status != 0)
		{
			Debug.LogError("Cannot save RMS " + filename + " because current is saving " + Rms2.filename);
			return;
		}
		Rms2.filename = filename;
		Rms2.data = data;
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
			Debug.LogError("TOO LONG TO SAVE RMS " + filename);
		}
	}

	private static sbyte[] _loadRMS(string filename)
	{
		if (status != 0)
		{
			Debug.LogError("Cannot load RMS " + filename + " because current is loading " + Rms2.filename);
			return null;
		}
		Rms2.filename = filename;
		data = null;
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
			Debug.LogError("TOO LONG TO LOAD RMS " + filename);
		}
		return data;
	}

	public static void update()
	{
		if (status == 2)
		{
			status = 1;
			__saveRMS(filename, data);
			status = 0;
		}
		else if (status == 3)
		{
			status = 1;
			data = __loadRMS(filename);
			status = 0;
		}
	}

	public static int loadRMSInt(string file)
	{
		sbyte[] array = loadRMS(file);
		return (array != null) ? array[0] : (-1);
	}

	public static void saveRMSInt(string file, int x)
	{
		try
		{
			saveRMS(file, new sbyte[1] { (sbyte)x });
		}
		catch (Exception)
		{
		}
	}

	public static string GetiPhoneDocumentsPath()
	{
		return Application.persistentDataPath + "/second";
	}

	private static void __saveRMS(string filename, sbyte[] data)
	{
		string text = GetiPhoneDocumentsPath() + "/" + filename;
		string directory = Path.GetDirectoryName(text);
		if (!Directory.Exists(directory))
		{
			Directory.CreateDirectory(directory);
		}
		FileStream fileStream = new FileStream(text, FileMode.Create);
		fileStream.Write(ArrayCast2.cast(data), 0, data.Length);
		fileStream.Flush();
		fileStream.Close();
		Main2.setBackupIcloud(text);
	}

	private static sbyte[] __loadRMS(string filename)
	{
		try
		{
			string dir = GetiPhoneDocumentsPath() + "/" + filename;
			FileStream fileStream = new FileStream(dir, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			sbyte[] array2 = ArrayCast2.cast(array);
			return ArrayCast2.cast(array);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static void clearAll()
	{
		Cout2.LogError3("clean rms");
		DirectoryInfo di = new DirectoryInfo(GetiPhoneDocumentsPath() + "/");
		try
		{
			if (di.Exists)
			{
				FileInfo[] files = di.GetFiles();

				foreach (FileInfo fileInfo in files)
				{
					fileInfo.Delete();
				}
			}
		}
		catch
		{
			MainMod.Log("clearAll");
		}
	}

	public static void DeleteStorage(string path)
	{
		try
		{
			File.Delete(GetiPhoneDocumentsPath() + "/" + path);
		}
		catch (Exception)
		{
		}
	}

	public static string ByteArrayToString(byte[] ba)
	{
		string text = BitConverter.ToString(ba);
		return text.Replace("-", string.Empty);
	}

	public static byte[] StringToByteArray(string hex)
	{
		int length = hex.Length;
		byte[] array = new byte[length / 2];
		for (int i = 0; i < length; i += 2)
		{
			array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
		}
		return array;
	}

	public static void deleteRecord(string name)
	{
		try
		{
			PlayerPrefs.DeleteKey(name);
		}
		catch (Exception ex)
		{
			Cout2.println("loi xoa RMS --------------------------" + ex.ToString());
		}
	}

	public static void clearRMS()
	{
		deleteRecord("data");
		deleteRecord("dataVersion");
		deleteRecord("map");
		deleteRecord("mapVersion");
		deleteRecord("skill");
		deleteRecord("killVersion");
		deleteRecord("item");
		deleteRecord("itemVersion");
	}
}
