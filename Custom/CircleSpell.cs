using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CircleSpell : MonoBehaviour {

    public ParticleSystem baseCircle;
    public ParticleSystem circleRise;
    public ParticleSystem sparklesRise;

    public float spellDuration; //total spell length time
    float spellCountdown; //countdown,  how much time is left

    int spellDamagePerTick;

    Rigidbody enemyRB;

    void Start() {
        spellCountdown = spellDuration;
        spellDamagePerTick = 15;

        baseCircle.Play();
        circleRise.Play();
        sparklesRise.Play();
    }


    void Update() {
        if (spellCountdown <= 0)
        {
            Destroy(gameObject, 3); //after a delay, destroy spell
            Destroy(GetComponent<SphereCollider>()); //no more collider effect
        }

        else if (spellCountdown <= 1.5) //collided enemies no longer stunned
        {
            SphereCollider collider = transform.GetComponent<SphereCollider>();
            collider.radius = 2.5f;

            spellCountdown -= Time.deltaTime; 
        }

        else
        {
            spellCountdown -= Time.deltaTime; //decrement duration per s as long as object is alive 
        }
    }

    //spell is present, damage and stun enemies in trigger range
    private void OnTriggerStay(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        EnemyMovement enemyMovement = other.GetComponent<EnemyMovement>();
        Animator enemyanim = other.GetComponent<Animator>();
        NavMeshAgent enemyNav = other.GetComponent<NavMeshAgent>();
        
        if (enemyHealth != null && enemyMovement != null) //if spell is alive and we hit an enemy
        {
            enemyHealth.TakeDamage(spellDamagePerTick * Time.deltaTime, other.transform.position); //enemy take damage

            enemyRB = other.GetComponent<Rigidbody>();
            //Vector3 toCenter = gameObject.transform.position - enemyRB.position;

            if (spellCountdown >= 1.5)
            {
                enemyNav.enabled = false;
                enemyMovement.enabled = false;
                enemyanim.SetBool("IsStunned", true);
                //enemyRB.isKinematic = false;
                //enemyRB.AddForce(toCenter, ForceMode.Impulse);
            }

            else
            {
                //enemyRB.isKinematic = true;
                enemyNav.enabled = true;
                enemyMovement.enabled = true;
                enemyanim.SetBool("IsStunned", false);
            }
        } 
    }
}


