public class SkillOption2
{
	public int param;

	public SkillOptionTemplate2 optionTemplate;

	public string optionString;

	public string getOptionString()
	{
		if (optionString == null)
		{
			optionString = NinjaUtil2.Replace(optionTemplate.name, "#", string.Empty + param);
		}
		return optionString;
	}
}
