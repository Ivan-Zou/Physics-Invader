using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDrop : MonoBehaviour {
    public AudioClip lifePickUpSound;
    void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;

        if (collider.CompareTag("Player")) {
            PlayerShip player = collider.gameObject.GetComponent<PlayerShip>();
            GameObject obj = GameObject.Find("GlobalObject");
            Global g = obj.GetComponent<Global>();
            // Increase player's lives
            g.lives++;
            // Play life pick up sound
            AudioSource.PlayClipAtPoint(lifePickUpSound, gameObject.transform.position);
            // destory the heart
            Destroy(gameObject);
        }
    }
}
