using UnityEngine;
using UnityEngine.Networking;

internal class Net2
{
	//public static UnityWebRequest www;

	public static Command2 h;

	//public static void update()
	//{
	//	if (www != null && www.isDone)
	//	{
	//		string str = string.Empty;
	//		if (www.error == null || www.error.Equals(string.Empty))
	//		{
	//			str = www.;
	//		}
	//		www = null;
	//		if (h != null)
	//		{
	//			h.perform(str);
	//		}
	//	}
	//}

	//public static void connectHTTP(string link, Command h)
	//{
	//	if (www != null)
	//	{
	//		Cout.LogError("GET HTTP BUSY");
	//	}
	//	www = new UnityWebRequest(link);
	//	Net.h = h;
	//}

	public static void connectHTTP2(string link, Command2 h)
	{
		Net2.h = h;
		if (link != null)
		{
			h.perform(link);
		}
	}
}
