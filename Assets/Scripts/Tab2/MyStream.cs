using System;

public class MyStream2
{
	public static DataInputStream2 readFile(string path)
	{
		path = Main2.res + path;
		try
		{
			return DataInputStream2.getResourceAsStream(path);
		}
		catch (Exception)
		{
			return null;
		}
	}
}
