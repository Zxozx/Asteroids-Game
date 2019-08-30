using UnityEngine.Audio;
using System;
using UnityEngine;

namespace Asteroids
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;

        public static AudioManager instance;

        public bool isPlaying = false;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.playOnAwake = s.playOnAwake;
            }
        }

        void Start()
        {
            Play("MainTheme");
        }

        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null) return;
            s.source.Play();
            isPlaying = s.source.isPlaying;
        }

        public void Stop(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Stop();
        }
    }
}