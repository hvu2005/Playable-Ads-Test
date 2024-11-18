using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSystem : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        int spriteIndex = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
    }

}
