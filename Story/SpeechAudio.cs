using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechAudio : MonoBehaviour {

    public AudioClip[] clipArray;
    public AudioSource effectSource;
    private int clipIndex;
    public float pitchMin, pitchMax, volumeMin, volumeMax;

    // Use this for initialization
    void Start () {
		
	}

    //void Update()
    //{
    //    if (Input.GetButton("Fire1"))
    //    {
    //        StartCoroutine(PlayAudio());
    //    }
    //}


    public void PlayRoundRobin()
    {
        //effectSource.pitch = Random.Range(pitchMin, pitchMax);
        //effectSource.volume = Random.Range(volumeMin, volumeMax);

        if (clipIndex < clipArray.Length)
        {
            effectSource.PlayOneShot(clipArray[clipIndex]);
            clipIndex++;
        }

        else
        {
            clipIndex = 0;
            effectSource.PlayOneShot(clipArray[clipIndex]);
            clipIndex++;
        }
    }

    public void PlayRandom()
    {
        effectSource.pitch = Random.Range(pitchMin, pitchMax);
        //effectSource.volume = Random.Range(volumeMin, volumeMax);

        clipIndex = RepeatCheck(clipIndex, clipArray.Length);
        effectSource.PlayOneShot(clipArray[clipIndex]);
    }

    int RepeatCheck(int previousIndex, int range)
    {
        int index = Random.Range(0, range);

        while (index == previousIndex)
        {
            index = Random.Range(0, range);
        }
        return index;
    }

    void TestSound()
    {
        StartCoroutine(PlayAudio());
    }

    IEnumerator PlayAudio()
    {
            PlayRandom();

            yield return new WaitForSecondsRealtime(1);
        }

    }

