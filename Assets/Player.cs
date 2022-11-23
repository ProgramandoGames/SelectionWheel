using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    SelectionWheel selectionWheel;
    SpriteRenderer weaponSprite;

    private void Awake() {

        selectionWheel = FindObjectOfType<SelectionWheel>();
        weaponSprite  = GetComponent<SpriteRenderer>();

    }

    void Start() {
        
    }

    void Update() {

        if(Input.GetKeyDown(KeyCode.Tab)) {
            selectionWheel.Open();
        }

        if(Input.GetKeyUp(KeyCode.Tab)) {
            selectionWheel.Close();
            weaponSprite.sprite = selectionWheel.selectedWeapon;
        }
        
    }

}
