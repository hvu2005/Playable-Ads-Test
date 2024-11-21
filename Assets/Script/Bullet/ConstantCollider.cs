using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantCollider : MonoBehaviour
{
    private Vector2 originSize;
    private CapsuleCollider2D triggerBox;
    // Start is called before the first frame update
    void Start()
    {
        originSize = GetComponent<CapsuleCollider2D>().size;
        triggerBox = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        triggerBox.size = originSize;
    }
}
