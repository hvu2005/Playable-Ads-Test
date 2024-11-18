using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager Data", menuName = "ScriptableObjects/GameManager Data", order = 2)]
public class GameManagerData : ScriptableObject
{
    public GameObject canvas;
    public GameObject taptap;
    public GameObject takeDmgVfx;
    public GameObject[] phase;
}
