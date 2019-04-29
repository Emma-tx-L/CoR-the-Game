using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blendshapes : MonoBehaviour {

    //attach this to the body part with blendshapes (probably the Head)


    int newBlendIndex;

    string currBlend = "";
    int currBlendIndex;


    Mesh mesh;
    SkinnedMeshRenderer meshR;
    int blendShapeCount;


    void Start () {

        meshR = GetComponent<SkinnedMeshRenderer>();

        mesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        blendShapeCount = mesh.blendShapeCount;

    } 

    
    public void BlendShape(string passedBlend)
    {

        //if this is the first pose in the story, and there hasn't been a previous yet
        if (currBlend == "" && passedBlend != null)
        {

            newBlendIndex = mesh.GetBlendShapeIndex(passedBlend);

            meshR.SetBlendShapeWeight(newBlendIndex, 100);

            //this is  now the current face
            currBlend = passedBlend;
            currBlendIndex = newBlendIndex;
        }

        else if (currBlend != passedBlend)
        {
            //Debug.Log(passedBlend);
            newBlendIndex = mesh.GetBlendShapeIndex(passedBlend);

            //remove current face and pass in new face
            meshR.SetBlendShapeWeight(currBlendIndex, 0);
            meshR.SetBlendShapeWeight(newBlendIndex, 100);

            //update current face
            currBlend = passedBlend;
            currBlendIndex = newBlendIndex;


        }
    }


    //resets all blendshapes to zero
    public void ResetShapes()
    {
        for (int i = 0; i < blendShapeCount; i++)
        {
            meshR.SetBlendShapeWeight(i, 0);
        }

        //reinitialize
        currBlend = "";
    }
	

}
