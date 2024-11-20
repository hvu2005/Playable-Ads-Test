using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        float elapseTime = 0f;
        while(elapseTime < 0.95f)
        {
            elapseTime += Time.deltaTime;
            transform.position += new Vector3(0f, -4f*Time.deltaTime, 0f);
            yield return null;
        }
    }
}
