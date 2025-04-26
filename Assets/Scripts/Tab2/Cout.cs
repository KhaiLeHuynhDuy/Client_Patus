using UnityEngine;

public class Cout2
{
	public static int count;

	public static void println(string s)
	{
		if (mSystem2.isTest)
		{
			Debug.Log(((count % 2 != 0) ? "***--- " : ">>>--- ") + s);
			count++;
		}
	}

	public static void Log(string str)
	{
		if (mSystem2.isTest)
		{
			Debug.Log(str);
		}
	}

	public static void LogError(string str)
	{
		if (mSystem2.isTest)
		{
			Debug.LogError(str);
		}
	}

	public static void LogError2(string str)
	{
		if (!mSystem2.isTest)
		{
		}
	}

	public static void LogError3(string str)
	{
		if (mSystem2.isTest)
		{
			Debug.LogError(str);
		}
	}

	public static void LogWarning(string str)
	{
		if (mSystem2.isTest)
		{
			Debug.LogWarning(str);
		}
	}
}
