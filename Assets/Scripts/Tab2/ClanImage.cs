public class ClanImage2
{
    public int ID;

    public string name;

    public int[] idImage;

    public int xu;

    public int luong;

    public static MyVector2 vClanImage = new MyVector2();

    public static MyHashTable2 idImages = new MyHashTable2();

    public static void addClanImage(ClanImage2 cm)
    {
        Service2.gI().clanImage((sbyte)cm.ID);
        vClanImage.addElement(cm);
    }

    public static ClanImage2 getClanImage(short ID)
    {
        for (int i = 0; i < vClanImage.size(); i++)
        {
            ClanImage2 clanImage = (ClanImage2)vClanImage.elementAt(i);
            if (clanImage.ID == ID)
            {
                return clanImage;
            }
        }
        return null;
    }

    public static bool isExistClanImage(int ID)
    {
        for (int i = 0; i < vClanImage.size(); i++)
        {
            ClanImage2 clanImage = (ClanImage2)vClanImage.elementAt(i);
            if (clanImage.ID == ID)
            {
                return true;
            }
        }
        return false;
    }
}
