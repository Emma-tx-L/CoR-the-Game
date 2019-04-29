using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteRefManager : MonoBehaviour {

    public static SpriteRefManager spritesRef;

    public GameObject Pride;
    public GameObject Zephir;

    void Awake () {
        spritesRef = this;
	}
	
    public GameObject FindCharacter(string name)
    {
        if (name == "Pride")
        {
            return Pride;
        }

        if (name == "Zephir")
        {
            return Zephir;
        }

        else
        return null;
    }
}
