using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameManagerData _data;

    private GameObject canvas;
    private GameObject taptap;
    private GameObject takeDmgVfx;
    //instantiate data
    private void InstantiateData()
    {
        canvas = Instantiate(_data.canvas);
        takeDmgVfx = Instantiate(_data.takeDmgVfx, canvas.transform);
        taptap = Instantiate(_data.taptap, canvas.transform);
        DontDestroyOnLoad(canvas);
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        InstantiateData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region takeDmg
    public void PlayerTakeDmg()
    {
        StartCoroutine(TakeDmg());
    }
    private IEnumerator TakeDmg()
    {
        takeDmgVfx.SetActive(true);
        yield return new WaitForSeconds(1f);
        takeDmgVfx.SetActive(false);
    }
    #endregion
}
