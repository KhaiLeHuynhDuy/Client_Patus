public class InputStream2 : myReader2
{
	public InputStream2()
	{
	}

	public InputStream2(sbyte[] data)
	{
		buffer = data;
	}

	public InputStream2(string filename)
		: base(filename)
	{
	}
}
