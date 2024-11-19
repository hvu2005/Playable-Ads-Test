using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _data;
    private int hp;
    void Start()
    {
        hp = _data.hp;    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(DyingExplosive());
        }
        if(collision.CompareTag("Bullet"))
        {
            hp--;
            if(hp == 0 )
            {
                StartCoroutine(DyingExplosive());
            }
        }
    }
    private IEnumerator DyingExplosive()
    {
        GetComponent<Animator>().SetTrigger("isDead");
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.45f);
        Destroy(gameObject);
    }
}
