using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    Rigidbody enemyRB;
    Animator enemyAC;

    //public float stunTime;
    //float stunCounter;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyRB = GetComponent<Rigidbody>();
        enemyAC = GetComponent<Animator>();
    }


    void Update()
    {
        //requirements for enabling movement: enemy alive, player alive, enemy not stunned
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && nav.isActiveAndEnabled)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }

    public void Interrupt()
    {
        nav.enabled = false;
        //enemyRB.AddForce(-transform.forward * 10, ForceMode.Impulse);
        enemyAC.Play("P_Knockback");

        Invoke("ReNav", 1);
    }

    void ReNav()
    {
        nav.enabled = true;
    }
}