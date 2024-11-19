using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;


public class Item : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fallSpeed;
    [SerializeField] private GameObject effect;
    private bool canMove;
    private Vector3 originPos;
    private PlayerBehave player;
    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position + new Vector3(0.35f,0.35f,0f);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehave>();
        StartCoroutine(Spawning());
    }
    // Update is called once per frame
    void Update()
    {
        if(effect != null)
        {
            effect.transform.Rotate(0f, 0f, 300f * Time.deltaTime);
        }
        if (!canMove)
        {
            return;
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
    private IEnumerator Spawning()
    {
        canMove = false;
        while (Vector2.Distance(transform.position,originPos) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, originPos, moveSpeed*Time.deltaTime/3);
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        canMove = true;
    }
    private void Moving()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 1.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            if (distance < 0.1f)
            {
                gameObject.SetActive(false);
                GameManager.instance.isObtaningItem = true;
            }
        }
        else
        {
            transform.position += new Vector3(0f, -fallSpeed * Time.deltaTime, 0f);
        }
    }
    
}
