using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAmmo : MonoBehaviour {
    public AudioClip ammoPickUpSound;
    public int ammoCount;
    void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;

        if (collider.CompareTag("Player")) {
            PlayerShip player = collider.gameObject.GetComponent<PlayerShip>();
            // If the ammo count is not at capacity
            if (player.ammoCount < player.maxAmmo) {
                // Increase ammo count
                player.ammoCount += ammoCount;
                // Play ammo pick up sound
                AudioSource.PlayClipAtPoint(ammoPickUpSound, gameObject.transform.position);
                // destory the ammo
                Destroy(gameObject);
            }
        } else if (collision.collider.CompareTag("Floor")) {
            
        } else {
            // If it collides with anything else and is the Ammo Drop, ignore the collision
            if (ammoCount == 15) {
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            }
        }
    }
}
