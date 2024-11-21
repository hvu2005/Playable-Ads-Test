using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ObjectPooling explosivePool;
    [SerializeField] private int hp;
    public float yPosition;
    private void Start()
    {
        explosivePool = GameObject.FindGameObjectWithTag("Explosive").GetComponent<ObjectPooling>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(DyingExplosion());
        }
        if(collision.CompareTag("Bullet"))
        {
            hp--;
            if(hp == 0 )
            {
                StartCoroutine(DyingExplosion());
                return;
            }
            Explosive(collision);
        }
    }
    private void Explosive(Collider2D collision)
    {
        GameObject explosive = explosivePool.GetObject();
        explosive.transform.position = collision.ClosestPoint(transform.position);
        GameManager.instance.StartGlobalCoroutine(ReturnObject(explosive, 0.5f));
    }
    private IEnumerator ReturnObject(GameObject explosive, float time)
    {
        yield return new WaitForSeconds(time);
        explosivePool.ReturnObject(explosive);
    }
    private IEnumerator DyingExplosion()
    {
        GetComponent<Animator>().SetTrigger("isDead");
        GetComponent<BoxCollider2D>().enabled = false;
        AudioManager.instance.PlayOnShot(2,AudioManager.instance._data.explosiveSound);
        yield return new WaitForSeconds(0.45f);
        GameManager.instance.ItemDropPosition(transform.position);
        GameManager.instance.killCount++;
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
    public void SetHp(int hp)
    {
        this.hp = hp;
    }
}
