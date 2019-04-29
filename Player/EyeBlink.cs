using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlink : MonoBehaviour
{

    //this should run independent of time scale, relevant for UI Sprites
    //attach this to the head, which has the EyeBothClose blendshape

    float waitSeconds = 5f;
    SkinnedMeshRenderer meshR;
    Mesh mesh;
    int blinkIn;
    float CD;

    bool blinking = false;
    bool closed = false;
    float timeOpen = 0f;
    float timeClose = 100f;
    float blinkSpeed = 300f;

    void Start()
    {
        meshR = GetComponent<SkinnedMeshRenderer>();
        mesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        blinkIn = mesh.GetBlendShapeIndex("EyeBothClose");

        CD = waitSeconds;

    }

    void Update()
    {


        if (blinking)
        {
            //if brand new blink is starting, turn on the eyeclose blendshape
            if (timeOpen < 100 && timeClose > 0 && !closed)
            {
                meshR.SetBlendShapeWeight(blinkIn, timeOpen);
                timeOpen += Time.unscaledDeltaTime * blinkSpeed;
            }

            //once eyes are closed, set closed to true
            else if (timeOpen >= 100 && !closed)
            {
                closed = true;
            }

            //if eyes already closed and is still closed, 
            else if (timeClose > 0 && closed)
            {
                meshR.SetBlendShapeWeight(blinkIn, timeClose);
                timeClose -= Time.unscaledDeltaTime * blinkSpeed;
            }

            //once eyes are fully open again after closing once, stop blinking
            else if (timeClose <= 0f && closed)
            {
                blinking = false;

            }

        }

        else //if not blinking
        {
            //decrement CD
            CD -= Time.unscaledDeltaTime;

            //once CD is 0, blink
            if (CD <= 0)
            {
                Blink();
            }
        }
    }



    void Blink()
    {
        //reinitialize
        timeOpen = 0f;
        timeClose = 100f;
        CD = waitSeconds;

        //start a new blink
        closed = false;
        blinking = true;

    }
}

