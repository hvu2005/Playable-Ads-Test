using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2 : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject bolatoa;
    [SerializeField] private float moveSpeed;
    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, -moveSpeed * Time.deltaTime, 0f);
        if (transform.position.y < -65f)
        {
            GameManager.instance.forceToNextPhase = true;
            gameObject.SetActive(false);
        }
    }
    private IEnumerator SpawnEnemies()
    {
        spawnPosition = new Vector3(-1.8f, 5f, 0f);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().SetHp(3);
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    GameObject enemy = Instantiate(enemies[i], spawnPosition + new Vector3(0.6f * k, 0f, 0f), Quaternion.identity, transform);
                    StartCoroutine(DestroyEnemy(enemy));
                }
                yield return new WaitForSeconds(0.35f);
            }
        }
        spawnPosition = new Vector3(-1.7f, 5f, 0f);
        bolatoa.GetComponent<Enemy>().SetHp(2);
        for (int i = 0; i < 4; i++)
        {
            GameObject bolatoaEnemy = Instantiate(bolatoa, spawnPosition + new Vector3(1.15f * i, 0f, 0f), Quaternion.identity, transform);
            StartCoroutine (DestroyEnemy(bolatoaEnemy)); 
        }
        yield return new WaitForSeconds(0.35f);
        spawnPosition = new Vector3(-1.15f, 5f, 0f);
        for(int i = 0; i < 3; i++)
        {
            GameObject bolatoaEnemy = Instantiate(bolatoa, spawnPosition + new Vector3(1.15f*i, 0f, 0f), Quaternion.identity, transform);
            StartCoroutine(DestroyEnemy(bolatoaEnemy));
        }
    }
    private IEnumerator DestroyEnemy(GameObject obj)
    {
        yield return new WaitForSeconds(5.5f);
        if(obj != null)
        {
            Destroy(obj);
        }
    }
}
