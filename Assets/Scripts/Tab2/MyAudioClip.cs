using UnityEngine;

public class MyAudioClip2
{
	public string name;

	public AudioClip clip;

	public long timeStart;

	public MyAudioClip2(string filename)
	{
		clip = (AudioClip)Resources.Load(filename);
		name = filename;
	}

	public void Play()
	{
		Main2.main.GetComponent<AudioSource>().PlayOneShot(clip);
		timeStart = mSystem2.currentTimeMillis();
	}

	public bool isPlaying()
	{
		return false;
	}
}
