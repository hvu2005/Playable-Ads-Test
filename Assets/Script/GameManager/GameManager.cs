using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameManagerData _data;
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject upgradingItem;
    public int killCount = 0;
    //~~~~~~~~~~ItemSystem~~~~~~~~~~
    private int itemDropCount = 1;
    private Vector3 itemDropPos;
    private int itemCount;
    public bool isObtaningItem;
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private GameObject canvas;
    private GameObject taptap;
    private GameObject takeDmgVfx;
    private GameObject[] phases;
    private int currentPhase;
    public bool forceToNextPhase;
    //instantiate data
    private void InstantiateData()
    {
        phases = new GameObject[_data.phases.Length];
        for (int i = 0; i < _data.phases.Length; i++)
        {
            phases[i] = Instantiate(_data.phases[i]);
            phases[i].SetActive(false);
        }
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
        phases[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.isInteracting)
        {
            taptap.SetActive(false);
        }
        if((killCount == 39 && phases[0].activeSelf) || forceToNextPhase)
        {
            IntoNextPhase();
        }
        DropItem();
    }
    private void DropItem()
    {
        if(killCount >= itemDropCount && itemCount < 4)
        {
            itemDropCount += 4;
            itemCount++;
            if(itemCount < 4)
            {
                Instantiate(item, itemDropPos, Quaternion.identity);
            }
            else
            {
                Instantiate(upgradingItem,itemDropPos, Quaternion.identity);    
            }
        }
    }
    private void IntoNextPhase()
    {
        phases[currentPhase].SetActive(false);
        if(currentPhase < phases.Length - 1)
        {
            phases[++currentPhase].SetActive(true);
        }
        forceToNextPhase = false;
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
    public void ItemDropPosition(Vector3 pos)
    {
        itemDropPos = pos;
    }
    public void StartGlobalCoroutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }
}
