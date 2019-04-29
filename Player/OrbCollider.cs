using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCollider : MonoBehaviour {

    public bool canHit = true;
    private float damage = 20f;
    PlayerAttacks playerAttack;

	// Use this for initialization
	void Start () {

        playerAttack = GetComponentInParent<PlayerAttacks>();
	}

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth != null && canHit && playerAttack.orbOut)
        {
            enemyHealth.TakeDamage(damage, other.transform.position);

        }
    }
}
