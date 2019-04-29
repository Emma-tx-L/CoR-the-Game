using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float startingHealth = 1000;
    public float currentHealth;
    public int scoreValue = 10;
    //public AudioClip deathClip;
    public ParticleSystem deathPS;


    Animator anim;
    //AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;
    float timer;
    float sinkSpeed = 0.5f;

    void Awake()
    {
        anim = GetComponent<Animator>();
        //enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;

        anim.SetTrigger("Spawned");

    }


    void Update()
    {
        if (isSinking && timer >= 3f)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }

        timer += Time.deltaTime;
    }


    public void TakeDamage(float amount, Vector3 hitPoint)
    {
        if (isDead)
            return;

        //enemyAudio.Play();

        currentHealth -= amount;

        //Debug.Log(currentHealth);

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");

        deathPS.Play();

        StartSinking();

        //enemyAudio.clip = deathClip;
        //enemyAudio.Play();
    }


    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        timer = 0f;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 5f);
    }
}