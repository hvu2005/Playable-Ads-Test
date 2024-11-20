using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2 : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject bolatoas;
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
        if (transform.position.y < -44f)
        {
            GameManager.instance.forceToNextPhase = true;
            gameObject.SetActive(false);
        }
    }
    private IEnumerator SpawnEnemies()
    {
        spawnPosition = transform.position + new Vector3(-1.8f, 7f, 0f);
        for (int i = 0; i < enemies.Length; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    Instantiate(enemies[i], spawnPosition + new Vector3(0.6f * k, 0f, 0f), Quaternion.identity, transform);
                }
                yield return new WaitForSeconds(0.2f);
            }
        }
        yield return new WaitForSeconds(0.2f);
        Instantiate(bolatoas, spawnPosition + new Vector3(0.6f * 3f, 0f, 0f), Quaternion.identity, transform);
    }
}
