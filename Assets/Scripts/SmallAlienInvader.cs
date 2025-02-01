using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAlienInvader : MonoBehaviour {
    public int pointValue;
    private float shootTimer, shootInterval;
    public float dropChance;
    // Start is called before the first frame update
    void Start() {
        pointValue = 30;
        dropChance = 0.05f;
        ResetShootTimer();
    }

    public AudioClip deathSound;
    public GameObject deathExplosion;
    public GameObject ammoDrop, lifeDrop;
    public void Die() {
        // Play death sound
        AudioSource.PlayClipAtPoint(deathSound, gameObject.transform.position);
        // Create explosion particles
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.identity);
        // Add points to score
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.score += pointValue;
        // Chance to drop either an ammoDrop or lifeDrop, but not both
        if (Random.value < dropChance) {
            GameObject dropItem = (Random.value < 0.5f) ? ammoDrop : lifeDrop;
            Vector3 spawnPos = gameObject.transform.position + new Vector3(0, 0, -0.5f);
            Instantiate(dropItem, spawnPos, Quaternion.identity);
        }
        // Destroy object
        Destroy(gameObject);

    }

    public bool canShoot;
    public GameObject projectile;
    // Update is called once per frame
    void Update() {
        if (canShoot) {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0) {
                Debug.Log("Alien Fires!");
                // Spawn Projectile
                Vector3 spawnPos = gameObject.transform.position;
                spawnPos.y -= 0.5f;
                GameObject obj = Instantiate(projectile, spawnPos, Quaternion.identity) as GameObject;
                ResetShootTimer();
            }
        }
    }

    void ResetShootTimer() {
        // Set a random interval between 5 to 10 seconds
        shootInterval = Random.Range(5.0f, 10.0f);
        shootTimer = shootInterval;
    }
}
