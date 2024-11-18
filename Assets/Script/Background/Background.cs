using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Background : MonoBehaviour
{
    [Range(-10f,10f)]
    [SerializeField] private float moveSpeed;
    private float offset;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += moveSpeed*Time.deltaTime;
        material.SetTextureOffset("_MainTex", new Vector2(0f, offset));
    }
}
