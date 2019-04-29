using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaterial : MonoBehaviour
{
    //Color emitcolor;

    Material enemymat;

    public EnemyHealth enemyHealth;
    //float lerpSpeed = 0.4f;
    //float t;

    //Color purple = new Color(39f, 0f, 255f);
    //Color blue = new Color(0f, 166f, 255f);

    void Start()
    {
        enemymat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if ((enemyHealth.currentHealth / enemyHealth.startingHealth) <= 0.05)
        {
            //emitcolor = Color.Lerp(blue, Color.black, Mathf.PingPong(t, lerpSpeed));
            enemymat.SetColor("_MKGlowColor", Color.white);
            enemymat.SetColor("_MKGlowTexColor", Color.white);
        }

        else if ((enemyHealth.currentHealth / enemyHealth.startingHealth) <= 0.2)
        {
            //emitcolor = Color.Lerp(purple, blue, Mathf.PingPong(t, lerpSpeed));
            enemymat.SetColor("_MKGlowColor", Color.yellow);
            enemymat.SetColor("_MKGlowTexColor", Color.yellow);
        }

        else if ((enemyHealth.currentHealth / enemyHealth.startingHealth) <= 0.3)
        {
            //emitcolor = Color.Lerp(Color.white, purple, Mathf.PingPong(t, lerpSpeed));
            enemymat.SetColor("_MKGlowColor", Color.green);
            enemymat.SetColor("_MKGlowTexColor", Color.green);
        }

        else if ((enemyHealth.currentHealth / enemyHealth.startingHealth) <= 0.5)
        {
            //emitcolor = Color.Lerp(purple, blue, Mathf.PingPong(t, lerpSpeed));
            enemymat.SetColor("_MKGlowColor", Color.cyan);
            enemymat.SetColor("_MKGlowTexColor", Color.cyan);

        }
    }
}
