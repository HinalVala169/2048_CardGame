using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] public AudioSource audioSource;
    public Audio[] clips;


    void Start()
    {
        instance = this;
    }

    public void MuteAndUnmute()
    {
        audioSource.mute = !audioSource.mute;
    }
    public void PlayAudio(AudioName name)
    {
        foreach (var item in clips)
        {
            if (item.name == name)
            {
                audioSource.PlayOneShot(item.clip);


                break;
            }
        }
    }


    public void PlayAudioBG(AudioName name)
    {

        foreach (var item in clips)
        {
            if (item.name == name)
            {
                audioSource.clip = item.clip;
                audioSource.Play();
                break;
            }
        }
    }
    }
    [System.Serializable]
    public class Audio
    {
        public AudioName name;
        public AudioClip clip;
    }


    public enum AudioName
    {
        Card,
        Merge,
        Score,
        ButtonClick,
        GameOver,
        DisCard,
        

        GameBG,
    }

