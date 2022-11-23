using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WEAPON_INFO {
    public string name;
    public Sprite sprite;
}


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject {

    public List<WEAPON_INFO> weapons;
    
}
