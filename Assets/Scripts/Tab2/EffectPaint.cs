public class EffectPaint2
{
	public int index;

	public Mob2 eMob;

	public Char2 eChar;

	public EffectCharPaint2 effCharPaint;

	public bool isFly;

	public int getImgId()
	{
		return effCharPaint.arrEfInfo[index].idImg;
	}
}
