using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Audio Data", menuName = "ScriptableObjects/Audio Data", order = 4)]
public class AudioData : ScriptableObject
{
    public AudioClip backGroundSound;
    public AudioClip shootingSound;
    public AudioClip explosiveSound;
    public AudioClip obtainItem;
    public AudioClip intoSuperiorSound;
}
