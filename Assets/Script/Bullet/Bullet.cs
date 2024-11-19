using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    void OnEnable()
    {
        Invoke("TurnOffBullet", 1f);    
    }
    void Update()
    {
        transform.position += new Vector3(0f, moveSpeed * Time.deltaTime, 0f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        TurnOffBullet();
    }
    private void TurnOffBullet()
    {
        FindObjectOfType<ObjectPooling>().ReturnObject(gameObject);
    }
}
