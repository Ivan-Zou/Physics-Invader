using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoUI : MonoBehaviour{
    PlayerShip playerObj;
    TMP_Text ammoText;
    // Start is called before the first frame update
    void Start() {
        GameObject g = GameObject.Find("PlayerShip");
        playerObj = g.GetComponent<PlayerShip>();
        ammoText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update() {
        ammoText.text = "AMMO: " + playerObj.ammoCount.ToString() + "/" + playerObj.maxAmmo.ToString();
    }
}
