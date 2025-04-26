using System;

internal class ImageSource2
{
    public sbyte version;

    public string id;

    public static MyVector2 vSource = new MyVector2();

    public static MyVector2 vRms = new MyVector2();

    public ImageSource2(string ID, sbyte version)
    {
        id = ID;
        this.version = version;
    }

    public static void checkRMS()
    {
        MyVector2 myVector = new MyVector2();
        sbyte[] array = Rms2.loadRMS("ImageSource");
        if (array == null)
        {
            Service2.gI().imageSource(myVector);
            return;
        }
        vRms = new MyVector2();
        DataInputStream2 dataInputStream = new DataInputStream2(array);
        if (dataInputStream == null)
        {
            return;
        }
        try
        {
            short num = dataInputStream.readShort();
            string[] array2 = new string[num];
            sbyte[] array3 = new sbyte[num];
            for (int i = 0; i < num; i++)
            {
                array2[i] = dataInputStream.readUTF();
                array3[i] = dataInputStream.readByte();
                vRms.addElement(new ImageSource2(array2[i], array3[i]));
            }
            dataInputStream.close();
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        Service2.gI().imageSource(myVector);
    }

    public static sbyte getVersionRMSByID(string id)
    {
        for (int i = 0; i < vRms.size(); i++)
        {
            if (id.Equals(((ImageSource2)vRms.elementAt(i)).id))
            {
                return ((ImageSource2)vRms.elementAt(i)).version;
            }
        }
        return -1;
    }

    public static sbyte getCurrVersionByID(string id)
    {
        for (int i = 0; i < vSource.size(); i++)
        {
            if (id.Equals(((ImageSource2)vSource.elementAt(i)).id))
            {
                return ((ImageSource2)vSource.elementAt(i)).version;
            }
        }
        return -1;
    }

    public static bool isExistID(string id)
    {
        for (int i = 0; i < vRms.size(); i++)
        {
            if (id.Equals(((ImageSource2)vRms.elementAt(i)).id))
            {
                return true;
            }
        }
        return false;
    }

    public static void saveRMS()
    {
        DataOutputStream2 dataOutputStream = new DataOutputStream2();
        try
        {
            dataOutputStream.writeShort((short)vSource.size());
            for (int i = 0; i < vSource.size(); i++)
            {
                dataOutputStream.writeUTF(((ImageSource2)vSource.elementAt(i)).id);
                dataOutputStream.writeByte(((ImageSource2)vSource.elementAt(i)).version);
            }
            Rms2.saveRMS("ImageSource", dataOutputStream.toByteArray());
            dataOutputStream.close();
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
    }
}
