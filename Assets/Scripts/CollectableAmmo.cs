using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAmmo : MonoBehaviour {
    public AudioClip ammoPickUpSound;
    void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;

        if (collider.CompareTag("Player")) {
            PlayerShip player = collider.gameObject.GetComponent<PlayerShip>();
            // If the ammo count is not at capacity
            if (player.ammoCount < player.maxAmmo) {
                // Increase ammo count
                player.ammoCount++;
                // Play ammo pick up sound
                AudioSource.PlayClipAtPoint(ammoPickUpSound, gameObject.transform.position);
                // destory the ammo
                Destroy(gameObject);
            }
        }
    }
}
