using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private int poolSize;
    private List<GameObject> bullets;
    // Start is called before the first frame update
    void Awake()
    {
        bullets = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPref);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
