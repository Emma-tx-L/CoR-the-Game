using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingAttackFX : MonoBehaviour {

    int orbDamage = 10;

    void OnParticleCollision(GameObject other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(orbDamage); 

        }
    }
}
