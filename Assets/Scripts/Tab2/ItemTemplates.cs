public class ItemTemplates2
{
	public static MyHashTable2 itemTemplates = new MyHashTable2();

	public static void add(ItemTemplate2 it)
	{
		itemTemplates.put(it.id, it);
	}

	public static ItemTemplate2 get(short id)
	{
		return (ItemTemplate2)itemTemplates.get(id);
	}

	public static short getPart(short itemTemplateID)
	{
		return get(itemTemplateID).part;
	}

	public static short getIcon(short itemTemplateID)
	{
		return get(itemTemplateID).iconID;
	}
}
