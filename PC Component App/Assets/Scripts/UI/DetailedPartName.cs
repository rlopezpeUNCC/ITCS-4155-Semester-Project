using UnityEngine;
using System.Collections;
/* 
    Currently attached to all immediate children of Computer GameObject.
    
    Adds text field in Inspector to give each computer part a detailed name.
    This allows us to keep the model names generic in the hierarchy but give a more specific name for the user.
    This simplifies the part-tracking process for script TableCheckBoxes while allowing us to keep the "true" part name.

    Uses code from Unity3D documentation: https://docs.unity3d.com/Manual/VariablesAndTheInspector.html
*/
public class DetailedPartName : MonoBehaviour 
{
    public string partName;
    
    // Use this for initialization
    void Start () 
    {
        // Debug.Log("Part name is " + partName);
    }
}