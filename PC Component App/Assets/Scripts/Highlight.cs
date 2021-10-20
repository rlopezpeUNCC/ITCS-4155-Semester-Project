using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    Color hoverColor = Color.blue;
    Color currentColor;

    MeshRenderer mats;

    // Start is called before the first frame update
    void Start()
    {
        mats = GetComponent<MeshRenderer>();
        currentColor = mats.material.color;        
    }

    // Update is called once per frame
    void OnMouseOver() 
    {
        mats.material.color = hoverColor;        
    }

    void OnMouseExit()
    {
        mats.material.color = currentColor;
        
    }
}
