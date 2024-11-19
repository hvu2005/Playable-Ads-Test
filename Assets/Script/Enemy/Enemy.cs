using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private int hp;
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
        AudioManager.instance.PlayOnShot(2,AudioManager.instance._data.explosiveSound);
        yield return new WaitForSeconds(0.45f);
        GameManager.instance.ItemDropPosition(transform.position);
        GameManager.instance.killCount++;
        gameObject.SetActive(false);
    }
}
