using System;

public class NinjaUtil2
{
	public static void onLoadMapComplete()
	{
		GameCanvas2.endDlg();
	}

	public void onLoading()
	{
		GameCanvas2.startWaitDlg(mResources2.downloading_data);
	}

	public static int randomNumber(int max)
	{
		MyRandom2 myRandom = new MyRandom2();
		return myRandom.nextInt(max);
	}

	public static sbyte[] readByteArray(Message2 msg)
	{
		try
		{
			int length = msg.reader().readInt();
			if (length > 1)
			{
				sbyte[] data = new sbyte[length];
				msg.reader().read(ref data);
				return data;
			}
		}
		catch (Exception)
		{
		}
		return null;
	}

	public static sbyte[] readByteArray(myReader2 dos)
	{
		try
		{
			int num = dos.readInt();
			sbyte[] data = new sbyte[num];
			dos.read(ref data);
			return data;
		}
		catch (Exception)
		{
			Cout2.LogError("LOI DOC readByteArray dos  NINJAUTIL");
		}
		return null;
	}

	public static string Replace(string text, string regex, string replacement)
	{
		return text.Replace(regex, replacement);
	}

	public static string NumberTostring(string number)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		if (number.Equals(string.Empty))
		{
			return text;
		}
		if (number[0] == '-')
		{
			text2 = "-";
			number = number[1..];
		}
		for (int num = number.Length - 1; num >= 0; num--)
		{
			text = ((number.Length - 1 - num) % 3 != 0 || number.Length - 1 - num <= 0) ? (number[num] + text) : (number[num] + "." + text);
		}
		return text2 + text;
	}

	public static string NumberTostring2(long num)
	{
		if (num >= 1_000_000_000)
		{
			return $"{num / 1_000_000_000:0.0}B";
		}
		else if (num >= 1_000_000)
		{
			return $"{num / 1_000_000:0.0}M";
		}
		else if (num >= 1_000)
		{
			return $"{num / 1_000:0.0}K";
		}
		else
		{
			return num.ToString();
		}
	}

	public static string getDate(int second)
	{
		long num = (long)second * 1000L;
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Add(new TimeSpan(num * 10000)).ToUniversalTime();
		int hour = dateTime.Hour;
		int minute = dateTime.Minute;
		int day = dateTime.Day;
		int month = dateTime.Month;
		int year = dateTime.Year;
		return day + "/" + month + "/" + year + " " + hour + "h";
	}

	public static string getDate2(long second)
	{
		long num = second + 25200000;
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Add(new TimeSpan(num * 10000)).ToUniversalTime();
		int hour = dateTime.Hour;
		int minute = dateTime.Minute;
		return hour + "h" + minute + "m";
	}

	public static string getTime(int timeRemainS)
	{
		int num = 0;
		if (timeRemainS > 60)
		{
			num = timeRemainS / 60;
			timeRemainS %= 60;
		}
		int num2 = 0;
		if (num > 60)
		{
			num2 = num / 60;
			num %= 60;
		}
		int num3 = 0;
		if (num2 > 24)
		{
			num3 = num2 / 24;
			num2 %= 24;
		}
		string empty = string.Empty;
		if (num3 > 0)
		{
			empty += num3;
			empty += "d";
			return empty + num2 + "h";
		}
		if (num2 > 0)
		{
			empty += num2;
			empty += "h";
			return empty + num + "'";
		}
		empty = ((num <= 9) ? (empty + "0" + num) : (empty + num));
		empty += ":";
		if (timeRemainS > 9)
		{
			return empty + timeRemainS;
		}
		return empty + "0" + timeRemainS;
	}

	public static string getMoneys(long m)
	{
		string text = string.Empty;
		long num = m / 1000 + 1;
		for (int i = 0; i < num; i++)
		{
			if (m >= 1000)
			{
				long num2 = m % 1000;
				text = ((num2 != 0) ? ((num2 >= 10) ? ((num2 >= 100) ? ("." + num2 + text) : (".0" + num2 + text)) : (".00" + num2 + text)) : (".000" + text));
				m /= 1000;
				continue;
			}
			text = m + text;
			break;
		}
		return text;
	}

	public static string getTimeAgo(long timeRemainS)
	{
		long num = 0;
		if (timeRemainS > 60)
		{
			num = timeRemainS / 60;
		}
		long num2 = 0;
		if (num > 60)
		{
			num2 = num / 60;
			num %= 60;
		}
		long num3 = 0;
		if (num2 > 24)
		{
			num3 = num2 / 24;
			num2 %= 24;
		}
		string empty = string.Empty;
		if (num3 > 0)
		{
			empty += num3;
			empty += "d";
			return empty + num2 + "h";
		}
		if (num2 > 0)
		{
			empty += num2;
			empty += "h";
			return empty + num + "'";
		}
		if (num == 0)
		{
			num = 1;
		}
		empty += num;
		return empty + "p";
	}

	public static string[] split(string original, string separator)
	{
		MyVector2 myVector = new MyVector2();
		for (int num = original.IndexOf(separator); num >= 0; num = original.IndexOf(separator))
		{
			myVector.addElement(original.Substring(0, num));
			original = original.Substring(num + separator.Length);
		}
		myVector.addElement(original);
		string[] array = new string[myVector.size()];
		if (myVector.size() > 0)
		{
			for (int i = 0; i < myVector.size(); i++)
			{
				array[i] = (string)myVector.elementAt(i);
			}
		}
		return array;
	}

	public static bool checkNumber(string numberStr)
	{
		try
		{
			int.Parse(numberStr);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
