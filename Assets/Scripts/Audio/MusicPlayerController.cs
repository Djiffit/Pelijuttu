using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerController : MonoBehaviour
{
    private static MusicPlayerController instance = null;
    private AudioSource audioSource;

    public static MusicPlayerController Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            instance.SetMusic(this.gameObject.GetComponent<AudioSource>().clip);
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            audioSource = this.gameObject.GetComponent<AudioSource>();
            audioSource.Play();
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void SetMusic(AudioClip song)
    {
        // Change song if needed
        if (audioSource.clip == null || song.name != audioSource.clip.name)
        {
            audioSource.Stop();
            audioSource.clip = song;
            audioSource.Play();
        }
    }
}
