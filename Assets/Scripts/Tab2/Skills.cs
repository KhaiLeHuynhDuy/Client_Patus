public class Skills2
{
	public static MyHashTable2 skills = new MyHashTable2();

	public static void add(Skill2 skill)
	{
		skills.put(skill.skillId, skill);
	}

	public static Skill2 get(short skillId)
	{
		return (Skill2)skills.get(skillId);
	}
}
