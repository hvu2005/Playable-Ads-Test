using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2 : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject bolatoas;
    [SerializeField] private float moveSpeed;
    private Vector3 spawnPosition;
    private float yOffset;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position + new Vector3(-1.8f,7f,0f);
        for(int i = 0; i < enemies.Length; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                for(int k = 0; k < 7; k++)
                {
                    Instantiate(enemies[i], spawnPosition + new Vector3(0.6f*k, yOffset, 0f), Quaternion.identity,transform);
                }
                yOffset += 0.7f;
            }
        }
        Instantiate(bolatoas, spawnPosition + new Vector3(0.6f*3f,yOffset,0f), Quaternion.identity,transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, -moveSpeed * Time.deltaTime, 0f);
        if (transform.position.y < -50f)
        {
            GameManager.instance.forceToNextPhase = true;
            gameObject.SetActive(false);
        }
    }
}
