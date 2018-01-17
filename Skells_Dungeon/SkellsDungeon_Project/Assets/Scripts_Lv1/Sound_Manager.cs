using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : Singleton<Sound_Manager>
{
    public enum SoundType
    {
        //Music = 0,
        //SoundEffects = 1,
        BackgroundMusic,
        ItemSound,
        PowerGem

    }
    [SerializeField]
    private AudioSource BackgroundMusic = null;
    [SerializeField]
    private AudioSource ItemSound = null;
    [SerializeField]
    private AudioSource PowerGem = null;


    private List<AudioSource> Audio_List = new List<AudioSource>();
    static private int NUMTYPES = 2;
    static private float[] soundVolume = new float[NUMTYPES];
    private float _fxVolume = 1.0f;


    void Start()
    {
      AddSound(BackgroundMusic);
      AddSound(ItemSound);
      AddSound(PowerGem);
      PlaySound(SoundType.BackgroundMusic);
    }

    public void PlaySound(SoundType sound)
    {
   
        foreach (AudioSource audio in Audio_List)
        {
            if(audio != BackgroundMusic)
            {
                audio.Pause();
            }
            
        }
        switch (sound)
        {
            case SoundType.BackgroundMusic:
                Audio_List[0].Play();
                break;
            case SoundType.ItemSound:
                Audio_List[1].Play();
                break;
            case SoundType.PowerGem:
                Audio_List[2].Play();
                break;

        }
        //sound.Play();
    }

    public void StopSound(SoundType sound)
    {
        switch (sound)
        {
            case SoundType.BackgroundMusic:
                Audio_List[0].Stop();
                break;
            case SoundType.ItemSound:
                Audio_List[1].Stop();
                break;
            case SoundType.PowerGem:
                Audio_List[2].Stop();
                break;

        }
    }
    public void AddSound(AudioSource sound)
    {
        if (sound != null)
        {
            Audio_List.Add(sound);
        }
    }
    public void RemoveSound(AudioSource sound)
    {
        Audio_List.Remove(sound);
    }



    static public float GetVolume(SoundType type)
    {
        return soundVolume[(int)type];
    }

    static public void SetVolume(SoundType type, float volume)
    {
        soundVolume[(int)type] = volume;
    }

    static public void LoadFromPrefs()
    {
        for (SoundType i = 0; (int)i < NUMTYPES; ++i)
        {
            string prefName = "Sound" + i.ToString() + "Volume";
            soundVolume[(int)i] = PlayerPrefs.GetFloat(prefName, 0.5f);
        }
    }

    static public void Save()
    {
        for (SoundType i = 0; (int)i < NUMTYPES; ++i)
        {
            string prefName = "Sound" + i.ToString() + "Volume";
            PlayerPrefs.SetFloat(prefName, soundVolume[(int)i]);
        }
        PlayerPrefs.Save();
    }


    static public void ResetVolumes()
    {
        for (SoundType i = 0; (int)i < NUMTYPES; ++i)
        {
            string prefName = "Sound" + i.ToString() + "Volume";
            PlayerPrefs.SetFloat(prefName, 0.5f);
        }
        LoadFromPrefs();
    }


public float BackAudioVolume
{
    get
    {
        return AudioListener.volume;
    }
    set
    {
        AudioListener.volume = value;
    }
}

    public float FxVolume
    {
        get
        { return _fxVolume; }
        set
        {
            _fxVolume = value;
            ItemSound.volume = _fxVolume;
            PowerGem.volume = _fxVolume;
            BackgroundMusic.volume = _fxVolume;
        }
    }
}
