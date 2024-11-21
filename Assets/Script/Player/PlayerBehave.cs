using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehave : MonoBehaviour
{
    
    private bool isImmortal;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(InputManager.instance.isInteracting)
        {
            transform.position = MousePosition();

        }
    }
    private Vector3 MousePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        return mousePos;
    }
    #region Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerController(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerController(collision);
    }
    private void OnTriggerController(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isImmortal)
        {
            GameManager.instance.PlayerTakeDmg();
            StartCoroutine(Immortal());
        }
        //if(collision.CompareTag("Item"))
        //{

        //}
    }
    #endregion
    private IEnumerator Immortal()
    {
        isImmortal = true;
        float elapsedTime = 0f;
        Color playerColor = GetComponent<SpriteRenderer>().color;
        while (elapsedTime < 2f)
        {
            float t = Mathf.PingPong(Time.time / 0.1f, 1);
            playerColor.a = Mathf.Lerp(1f,0f,t);
            GetComponent<SpriteRenderer>().color = playerColor;
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        playerColor.a = 1f;
        GetComponent<SpriteRenderer>().color = playerColor;
        isImmortal = false;
    }
}
    