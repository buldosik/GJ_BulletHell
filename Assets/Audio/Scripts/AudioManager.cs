using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    private void Awake() {

        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return; 
        }   
        DontDestroyOnLoad(gameObject);
        //GlobalCache.Inst.LoadData();
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            //    s.source.volume = s.volume * GlobalCache.Inst.MusicLevel;
            
            s.source.volume = s.volume;// * GlobalCache.Inst.SoundLevel;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    private void Start() {
        Play("Theme");
    }
    // FindObjectOfType<AudioManager().Play("");
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.Log("Sound: " + name + " wasn't found.");
            return;
        }
        s.source.Play();
    }
    public void Reload()
    {
        //GlobalCache.Inst.LoadData();
        AudioSource[] sources = GetComponents<AudioSource>();
        foreach(AudioSource sr in sources)
        {
            foreach (Sound sd in sounds)
            {
                if(sd.clip == sr.clip)
                {
                    sr.volume = sd.volume;// * GlobalCache.Inst.SoundLevel;
                    sr.pitch = sd.pitch;
                    sr.loop = sd.loop;
                }
            }
        }
    }
}
