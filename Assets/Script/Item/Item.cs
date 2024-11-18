using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;


public class Item : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fallSpeed;
    [SerializeField] private GameObject effect;
    private PlayerBehave player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehave>();
    }
    // Update is called once per frame
    void Update()
    {
        if(effect != null)
        {
            effect.transform.Rotate(0f, 0f, 300f * Time.deltaTime);
        }
        if (transform.position.y < -6f)
        {
            gameObject.SetActive(false);
            return;
        }
        if (InputManager.instance.isInteracting)
        {
            Moving();
        }
    }
    private void Moving()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 1.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            if (distance < 0.1f) gameObject.SetActive(false);
        }
        else
        {
            transform.position += new Vector3(0f, -fallSpeed * Time.deltaTime, 0f);
        }
    }
    
}
