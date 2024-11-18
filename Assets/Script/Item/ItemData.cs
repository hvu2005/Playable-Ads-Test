using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item data", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemData : ScriptableObject
{
    public GameObject itemObject;
    public string itemName;
    public int itemIndex;
    public GameObject effect;
}
