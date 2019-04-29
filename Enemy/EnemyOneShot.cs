using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneShot : MonoBehaviour
{
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    CapsuleCollider capsuleCollider;
    EnemyMovement enemyMovement;
    bool attacked = false;

    public ParticleSystem blowUp;

    //bool playerInRange;
    //float timer;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !attacked)
        {
            attacked = true;
            //playerInRange = true;
            Attack();
        }
    }

    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }

    void Attack()
    {
        //timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
            anim.SetTrigger("Attacked");
            Destroy(capsuleCollider, 1f);
            enemyMovement.enabled = false;
            blowUp.Play(true);
            Destroy(gameObject, 2.5f);
        }
    }
}