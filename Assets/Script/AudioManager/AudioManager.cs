using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioData _data { get; private set; }

    private AudioSource backGroundMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
