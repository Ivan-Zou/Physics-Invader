using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // Destroy projectiles when they are off-screen
        if (gameObject.transform.position.y < -3) {
            Destroy(gameObject);
        }
    }
}
