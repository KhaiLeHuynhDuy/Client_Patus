public class Message2
{
	public sbyte command;

	private myReader2 dis;

	private myWriter2 dos;

	public Message2(int command)
	{
		this.command = (sbyte)command;
		dos = new myWriter2();
	}

	public Message2()
	{
		dos = new myWriter2();
	}

	public Message2(sbyte command)
	{
		this.command = command;
		dos = new myWriter2();
	}

	public Message2(sbyte command, sbyte[] data)
	{
		this.command = command;
		dis = new myReader2(data);
	}

	public sbyte[] getData()
	{
		return dos.getData();
	}

	public myReader2 reader()
	{
		return dis;
	}

	public myWriter2 writer()
	{
		return dos;
	}

	public int readInt3Byte()
	{
		return dis.readInt();
	}

	public long readLong()
	{
		if (MainMod.isReadInt)
		{
			return dis.readInt();
		}

		return dis.readLong();
	}

	public void cleanup()
	{
	}
}
