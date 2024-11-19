using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioData _data;

    [SerializeField] private AudioSource[] audio;

    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null) { instance = this; }
        else { Destroy(gameObject); }
        audio[0].clip = _data.backGroundSound;
        audio[0].Play();
    }
    public void PlayOnShot(int index, AudioClip clip)
    {
        audio[index].PlayOneShot(clip);
    }
}
