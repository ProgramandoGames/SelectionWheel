using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionWheel : MonoBehaviour {

    public Transform slotPrefab;
    public WeaponData weaponData;
    
    RectTransform   slotParent;
    RectTransform   background;
    TextMeshProUGUI weaponName;

    List<GameObject> slots = new List<GameObject> ();

    int slotsQtt   = 6;
    float distance = 300f;

    float angleInterval = 0;

    public Sprite selectedWeapon;

    private void Awake() {

        background = transform.GetChild(0).GetComponent<RectTransform>();
        slotParent = transform.GetChild(1).GetComponent<RectTransform>();
        weaponName = transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        selectedWeapon = weaponData.weapons[0].sprite;

    }

    void Start() {

        for(int i = 0; i < slotsQtt; ++i) {
            GameObject newSlot = Instantiate(slotPrefab, slotParent).gameObject;

            Image weaponImage = newSlot.transform.GetChild(0).GetComponent<Image>();

            weaponImage.sprite = weaponData.weapons[i].sprite;
            weaponImage.SetNativeSize();

            slots.Add(newSlot);
        }

        angleInterval = 360f / slotsQtt;

        for(int i = 0; i < slotsQtt; ++i) {

            var angle = (angleInterval * i) * Mathf.Deg2Rad;

            Vector2 position = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;

            slots[i].GetComponent<RectTransform>().localPosition = position;
            slots[i].GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg - 90);

            Transform weaponImage = slots[i].transform.GetChild(0);
            weaponImage.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, -angle * Mathf.Rad2Deg + 90);

        }

        gameObject.SetActive(false);

    }

    public void Open() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    void Selection() {

        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 mouseDir = (mousePos - Vector2.one * 0.5f).normalized;

        for(int i = 0; i < slots.Count; ++i) {

            var angle = Vector2.Angle(slots[i].transform.up, mouseDir);

            Image slotImage = slots[i].GetComponent<Image>();
            if(angle <= angleInterval / 2) {
                slotImage.color = Color.Lerp(slotImage.color, Color.white, 0.01f);
                weaponName.text = weaponData.weapons[i].name;
                selectedWeapon = weaponData.weapons[i].sprite;
            } else {
                slotImage.color = Color.Lerp(slotImage.color, Color.white * 0.5f, 0.01f);
            }

        }

    }


    void Update() {

        Selection();

    }

}
