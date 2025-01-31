using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAmmo : MonoBehaviour {
    void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;

        if (collider.CompareTag("Player")) {
            PlayerShip player = collider.gameObject.GetComponent<PlayerShip>();
            // Increase ammo count
            if (player.ammoCount < player.maxAmmo) {
                player.ammoCount++;
                // destory the ammo
                Destroy(gameObject);
            }
        }
    }
}
