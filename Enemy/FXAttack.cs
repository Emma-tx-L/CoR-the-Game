using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXAttack : MonoBehaviour {

    public int damage = 15;

    void Start()
    {
        var physicsMotion = GetComponentInChildren<RFX4_PhysicsMotion>(true);
        if (physicsMotion != null) physicsMotion.CollisionEnter += CollisionEnter;

        var raycastCollision = GetComponentInChildren<RFX4_RaycastCollision>(true);
        if (raycastCollision != null) raycastCollision.CollisionEnter += CollisionEnter;
    }

    private void CollisionEnter(object sender, RFX4_PhysicsMotion.RFX4_CollisionInfo e)
    {
        //Debug.Log(e.HitPoint); //a collision coordinates in world space
        //Debug.Log(e.HitGameObject.name); //a collided gameobject
        //Debug.Log(e.HitCollider.name); //a collided collider :)
        PlayerHealth playerHealth = e.HitGameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null && playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(damage);

        }
    }
}
