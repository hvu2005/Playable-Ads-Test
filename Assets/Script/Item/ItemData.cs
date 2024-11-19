using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Buff stat", menuName = "ScriptableObjects/Item", order = 3)]
public class ItemData : ScriptableObject
{
    public float bonusAttackSpeed;
    public int bonusLevel;
    public bool intoSuperior; //hoa sieu nhan
}
