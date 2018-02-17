using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance = null;

    public AudioClip goalBloop;
    public AudioClip lossBuzz;
    public AudioClip hitPaddleBloop;
    public AudioClip winSound;
    public AudioClip wallBloop;

    private AudioSource soundEffectAudio;

    void Start () {
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource[] sources = GetComponents<AudioSource>();

        foreach (var source in sources)
        {
            if (source.clip == null)    
            {
                soundEffectAudio = source;
            }
        }
    }

    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
	
	void Update () {}
}
