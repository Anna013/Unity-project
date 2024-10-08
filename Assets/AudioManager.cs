
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    void Start(){
       Play("Forest");

    }

    void Awake()
    {
        foreach(Sound s in sounds){
             s.source = gameObject.AddComponent<AudioSource>();
             s.source.clip = s.clip;

             s.source.volume = s.volume;
             s.source.pitch = s.pitch;
        }
    }

    
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(!s.source.isPlaying){
            s.source.Play();
        }
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s.source.isPlaying){
            s.source.Pause();
        }
    }


    public void Stop(string name){
        
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s.source.isPlaying){
            s.source.Stop();
        }
    }

}
