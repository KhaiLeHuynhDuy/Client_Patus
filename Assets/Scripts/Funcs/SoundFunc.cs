using System;
using System.Threading;
using UnityEngine;

public class SoundFunc : MonoBehaviour
{
    public static int AIR_SHIP;

    public static int RAIN = 1;

    public static int TAITAONANGLUONG = 2;

    public static int GET_ITEM;

    public static int MOVE = 1;

    public static int LOW_PUNCH = 2;

    public static int LOW_KICK = 3;

    public static int FLY = 4;

    public static int JUMP = 5;

    public static int PANEL_OPEN = 6;

    public static int BUTTON_CLOSE = 7;

    public static int BUTTON_CLICK = 8;

    public static int MEDIUM_PUNCH = 9;

    public static int MEDIUM_KICK = 10;

    public static int PANEL_CLICK = 11;

    public static int EAT_PEAN = 12;

    public static int OPEN_DIALOG = 13;

    public static int NORMAL_KAME = 14;

    public static int NAMEK_KAME = 15;

    public static int XAYDA_KAME = 16;

    public static int EXPLODE_1 = 17;

    public static int EXPLODE_2 = 18;

    public static int TRAIDAT_KAME = 19;

    public static int HP_UP = 20;

    public static int THAIDUONGHASAN = 21;

    public static int HOISINH = 22;

    public static int GONG = 23;

    public static int KHICHAY = 24;

    public static int BIG_EXPLODE = 25;

    public static int NAMEK_LAZER = 26;

    public static int NAMEK_CHARGE = 27;

    public static int RADAR_CLICK = 28;

    public static int RADAR_ITEM = 29;

    public static int FIREWORK = 30;

    public static int KAMEX10_0 = 31;

    public static int KAMEX10_1 = 32;

    public static int DESTROY_0 = 33;

    public static int DESTROY_1 = 34;

    public static int MAFUBA_0 = 35;

    public static int MAFUBA_1 = 36;

    public static int MAFUBA_2 = 37;

    public static int DESTROY_2 = 38;

    public static int status;

    public static int postem;

    private static string filenametemp;

    public static bool stopAll;

    public static AudioSource SoundWater;

    public static AudioSource SoundRun;

    public static AudioSource SoundBGLoop;

    public static AudioClip[] music;

    public static GameObject[] player;

    public static int l1;

    public static int fromScene = 0;

    public static void init()
    {
        GameObject gameObject = new()
        {
            name = "Audio Player"
        };
        gameObject.transform.position = Vector3.zero;
        gameObject.AddComponent<AudioListener>();
        SoundBGLoop = gameObject.AddComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public static void init(int[] musicID, int[] sID)
    {
        if (player == null && music == null)
        {
            init();
            l1 = musicID.Length;
            player = new GameObject[musicID.Length + sID.Length];
            music = new AudioClip[musicID.Length + sID.Length];
            for (int i = 0; i < player.Length; i++)
            {
                string fileName = (i >= l1) ? ("/sound/" + (i - l1)) : ("/music/" + i);
                getAssetSoundFile(fileName, i);
            }
        }
    }

    public static void playSound(int id, float volume, int from)
    {
        fromScene = from;
        play(id + l1, volume);
    }

    public static void playSound1(int id, float volume)
    {
        play(id, volume);
    }

    public static void getAssetSoundFile(string fileName, int pos)
    {
        try
        {
            stop(pos);
            string empty = string.Empty;
            empty = "res" + fileName;
            load(empty, pos);
        }
        catch (Exception)
        {
        }
    }

    public static void stopAllz()
    {
        for (int i = 0; i < music.Length; i++)
        {
            stop(i);
        }
        sTopSoundBG();
    }

    public static void sTopSoundRun()
    {
        SoundRun.GetComponent<AudioSource>().Stop();
    }

    public static bool isPlayingSound()
    {
        if (SoundRun == null)
        {
            return false;
        }
        return SoundRun.GetComponent<AudioSource>().isPlaying;
    }

    public static void stopSoundNatural(int id)
    {
        SoundWater.GetComponent<AudioSource>().Stop();
    }

    public static void playMus(int type, float vl, bool loop, int from)
    {
        fromScene = from;
        vl -= 0.3f;
        if (vl <= 0f)
        {
            vl = 0.01f;
        }
        playSoundBGLoop(type, vl);
    }

    public static bool isPlayingSoundBG(int id)
    {
        if (SoundBGLoop == null)
        {
            return false;
        }
        return SoundBGLoop.GetComponent<AudioSource>().isPlaying;
    }

    public static void load(string filename, int pos)
    {
        if (Thread.CurrentThread.Name == Main.mainThreadName)
        {
            __load(filename, pos);
        }
        else
        {
            _load(filename, pos);
        }
    }

    private static void _load(string filename, int pos)
    {
        if (status != 0)
        {
            Cout.LogError("CANNOT LOAD AUDIO " + filename + " WHEN LOADING " + filenametemp);
            return;
        }
        filenametemp = filename;
        postem = pos;
        status = 2;
        int i;
        for (i = 0; i < 100; i++)
        {
            Thread.Sleep(5);
            if (status == 0)
            {
                break;
            }
        }
        if (i == 100)
        {
            Cout.LogError("TOO LONG FOR LOAD AUDIO " + filename);
            return;
        }
        Cout.Log("Load Audio " + filename + " done in " + i * 5 + "ms");
    }

    private static void __load(string filename, int pos)
    {
        music[pos] = (AudioClip)Resources.Load(filename, typeof(AudioClip));
        GameObject.Find("Main Camera").AddComponent<AudioSource>();
        player[pos] = GameObject.Find("Main Camera");
    }

    public static void start(float volume, int pos)
    {
        if (Thread.CurrentThread.Name == Main.mainThreadName)
        {
            __start(volume, pos);
        }
        else
        {
            _start(volume, pos);
        }
    }

    public static void _start(float volume, int pos)
    {
        if (status != 0)
        {
            return;
        }
        postem = pos;
        status = 3;
        int i;
        for (i = 0; i < 100; i++)
        {
            Thread.Sleep(5);
            if (status == 0)
            {
                break;
            }
        }
    }

    public static void __start(float volume, int pos)
    {
        if (!(player[pos] == null))
        {
            player[pos].GetComponent<AudioSource>().PlayOneShot(music[pos], volume);
        }
    }

    public static void stop(int pos)
    {
        if (Thread.CurrentThread.Name == Main.mainThreadName)
        {
            __stop(pos);
        }
        else
        {
            _stop(pos);
        }
    }

    public static void _stop(int pos)
    {
        if (status != 0)
        {
            Debug.LogError("CANNOT STOP AUDIO WHEN STOPPING");
            return;
        }
        postem = pos;
        status = 4;
        int i;
        for (i = 0; i < 100; i++)
        {
            Thread.Sleep(5);
            if (status == 0)
            {
                break;
            }
        }
        if (i == 100)
        {
            Debug.LogError("TOO LONG FOR STOP AUDIO");
        }
        else
        {
            Debug.Log("Stop Audio done in " + i * 5 + "ms");
        }
    }

    public static void __stop(int pos)
    {
        if (player[pos] != null)
        {
            player[pos].GetComponent<AudioSource>().Stop();
        }
    }

    public static void play(int id, float volume)
    {
        string currentSceneName;
        try
        {
            currentSceneName = SceneSwitcher.GetCurrSceneName();
        }
        catch (Exception)
        {
            return;
        }
        if (fromScene == 0 && currentSceneName == MainMod.sceneName)
        {
            if (GameCanvas.isPlaySound)
            {
                start(volume, id);
            }
        }
        if (fromScene == 1 && currentSceneName == MainMod2.sceneName)
        {
            if (GameCanvas2.isPlaySound)
            {
                start(volume, id);
            }
        }
    }

    public static void sTopSoundBG()
    {
        SoundBGLoop.GetComponent<AudioSource>().Stop();
    }

    public static void playSoundBGLoop(int id, float volume)
    {
        string currentSceneName;
        try
        {
            currentSceneName = SceneSwitcher.GetCurrSceneName();
        }
        catch (Exception)
        {
            return;
        }
        if (fromScene == 0 && currentSceneName == MainMod.sceneName)
        {
            if (GameCanvas.isPlaySound)
            {
                PlaySoundBGLoop_(id, volume);
            }
        }
        if (fromScene == 1 && currentSceneName == MainMod2.sceneName)
        {
            if (GameCanvas2.isPlaySound)
            {
                PlaySoundBGLoop_(id, volume);
            }
        }
    }

    public static void PlaySoundBGLoop_(int id, float volume)
    {
        if (id == AIR_SHIP)
        {
            playSound1(id, volume + 0.2f);
        }
        else if (!(SoundBGLoop == null) && !isPlayingSoundBG(id))
        {
            SoundBGLoop.GetComponent<AudioSource>().loop = true;
            SoundBGLoop.GetComponent<AudioSource>().clip = music[id];
            SoundBGLoop.GetComponent<AudioSource>().volume = volume;
            SoundBGLoop.GetComponent<AudioSource>().Play();
        }
    }
}
