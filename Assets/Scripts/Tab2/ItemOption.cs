public class ItemOption2
{
	public int param;

	public sbyte active;

	public sbyte activeCard;

	public ItemOptionTemplate2 optionTemplate;

	public ItemOption2()
	{
	}

	public ItemOption2(int optionTemplateId, int param)
	{
		if (optionTemplateId == 22)
		{
			optionTemplateId = 6;
			param *= 1000;
		}
		if (optionTemplateId == 23)
		{
			optionTemplateId = 7;
			param *= 1000;
		}
		this.param = param;
		optionTemplate = GameScr2.gI().iOptionTemplates[optionTemplateId];
	}

	public string getOptionString()
	{
		return NinjaUtil2.Replace(optionTemplate.name, "#", param + string.Empty);
	}

	public string getOptionName()
	{
		return NinjaUtil2.Replace(optionTemplate.name, "+#", string.Empty);
	}

	public string getOptiongColor()
	{
		return NinjaUtil2.Replace(optionTemplate.name, "$", string.Empty);
	}
}
